using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public class StateUI : UIBehavior<StateUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<State>> state;

            #region Sub

            public abstract class Sub : Data
            {
                public abstract State.Type getType();
            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                state,
                sub
            }

            public UIData() : base()
            {
                this.state = new VP<ReferenceData<State>>(this, (byte)Property.state, new ReferenceData<State>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return 1;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    State state = this.data.state.v.data;
                    if (state != null)
                    {
                        switch (state.getType())
                        {
                            case State.Type.Load:
                                {
                                    Load load = state as Load;
                                    // UIData
                                    LoadUI.UIData loadUIData = this.data.sub.newOrOld<LoadUI.UIData>();
                                    {
                                        loadUIData.load.v = new ReferenceData<Load>(load);
                                    }
                                    this.data.sub.v = loadUIData;
                                }
                                break;
                            case State.Type.Start:
                                {
                                    Start start = state as Start;
                                    // UIData
                                    StartUI.UIData startUIData = this.data.sub.newOrOld<StartUI.UIData>();
                                    {
                                        startUIData.start.v = new ReferenceData<Start>(start);
                                    }
                                    this.data.sub.v = startUIData;
                                }
                                break;
                            case State.Type.Play:
                                {
                                    Play play = state as Play;
                                    // UIData
                                    PlayUI.UIData playUIData = this.data.sub.newOrOld<PlayUI.UIData>();
                                    {
                                        playUIData.play.v = new ReferenceData<Play>(play);
                                    }
                                    this.data.sub.v = playUIData;
                                }
                                break;
                            case State.Type.End:
                                {
                                    End end = state as End;
                                    // UIData
                                    EndUI.UIData endUIData = this.data.sub.newOrOld<EndUI.UIData>();
                                    {
                                        endUIData.end.v = new ReferenceData<End>(end);
                                    }
                                    this.data.sub.v = endUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("state null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public LoadUI loadPrefab;
        public StartUI startPrefab;
        public PlayUI playPrefab;
        public EndUI endPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.state.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is State)
                {
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // Child
                    {
                        switch (sub.getType())
                        {
                            case State.Type.Load:
                                {
                                    LoadUI.UIData loadUIData = sub as LoadUI.UIData;
                                    UIUtils.Instantiate(loadUIData, loadPrefab, this.transform);
                                }
                                break;
                            case State.Type.Start:
                                {
                                    StartUI.UIData startUIData = sub as StartUI.UIData;
                                    UIUtils.Instantiate(startUIData, startPrefab, this.transform);
                                }
                                break;
                            case State.Type.Play:
                                {
                                    PlayUI.UIData playUIData = sub as PlayUI.UIData;
                                    UIUtils.Instantiate(playUIData, playPrefab, this.transform);
                                }
                                break;
                            case State.Type.End:
                                {
                                    EndUI.UIData endUIData = sub as EndUI.UIData;
                                    UIUtils.Instantiate(endUIData, endPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.state.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is State)
                {
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // Child
                    {
                        switch (sub.getType())
                        {
                            case State.Type.Load:
                                {
                                    LoadUI.UIData loadUIData = sub as LoadUI.UIData;
                                    loadUIData.removeCallBackAndDestroy(typeof(LoadUI));
                                }
                                break;
                            case State.Type.Start:
                                {
                                    StartUI.UIData startUIData = sub as StartUI.UIData;
                                    startUIData.removeCallBackAndDestroy(typeof(StartUI));
                                }
                                break;
                            case State.Type.Play:
                                {
                                    PlayUI.UIData playUIData = sub as PlayUI.UIData;
                                    playUIData.removeCallBackAndDestroy(typeof(PlayUI));
                                }
                                break;
                            case State.Type.End:
                                {
                                    EndUI.UIData endUIData = sub as EndUI.UIData;
                                    endUIData.removeCallBackAndDestroy(typeof(EndUI));
                                }
                                break;
                            default:
                                Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
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
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.state:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.sub:
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
                if (wrapProperty.p is State)
                {
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}