using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ViewSaveGameHistoryUI : UIBehavior<ViewSaveGameHistoryUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<History>> history;

        #region Constructor

        public enum Property
        {
            history
        }

        public UIData() : base()
        {
            this.history = new VP<ReferenceData<History>>(this, (byte)Property.history, new ReferenceData<History>(null));
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        ViewSaveGameHistoryUI viewSaveGameHistoryUI = this.findCallBack<ViewSaveGameHistoryUI>();
                        if (viewSaveGameHistoryUI != null)
                        {
                            isProcess = viewSaveGameHistoryUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("viewSaveGameHistoryUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtBack = new TxtLanguage("Back");
    private static readonly TxtLanguage txtCannotBack = new TxtLanguage("Cannot back");

    private static readonly TxtLanguage txtNext = new TxtLanguage("Next");
    private static readonly TxtLanguage txtCannotNext = new TxtLanguage("Cannot next");

    public Text tvHistoryNotLoad;
    private static readonly TxtLanguage txtHistoryNotLoad = new TxtLanguage("History not load");

    static ViewSaveGameHistoryUI()
    {
        txtBack.add(Language.Type.vi, "Quay Lại");
        txtCannotBack.add(Language.Type.vi, "Không thể quay lại");
        txtNext.add(Language.Type.vi, "Kế Tiếp");
        txtCannotNext.add(Language.Type.vi, "Không thể kế tiếp");
        txtHistoryNotLoad.add(Language.Type.vi, "Lịch sử không được tải");
    }

    #endregion

    #region Refresh

    public Button btnBack;
    public Text tvBack;

    public Button btnNext;
    public Text tvNext;

    public Text tvPosition;

    public GameObject historyNotLoad;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                History history = this.data.history.v.data;
                if (history != null)
                {
                    // historyNotLoad
                    {
                        if (historyNotLoad != null)
                        {
                            historyNotLoad.SetActive(history.changes.vs.Count != history.changeCount.v);
                        }
                        else
                        {
                            Debug.LogError("historyNotLoad null: " + this);
                        }
                    }
                    // btnBack, tvBack
                    {
                        if (btnBack != null && tvBack != null)
                        {
                            if (history.position.v > 0)
                            {
                                btnBack.interactable = true;
                                tvBack.text = txtBack.get();
                            }
                            else
                            {
                                btnBack.interactable = false;
                                tvBack.text = txtCannotBack.get();
                            }
                        }
                        else
                        {
                            Debug.LogError("btnBack, tvBack null: " + this);
                        }
                    }
                    // btnNext, tvNext
                    {
                        if (btnNext != null && tvNext != null)
                        {
                            if (history.position.v < history.changes.vs.Count - 1)
                            {
                                btnNext.interactable = true;
                                tvNext.text = txtNext.get();
                            }
                            else
                            {
                                btnNext.interactable = false;
                                tvNext.text = txtCannotNext.get();
                            }
                        }
                        else
                        {
                            Debug.LogError("btnNext, tvNext null: " + this);
                        }
                    }
                    // tvPosition
                    {
                        if (tvPosition != null)
                        {
                            tvPosition.text = history.position.v + "/" + history.changes.vs.Count;
                        }
                        else
                        {
                            Debug.LogError("tvPosition null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("history null: " + this);
                }
                // txt
                {
                    if (tvHistoryNotLoad != null)
                    {
                        tvHistoryNotLoad.text = txtHistoryNotLoad.get();
                    }
                    else
                    {
                        Debug.LogError("tvHistoryNotLoad null: " + this);
                    }
                }
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.history.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        if (data is History)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.history.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        if (data is History)
        {
            return;
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
                case UIData.Property.history:
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
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
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
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if (wrapProperty.p is History)
        {
            switch ((History.Property)wrapProperty.n)
            {
                case History.Property.isActive:
                    break;
                case History.Property.changes:
                    dirty = true;
                    break;
                case History.Property.position:
                    dirty = true;
                    break;
                case History.Property.changeCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnNext, onClickBtnNext);
            UIUtils.SetButtonOnClick(btnBack, onClickBtnBack);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.N:
                        {
                            if (btnNext != null && btnNext.gameObject.activeInHierarchy && btnNext.interactable)
                            {
                                this.onClickBtnNext();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    case KeyCode.B:
                        {
                            if (btnBack != null && btnBack.gameObject.activeInHierarchy && btnBack.interactable)
                            {
                                this.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            History history = this.data.history.v.data;
            if (history != null)
            {
                Game game = history.findDataInParent<Game>();
                if (game != null)
                {
                    GameData gameData = game.gameData.v;
                    if (gameData != null)
                    {
                        Turn turn = gameData.turn.v;
                        int currentTurn = turn.turn.v;
                        // next
                        {
                            int backIndex = history.getIndex(currentTurn - 1);
                            history.changePosition(backIndex);
                        }
                    }
                    else
                    {
                        Debug.LogError("gameData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("game null: " + this);
                }
            }
            else
            {
                Debug.LogError("history null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnNext()
    {
        if (this.data != null)
        {
            History history = this.data.history.v.data;
            if (history != null)
            {
                Game game = history.findDataInParent<Game>();
                if (game != null)
                {
                    GameData gameData = game.gameData.v;
                    if (gameData != null)
                    {
                        Turn turn = gameData.turn.v;
                        int currentTurn = turn.turn.v;
                        // next
                        {
                            int nextIndex = history.getIndex(currentTurn + 1);
                            history.changePosition(nextIndex);
                        }
                    }
                    else
                    {
                        Debug.LogError("gameData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("game null: " + this);
                }
            }
            else
            {
                Debug.LogError("history null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}