using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace RussianDraught.UseRule
{
	public class ClickPieceUI : UIBehavior<ClickPieceUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : ShowUI.UIData.Sub
		{

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
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
						if (this.keyX.v >= 0 && this.keyX.v < 8
							&& this.keyY.v >= 0 && this.keyY.v < 8) {
							// find new key position
							int newKeyX = this.keyX.v;
							int newKeyY = this.keyY.v;
							{
								switch (e.keyCode) {
								case KeyCode.LeftArrow:
									newKeyX++;
									break;
								case KeyCode.RightArrow:
									newKeyX--;
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
							if (newKeyX >= 0 && newKeyX < 8
								&& newKeyY >= 0 && newKeyY < 8) {
								this.keyX.v = newKeyX;
								this.keyY.v = newKeyY;
							}
						} else {
							// bring to lastMove
							int lastKeyX = 4;
							int lastKeyY = 4;
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
									case GameMove.Type.RussianDraughtMove:
										{
											RussianDraughtMove russianDraughtMove = gameMove as RussianDraughtMove;
											{
												if (russianDraughtMove.m.vs.Count >= 2) {
													int sq = RussianDraughtMove.convertMtoSq (russianDraughtMove.m.vs [1]);
													if (sq >= 0) {
														lastKeyX = sq % 8;
														lastKeyY = sq / 8;
													} else {
														Debug.LogError ("why sq so small: " + sq + "; " + this);
													}
												} else {
													Debug.LogError ("m count error");
												}
											}
										}
										break;
									case GameMove.Type.RussianDraughtCustomSet:
										{
											NoneRule.RussianDraughtCustomSet russianDraughtCustomSet = gameMove as NoneRule.RussianDraughtCustomSet;
											lastKeyX = russianDraughtCustomSet.square.v % 8;
											lastKeyY = russianDraughtCustomSet.square.v / 8;
										}
										break;
									case GameMove.Type.RussianDraughtCustomMove:
										{
											NoneRule.RussianDraughtCustomMove russianDraughtCustomMove = gameMove as NoneRule.RussianDraughtCustomMove;
											lastKeyX = russianDraughtCustomMove.destSquare.v % 8;
											lastKeyY = russianDraughtCustomMove.destSquare.v / 8;
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
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertSquareToLocalPosition (this.data.keyX.v + 8 * this.data.keyY.v);
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

		private void clickPiece(int square)
		{
			if (this.data != null) {
				RussianDraught russianDraught = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						russianDraught = useRuleInputUIData.russianDraught.v.data;
						if (russianDraught != null) {
							if (Game.IsPlaying (russianDraught)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("russianDraught null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (square >= 0 && square < 64) {
						// Find click correct piece
						bool isCorrectPiece = false;
						{
							int piece = russianDraught.getPiece (square);
							isCorrectPiece = Common.isRealPiece (piece);
						}
						if (isCorrectPiece) {
							// chuyen sang clickDest
							ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
							if (show != null) {
								ClickDestUI.UIData clickDest = new ClickDestUI.UIData ();
								{
									clickDest.uid = show.sub.makeId ();
									clickDest.square.v = square;
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
				if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
					&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
					this.clickPiece (this.data.keyX.v + 8 * this.data.keyY.v);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.LogError ("OnPointerDown: " + eventData);
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int square = Common.converLocalPositionToSquare (localPosition);
			Debug.LogError ("localPositition: " + localPosition + "; " + square);
			this.clickPiece (square);
		}

	}

}