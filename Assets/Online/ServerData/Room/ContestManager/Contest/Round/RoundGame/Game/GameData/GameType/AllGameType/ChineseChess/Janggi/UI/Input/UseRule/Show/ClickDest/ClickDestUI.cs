using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Janggi.UseRule
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
							if (this.keyX.v >= 0 && this.keyX.v < 9
								&& this.keyY.v >= 0 && this.keyY.v < 10) {
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
								if (newKeyX >= 0 && newKeyX < 9
									&& newKeyY >= 0 && newKeyY < 10) {
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

		public Image imgSelect;

		public GameObject keySelect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// keySelect
					{
						if (keySelect != null) {
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 9
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 10) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.keyX.v, this.data.keyY.v);
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
					}
					// imgSelect
					{
						if (imgSelect != null) {
							// localPosition
							{
								imgSelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.x.v, this.data.y.v);
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
							List<JanggiMove> legalMoves = new List<JanggiMove>();
							{
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								if (show != null) {
									foreach (JanggiMove legalMove in show.legalMoves.vs) {
										if (legalMove.fromX.v == this.data.x.v && legalMove.fromY.v == this.data.y.v) {
											legalMoves.Add (legalMove);
										}
									}
								} else {
									Debug.LogError ("show null: " + this);
								}
							}
							// Make UI
							{
								foreach (JanggiMove janggiMove in legalMoves) {
									// find UI
									LegalMoveUI.UIData legalMoveUIData = null;
									bool needAdd = false;
									{
										// find old
										foreach (LegalMoveUI.UIData check in oldLegalMoves) {
											if (check.janggiMove.v.data == janggiMove) {
												legalMoveUIData = check;
												break;
											} else if (check.janggiMove.v.data == null) {
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
										legalMoveUIData.janggiMove.v = new ReferenceData<JanggiMove> (janggiMove);
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
							legalMoveUIData.janggiMove.v = new ReferenceData<JanggiMove> (null);
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
				Janggi janggi = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						janggi = useRuleInputUIData.janggi.v.data;
						if (janggi != null) {
							if (Game.IsPlaying (janggi)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("janggi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 9 && y >= 0 && y < 10) {
						// Click the same already click
						bool isCurrentSelect = false;
						{
							if (this.data.x.v == x && this.data.y.v == y) {
								isCurrentSelect = true;
							}
						}
						if (isCurrentSelect) {
							// Chuyen ve ClickPieceUI
							ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
							if (show != null) {
								ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
								{
									clickPieceUIData.uid = show.sub.makeId ();
								}
								show.sub.v = clickPieceUIData;
							} else {
								Debug.LogError ("show null: " + this);
							}
						} else {
							// select other piece in the same side
							bool isSelectOtherPiece = false;
							{
								int index = y * Board.Width + x;
								if (index >= 0 && index < janggi.stones.vs.Count) {
									uint pc = janggi.stones.vs [index];
									if (janggi.getPlayerIndex () == 0) {
										if (StoneHelper.IsGreen (pc)) {
											isSelectOtherPiece = true;
										}
									} else if (janggi.getPlayerIndex () == 1) {
										if (StoneHelper.IsRed (pc)) {
											isSelectOtherPiece = true;
										}
									}
								} else {
									Debug.LogError ("index error: " + index + ", " + janggi.stones.vs.Count);
								}
							}
							if (isSelectOtherPiece) {
								this.data.x.v = x;
								this.data.y.v = y;
							} else {
								// Find move click
								JanggiMove janggiMove = null;
								{
									ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
									if (show != null) {
										foreach (JanggiMove check in show.legalMoves.vs) {
											if (check.fromX.v == this.data.x.v && check.fromY.v == this.data.y.v && check.toX.v == x && check.toY.v == y) {
												janggiMove = check;
												break;
											}
										}
									} else {
										Debug.LogError ("show null: " + this);
									}
								}
								if (janggiMove != null) {
									ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
									if (clientInput != null) {
										clientInput.makeSend (janggiMove);
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
				Common.convertLocalPositionToXY (localPosition, out x, out y);
			}
			Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			this.clickDest (x, y);
		}

	}
}