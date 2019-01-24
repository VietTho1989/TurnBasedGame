using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class CalculateScoreSumUI : UIBehavior<CalculateScoreSumUI.UIData>
	{

		#region UIData

		public class UIData : CalculateScore.UIData
		{

			public VP<EditData<CalculateScoreSum>> editCalculateScoreSum;

			#region Constructor

			public enum Property
			{
				editCalculateScoreSum
			}

			public UIData() : base()
			{
				this.editCalculateScoreSum = new VP<EditData<CalculateScoreSum>>(this, (byte)Property.editCalculateScoreSum, new EditData<CalculateScoreSum>());
			}

			#endregion

			public override CalculateScore.Type getType ()
			{
				return CalculateScore.Type.Sum;
			}

		}

		#endregion

		#region Refresh

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<CalculateScoreSum> editCalculateScoreSum = this.data.editCalculateScoreSum.v;
					if (editCalculateScoreSum != null) {
						editCalculateScoreSum.update ();
						// get show
						CalculateScoreSum show = editCalculateScoreSum.show.v.data;
						CalculateScoreSum compare = editCalculateScoreSum.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editCalculateScoreSum.compareOtherType.v.data != null) {
										if (editCalculateScoreSum.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
								differentIndicator.SetActive (isDifferent);
							} else {
								Debug.LogError ("differentIndicator null: " + this);
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

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.editCalculateScoreSum.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// editCalculateScoreSum
				{
					if (data is EditData<CalculateScoreSum>) {
						EditData<CalculateScoreSum> editCalculateScoreSum = data as EditData<CalculateScoreSum>;
						// Child
						{
							editCalculateScoreSum.show.allAddCallBack (this);
							editCalculateScoreSum.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is CalculateScoreSum) {
							CalculateScoreSum calculateScoreSum = data as CalculateScoreSum;
							// Parent
							{
								DataUtils.addParentCallBack (calculateScoreSum, this, ref this.server);
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
				// Child
				{
					uiData.editCalculateScoreSum.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				// editCalculateScoreSum
				{
					if (data is EditData<CalculateScoreSum>) {
						EditData<CalculateScoreSum> editCalculateScoreSum = data as EditData<CalculateScoreSum>;
						// Child
						{
							editCalculateScoreSum.show.allRemoveCallBack (this);
							editCalculateScoreSum.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is CalculateScoreSum) {
							CalculateScoreSum calculateScoreSum = data as CalculateScoreSum;
							// Parent
							{
								DataUtils.removeParentCallBack (calculateScoreSum, this, ref this.server);
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
				case UIData.Property.editCalculateScoreSum:
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
				// editCalculateScoreSum
				{
					if (wrapProperty.p is EditData<CalculateScoreSum>) {
						switch ((EditData<CalculateScoreSum>.Property)wrapProperty.n) {
						case EditData<CalculateScoreSum>.Property.origin:
							break;
						case EditData<CalculateScoreSum>.Property.show:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case EditData<CalculateScoreSum>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case EditData<CalculateScoreSum>.Property.compareOtherType:
							break;
						case EditData<CalculateScoreSum>.Property.canEdit:
							break;
						case EditData<CalculateScoreSum>.Property.editType:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is CalculateScoreSum) {
							switch ((CalculateScoreSum.Property)wrapProperty.n) {
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