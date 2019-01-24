using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace Posture
{
	public class ChoosePostureAdapter : SRIA<ChoosePostureAdapter.UIData, ChoosePostureHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{
			public VP<ReferenceData<ChoosePostureUI.UIData>> loadPostureData;

			public LP<ChoosePostureHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				loadPostureData,
				holders
			}

			public UIData() : base()
			{
				this.loadPostureData = new VP<ReferenceData<ChoosePostureUI.UIData>>(this, (byte)Property.loadPostureData, new ReferenceData<ChoosePostureUI.UIData>(null));
				this.holders = new LP<ChoosePostureHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<PostureGameData> postureGameDatas = new List<PostureGameData>();

			public void reset()
			{
				this.postureGameDatas.Clear();
			}

		}

		#endregion

		#region Adapter

		public ChoosePostureHolder holderPrefab;

		protected override ChoosePostureHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChoosePostureHolder.UIData uiData = new ChoosePostureHolder.UIData();
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

		protected override void UpdateViewsHolder (ChoosePostureHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoPostures;
		public static readonly TxtLanguage txtNoPostures = new TxtLanguage();

		static ChoosePostureAdapter()
		{
			txtNoPostures.add (Language.Type.vi, "Không có thế cờ nào cả");
		}

		#endregion

		public GameObject noPostures;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						ChoosePostureUI.UIData loadPostureData = this.data.loadPostureData.v.data;
						if (loadPostureData != null) {
							int min = Mathf.Min (loadPostureData.gameDatas.vs.Count, _Params.postureGameDatas.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (loadPostureData.gameDatas.vs [i] != _Params.postureGameDatas [i]) {
										// change param
										_Params.postureGameDatas [i] = loadPostureData.gameDatas.vs [i];
										// Update holder
										foreach (ChoosePostureHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.postureGameData.v = new ReferenceData<PostureGameData> (loadPostureData.gameDatas.vs [i]);
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (loadPostureData.gameDatas.vs.Count > min) {
									// Add
									int insertCount = loadPostureData.gameDatas.vs.Count - min;
									List<PostureGameData> addItems = loadPostureData.gameDatas.vs.GetRange (min, insertCount);
									_Params.postureGameDatas.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.postureGameDatas.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.postureGameDatas.RemoveRange (min, deleteCount);
									}
								}
							}
							// NoPostures
							{
								if (noPostures != null) {
									if (loadPostureData.state.v == ChoosePostureUI.UIData.State.Show) {
										bool haveAny = false;
										{
											foreach (ChoosePostureHolder.UIData holder in this.data.holders.vs) {
												if (holder.postureGameData.v.data != null) {
													ChoosePostureHolder holderUI = holder.findCallBack<ChoosePostureHolder> ();
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
										}
										noPostures.SetActive (!haveAny);
									} else {
										noPostures.SetActive (false);
									}
								} else {
									Debug.LogError ("noHumans null: " + this);
								}
							}
						} else {
							Debug.LogError ("loadPostureData null: " + this);
						}
						// txt
						{
							if (tvNoPostures != null) {
								tvNoPostures.text = txtNoPostures.get ("Don't have any postures");
							} else {
								Debug.LogError ("tvNoPostures null: " + this);
							}
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.loadPostureData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ChoosePostureUI.UIData) {
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
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
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.loadPostureData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			{
				if (data is ChoosePostureUI.UIData) {
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
				case UIData.Property.loadPostureData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.holders:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Setting
			if (wrapProperty.p is Setting) {
				switch ((Setting.Property)wrapProperty.n) {
				case Setting.Property.language:
					dirty = true;
					break;
				case Setting.Property.showLastMove:
					break;
				case Setting.Property.viewUrlImage:
					break;
				case Setting.Property.animationSetting:
					break;
				case Setting.Property.maxThinkCount:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is ChoosePostureUI.UIData) {
				switch ((ChoosePostureUI.UIData.Property)wrapProperty.n) {
				case ChoosePostureUI.UIData.Property.adapter:
					break;
				case ChoosePostureUI.UIData.Property.state:
					dirty = true;
					break;
				case ChoosePostureUI.UIData.Property.gameType:
					break;
				case ChoosePostureUI.UIData.Property.gameDatas:
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