using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayUI : UIBehavior<PlayUI.UIData>
	{

		#region UIData

		public class UIData : StateUI.UIData.Sub
		{

			public VP<ReferenceData<Play>> play;

			#region Sub

			public abstract class Sub : Data
			{
				public abstract Play.Sub.Type getType();
			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				play,
				sub
			}

			public UIData() : base()
			{
				this.play = new VP<ReferenceData<Play>>(this, (byte)Property.play, new ReferenceData<Play>(null));
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public override State.Type getType ()
			{
				return State.Type.Play;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Play play = this.data.play.v.data;
					if (play != null) {
						// sub
						{
							Play.Sub sub = play.sub.v;
							if (sub != null) {
								switch (sub.getType ()) {
								case Play.Sub.Type.Normal:
									{
										PlayNormal playNormal = sub as PlayNormal;
										// UIData
										PlayNormalUI.UIData playNormalUIData = this.data.sub.newOrOld<PlayNormalUI.UIData> ();
										{
											playNormalUIData.playNormal.v = new ReferenceData<PlayNormal> (playNormal);
										}
										this.data.sub.v = playNormalUIData;
									}
									break;
								case Play.Sub.Type.Pause:
									{
										PlayPause playPause = sub as PlayPause;
										// UIData
										PlayPauseUI.UIData playPauseUIData = this.data.sub.newOrOld<PlayPauseUI.UIData>();
										{
											playPauseUIData.playPause.v = new ReferenceData<PlayPause> (playPause);
										}
										this.data.sub.v = playPauseUIData;
									}
									break;
								case Play.Sub.Type.UnPause:
									{
										PlayUnPause playUnPause = sub as PlayUnPause;
										// UIData
										PlayUnPauseUI.UIData playUnPauseUIData = this.data.sub.newOrOld<PlayUnPauseUI.UIData> ();
										{
											playUnPauseUIData.playUnPause.v = new ReferenceData<PlayUnPause> (playUnPause);
										}
										this.data.sub.v = playUnPauseUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("sub null: " + this);
							}
						}
					} else {
						Debug.LogError ("play null: " + this);
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

		public PlayNormalUI playNormalPrefab;
		public PlayPauseUI playPausePrefab;
		public PlayUnPauseUI playUnPausePrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.play.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Play) {
					dirty = true;
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case Play.Sub.Type.Normal:
							{
								PlayNormalUI.UIData playNormalUIData = sub as PlayNormalUI.UIData;
								UIUtils.Instantiate (playNormalUIData, playNormalPrefab, this.transform);
							}
							break;
						case Play.Sub.Type.Pause:
							{
								PlayPauseUI.UIData playPauseUIData = sub as PlayPauseUI.UIData;
								UIUtils.Instantiate (playPauseUIData, playPausePrefab, this.transform);
							}
							break;
						case Play.Sub.Type.UnPause:
							{
								PlayUnPauseUI.UIData playUnPauseUIData = sub as PlayUnPauseUI.UIData;
								UIUtils.Instantiate (playUnPauseUIData, playUnPausePrefab, this.transform);
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + sub.getType () + "; " + this);
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
					uiData.play.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is Play) {
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case Play.Sub.Type.Normal:
							{
								PlayNormalUI.UIData playNormalUIData = sub as PlayNormalUI.UIData;
								playNormalUIData.removeCallBackAndDestroy (typeof(PlayNormalUI));
							}
							break;
						case Play.Sub.Type.Pause:
							{
								PlayPauseUI.UIData playPauseUIData = sub as PlayPauseUI.UIData;
								playPauseUIData.removeCallBackAndDestroy (typeof(PlayPauseUI));
							}
							break;
						case Play.Sub.Type.UnPause:
							{
								PlayUnPauseUI.UIData playUnPauseUIData = sub as PlayUnPauseUI.UIData;
								playUnPauseUIData.removeCallBackAndDestroy (typeof(PlayUnPauseUI));
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + sub.getType () + "; " + this);
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
				case UIData.Property.play:
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
				if (wrapProperty.p is Play) {
					switch ((Play.Property)wrapProperty.n) {
					case Play.Property.sub:
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