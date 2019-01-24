using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class UseRuleInputNoneUI : UIBehavior<UseRuleInputNoneUI.UIData>
	{

		#region UIData

		public class UIData : UseRuleInputUI.UIData.Sub
		{

			#region Constructor

			public enum Property
			{

			}

			public UIData() : base()
			{

			}

			#endregion

			public override Type getType ()
			{
				return Type.None;
			}

			public override void onClickCard (Card card)
			{
				if (card != null) {
					UseRuleInputUI.UIData useRuleInputUIData = this.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						UseRuleInputCardUI.UIData useRuleInputCardUIData = new UseRuleInputCardUI.UIData ();
						{
							useRuleInputCardUIData.uid = useRuleInputUIData.sub.makeId ();
							useRuleInputCardUIData.card.v = new ReferenceData<Card> (card);
						}
						useRuleInputUIData.sub.v = useRuleInputCardUIData;
					} else {
						Debug.LogError ("useRuleInputUIData null");
					}
				} else {
					Debug.LogError ("card null");
				}
			}

			public override void onClickPile (Pile pile)
			{
				
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

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {

				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
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
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnReset()
		{
			if (this.data != null) {
				Solitaire solitaire = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						solitaire = useRuleInputUIData.solitaire.v.data;
						if (solitaire != null) {
							if (Game.IsPlaying (solitaire)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("solitaire null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
					if (clientInput != null) {
						SolitaireReset solitaireReset = new SolitaireReset ();
						{

						}
						clientInput.makeSend (solitaireReset);
					} else {
						Debug.LogError ("clientInput null: " + this);
					}
				} else {
					Debug.LogError ("not active: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}