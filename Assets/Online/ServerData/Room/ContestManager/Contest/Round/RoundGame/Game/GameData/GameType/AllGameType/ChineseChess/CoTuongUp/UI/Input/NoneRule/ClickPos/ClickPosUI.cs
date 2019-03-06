using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace CoTuongUp.NoneRule
{
	public class ClickPosUI : UIBehavior<ClickPosUI.UIData>
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<byte> coord;

			#region Constructor

			public enum Property
			{
				coord
			}

			public UIData() : base()
			{
				this.coord = new VP<byte>(this, (byte)Property.coord, 0);
			}

			#endregion

			public override Type getType ()
			{
				return Type.ClickPos;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							ClickPosUI clickPosUI = this.findCallBack<ClickPosUI> ();
							if (clickPosUI != null) {
								clickPosUI.onClickBtnBack ();
							} else {
								Debug.LogError ("clickPosUI null: " + this);
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
		public Transform contentContainer;

		public Button btnMove;
		public Button btnFlip;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// imgSelect
					{
						if (ivSelect != null) {
							// position
							ivSelect.transform.localPosition = Common.convertCoordToLocalPosition (this.data.coord.v);
							// Scale
							{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								ivSelect.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
							}
						} else {
							Debug.LogError ("imgSelect null: " + this);
						}
					}
					// Scale
					{
						if (contentContainer != null) {
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							float scale = 0.015f;
							contentContainer.localScale = (playerView == 0 ? new Vector3 (scale, scale, 1f) : new Vector3 (scale, -scale, 1f));
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
					// btnMove
					{
						if (btnMove != null) {
							bool isClickPiece = false;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									CoTuongUp coTuongUp = noneRuleInputUIData.coTuongUp.v.data;
									if (coTuongUp != null) {
										byte piece = coTuongUp.getPieceByCoord (this.data.coord.v);
										if (piece != Common.x) {
											isClickPiece = true;
										}
									} else {
										Debug.LogError ("coTuongUp null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputuIData null: " + this);
								}
							}
							btnMove.gameObject.SetActive (isClickPiece);
						} else {
							Debug.LogError ("btnMove null: " + this);
						}
					}
					// btnFlip
					{
						if (btnFlip != null) {
							bool isClickHide = false;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									CoTuongUp coTuongUp = noneRuleInputUIData.coTuongUp.v.data;
									if (coTuongUp != null) {
										byte piece = coTuongUp.getPieceByCoord (this.data.coord.v);
										if (Common.Visibility.isHide (piece)) {
											isClickHide = true;
										}
									} else {
										Debug.LogError ("coTuongUp null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputuIData null: " + this);
								}
							}
							btnFlip.gameObject.SetActive (isClickHide);
						} else {
							Debug.LogError ("btnFlip null: " + this);
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

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();
		private NoneRuleInputUI.UIData noneRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.coTuongUp.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is CoTuongUp) {
						CoTuongUp coTuongUp = data as CoTuongUp;
						// Child
						{
							coTuongUp.nodes.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Node) {
						dirty = true;
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.coTuongUp.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is CoTuongUp) {
						CoTuongUp coTuongUp = data as CoTuongUp;
						// Child
						{
							coTuongUp.nodes.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Node) {
						return;
					}
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
				case UIData.Property.coord:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (wrapProperty.p is NoneRuleInputUI.UIData) {
					switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
					case NoneRuleInputUI.UIData.Property.coTuongUp:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case NoneRuleInputUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is CoTuongUp) {
						switch ((CoTuongUp.Property)wrapProperty.n) {
						case CoTuongUp.Property.allowViewCapture:
							break;
						case CoTuongUp.Property.allowWatcherViewHidden:
							break;
						case CoTuongUp.Property.allowOnlyFlip:
							break;
						case CoTuongUp.Property.turn:
							break;
						case CoTuongUp.Property.side:
							break;
						case CoTuongUp.Property.nodes:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case CoTuongUp.Property.plyDraw:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Node) {
						switch ((Node.Property)wrapProperty.n) {
						case Node.Property.ply:
							break;
						case Node.Property.pieces:
							dirty = true;
							break;
						case Node.Property.captures:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
				if (noneRuleInputUIData != null) {
					ClickNoneUI.UIData clickNoneUIData = noneRuleInputUIData.sub.newOrOld<ClickNoneUI.UIData> ();
					{

					}
					noneRuleInputUIData.sub.v = clickNoneUIData;
				} else {
					Debug.LogError ("noneRuleInputUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnSetPiece()
		{
			if (this.data != null) {
				NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
				if (noneRuleInputUIData != null) {
					SetPieceUI.UIData setPieceUIData = new SetPieceUI.UIData ();
					{
						setPieceUIData.uid = noneRuleInputUIData.sub.makeId ();
						setPieceUIData.coord.v = this.data.coord.v;
					}
					noneRuleInputUIData.sub.v = setPieceUIData;
				} else {
					Debug.LogError ("noneRuleInputUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnMove()
		{
			if (this.data != null) {
				NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
				if (noneRuleInputUIData != null) {
					ClickMoveUI.UIData clickMoveUIData = new ClickMoveUI.UIData ();
					{
						clickMoveUIData.uid = noneRuleInputUIData.sub.makeId ();
						clickMoveUIData.coord.v = this.data.coord.v;
					}
					noneRuleInputUIData.sub.v = clickMoveUIData;
				} else {
					Debug.LogError ("noneRuleInputUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnEnd()
		{
			if (this.data != null) {
				ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
				if (clientInput != null) {
					EndTurn endTurn = new EndTurn ();
					{

					}
					clientInput.makeSend (endTurn);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnClear()
		{
			if (this.data != null) {
				ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
				if (clientInput != null) {
					Clear clear = new Clear ();
					{

					}
					clientInput.makeSend (clear);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnFlip()
		{
			if (this.data != null) {
				ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
				if (clientInput != null) {
					CoTuongUpCustomFlip coTuongUpCustomFlip = new CoTuongUpCustomFlip ();
					{
						coTuongUpCustomFlip.coord.v = this.data.coord.v;
					}
					clientInput.makeSend (coTuongUpCustomFlip);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}