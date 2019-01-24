using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using Rule;

namespace CoTuongUp
{
	public class CoTuongUpMoveUI : UIBehavior<CoTuongUpMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<CoTuongUpMove>> coTuongUpMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				coTuongUpMove,
				isHint
			}

			public UIData() : base()
			{
				this.coTuongUpMove = new VP<ReferenceData<CoTuongUpMove>>(this, (byte)Property.coTuongUpMove, new ReferenceData<CoTuongUpMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.CoTuongUpMove;
			}

		}

		#endregion

		#region Refresh

		private static Vector2 Delta = new Vector2 (9/2f, 10/2f);

		private Color normalColor = new Color (16/256f, 78/256f, 163/256f, 256/256f);
		private Color hintColor = Color.green;// new Color (0 / 256f, 1, 0, 256 / 256f);

		public UILineRenderer lineRenderer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					CoTuongUpMove coTuongUpMove = this.data.coTuongUpMove.v.data;
					if (coTuongUpMove != null) {
						// lineRenderer
						if (lineRenderer != null) {
							lineRenderer.enabled = true;
							// line
							{
								// Find position;
								int fromX = 0;
								int fromY = 0;
								int destX = 0;
								int destY = 0;
								{
									Rules.Move move = CoTuongUpMove.getMove (coTuongUpMove.move.v);
									// Debug.LogError ("Move: " + move);
									fromX = move.from.x;
									fromY = 9 - move.from.y;
									destX = move.dest.x;
									destY = 9 - move.dest.y;
								}
								// Make point array
								Vector2[] points;
								if (fromX != destX || fromY != destY) {
									List<Vector2> temp = new List<Vector2> ();
									// From
									{
										Vector2 fro = new Vector2 (fromX + 0.5f - Delta.x, fromY + 0.5f - Delta.y);
										temp.Add (fro);
									}
									// Middle: for horse move
									{
										// Check is horse move
										bool isHorseMove = false;
										{
											if ((Mathf.Abs (fromX - destX) == 2 && Mathf.Abs (fromY - destY) == 1)
											    || (Mathf.Abs (fromX - destX) == 1 && Mathf.Abs (fromY - destY) == 2)) {
												isHorseMove = true;
											}
										}
										// Make point
										if (isHorseMove) {
											Vector2 middle = Vector2.zero;
											//
											if (fromX + 2 == destX) {
												middle = new Vector2 (fromX + 0.5f + 1, fromY + 0.5f);
											} 
											//
											else if (fromX - 2 == destX) {
												middle = new Vector2 (fromX + 0.5f - 1, fromY + 0.5f);
											} 
											//
											else if (fromY + 2 == destY) {
												middle = new Vector2 (fromX + 0.5f, fromY + 1 + 0.5f);
											}
											//
											else if (fromY - 2 == destY) {
												middle = new Vector2 (fromX + 0.5f, fromY - 1 + 0.5f);
											}
											temp.Add (middle - Delta);
										} else {
											// Debug.Log ("not horse move");
										}
									}
									// Des
									{
										Vector2 des = new Vector2 (destX + 0.5f - Delta.x, destY + 0.5f - Delta.y);
										temp.Add (des);
									}
									// Set
									{
										points = new Vector2[temp.Count];
										for (int i = 0; i < temp.Count; i++) {
											points [i] = temp [i];
										}
									}
								} else {
									points = new Vector2[5];
									{
										points [0] = new Vector2 (destX + 0.5f - Delta.x + 0.5f, destY + 0.5f - Delta.y + 0.5f);
										points [1] = new Vector2 (destX - 0.5f - Delta.x + 0.5f, destY + 0.5f - Delta.y + 0.5f);
										points [2] = new Vector2 (destX - 0.5f - Delta.x + 0.5f, destY + 0.5f - Delta.y - 0.5f);
										points [3] = new Vector2 (destX + 0.5f - Delta.x + 0.5f, destY + 0.5f - Delta.y - 0.5f);
										points [4] = new Vector2 (destX + 0.5f - Delta.x + 0.5f, destY + 0.5f - Delta.y + 0.5f);
									}
								}
								lineRenderer.Points = points;
							}
							// color
							{
								if (this.data.isHint.v) {
									lineRenderer.color = hintColor;
								} else {
									lineRenderer.color = normalColor;
								}
							}
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
					} else {
						// Debug.LogError ("coTuongUpMove null: " + this);
						// lineRenderer
						if (lineRenderer != null) {
							lineRenderer.enabled = false;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
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
				{
					uiData.coTuongUpMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			if (data is CoTuongUpMove) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				{
					uiData.coTuongUpMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			if (data is CoTuongUpMove) {
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
				case UIData.Property.coTuongUpMove:
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
			if (wrapProperty.p is CoTuongUpMove) {
				switch ((CoTuongUpMove.Property)wrapProperty.n) {
				case CoTuongUpMove.Property.move:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}