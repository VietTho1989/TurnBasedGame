using UnityEngine;
using UnityEngine.UI.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiMoveUI : UIBehavior<JanggiMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			
			public VP<ReferenceData<JanggiMove>> janggiMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				janggiMove,
				isHint
			}

			public UIData() : base()
			{
				this.janggiMove = new VP<ReferenceData<JanggiMove>>(this, (byte)Property.janggiMove, new ReferenceData<JanggiMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.JanggiMove;
			}

		}

		#endregion

		#region Refresh

		public Color normalColor = new Color (16/256f, 78/256f, 163/256f, 256/256f);
		public Color hintColor = Color.green;// new Color (0 / 256f, 1, 0, 256 / 256f);

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					JanggiMove janggiMove = this.data.janggiMove.v.data;
					if (janggiMove != null) {
						// UI
						{
							UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
							if (lineRenderer != null) {
								// line
								{
									// Make point array
									Vector2[] points;
									{
										List<Vector2> temp = new List<Vector2> ();
										// From
										{
											Vector2 fro = Common.convertXYToLocalPosition (janggiMove.fromX.v, janggiMove.fromY.v);
											temp.Add (fro);
										}
										// Middle: for horse move
										{
											bool alreadySpecialMove = false;
											// horse move
											if (!alreadySpecialMove) {
												// Check is horse move
												bool isHorseMove = false;
												{
													if ((Mathf.Abs (janggiMove.fromX.v - janggiMove.toX.v) == 2 && Mathf.Abs (janggiMove.fromY.v - janggiMove.toY.v) == 1)
													    || (Mathf.Abs (janggiMove.fromX.v - janggiMove.toX.v) == 1 && Mathf.Abs (janggiMove.fromY.v - janggiMove.toY.v) == 2)) {
														isHorseMove = true;
													}
												}
												// Make point
												if (isHorseMove) {
													alreadySpecialMove = true;
													Vector2 middle = Vector2.zero;
													//
													if (janggiMove.fromX.v + 2 == janggiMove.toX.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v + 1, janggiMove.fromY.v);
													} 
													//
													else if (janggiMove.fromX.v - 2 == janggiMove.toX.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v - 1, janggiMove.fromY.v);
													} 
													//
													else if (janggiMove.fromY.v + 2 == janggiMove.toY.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v, janggiMove.fromY.v + 1);
													}
													//
													else if (janggiMove.fromY.v - 2 == janggiMove.toY.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v, janggiMove.fromY.v - 1);
													}
													temp.Add (middle);
												} else {
													// Debug.Log ("not horse move");
												}
											}
											// elephant move
											if (!alreadySpecialMove) {
												// Check is elephant move
												bool isElephantMove = false;
												{
													if ((Mathf.Abs (janggiMove.fromX.v - janggiMove.toX.v) == 3 && Mathf.Abs (janggiMove.fromY.v - janggiMove.toY.v) == 2)
														|| (Mathf.Abs (janggiMove.fromX.v - janggiMove.toX.v) == 2 && Mathf.Abs (janggiMove.fromY.v - janggiMove.toY.v) == 3)) {
														isElephantMove = true;
													}
												}
												// Make point
												if (isElephantMove) {
													alreadySpecialMove = true;
													Vector2 middle = Vector2.zero;
													//
													if (janggiMove.fromX.v + 3 == janggiMove.toX.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v + 1, janggiMove.fromY.v);
													} 
													//
													else if (janggiMove.fromX.v - 3 == janggiMove.toX.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v - 1, janggiMove.fromY.v);
													} 
													//
													else if (janggiMove.fromY.v + 3 == janggiMove.toY.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v, janggiMove.fromY.v + 1);
													}
													//
													else if (janggiMove.fromY.v - 3 == janggiMove.toY.v) {
														middle = Common.convertXYToLocalPosition (janggiMove.fromX.v, janggiMove.fromY.v - 1);
													}
													temp.Add (middle);
												} else {
													// Debug.Log ("not elephant move");
												}
											}
										}
										// Des
										{
											Vector2 des = Common.convertXYToLocalPosition (janggiMove.toX.v, janggiMove.toY.v);
											temp.Add (des);
										}
										// Set
										{
											points = new Vector2[temp.Count];
											for (int i = 0; i < temp.Count; i++) {
												points [i] = temp [i];
											}
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
						}
					} else {
						// Debug.LogError ("janggiMove null: " + this);
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
					uiData.janggiMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is JanggiMove) {
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
					uiData.janggiMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is JanggiMove) {
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
				case UIData.Property.janggiMove:
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
			// Chikd
			if (wrapProperty.p is JanggiMove) {
				switch ((JanggiMove.Property)wrapProperty.n) {
				case JanggiMove.Property.fromX:
					dirty = true;
					break;
				case JanggiMove.Property.fromY:
					dirty = true;
					break;
				case JanggiMove.Property.toX:
					dirty = true;
					break;
				case JanggiMove.Property.toY:
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