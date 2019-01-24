using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace FairyChess.NoneRule
{
	public class SetHandAdapter : SRIA<SetHandAdapter.UIData, SetHandHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public LP<SetHandHolder.UIData> holders;

			public VP<Common.ColorAndPiece> chosen;

			#region Constructor

			public enum Property
			{
				holders,
				chosen
			}

			public UIData() : base()
			{
				this.holders = new LP<SetHandHolder.UIData>(this, (byte)Property.holders);
				this.chosen = new VP<Common.ColorAndPiece>(this, (byte)Property.chosen, null);
			}

			#endregion

			[NonSerialized]
			public List<Common.ColorAndPiece> pieces = new List<Common.ColorAndPiece>();

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
						List<Common.ColorAndPiece> pieces = new List<Common.ColorAndPiece> ();
						// get
						{
							// find variant
							Variant variant = null;
							// find variantType
							Common.VariantType variantType = Common.VariantType.asean;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									FairyChess fairyChess = noneRuleInputUIData.fairyChess.v.data;
									if (fairyChess != null) {
										variantType = (Common.VariantType)fairyChess.variantType.v;
									} else {
										Debug.LogError ("fairyChess null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputUIData null: " + this);
								}
							}
							// get
							if (VariantMap.variants.TryGetValue (variantType, out variant)) {
								Common.Color[] colors = { Common.Color.WHITE, Common.Color.BLACK };
								foreach (Common.Color color in colors) {
									foreach (Common.PieceType pieceType in variant.pieceTypes) {
										Common.ColorAndPiece piece = new Common.ColorAndPiece ();
										{
											piece.color = color;
											piece.pieceType = pieceType;
										}
										pieces.Add (piece);
									}
								}
							}
						}
						// chosen
						{
							if (this.data.chosen.v == null || !pieces.Contains (this.data.chosen.v)) {
								if (pieces.Count > 0) {
									this.data.chosen.v = pieces [0];
								} else {
									this.data.chosen.v = null;
								}
							}
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
									List<Common.ColorAndPiece> addItems = pieces.GetRange (min, insertCount);
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
						noneRuleInputUIData.fairyChess.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is FairyChess) {
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
						noneRuleInputUIData.fairyChess.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is FairyChess) {
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
				case UIData.Property.chosen:
					dirty = true;
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
					case NoneRuleInputUI.UIData.Property.fairyChess:
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
				if (wrapProperty.p is FairyChess) {
					switch ((FairyChess.Property)wrapProperty.n) {
					case FairyChess.Property.board:
						break;
					case FairyChess.Property.unpromotedBoard:
						break;
					case FairyChess.Property.byTypeBB:
						break;
					case FairyChess.Property.byColorBB:
						break;
					case FairyChess.Property.pieceCount:
						break;
					case FairyChess.Property.pieceList:
						break;
					case FairyChess.Property.index:
						break;
					case FairyChess.Property.castlingRightsMask:
						break;
					case FairyChess.Property.castlingRookSquare:
						break;
					case FairyChess.Property.castlingPath:
						break;
					case FairyChess.Property.gamePly:
						break;
					case FairyChess.Property.sideToMove:
						break;
					case FairyChess.Property.variantType:
						dirty = true;
						break;
					case FairyChess.Property.st:
						break;
					case FairyChess.Property.chess960:
						break;
					case FairyChess.Property.pieceCountInHand:
						dirty = true;
						break;
					case FairyChess.Property.promotedPieces:
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