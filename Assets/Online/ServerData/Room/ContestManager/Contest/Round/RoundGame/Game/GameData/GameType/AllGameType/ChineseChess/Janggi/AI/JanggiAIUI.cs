using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiAIUI : UIBehavior<JanggiAIUI.UIData>
	{

		#region UIData

		public class UIData : AIUI.UIData.Sub
		{

			public VP<EditData<JanggiAI>> editAI;

			#region maxVisitCount

			public VP<RequestChangeIntUI.UIData> maxVisitCount;

			public void makeRequestChangeMaxVisitCount (RequestChangeUpdate<int>.UpdateData update, int newMaxVisitCount)
			{
				// Find janggiAI
				JanggiAI janggiAI = null;
				{
					EditData<JanggiAI> editJanggiAI = this.editAI.v;
					if (editJanggiAI != null) {
						janggiAI = editJanggiAI.show.v.data;
					} else {
						Debug.LogError ("editJanggiAI null: " + this);
					}
				}
				// Process
				if (janggiAI != null) {
					janggiAI.requestChangeMaxVisitCount (Server.getProfileUserId(janggiAI), newMaxVisitCount);
				} else {
					Debug.LogError ("janggiAI null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editAI,
				maxVisitCount
			}

			public UIData() : base()
			{
				this.editAI = new VP<EditData<JanggiAI>>(this, (byte)Property.editAI, new EditData<JanggiAI>());
				// maxVisitCount
				{
					this.maxVisitCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxVisitCount, new RequestChangeIntUI.UIData());
					// event
					this.maxVisitCount.v.updateData.v.request.v = makeRequestChangeMaxVisitCount;
				}
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Janggi;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbMaxVisitCount;
		public static readonly TxtLanguage txtMaxVisitCount = new TxtLanguage();

		static JanggiAIUI()
		{
			txtTitle.add (Language.Type.vi, "Cờ Tướng Triều Tiên AI");
			txtMaxVisitCount.add (Language.Type.vi, "Số nốt thăm tối đa");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<JanggiAI> editJanggiAI = this.data.editAI.v;
					if (editJanggiAI != null) {
						// update
						editJanggiAI.update ();
						// get show
						JanggiAI show = editJanggiAI.show.v.data;
						JanggiAI compare = editJanggiAI.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editJanggiAI.compareOtherType.v.data != null) {
										if (editJanggiAI.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
								differentIndicator.SetActive (isDifferent);
							} else {
								Debug.LogError ("differentIndicator null: " + this);
							}
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
									// Debug.LogError ("server null: " + this);
								}
							}
							// set origin
							{
								// maxVisitCount
								{
									RequestChangeIntUI.UIData maxVisitCount = this.data.maxVisitCount.v;
									if (maxVisitCount != null) {
										// updateData
										RequestChangeUpdate<int>.UpdateData updateData = maxVisitCount.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.maxVisitCount.v;
											updateData.canRequestChange.v = editJanggiAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												maxVisitCount.showDifferent.v = true;
												maxVisitCount.compare.v = compare.maxVisitCount.v;
											} else {
												maxVisitCount.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
							}
							// reset?
							if (needReset) {
								needReset = false;
								// maxVisitCount
								{
									RequestChangeIntUI.UIData maxVisitCount = this.data.maxVisitCount.v;
									if (maxVisitCount != null) {
										RequestChangeUpdate<int>.UpdateData updateData = maxVisitCount.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.maxVisitCount.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("janggiAI null: " + this);
						}
					} else {
						Debug.LogError ("editJanggiAI null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Janggi AI");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbMaxVisitCount != null) {
							lbMaxVisitCount.text = txtMaxVisitCount.get ("Max node visit count");
						} else {
							Debug.LogError ("lbMaxVisitCount null: " + this);
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

		public Transform maxVisitCountContainer;

		public RequestChangeIntUI requestIntPrefab;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// Child
				{
					uiData.editAI.allAddCallBack (this);
					uiData.maxVisitCount.allAddCallBack (this);
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
				// editAI
				{
					if (data is EditData<JanggiAI>) {
						EditData<JanggiAI> editAI = data as EditData<JanggiAI>;
						// Child
						{
							editAI.show.allAddCallBack (this);
							editAI.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is JanggiAI) {
							JanggiAI janggiAI = data as JanggiAI;
							// Parent
							{
								DataUtils.addParentCallBack (janggiAI, this, ref this.server);
							}
							dirty = true;
							needReset = true;
							return;
						}
						// Parent
						if (data is Server) {
							dirty = true;
							return;
						}
					}
				}
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.maxVisitCount:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, maxVisitCountContainer);
								}
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("wrapProperty null: " + this);
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
				Setting.get ().removeCallBack (this);
				// Child
				{
					uiData.editAI.allRemoveCallBack (this);
					uiData.maxVisitCount.allRemoveCallBack (this);
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
				// editAI
				{
					if (data is EditData<JanggiAI>) {
						EditData<JanggiAI> editAI = data as EditData<JanggiAI>;
						// Child
						{
							editAI.show.allRemoveCallBack (this);
							editAI.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is JanggiAI) {
							JanggiAI janggiAI = data as JanggiAI;
							// Parent
							{
								DataUtils.removeParentCallBack (janggiAI, this, ref this.server);
							}
							return;
						}
						// Parent
						if (data is Server) {
							return;
						}
					}
				}
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.editAI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.maxVisitCount:
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
				// editAI
				{
					if (wrapProperty.p is EditData<JanggiAI>) {
						switch ((EditData<JanggiAI>.Property)wrapProperty.n) {
						case EditData<JanggiAI>.Property.origin:
							dirty = true;
							break;
						case EditData<JanggiAI>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<JanggiAI>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<JanggiAI>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<JanggiAI>.Property.canEdit:
							dirty = true;
							break;
						case EditData<JanggiAI>.Property.editType:
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
						if (wrapProperty.p is JanggiAI) {
							switch ((JanggiAI.Property)wrapProperty.n) {
							case JanggiAI.Property.maxVisitCount:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Parent
						if (wrapProperty.p is Server) {
							Server.State.OnUpdateSyncStateChange (wrapProperty, this);
							return;
						}
					}
				}
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}