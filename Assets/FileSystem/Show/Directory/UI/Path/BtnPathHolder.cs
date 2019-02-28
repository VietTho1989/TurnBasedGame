using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class BtnPathHolder : SriaHolderBehavior<BtnPathHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<DirectoryInfo> dir;

			#region Constructor

			public enum Property
			{
				dir
			}

			public UIData() : base()
			{
				this.dir = new VP<DirectoryInfo>(this, (byte)Property.dir, null);
			}

			#endregion

			public void updateView(BtnPathAdapter.UIData myParams)
			{
				// Find
				DirectoryInfo dir = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.dirs.Count) {
						dir = myParams.dirs [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.dir.v = dir;
			}

		}

		#endregion

		#region Refresh

		public Text tvPath;
        public static readonly Color BoldColor = new Color(11 / 255f, 0, 0);
        public static readonly Color NormalColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
                if (this.data != null) {
                    DirectoryInfo dir = this.data.dir.v;
                    if (dir != null) {
                        // tvPath
                        {
                            if (tvPath != null) {
                                // txt
                                {
                                    string path = dir.Name;
                                    {
                                        if (string.IsNullOrEmpty(path))
                                        {
                                            path = "   ";
                                        }
                                        else if (path.Length >= 20)
                                        {
                                            path = path.Substring(0, 19) + "..";
                                        }
                                    }
                                    tvPath.text = "  " + path + "  >";
                                }
                                // color
                                {
                                    bool isBold = false;
                                    {
                                        BtnPathAdapter.UIData btnPathAdapterUIData = this.data.findDataInParent<BtnPathAdapter.UIData>();
                                        if (btnPathAdapterUIData != null)
                                        {
                                            BtnPathAdapter btnPathAdapter = btnPathAdapterUIData.findCallBack<BtnPathAdapter>();
                                            if (btnPathAdapter != null)
                                            {
                                                if(this.data.ItemIndex == btnPathAdapter.GetItemsCount() - 1)
                                                {
                                                    isBold = true;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("btnPathAdapter null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("btnPathAdapterUIData null");
                                        }
                                    }
                                    tvPath.color = isBold ? BoldColor : NormalColor;
                                }
                            } else {
                                Debug.LogError("tvPath null: " + this);
                            }
                        }
                    } else {
                        // Debug.LogError("dir null: " + this);
                    }
                } else {
                    // Debug.LogError ("data null: " + this);
                }
			}
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
				case UIData.Property.dir:
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

		public void onClickBtnPath()
		{
			if (this.data != null) {
				DirectoryInfo dir = this.data.dir.v;
				if (dir != null) {
					ShowDirectoryUI.UIData showDirectoryUIData = this.data.findDataInParent<ShowDirectoryUI.UIData> ();
					if (showDirectoryUIData != null) {
						ShowDirectory showDirectory = showDirectoryUIData.showDirectory.v.data;
						if (showDirectory != null) {
							showDirectory.directory.v = dir;
						} else {
							Debug.LogError ("showDirectory null: " + this);
						}
					} else {
						Debug.LogError ("showDirectoryUIData null: " + this);
					}
				} else {
					Debug.LogError ("dir null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}