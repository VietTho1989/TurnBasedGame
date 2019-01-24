using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtMoveUI : UIBehavior<RussianDraughtMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<RussianDraughtMove>> russianDraughtMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				russianDraughtMove,
				isHint
			}

			public UIData() : base()
			{
				this.russianDraughtMove = new VP<ReferenceData<RussianDraughtMove>>(this, (byte)Property.russianDraughtMove, new ReferenceData<RussianDraughtMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.RussianDraughtMove;
			}

		}

		#endregion

		#region Refresh

		public UILineRenderer lineRenderer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RussianDraughtMove move = this.data.russianDraughtMove.v.data;
					if (move != null) {
						if (lineRenderer != null) {
							// active or not
							if (move.l.v >= 2) {
								lineRenderer.enabled = true;
								// set line
								{
									List<int> squares = move.getMoveSquareList ();
									if (squares.Count >= 2) {
										Vector2[] points = new Vector2[squares.Count];
										{
											for (int i = 0; i < squares.Count; i++) {
												points [i] = Common.convertSquareToLocalPosition (squares [i]);
											}
										}
										lineRenderer.Points = points;
									} else {
										Debug.LogError ("why square count <=0: " + this);
										lineRenderer.Points = new Vector2[]{ };
									}
								}
							} else {
								lineRenderer.enabled = false;
							}
							// color
							lineRenderer.color = this.data.isHint.v ? Global.HintColor : Global.NormalColor;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
					} else {
						// Debug.LogError ("move null: " + this);
						if (lineRenderer != null) {
							lineRenderer.enabled = false;
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.russianDraughtMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			if (data is RussianDraughtMove) {
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
					uiData.russianDraughtMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			if (data is RussianDraughtMove) {
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
				case UIData.Property.russianDraughtMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is RussianDraughtMove) {
				switch ((RussianDraughtMove.Property)wrapProperty.n) {
				case RussianDraughtMove.Property.m:
					dirty = true;
					break;
				case RussianDraughtMove.Property.path:
					dirty = true;
					break;
				case RussianDraughtMove.Property.l:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}

		#endregion
	}
}