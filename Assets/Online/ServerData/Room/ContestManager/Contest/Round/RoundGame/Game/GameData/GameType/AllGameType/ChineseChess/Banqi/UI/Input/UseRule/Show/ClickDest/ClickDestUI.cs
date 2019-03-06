using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Banqi.UseRule
{
	public class ClickDestUI : UIBehavior<ClickDestUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : ShowUI.UIData.Sub
		{

			public VP<int> x;

			public VP<int> y;

			public LP<LegalMoveUI.UIData> legalMoves;

			#region keyEvent

			public VP<int> keyX;

			public VP<int> keyY;

			#endregion

			#region Constructor

			public enum Property
			{
				x,
				y,
				legalMoves,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.x = new VP<int>(this, (byte)Property.x, 0);
				this.y = new VP<int>(this, (byte)Property.y, 0);
				this.legalMoves = new LP<LegalMoveUI.UIData>(this, (byte)Property.legalMoves);
				// keyEvent
				{
					this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
					this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
				}
			}

			#endregion

			public override Type getType ()
			{
				return Type.ClickDest;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// key
					if (!isProcess) {
						if (InputEvent.isEnter (e)) {
							// enter
							ClickDestUI clickDestUI = this.findCallBack<ClickDestUI> ();
							if (clickDestUI != null) {
								clickDestUI.onEnterKey ();
							} else {
								Debug.LogError ("clickDestUI null: " + this);
							}
							isProcess = true;
						} else if (InputEvent.isArrow (e)) {
							if (this.keyX.v >= 0 && this.keyX.v < 8
								&& this.keyY.v >= 0 && this.keyY.v < 4) {
								// find new key position
								int newKeyX = this.keyX.v;
								int newKeyY = this.keyY.v;
								{
									switch (e.keyCode) {
									case KeyCode.LeftArrow:
										newKeyX--;
										break;
									case KeyCode.RightArrow:
										newKeyX++;
										break;
									case KeyCode.UpArrow:
										newKeyY++;
										break;
									case KeyCode.DownArrow:
										newKeyY--;
										break;
									default:
										Debug.LogError ("unknown keyCode: " + e.keyCode);
										break;
									}
								}
								// set
								if (newKeyX >= 0 && newKeyX < 8
									&& newKeyY >= 0 && newKeyY < 4) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								this.keyX.v = this.x.v;
								this.keyY.v = this.y.v;
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public GameObject ivSelect;

		public GameObject keySelect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// keySelect
					{
						if (keySelect != null) {
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
							    && this.data.keyY.v >= 0 && this.data.keyY.v < 4) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertPosToLocalPosition (8 * this.data.keyY.v + this.data.keyX.v);
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
					}
					// imgSelect
					{
						if (ivSelect != null) {
							// localPosition
							{
								ivSelect.transform.localPosition = Common.convertPosToLocalPosition (8 * this.data.y.v + this.data.x.v);
							}
							// TODO co the co rotate
							{
								// TODO Can hoan thien
							}
						} else {
							Debug.LogError ("imgSelect null: " + this);
						}
					}
					// Legal moves
					{
						// get oldLegalMoves
						List<LegalMoveUI.UIData> oldLegalMoves = new List<LegalMoveUI.UIData> ();
						{
							oldLegalMoves.AddRange (this.data.legalMoves.vs);
						}
						// Update
						{
							// Get legal move list
							List<BanqiMove> legalMoves = new List<BanqiMove> ();
							{
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								if (show != null) {
									foreach (BanqiMove legalMove in show.legalMoves.vs) {
										if (legalMove.fromX.v - 1 == this.data.x.v && (3 - (legalMove.fromY.v - 1)) == this.data.y.v) {
											legalMoves.Add (legalMove);
										}
									}
								} else {
									Debug.LogError ("show null: " + this);
								}
							}
							// Make UI
							{
								foreach (BanqiMove banqiMove in legalMoves) {
									// find UI
									LegalMoveUI.UIData legalMoveUIData = null;
									bool needAdd = false;
									{
										// find old
										foreach (LegalMoveUI.UIData check in oldLegalMoves) {
											if (check.banqiMove.v.data == banqiMove) {
												legalMoveUIData = check;
												break;
											} else if (check.banqiMove.v.data == null) {
												legalMoveUIData = check;
											}
										}
										// make new
										if (legalMoveUIData == null) {
											legalMoveUIData = new LegalMoveUI.UIData ();
											{
												legalMoveUIData.uid = this.data.legalMoves.makeId ();
											}
											needAdd = true;
										} else {
											oldLegalMoves.Remove (legalMoveUIData);
										}
									}
									// Update
									{
										legalMoveUIData.banqiMove.v = new ReferenceData<BanqiMove> (banqiMove);
									}
									// Add
									if (needAdd) {
										this.data.legalMoves.add (legalMoveUIData);
									}
								}
							}
						}
						// Remove old
						foreach (LegalMoveUI.UIData legalMoveUIData in oldLegalMoves) {
							legalMoveUIData.banqiMove.v = new ReferenceData<BanqiMove> (null);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region implement callBacks

		public LegalMoveUI legalMovePrefab;

		private ShowUI.UIData show = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.show);
				}
				// Child
				{
					uiData.legalMoves.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is ShowUI.UIData) {
				dirty = true;
				return;
			}
			// Child
			if (data is LegalMoveUI.UIData) {
				LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
				// UI
				{
					UIUtils.Instantiate (legalMoveUIData, legalMovePrefab, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.show);
				}
				// Child
				{
					uiData.legalMoves.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			if (data is ShowUI.UIData) {
				return;
			}
			// Child
			if (data is LegalMoveUI.UIData) {
				LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
				// UI
				{
					legalMoveUIData.removeCallBackAndDestroy (typeof(LegalMoveUI));
				}
				return;
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
					dirty = true;
					break;
				case UIData.Property.y:
					dirty = true;
					break;
				case UIData.Property.legalMoves:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.keyX:
					dirty = true;
					break;
				case UIData.Property.keyY:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is ShowUI.UIData) {
				switch ((ShowUI.UIData.Property)wrapProperty.n) {
				case ShowUI.UIData.Property.legalMoves:
					dirty = true;
					break;
				case ShowUI.UIData.Property.sub:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is LegalMoveUI.UIData) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		private void clickDest(int x, int y)
		{
			if (this.data != null) {
				Banqi banqi = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						banqi = useRuleInputUIData.banqi.v.data;
						if (banqi != null) {
							if (global::Game.IsPlaying (banqi)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("banqi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 8 && y >= 0 && y < 4) {
						// Click the same already click
						bool isCurrentSelect = false;
						{
							if (this.data.x.v == x && this.data.y.v == y) {
								isCurrentSelect = true;
							}
						}
						if (isCurrentSelect) {
							// Find move click
							BanqiMove banqiMove = null;
							{
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								if (show != null) {
									foreach (BanqiMove check in show.legalMoves.vs) {
										if (check.fromX.v - 1 == this.data.x.v && (3 - (check.fromY.v - 1)) == this.data.y.v && check.destX.v - 1 == x && (3 - (check.destY.v - 1)) == y) {
											banqiMove = check;
											break;
										}
									}
								} else {
									Debug.LogError ("show null: " + this);
								}
							}
							if (banqiMove != null) {
								ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
								if (clientInput != null) {
									clientInput.makeSend (banqiMove);
								} else {
									Debug.LogError ("clientInput null: " + this);
								}
							} else {
								// Chuyen ve ClickPieceUI
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								if (show != null) {
									ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
									{
										clickPieceUIData.uid = show.sub.makeId ();
									}
									show.sub.v = clickPieceUIData;
								} else {
									Debug.LogError ("show null: " + this);
								}
							}
						} else {
							// select other piece in the same side
							bool isSelectOtherPiece = false;
							{
								Token.Ecolor color;
								Token.Type type;
								bool isFaceUp;
								banqi.getPiece (8 * y + x, out color, out type, out isFaceUp);
								if (color != Token.Ecolor.None) {
									if (isFaceUp) {
										if (color == banqi.color.v) {
											isSelectOtherPiece = true;
										}
									} else {
										isSelectOtherPiece = true;
									}
								}
							}
							if (isSelectOtherPiece) {
								this.data.x.v = x;
								this.data.y.v = y;
							} else {
								// Find move click
								BanqiMove banqiMove = null;
								{
									ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
									if (show != null) {
										foreach (BanqiMove check in show.legalMoves.vs) {
											if (check.fromX.v - 1 == this.data.x.v && (3 - (check.fromY.v - 1)) == this.data.y.v && check.destX.v - 1 == x && (3 - (check.destY.v - 1)) == y) {
												banqiMove = check;
												break;
											}
										}
									} else {
										Debug.LogError ("show null: " + this);
									}
								}
								if (banqiMove != null) {
									ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
									if (clientInput != null) {
										clientInput.makeSend (banqiMove);
									} else {
										Debug.LogError ("clientInput null: " + this);
									}
								} else {
									Debug.LogError ("click not dest position: " + this);
								}
							}
						}
					} else {
						Debug.LogError ("click outside board");
					}
				} else {
					Debug.LogError ("not active: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onEnterKey()
		{
			if (this.data != null) {
				this.clickDest (this.data.keyX.v, this.data.keyY.v);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.LogError ("OnPointerDown: " + eventData + "; " + this);
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int x = 0;
			int y = 0;
			{
				Common.convertLocalPostionToPos (localPosition, out x, out y);
			}
			Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			this.clickDest (x, y);
		}

	}
}