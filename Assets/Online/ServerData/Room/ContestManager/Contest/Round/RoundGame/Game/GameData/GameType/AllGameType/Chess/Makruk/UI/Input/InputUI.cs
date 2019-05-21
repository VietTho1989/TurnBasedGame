using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
{
    public class InputUI : UIBehavior<InputUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Makruk>> makruk;

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
                makruk,
                sub
            }

            public UIData() : base()
            {
                this.makruk = new VP<ReferenceData<Makruk>>(this, (byte)Property.makruk, new ReferenceData<Makruk>(null));
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
                            // Find Makruk
                            Makruk makruk = null;
                            {
                                InputUI.UIData inputUIData = data.findDataInParent<InputUI.UIData>();
                                if (inputUIData != null)
                                {
                                    makruk = inputUIData.makruk.v.data;
                                }
                                else
                                {
                                    Debug.LogError("inputUIData null: " + data);
                                }
                            }
                            if (makruk != null)
                            {
                                Game game = makruk.findDataInParent<Game>();
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
                                Debug.LogError("makruk null: " + data);
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Makruk ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (GameDataUI.UIData.IsAllowInput(this.data))
                    {
                        // use rule or not
                        if (GameData.IsUseRule(this.data.makruk.v.data))
                        {
                            // Find
                            UseRuleInputUI.UIData useRuleInputUIData = this.data.sub.newOrOld<UseRuleInputUI.UIData>();
                            {
                                // makruk
                                useRuleInputUIData.makruk.v = new ReferenceData<Makruk>(this.data.makruk.v.data);
                            }
                            this.data.sub.v = useRuleInputUIData;
                        }
                        else
                        {
                            // Find
                            NoneRuleInputUI.UIData noneRuleInputUIData = this.data.sub.newOrOld<NoneRuleInputUI.UIData>();
                            {
                                // makruk
                                noneRuleInputUIData.makruk.v = new ReferenceData<Makruk>(this.data.makruk.v.data);
                            }
                            this.data.sub.v = noneRuleInputUIData;
                            /*UseRuleInputUI.UIData useRuleInputUIData = this.data.sub.newOrOld<UseRuleInputUI.UIData> ();
							{
								// makruk
								useRuleInputUIData.makruk.v = new ReferenceData<Makruk> (this.data.makruk.v.data);
							}
							this.data.sub.v = useRuleInputUIData;*/
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
        private GameDataCheckChangeRule<Makruk> gameDataCheckChangeRule = new GameDataCheckChangeRule<Makruk>();

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
                    uiData.makruk.allAddCallBack(this);
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
                // makruk
                {
                    if (data is Makruk)
                    {
                        Makruk makruk = data as Makruk;
                        // Check change
                        {
                            gameDataCheckChangeRule.addCallBack(this);
                            gameDataCheckChangeRule.setData(makruk);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is GameDataCheckChangeRule<Makruk>)
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
                    uiData.makruk.allRemoveCallBack(this);
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
                // makruk
                {
                    if (data is Makruk)
                    {
                        // Makruk makruk = data as Makruk;
                        // Check change
                        {
                            gameDataCheckChangeRule.removeCallBack(this);
                            gameDataCheckChangeRule.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is GameDataCheckChangeRule<Makruk>)
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
                    case UIData.Property.makruk:
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
                // makruk
                {
                    if (wrapProperty.p is Makruk)
                    {
                        return;
                    }
                    // Check change
                    if (wrapProperty.p is GameDataCheckChangeRule<Makruk>)
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