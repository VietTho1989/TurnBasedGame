using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerUI : UIBehavior<ContestManagerUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<ContestManager>> contestManager;

			#region Sub

			public abstract class Sub : Data
			{

				public abstract ContestManager.State.Type getType();

				public abstract bool processEvent (Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				contestManager,
				sub
			}

			public UIData() : base()
			{
				this.contestManager = new VP<ReferenceData<ContestManager>>(this, (byte)Property.contestManager, new ReferenceData<ContestManager>(null));
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				// Debug.LogError ("processEvent: " + e + "; " + this);
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
					ContestManager contestManager = this.data.contestManager.v.data;
					if (contestManager != null) {
						// sub
						{
							ContestManager.State state = contestManager.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case ContestManager.State.Type.Lobby:
									{
										ContestManagerStateLobby lobby = state as ContestManagerStateLobby;
										// UIData
										ContestManagerStateLobbyUI.UIData lobbyUIData = this.data.sub.newOrOld<ContestManagerStateLobbyUI.UIData>();
										{
											lobbyUIData.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby> (lobby);
										}
										this.data.sub.v = lobbyUIData;
									}
									break;
								case ContestManager.State.Type.Play:
									{
										ContestManagerStatePlay play = state as ContestManagerStatePlay;
										// UIData
										ContestManagerStatePlayUI.UIData playUIData = this.data.sub.newOrOld<ContestManagerStatePlayUI.UIData>();
										{
											playUIData.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay> (play);
										}
										this.data.sub.v = playUIData;
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
						Debug.LogError ("contestManager null");
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

		public ContestManagerStateLobbyUI lobbyPrefab;
		public ContestManagerStatePlayUI playPrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.contestManager.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ContestManager) {
					dirty = true;
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case ContestManager.State.Type.Lobby:
							{
								ContestManagerStateLobbyUI.UIData lobbyUIData = sub as ContestManagerStateLobbyUI.UIData;
								UIUtils.Instantiate (lobbyUIData, lobbyPrefab, this.transform);
							}
							break;
						case ContestManager.State.Type.Play:
							{
								ContestManagerStatePlayUI.UIData playUIData = sub as ContestManagerStatePlayUI.UIData;
								UIUtils.Instantiate (playUIData, playPrefab, this.transform);
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
					uiData.contestManager.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is ContestManager) {
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case ContestManager.State.Type.Lobby:
							{
								ContestManagerStateLobbyUI.UIData lobbyUIData = sub as ContestManagerStateLobbyUI.UIData;
								lobbyUIData.removeCallBackAndDestroy (typeof(ContestManagerStateLobbyUI));
							}
							break;
						case ContestManager.State.Type.Play:
							{
								ContestManagerStatePlayUI.UIData playUIData = sub as ContestManagerStatePlayUI.UIData;
								playUIData.removeCallBackAndDestroy (typeof(ContestManagerStatePlayUI));
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
				case UIData.Property.contestManager:
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
				if (wrapProperty.p is ContestManager) {
					switch ((ContestManager.Property)wrapProperty.n) {
					case ContestManager.Property.state:
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