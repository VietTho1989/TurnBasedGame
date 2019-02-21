using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class EndUI : UIBehavior<EndUI.UIData>
	{

		#region UIData

		public class UIData : StateUI.UIData.Sub
		{

			public VP<ReferenceData<End>> end;

			#region Constructor

			public enum Property
			{
				end
			}

			public UIData() : base()
			{
				this.end = new VP<ReferenceData<End>>(this, (byte)Property.end, new ReferenceData<End>(null));
			}

			#endregion

			public override State.Type getType ()
			{
				return State.Type.End;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvMessage;
		public static readonly TxtLanguage txtMessage = new TxtLanguage ();

		static EndUI()
		{
			txtMessage.add (Language.Type.vi, "Game Kết Thúc");
		}

		#endregion

		public Transform contentContainer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					End end = this.data.end.v.data;
					if (end != null) {
						// contentContainer
						{
							if (contentContainer != null) {
								bool isOnAnimation = false;
								{
									GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData> ();
									if (gameUIData != null) {
										GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
										if (gameDataUIData != null) {
											GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
											if (gameDataBoardUIData != null) {
												isOnAnimation = GameDataBoardUI.UIData.isOnAnimation (gameDataBoardUIData);
											}
										} else {
											Debug.LogError ("gameDataUIData null: " + this);
										}
									} else {
										Debug.LogError ("gameUIData null: " + this);
									}
								}
								contentContainer.gameObject.SetActive (!isOnAnimation);
								if (isOnAnimation) {
									dirty = true;
								}
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
						}
					} else {
						Debug.LogError ("end null: " + this);
					}
					// txt
					{
						if (tvMessage != null) {
							tvMessage.text = txtMessage.get ("Game End");
						} else {
							Debug.LogError ("tvMessage null: " + this);
						}
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.end.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is End) {
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
				// Child
				{
					uiData.end.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			{
				if (data is End) {
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
				case UIData.Property.end:
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
			// Child
			{
				if (wrapProperty.p is End) {
					switch ((End.Property)wrapProperty.n) {
					case End.Property.results:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}