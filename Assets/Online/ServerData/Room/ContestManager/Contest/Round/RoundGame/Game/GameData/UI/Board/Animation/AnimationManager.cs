using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : Data
{

	public const float DefaultDuration = 0.36f;

	public VP<bool> isEnable;

	public LP<AnimationProgress> animationProgresses;

	public VP<GameMove> lastMove;

	#region State

	public enum State
	{
		Remove, 
		Delay,
		Normal
	}

	public VP<State> state;

	#endregion

	#region Constructor

	public enum Property
	{
		isEnable,
		animationProgresses,
		lastMove,
		state
	}

	public AnimationManager() : base()
	{
		this.isEnable = new VP<bool> (this, (byte)Property.isEnable, true);
		this.animationProgresses = new LP<AnimationProgress> (this, (byte)Property.animationProgresses);
		this.lastMove = new VP<GameMove> (this, (byte)Property.lastMove, null);
		this.state = new VP<State> (this, (byte)Property.state, State.Normal);
	}

	#endregion

	public bool isOnAnimation()
	{
		if (this.animationProgresses.vs.Count > 0) {
			return true;
		}
		return false;
	}

	#region action

	public void add(MoveAnimation moveAnimation)
	{
		if (moveAnimation != null) {
			if (this.isEnable.v) {
				AnimationProgress animationProgress = new AnimationProgress ();
				{
					animationProgress.uid = this.animationProgresses.makeId ();
					// time
					animationProgress.time.v = 0;
					// duration
					animationProgress.duration.v = moveAnimation.getDuration ();
					// moveAnimation
					animationProgress.moveAnimation.v = new ReferenceData<MoveAnimation> (moveAnimation);
					// isReverse?
					{
						bool isReverse = false;
						{
							Record.ViewRecordUI.UIData viewRecordUIData = this.findDataInParent<Record.ViewRecordUI.UIData> ();
							if (viewRecordUIData != null) {
								Record.ViewRecordControllerUI.UIData controller = viewRecordUIData.controller.v;
								if (controller != null) {
									if (controller.speed.v < 0) {
										isReverse = true;
									}
								} else {
									Debug.LogError ("controller null: " + this);
								}
							} else {
								// Debug.LogError ("viewRecordUIData null: " + this);
							}
						}
						animationProgress.isReverse = isReverse;
					}
				}
				this.animationProgresses.add (animationProgress);
			} else {
				// Debug.LogError ("not enable, so not add");
			}
		} else {
			Debug.LogError ("moveAnimation null: " + this);
		}
	}

	public void reset()
	{
		this.animationProgresses.clear ();
		this.lastMove.v = null;
		this.state.v = State.Normal;
	}

	#endregion

	public static bool IsLoadFull(Data data)
	{
		bool ret = true;
		{
			if (data != null) {
				GameDataBoardUI.UIData gameDataBoardUIData = data.findDataInParent<GameDataBoardUI.UIData> ();
				if (gameDataBoardUIData != null) {
					AnimationManager animationManager = gameDataBoardUIData.animationManager.v;
					if (animationManager != null) {
						ret = animationManager.isLoadFull ();
					} else {
						Debug.LogError ("animationManager null");
					}
				} else {
					Debug.LogError ("gameDataBoardUIData null");
				}
			} else {
				Debug.LogError ("data null");
			}
		}
		return ret;
	}

	public bool isLoadFull()
	{
		bool ret = true;
		{
			if (this.animationProgresses.vs.Count > 0) {
				AnimationProgress animationProgress = this.animationProgresses.vs [0];
				MoveAnimation moveAnimation = animationProgress.moveAnimation.v.data;
				if (moveAnimation != null) {
					if (!moveAnimation.isLoadFullData ()) {
						Debug.LogError ("moveAnimation not load full");
						ret = false;
					}
				} else {
					Debug.LogError ("moveAnimation null");
				}
			} else {
				// find animationData
				AnimationData animationData = null;
				{
					GameDataBoardUI.UIData gameDataBoardUIData = this.findDataInParent<GameDataBoardUI.UIData> ();
					if (gameDataBoardUIData != null) {
						GameData gameData = gameDataBoardUIData.gameData.v.data;
						if (gameData != null) {
							Game game = gameData.findDataInParent<Game> ();
							if (game != null) {
								animationData = game.animationData.v;
							} else {
								Debug.LogError ("game null");
							}
						} else {
							Debug.LogError ("gameData null");
						}
					} else {
						Debug.LogError ("gameDataBoardUIData null");
					}
				}
				// process
				if (animationData != null) {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (animationData, out dataIdentity)) {
						if (dataIdentity is AnimationDataIdentity) {
							AnimationDataIdentity animationDataIdentity = dataIdentity as AnimationDataIdentity;
							if (animationDataIdentity.moveAnimations != animationData.moveAnimations.vs.Count) {
								ret = false;
							}
						}
					}
				} else {
					// Debug.LogError ("animationData null");
				}
			}
		}
		return ret;
	}

}