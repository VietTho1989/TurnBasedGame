using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundUI : UIBehavior<RequestNewEliminationRoundUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<RequestNewEliminationRound>> requestNewEliminationRound;

			#region Sub

			public abstract class Sub : Data
			{

				public abstract RequestNewEliminationRound.State.Type getType();

				public abstract bool processEvent(Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				requestNewEliminationRound,
				sub
			}

			public UIData() : base()
			{
				this.requestNewEliminationRound = new VP<ReferenceData<RequestNewEliminationRound>>(this, (byte)Property.requestNewEliminationRound, new ReferenceData<RequestNewEliminationRound>(null));
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// sub
					if (!isProcess) {
						Sub sub = this.sub.v;
						if (sub != null) {
							isProcess = sub.processEvent (e);
						} else {
							Debug.LogError ("sub null: " + this);
						}
					}
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
					RequestNewEliminationRound requestNewEliminationRound = this.data.requestNewEliminationRound.v.data;
					if (requestNewEliminationRound != null) {
						// sub
						{
							RequestNewEliminationRound.State state = requestNewEliminationRound.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case RequestNewEliminationRound.State.Type.None:
									{
										RequestNewEliminationRoundStateNone requestNewEliminationRoundStateNone = state as RequestNewEliminationRoundStateNone;
										// UIData
										RequestNewEliminationRoundStateNoneUI.UIData requestNewEliminationRoundStateNoneUIData = this.data.sub.newOrOld<RequestNewEliminationRoundStateNoneUI.UIData>();
										{
											requestNewEliminationRoundStateNoneUIData.requestNewEliminationRoundStateNone.v = new ReferenceData<RequestNewEliminationRoundStateNone> (requestNewEliminationRoundStateNone);
										}
										this.data.sub.v = requestNewEliminationRoundStateNoneUIData;
									}
									break;
								case RequestNewEliminationRound.State.Type.Ask:
									{
										RequestNewEliminationRoundStateAsk requestNewEliminationRoundStateAsk = state as RequestNewEliminationRoundStateAsk;
										// UIData
										RequestNewEliminationRoundStateAskUI.UIData requestNewEliminationRoundStateAskUIData = this.data.sub.newOrOld<RequestNewEliminationRoundStateAskUI.UIData>();
										{
											requestNewEliminationRoundStateAskUIData.requestNewEliminationRoundStateAsk.v = new ReferenceData<RequestNewEliminationRoundStateAsk> (requestNewEliminationRoundStateAsk);
										}
										this.data.sub.v = requestNewEliminationRoundStateAskUIData;
									}
									break;
								case RequestNewEliminationRound.State.Type.Accept:
									{
										RequestNewEliminationRoundStateAccept requestNewEliminationRoundStateAccept = state as RequestNewEliminationRoundStateAccept;
										// UIData
										RequestNewEliminationRoundStateAcceptUI.UIData requestNewEliminationRoundStateAcceptUIData = this.data.sub.newOrOld<RequestNewEliminationRoundStateAcceptUI.UIData>();
										{
											requestNewEliminationRoundStateAcceptUIData.requestNewEliminationRoundStateAccept.v = new ReferenceData<RequestNewEliminationRoundStateAccept> (requestNewEliminationRoundStateAccept);
										}
										this.data.sub.v = requestNewEliminationRoundStateAcceptUIData;
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
						Debug.LogError ("requestNewEliminationRound null: " + this);
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

		public RequestNewEliminationRoundStateNoneUI nonePrefab;
		public RequestNewEliminationRoundStateAskUI askPrefab;
		public RequestNewEliminationRoundStateAcceptUI acceptPrefab;
		public Transform stateContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.requestNewEliminationRound.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RequestNewEliminationRound) {
					dirty = true;
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RequestNewEliminationRound.State.Type.None:
							{
								RequestNewEliminationRoundStateNoneUI.UIData requestNewEliminationRoundStateNone = sub as RequestNewEliminationRoundStateNoneUI.UIData;
								UIUtils.Instantiate (requestNewEliminationRoundStateNone, nonePrefab, stateContainer);
							}
							break;
						case RequestNewEliminationRound.State.Type.Ask:
							{
								RequestNewEliminationRoundStateAskUI.UIData requestNewEliminationRoundStateAsk = sub as RequestNewEliminationRoundStateAskUI.UIData;
								UIUtils.Instantiate (requestNewEliminationRoundStateAsk, askPrefab, stateContainer);
							}
							break;
						case RequestNewEliminationRound.State.Type.Accept:
							{
								RequestNewEliminationRoundStateAcceptUI.UIData requestNewEliminationRoundStateAccept = sub as RequestNewEliminationRoundStateAcceptUI.UIData;
								UIUtils.Instantiate (requestNewEliminationRoundStateAccept, acceptPrefab, stateContainer);
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
					uiData.requestNewEliminationRound.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is RequestNewEliminationRound) {
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RequestNewEliminationRound.State.Type.None:
							{
								RequestNewEliminationRoundStateNoneUI.UIData requestNewEliminationRoundStateNone = sub as RequestNewEliminationRoundStateNoneUI.UIData;
								requestNewEliminationRoundStateNone.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundStateNoneUI));
							}
							break;
						case RequestNewEliminationRound.State.Type.Ask:
							{
								RequestNewEliminationRoundStateAskUI.UIData requestNewEliminationRoundStateAsk = sub as RequestNewEliminationRoundStateAskUI.UIData;
								requestNewEliminationRoundStateAsk.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundStateAskUI));
							}
							break;
						case RequestNewEliminationRound.State.Type.Accept:
							{
								RequestNewEliminationRoundStateAcceptUI.UIData requestNewEliminationRoundStateAccept = sub as RequestNewEliminationRoundStateAcceptUI.UIData;
								requestNewEliminationRoundStateAccept.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundStateAcceptUI));
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

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.requestNewEliminationRound:
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
				if (wrapProperty.p is RequestNewEliminationRound) {
					switch ((RequestNewEliminationRound.Property)wrapProperty.n) {
					case RequestNewEliminationRound.Property.state:
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