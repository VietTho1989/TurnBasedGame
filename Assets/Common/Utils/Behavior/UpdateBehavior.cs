using UnityEngine;
using System.Collections;

public abstract class UpdateBehavior<K> : GameBehavior<K>, DirtyInterface where K : Data
{

	private bool Dirty = true;

	protected bool dirty{
		get{
			return Dirty;
		}
		set{
			Dirty = value;
			if (this) {
				if (this.isShouldDisableUpdate ()) {
					this.enabled = Dirty;
				}
			}
		}
	}

	public void makeDirty()
	{
		dirty = true;
	}

	public abstract bool isShouldDisableUpdate ();

	void Awake() {
		dirty = true;
	}

	public override void OnEnable ()
	{
		base.OnEnable ();
		dirty = true;
	}

	#region Update

	void FixedUpdate()
	{
		this.update ();
	}

	public override void onAfterSetData ()
	{
		base.onAfterSetData ();
		this.update ();
	}

	public abstract void update();

	#endregion
}