using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class TeamResultUI : UIBehavior<TeamResultUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<TeamResult>> teamResult;

            #region Constructor

            public enum Property
            {
                teamResult
            }

            public UIData() : base()
            {
                this.teamResult = new VP<ReferenceData<TeamResult>>(this, (byte)Property.teamResult, new ReferenceData<TeamResult>(null));
            }

            #endregion

        }

        #endregion

        #region txt

        public Text tvTeam;
        private static readonly TxtLanguage txtTeam = new TxtLanguage();

        public Text tvScore;
        private static readonly TxtLanguage txtScore = new TxtLanguage();

        static TeamResultUI()
        {
            txtTeam.add(Language.Type.vi, "Đội");
            txtScore.add(Language.Type.vi, "Điểm");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    TeamResult teamResult = this.data.teamResult.v.data;
                    if (teamResult != null)
                    {
                        if (tvTeam != null)
                        {
                            tvTeam.text = txtTeam.get("Team") + ": " + teamResult.teamIndex.v;
                        }
                        else
                        {
                            Debug.LogError("tvTeam null");
                        }
                        if (tvScore != null)
                        {
                            tvScore.text = txtScore.get("Score") + ": " + teamResult.score.v;
                        }
                        else
                        {
                            Debug.LogError("tvScore null");
                        }
                    }
                    else
                    {
                        Debug.LogError("teamResult null");
                    }
                }
                else
                {
                    Debug.LogError("data null");
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
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.teamResult.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            if(data is TeamResult)
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
                    uiData.teamResult.allRemoveCallBack(this);
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
            if (data is TeamResult)
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
                    case UIData.Property.teamResult:
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
                    case Setting.Property.defaultChosenGame:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is TeamResult)
            {
                switch ((TeamResult.Property)wrapProperty.n)
                {
                    case TeamResult.Property.teamIndex:
                        dirty = true;
                        break;
                    case TeamResult.Property.score:
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