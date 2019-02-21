using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class StartUI : UIBehavior<StartUI.UIData>
	{

		#region UIData

		public class UIData : StateUI.UIData.Sub
		{

			public VP<ReferenceData<Start>> start;

			#region Sub

			public abstract class Sub : Data
			{
				public abstract Start.Sub.Type getType();
			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				start,
				sub
			}

			public UIData() : base()
			{
				this.start = new VP<ReferenceData<Start>>(this, (byte)Property.start, new ReferenceData<Start>(null));
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public override State.Type getType ()
			{
				return State.Type.Start;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Start start = this.data.start.v.data;
					if (start != null) {
						// onAnimation?
						{
							if (subContainer != null) {
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
								subContainer.gameObject.SetActive (!isOnAnimation);
								if (isOnAnimation) {
									dirty = true;
								}
							} else {
								Debug.LogError ("subContainer null: " + this);
							}
						}
						// sub
						Start.Sub sub = start.sub.v;
						if (sub != null) {
							switch (sub.getType ()) {
							case Start.Sub.Type.Normal:
								{
									StartNormal startNormal = sub as StartNormal;
									// UIData
									StartNormalUI.UIData startNormalUIData = this.data.sub.newOrOld<StartNormalUI.UIData>();
									{
										startNormalUIData.startNormal.v = new ReferenceData<StartNormal> (startNormal);
									}
									this.data.sub.v = startNormalUIData;
								}
								break;
							default:
								Debug.LogError ("Don't process: " + sub.getType () + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("sub null: " + this);
						}
					} else {
						Debug.LogError ("start null: " + this);
					}
				} else {
					// Debug.LogError ("start null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public StartNormalUI startNormalPrefab;
		public Transform subContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.start.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Start) {
					dirty = true;
					return;
				}
				if (data is StartUI.UIData.Sub) {
					StartUI.UIData.Sub sub = data as StartUI.UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case Start.Sub.Type.Normal:
							{
								StartNormalUI.UIData startNormalUIData = sub as StartNormalUI.UIData;
								UIUtils.Instantiate (startNormalUIData, startNormalPrefab, subContainer);
							}
							break;
						default:
							Debug.LogError ("Don't process: " + sub.getType () + "; " + this);
							break;
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
				// Child
				{
					uiData.start.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is Start) {
					return;
				}
				if (data is StartUI.UIData.Sub) {
					StartUI.UIData.Sub sub = data as StartUI.UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case Start.Sub.Type.Normal:
							{
								StartNormalUI.UIData startNormalUIData = sub as StartNormalUI.UIData;
								startNormalUIData.removeCallBackAndDestroy (typeof(StartNormalUI));
							}
							break;
						default:
							Debug.LogError ("Don't process: " + sub.getType () + "; " + this);
							break;
						}
					}
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
				case UIData.Property.start:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.sub:
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
			// Child
			{
				if (wrapProperty.p is Start) {
					switch ((Start.Property)wrapProperty.n) {
					case Start.Property.sub:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is StartUI.UIData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}