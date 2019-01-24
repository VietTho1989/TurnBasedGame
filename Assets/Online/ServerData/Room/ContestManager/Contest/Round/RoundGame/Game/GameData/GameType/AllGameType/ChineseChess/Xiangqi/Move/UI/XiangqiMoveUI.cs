using UnityEngine;
using UnityEngine.UI.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiMoveUI : UIBehavior<XiangqiMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<XiangqiMove>> xiangqiMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				xiangqiMove,
				isHint
			}

			public UIData() : base()
			{
				this.xiangqiMove = new VP<ReferenceData<XiangqiMove>>(this, (byte)Property.xiangqiMove, new ReferenceData<XiangqiMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.XiangqiMove;
			}
		}

		#endregion

		#region Refresh

		private const float DeltaX = 4.5f;
		private const float DeltaY = 5;

		public Color normalColor = new Color (16/256f, 78/256f, 163/256f, 256/256f);
		public Color hintColor = Color.green;// new Color (0 / 256f, 1, 0, 256 / 256f);

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					XiangqiMove xiangqiMove = this.data.xiangqiMove.v.data;
					if (xiangqiMove != null) {
						// UI
						{
							UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
							if (lineRenderer != null) {
								// line
								{
									Piece.Position from = new Piece.Position (0, 0);
									Piece.Position dest = new Piece.Position (1, 1);
									// find position
									{
										// TODO can hoan thien
										// Debug.LogError("xiangMove: "+xiangqiMove.move.v);
										byte[] bytes = BitConverter.GetBytes (xiangqiMove.move.v);
										if (bytes.Length == 4) {
											from.X = bytes[0] - 'a';
											from.Y = bytes[1] - 48;
											dest.X = bytes[2] - 'a';
											dest.Y = bytes[3] - 48;
										} else {
											Debug.LogError ("why convert move to bytes not correct: " + this);
										}
									}
									// process
									// Debug.LogError("from, dest: "+from+"; "+dest+"; "+this);
									if (Common.isInsideBoard (from.X, from.Y) && Common.isInsideBoard (dest.X, dest.Y)) {
										if (from.X != dest.X || from.Y != dest.Y) {
											// Make point array
											Vector2[] points;
											{
												List<Vector2> temp = new List<Vector2> ();
												// From
												{
													Vector2 fro = new Vector2 (from.X + 0.5f - DeltaX, 
														from.Y + 0.5f - DeltaY);
													temp.Add (fro);
												}
												// Middle: for horse move
												{
													// Check is horse move
													bool isHorseMove = false;
													{
														if ((Mathf.Abs (from.X - dest.X) == 2 && Mathf.Abs (from.Y - dest.Y) == 1)
															|| (Mathf.Abs (from.X - dest.X) == 1 && Mathf.Abs (from.Y - dest.Y) == 2)) {
															isHorseMove = true;
														}
													}
													// Make point
													if (isHorseMove) {
														Vector2 middle = Vector2.zero;
														//
														if (from.X + 2 == dest.X) {
															middle = new Vector2 (from.X + 0.5f + 1, from.Y + 0.5f);
														} 
														//
														else if (from.X - 2 == dest.X) {
															middle = new Vector2 (from.X + 0.5f - 1, from.Y + 0.5f);
														} 
														//
														else if (from.Y + 2 == dest.Y) {
															middle = new Vector2 (from.X + 0.5f, from.Y + 1 + 0.5f);
														}
														//
														else if (from.Y - 2 == dest.Y) {
															middle = new Vector2 (from.X + 0.5f, from.Y - 1 + 0.5f);
														}
														temp.Add (new Vector2 (middle.x - DeltaX, middle.y - DeltaY));
													} else {
														// Debug.Log ("not horse move");
													}
												}
												// Des
												{
													Vector2 des = new Vector2 (dest.X + 0.5f - DeltaX,  dest.Y + 0.5f - DeltaY);
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
										} else {
											// position the same, so this is drop
											Debug.LogError ("why position the same: " + from + "; " + dest + "; " + this);
											Vector2[] points = new Vector2[5];
											{
												points [0] = new Vector2 (dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
												points [1] = new Vector2 (dest.X - 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
												points [2] = new Vector2 (dest.X - 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY - 0.5f);
												points [3] = new Vector2 (dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY - 0.5f);
												points [4] = new Vector2 (dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
											}
											lineRenderer.Points = points;
										}
									} else {
										Debug.LogError ("why position not inside board: " + from + "; " + dest + "; " + this);
										lineRenderer.Points = new Vector2[]{};
									}
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
						// Debug.LogError ("xiangqiMove null: " + this);
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
					uiData.xiangqiMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is XiangqiMove) {
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
					uiData.xiangqiMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is XiangqiMove) {
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
				case UIData.Property.xiangqiMove:
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
			// Child
			if (wrapProperty.p is XiangqiMove) {
				switch ((XiangqiMove.Property)wrapProperty.n) {
				case XiangqiMove.Property.move:
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