using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class InformationUI : UIBehavior<InformationUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Weiqi>> weiqi;

            #region Constructor

            public enum Property
            {
                weiqi
            }

            public UIData() : base()
            {
                this.weiqi = new VP<ReferenceData<Weiqi>>(this, (byte)Property.weiqi, new ReferenceData<Weiqi>(null));
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
                            InformationUI informationUI = this.findCallBack<InformationUI>();
                            if (informationUI != null)
                            {
                                isProcess = informationUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("informationUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public Text tvScore;

        public Sprite spriteScoreOn;
        public Sprite spriteScoreOff;
        public Button btnToggleScore;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                // set information
                if (this.data != null)
                {
                    Weiqi weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        // tvScore
                        {
                            if (tvScore != null)
                            {
                                tvScore.text = string.Format("black score: {0}, white score: {1}, dame: {2}, score: {3}, black capture: {4}, white capture: {5}", weiqi.scoreBlack.v, weiqi.scoreWhite.v, weiqi.dame.v, -weiqi.score.v, weiqi.b.v.getCaptures((int)Common.stone.S_BLACK), weiqi.b.v.getCaptures((int)Common.stone.S_WHITE));
                            }
                            else
                            {
                                Debug.LogError("tvScore null: " + this);
                            }
                        }
                        // btnToggleScore
                        {
                            if (btnToggleScore != null)
                            {
                                Image imgToggleScore = btnToggleScore.image;
                                if (imgToggleScore != null)
                                {
                                    // Find mode
                                    BoardUI.UIData.Mode mode = BoardUI.UIData.Mode.Normal;
                                    {
                                        // Find BoardUI.UIData
                                        BoardUI.UIData boardUIData = null;
                                        {
                                            WeiqiGameDataUI.UIData weiqiGameDataUI = this.data.findDataInParent<WeiqiGameDataUI.UIData>();
                                            if (weiqiGameDataUI != null)
                                            {
                                                boardUIData = weiqiGameDataUI.board.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("weiqiGameDataUI null");
                                            }
                                        }
                                        if (boardUIData != null)
                                        {
                                            mode = boardUIData.mode.v;
                                        }
                                    }
                                    // process
                                    switch (mode)
                                    {
                                        case BoardUI.UIData.Mode.Normal:
                                            imgToggleScore.sprite = spriteScoreOff;
                                            break;
                                        case BoardUI.UIData.Mode.Score:
                                            imgToggleScore.sprite = spriteScoreOn;
                                            break;
                                        default:
                                            Debug.LogError("unknown mode: " + mode);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("imgToggleScore null");
                                }
                            }
                            else
                            {
                                Debug.LogError("btnToggleScore null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("weiqi null: " + this);
                    }
                    // show or not
                    {
                        // find
                        bool isShow = true;
                        {
                            MiniGameDataUI.UIData miniGameDataUIData = this.data.findDataInParent<MiniGameDataUI.UIData>();
                            if (miniGameDataUIData != null)
                            {
                                isShow = false;
                            }
                            else
                            {
                                // Debug.LogError("miniGameDataUIData null");
                            }
                        }
                        // process
                        {
                            if (tvScore != null)
                            {
                                tvScore.gameObject.SetActive(isShow);
                            }
                            else
                            {
                                Debug.LogError("tvScore null");
                            }
                            if (btnToggleScore != null)
                            {
                                btnToggleScore.gameObject.SetActive(isShow);
                            }
                            else
                            {
                                Debug.LogError("btnToggleScore null");
                            }
                        }
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

        private WeiqiGameDataUI.UIData weiqiGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.weiqiGameDataUIData);
                }
                // Child
                {
                    uiData.weiqi.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is WeiqiGameDataUI.UIData)
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
                    // child
                    {
                        weiqiGameDataUIData.board.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is BoardUI.UIData)
                {
                    // BoardUI.UIData boardUIData = data as BoardUI.UIData;
                    {

                    }
                    dirty = true;
                    return;
                }
            }
            // Logic
            {
                if (data is Weiqi)
                {
                    Weiqi weiqi = data as Weiqi;
                    {
                        weiqi.b.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is Board)
                {
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.weiqiGameDataUIData);
                }
                // Child
                {
                    uiData.weiqi.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is WeiqiGameDataUI.UIData)
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
                    // child
                    {
                        weiqiGameDataUIData.board.allRemoveCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is BoardUI.UIData)
                {
                    // BoardUI.UIData boardUIData = data as BoardUI.UIData;
                    {

                    }
                    return;
                }
            }
            // Logic
            {
                if (data is Weiqi)
                {
                    Weiqi weiqi = data as Weiqi;
                    {
                        weiqi.b.allRemoveCallBack(this);
                    }
                    return;
                }
                if (data is Board)
                {
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
                    case UIData.Property.weiqi:
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
            // Parent
            {
                if (wrapProperty.p is WeiqiGameDataUI.UIData)
                {
                    switch ((WeiqiGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case WeiqiGameDataUI.UIData.Property.gameData:
                            break;
                        case WeiqiGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case WeiqiGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case WeiqiGameDataUI.UIData.Property.board:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case WeiqiGameDataUI.UIData.Property.information:
                            break;
                        case WeiqiGameDataUI.UIData.Property.lastMove:
                            break;
                        case WeiqiGameDataUI.UIData.Property.showHint:
                            break;
                        case WeiqiGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is BoardUI.UIData)
                {
                    switch ((BoardUI.UIData.Property)wrapProperty.n)
                    {
                        case BoardUI.UIData.Property.weiqi:
                            break;
                        case BoardUI.UIData.Property.background:
                            break;
                        case BoardUI.UIData.Property.mode:
                            dirty = true;
                            break;
                        case BoardUI.UIData.Property.boardSize:
                            break;
                        case BoardUI.UIData.Property.pieces:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Logic
            {
                if (wrapProperty.p is Weiqi)
                {
                    switch ((Weiqi.Property)wrapProperty.n)
                    {
                        case Weiqi.Property.b:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Weiqi.Property.deadgroup:
                            break;
                        case Weiqi.Property.scoreOwnerMap:
                            break;
                        case Weiqi.Property.scoreOwnerMapSize:
                            break;
                        case Weiqi.Property.scoreBlack:
                            dirty = true;
                            break;
                        case Weiqi.Property.scoreWhite:
                            dirty = true;
                            break;
                        case Weiqi.Property.dame:
                            dirty = true;
                            break;
                        case Weiqi.Property.score:
                            dirty = true;
                            break;
                        case Weiqi.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is Board)
                {
                    switch ((Board.Property)wrapProperty.n)
                    {
                        case Board.Property.size:
                            break;
                        case Board.Property.size2:
                            break;
                        case Board.Property.bits2:
                            break;
                        case Board.Property.captures:
                            dirty = true;
                            break;
                        case Board.Property.komi:
                            break;
                        case Board.Property.handicap:
                            break;
                        case Board.Property.rules:
                            break;
                        case Board.Property.moves:
                            break;
                        case Board.Property.last_move:
                            break;
                        case Board.Property.last_move2:
                            break;
                        case Board.Property.last_move3:
                            break;
                        case Board.Property.last_move4:
                            break;
                        case Board.Property.superko_violation:
                            break;
                        case Board.Property.b:
                            break;
                        case Board.Property.g:
                            break;
                        case Board.Property.pp:
                            break;
                        case Board.Property.pat3:
                            break;
                        case Board.Property.gi:
                            break;
                        case Board.Property.c:
                            break;
                        case Board.Property.clen:
                            break;
                        case Board.Property.symmetry:
                            break;
                        case Board.Property.last_ko:
                            break;
                        case Board.Property.last_ko_age:
                            break;
                        case Board.Property.ko:
                            break;
                        case Board.Property.quicked:
                            break;
                        case Board.Property.history_hash:
                            break;
                        case Board.Property.hash:
                            break;
                        case Board.Property.qhash:
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

        #region Button

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.Q:
                            {
                                if (btnToggleScore != null && btnToggleScore.gameObject.activeInHierarchy && btnToggleScore.interactable)
                                {
                                    this.onClickBtnToggleScore();
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
        public void onClickBtnToggleScore()
        {
            Debug.Log("onClickBtnToggleScore");
            if (this.data != null)
            {
                // Find BoardUI.UIData
                BoardUI.UIData boardUIData = null;
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUI = this.data.findDataInParent<WeiqiGameDataUI.UIData>();
                    if (weiqiGameDataUI != null)
                    {
                        boardUIData = weiqiGameDataUI.board.v;
                    }
                    else
                    {
                        Debug.LogError("weiqiGameDataUI null");
                    }
                }
                // Process
                if (boardUIData != null)
                {
                    switch (boardUIData.mode.v)
                    {
                        case BoardUI.UIData.Mode.Normal:
                            boardUIData.mode.v = BoardUI.UIData.Mode.Score;
                            break;
                        case BoardUI.UIData.Mode.Score:
                            boardUIData.mode.v = BoardUI.UIData.Mode.Normal;
                            break;
                        default:
                            Debug.LogError("unknown mode: " + boardUIData.mode.v + "; " + this);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("boardUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #endregion

    }
}