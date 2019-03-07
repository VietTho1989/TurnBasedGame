using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;
using Makruk.UseRule;

namespace Makruk
{
	public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>
	{

		#region UIData

		public class UIData : InputUI.UIData.Sub
		{
			
			public VP<ReferenceData<Makruk>> makruk;

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
				makruk,
				state
			}

			public UIData() : base()
			{
				this.makruk = new VP<ReferenceData<Makruk>>(this, (byte)Property.makruk, new ReferenceData<Makruk>(null));
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
					Makruk makruk = this.data.makruk.v.data;
					if (makruk != null) {
						// if makruk have change, return to get
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
								if (Routine.IsNull (getLegalMoves)) {
									getLegalMoves = CoroutineManager.StartCoroutine (TaskGetLegalMoves(), this.gameObject);
								} else {
									Debug.LogError ("Why getLegalMoves != null");
								}
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
			// Find makruk
			Makruk makruk = null;
			{
				if (this.data != null) {
					if (this.data.makruk.v.data != null) {
						makruk = this.data.makruk.v.data;
					} else {
						Debug.LogError ("makruk null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
			if (makruk != null) {
				List<MakrukMove> legalMoves = new List<MakrukMove> ();
				// Find legal inputData in other thread
				var mtask = UnityTask.Run (() => { 
					legalMoves = Core.unityGetLegalMoves(makruk, Core.CanCorrect);
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
					ShowUI.UIData show = this.data.state.newOrOld<ShowUI.UIData>();
					{
						// legalMoves
						{
							// Debug.LogError ("show legalMoves: " + GameUtils.Utils.getListString (legalMoves));
							show.legalMoves.clear ();
							for (int i = 0; i < legalMoves.Count; i++) {
								MakrukMove legalMove = legalMoves [i];
								{
									legalMove.uid = show.legalMoves.makeId ();
								}
								show.legalMoves.add (legalMove);
							}
						}
					}
					this.data.state.v = show;
				}
			} else {
				Debug.LogError ("makruk null: " + this);
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

		/** makruk have change?*/
		private bool haveChange = true;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.makruk.allAddCallBack (this);
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
			// Makruk
			{
				if (data is Makruk) {
					Makruk makruk = data as Makruk;
					// Child
					{
						makruk.addCallBackAllChildren (this);
					}
					dirty = true;
					haveChange = true;
					return;
				}
				// Child
				{
					// if (data.findDataInParent<Makruk> () != null) 
					{
						data.addCallBackAllChildren (this);
						dirty = true;
						haveChange = true;
						return;
					}
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
					uiData.makruk.allRemoveCallBack (this);
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
			// Makruk
			{
				if (data is Makruk) {
					Makruk makruk = data as Makruk;
					// Child
					{
						makruk.removeCallBackAllChildren (this);
					}
					return;
				}
				// Child
				{
					data.removeCallBackAllChildren (this);
					return;
				}
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.makruk:
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
			// Makruk
			{
				if (wrapProperty.p is Makruk) {
					if (Generic.IsAddCallBackInterface<T>()) {
						ValueChangeUtils.replaceCallBack (this, syncs);
					}
					dirty = true;
					haveChange = true;
					return;
				}
				// Child
				{
					if (wrapProperty.p.findDataInParent<Makruk> () != null) {
						if (Generic.IsAddCallBackInterface<T>()) {
							ValueChangeUtils.replaceCallBack (this, syncs);
						}
						dirty = true;
						haveChange = true;
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}