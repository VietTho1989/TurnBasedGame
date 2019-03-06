using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Banqi.NoneRule
{
	public class SetPieceUI : UIBehavior<SetPieceUI.UIData>
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> x;

			public VP<int> y;

			#region Constructor

			public enum Property
			{
				x,
				y
			}

			public UIData() : base()
			{
				this.x = new VP<int>(this, (byte)Property.x, 0);
				this.y = new VP<int>(this, (byte)Property.y, 0);
			}

			#endregion

			public override Type getType ()
			{
				return Type.SetPiece;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							SetPieceUI setPieceUI = this.findCallBack<SetPieceUI> ();
							if (setPieceUI != null) {
								setPieceUI.onClickBtnCancel ();
							} else {
								Debug.LogError ("setPieceUI null: " + this);
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

		public Dropdown drColor;
		public Dropdown drType;
		public Toggle tgFaceUp;

		public override void Awake ()
		{
			base.Awake ();
			// drColor
			{
				if (drColor != null) {
					drColor.onValueChanged.AddListener (delegate(int newValue) {
						if (this.data != null) {
						
						} else {
							Debug.LogError ("data null: " + this);
						}
					});
					// options
					foreach(Token.Ecolor color in System.Enum.GetValues(typeof(Token.Ecolor))){
						Dropdown.OptionData optionData = new Dropdown.OptionData ();
						{
							optionData.text = "" + color;
						}
						drColor.options.Add (optionData);
					}
					drColor.RefreshShownValue ();
				} else {
					Debug.LogError ("drColor null: " + this);
				}
			}
			// drType
			{
				if (drType != null) {
					drType.onValueChanged.AddListener (delegate(int newValue) {
						if (this.data != null) {

						} else {
							Debug.LogError ("data null: " + this);
						}
					});
					// options
					foreach(Token.Type type in System.Enum.GetValues(typeof(Token.Type))){
						Dropdown.OptionData optionData = new Dropdown.OptionData ();
						{
							optionData.text = "" + type;
						}
						drType.options.Add (optionData);
					}
					drType.RefreshShownValue ();
				} else {
					Debug.LogError ("drType null: " + this);
				}
			}
		}

		public GameObject ivSelect;
		public Transform contentContainer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// imgSelect
					{
						if (ivSelect != null) {
							// position
							ivSelect.transform.localPosition = Common.convertPosToLocalPosition (8 * this.data.y.v + this.data.y.v);
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
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private GameDataBoardCheckPerspectiveChange<UIData> checkPerspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					checkPerspectiveChange.addCallBack (this);
					checkPerspectiveChange.setData (uiData);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					checkPerspectiveChange.removeCallBack (this);
					checkPerspectiveChange.setData (null);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnCancel()
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

		public void onClickBtnChoose()
		{
			if (this.data != null) {
				Banqi banqi = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						banqi = noneRuleInputUIData.banqi.v.data;
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
					// send move
					ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
					if (clientInput != null) {
						BanqiCustomSet banqiCustomSet = new BanqiCustomSet ();
						{
							banqiCustomSet.x.v = this.data.x.v;
							banqiCustomSet.y.v = this.data.y.v;
							// color
							{
								Token.Ecolor color = Token.Ecolor.RED;
								{
									if (drColor != null) {
										color = (Token.Ecolor)drColor.value;
									} else {
										Debug.LogError ("drColor null");
									}
								}
								banqiCustomSet.color.v = color;
							}
							// type
							{
								Token.Type type = Token.Type.SOLDIER;
								{
									if (drType != null) {
										type = (Token.Type)drType.value;
									} else {
										Debug.LogError ("drType null");
									}
								}
								banqiCustomSet.type.v = type;
							}
							// isFaceUp
							{
								bool isFaceUp = true;
								{
									if (tgFaceUp != null) {
										isFaceUp = tgFaceUp.isOn;
									} else {
										Debug.LogError ("tgFaceUp null");
									}
								}
								banqiCustomSet.isFaceUp.v = isFaceUp;
							}
						}
						clientInput.makeSend (banqiCustomSet);
					} else {
						Debug.LogError ("clientInput null: " + this);
					}
				} else {
					Debug.LogError ("not active: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}