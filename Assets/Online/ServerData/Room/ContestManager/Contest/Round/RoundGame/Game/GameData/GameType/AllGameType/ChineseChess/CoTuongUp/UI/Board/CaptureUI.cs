using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
	public class CaptureUI : UIBehavior<CaptureUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<UpdateTransform.UpdateData> updateTransform;

			public VP<byte> piece;

			#region Constructor

			public enum Property
			{
				updateTransform,
				piece
			}

			public UIData() : base()
			{
				this.updateTransform = new VP<UpdateTransform.UpdateData>(this, (byte)Property.updateTransform, new UpdateTransform.UpdateData());
				this.piece = new VP<byte>(this, (byte)Property.piece, Common.x);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Sprite eaten;
		public Sprite RedGeneral;
		public Sprite RedAdvisor;
		public Sprite RedElephant;
		public Sprite RedHorse;
		public Sprite RedChariot;
		public Sprite RedCannon;
		public Sprite RedPawn;
		public Sprite BlackGeneral;
		public Sprite BlackAdvisor;
		public Sprite BlackElephant;
		public Sprite BlackHorse;
		public Sprite BlackChariot;
		public Sprite BlackPawn;
		public Sprite BlackCannon;
		public Sprite Hidden;

		public Image img;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// check load full
					bool isLoadFull = true;
					{
						// animation
						if (isLoadFull) {
							isLoadFull = AnimationManager.IsLoadFull (this.data);
						}
					}
					// process
					if (isLoadFull) {
						// img
						if (img != null) {
							if (!Common.Visibility.isHide (this.data.piece.v)) {
								img.color = new Color (1f, 1f, 1f, 1f);
								switch (this.data.piece.v) {
								case 0:
									img.sprite = eaten;
									break;

								case Common.K:
									img.sprite = RedGeneral;
									break;
								case Common.A:
									img.sprite = RedAdvisor;
									break;
								case Common.B:
									img.sprite = RedElephant;
									break;
								case Common.R:
									img.sprite = RedChariot;
									break;
								case Common.C:
									img.sprite = RedCannon;
									break;
								case Common.N:
									img.sprite = RedHorse;
									break;
								case Common.P:
									img.sprite = RedPawn;
									break;

								case Common.k:
									img.sprite = BlackGeneral;
									break;
								case Common.a:
									img.sprite = BlackAdvisor;
									break;
								case Common.b:
									img.sprite = BlackElephant;
									break;
								case Common.r:
									img.sprite = BlackChariot;
									break;
								case Common.c:
									img.sprite = BlackCannon;
									break;
								case Common.n:
									img.sprite = BlackHorse;
									break;
								case Common.p:
									img.sprite = BlackPawn;
									break;

								default:
									Debug.LogError ("unknown sprite: " + this.data.piece.v);
									img.sprite = eaten;
									break;
								}
							} else {
								// canView hidden piece?
								bool canView = false;
								{
									BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
									if (boardUIData != null) {
										CoTuongUp coTuongUp = boardUIData.coTuongUp.v.data;
										if (coTuongUp != null) {
											if (coTuongUp.allowViewCapture.v) {
												canView = true;
											} else {
												if (coTuongUp.allowWatcherViewHidden.v && boardUIData.isWatcher.v) {
													canView = true;
												}
											}
										} else {
											Debug.LogError ("coTuongUp null: " + this);
										}
									} else {
										Debug.LogError ("boardUIData null: " + this);
									}
								}
								// process
								if (canView) {
									img.color = new Color (1f, 1f, 1f, 0.6f);
									switch (this.data.piece.v) {
									case 0:
										img.sprite = eaten;
										break;

									case Common.HK:
										img.sprite = RedGeneral;
										break;
									case Common.HA:
										img.sprite = RedAdvisor;
										break;
									case Common.HB:
										img.sprite = RedElephant;
										break;
									case Common.HR:
										img.sprite = RedChariot;
										break;
									case Common.HC:
										img.sprite = RedCannon;
										break;
									case Common.HN:
										img.sprite = RedHorse;
										break;
									case Common.HP:
										img.sprite = RedPawn;
										break;

									case Common.hk:
										img.sprite = BlackGeneral;
										break;
									case Common.ha:
										img.sprite = BlackAdvisor;
										break;
									case Common.hb:
										img.sprite = BlackElephant;
										break;
									case Common.hr:
										img.sprite = BlackChariot;
										break;
									case Common.hc:
										img.sprite = BlackCannon;
										break;
									case Common.hn:
										img.sprite = BlackHorse;
										break;
									case Common.hp:
										img.sprite = BlackPawn;
										break;
									default:
										Debug.LogError ("unknown sprite: " + this.data.piece.v);
										img.sprite = eaten;
										break;
									}
								} else {
									img.color = new Color (1f, 1f, 1f, 1f);
									img.sprite = Hidden;
								}
							}
							// Scale
							{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								this.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
							}
						} else {
							Debug.LogError ("img null: " + this);
						}
					} else {
						Debug.LogError ("not load full");
						dirty = true;
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

		private BoardUI.UIData boardUIData = null;
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
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.boardUIData);
				}
				// Child
				{
					uiData.updateTransform.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// BoardUIData
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						{
							boardUIData.coTuongUp.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is CoTuongUp) {
						dirty = true;
						return;
					}
				}
				// checkChange
				if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
					dirty = true;
					return;
				}
			}
			// Child
			if (data is UpdateTransform.UpdateData) {
				UpdateTransform.UpdateData updateTransform = data as UpdateTransform.UpdateData;
				{
					UpdateUtils.makeComponentUpdate<UpdateTransform, UpdateTransform.UpdateData> (updateTransform, this.transform);
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
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.boardUIData);
				}
				// Child
				{
					uiData.updateTransform.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				// BoardUIData
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						{
							boardUIData.coTuongUp.allRemoveCallBack (this);
						}
						return;
					}
					if (data is CoTuongUp) {
						return;
					}
				}
				// checkChange
				if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
					return;
				}
			}
			// Child
			if (data is UpdateTransform.UpdateData) {
				UpdateTransform.UpdateData updateTransform = data as UpdateTransform.UpdateData;
				{
					updateTransform.removeCallBackAndRemoveComponent (typeof(UpdateTransform));
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
				case UIData.Property.piece:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// boardUIData
				{
					if (wrapProperty.p is BoardUI.UIData) {
						switch ((BoardUI.UIData.Property)wrapProperty.n) {
						case BoardUI.UIData.Property.coTuongUp:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case BoardUI.UIData.Property.isWatcher:
							dirty = true;
							break;
						case BoardUI.UIData.Property.pieces:
							break;
						case BoardUI.UIData.Property.captures:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					if (wrapProperty.p is CoTuongUp) {
						switch ((CoTuongUp.Property)wrapProperty.n) {
						case CoTuongUp.Property.allowViewCapture:
							dirty = true;
							break;
						case CoTuongUp.Property.allowWatcherViewHidden:
							dirty = true;
							break;
						case CoTuongUp.Property.allowOnlyFlip:
							break;
						case CoTuongUp.Property.turn:
							break;
						case CoTuongUp.Property.side:
							break;
						case CoTuongUp.Property.nodes:
							break;
						case CoTuongUp.Property.plyDraw:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				// Check Change
				if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
					switch ((GameDataBoardCheckPerspectiveChange<UIData>.Property)wrapProperty.n) {
					case GameDataBoardCheckPerspectiveChange<UIData>.Property.change:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			if (wrapProperty.p is UpdateTransform.UpdateData) {
				switch ((UpdateTransform.UpdateData.Property)wrapProperty.n) {
				case UpdateTransform.UpdateData.Property.position:
					dirty = true;
					break;
				case UpdateTransform.UpdateData.Property.rotation:
					dirty = true;
					break;
				case UpdateTransform.UpdateData.Property.scale:
					dirty = true;
					break;
				case UpdateTransform.UpdateData.Property.size:
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