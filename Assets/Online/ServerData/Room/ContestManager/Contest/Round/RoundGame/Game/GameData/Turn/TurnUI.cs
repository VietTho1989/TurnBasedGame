using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnUI : UIBehavior<TurnUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<Turn>> turn;

		#region Constructor

		public enum Property
		{
			turn
		}

		public UIData() : base()
		{
			this.turn = new VP<ReferenceData<Turn>>(this, (byte)Property.turn, new ReferenceData<Turn>(null));
		}

		#endregion
	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtTurn = new TxtLanguage ();

	static TurnUI()
	{
		txtTurn.add (Language.Type.vi, "Lượt");
	}

	#endregion

	public Text tvTurn;
	public Text tvWho;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Turn turn = this.data.turn.v.data;
				if (turn != null) {
					if (tvTurn != null && tvWho != null) {
						tvTurn.text = txtTurn.get ("Turn") + " " + turn.turn.v;
						// Who
						{
							// Find GameType
							GameType gameType = null;
							{
								GameData gameData = turn.findDataInParent<GameData> ();
								if (gameData != null) {
									gameType = gameData.gameType.v;
								} else {
									Debug.LogError ("gameData null");
								}
							}
							if (gameType != null) {
								tvWho.text = "" + turn.playerIndex.v;
							} else {
								Debug.LogError ("gameType null");
							}
						}
					} else {
						Debug.LogError ("tvTurn, tvWho null");
					}
				} else {
					Debug.LogError ("turn null: " + this);
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.turn.allAddCallBack (this);
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
		if (data is Turn) {
			dirty = true;
			return;
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
				uiData.turn.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Child
		if (data is Turn) {
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
			case UIData.Property.turn:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
		if (wrapProperty.p is Turn) {
			switch ((Turn.Property)wrapProperty.n) {
			case Turn.Property.turn:
				dirty = true;
				break;
			case Turn.Property.playerIndex:
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