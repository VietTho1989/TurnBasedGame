using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class ScrollViewUI : UIBehavior<ScrollViewUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			#region x

			public VP<RequestChangeFloatUI.UIData> x;

			public void makeRequestChangeX (RequestChangeUpdate<float>.UpdateData update, float newX)
			{
				// Find
				BoardUI.UIData boardUIData = this.findDataInParent<BoardUI.UIData>();
				// Process
				if (boardUIData != null) {
					boardUIData.x.v = newX;
				} else {
					Debug.LogError ("boardUIData null: " + this);
				}
			}

			#endregion

			#region y

			public VP<RequestChangeFloatUI.UIData> y;

			public void makeRequestChangeY (RequestChangeUpdate<float>.UpdateData update, float newY)
			{
				// Find
				BoardUI.UIData boardUIData = this.findDataInParent<BoardUI.UIData>();
				// Process
				if (boardUIData != null) {
					boardUIData.y.v = newY;
				} else {
					Debug.LogError ("boardUIData null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				x,
				y
			}

			public UIData() : base()
			{
				// x
				{
					this.x = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.x, new RequestChangeFloatUI.UIData());
					// have limit
					{
						FloatLimit.Have have = new FloatLimit.Have();
						{
							have.uid = this.x.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 0;
						}
						this.x.v.limit.v = have;
					}
					// event
					{
						this.x.v.updateData.v.request.v = makeRequestChangeX;
						this.x.v.updateData.v.waitTime.v = 0.01f;// Time.fixedDeltaTime;
					}
				}
				// y
				{
					this.y = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.y, new RequestChangeFloatUI.UIData());
					// have limit
					{
						FloatLimit.Have have = new FloatLimit.Have();
						{
							have.uid = this.y.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 0;
						}
						this.y.v.limit.v = have;
					}
					// event
					{
						this.y.v.updateData.v.request.v = makeRequestChangeY;
						this.y.v.updateData.v.waitTime.v = 0.01f;// Time.fixedDeltaTime;
					}
				}
			}

			#endregion

		}

		#endregion

		#region Refresh

		private bool needReset = true;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
					if (boardUIData != null) {
						// get server state
						Server.State.Type serverState = Server.State.Type.Connect;
						{
							// Co le khong can
						}
						// limit
						{
							MineSweeper mineSweeper = boardUIData.mineSweeper.v.data;
							if (mineSweeper != null) {
								// x
								{
									// Find limit
									FloatLimit.Have limitX = null;
									{
										RequestChangeFloatUI.UIData x = this.data.x.v;
										if (x != null) {
											if (x.limit.v is FloatLimit.Have) {
												limitX = x.limit.v as FloatLimit.Have;
											} else {
												Debug.LogError ("why not intLimit: " + this);
											}
										} else {
											Debug.LogError ("x null: " + this);
										}
									}
									// Set
									if (limitX != null) {
										limitX.min.v = 0;
										limitX.max.v = mineSweeper.X.v - boardUIData.width.v;
									} else {
										Debug.LogError ("limitX null: " + this);
									}
								}
								// y
								{
									// Find limit
									FloatLimit.Have limitY = null;
									{
										RequestChangeFloatUI.UIData y = this.data.y.v;
										if (y != null) {
											if (y.limit.v is FloatLimit.Have) {
												limitY = y.limit.v as FloatLimit.Have;
											} else {
												Debug.LogError ("why not intLimit: " + this);
											}
										} else {
											Debug.LogError ("y null: " + this);
										}
									}
									// Set
									if (limitY != null) {
										limitY.min.v = 0;
										limitY.max.v = mineSweeper.Y.v - boardUIData.height.v;
									} else {
										Debug.LogError ("limitY null: " + this);
									}
								}
							} else {
								Debug.LogError ("mineSweeper null: " + this);
							}
						}
						// x
						{
							RequestChangeFloatUI.UIData x = this.data.x.v;
							if (x != null) {
								// Show or not
								bool show = false;
								{
									if (x.limit.v is FloatLimit.Have) {
										FloatLimit.Have limitX = x.limit.v as FloatLimit.Have;
										if (limitX.max.v > limitX.min.v) {
											show = true;
										}
									} else {
										Debug.LogError ("why not intLimit: " + this);
									}
								}
								// Process
								if (show) {
									// show
									if (xContainer != null) {
										xContainer.gameObject.SetActive (true);
									} else {
										Debug.LogError ("xContainer null: " + this);
									}
									// set orgin
									{
										RequestChangeUpdate<float>.UpdateData updateData = x.updateData.v;
										if (updateData != null) {
											updateData.origin.v = boardUIData.x.v;
											Debug.LogError ("set origin: " + updateData.origin.v);
											updateData.canRequestChange.v = true;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									}
									// reset
									if (needReset) {
										RequestChangeUpdate<float>.UpdateData updateData = x.updateData.v;
										if (updateData != null) {
											updateData.current.v = boardUIData.x.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									}
								} else {
									// hide
									if (xContainer != null) {
										xContainer.gameObject.SetActive (false);
									} else {
										Debug.LogError ("xContainer null: " + this);
									}
								}
							} else {
								Debug.LogError ("x null: " + this);
							}
						}
						// y
						{
							RequestChangeFloatUI.UIData y = this.data.y.v;
							if (y != null) {
								// Show or not
								bool show = false;
								{
									if (y.limit.v is FloatLimit.Have) {
										FloatLimit.Have limitY = y.limit.v as FloatLimit.Have;
										if (limitY.max.v > limitY.min.v) {
											show = true;
										}
									} else {
										Debug.LogError ("why not intLimit: " + this);
									}
								}
								// Process
								if (show) {
									// show
									if (yContainer != null) {
										yContainer.gameObject.SetActive (true);
									} else {
										Debug.LogError ("yContainer null: " + this);
									}
									// set orgin
									{
										RequestChangeUpdate<float>.UpdateData updateData = y.updateData.v;
										if (updateData != null) {
											updateData.origin.v = boardUIData.y.v;
											updateData.canRequestChange.v = true;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									}
									// reset
									if (needReset) {
										RequestChangeUpdate<float>.UpdateData updateData = y.updateData.v;
										if (updateData != null) {
											updateData.current.v = boardUIData.y.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									}
								} else {
									// hide
									if (yContainer != null) {
										yContainer.gameObject.SetActive (false);
									} else {
										Debug.LogError ("yContainer null: " + this);
									}
								}
							} else {
								Debug.LogError ("y null: " + this);
							}
						}
						needReset = false;
					} else {
						Debug.LogError ("boardUIData null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public RequestChangeFloatUI requestFloatPrefab;

		public Transform xContainer;
		public Transform yContainer;

		private BoardUI.UIData boardUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.boardUIData);
				}
				// Child
				{
					uiData.x.allAddCallBack (this);
					uiData.y.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is BoardUI.UIData) {
					BoardUI.UIData boardUIData = data as BoardUI.UIData;
					// Child
					{
						boardUIData.mineSweeper.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is MineSweeper) {
					needReset = true;
					dirty = true;
					return;
				}
			}
			// Child
			{
				// x, y
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.x:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, xContainer);
								break;
							case UIData.Property.y:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, yContainer);
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("wrapProperty null: " + this);
						}
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
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.boardUIData);
				}
				// Child
				{
					uiData.x.allRemoveCallBack (this);
					uiData.y.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is BoardUI.UIData) {
					BoardUI.UIData boardUIData = data as BoardUI.UIData;
					// Child
					{
						boardUIData.mineSweeper.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is MineSweeper) {
					return;
				}
			}
			// Child
			{
				// x, y
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeFloatUI));
					}
					dirty = true;
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
				case UIData.Property.x:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.y:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is BoardUI.UIData) {
					switch ((BoardUI.UIData.Property)wrapProperty.n) {
					case BoardUI.UIData.Property.mineSweeper:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case BoardUI.UIData.Property.background:
						break;
					case BoardUI.UIData.Property.boundary:
						break;
					case BoardUI.UIData.Property.scrollView:
						break;
					case BoardUI.UIData.Property.pieces:
						break;
					case BoardUI.UIData.Property.booom:
						break;
					case BoardUI.UIData.Property.allowWatchBomb:
						break;
					case BoardUI.UIData.Property.maxWidth:
						break;
					case BoardUI.UIData.Property.maxHeight:
						break;
					case BoardUI.UIData.Property.x:
						dirty = true;
						break;
					case BoardUI.UIData.Property.y:
						dirty = true;
						break;
					case BoardUI.UIData.Property.width:
						dirty = true;
						break;
					case BoardUI.UIData.Property.height:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is MineSweeper) {
					switch ((MineSweeper.Property)wrapProperty.n) {
					case MineSweeper.Property.Y:
						dirty = true;
						break;
					case MineSweeper.Property.X:
						dirty = true;
						break;
					case MineSweeper.Property.K:
						break;
					case MineSweeper.Property.bombs:
						break;
					case MineSweeper.Property.booom:
						break;
					case MineSweeper.Property.flags:
						break;
					case MineSweeper.Property.board:
						break;
					case MineSweeper.Property.minesFound:
						break;
					case MineSweeper.Property.init:
						break;
					case MineSweeper.Property.neb:
						break;
					case MineSweeper.Property.allowWatchBoomb:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
				// x, y
				if (wrapProperty.p is RequestChangeFloatUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}