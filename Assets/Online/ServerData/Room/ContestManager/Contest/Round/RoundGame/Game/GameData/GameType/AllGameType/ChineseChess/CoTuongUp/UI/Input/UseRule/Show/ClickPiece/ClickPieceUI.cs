using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Rule;

namespace CoTuongUp.UseRule
{
	public class ClickPieceUI : UIBehavior<ClickPieceUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : ShowUI.UIData.Sub
		{

			public VP<byte> keyX;

			public VP<byte> keyY;

			#region Constructor

			public enum Property
			{
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.keyX = new VP<byte>(this, (byte)Property.keyX, 20);
				this.keyY = new VP<byte>(this, (byte)Property.keyY, 20);
			}

			#endregion

			public override Type getType ()
			{
				return Type.ClickPiece;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					if (InputEvent.isEnter (e)) {
						// enter
						ClickPieceUI clickPieceUI = this.findCallBack<ClickPieceUI> ();
						if (clickPieceUI != null) {
							clickPieceUI.onEnterKey ();
						} else {
							Debug.LogError ("clickPieceUI null: " + this);
						}
						isProcess = true;
					} else if (InputEvent.isArrow (e)) {
						if (this.keyX.v >= 0 && this.keyX.v < 9
							&& this.keyY.v >= 0 && this.keyY.v < 10) {
							// find new key position
							byte newKeyX = this.keyX.v;
							byte newKeyY = this.keyY.v;
							{
								switch (e.keyCode) {
								case KeyCode.LeftArrow:
									newKeyX--;
									break;
								case KeyCode.RightArrow:
									newKeyX++;
									break;
								case KeyCode.UpArrow:
									newKeyY--;
									break;
								case KeyCode.DownArrow:
									newKeyY++;
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
							// bring to lastMove
							byte lastKeyX = 4;
							byte lastKeyY = 5;
							{
								// find gameMove
								GameMove gameMove = null;
								{
									// Find gameData
									GameData gameData = null;
									{
										GameDataUI.UIData gameDataUIData = this.findDataInParent<GameDataUI.UIData> ();
										if (gameDataUIData != null) {
											gameData = gameDataUIData.gameData.v.data;
										} else {
											Debug.LogError ("gameDataUIData null: ");
										}
									}
									// Process
									if (gameData != null) {
										LastMove lastMove = gameData.lastMove.v;
										if (lastMove != null) {
											gameMove = lastMove.gameMove.v;
										} else {
											Debug.LogError ("lastMove null: " + this);
										}
									} else {
										// Debug.LogError ("gameData null: " + data);
									}
								}
								// process
								if (gameMove != null) {
									switch (gameMove.getType ()) {
									case GameMove.Type.CoTuongUpMove:
										{
											CoTuongUpMove coTuongUpMove = gameMove as CoTuongUpMove;
											Rules.Move ruleMove = CoTuongUpMove.getMove (coTuongUpMove.move.v);
											lastKeyX = ruleMove.dest.x;
											lastKeyY = ruleMove.dest.y;
										}
										break;
									case GameMove.Type.CoTuongUpCustomSet:
										{
											NoneRule.CoTuongUpCustomSet coTuongUpCustomSet = gameMove as NoneRule.CoTuongUpCustomSet;
											Common.parseCoord (coTuongUpCustomSet.coord.v, out lastKeyX, out lastKeyY);
										}
										break;
									case GameMove.Type.CoTuongUpCustomMove:
										{
											NoneRule.CoTuongUpCustomMove coTuongUpCustomMove = gameMove as NoneRule.CoTuongUpCustomMove;
											Common.parseCoord (coTuongUpCustomMove.dest.v, out lastKeyX, out lastKeyY);
										}
										break;
									case GameMove.Type.CoTuongUpCustomFlip:
										{
											NoneRule.CoTuongUpCustomFlip coTuongUpCustomFlip = gameMove as NoneRule.CoTuongUpCustomFlip;
											Common.parseCoord (coTuongUpCustomFlip.coord.v, out lastKeyX, out lastKeyY);
										}
										break;
									case GameMove.Type.None:
										break;
									default:
										Debug.LogError ("unknown type: " + gameMove.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("gameMove null: " + this);
								}
							}
							// set
							this.keyX.v = lastKeyX;
							this.keyY.v = lastKeyY;
						}
						isProcess = true;
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

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
								keySelect.transform.localPosition = Common.convertCoordToLocalPosition (Common.makeCoord (this.data.keyX.v, this.data.keyY.v));
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		private void clickPiece(byte x, byte y)
		{
			if (this.data != null) {
				CoTuongUp coTuongUp = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						coTuongUp = useRuleInputUIData.coTuongUp.v.data;
						if (coTuongUp != null) {
							if (Game.IsPlaying (coTuongUp)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("coTuongUp null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 9 && y >= 0 && y < 10) {
						byte coord = Common.makeCoord ((byte)x, (byte)y);
						// check click correct piece
						bool isCorrectPiece = false;
						{
							byte piece = coTuongUp.getPieceByCoord (coord);
							if (coTuongUp.side.v == Common.getPieceSide (piece)) {
								isCorrectPiece = true;
							}
						}
						// process
						if (isCorrectPiece) {
							// chuyen sang clickDest
							ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
							if (show != null) {
								ClickDestUI.UIData clickDest = new ClickDestUI.UIData ();
								{
									clickDest.uid = show.sub.makeId ();
									clickDest.coord.v = coord;
								}
								show.sub.v = clickDest;
							} else {
								Debug.LogError ("show null: " + this);
							}
						} else {
							Debug.LogError ("click wrong piece: " + this);
						}
					} else {
						Debug.LogError ("click outside board: " + this);
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
				this.clickPiece (this.data.keyX.v, this.data.keyY.v);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.LogError ("OnPointerDown: " + eventData);
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int x = 0;
			int y = 0;
			Common.convertLocalPositionToXY (localPosition, out x, out y);
			Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			this.clickPiece ((byte)x, (byte)y);
		}

	}

}