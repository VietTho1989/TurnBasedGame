using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Khet.UseRule
{
	public class ClickDestUI : UIBehavior<ClickDestUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : ShowUI.UIData.Sub
		{

			public VP<int> piecePosition;

			public LP<LegalMoveUI.UIData> legalMoves;

			#region keyEvent

			public VP<int> keyX;

			public VP<int> keyY;

			#endregion

			#region Constructor

			public enum Property
			{
				piecePosition,
				legalMoves,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.piecePosition = new VP<int>(this, (byte)Property.piecePosition, 0);
				this.legalMoves = new LP<LegalMoveUI.UIData>(this, (byte)Property.legalMoves);
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
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
							if (this.keyX.v >= 0 && this.keyX.v < 10
							    && this.keyY.v >= 0 && this.keyY.v < 8) {
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
								    && newKeyY >= 0 && newKeyY < 8) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								// bring to lastMove
								int lastKeyX = this.piecePosition.v % Common.BoardWidth - 1;
								int lastKeyY = this.piecePosition.v / Common.BoardWidth - 1;
								// set
								this.keyX.v = lastKeyX;
								this.keyY.v = lastKeyY;
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

		public Button btnRotateAdd;
		public Button btnRotateSub;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// keySelect
					{
						if (keySelect != null) {
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 10
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
								keySelect.SetActive (true);
								int position = (this.data.keyY.v + 1) * Common.BoardWidth + (this.data.keyX.v + 1);
								keySelect.transform.localPosition = Common.getLocalPosition (position);
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
							imgSelect.transform.localPosition = Common.getLocalPosition (this.data.piecePosition.v);
						} else {
							Debug.LogError ("imgSelect null: " + this);
						}
					}
					// legalMoves
					{
						// get move list
						List<KhetMove> khetMoves = new List<KhetMove>();
						{
							ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
							if (showUIData != null) {
								foreach (KhetMove khetMove in showUIData.legalMoves.vs) {
									if (KhetMove.GetStart (khetMove.move.v) == this.data.piecePosition.v
									   && KhetMove.GetEnd (khetMove.move.v) != this.data.piecePosition.v) {
										khetMoves.Add (khetMove);
									}
								}
							} else {
								Debug.LogError ("showUIData null");
							}
						}
						// Process
						{
							// get old
							List<LegalMoveUI.UIData> oldLegalMoveUIDatas = new List<LegalMoveUI.UIData>();
							{
								oldLegalMoveUIDatas.AddRange (this.data.legalMoves.vs);
							}
							// Update
							{
								foreach (KhetMove khetMove in khetMoves) {
									// find UIData
									LegalMoveUI.UIData legalMoveUIData = null;
									bool needAdd = false;
									{
										// find old
										if (oldLegalMoveUIDatas.Count > 0) {
											legalMoveUIData = oldLegalMoveUIDatas [0];
										}
										// make new
										if (legalMoveUIData == null) {
											legalMoveUIData = new LegalMoveUI.UIData ();
											{
												legalMoveUIData.uid = this.data.legalMoves.makeId ();
											}
											needAdd = true;
										} else {
											oldLegalMoveUIDatas.Remove (legalMoveUIData);
										}
									}
									// Update
									{
										legalMoveUIData.khetMove.v = new ReferenceData<KhetMove> (khetMove);
									}
									// Add
									if (needAdd) {
										this.data.legalMoves.add (legalMoveUIData);
									}
								}
							}
							// remove old
							foreach (LegalMoveUI.UIData legalMoveUIData in oldLegalMoveUIDatas) {
								legalMoveUIData.khetMove.v = new ReferenceData<KhetMove> (null);
							}
						}
					}
					// btnRotate
					{
						if (btnRotateAdd != null && btnRotateSub != null) {
							bool canRotateAdd = false;
							bool canRotateSub = false;
							{
								ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
								if (showUIData != null) {
									foreach (KhetMove khetMove in showUIData.legalMoves.vs) {
										if (KhetMove.GetStart (khetMove.move.v) == this.data.piecePosition.v
											&& KhetMove.GetEnd (khetMove.move.v) == this.data.piecePosition.v) {
											if (KhetMove.GetRotation (khetMove.move.v) > 0) {
												canRotateAdd = true;
											} else {
												canRotateSub = true;
											}
											if (canRotateAdd && canRotateSub) {
												break;
											}
										}
									}
								} else {
									Debug.LogError ("showUIData null");
								}
							}
							btnRotateAdd.gameObject.SetActive (canRotateAdd);
							btnRotateSub.gameObject.SetActive (canRotateSub);
						} else {
							Debug.LogError ("btnRotateAdd, btnRotateSub null");
						}
					}
				} else {
					Debug.LogError ("data null");
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
		public Transform legalMoveContainer;

		private ShowUI.UIData showUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.showUIData);
				}
				// Child
				{
					uiData.legalMoves.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is ShowUI.UIData) {
					ShowUI.UIData showUIData = data as ShowUI.UIData;
					// Child
					{
						showUIData.legalMoves.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is KhetMove) {
					dirty = true;
					return;
				}
			}
			// Child
			if (data is LegalMoveUI.UIData) {
				LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
				// UI
				{
					UIUtils.Instantiate (legalMoveUIData, legalMovePrefab, legalMoveContainer);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.showUIData);
				}
				// Child
				{
					uiData.legalMoves.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is ShowUI.UIData) {
					ShowUI.UIData showUIData = data as ShowUI.UIData;
					// Child
					{
						showUIData.legalMoves.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is KhetMove) {
					return;
				}
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
				case UIData.Property.piecePosition:
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
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is ShowUI.UIData) {
					switch ((ShowUI.UIData.Property)wrapProperty.n) {
					case ShowUI.UIData.Property.legalMoves:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case ShowUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is KhetMove) {
					switch ((KhetMove.Property)wrapProperty.n) {
					case KhetMove.Property.move:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
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
				Khet khet = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						khet = useRuleInputUIData.khet.v.data;
						if (khet != null) {
							if (Game.IsPlaying (khet)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("khet null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 10 && y >= 0 && y < 8) {
						int position = (y + 1) * Common.BoardWidth + (x + 1);
						if (position == this.data.piecePosition.v) {
							// tro ve clickPiece
							ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
							if (showUIData != null) {
								ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
								{
									clickPieceUIData.uid = showUIData.sub.makeId ();
								}
								showUIData.sub.v = clickPieceUIData;
							} else {
								Debug.LogError ("showUIData null");
							}
						} else {
							// find move
							KhetMove khetMove = null;
							{
								ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
								if (showUIData != null) {
									foreach (KhetMove legalMove in showUIData.legalMoves.vs) {
										if (KhetMove.GetStart (legalMove.move.v) == this.data.piecePosition.v
										   && KhetMove.GetEnd (legalMove.move.v) == position) {
											khetMove = legalMove;
											break;
										}
									}
								} else {
									Debug.LogError ("showUIData null");
								}
							}
							// process
							if (khetMove != null) {
								ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
								if (clientInput != null) {
									clientInput.makeSend (khetMove);
								} else {
									Debug.LogError ("clientInput null: " + this);
								}
							} else {
								Debug.LogError ("khetMove null");
							}
						}
					} else {
						Debug.LogError ("click outside board: " + x + "; " + y);
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
			Common.convertLocalPositionToXY (localPosition, out x, out y);
			this.clickDest (x, y);
		}

		#region rotate

		public void onClickRotateAdd()
		{
			this.onClickRotate (true);
		}

		public void onClickRotateSub()
		{
			this.onClickRotate (false);
		}

		public void onClickRotate(bool isAdd)
		{
			if (this.data != null) {
				Khet khet = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						khet = useRuleInputUIData.khet.v.data;
						if (khet != null) {
							if (Game.IsPlaying (khet)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("khet null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					// find move
					KhetMove khetMove = null;
					{
						ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
						if (showUIData != null) {
							foreach (KhetMove legalMove in showUIData.legalMoves.vs) {
								if (KhetMove.GetStart (legalMove.move.v) == this.data.piecePosition.v
									&& KhetMove.GetEnd (legalMove.move.v) == this.data.piecePosition.v) {
									if (KhetMove.GetRotation (legalMove.move.v) > 0) {
										if (isAdd) {
											khetMove = legalMove;
											break;
										}
									} else {
										if (!isAdd) {
											khetMove = legalMove;
											break;
										}
									}
								}
							}
						} else {
							Debug.LogError ("showUIData null");
						}
					}
					// process
					if (khetMove != null) {
						ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
						if (clientInput != null) {
							clientInput.makeSend (khetMove);
						} else {
							Debug.LogError ("clientInput null: " + this);
						}
					} else {
						Debug.LogError ("khetMove null");
					}
				} else {
					Debug.LogError ("not active: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		#endregion

	}
}