using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace RussianDraught.NoneRule
{
	public class ClickPosUI : UIBehavior<ClickPosUI.UIData>
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> square;

			#region Constructor

			public enum Property
			{
				square
			}

			public UIData() : base()
			{
				this.square = new VP<int>(this, (byte)Property.square, 0);
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

		public Image imgSelect;
		public Transform contentContainer;

		public Button btnMove;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// imgSelect
					{
						if (imgSelect != null) {
							// position
							imgSelect.transform.localPosition = Common.convertSquareToLocalPosition (this.data.square.v);
							// Scale
							{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								imgSelect.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
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
									RussianDraught russianDraught = noneRuleInputUIData.russianDraught.v.data;
									if (russianDraught != null) {
										int piece = russianDraught.getPiece (this.data.square.v);
										if (Common.isRealPiece (piece)) {
											isClickPiece = true;
										}
									} else {
										Debug.LogError ("russianDraught null: " + this);
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
						noneRuleInputUIData.russianDraught.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is RussianDraught) {
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
						noneRuleInputUIData.russianDraught.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is RussianDraught) {
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
				case UIData.Property.square:
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
					case NoneRuleInputUI.UIData.Property.russianDraught:
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
				if (wrapProperty.p is RussianDraught) {
					switch ((RussianDraught.Property)wrapProperty.n) {
					case RussianDraught.Property.Board:
						dirty = true;
						break;
					case RussianDraught.Property.num_wpieces:
						break;
					case RussianDraught.Property.num_bpieces:
						break;
					case RussianDraught.Property.Color:
						break;
					case RussianDraught.Property.g_root_mb:
						break;
					case RussianDraught.Property.realdepth:
						break;
					case RussianDraught.Property.RepNum:
						break;
					case RussianDraught.Property.HASH_KEY:
						break;
					case RussianDraught.Property.p_list:
						break;
					case RussianDraught.Property.indices:
						break;
					case RussianDraught.Property.g_pieces:
						break;
					case RussianDraught.Property.Reversible:
						break;
					case RussianDraught.Property.c_num:
						break;
					}
					return;
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
						setPieceUIData.square.v = this.data.square.v;
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
						clickMoveUIData.square.v = this.data.square.v;
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

	}
}