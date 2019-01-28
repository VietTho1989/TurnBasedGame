﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
	public class InternationalDraughtCustomSetUI : UIBehavior<InternationalDraughtCustomSetUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<InternationalDraughtCustomSet>> internationalDraughtCustomSet;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				internationalDraughtCustomSet,
				isHint
			}

			public UIData() : base()
			{
				this.internationalDraughtCustomSet = new VP<ReferenceData<InternationalDraughtCustomSet>>(this, (byte)Property.internationalDraughtCustomSet, new ReferenceData<InternationalDraughtCustomSet>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.InternationalDraughtCustomSet;
			}
		}

		#endregion

		#region Refresh

		public UILineRenderer lineRenderer;

		public Image imgHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					InternationalDraughtCustomSet internationalDraughtCustomSet = this.data.internationalDraughtCustomSet.v.data;
					if (internationalDraughtCustomSet != null) {
						// lineRenderer
						if (lineRenderer != null) {
							Vector2[] points = new Vector2[5];
							{
								Vector3 localPos = Common.convertSquareToLocalPosition (internationalDraughtCustomSet.square.v);
								points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
								points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
								points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
								points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
							}
							lineRenderer.Points = points;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (imgHint != null) {
							if (this.data.isHint.v) {
								// sprite
								imgHint.sprite = InternationalDraughtSpriteContainer.get ().getSprite ((int)internationalDraughtCustomSet.pieceSide.v);
								// position
								{
									imgHint.transform.localPosition = Common.convertSquareToLocalPosition (internationalDraughtCustomSet.square.v);
								}
								// scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
								}
							} else {
								imgHint.sprite = InternationalDraughtSpriteContainer.get ().getSprite ((int)Common.Piece_Side.Empty);
							}
						} else {
							Debug.LogError ("imgHint null: " + this);
						}
					} else {
						Debug.LogError ("chessCustomSet null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Child
				{
					uiData.internationalDraughtCustomSet.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (data is InternationalDraughtCustomSet) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Child
				{
					uiData.internationalDraughtCustomSet.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Child
			if (data is InternationalDraughtCustomSet) {
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
				case UIData.Property.internationalDraughtCustomSet:
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
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is InternationalDraughtCustomSet) {
				switch ((InternationalDraughtCustomSet.Property)wrapProperty.n) {
				case InternationalDraughtCustomSet.Property.square:
					dirty = true;
					break;
				case InternationalDraughtCustomSet.Property.pieceSide:
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