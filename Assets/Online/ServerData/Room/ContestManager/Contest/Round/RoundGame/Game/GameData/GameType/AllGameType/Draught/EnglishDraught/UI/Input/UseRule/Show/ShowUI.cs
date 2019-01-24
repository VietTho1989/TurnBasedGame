using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.UseRule
{
	public class ShowUI : UIBehavior<ShowUI.UIData>
	{

		#region UIData

		public class UIData : UseRuleInputUI.UIData.State
		{
			
			public LP<EnglishDraughtMove> legalMoves;

			#region Sub

			public abstract class Sub : Data
			{
				
				public enum Type
				{
					/** Chon piece de di chuyen hoac chon drop*/
					ClickPiece,
					/** Chon dest*/
					ClickDest
				}

				public abstract Type getType();

				public abstract bool processEvent (Event e);

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
				this.legalMoves = new LP<EnglishDraughtMove> (this, (byte)Property.legalMoves);
				this.sub = new VP<Sub>(this, (byte)Property.sub, new ClickPieceUI.UIData());
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
					// sub
					if (this.data.sub.v == null) {
						Debug.LogError ("why sub null: " + this);
						ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
						{
							clickPieceUIData.uid = this.data.sub.makeId ();
						}
						this.data.sub.v = clickPieceUIData;
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region implement callBacks

		public ClickPieceUI clickPiecePrefab;
		public ClickDestUI clickDestPrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// Child
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.ClickPiece:
						{
							ClickPieceUI.UIData clickPieceUIData = sub as ClickPieceUI.UIData;
							UIUtils.Instantiate (clickPieceUIData, clickPiecePrefab, this.transform);
						}
						break;
					case UIData.Sub.Type.ClickDest:
						{
							ClickDestUI.UIData clickDestUIData = sub as ClickDestUI.UIData;
							UIUtils.Instantiate (clickDestUIData, clickDestPrefab, this.transform);
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
				// Child
				{
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// Child
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.ClickPiece:
						{
							ClickPieceUI.UIData clickPieceUIData = sub as ClickPieceUI.UIData;
							clickPieceUIData.removeCallBackAndDestroy(typeof(ClickPieceUI));
						}
						break;
					case UIData.Sub.Type.ClickDest:
						{
							ClickDestUI.UIData clickDestUIData = sub as ClickDestUI.UIData;
							clickDestUIData.removeCallBackAndDestroy (typeof(ClickDestUI));
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
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
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