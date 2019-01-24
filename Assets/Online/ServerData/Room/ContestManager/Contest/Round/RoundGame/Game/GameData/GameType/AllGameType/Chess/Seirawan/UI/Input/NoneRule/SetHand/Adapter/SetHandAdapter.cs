using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace Seirawan.NoneRule
{
	public class SetHandAdapter : SRIA<SetHandAdapter.UIData, SetHandHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public LP<SetHandHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				holders
			}

			public UIData() : base()
			{
				this.holders = new LP<SetHandHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<Common.Piece> pieces = new List<Common.Piece>();

			public void reset()
			{
				this.pieces.Clear();
			}

		}

		#endregion

		#region Adapter

		public SetHandHolder holderPrefab;

		protected override SetHandHolder.UIData CreateViewsHolder (int itemIndex)
		{
			SetHandHolder.UIData uiData = new SetHandHolder.UIData();
			{
				// add
				{
					uiData.uid = this.data.holders.makeId ();
					this.data.holders.add (uiData);
				}
				// MakeUI
				if (holderPrefab != null) {
					uiData.Init (holderPrefab.gameObject, itemIndex);
				} else {
					Debug.LogError ("holderPrefab null: " + this);
				}
			}
			return uiData;
		}

		protected override void UpdateViewsHolder (SetHandHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		public GameObject noPieces;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						List<Common.Piece> pieces = new List<Common.Piece> ();
						// get
						{
							pieces.Add (Common.Piece.W_ELEPHANT);
							pieces.Add (Common.Piece.W_HAWK);
							pieces.Add (Common.Piece.B_ELEPHANT);
							pieces.Add (Common.Piece.B_HAWK);
						}
						// Make list
						{
							int min = Mathf.Min (pieces.Count, _Params.pieces.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (pieces[i] != _Params.pieces [i]) {
										// change param
										_Params.pieces [i] = pieces [i];
										// Update holder
										foreach (SetHandHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.piece.v = pieces [i];
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (pieces.Count > min) {
									// Add
									int insertCount = pieces.Count - min;
									List<Common.Piece> addItems = pieces.GetRange (min, insertCount);
									_Params.pieces.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.pieces.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.pieces.RemoveRange (min, deleteCount);
									}
								}
							}
						}
						// NoPieces
						{
							if (noPieces != null) {
								bool haveAny = false;
								{
									foreach (SetHandHolder.UIData holder in this.data.holders.vs) {
										SetHandHolder holderUI = holder.findCallBack<SetHandHolder> ();
										if (holderUI != null) {
											if (holderUI.gameObject.activeSelf) {
												haveAny = true;
												break;
											}
										} else {
											Debug.LogError ("holderUI null: " + this);
										}
									}
								}
								noPieces.SetActive (!haveAny);
							} else {
								Debug.LogError ("noPieces null: " + this);
							}
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					Debug.LogError ("not initalized: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private NoneRuleInputUI.UIData noneRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.seirawan.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Seirawan) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.seirawan.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Seirawan) {
					return;
				}
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
				case UIData.Property.holders:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is NoneRuleInputUI.UIData) {
					switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
					case NoneRuleInputUI.UIData.Property.seirawan:
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
				if (wrapProperty.p is Seirawan) {
					switch ((Seirawan.Property)wrapProperty.n) {
					case Seirawan.Property.board:
						break;
					case Seirawan.Property.byTypeBB:
						break;
					case Seirawan.Property.byColorBB:
						break;
					case Seirawan.Property.inHand:
						dirty = true;
						break;
					case Seirawan.Property.handScore:
						break;
					case Seirawan.Property.pieceCount:
						break;
					case Seirawan.Property.pieceList:
						break;
					case Seirawan.Property.index:
						break;
					case Seirawan.Property.castlingRightsMask:
						break;
					case Seirawan.Property.castlingRookSquare:
						break;
					case Seirawan.Property.castlingPath:
						break;
					case Seirawan.Property.gamePly:
						break;
					case Seirawan.Property.sideToMove:
						break;
					case Seirawan.Property.st:
						break;
					case Seirawan.Property.chess960:
						break;
					case Seirawan.Property.isCustom:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}