using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Xiangqi.UseRule;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace Xiangqi
{
	public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>
	{

		#region UIData

		public class UIData : InputUI.UIData.Sub
		{
			
			public VP<ReferenceData<Xiangqi>> xiangqi;

			#region State

			public abstract class State : Data
			{
				
				public enum Type
				{
					/** Get legal moves*/
					Get,
					/** Getting legal moves*/
					Getting,
					/** Have got legal moves, now show*/
					Show
				}

				public abstract Type getType();

				public abstract bool processEvent(Event e);

			}

			public VP<State> state;

			#endregion

			#region Constructor

			public enum Property
			{
				xiangqi,
				state
			}

			public UIData() : base()
			{
				this.xiangqi = new VP<ReferenceData<Xiangqi>>(this, (byte)Property.xiangqi, new ReferenceData<Xiangqi>(null));
				this.state = new VP<State>(this, (byte)Property.state, new GetUI.UIData());
			}

			#endregion

			public override Type getType ()
			{
				return Type.UseRule;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// state
					if (!isProcess) {
						State state = this.state.v;
						if (state != null) {
							isProcess = state.processEvent (e);
						} else {
							Debug.LogError ("state null: " + this);
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Xiangqi xiangqi = this.data.xiangqi.v.data;
					if (xiangqi != null) {
						// if xiangqi have change, return to get
						if (haveChange) {
							haveChange = false;
							// getUIData
							{
								GetUI.UIData getUIData = this.data.state.newOrOld<GetUI.UIData> ();
								{

								}
								this.data.state.v = getUIData;
							}
						}
						// Task get ai move
						switch (this.data.state.v.getType ()) {
						case UIData.State.Type.Get:
							{
								destroyRoutine (getLegalMoves);
								// Chuyen sang getting
								{
									GettingUI.UIData newGetting = new GettingUI.UIData ();
									{
										newGetting.uid = this.data.state.makeId ();
									}
									this.data.state.v = newGetting;
								}
							}
							break;
						case UIData.State.Type.Getting:
							{
								startRoutine (ref this.getLegalMoves, TaskGetLegalMoves ());
							}
							break;
						case UIData.State.Type.Show:
							{
								destroyRoutine (getLegalMoves);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + this.data.state.v.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("xiangqi null: " + this);
						GetUI.UIData getUIData = this.data.state.newOrOld<GetUI.UIData> ();
						{

						}
						this.data.state.v = getUIData;
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region Task get legal moves

		private Routine getLegalMoves;

		public IEnumerator TaskGetLegalMoves()
		{
			// Find xiangqi
			Xiangqi xiangqi = null;
			{
				if (this.data != null) {
					if (this.data.xiangqi.v.data != null) {
						xiangqi = this.data.xiangqi.v.data;
					} else {
						Debug.LogError ("xiangqi null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
			if (xiangqi != null) {
				List<LegalMove> legalMoves = new List<LegalMove> ();
				// Find legal inputData in other thread
				var mtask = UnityTask.Run (() => { 
					legalMoves = Core.unityGetLegalMoves(xiangqi, Core.CanCorrect);
				});
				// Wait
				{
					while (!mtask.IsCompleted) {
						yield return new Wait ();
					}
					// yield return mtask;
					if (mtask.IsFaulted) {
						Debug.LogException (mtask.Exception);
					}
				}
				// Change state
				{
					// Find show
					ShowUI.UIData showUIData = this.data.state.newOrOld<ShowUI.UIData>();
					{
						// legalMoves
						{
							// Debug.LogError ("show legalMoves: " + GameUtils.Utils.getListString (legalMoves));
							showUIData.legalMoves.clear ();
							for (int i = 0; i < legalMoves.Count; i++) {
								LegalMove legalMove = legalMoves [i];
								{
									legalMove.uid = showUIData.legalMoves.makeId ();
								}
								showUIData.legalMoves.add (legalMove);
							}
						}
					}
					this.data.state.v = showUIData;
				}
			} else {
				Debug.LogError ("xiangqi null: " + this);
			}
		}

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (getLegalMoves);
			}
			return ret;
		}

		#endregion

		#region implement callBacks

		public GetUI getPrefab;
		public GettingUI gettingPrefab;
		public ShowUI showPrefab;

		/** xiangqi have change?*/
		private bool haveChange = true;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.xiangqi.allAddCallBack (this);
					uiData.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// State
			{
				if (data is UIData.State) {
					UIData.State state = data as UIData.State;
					{
						switch (state.getType ()) {
						case UIData.State.Type.Get:
							{
								GetUI.UIData myGet = state as GetUI.UIData;
								UIUtils.Instantiate (myGet, getPrefab, this.transform);
							}
							break;
						case UIData.State.Type.Getting:
							{
								GettingUI.UIData getting = state as GettingUI.UIData;
								UIUtils.Instantiate (getting, gettingPrefab, this.transform);
							}
							break;
						case UIData.State.Type.Show:
							{
								ShowUI.UIData show = state as ShowUI.UIData;
								UIUtils.Instantiate (show, showPrefab, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType ());
							break;
						}
					}
					dirty = true;
					return;
				}
			}
			// Xiangqi
			{
				if (data is Xiangqi) {
					Xiangqi xiangqi = data as Xiangqi;
					// Child
					{
						xiangqi.addCallBackAllChildren (this);
					}
					dirty = true;
					haveChange = true;
					return;
				}
				// Child
				{
					data.addCallBackAllChildren (this);
					dirty = true;
					haveChange = true;
					return;
				}
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.xiangqi.allRemoveCallBack (this);
					uiData.state.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// State
			{
				if (data is UIData.State) {
					UIData.State state = data as UIData.State;
					{
						switch (state.getType ()) {
						case UIData.State.Type.Get:
							{
								GetUI.UIData myGet = state as GetUI.UIData;
								myGet.removeCallBackAndDestroy (typeof(GetUI));
							}
							break;
						case UIData.State.Type.Getting:
							{
								GettingUI.UIData getting = state as GettingUI.UIData;
								getting.removeCallBackAndDestroy (typeof(GettingUI));
							}
							break;
						case UIData.State.Type.Show:
							{
								ShowUI.UIData show = state as ShowUI.UIData;
								show.removeCallBackAndDestroy (typeof(ShowUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType ());
							break;
						}
					}
					return;
				}
			}
			// Xiangqi
			{
				if (data is Xiangqi) {
					Xiangqi xiangqi = data as Xiangqi;
					// Child
					{
						xiangqi.removeCallBackAllChildren (this);
					}
					return;
				}
				// Child
				{
					data.removeCallBackAllChildren (this);
					return;
				}
			}
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.xiangqi:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// State
			{
				if (wrapProperty.p is UIData.State) {
					return;
				}
			}
			// Xiangqi
			{
				if (wrapProperty.p is Xiangqi) {
					if (Generic.IsAddCallBackInterface<T> ()) {
						ValueChangeUtils.replaceCallBack (this, syncs);
					}
					dirty = true;
					haveChange = true;
					return;
				}
				// Child
				{
					if (Generic.IsAddCallBackInterface<T> ()) {
						ValueChangeUtils.replaceCallBack (this, syncs);
					}
					dirty = true;
					haveChange = true;
					return;
				}
			}
			// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}