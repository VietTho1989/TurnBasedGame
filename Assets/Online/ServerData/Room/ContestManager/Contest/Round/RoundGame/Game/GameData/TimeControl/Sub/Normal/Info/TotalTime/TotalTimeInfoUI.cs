using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class TotalTimeInfoUI : UIBehavior<TotalTimeInfoUI.UIData>, HaveTransformData
	{

		#region UIData

		public class UIData : Data
		{

			public VP<EditData<TotalTimeInfo>> editTotalTimeInfo;

			#region sub

			public abstract class Sub : Data
			{

				public abstract TotalTimeInfo.Type getType();

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				editTotalTimeInfo,
				sub
			}

			public UIData() : base()
			{
				this.editTotalTimeInfo = new VP<EditData<TotalTimeInfo>>(this, (byte)Property.editTotalTimeInfo, new EditData<TotalTimeInfo>());
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		static TotalTimeInfoUI()
		{
			txtTitle.add (Language.Type.vi, "Tổng Thời Gian");
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

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<TotalTimeInfo> editTotalTimeInfo = this.data.editTotalTimeInfo.v;
                    if (editTotalTimeInfo != null)
                    {
                        editTotalTimeInfo.update();
                        // get show
                        TotalTimeInfo show = editTotalTimeInfo.show.v.data;
                        TotalTimeInfo compare = editTotalTimeInfo.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editTotalTimeInfo.compareOtherType.v.data != null)
                                    {
                                        if (editTotalTimeInfo.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = Server.State.Type.Connect;
                                {
                                    Server server = show.findDataInParent<Server>();
                                    if (server != null)
                                    {
                                        if (server.state.v != null)
                                        {
                                            serverState = server.state.v.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("server state null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("server null: " + this);
                                    }
                                    // Debug.LogError("serverState: " + serverState);
                                }
                                // set origin
                                {
                                    // sub
                                    {
                                        switch (show.getType())
                                        {
                                            case TotalTimeInfo.Type.Limit:
                                                {
                                                    TotalTimeInfo.Limit haveLimit = show as TotalTimeInfo.Limit;
                                                    // UIData
                                                    TotalTimeInfoLimitUI.UIData haveLimitUIData = this.data.sub.newOrOld<TotalTimeInfoLimitUI.UIData>();
                                                    {
                                                        EditData<TotalTimeInfo.Limit> editHaveLimit = haveLimitUIData.editLimit.v;
                                                        if (editHaveLimit != null)
                                                        {
                                                            // origin
                                                            editHaveLimit.origin.v = new ReferenceData<TotalTimeInfo.Limit>((TotalTimeInfo.Limit)editTotalTimeInfo.origin.v.data);
                                                            // show
                                                            editHaveLimit.show.v = new ReferenceData<TotalTimeInfo.Limit>(haveLimit);
                                                            // compare
                                                            editHaveLimit.compare.v = new ReferenceData<TotalTimeInfo.Limit>((TotalTimeInfo.Limit)compare);
                                                            // compareOtherType
                                                            editHaveLimit.compareOtherType.v = new ReferenceData<Data>(editTotalTimeInfo.compareOtherType.v.data);
                                                            // canEdit
                                                            editHaveLimit.canEdit.v = editTotalTimeInfo.canEdit.v;
                                                            // editType
                                                            editHaveLimit.editType.v = editTotalTimeInfo.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editHaveLimit null: " + this);
                                                        }
                                                    }
                                                    this.data.sub.v = haveLimitUIData;
                                                }
                                                break;
                                            case TotalTimeInfo.Type.NoLimit:
                                                {
                                                    TotalTimeInfo.NoLimit noLimit = show as TotalTimeInfo.NoLimit;
                                                    // UIData
                                                    TotalTimeInfoNoLimitUI.UIData noLimitUIData = this.data.sub.newOrOld<TotalTimeInfoNoLimitUI.UIData>();
                                                    {
                                                        EditData<TotalTimeInfo.NoLimit> editNoLimit = noLimitUIData.editNoLimit.v;
                                                        if (editNoLimit != null)
                                                        {
                                                            // origin
                                                            editNoLimit.origin.v = new ReferenceData<TotalTimeInfo.NoLimit>((TotalTimeInfo.NoLimit)editTotalTimeInfo.origin.v.data);
                                                            // show
                                                            editNoLimit.show.v = new ReferenceData<TotalTimeInfo.NoLimit>(noLimit);
                                                            // compare
                                                            editNoLimit.compare.v = new ReferenceData<TotalTimeInfo.NoLimit>((TotalTimeInfo.NoLimit)compare);
                                                            // compareOtherType
                                                            editNoLimit.compareOtherType.v = new ReferenceData<Data>(editTotalTimeInfo.compareOtherType.v.data);
                                                            // canEdit
                                                            editNoLimit.canEdit.v = editTotalTimeInfo.canEdit.v;
                                                            // editType
                                                            editNoLimit.editType.v = editTotalTimeInfo.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editNoLimit null: " + this);
                                                        }
                                                    }
                                                    this.data.sub.v = noLimitUIData;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + show.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editTotalTimeInfo null: " + this);
                    }
                    // UISize
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // sub
                        {
                            deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Total Time");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
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

		public TotalTimeInfoNoLimitUI noLimitPrefab;
		public TotalTimeInfoLimitUI limitPrefab;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editTotalTimeInfo.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
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
				// EditData
				{
					if (data is EditData<TotalTimeInfo>) {
						EditData<TotalTimeInfo> editTotalTimeInfo = data as EditData<TotalTimeInfo>;
						// Child
						{
							editTotalTimeInfo.show.allAddCallBack (this);
							editTotalTimeInfo.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is TotalTimeInfo) {
							TotalTimeInfo totalTimeInfo = data as TotalTimeInfo;
							// Parent
							{
								DataUtils.addParentCallBack (totalTimeInfo, this, ref this.server);
							}
							dirty = true;
							needReset = true;
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
				// Sub
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case TotalTimeInfo.Type.Limit:
							{
								TotalTimeInfoLimitUI.UIData limitUIData = sub as TotalTimeInfoLimitUI.UIData;
								UIUtils.Instantiate (limitUIData, limitPrefab, this.transform);
							}
							break;
						case TotalTimeInfo.Type.NoLimit:
							{
								TotalTimeInfoNoLimitUI.UIData noLimitUIData = sub as TotalTimeInfoNoLimitUI.UIData;
								UIUtils.Instantiate (noLimitUIData, noLimitPrefab, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
					uiData.editTotalTimeInfo.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
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
				// EditData
				{
					if (data is EditData<TotalTimeInfo>) {
						EditData<TotalTimeInfo> editTotalTimeInfo = data as EditData<TotalTimeInfo>;
						// Child
						{
							editTotalTimeInfo.show.allRemoveCallBack (this);
							editTotalTimeInfo.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is TotalTimeInfo) {
							TotalTimeInfo totalTimeInfo = data as TotalTimeInfo;
							// Parent
							{
								DataUtils.removeParentCallBack (totalTimeInfo, this, ref this.server);
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
				// Sub
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case TotalTimeInfo.Type.Limit:
							{
								TotalTimeInfoLimitUI.UIData limitUIData = sub as TotalTimeInfoLimitUI.UIData;
								limitUIData.removeCallBackAndDestroy (typeof(TotalTimeInfoLimitUI));
							}
							break;
						case TotalTimeInfo.Type.NoLimit:
							{
								TotalTimeInfoNoLimitUI.UIData noLimitUIData = sub as TotalTimeInfoNoLimitUI.UIData;
								noLimitUIData.removeCallBackAndDestroy (typeof(TotalTimeInfoNoLimitUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
				case UIData.Property.editTotalTimeInfo:
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
				// EditData
				{
					if (wrapProperty.p is EditData<TotalTimeInfo>) {
						switch ((EditData<TotalTimeInfo>.Property)wrapProperty.n) {
						case EditData<TotalTimeInfo>.Property.origin:
							dirty = true;
							break;
						case EditData<TotalTimeInfo>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TotalTimeInfo>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TotalTimeInfo>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<TotalTimeInfo>.Property.canEdit:
							dirty = true;
							break;
						case EditData<TotalTimeInfo>.Property.editType:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is TotalTimeInfo) {
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
				// Sub
				if (wrapProperty.p is UIData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}