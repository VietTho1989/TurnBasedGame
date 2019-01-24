using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi.NoneRule
{
	public class WeiqiCustomMoveUI : UIBehavior<WeiqiCustomMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<WeiqiCustomMove>> weiqiCustomMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				weiqiCustomMove,
				isHint
			}

			public UIData() : base()
			{
				this.weiqiCustomMove = new VP<ReferenceData<WeiqiCustomMove>>(this, (byte)Property.weiqiCustomMove, new ReferenceData<WeiqiCustomMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.WeiqiCustomMove;
			}

		}

		#endregion

		#region Refresh

		public UILineRenderer lineRendererFrom;
		public UILineRenderer lineRendererDest;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					WeiqiCustomMove weiqiCustomMove = this.data.weiqiCustomMove.v.data;
					if (weiqiCustomMove != null) {
						// find boardSize
						int boardSize = 21;
						{
							WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.findDataInParent<WeiqiGameDataUI.UIData> ();
							if (weiqiGameDataUIData != null) {
								BoardUI.UIData boardUIData = weiqiGameDataUIData.board.v;
								if (boardUIData != null) {
									Weiqi weiqi = boardUIData.weiqi.v.data;
									if (weiqi != null) {
										Board board = weiqi.b.v;
										if (board != null) {
											boardSize = board.size.v;
										} else {
											Debug.LogError ("board null: " + this);
										}
									} else {
										Debug.LogError ("weiqi null: " + this);
									}
								} else {
									Debug.LogError ("boardUIData null: " + this);
								}
							} else {
								Debug.LogError ("weiqiGameDataUIData null: " + this);
							}
						}
						// from
						if (lineRendererFrom != null) {
							// point
							{
								Vector2[] points = new Vector2[5];
								{
									Vector3 localPos = Common.convertCoordToLocalPosition (boardSize, weiqiCustomMove.from.v);
									points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
									points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
									points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
									points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
									points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								}
								lineRendererFrom.Points = points;
							}
							// color
							{
								if (this.data.isHint.v) {
									lineRendererFrom.color = new Color (1, 0, 0, 0.5f);
								} else {
									lineRendererFrom.color = new Color (1, 0, 0, 1f);
								}
							}
						} else {
							Debug.LogError ("lineRendererFrom null: " + this);
						}
						// dest
						if (lineRendererDest != null) {
							// point
							{
								Vector2[] points = new Vector2[5];
								{
									Vector3 localPos = Common.convertCoordToLocalPosition (boardSize, weiqiCustomMove.dest.v);
									points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
									points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
									points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
									points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
									points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								}
								lineRendererDest.Points = points;
							}
							// color
							{
								if (this.data.isHint.v) {
									lineRendererDest.color = new Color (0, 1, 0, 0.5f);
								} else {
									lineRendererDest.color = new Color (0, 1, 0, 1f);
								}
							}
						} else {
							Debug.LogError ("lineRendererDest null: " + this);
						}
					} else {
						Debug.LogError ("weiqiCustomMove null: " + this);
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

		private WeiqiGameDataUI.UIData weiqiGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.weiqiGameDataUIData);
				}
				// Child
				{
					uiData.weiqiCustomMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is WeiqiGameDataUI.UIData) {
					WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
					// Child
					{
						weiqiGameDataUIData.board.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.weiqi.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is Weiqi) {
							Weiqi weiqi = data as Weiqi;
							// Child
							{
								weiqi.b.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						if (data is Board) {
							dirty = true;
							return;
						}
					}
				}
			}
			// Child
			if (data is WeiqiCustomMove) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.weiqiGameDataUIData);
				}
				// Child
				{
					uiData.weiqiCustomMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is WeiqiGameDataUI.UIData) {
					WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
					// Child
					{
						weiqiGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.weiqi.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is Weiqi) {
							Weiqi weiqi = data as Weiqi;
							// Child
							{
								weiqi.b.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						if (data is Board) {
							return;
						}
					}
				}
			}
			// Child
			if (data is WeiqiCustomMove) {
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
				case UIData.Property.weiqiCustomMove:
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
			// Parent
			{
				if (wrapProperty.p is WeiqiGameDataUI.UIData) {
					switch ((WeiqiGameDataUI.UIData.Property)wrapProperty.n) {
					case WeiqiGameDataUI.UIData.Property.gameData:
						break;
					case WeiqiGameDataUI.UIData.Property.updateTransform:
						break;
					case WeiqiGameDataUI.UIData.Property.transformOrganizer:
						break;
					case WeiqiGameDataUI.UIData.Property.isOnAnimation:
						break;
					case WeiqiGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case WeiqiGameDataUI.UIData.Property.information:
						break;
					case WeiqiGameDataUI.UIData.Property.lastMove:
						break;
					case WeiqiGameDataUI.UIData.Property.showHint:
						break;
					case WeiqiGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is BoardUI.UIData) {
						switch ((BoardUI.UIData.Property)wrapProperty.n) {
						case BoardUI.UIData.Property.weiqi:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case BoardUI.UIData.Property.background:
							break;
						case BoardUI.UIData.Property.mode:
							break;
						case BoardUI.UIData.Property.boardSize:
							break;
						case BoardUI.UIData.Property.pieces:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is Weiqi) {
							switch ((Weiqi.Property)wrapProperty.n) {
							case Weiqi.Property.b:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case Weiqi.Property.deadgroup:
								break;
							case Weiqi.Property.scoreOwnerMap:
								break;
							case Weiqi.Property.scoreOwnerMapSize:
								break;
							case Weiqi.Property.scoreBlack:
								break;
							case Weiqi.Property.scoreWhite:
								break;
							case Weiqi.Property.dame:
								break;
							case Weiqi.Property.score:
								break;
							case Weiqi.Property.isCustom:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						if (wrapProperty.p is Board) {
							switch ((Board.Property)wrapProperty.n) {
							case Board.Property.size:
								dirty = true;
								break;
							case Board.Property.size2:
								break;
							case Board.Property.bits2:
								break;
							case Board.Property.captures:
								break;
							case Board.Property.komi:
								break;
							case Board.Property.handicap:
								break;
							case Board.Property.rules:
								break;
							case Board.Property.moves:
								break;
							case Board.Property.last_move:
								break;
							case Board.Property.last_move2:
								break;
							case Board.Property.last_move3:
								break;
							case Board.Property.last_move4:
								break;
							case Board.Property.superko_violation:
								break;
							case Board.Property.b:
								break;
							case Board.Property.g:
								break;
							case Board.Property.pp:
								break;
							case Board.Property.pat3:
								break;
							case Board.Property.gi:
								break;
							case Board.Property.c:
								break;
							case Board.Property.clen:
								break;
							case Board.Property.symmetry:
								break;
							case Board.Property.last_ko:
								break;
							case Board.Property.last_ko_age:
								break;
							case Board.Property.ko:
								break;
							case Board.Property.quicked:
								break;
							case Board.Property.history_hash:
								break;
							case Board.Property.hash:
								break;
							case Board.Property.qhash:
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
			// Child
			if (wrapProperty.p is WeiqiCustomMove) {
				switch ((WeiqiCustomMove.Property)wrapProperty.n) {
				case WeiqiCustomMove.Property.from:
					dirty = true;
					break;
				case WeiqiCustomMove.Property.dest:
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