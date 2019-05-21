using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class InputUI : UIBehavior<InputUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<MineSweeper>> mineSweeper;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    UseRule,
                    NoneRule
                }

                public abstract Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                mineSweeper,
                sub
            }

            public UIData() : base()
            {
                this.mineSweeper = new VP<ReferenceData<MineSweeper>>(this, (byte)Property.mineSweeper, new ReferenceData<MineSweeper>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // sub
                    if (!isProcess)
                    {
                        Sub sub = this.sub.v;
                        if (sub != null)
                        {
                            isProcess = sub.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("sub null: " + this);
                        }
                    }
                }
                return isProcess;
            }

            public static ClientInput findClientInput(Data data)
            {
                ClientInput clientInput = null;
                {
                    if (data != null)
                    {
                        // Find WaitInputAction
                        WaitInputAction waitInputAction = null;
                        {
                            // Find MineSweeper
                            MineSweeper mineSweeper = null;
                            {
                                InputUI.UIData inputUIData = data.findDataInParent<InputUI.UIData>();
                                if (inputUIData != null)
                                {
                                    mineSweeper = inputUIData.mineSweeper.v.data;
                                }
                                else
                                {
                                    Debug.LogError("inputUIData null: " + data);
                                }
                            }
                            if (mineSweeper != null)
                            {
                                Game game = mineSweeper.findDataInParent<Game>();
                                if (game != null)
                                {
                                    GameAction gameAction = game.gameAction.v;
                                    if (gameAction != null && gameAction is WaitInputAction)
                                    {
                                        waitInputAction = gameAction as WaitInputAction;
                                    }
                                    else
                                    {
                                        Debug.LogError("not waitInputAction null: " + data);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("game null: " + data);
                                }
                            }
                            else
                            {
                                Debug.LogError("mineSweeper null: " + data);
                            }
                        }
                        // Process
                        if (waitInputAction != null)
                        {
                            clientInput = waitInputAction.clientInput.v;
                        }
                        else
                        {
                            Debug.LogError("waitInputAction null: " + data);
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + data);
                    }
                }
                return clientInput;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.MineSweeper ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    MineSweeper mineSweeper = this.data.mineSweeper.v.data;
                    if (mineSweeper != null)
                    {
                        if (GameDataUI.UIData.IsAllowInput(this.data))
                        {
                            // use rule or not
                            if (GameData.IsUseRule(this.data.mineSweeper.v.data))
                            {
                                // Find
                                UseRuleInputUI.UIData useRuleInputUIData = this.data.sub.newOrOld<UseRuleInputUI.UIData>();
                                {
                                    // mineSweeper
                                    useRuleInputUIData.mineSweeper.v = new ReferenceData<MineSweeper>(this.data.mineSweeper.v.data);
                                }
                                this.data.sub.v = useRuleInputUIData;
                            }
                            else
                            {
                                // Find
                                /*NoneRuleInputUI.UIData noneRuleInputUIData = this.data.sub.newOrOld<NoneRuleInputUI.UIData> ();
							{
								// mineSweeper
								noneRuleInputUIData.mineSweeper.v = new ReferenceData<MineSweeper> (this.data.mineSweeper.v.data);
							}
							this.data.sub.v = noneRuleInputUIData;*/
                                UseRuleInputUI.UIData useRuleInputUIData = this.data.sub.newOrOld<UseRuleInputUI.UIData>();
                                {
                                    // mineSweeper
                                    useRuleInputUIData.mineSweeper.v = new ReferenceData<MineSweeper>(this.data.mineSweeper.v.data);
                                }
                                this.data.sub.v = useRuleInputUIData;
                            }
                        }
                        else
                        {
                            Debug.LogError("not use input: " + this);
                            this.data.sub.v = null;
                        }
                    }
                    else
                    {
                        Debug.LogError("mineSweeper null: " + this);
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

        public UseRuleInputUI useRulePrefab;
        public NoneRuleInputUI noneRulePrefab;

        private GameDataUICheckAllowInputChange<UIData> gameDataUICheckAllowInputChange = new GameDataUICheckAllowInputChange<UIData>();
        private GameDataCheckChangeRule<MineSweeper> gameDataCheckChangeRule = new GameDataCheckChangeRule<MineSweeper>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Check change
                {
                    gameDataUICheckAllowInputChange.addCallBack(this);
                    gameDataUICheckAllowInputChange.setData(uiData);
                }
                // Child
                {
                    uiData.mineSweeper.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is GameDataUICheckAllowInputChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // mineSweeper
                {
                    if (data is MineSweeper)
                    {
                        MineSweeper mineSweeper = data as MineSweeper;
                        // Check change
                        {
                            gameDataCheckChangeRule.addCallBack(this);
                            gameDataCheckChangeRule.setData(mineSweeper);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is GameDataCheckChangeRule<MineSweeper>)
                    {
                        dirty = true;
                        return;
                    }
                }
                // sub
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.UseRule:
                                {
                                    UseRuleInputUI.UIData useRuleInputUIData = sub as UseRuleInputUI.UIData;
                                    UIUtils.Instantiate(useRuleInputUIData, useRulePrefab, this.transform);
                                }
                                break;
                            case UIData.Sub.Type.NoneRule:
                                {
                                    NoneRuleInputUI.UIData noneRuleInputUIData = sub as NoneRuleInputUI.UIData;
                                    UIUtils.Instantiate(noneRuleInputUIData, noneRulePrefab, this.transform);
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
                // Check change
                {
                    gameDataUICheckAllowInputChange.removeCallBack(this);
                    gameDataUICheckAllowInputChange.setData(null);
                }
                // Child
                {
                    uiData.mineSweeper.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                }
                return;
            }
            // CheckChange
            if (data is GameDataUICheckAllowInputChange<UIData>)
            {
                return;
            }
            // Child
            {
                // mineSweeper
                {
                    if (data is MineSweeper)
                    {
                        // MineSweeper mineSweeper = data as MineSweeper;
                        // Check change
                        {
                            gameDataCheckChangeRule.removeCallBack(this);
                            gameDataCheckChangeRule.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is GameDataCheckChangeRule<MineSweeper>)
                    {
                        return;
                    }
                }
                // sub
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.UseRule:
                                {
                                    UseRuleInputUI.UIData useRuleInputUIData = sub as UseRuleInputUI.UIData;
                                    useRuleInputUIData.removeCallBackAndDestroy(typeof(UseRuleInputUI));
                                }
                                break;
                            case UIData.Sub.Type.NoneRule:
                                {
                                    NoneRuleInputUI.UIData noneRuleInputUIData = sub as NoneRuleInputUI.UIData;
                                    noneRuleInputUIData.removeCallBackAndDestroy(typeof(NoneRuleInputUI));
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
                    case UIData.Property.mineSweeper:
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
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is GameDataUICheckAllowInputChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // MineSweeper
                {
                    if (wrapProperty.p is MineSweeper)
                    {
                        return;
                    }
                    // Check change
                    if (wrapProperty.p is GameDataCheckChangeRule<MineSweeper>)
                    {
                        dirty = true;
                        return;
                    }
                }
                // sub
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}