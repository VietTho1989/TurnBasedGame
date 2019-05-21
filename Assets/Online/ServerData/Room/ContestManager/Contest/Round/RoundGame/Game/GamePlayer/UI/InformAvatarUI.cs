using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InformAvatarUI : UIBehavior<InformAvatarUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GamePlayer.Inform>> inform;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract GamePlayer.Inform.Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            inform,
            sub
        }

        public UIData() : base()
        {
            this.inform = new VP<ReferenceData<GamePlayer.Inform>>(this, (byte)Property.inform, new ReferenceData<GamePlayer.Inform>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

    }

    #endregion

    public override int getStartAllocate()
    {
        return 2;
    }

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GamePlayer.Inform inform = this.data.inform.v.data;
                if (inform != null)
                {
                    switch (inform.getType())
                    {
                        case GamePlayer.Inform.Type.None:
                            {
                                EmptyInform emptyInform = inform as EmptyInform;
                                // UIData
                                EmptyInformAvatarUI.UIData emptyInformAvatarUIData = this.data.sub.newOrOld<EmptyInformAvatarUI.UIData>();
                                {
                                    emptyInformAvatarUIData.emptyInform.v = new ReferenceData<EmptyInform>(emptyInform);
                                }
                                this.data.sub.v = emptyInformAvatarUIData;
                            }
                            break;
                        case GamePlayer.Inform.Type.Human:
                            {
                                Human human = inform as Human;
                                // UIData
                                HumanAvatarUI.UIData humanAvatarUIData = this.data.sub.newOrOld<HumanAvatarUI.UIData>();
                                {
                                    humanAvatarUIData.human.v = new ReferenceData<Human>(human);
                                }
                                this.data.sub.v = humanAvatarUIData;
                            }
                            break;
                        case GamePlayer.Inform.Type.Computer:
                            {
                                Computer computer = inform as Computer;
                                // UIData
                                ComputerAvatarUI.UIData computerAvatarUIData = this.data.sub.newOrOld<ComputerAvatarUI.UIData>();
                                {
                                    computerAvatarUIData.computer.v = new ReferenceData<Computer>(computer);
                                }
                                this.data.sub.v = computerAvatarUIData;
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + inform.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    // Debug.LogError ("inform null: " + this);
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

    public EmptyInformAvatarUI emptyInformPrefab;
    public HumanAvatarUI humanPrefab;
    public ComputerAvatarUI computerPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.inform.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is GamePlayer.Inform)
            {
                dirty = true;
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GamePlayer.Inform.Type.None:
                            {
                                EmptyInformAvatarUI.UIData emptyInformAvatarUIData = sub as EmptyInformAvatarUI.UIData;
                                UIUtils.Instantiate(emptyInformAvatarUIData, emptyInformPrefab, this.transform);
                            }
                            break;
                        case GamePlayer.Inform.Type.Human:
                            {
                                HumanAvatarUI.UIData humanAvatarUIData = sub as HumanAvatarUI.UIData;
                                UIUtils.Instantiate(humanAvatarUIData, humanPrefab, this.transform);
                            }
                            break;
                        case GamePlayer.Inform.Type.Computer:
                            {
                                ComputerAvatarUI.UIData computerAvatarUIData = sub as ComputerAvatarUI.UIData;
                                UIUtils.Instantiate(computerAvatarUIData, computerPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
                uiData.inform.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is GamePlayer.Inform)
            {
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GamePlayer.Inform.Type.None:
                            {
                                EmptyInformAvatarUI.UIData emptyInformAvatarUIData = sub as EmptyInformAvatarUI.UIData;
                                emptyInformAvatarUIData.removeCallBackAndDestroy(typeof(EmptyInformAvatarUI));
                            }
                            break;
                        case GamePlayer.Inform.Type.Human:
                            {
                                HumanAvatarUI.UIData humanAvatarUIData = sub as HumanAvatarUI.UIData;
                                humanAvatarUIData.removeCallBackAndDestroy(typeof(HumanAvatarUI));
                            }
                            break;
                        case GamePlayer.Inform.Type.Computer:
                            {
                                ComputerAvatarUI.UIData computerAvatarUIData = sub as ComputerAvatarUI.UIData;
                                computerAvatarUIData.removeCallBackAndDestroy(typeof(ComputerAvatarUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.inform:
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
            if (wrapProperty.p is GamePlayer.Inform)
            {
                return;
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}