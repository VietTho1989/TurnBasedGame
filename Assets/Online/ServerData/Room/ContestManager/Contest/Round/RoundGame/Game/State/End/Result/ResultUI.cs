using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public class ResultUI : UIBehavior<ResultUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Result>> result;

            #region Constructor

            public enum Property
            {
                result
            }

            public UIData() : base()
            {
                this.result = new VP<ReferenceData<Result>>(this, (byte)Property.result, new ReferenceData<Result>(null));
            }

            #endregion

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtNone = new TxtLanguage("Result: game not end");
        private static readonly TxtLanguage txtRequestDraw = new TxtLanguage("Draw: players request");
        private static readonly TxtLanguage txtGameDraw = new TxtLanguage("Draw: game draw");
        private static readonly TxtLanguage txtCheckMate = new TxtLanguage("Win: checkmate");
        private static readonly TxtLanguage txtCheckMated = new TxtLanguage("Lose: checkmated");
        private static readonly TxtLanguage txtTimeOut = new TxtLanguage("Lose: timeout");
        private static readonly TxtLanguage txtEnemyTimeOut = new TxtLanguage("Win: enemy timeout");
        private static readonly TxtLanguage txtSurrender = new TxtLanguage("Lose: surrender");
        private static readonly TxtLanguage txtEnemySurrender = new TxtLanguage("Win: enemy surrender");

        static ResultUI()
        {
            txtNone.add(Language.Type.vi, "Kết quả: chưa kết thúc");
            txtRequestDraw.add(Language.Type.vi, "Hoà: thoả thuận");
            txtGameDraw.add(Language.Type.vi, "Ván đấu hoà");
            txtCheckMate.add(Language.Type.vi, "Thắng: chiếu hết");
            txtCheckMated.add(Language.Type.vi, "Thua: chiếu hết");
            txtTimeOut.add(Language.Type.vi, "Thua: hết giờ");
            txtEnemyTimeOut.add(Language.Type.vi, "Thắng: hết giờ");
            txtSurrender.add(Language.Type.vi, "Thua: bỏ cuộc");
            txtEnemySurrender.add(Language.Type.vi, "Thắng: bỏ cuộc");
        }

        #endregion

        #region Refresh

        public Text tvResult;

        private static readonly Color normalColor = new Color(50 / 255.0f, 50 / 255.0f, 50 / 255.0f);
        private static readonly Color endColor = new Color(0f, 0f, 1f);

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Result result = this.data.result.v.data;
                    if (result != null)
                    {
                        // tvResult
                        if (tvResult != null)
                        {
                            // tvResult.text = result.score.v + "; " + result.reason.v;
                            // txt
                            switch (result.reason.v)
                            {
                                case Result.Reason.None:
                                    tvResult.text = txtNone.get();
                                    break;
                                case Result.Reason.RequestDraw:
                                    tvResult.text = txtRequestDraw.get();
                                    break;
                                case Result.Reason.GameDraw:
                                    tvResult.text = txtGameDraw.get();
                                    break;
                                case Result.Reason.CheckMate:
                                    tvResult.text = txtCheckMate.get();
                                    break;
                                case Result.Reason.CheckMated:
                                    tvResult.text = txtCheckMated.get();
                                    break;
                                case Result.Reason.TimeOut:
                                    tvResult.text = txtTimeOut.get();
                                    break;
                                case Result.Reason.EnemyTimeOut:
                                    tvResult.text = txtEnemyTimeOut.get();
                                    break;
                                case Result.Reason.Surrender:
                                    tvResult.text = txtSurrender.get();
                                    break;
                                case Result.Reason.EnemySurrender:
                                    tvResult.text = txtEnemySurrender.get();
                                    break;
                                default:
                                    Debug.LogError("unknown reason: " + result.reason.v);
                                    tvResult.text = result.score.v + "; " + result.reason.v;
                                    break;
                            }
                            // color
                            tvResult.color = (result.reason.v == Result.Reason.None) ? normalColor : endColor;
                        }
                        else
                        {
                            Debug.LogError("tvResult null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("result null: " + this);
                        // tvResult
                        if (tvResult != null)
                        {
                            tvResult.text = txtNone.get();
                            tvResult.color = normalColor;
                        }
                        else
                        {
                            Debug.LogError("tvResult null: " + this);
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
                    uiData.result.allAddCallBack(this);
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
            if (data is Result)
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
                    uiData.result.allRemoveCallBack(this);
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
            if (data is Result)
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
                    case UIData.Property.result:
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
                    case Setting.Property.style:
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
            if (wrapProperty.p is Result)
            {
                switch ((Result.Property)wrapProperty.n)
                {
                    case Result.Property.playerIndex:
                        dirty = true;
                        break;
                    case Result.Property.score:
                        dirty = true;
                        break;
                    case Result.Property.reason:
                        dirty = true;
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

    }
}