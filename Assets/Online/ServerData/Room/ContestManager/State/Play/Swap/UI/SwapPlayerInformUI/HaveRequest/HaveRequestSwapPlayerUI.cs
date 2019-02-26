using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class HaveRequestSwapPlayerUI : UIBehavior<HaveRequestSwapPlayerUI.UIData>
	{

		#region UIData

		public class UIData :SwapPlayerInformUI.UIData.Sub
		{

			public VP<ReferenceData<SwapRequest>> swapRequest;

			public VP<InformUI> informUI;

			#region stateUI

			public abstract class StateUI : Data
			{

				public abstract SwapRequest.State.Type getType();

			}

			public VP<StateUI> stateUI;

			#endregion

			#region Constructor

			public enum Property
			{
				swapRequest,
				informUI,
				stateUI
			}

			public UIData() : base()
			{
				this.swapRequest = new VP<ReferenceData<SwapRequest>>(this, (byte)Property.swapRequest, new ReferenceData<SwapRequest>(null));
				this.informUI = new VP<InformUI>(this, (byte)Property.informUI, null);
				this.stateUI = new VP<StateUI>(this, (byte)Property.stateUI, null);
			}

			#endregion

			public override Type getType ()
			{
				return Type.HaveRequest;
			}

		}

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        static HaveRequestSwapPlayerUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Yêu Cầu Thay Người");
            }
            // rect
            {
                // stateUIRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 0.0); pivot: (0.5, 0.0);
                    // offsetMin: (0.0, 0.0); offsetMax: (0.0, 130.0); sizeDelta: (0.0, 130.0);
                    stateUIRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    stateUIRect.anchorMin = new Vector2(0.0f, 0.0f);
                    stateUIRect.anchorMax = new Vector2(1.0f, 0.0f);
                    stateUIRect.pivot = new Vector2(0.5f, 0.0f);
                    stateUIRect.offsetMin = new Vector2(0.0f, 0.0f);
                    stateUIRect.offsetMax = new Vector2(0.0f, 130.0f);
                    stateUIRect.sizeDelta = new Vector2(0.0f, 130.0f);
                }
            }
        }

        #endregion

        #region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SwapRequest swapRequest = this.data.swapRequest.v.data;
					if (swapRequest != null) {
                        // title
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get("Swap Player Request");
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                        // inform
                        {
							GamePlayer.Inform inform = swapRequest.inform.v;
							if (inform != null) {
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									{
										EmptyInform emptyInform = inform as EmptyInform;
										// UIData
										EmptyInformUI.UIData emptyInformUIData = this.data.informUI.newOrOld<EmptyInformUI.UIData> ();
										{
											emptyInformUIData.editEmptyInform.v.origin.v = new ReferenceData<EmptyInform> (emptyInform);
											emptyInformUIData.editEmptyInform.v.canEdit.v = false;
										}
										this.data.informUI.v = emptyInformUIData;
									}
									break;
								case GamePlayer.Inform.Type.Human:
									{
										Human human = inform as Human;
										// UIData
										HumanUI.UIData humanUIData = this.data.informUI.newOrOld<HumanUI.UIData>();
										{
											humanUIData.editHuman.v.origin.v = new ReferenceData<Human> (human);
											humanUIData.editHuman.v.canEdit.v = false;
										}
										this.data.informUI.v = humanUIData;
									}
									break;
								case GamePlayer.Inform.Type.Computer:
									{
										Computer computer = inform as Computer;
										// UIData
										ComputerUI.UIData computerUIData = this.data.informUI.newOrOld<ComputerUI.UIData>();
										{
											computerUIData.editComputer.v.origin.v = new ReferenceData<Computer> (computer);
											computerUIData.editComputer.v.canEdit.v = false;
										}
										this.data.informUI.v = computerUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("inform null: " + this);
							}
						}
						// stateUI
						{
							SwapRequest.State state = swapRequest.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case SwapRequest.State.Type.Ask:
									{
										SwapRequestStateAsk swapRequestStateAsk = state as SwapRequestStateAsk;
										// UIData
										SwapRequestStateAskUI.UIData askUIData = this.data.stateUI.newOrOld<SwapRequestStateAskUI.UIData>();
										{
											askUIData.swapRequestStateAsk.v = new ReferenceData<SwapRequestStateAsk> (swapRequestStateAsk);
										}
										this.data.stateUI.v = askUIData;
									}
									break;
								case SwapRequest.State.Type.Accept:
									{
										SwapRequestStateAccept swapRequestStateAccept = state as SwapRequestStateAccept;
										// UIData
										SwapRequestStateAcceptUI.UIData acceptUIData = this.data.stateUI.newOrOld<SwapRequestStateAcceptUI.UIData>();
										{
											acceptUIData.swapRequestStateAccept.v = new ReferenceData<SwapRequestStateAccept> (swapRequestStateAccept);
										}
										this.data.stateUI.v = acceptUIData;
									}
									break;
								case SwapRequest.State.Type.Cancel:
									{
										SwapRequestStateCancel swapRequestStateCancel = state as SwapRequestStateCancel;
										// UIData
										SwapRequestStateCancelUI.UIData cancelUIData = this.data.stateUI.newOrOld<SwapRequestStateCancelUI.UIData>();
										{
											cancelUIData.swapRequestStateCancel.v = new ReferenceData<SwapRequestStateCancel> (swapRequestStateCancel);
										}
										this.data.stateUI.v = cancelUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("state null: " + this);
							}
						}
					} else {
						Debug.LogError ("swapRequest null: " + this);
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

		public EmptyInformUI emptyPrefab;
		public HumanUI humanPrefab;
		public ComputerUI computerPrefab;
		public Transform informUIContainer;

		public SwapRequestStateAskUI askPrefab;
		public SwapRequestStateAcceptUI acceptPrefab;
		public SwapRequestStateCancelUI cancelPrefab;
        private static readonly UIRectTransform stateUIRect = new UIRectTransform();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
				// Child
				{
					uiData.swapRequest.allAddCallBack (this);
					uiData.informUI.allAddCallBack (this);
					uiData.stateUI.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
				if (data is SwapRequest) {
					dirty = true;
					return;
				}
				if (data is InformUI) {
					InformUI informUI = data as InformUI;
					// UI
					{
						switch (informUI.getType ()) {
						case GamePlayer.Inform.Type.None:
							{
								EmptyInformUI.UIData emptyInformUIData = informUI as EmptyInformUI.UIData;
								UIUtils.Instantiate (emptyInformUIData, emptyPrefab, informUIContainer);
							}
							break;
						case GamePlayer.Inform.Type.Human:
							{
								HumanUI.UIData humanUIData = informUI as HumanUI.UIData;
								UIUtils.Instantiate (humanUIData, humanPrefab, informUIContainer);
							}
							break;
						case GamePlayer.Inform.Type.Computer:
							{
								ComputerUI.UIData computerUIData = informUI as ComputerUI.UIData;
								UIUtils.Instantiate (computerUIData, computerPrefab, informUIContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + informUI.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is UIData.StateUI) {
					UIData.StateUI stateUI = data as UIData.StateUI;
					// UI
					{
						switch (stateUI.getType ()) {
						case SwapRequest.State.Type.Ask:
							{
								SwapRequestStateAskUI.UIData askUIData = stateUI as SwapRequestStateAskUI.UIData;
								UIUtils.Instantiate (askUIData, askPrefab, this.transform, stateUIRect);
							}
							break;
						case SwapRequest.State.Type.Accept:
							{
								SwapRequestStateAcceptUI.UIData acceptUIData = stateUI as SwapRequestStateAcceptUI.UIData;
								UIUtils.Instantiate (acceptUIData, acceptPrefab, this.transform, stateUIRect);
							}
							break;
						case SwapRequest.State.Type.Cancel:
							{
								SwapRequestStateCancelUI.UIData cancelUIData = stateUI as SwapRequestStateCancelUI.UIData;
								UIUtils.Instantiate (cancelUIData, cancelPrefab, this.transform, stateUIRect);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + stateUI.getType () + "; " + this);
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
                // Setting
                Setting.get().removeCallBack(this);
				// Child
				{
					uiData.swapRequest.allRemoveCallBack (this);
					uiData.informUI.allRemoveCallBack (this);
					uiData.stateUI.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Child
            {
				if (data is SwapRequest) {
					return;
				}
				if (data is InformUI) {
					InformUI informUI = data as InformUI;
					// UI
					{
						switch (informUI.getType ()) {
						case GamePlayer.Inform.Type.None:
							{
								EmptyInformUI.UIData emptyInformUIData = informUI as EmptyInformUI.UIData;
								emptyInformUIData.removeCallBackAndDestroy (typeof(EmptyInformUI));
							}
							break;
						case GamePlayer.Inform.Type.Human:
							{
								HumanUI.UIData humanUIData = informUI as HumanUI.UIData;
								humanUIData.removeCallBackAndDestroy (typeof(HumanUI));
							}
							break;
						case GamePlayer.Inform.Type.Computer:
							{
								ComputerUI.UIData computerUIData = informUI as ComputerUI.UIData;
								computerUIData.removeCallBackAndDestroy (typeof(ComputerUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + informUI.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is UIData.StateUI) {
					UIData.StateUI stateUI = data as UIData.StateUI;
					// UI
					{
						switch (stateUI.getType ()) {
						case SwapRequest.State.Type.Ask:
							{
								SwapRequestStateAskUI.UIData askUIData = stateUI as SwapRequestStateAskUI.UIData;
								askUIData.removeCallBackAndDestroy (typeof(SwapRequestStateAskUI));
							}
							break;
						case SwapRequest.State.Type.Accept:
							{
								SwapRequestStateAcceptUI.UIData acceptUIData = stateUI as SwapRequestStateAcceptUI.UIData;
								acceptUIData.removeCallBackAndDestroy (typeof(SwapRequestStateAcceptUI));
							}
							break;
						case SwapRequest.State.Type.Cancel:
							{
								SwapRequestStateCancelUI.UIData cancelUIData = stateUI as SwapRequestStateCancelUI.UIData;
								cancelUIData.removeCallBackAndDestroy (typeof(SwapRequestStateCancelUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + stateUI.getType () + "; " + this);
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
				case UIData.Property.swapRequest:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.informUI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.stateUI:
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
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
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
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
				if (wrapProperty.p is SwapRequest) {
					switch ((SwapRequest.Property)wrapProperty.n) {
					case SwapRequest.Property.state:
						dirty = true;
						break;
					case SwapRequest.Property.teamIndex:
						dirty = true;
						break;
					case SwapRequest.Property.playerIndex:
						dirty = true;
						break;
					case SwapRequest.Property.inform:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is InformUI) {
					return;
				}
				if (wrapProperty.p is UIData.StateUI) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}