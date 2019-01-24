using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class LaserPathUI : UIBehavior<LaserPathUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Khet>> khet;

			public LP<LaserPointUI.UIData> laserPoints;

			#region Force

			public enum Force
			{
				None,
				All,
				Silver,
				Red,
				Hide
			}

			public VP<Force> force;

			#endregion

			#region Show

			public enum Show
			{
				All,
				Silver,
				Red,
				None
			}

			public VP<Show> show;

			#endregion

			#region Constructor

			public enum Property
			{
				khet,
				laserPoints,
				force,
				show
			}

			public UIData() : base()
			{
				this.khet = new VP<ReferenceData<Khet>>(this, (byte)Property.khet, new ReferenceData<Khet>(null));
				this.laserPoints = new LP<LaserPointUI.UIData>(this, (byte)Property.laserPoints);
				this.force = new VP<Force>(this, (byte)Property.force, Force.None);
				this.show = new VP<Show>(this, (byte)Property.show, Show.None);
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region drShow

		public Dropdown drShow;

		public override void Awake ()
		{
			base.Awake ();
			if (drShow != null) {
				drShow.onValueChanged.AddListener (delegate(int newValue) {
					if (this.data != null) {
						this.data.show.v = (UIData.Show)newValue;
					} else {
						Debug.LogError ("data null: " + this);
					}
				});
			} else {
				Debug.LogError ("drShow null: " + this);
			}
		}

		public static readonly TxtLanguage txtAll = new TxtLanguage ();
		public static readonly TxtLanguage txtSilver = new TxtLanguage ();
		public static readonly TxtLanguage txtRed = new TxtLanguage ();
		public static readonly TxtLanguage txtNone = new TxtLanguage ();

		static LaserPathUI()
		{
			txtAll.add (Language.Type.vi, "Tất cả");
			txtSilver.add (Language.Type.vi, "Bạc");
			txtRed.add (Language.Type.vi, "Đỏ");
			txtNone.add (Language.Type.vi, "Không");
		}

		#endregion

		public UILineRenderer silverLine;
		public UILineRenderer redLine;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Khet khet = this.data.khet.v.data;
					if (khet != null) {
						// drShow
						{
							if (drShow != null) {
								// options
								{
									string[] options = { 
										txtAll.get ("All"),
										txtSilver.get ("Silver"),
										txtRed.get ("Red"),
										txtNone.get ("None")
									};
									UIUtils.RefreshDropDownOptions (drShow, options);
								}
								// set value
								drShow.value = (int)this.data.show.v;
								drShow.RefreshShownValue ();
							} else {
								Debug.LogError ("drShow null");
							}
						}
						// check load full
						bool isLoadFull = true;
						{
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// Find MoveAnimation
							MoveAnimation moveAnimation = null;
							float time = 0;
							float duration = 0;
							{
								GameDataBoardUI.UIData.getCurrentMoveAnimationInfo (this.data, out moveAnimation, out time, out duration);
							}
							// find force
							{
								UIData.Force force = UIData.Force.None;
								{
									if (moveAnimation != null) {
										force = UIData.Force.Hide;
										switch (moveAnimation.getType ()) {
										case GameMove.Type.KhetMove:
											{
												KhetMoveAnimation khetMoveAnimation = moveAnimation as KhetMoveAnimation;
												if (time >= khetMoveAnimation.moveTime.v + khetMoveAnimation.rotateTime.v) {
													if (khetMoveAnimation.playerToMove.v == (int)Common.Player.Silver) {
														force = UIData.Force.Silver;
													} else {
														force = UIData.Force.Red;
													}
												}
											}
											break;
										default:
											Debug.LogError ("unknown moveAnimation: " + moveAnimation);
											break;
										}
									} else {
										// Debug.LogError ("moveAnimation null");
									}
								}
								this.data.force.v = force;
							}
							// line
							if (silverLine != null && redLine != null) {
								// find, silver, red points
								List<int> silvers = null;
								List<int> reds = null;
								{
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.KhetMove:
											{
												KhetMoveAnimation khetMoveAnimation = moveAnimation as KhetMoveAnimation;
												// silvers
												{
													silvers = new List<int> ();
													if (!khetMoveAnimation.isKill.v) {
														silvers.AddRange (khetMoveAnimation.silverLine.vs);
													} else {
														foreach (int silver in khetMoveAnimation.silverLine.vs) {
															silvers.Add (silver);
															if (silver == khetMoveAnimation.laserTargetIndex.v) {
																break;
															}
														}
													}
												}
												// reds
												{
													reds = new List<int> ();
													if (!khetMoveAnimation.isKill.v) {
														reds.AddRange (khetMoveAnimation.redLine.vs);
													} else {
														foreach (int red in khetMoveAnimation.redLine.vs) {
															reds.Add (red);
															if (red == khetMoveAnimation.laserTargetIndex.v) {
																break;
															}
														}
													}
												}
											}
											break;
										default:
											Debug.LogError ("unknown moveAnimation: " + moveAnimation);
											break;
										}
									} else {
										Debug.LogError ("moveAnimation null");
									}
									// normal
									{
										if (silvers == null) {
											silvers = Core.unityGetMyLaserPath (khet, Core.CanCorrect, Common.Player.Silver);
										}
										if (reds == null) {
											reds = Core.unityGetMyLaserPath (khet, Core.CanCorrect, Common.Player.Red);
										}
									}
								}
								// add start points
								{
									silvers.Insert (0, 1 * Common.BoardWidth + (Common.BoardWidth - 2));
									reds.Insert (0, (Common.BoardHeight - 2) * Common.BoardWidth + 1);
								}
								// make line
								{
									// silver
									{
										// find show
										bool show = false;
										{
											switch (this.data.force.v) {
											case UIData.Force.None:
												{
													switch (this.data.show.v) {
													case UIData.Show.All:
														show = true;
														break;
													case UIData.Show.Silver:
														show = true;
														break;
													case UIData.Show.Red:
														break;
													case UIData.Show.None:
														break;
													default:
														Debug.LogError ("unknown show: " + this.data.show.v);
														break;
													}
												}
												break;
											case UIData.Force.All:
												show = true;
												break;
											case UIData.Force.Silver:
												show = true;
												break;
											case UIData.Force.Red:
												break;
											case UIData.Force.Hide:
												break;
											default:
												Debug.LogError ("unknown force: " + this.data.force.v);
												break;
											}
										}
										// process
										if (show) {
											Vector2[] silverPoints = new Vector2[silvers.Count];
											{
												for (int i = 0; i < silvers.Count; i++) {
													silverPoints [i] = Common.getLocalPosition (silvers [i]);
												}
											}
											silverLine.Points = silverPoints;
										} else {
											silverLine.Points = new Vector2[0];
										}
									}
									// red
									{
										// find show
										bool show = false;
										{
											switch (this.data.force.v) {
											case UIData.Force.None:
												{
													switch (this.data.show.v) {
													case UIData.Show.All:
														show = true;
														break;
													case UIData.Show.Silver:
														break;
													case UIData.Show.Red:
														show = true;
														break;
													case UIData.Show.None:
														break;
													default:
														Debug.LogError ("unknown show: " + this.data.show.v);
														break;
													}
												}
												break;
											case UIData.Force.All:
												show = true;
												break;
											case UIData.Force.Silver:
												break;
											case UIData.Force.Red:
												show = true;
												break;
											case UIData.Force.Hide:
												break;
											default:
												Debug.LogError ("unknown force: " + this.data.force.v);
												break;
											}
										}
										// process
										if (show) {
											Vector2[] redPoints = new Vector2[reds.Count];
											{
												for (int i = 0; i < reds.Count; i++) {
													redPoints [i] = Common.getLocalPosition (reds [i]);
												}
											}
											redLine.Points = redPoints;
										} else {
											redLine.Points = new Vector2[0];
										}
									}
								}
							} else {
								Debug.LogError ("silverLine, redLine null");
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("khet null");
					}
				} else {
					Debug.LogError ("data null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public LaserPointUI laserPointPrefab;
		public Transform laserPointContainer;

		private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// checkChange
				{
					animationManagerCheckChange.needTimeChange = true;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (uiData);
				}
				// Child
				{
					uiData.khet.allAddCallBack (this);
					uiData.laserPoints.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Khet) {
					dirty = true;
					return;
				}
				if (data is LaserPointUI.UIData) {
					LaserPointUI.UIData laserPointUIData = data as LaserPointUI.UIData;
					// UI
					{
						UIUtils.Instantiate (laserPointUIData, laserPointPrefab, this.transform);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().removeCallBack(this);
				// checkChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				// Child
				{
					uiData.khet.allRemoveCallBack (this);
					uiData.laserPoints.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				return;
			}
			// Child
			{
				if (data is Khet) {
					return;
				}
				if (data is LaserPointUI.UIData) {
					LaserPointUI.UIData laserPointUIData = data as LaserPointUI.UIData;
					// UI
					{
						laserPointUIData.removeCallBackAndDestroy (typeof(LaserPointUI));
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.khet:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.laserPoints:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.force:
					dirty = true;
					break;
				case UIData.Property.show:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Setting
			if (wrapProperty.p is Setting) {
				switch ((Setting.Property)wrapProperty.n) {
				case Setting.Property.language:
					dirty = true;
					break;
				case Setting.Property.showLastMove:
					break;
				case Setting.Property.viewUrlImage:
					break;
				case Setting.Property.animationSetting:
					break;
				case Setting.Property.maxThinkCount:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is Khet) {
					switch ((Khet.Property)wrapProperty.n) {
					case Khet.Property._playerToMove:
						dirty = true;
						break;
					case Khet.Property._checkmate:
						break;
					case Khet.Property._drawn:
						break;
					case Khet.Property._moveNumber:
						break;
					case Khet.Property._laser:
						dirty = true;
						break;
					case Khet.Property._board:
						dirty = true;
						break;
					case Khet.Property._pharaohPositions:
						break;
					case Khet.Property.khetSub:
						break;
					case Khet.Property.isCustom:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is LaserPointUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}