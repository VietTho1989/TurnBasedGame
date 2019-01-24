using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
	public class ShowUI : UIBehavior<ShowUI.UIData>
	{

		#region UIData

		public class UIData : UseRuleInputUI.UIData.State
		{

			public LP<NineMenMorrisMove> legalMoves;

			#region Sub

			public abstract class Sub : Data
			{

				public enum Type
				{
					Positioning,
					Playing
				}

				public abstract Type getType();

				public abstract bool processEvent(Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				legalMoves,
				sub
			}

			public UIData() : base()
			{
				this.legalMoves = new LP<NineMenMorrisMove>(this, (byte)Property.legalMoves);
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public override Type getType ()
			{
				return Type.Show;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// sub
					if (!isProcess) {
						Sub sub = this.sub.v;
						if (sub != null) {
							isProcess = sub.processEvent (e);
						} else {
							Debug.LogError ("sub null");
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
					// find nineMenMorris
					NineMenMorris nineMenMorris = null;
					{
						UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
						if (useRuleInputUIData != null) {
							nineMenMorris = useRuleInputUIData.nineMenMorris.v.data;
						} else {
							Debug.LogError ("useRuleInputUIData null");
						}
					}
					// process
					if (nineMenMorris != null) {
						if (nineMenMorris.turn.v < 18) {
							// positioning
							ShowPhasePositioningUI.UIData showPositioningUIData = this.data.sub.newOrOld<ShowPhasePositioningUI.UIData>();
							{

							}
							this.data.sub.v = showPositioningUIData;
						} else {
							// playing
							ShowPhasePlayingUI.UIData showPlayingUIData = this.data.sub.newOrOld<ShowPhasePlayingUI.UIData>();
							{

							}
							this.data.sub.v = showPlayingUIData;
						}
					} else {
						Debug.LogError ("nineMenMorris null");
					}
				} else {
					Debug.LogError ("data null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public ShowPhasePositioningUI positioningPrefab;
		public ShowPhasePlayingUI playingPrefab;

		private UseRuleInputUI.UIData useRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.useRuleInputUIData);
				}
				// Child
				{
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is UseRuleInputUI.UIData) {
					UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
					// Child
					{
						useRuleInputUIData.nineMenMorris.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is NineMenMorris) {
					dirty = true;
					return;
				}
			}
			// Child
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.Positioning:
						{
							ShowPhasePositioningUI.UIData showPhasePositioningUIData = sub as ShowPhasePositioningUI.UIData;
							UIUtils.Instantiate (showPhasePositioningUIData, positioningPrefab, this.transform);
						}
						break;
					case UIData.Sub.Type.Playing:
						{
							ShowPhasePlayingUI.UIData showPhasePlayingUIData = sub as ShowPhasePlayingUI.UIData;
							UIUtils.Instantiate (showPhasePlayingUIData, playingPrefab, this.transform);
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
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.useRuleInputUIData);
				}
				// Child
				{
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is UseRuleInputUI.UIData) {
					UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
					// Child
					{
						useRuleInputUIData.nineMenMorris.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is NineMenMorris) {
					return;
				}
			}
			// Child
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.Positioning:
						{
							ShowPhasePositioningUI.UIData showPhasePositioningUIData = sub as ShowPhasePositioningUI.UIData;
							showPhasePositioningUIData.removeCallBackAndDestroy (typeof(ShowPhasePositioningUI));
						}
						break;
					case UIData.Sub.Type.Playing:
						{
							ShowPhasePlayingUI.UIData showPhasePlayingUIData = sub as ShowPhasePlayingUI.UIData;
							showPhasePlayingUIData.removeCallBackAndDestroy (typeof(ShowPhasePlayingUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
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
				case UIData.Property.legalMoves:
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
			// Parent
			{
				if (wrapProperty.p is UseRuleInputUI.UIData) {
					switch ((UseRuleInputUI.UIData.Property)wrapProperty.n) {
					case UseRuleInputUI.UIData.Property.nineMenMorris:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case UseRuleInputUI.UIData.Property.state:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is NineMenMorris) {
					switch ((NineMenMorris.Property)wrapProperty.n) {
					case NineMenMorris.Property.board:
						break;
					case NineMenMorris.Property.moved:
						break;
					case NineMenMorris.Property.moved_to:
						break;
					case NineMenMorris.Property.action:
						break;
					case NineMenMorris.Property.mill:
						break;
					case NineMenMorris.Property.terminal:
						break;
					case NineMenMorris.Property.removed:
						break;
					case NineMenMorris.Property.utility:
						break;
					case NineMenMorris.Property.turn:
						dirty = true;
						break;
					case NineMenMorris.Property.isCustom:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}