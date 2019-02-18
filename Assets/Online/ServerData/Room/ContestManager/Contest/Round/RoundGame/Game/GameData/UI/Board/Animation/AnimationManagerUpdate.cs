using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Record;

public class AnimationManagerUpdate : UpdateBehavior<AnimationManager>
{

    #region Refresh

    private float delayTime = 0;
    private const float DelayDuration = 0.3f;

    private float LastTime = float.MinValue;

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // Debug.LogError ("animationManager state: " + this.data.state.v);
                // check is view record controller state pickup
                {
                    // find
                    bool isViewControllerStatePickUp = false;
                    {
                        ViewRecordUI.UIData viewRecordUIData = this.data.findDataInParent<ViewRecordUI.UIData>();
                        if (viewRecordUIData != null)
                        {
                            ViewRecordControllerUI.UIData controller = viewRecordUIData.controller.v;
                            if (controller != null)
                            {
                                ViewRecordControllerUI.UIData.State state = controller.state.v;
                                if (state != null)
                                {
                                    if (state.getType() == ViewRecordControllerUI.UIData.State.Type.Pick)
                                    {
                                        isViewControllerStatePickUp = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("state null");
                                }
                            }
                            else
                            {
                                Debug.LogError("controller null: " + this);
                            }
                        }
                        else
                        {
                            // Debug.LogError ("viewRecordUIData null: " + this);
                        }
                    }
                    // process
                    if (isViewControllerStatePickUp)
                    {
                        this.data.isEnable.v = false;
                        this.data.reset();
                    }
                    else
                    {
                        this.data.isEnable.v = true;
                    }
                }
                // state
                {
                    // normal
                    switch (this.data.state.v)
                    {
                        case AnimationManager.State.Normal:
                            {
                                delayTime = 0;
                                this.data.lastMove.v = null;
                                // AnimationSetting
                                {
                                    AnimationSetting animationSetting = Setting.get().animationSetting.v;
                                    if (animationSetting != null)
                                    {
                                        if (animationSetting.scale.v > 0)
                                        {
                                            // maxWaitAnimationCount
                                            if (animationSetting.fastForward.v)
                                            {
                                                if (animationSetting.maxWaitAnimationCount.v >= 1)
                                                {
                                                    while (this.data.animationProgresses.vs.Count > animationSetting.maxWaitAnimationCount.v)
                                                    {
                                                        this.data.animationProgresses.removeAt(0);
                                                        Debug.LogError("skip moveAnimation");
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("why maxWaitAnimationCount so small: " + this);
                                                    this.data.animationProgresses.clear();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.data.animationProgresses.clear();
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("animationSetting null: " + this);
                                    }
                                }
                                // update time and duration
                                if (this.data.animationProgresses.vs.Count > 0)
                                {
                                    // Find moveAnimation
                                    AnimationProgress animationProgress = this.data.animationProgresses.vs[0];
                                    // Process
                                    if (animationProgress != null)
                                    {
                                        // correct duration
                                        {
                                            if (animationProgress.duration.v == 0)
                                            {
                                                MoveAnimation moveAnimation = animationProgress.moveAnimation.v.data;
                                                if (moveAnimation != null)
                                                {
                                                    animationProgress.duration.v = moveAnimation.getDuration();
                                                    Debug.LogError("error, animationProgress duration 0: " + animationProgress.duration.v);
                                                }
                                                else
                                                {
                                                    Debug.LogError("moveAnimation null: " + this);
                                                }
                                            }
                                        }
                                        if (animationProgress.time.v >= Mathf.Max(animationProgress.duration.v, 0.00001f))
                                        {
                                            // this.data.animationProgresses.removeAt (0);
                                            this.data.state.v = AnimationManager.State.Remove;
                                            dirty = true;
                                        }
                                        else
                                        {
                                            bool isLoadFullData = true;
                                            {
                                                MoveAnimation moveAnimation = animationProgress.moveAnimation.v.data;
                                                if (moveAnimation != null)
                                                {
                                                    isLoadFullData = moveAnimation.isLoadFullData();
                                                }
                                                else
                                                {
                                                    Debug.LogError("moveAnimation null");
                                                }
                                            }
                                            if (isLoadFullData)
                                            {
                                                float scale = 1;
                                                {
                                                    // find isPause
                                                    bool isPause = false;
                                                    {
                                                        // TODO Can hoan thien
                                                    }
                                                    if (!isPause)
                                                    {
                                                        AnimationSetting animationSetting = Setting.get().animationSetting.v;
                                                        if (animationSetting != null)
                                                        {
                                                            scale = animationSetting.scale.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("animationSetting null: " + this);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        scale = 0;
                                                    }
                                                }
                                                if (Time.time == LastTime)
                                                {
                                                    Debug.LogError("the same last time: " + LastTime);
                                                    dirty = true;
                                                }
                                                else
                                                {
                                                    animationProgress.time.v = Mathf.Min(animationProgress.time.v + Time.fixedDeltaTime * scale, animationProgress.duration.v);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("not load full data");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("why cannot find moveAnimation: " + this);
                                        this.data.animationProgresses.clear();
                                    }
                                }
                            }
                            break;
                        case AnimationManager.State.Remove:
                            {
                                // make lastMove
                                {
                                    if (this.data.lastMove.v == null)
                                    {
                                        // find last moveAnimation
                                        MoveAnimation moveAnimation = null;
                                        {
                                            if (this.data.animationProgresses.vs.Count > 0)
                                            {
                                                AnimationProgress animationProgress = this.data.animationProgresses.vs[0];
                                                moveAnimation = animationProgress.moveAnimation.v.data;
                                            }
                                        }
                                        // Process
                                        if (moveAnimation != null)
                                        {
                                            GameMove lastMove = moveAnimation.makeGameMove();
                                            {
                                                lastMove.uid = this.data.lastMove.makeId();
                                            }
                                            this.data.lastMove.v = lastMove;
                                        }
                                        else
                                        {
                                            Debug.LogError("moveAnimation null: " + this);
                                        }
                                    }
                                }
                                // find needRemove
                                bool isBackward = false;
                                {
                                    ViewRecordUI.UIData viewRecordUIData = this.data.findDataInParent<ViewRecordUI.UIData>();
                                    if (viewRecordUIData != null)
                                    {
                                        ViewRecordControllerUI.UIData controller = viewRecordUIData.controller.v;
                                        if (controller != null)
                                        {
                                            if (controller.speed.v < 0)
                                            {
                                                isBackward = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("controller null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("viewRecordUIData null: " + this);
                                    }
                                }
                                // check need delay
                                bool needDelay = false;
                                {
                                    if (!isBackward)
                                    {
                                        needDelay = true;
                                    }
                                    else
                                    {
                                        if (this.data.animationProgresses.vs.Count > 1)
                                        {
                                            needDelay = true;
                                        }
                                    }
                                }
                                // process
                                if (needDelay)
                                {
                                    if (this.data.animationProgresses.vs.Count > 0)
                                    {
                                        this.data.animationProgresses.removeAt(0);
                                    }
                                    if (!isBackward)
                                    {
                                        delayTime = 0;
                                        this.data.state.v = AnimationManager.State.Delay;
                                        dirty = true;
                                    }
                                    else
                                    {
                                        this.data.state.v = AnimationManager.State.Normal;
                                        dirty = true;
                                    }
                                }
                                else
                                {
                                    // wait for other animation
                                }
                            }
                            break;
                        case AnimationManager.State.Delay:
                            {
                                if (Time.time == LastTime)
                                {
                                    Debug.LogError("the same last time: " + LastTime);
                                    dirty = true;
                                }
                                else
                                {
                                    delayTime += Time.fixedDeltaTime;
                                }
                                if (delayTime >= DelayDuration)
                                {
                                    this.data.state.v = AnimationManager.State.Normal;
                                }
                                dirty = true;
                            }
                            break;
                        default:
                            Debug.LogError("unknown state: " + this.data.state.v);
                            break;
                    }
                }
                LastTime = Time.time;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    private GameDataBoardUI.UIData gameDataBoardUIData = null;
    private Game game = null;

    private ViewRecordUI.UIData viewRecordUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is AnimationManager)
        {
            AnimationManager animationManager = data as AnimationManager;
            // Setting
            {
                Setting.get().animationSetting.allAddCallBack(this);
            }
            // Parent
            {
                DataUtils.addParentCallBack(animationManager, this, ref this.gameDataBoardUIData);
                DataUtils.addParentCallBack(animationManager, this, ref this.viewRecordUIData);
            }
            // Child
            {
                animationManager.animationProgresses.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        {
            if (data is AnimationSetting)
            {
                dirty = true;
                return;
            }
        }
        // Parent
        {
            // gameDataBoardUIData
            {
                if (data is GameDataBoardUI.UIData)
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                    // Child
                    {
                        gameDataBoardUIData.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Parent
                        {
                            DataUtils.addParentCallBack(gameData, this, ref this.game);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is Game)
                        {
                            Game game = data as Game;
                            // Child
                            {
                                game.animationData.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (data is AnimationData)
                            {
                                // AnimationData animationData = data as AnimationData;
                                // reset
                                {
                                    if (this.data != null)
                                    {
                                        this.data.reset();
                                    }
                                    else
                                    {
                                        Debug.LogError("data null: " + this);
                                    }
                                }
                                // Child
                                {
                                    // Khong add
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            if (data is MoveAnimation)
                            {
                                MoveAnimation moveAnimation = data as MoveAnimation;
                                // Add
                                {
                                    if (this.data != null)
                                    {
                                        // TODO Test this.data.waitToAddMoveAnimations.Add (moveAnimation);
                                        this.data.add(moveAnimation);
                                    }
                                    else
                                    {
                                        Debug.LogError("data null: " + this);
                                    }
                                }
                                dirty = true;
                                return;
                            }
                        }
                    }
                }
            }
            // viewRecordUI.UIData
            {
                if (data is ViewRecordUI.UIData)
                {
                    ViewRecordUI.UIData viewRecordUIData = data as ViewRecordUI.UIData;
                    // Child
                    {
                        viewRecordUIData.controller.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ViewRecordControllerUI.UIData)
                    {
                        ViewRecordControllerUI.UIData viewRecordControllerUIData = data as ViewRecordControllerUI.UIData;
                        // Child
                        {
                            viewRecordControllerUIData.state.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is ViewRecordControllerUI.UIData.State)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
        }
        // Child
        {
            if (data is AnimationProgress)
            {
                AnimationProgress animationProgress = data as AnimationProgress;
                // Update
                {
                    UpdateUtils.makeUpdate<AnimationProgressUpdate, AnimationProgress>(animationProgress, this.transform);
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is AnimationManager)
        {
            AnimationManager animationManager = data as AnimationManager;
            // Setting
            {
                Setting.get().animationSetting.allRemoveCallBack(this);
            }
            // Parent
            {
                DataUtils.removeParentCallBack(animationManager, this, ref this.gameDataBoardUIData);
                DataUtils.removeParentCallBack(animationManager, this, ref this.viewRecordUIData);
            }
            // Child
            {
                animationManager.animationProgresses.allRemoveCallBack(this);
            }
            this.setDataNull(animationManager);
            return;
        }
        // Setting
        {
            if (data is AnimationSetting)
            {
                return;
            }
        }
        // Parent
        {
            // gameDataBoardUIData
            {
                if (data is GameDataBoardUI.UIData)
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                    // Child
                    {
                        gameDataBoardUIData.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(gameData, this, ref this.game);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is Game)
                        {
                            Game game = data as Game;
                            // Child
                            {
                                game.animationData.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        {
                            if (data is AnimationData)
                            {
                                AnimationData animationData = data as AnimationData;
                                // Child
                                {
                                    animationData.moveAnimations.allRemoveCallBack(this);
                                }
                                return;
                            }
                            // Child
                            if (data is MoveAnimation)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            // viewRecordUI.UIData
            {
                if (data is ViewRecordUI.UIData)
                {
                    ViewRecordUI.UIData viewRecordUIData = data as ViewRecordUI.UIData;
                    // Child
                    {
                        viewRecordUIData.controller.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ViewRecordControllerUI.UIData)
                    {
                        ViewRecordControllerUI.UIData viewRecordControllerUIData = data as ViewRecordControllerUI.UIData;
                        // Child
                        {
                            viewRecordControllerUIData.state.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is ViewRecordControllerUI.UIData.State)
                    {
                        return;
                    }
                }
            }
        }
        // Child
        {
            if (data is AnimationProgress)
            {
                AnimationProgress animationProgress = data as AnimationProgress;
                // Update
                {
                    animationProgress.removeCallBackAndDestroy(typeof(AnimationProgressUpdate));
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is AnimationManager)
        {
            switch ((AnimationManager.Property)wrapProperty.n)
            {
                case AnimationManager.Property.isEnable:
                    dirty = true;
                    break;
                case AnimationManager.Property.animationProgresses:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case AnimationManager.Property.lastMove:
                    dirty = true;
                    break;
                case AnimationManager.Property.state:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Setting
        {
            if (wrapProperty.p is AnimationSetting)
            {
                switch ((AnimationSetting.Property)wrapProperty.n)
                {
                    case AnimationSetting.Property.scale:
                        dirty = true;
                        break;
                    case AnimationSetting.Property.fastForward:
                        dirty = true;
                        break;
                    case AnimationSetting.Property.maxWaitAnimationCount:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        // Parent
        {
            // gameDataBoardUIData
            {
                if (wrapProperty.p is GameDataBoardUI.UIData)
                {
                    switch ((GameDataBoardUI.UIData.Property)wrapProperty.n)
                    {
                        case GameDataBoardUI.UIData.Property.gameData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameDataBoardUI.UIData.Property.animationManager:
                            break;
                        case GameDataBoardUI.UIData.Property.sub:
                            break;
                        case GameDataBoardUI.UIData.Property.perspective:
                            break;
                        case GameDataBoardUI.UIData.Property.perspectiveUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GameData)
                    {
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is Game)
                        {
                            switch ((Game.Property)wrapProperty.n)
                            {
                                case Game.Property.gamePlayers:
                                    break;
                                case Game.Property.requestDraw:
                                    break;
                                case Game.Property.state:
                                    break;
                                case Game.Property.gameData:
                                    break;
                                case Game.Property.history:
                                    break;
                                case Game.Property.gameAction:
                                    break;
                                case Game.Property.undoRedoRequest:
                                    break;
                                case Game.Property.chatRoom:
                                    break;
                                case Game.Property.animationData:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        {
                            if (wrapProperty.p is AnimationData)
                            {
                                switch ((AnimationData.Property)wrapProperty.n)
                                {
                                    case AnimationData.Property.moveAnimations:
                                        {
                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                            dirty = true;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                            // Child
                            if (wrapProperty.p is MoveAnimation)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            // viewRecordUI.UIData
            {
                if (wrapProperty.p is ViewRecordUI.UIData)
                {
                    switch ((ViewRecordUI.UIData.Property)wrapProperty.n)
                    {
                        case ViewRecordUI.UIData.Property.dataRecord:
                            break;
                        case ViewRecordUI.UIData.Property.sub:
                            break;
                        case ViewRecordUI.UIData.Property.controller:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is ViewRecordControllerUI.UIData)
                    {
                        switch ((ViewRecordControllerUI.UIData.Property)wrapProperty.n)
                        {
                            case ViewRecordControllerUI.UIData.Property.dataRecord:
                                break;
                            case ViewRecordControllerUI.UIData.Property.speed:
                                dirty = true;
                                break;
                            case ViewRecordControllerUI.UIData.Property.requestSpeed:
                                break;
                            case ViewRecordControllerUI.UIData.Property.state:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case ViewRecordControllerUI.UIData.Property.time:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is ViewRecordControllerUI.UIData.State)
                    {
                        ViewRecordControllerUI.UIData.State state = wrapProperty.p as ViewRecordControllerUI.UIData.State;
                        switch (state.getType())
                        {
                            case ViewRecordControllerUI.UIData.State.Type.Play:
                                {
                                    switch ((ViewRecordControllerStatePlay.Property)wrapProperty.n)
                                    {
                                        case ViewRecordControllerStatePlay.Property.time:
                                            break;
                                        case ViewRecordControllerStatePlay.Property.state:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            case ViewRecordControllerUI.UIData.State.Type.Pick:
                                {
                                    switch ((ViewRecordControllerStatePick.Property)wrapProperty.n)
                                    {
                                        case ViewRecordControllerStatePick.Property.pickTime:
                                            break;
                                        case ViewRecordControllerStatePick.Property.startTime:
                                            break;
                                        default:
                                            Debug.LogError("Don't proess: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
        }
        // Child
        {
            if (wrapProperty.p is AnimationProgress)
            {
                switch ((AnimationProgress.Property)wrapProperty.n)
                {
                    case AnimationProgress.Property.time:
                        dirty = true;
                        break;
                    case AnimationProgress.Property.duration:
                        dirty = true;
                        break;
                    case AnimationProgress.Property.moveAnimation:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}