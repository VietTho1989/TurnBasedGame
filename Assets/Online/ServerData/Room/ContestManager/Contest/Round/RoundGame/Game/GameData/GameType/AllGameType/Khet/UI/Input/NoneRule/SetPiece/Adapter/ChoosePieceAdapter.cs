using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace Khet.NoneRule
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
			public List<Common.PieceAndPlayer> pieceAndPlayers = new List<Common.PieceAndPlayer>();

			public void reset()
			{
				this.pieceAndPlayers.Clear();
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
						List<Common.PieceAndPlayer> pieceAndPlayers = new List<Common.PieceAndPlayer> ();
						// get
						{
							// find alreadySelectPiece
							Common.Player alreadySelectPlayer = Common.Player.Silver;
							Common.Piece alreadySelectPiece = Common.Piece.None;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									Khet khet = noneRuleInputUIData.khet.v.data;
									if (khet != null) {
										// find position
										int position = 0;
										{
											SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData> ();
											if (setPieceUIData != null) {
												position = setPieceUIData.position.v;
											} else {
												Debug.LogError ("setPieceUIData null: " + this);
											}
										}
										// find piece and player
										if (position >= 0 && position < khet._board.vs.Count) {
											if (khet._board.vs [position] != Common.OffBoard && khet._board.vs [position] != Common.Empty) {
												alreadySelectPlayer = Common.GetOwner (khet._board.vs [position]);
												alreadySelectPiece = Common.GetPiece (khet._board.vs [position]);
											}
										}
									} else {
										Debug.LogError ("piece null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputUIData null: " + this);
								}
							}
							// add none
							{
								if (alreadySelectPiece != Common.Piece.None) {
									Common.PieceAndPlayer pieceAndPlayer = new Common.PieceAndPlayer ();
									{
										pieceAndPlayer.player = Common.Player.Silver;
										pieceAndPlayer.piece = Common.Piece.None;
									}
									pieceAndPlayers.Add (pieceAndPlayer);
								}
							}
							// add normal
							foreach (Common.Player player in System.Enum.GetValues(typeof(Common.Player))) {
								foreach (Common.Piece piece in System.Enum.GetValues(typeof(Common.Piece))) {
									bool canAdd = false;
									{
										if (piece != Common.Piece.None) {
											if (player != alreadySelectPlayer || piece != alreadySelectPiece) {
												canAdd = true;
											}
										}
									}
									if (canAdd) {
										Common.PieceAndPlayer pieceAndPlayer = new Common.PieceAndPlayer ();
										{
											pieceAndPlayer.player = player;
											pieceAndPlayer.piece = piece;
										}
										pieceAndPlayers.Add (pieceAndPlayer);
									}
								}
							}
						}
						// Make list
						{
							int min = Mathf.Min (pieceAndPlayers.Count, _Params.pieceAndPlayers.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (!object.Equals (pieceAndPlayers [i], _Params.pieceAndPlayers [i])) {
										// change param
										_Params.pieceAndPlayers [i] = pieceAndPlayers [i];
										// Update holder
										foreach (ChoosePieceHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.pieceAndPlayer.v = pieceAndPlayers [i];
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (pieceAndPlayers.Count > min) {
									// Add
									int insertCount = pieceAndPlayers.Count - min;
									List<Common.PieceAndPlayer> addItems = pieceAndPlayers.GetRange (min, insertCount);
									_Params.pieceAndPlayers.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.pieceAndPlayers.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.pieceAndPlayers.RemoveRange (min, deleteCount);
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
							noneRuleInputUIData.khet.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Khet) {
						dirty = true;
						return;
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
							noneRuleInputUIData.khet.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Khet) {
						return;
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
						case NoneRuleInputUI.UIData.Property.khet:
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
					if (wrapProperty.p is Khet) {
						switch ((Khet.Property)wrapProperty.n) {
						case Khet.Property._playerToMove:
							break;
						case Khet.Property._checkmate:
							break;
						case Khet.Property._drawn:
							break;
						case Khet.Property._moveNumber:
							break;
						case Khet.Property._laser:
							break;
						case Khet.Property._board:
							dirty = true;
							break;
						case Khet.Property._pharaohPositions:
							break;
						case Khet.Property.khetSub:
							break;
						case Khet.Property.isCustom:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				if (wrapProperty.p is SetPieceUI.UIData) {
					switch ((SetPieceUI.UIData.Property)wrapProperty.n) {
					case SetPieceUI.UIData.Property.position:
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