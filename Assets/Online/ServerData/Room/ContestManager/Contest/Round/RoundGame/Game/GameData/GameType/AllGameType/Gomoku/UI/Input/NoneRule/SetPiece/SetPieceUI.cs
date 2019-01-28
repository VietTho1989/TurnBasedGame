﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku.NoneRule
{
	public class SetPieceUI : UIBehavior<SetPieceUI.UIData>
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> square;

			public VP<ChoosePieceAdapter.UIData> choosePieceAdapter;

			#region Constructor

			public enum Property
			{
				square,
				choosePieceAdapter
			}

			public UIData() : base()
			{
				this.square = new VP<int>(this, (byte)Property.square, 0);
				this.choosePieceAdapter = new VP<ChoosePieceAdapter.UIData>(this, (byte)Property.choosePieceAdapter, new ChoosePieceAdapter.UIData());
			}

			#endregion

			public override Type getType ()
			{
				return Type.SetPiece;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							SetPieceUI setPieceUI = this.findCallBack<SetPieceUI> ();
							if (setPieceUI != null) {
								setPieceUI.onClickBtnBack ();
							} else {
								Debug.LogError ("setPieceUI null: " + this);
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public Image imgSelect;
		public Transform contentContainer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// find boardSize
					int boardSize = 19;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							Gomoku gomoku = noneRuleInputUIData.gomoku.v.data;
							if (gomoku != null) {
								boardSize = gomoku.boardSize.v;
							} else {
								Debug.LogError ("gomoku null: " + this);
							}
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// imgSelect
					{
						if (imgSelect != null) {
							// position
							imgSelect.transform.localPosition = Common.convertSquareToLocalPosition (boardSize, this.data.square.v);
							// Scale
							{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								imgSelect.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
							}
						} else {
							Debug.LogError ("imgSelect null: " + this);
						}
					}
					// Scale
					{
						if (contentContainer != null) {
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							float scale = 0.015f;
							contentContainer.localScale = (playerView == 0 ? new Vector3 (scale, scale, 1f) : new Vector3 (scale, -scale, 1f));
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
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

		private GameDataBoardCheckPerspectiveChange<UIData> checkPerspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData> ();

		public ChoosePieceAdapter choosePieceAdapterPrefab;
		public Transform choosePieceAdapterContainer;

		private NoneRuleInputUI.UIData noneRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					checkPerspectiveChange.addCallBack (this);
					checkPerspectiveChange.setData (uiData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				// Child
				{
					uiData.choosePieceAdapter.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.gomoku.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Gomoku) {
					dirty = true;
					return;
				}
			}
			// Child
			if (data is ChoosePieceAdapter.UIData) {
				ChoosePieceAdapter.UIData choosePieceAdapterUIData = data as ChoosePieceAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (choosePieceAdapterUIData, choosePieceAdapterPrefab, choosePieceAdapterContainer);
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
				// CheckChange
				{
					checkPerspectiveChange.removeCallBack (this);
					checkPerspectiveChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				// Child
				{
					uiData.choosePieceAdapter.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.gomoku.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Gomoku) {
					return;
				}
			}
			// Child
			if (data is ChoosePieceAdapter.UIData) {
				ChoosePieceAdapter.UIData choosePieceAdapterUIData = data as ChoosePieceAdapter.UIData;
				// UI
				{
					choosePieceAdapterUIData.removeCallBackAndDestroy (typeof(ChoosePieceAdapter));
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
				case UIData.Property.square:
					dirty = true;
					break;
				case UIData.Property.choosePieceAdapter:
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
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (wrapProperty.p is NoneRuleInputUI.UIData) {
					switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
					case NoneRuleInputUI.UIData.Property.gomoku:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case NoneRuleInputUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is Gomoku) {
					switch ((Gomoku.Property)wrapProperty.n) {
					case Gomoku.Property.boardSize:
						dirty = true;
						break;
					case Gomoku.Property.gs:
						break;
					case Gomoku.Property.player:
						break;
					case Gomoku.Property.winningPlayer:
						break;
					case Gomoku.Property.lastMove:
						break;
					case Gomoku.Property.winSize:
						break;
					case Gomoku.Property.winCoord:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			if (wrapProperty.p is ChoosePieceAdapter.UIData) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
				if (noneRuleInputUIData != null) {
					ClickNoneUI.UIData clickNoneUIData = noneRuleInputUIData.sub.newOrOld<ClickNoneUI.UIData> ();
					{

					}
					noneRuleInputUIData.sub.v = clickNoneUIData;
				} else {
					Debug.LogError ("noneRuleInputUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}