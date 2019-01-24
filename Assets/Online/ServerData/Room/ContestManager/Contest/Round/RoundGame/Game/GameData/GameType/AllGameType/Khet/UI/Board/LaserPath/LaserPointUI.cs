using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class LaserPointUI : UIBehavior<LaserPointUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<int> position;

			public VP<Common.Player> owner;

			public VP<int> direction;

			#region Constructor

			public enum Property
			{
				position,
				owner,
				direction
			}

			public UIData() : base()
			{
				this.position = new VP<int>(this, (byte)Property.position, 0);
				this.owner = new VP<Common.Player>(this, (byte)Property.owner, Common.Player.Silver);
				this.direction = new VP<int>(this, (byte)Property.direction, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public GameObject contentContainer;
		public Text tvDirection;
		public Image background;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.position.v >= 0 && this.data.position.v < Common.BoardArea) {
						if (this.data.direction.v >= 0) {
							// contentContainer
							if (contentContainer != null) {
								contentContainer.SetActive (true);
							} else {
								Debug.LogError ("contentContainer null");
							}
							// tvDirection
							if (tvDirection != null) {
								tvDirection.text = "" + this.data.direction.v;
								// color
								switch (this.data.owner.v) {
								case Common.Player.Silver:
									tvDirection.color = Color.red;
									break;
								case Common.Player.Red:
									tvDirection.color = Color.white;
									break;
								default:
									Debug.LogError ("unknown owner: " + this.data.owner.v);
									break;
								}
							} else {
								Debug.LogError ("tvDirection null");
							}
							// background
							if (background != null) {
								switch (this.data.owner.v) {
								case Common.Player.Silver:
									background.color = new Color (1f, 1f, 1f, 0.4f);
									break;
								case Common.Player.Red:
									background.color = new Color (1f, 0f, 0f, 0.4f);
									break;
								default:
									Debug.LogError ("unknown owner: " + this.data.owner.v);
									break;
								}
							} else {
								Debug.LogError ("background null");
							}
							// position
							this.transform.localPosition = Common.getLocalPosition(this.data.position.v);
						} else {
							// contentContainer
							if (contentContainer != null) {
								contentContainer.SetActive (false);
							} else {
								Debug.LogError ("contentContainer null");
							}
						}
					} else {
						// Debug.LogError ("outsideBoard");
						// contentContainer
						if (contentContainer != null) {
							contentContainer.SetActive (false);
						} else {
							Debug.LogError ("contentContainer null");
						}
					}
				} else {
					Debug.LogError ("data null");
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
			if (data is UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
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
				case UIData.Property.position:
					dirty = true;
					break;
				case UIData.Property.direction:
					dirty = true;
					break;
				case UIData.Property.owner:
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