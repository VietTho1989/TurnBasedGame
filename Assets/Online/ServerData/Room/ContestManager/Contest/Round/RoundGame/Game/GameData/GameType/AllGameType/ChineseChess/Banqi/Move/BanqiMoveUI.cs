using UnityEngine;
using UnityEngine.UI.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiMoveUI : UIBehavior<BanqiMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<BanqiMove>> banqiMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				banqiMove,
				isHint
			}

			public UIData() : base()
			{
				this.banqiMove = new VP<ReferenceData<BanqiMove>>(this, (byte)Property.banqiMove, new ReferenceData<BanqiMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.BanqiMove;
			}

		}

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Banqi ? 1 : 0;
        }

        #region Refresh

        public Color normalColor = new Color (16/256f, 78/256f, 163/256f, 256/256f);
		public Color hintColor = Color.green;// new Color (0 / 256f, 1, 0, 256 / 256f);

		public UILineRenderer lineRenderer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					BanqiMove banqiMove = this.data.banqiMove.v.data;
					if (banqiMove != null) {
						// UI
						{
							if (lineRenderer != null) {
								// line
								{
									if (banqiMove.fromX.v != banqiMove.destX.v || banqiMove.fromY.v != banqiMove.destY.v) {
										// Make point array
										Vector2[] points;
										{
											List<Vector2> temp = new List<Vector2> ();
											// From
											{
												// Debug.LogError ("from: " + banqiMove.fromX.v + ", " + banqiMove.fromY.v + ", " + banqiMove.destX.v + ", " + banqiMove.destY.v);
												Vector2 fro = Common.convertPosToLocalPosition (8 * (3 - (banqiMove.fromY.v - 1)) + (banqiMove.fromX.v - 1));
												temp.Add (fro);
											}
											// Des
											{
												Vector2 des = Common.convertPosToLocalPosition (8 * (3 - (banqiMove.destY.v - 1)) + (banqiMove.destX.v - 1));
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
										Vector2[] points = new Vector2[5];
										{
											Vector3 localPos = Common.convertPosToLocalPosition (8 * (3 - (banqiMove.destY.v - 1)) + (banqiMove.destX.v - 1));
											points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
											points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
											points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
											points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
											points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
										}
										lineRenderer.Points = points;
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
						// Debug.LogError ("banqiMove null: " + this);
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
					uiData.banqiMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is BanqiMove) {
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
					uiData.banqiMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is BanqiMove) {
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
				case UIData.Property.banqiMove:
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
			if (wrapProperty.p is BanqiMove) {
				switch ((BanqiMove.Property)wrapProperty.n) {
				case BanqiMove.Property.fromX:
					dirty = true;
					break;
				case BanqiMove.Property.fromY:
					dirty = true;
					break;
				case BanqiMove.Property.destX:
					dirty = true;
					break;
				case BanqiMove.Property.destY:
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