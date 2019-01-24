using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class LoadUpdate : UpdateBehavior<Load>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Game game = this.data.findDataInParent<Game> ();
					if (game != null) {
						Start start = new Start ();
						{
							start.uid = game.state.makeId ();
							// sub
							{
								// TODO Can hoan thien
							}
						}
						game.state.v = start;
					} else {
						Debug.LogError ("game null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is Load) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Load) {
				Load load = data as Load;
				{

				}
				this.setDataNull (load);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Load) {
				switch ((Load.Property)wrapProperty.n) {
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