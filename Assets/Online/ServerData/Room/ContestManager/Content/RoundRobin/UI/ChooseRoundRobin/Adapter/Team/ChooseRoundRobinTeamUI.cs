using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class ChooseRoundRobinTeamUI : UIBehavior<ChooseRoundRobinTeamUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> teamIndex;

            public VP<float> score;

            #region Constructor

            public enum Property
            {
                teamIndex,
                score
            }

            public UIData() : base()
            {
                this.teamIndex = new VP<int>(this, (byte)Property.teamIndex, 0);
                this.score = new VP<float>(this, (byte)Property.score, 0);
            }

            #endregion

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtTeam = new TxtLanguage("Team");
        private static readonly TxtLanguage txtScore = new TxtLanguage("Score");

        static ChooseRoundRobinTeamUI()
        {
            txtTeam.add(Language.Type.vi, "Đội");
            txtScore.add(Language.Type.vi, "Điểm");
        }

        #endregion

        #region Refresh

        public Text tvTeam;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (tvTeam != null)
                    {
                        tvTeam.text = txtTeam.get() + ": " + this.data.teamIndex.v
                            + "\t\t\t" + txtScore.get() + ": " + this.data.score.v;
                    }
                    else
                    {
                        Debug.LogError("tvTeam null");
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
                // Setting
                Setting.get().addCallBack(this);
                dirty = true;
                return;
            }
            // Child
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
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
            if(wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.teamIndex:
                        dirty = true;
                        break;
                    case UIData.Property.score:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if(wrapProperty.p is Setting)
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}