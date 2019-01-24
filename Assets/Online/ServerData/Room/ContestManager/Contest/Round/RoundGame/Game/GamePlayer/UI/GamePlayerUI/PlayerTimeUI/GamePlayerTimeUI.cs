using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TimeControl;
using TimeControl.Normal;
using TimeControl.HourGlass;

public class GamePlayerTimeUI : UIBehavior<GamePlayerTimeUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<GamePlayer>> gamePlayer;

		#region Sub

		public abstract class Sub : Data
		{
			public abstract TimeControl.TimeControl.Sub.Type getType();
		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			gamePlayer,
			sub
		}

		public UIData() : base()
		{
			this.gamePlayer = new VP<ReferenceData<GamePlayer>>(this, (byte)Property.gamePlayer, new ReferenceData<GamePlayer>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion
	}

	#endregion
	
	#region Update

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GamePlayer gamePlayer = this.data.gamePlayer.v.data;
				if (gamePlayer != null) {
					// Find timeControls.Sub
					TimeControl.TimeControl.Sub sub = null;
					{
						Game game = gamePlayer.findDataInParent<Game> ();
						if (game != null) {
							GameData gameData = game.gameData.v;
							if (gameData != null) {
								TimeControl.TimeControl timeControls = gameData.timeControl.v;
								if (timeControls != null) {
									sub = timeControls.sub.v;
								} else {
									Debug.LogError ("timeControls null: " + this);
								}
							} else {
								Debug.LogError ("gameData null: " + this);
							}
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
					// Process
					if (sub != null) {
						switch (sub.getType ()) {
						case TimeControl.TimeControl.Sub.Type.Normal:
							{
								// TimeControlNormal normal = sub as TimeControlNormal;
								// Find UI
								GamePlayerTimeNormalUI.UIData normalUIData = this.data.sub.newOrOld<GamePlayerTimeNormalUI.UIData>();
								{
									normalUIData.gamePlayer.v = new ReferenceData<GamePlayer> (gamePlayer);
								}
								this.data.sub.v = normalUIData;
							}
							break;
						case TimeControl.TimeControl.Sub.Type.HourGlass:
							{
								// TimeControlHourGlass hourGlass = sub as TimeControlHourGlass;
								// Find UI
								GamePlayerTimeHourGlassUI.UIData hourGlassUIData = this.data.sub.newOrOld<GamePlayerTimeHourGlassUI.UIData>();
								{
									hourGlassUIData.gamePlayer.v = new ReferenceData<GamePlayer> (gamePlayer);
								}
								this.data.sub.v = hourGlassUIData;
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("sub null: " + this);
					}
				} else {
					Debug.LogError ("gamePlayer null: " + this);
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

	public GamePlayerTimeNormalUI normalPrefab;
	public GamePlayerTimeHourGlassUI hourGlassPrefab;

	private Game game = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.sub.allAddCallBack (this);
				uiData.gamePlayer.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// sub
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				{
					switch (sub.getType ()) {
					case TimeControl.TimeControl.Sub.Type.Normal:
						{
							GamePlayerTimeNormalUI.UIData normalUIData = sub as GamePlayerTimeNormalUI.UIData;
							UIUtils.Instantiate (normalUIData, normalPrefab, this.transform);
						}
						break;
					case TimeControl.TimeControl.Sub.Type.HourGlass:
						{
							GamePlayerTimeHourGlassUI.UIData hourGlassUIData = sub as GamePlayerTimeHourGlassUI.UIData;
							UIUtils.Instantiate (hourGlassUIData, hourGlassPrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			// GamePlayer
			if (data is GamePlayer) {
				GamePlayer gamePlayer = data as GamePlayer;
				// Parent
				{
					DataUtils.addParentCallBack (gamePlayer, this, ref this.game);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is Game) {
					Game game = data as Game;
					{
						game.gameData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.timeControl.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// TimeControls
					{
						if (data is TimeControl.TimeControl) {
							TimeControl.TimeControl timeControls = data as TimeControl.TimeControl;
							{
								timeControls.sub.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						if (data is TimeControl.TimeControl.Sub) {
							dirty = true;
							return;
						}
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.sub.allRemoveCallBack (this);
				uiData.gamePlayer.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// sub
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				{
					switch (sub.getType ()) {
					case TimeControl.TimeControl.Sub.Type.Normal:
						{
							GamePlayerTimeNormalUI.UIData normalUIData = sub as GamePlayerTimeNormalUI.UIData;
							normalUIData.removeCallBackAndDestroy (typeof(GamePlayerTimeNormalUI));
						}
						break;
					case TimeControl.TimeControl.Sub.Type.HourGlass:
						{
							GamePlayerTimeHourGlassUI.UIData hourGlassUIData = sub as GamePlayerTimeHourGlassUI.UIData;
							hourGlassUIData.removeCallBackAndDestroy (typeof(GamePlayerTimeHourGlassUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			// GamePlayer
			if (data is GamePlayer) {
				GamePlayer gamePlayer = data as GamePlayer;
				// Parent
				{
					DataUtils.removeParentCallBack (gamePlayer, this, ref this.game);
				}
				return;
			}
			// Parent
			{
				if (data is Game) {
					Game game = data as Game;
					{
						game.gameData.allRemoveCallBack (this);
					}
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.timeControl.allRemoveCallBack (this);
						}
						dirty = true;
						return;
					}
					// TimeControls
					{
						if (data is TimeControl.TimeControl) {
							TimeControl.TimeControl timeControls = data as TimeControl.TimeControl;
							{
								timeControls.sub.allRemoveCallBack (this);
							}
							return;
						}
						if (data is TimeControl.TimeControl.Sub) {
							return;
						}
					}
				}
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
			case UIData.Property.gamePlayer:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.sub:
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
		// Child
		{
			// sub
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
			// GamePlayer
			if (wrapProperty.p is GamePlayer) {
				return;
			}
			// Parent
			{
				if (wrapProperty.p is Game) {
					switch ((Game.Property)wrapProperty.n) {
					case Game.Property.gamePlayers:
						break;
					case Game.Property.requestDraw:
						break;
					case Game.Property.state:
						break;
					case Game.Property.gameData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Game.Property.history:
						break;
					case Game.Property.gameAction:
						break;
					case Game.Property.undoRedoRequest:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// GameData
				{
					if (wrapProperty.p is GameData) {
						switch ((GameData.Property)wrapProperty.n) {
						case GameData.Property.gameType:
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							break;
						case GameData.Property.timeControl:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case GameData.Property.lastMove:
							break;
						case GameData.Property.state:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// TimeControls
					{
						if (wrapProperty.p is TimeControl.TimeControl) {
							switch ((TimeControl.TimeControl.Property)wrapProperty.n) {
							case TimeControl.TimeControl.Property.isEnable:
								break;
							case TimeControl.TimeControl.Property.aiCanTimeOut:
								break;
							case TimeControl.TimeControl.Property.timeOutPlayers:
								break;
							case TimeControl.TimeControl.Property.sub:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case TimeControl.TimeControl.Property.use:
								break;
							case TimeControl.TimeControl.Property.timeReport:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						if (wrapProperty.p is TimeControl.TimeControl.Sub) {
							return;
						}
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	#endregion

}