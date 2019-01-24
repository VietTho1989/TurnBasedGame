using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class KhetMoveUI : UIBehavior<KhetMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<KhetMove>> khetMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				khetMove,
				isHint
			}

			public UIData() : base()
			{
				this.khetMove = new VP<ReferenceData<KhetMove>>(this, (byte)Property.khetMove, new ReferenceData<KhetMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.KhetMove;
			}

		}

		#endregion

		#region Refresh

		private static Color normalColor = Color.blue;
		private static Color hintColor = new Color(0, 1, 0, 0.5f);

		public UILineRenderer lineRenderer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					KhetMove khetMove = this.data.khetMove.v.data;
					if (khetMove != null) {
						if (lineRenderer != null) {
							// line
							{
								int start = KhetMove.GetStart (khetMove.move.v);
								int end = KhetMove.GetEnd (khetMove.move.v);
								int rotation = KhetMove.GetRotation (khetMove.move.v);
								// Debug.LogError (string.Format ("khetMove: start: {0}, end: {1}, rotation: {2}", start, end, rotation));
								if (start != end) {
									Vector2 startLocation = Common.getLocalPosition (start);
									Vector2 endLocation = Common.getLocalPosition (end);
									Vector2[] points = { startLocation, endLocation };
									lineRenderer.Points = points;
								} else {
									Vector2[] points = new Vector2[4];
									{
										Vector2 location = Common.getLocalPosition (start);
										if (rotation > 0) {
											points [0] = new Vector2 (location.x - 0.5f, location.y + 0.5f);
											points [1] = new Vector2 (location.x + 0.5f, location.y + 0.5f);
											points [2] = new Vector2 (location.x + 0.5f, location.y - 0.5f);
											points [3] = new Vector2 (location.x - 0.5f, location.y - 0.5f);
										} else {
											points [0] = new Vector2 (location.x + 0.5f, location.y + 0.5f);
											points [1] = new Vector2 (location.x - 0.5f, location.y + 0.5f);
											points [2] = new Vector2 (location.x - 0.5f, location.y - 0.5f);
											points [3] = new Vector2 (location.x + 0.5f, location.y - 0.5f);
										}
									}
									lineRenderer.Points = points;
								}
							}
							// color
							lineRenderer.color = this.data.isHint.v ? hintColor : normalColor;
						} else {
							Debug.LogError ("lineRenderer null");
						}
					} else {
						Debug.LogError ("khetMove null");
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.khetMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is KhetMove) {
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
					uiData.khetMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is KhetMove) {
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
				case UIData.Property.khetMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is KhetMove) {
				switch ((KhetMove.Property)wrapProperty.n) {
				case KhetMove.Property.move:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}