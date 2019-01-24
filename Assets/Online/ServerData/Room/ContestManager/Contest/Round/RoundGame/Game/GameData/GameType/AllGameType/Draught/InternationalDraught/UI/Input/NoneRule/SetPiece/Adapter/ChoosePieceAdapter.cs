using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace InternationalDraught.NoneRule
{
	public class ChoosePieceAdapter : SRIA<ChoosePieceAdapter.UIData, ChoosePieceHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public LP<ChoosePieceHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				holders
			}

			public UIData() : base()
			{
				this.holders = new LP<ChoosePieceHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<Common.Piece_Side> pieceSides = new List<Common.Piece_Side>();

			public void reset()
			{
				this.pieceSides.Clear();
			}

		}

		#endregion

		#region Adapter

		public ChoosePieceHolder holderPrefab;

		protected override ChoosePieceHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChoosePieceHolder.UIData uiData = new ChoosePieceHolder.UIData();
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

		protected override void UpdateViewsHolder (ChoosePieceHolder.UIData newOrRecycled)
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
						List<Common.Piece_Side> pieces = new List<Common.Piece_Side> ();
						// get
						{
							// find alreadySelectPiece
							Common.Piece_Side alreadySelectPiece = 0;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									InternationalDraught internationalDraught = noneRuleInputUIData.internationalDraught.v.data;
									if (internationalDraught != null) {
										SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData> ();
										if (setPieceUIData != null) {
											alreadySelectPiece = (Common.Piece_Side)internationalDraught.getPieceSide (setPieceUIData.square.v);
										} else {
											Debug.LogError ("setPieceUIData null: " + this);
										}
									} else {
										Debug.LogError ("piece null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputUIData null: " + this);
								}
							}
							// add
							{
								Common.Piece_Side[] allPieceSides = { Common.Piece_Side.White_Man, Common.Piece_Side.Black_Man, Common.Piece_Side.White_King, Common.Piece_Side.Black_King, Common.Piece_Side.Empty };
								foreach (Common.Piece_Side piece in allPieceSides) {
									if (piece != alreadySelectPiece) {
										pieces.Add (piece);
									}
								}
							}
						}
						// Make list
						{
							int min = Mathf.Min (pieces.Count, _Params.pieceSides.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (pieces[i] != _Params.pieceSides [i]) {
										// change param
										_Params.pieceSides [i] = pieces [i];
										// Update holder
										foreach (ChoosePieceHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.pieceSide.v = pieces [i];
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
									List<Common.Piece_Side> addItems = pieces.GetRange (min, insertCount);
									_Params.pieceSides.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.pieceSides.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.pieceSides.RemoveRange (min, deleteCount);
									}
								}
							}
						}
						// NoPieces
						{
							if (noPieces != null) {
								bool haveAny = false;
								{
									foreach (ChoosePieceHolder.UIData holder in this.data.holders.vs) {
										ChoosePieceHolder holderUI = holder.findCallBack<ChoosePieceHolder> ();
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
		private SetPieceUI.UIData setPieceUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.noneRuleInputUIData);
					DataUtils.addParentCallBack (uiData, this, ref this.setPieceUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// noneRuleInputUIData
				{
					if (data is NoneRuleInputUI.UIData) {
						NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
						// Child
						{
							noneRuleInputUIData.internationalDraught.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is InternationalDraught) {
							InternationalDraught internationalDraught = data as InternationalDraught;
							// Child
							{
								internationalDraught.node.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						{
							if (data is Node) {
								Node node = data as Node;
								// Child
								{
									node.p_pos.allAddCallBack (this);
								}
								dirty = true;
								return;
							}
							// Child
							if (data is Pos) {
								dirty = true;
								return;
							}
						}
					}
				}
				if (data is SetPieceUI.UIData) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.setPieceUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				// noneRuleInputUIData
				{
					if (data is NoneRuleInputUI.UIData) {
						NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
						// Child
						{
							noneRuleInputUIData.internationalDraught.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is InternationalDraught) {
							InternationalDraught internationalDraught = data as InternationalDraught;
							// Child
							{
								internationalDraught.node.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						{
							if (data is Node) {
								Node node = data as Node;
								// Child
								{
									node.p_pos.allRemoveCallBack (this);
								}
								return;
							}
							// Child
							if (data is Pos) {
								return;
							}
						}
					}
				}
				if (data is SetPieceUI.UIData) {
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
				// noneRuleInputUIData
				{
					if (wrapProperty.p is NoneRuleInputUI.UIData) {
						switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
						case NoneRuleInputUI.UIData.Property.internationalDraught:
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
					{
						if (wrapProperty.p is InternationalDraught) {
							switch ((InternationalDraught.Property)wrapProperty.n) {
							case InternationalDraught.Property.node:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case InternationalDraught.Property.var:
								break;
							case InternationalDraught.Property.lastMove:
								break;
							case InternationalDraught.Property.ply:
								break;
							case InternationalDraught.Property.captureSize:
								break;
							case InternationalDraught.Property.captureSquares:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						{
							if (wrapProperty.p is Node) {
								switch ((Node.Property)wrapProperty.n) {
								case Node.Property.p_pos:
									{
										ValueChangeUtils.replaceCallBack (this, syncs);
										dirty = true;
									}
									break;
								case Node.Property.p_ply:
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
							// Child
							if (wrapProperty.p is Pos) {
								switch ((Pos.Property)wrapProperty.n) {
								case Pos.Property.p_piece:
									dirty = true;
									break;
								case Pos.Property.p_side:
									dirty = true;
									break;
								case Pos.Property.p_all:
									dirty = true;
									break;
								case Pos.Property.p_turn:
									dirty = true;
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
						}
					}
				}
				if (wrapProperty.p is SetPieceUI.UIData) {
					switch ((SetPieceUI.UIData.Property)wrapProperty.n) {
					case SetPieceUI.UIData.Property.square:
						dirty = true;
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