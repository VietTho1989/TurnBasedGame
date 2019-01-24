using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using GameManager.ContestManager;

namespace GameManager.Match
{
	public class RequestNewContestManagerUI : UIBehavior<RequestNewContestManagerUI.UIData>
	{
		
		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<RequestNewContestManager>> requestNewContestManager;

			#region Sub

			public abstract class Sub : Data
			{

				public abstract RequestNewContestManager.State.Type getType();

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				requestNewContestManager,
				sub
			}

			public UIData() : base()
			{
				this.requestNewContestManager = new VP<ReferenceData<RequestNewContestManager>>(this, (byte)Property.requestNewContestManager, new ReferenceData<RequestNewContestManager>(null));
				this.sub = new VP<Sub>(this, (byte)Property.requestNewContestManager, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// TODO Can hoan thien
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewContestManager requestNewContestManager = this.data.requestNewContestManager.v.data;
					if (requestNewContestManager != null) {
						// sub
						{
							RequestNewContestManager.State state = requestNewContestManager.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case RequestNewContestManager.State.Type.None:
									{
										RequestNewContestManagerStateNone none = state as RequestNewContestManagerStateNone;
										// UIData
										RequestNewContestManagerStateNoneUI.UIData noneUIData = this.data.sub.newOrOld<RequestNewContestManagerStateNoneUI.UIData> ();
										{
											noneUIData.requestNewContestManagerStateNone.v = new ReferenceData<RequestNewContestManagerStateNone> (none);
										}
										this.data.sub.v = noneUIData;
									}
									break;
								case RequestNewContestManager.State.Type.Ask:
									{
										RequestNewContestManagerStateAsk ask = state as RequestNewContestManagerStateAsk;
										// UIData
										RequestNewContestManagerStateAskUI.UIData askUIData = this.data.sub.newOrOld<RequestNewContestManagerStateAskUI.UIData> ();
										{
											askUIData.requestNewContestManagerStateAsk.v = new ReferenceData<RequestNewContestManagerStateAsk> (ask);
										}
										this.data.sub.v = askUIData;
									}
									break;
								case RequestNewContestManager.State.Type.Accept:
									{
										RequestNewContestManagerStateAccept accept = state as RequestNewContestManagerStateAccept;
										// UIData
										RequestNewContestManagerStateAcceptUI.UIData acceptUIData = this.data.sub.newOrOld<RequestNewContestManagerStateAcceptUI.UIData> ();
										{
											acceptUIData.requestNewContestManagerStateAccept.v = new ReferenceData<RequestNewContestManagerStateAccept> (accept);
										}
										this.data.sub.v = acceptUIData;
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
						Debug.LogError ("requestNewContestManager null: " + this);
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

		public RequestNewContestManagerStateNoneUI nonePrefab;
		public RequestNewContestManagerStateAskUI askPrefab;
		public RequestNewContestManagerStateAcceptUI acceptPrefab;
		public Transform subContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.requestNewContestManager.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RequestNewContestManager) {
					dirty = true;
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RequestNewContestManager.State.Type.None:
							{
								RequestNewContestManagerStateNoneUI.UIData noneUIData = sub as RequestNewContestManagerStateNoneUI.UIData;
								UIUtils.Instantiate (noneUIData, nonePrefab, subContainer);
							}
							break;
						case RequestNewContestManager.State.Type.Ask:
							{
								RequestNewContestManagerStateAskUI.UIData askUIData = sub as RequestNewContestManagerStateAskUI.UIData;
								UIUtils.Instantiate (askUIData, askPrefab, subContainer);
							}
							break;
						case RequestNewContestManager.State.Type.Accept:
							{
								RequestNewContestManagerStateAcceptUI.UIData acceptUIData = sub as RequestNewContestManagerStateAcceptUI.UIData;
								UIUtils.Instantiate (acceptUIData, acceptPrefab, subContainer);
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
				// Child
				{
					uiData.requestNewContestManager.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is RequestNewContestManager) {
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RequestNewContestManager.State.Type.None:
							{
								RequestNewContestManagerStateNoneUI.UIData noneUIData = sub as RequestNewContestManagerStateNoneUI.UIData;
								noneUIData.removeCallBackAndDestroy (typeof(RequestNewContestManagerStateNoneUI));
							}
							break;
						case RequestNewContestManager.State.Type.Ask:
							{
								RequestNewContestManagerStateAskUI.UIData askUIData = sub as RequestNewContestManagerStateAskUI.UIData;
								askUIData.removeCallBackAndDestroy (typeof(RequestNewContestManagerStateAskUI));
							}
							break;
						case RequestNewContestManager.State.Type.Accept:
							{
								RequestNewContestManagerStateAcceptUI.UIData acceptUIData = sub as RequestNewContestManagerStateAcceptUI.UIData;
								acceptUIData.removeCallBackAndDestroy (typeof(RequestNewContestManagerStateAcceptUI));
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
				case UIData.Property.requestNewContestManager:
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
				if (wrapProperty.p is RequestNewContestManager) {
					switch ((RequestNewContestManager.Property)wrapProperty.n) {
					case RequestNewContestManager.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is UIData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}