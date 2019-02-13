﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundNoLimitUI : UIBehavior<RequestNewRoundNoLimitUI.UIData>, HaveTransformData
	{

		#region UIData

		public class UIData : SingleContestFactoryUI.UIData.NewRoundLimitUI
		{

			public VP<EditData<RequestNewRoundNoLimit>> editNoLimit;

			#region Constructor

			public enum Property
			{
				editNoLimit
			}

			public UIData() : base()
			{
				this.editNoLimit = new VP<EditData<RequestNewRoundNoLimit>>(this, (byte)Property.editNoLimit, new EditData<RequestNewRoundNoLimit>());
			}

			#endregion

			public override RequestNewRound.Limit.Type getType ()
			{
				return RequestNewRound.Limit.Type.NoLimit;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{

				}
				return isProcess;
			}

		}

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        static RequestNewRoundNoLimitUI()
        {
            txtTitle.add(Language.Type.vi, "Không giới hạn số vòng");
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            /*if (transform.hasChanged)
            {
                transform.hasChanged = false;
                this.transformData.update(this.transform);
            }*/
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        #region Refresh

        private bool needReset = true;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<RequestNewRoundNoLimit> editNoLimit = this.data.editNoLimit.v;
					if (editNoLimit != null) {
						editNoLimit.update ();
						// get show
						RequestNewRoundNoLimit show = editNoLimit.show.v.data;
						RequestNewRoundNoLimit compare = editNoLimit.compare.v.data;
						if (show != null) {
							// different
							if (lbTitle != null) {
								bool isDifferent = false;
								{
									if (editNoLimit.compareOtherType.v.data != null) {
										if (editNoLimit.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
							} else {
								Debug.LogError ("lbTitle null: " + this);
							}
							// request
							{
								// get server state
								Server.State.Type serverState = Server.State.Type.Connect;
								{
									Server server = show.findDataInParent<Server> ();
									if (server != null) {
										if (server.state.v != null) {
											serverState = server.state.v.getType ();
										} else {
											Debug.LogError ("server state null: " + this);
										}
									} else {
										Debug.LogError ("server null: " + this + "; " + serverState + "; " + compare);
									}
								}
								// set origin
								{

								}
								// reset
								if (needReset) {
									needReset = false;
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editNoLimit null: " + this);
					}
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("No limit rounds");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                } else {
					// Debug.LogError ("data null: " + this);
				}
			}
            updateTransformData();
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
				// Child
				{
					uiData.editNoLimit.allAddCallBack (this);
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
				// editNoLimit
				{
					if (data is EditData<RequestNewRoundNoLimit>) {
						EditData<RequestNewRoundNoLimit> editNoLimit = data as EditData<RequestNewRoundNoLimit>;
						// Child
						{
							editNoLimit.show.allAddCallBack (this);
							editNoLimit.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is RequestNewRoundNoLimit) {
							RequestNewRoundNoLimit noLimit = data as RequestNewRoundNoLimit;
							// Parent
							{
								DataUtils.addParentCallBack (noLimit, this, ref this.server);
							}
							needReset = true;
							dirty = true;
							return;
						}
						// Parent
						{
							if (data is Server) {
								dirty = true;
								return;
							}
						}
					}
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
					uiData.editNoLimit.allRemoveCallBack (this);
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
				// editNoLimit
				{
					if (data is EditData<RequestNewRoundNoLimit>) {
						EditData<RequestNewRoundNoLimit> editNoLimit = data as EditData<RequestNewRoundNoLimit>;
						// Child
						{
							editNoLimit.show.allRemoveCallBack (this);
							editNoLimit.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is RequestNewRoundNoLimit) {
							RequestNewRoundNoLimit noLimit = data as RequestNewRoundNoLimit;
							// Parent
							{
								DataUtils.removeParentCallBack (noLimit, this, ref this.server);
							}
							return;
						}
						// Parent
						{
							if (data is Server) {
								return;
							}
						}
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
				case UIData.Property.editNoLimit:
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
				// editNoLimit
				{
					if (wrapProperty.p is EditData<RequestNewRoundNoLimit>) {
						switch ((EditData<RequestNewRoundNoLimit>.Property)wrapProperty.n) {
						case EditData<RequestNewRoundNoLimit>.Property.origin:
							break;
						case EditData<RequestNewRoundNoLimit>.Property.show:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case EditData<RequestNewRoundNoLimit>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case EditData<RequestNewRoundNoLimit>.Property.compareOtherType:
							break;
						case EditData<RequestNewRoundNoLimit>.Property.canEdit:
							break;
						case EditData<RequestNewRoundNoLimit>.Property.editType:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is RequestNewRoundNoLimit) {
							switch ((RequestNewRoundNoLimit.Property)wrapProperty.n) {
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Parent
						{
							if (wrapProperty.p is Server) {
								Server.State.OnUpdateSyncStateChange (wrapProperty, this);
								return;
							}
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}