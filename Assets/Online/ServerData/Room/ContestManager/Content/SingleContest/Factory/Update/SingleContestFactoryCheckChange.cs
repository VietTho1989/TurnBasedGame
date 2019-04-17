using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class SingleContestFactoryCheckChange<K> : Data, ValueChangeCallBack where K : Data
    {

        public VP<int> change;

        private void notifyChange()
        {
            this.change.v = this.change.v + 1;
        }

        #region Constructor

        public enum Property
        {
            change
        }

        public SingleContestFactoryCheckChange() : base()
        {
            this.change = new VP<int>(this, (byte)Property.change, 0);
        }

        #endregion

        public K data;

        public void setData(K newData)
        {
            if (this.data != newData)
            {
                // remove old
                {
                    DataUtils.removeParentCallBack(this.data, this, ref this.singleContestFactory);
                }
                // set new 
                {
                    this.data = newData;
                    DataUtils.addParentCallBack(this.data, this, ref this.singleContestFactory);
                }
            }
            else
            {
                Debug.LogError("the same: " + this + ", " + data + ", " + newData);
            }
        }

        #region implement callBacks

        private SingleContestFactory singleContestFactory = null;

        public void onAddCallBack<T>(T data) where T : Data
        {
            if (data is SingleContestFactory)
            {
                SingleContestFactory singleContestContentFactory = data as SingleContestFactory;
                // Child
                {
                    singleContestContentFactory.roundFactory.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            // Child
            {
                if (data is RoundFactory)
                {
                    RoundFactory roundFactory = data as RoundFactory;
                    // Child
                    {
                        switch (roundFactory.getType())
                        {
                            case RoundFactory.Type.Normal:
                                {
                                    NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                    normalRoundFactory.gameFactory.allAddCallBack(this);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                break;
                        }
                    }
                    this.notifyChange();
                    return;
                }
                // Child
                {
                    if (data is GameFactory)
                    {
                        GameFactory gameFactory = data as GameFactory;
                        // Child
                        {
                            gameFactory.gameDataFactory.allAddCallBack(this);
                        }
                        this.notifyChange();
                        return;
                    }
                    // Child
                    {
                        if (data is GameDataFactory)
                        {
                            GameDataFactory gameDataFactory = data as GameDataFactory;
                            // Child
                            {
                                switch (gameDataFactory.getType())
                                {
                                    case GameDataFactory.Type.Default:
                                        break;
                                    case GameDataFactory.Type.Posture:
                                        {
                                            PostureGameDataFactory postureGameDataFactory = gameDataFactory as PostureGameDataFactory;
                                            postureGameDataFactory.gameData.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                        break;
                                }
                            }
                            this.notifyChange();
                            return;
                        }
                        // Child
                        if (data is GameData)
                        {
                            this.notifyChange();
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
        {
            if (data is SingleContestFactory)
            {
                SingleContestFactory singleContestFactory = data as SingleContestFactory;
                // Child
                {
                    singleContestFactory.roundFactory.allRemoveCallBack(this);
                }
                this.singleContestFactory = null;
                return;
            }
            // Child
            {
                if (data is RoundFactory)
                {
                    RoundFactory roundFactory = data as RoundFactory;
                    // Child
                    {
                        switch (roundFactory.getType())
                        {
                            case RoundFactory.Type.Normal:
                                {
                                    NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                    normalRoundFactory.gameFactory.allRemoveCallBack(this);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // Child
                {
                    if (data is GameFactory)
                    {
                        GameFactory gameFactory = data as GameFactory;
                        // Child
                        {
                            gameFactory.gameDataFactory.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is GameDataFactory)
                        {
                            GameDataFactory gameDataFactory = data as GameDataFactory;
                            // Child
                            {
                                switch (gameDataFactory.getType())
                                {
                                    case GameDataFactory.Type.Default:
                                        break;
                                    case GameDataFactory.Type.Posture:
                                        {
                                            PostureGameDataFactory postureGameDataFactory = gameDataFactory as PostureGameDataFactory;
                                            postureGameDataFactory.gameData.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (data is GameData)
                        {
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is SingleContestFactory)
            {
                switch ((SingleContestFactory.Property)wrapProperty.n)
                {
                    case SingleContestFactory.Property.playerPerTeam:
                        this.notifyChange();
                        break;
                    case SingleContestFactory.Property.roundFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
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
                if (wrapProperty.p is RoundFactory)
                {
                    RoundFactory roundFactory = wrapProperty.p as RoundFactory;
                    // Child
                    {
                        switch (roundFactory.getType())
                        {
                            case RoundFactory.Type.Normal:
                                {
                                    switch ((NormalRoundFactory.Property)wrapProperty.n)
                                    {
                                        case NormalRoundFactory.Property.gameFactory:
                                            {
                                                ValueChangeUtils.replaceCallBack(this, syncs);
                                                this.notifyChange();
                                            }
                                            break;
                                        case NormalRoundFactory.Property.isChangeSideBetweenRound:
                                            break;
                                        case NormalRoundFactory.Property.isSwitchPlayer:
                                            break;
                                        case NormalRoundFactory.Property.isDifferentInTeam:
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GameFactory)
                    {
                        switch ((GameFactory.Property)wrapProperty.n)
                        {
                            case GameFactory.Property.timeControl:
                                break;
                            case GameFactory.Property.gameDataFactory:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    this.notifyChange();
                                }
                                break;
                            case GameFactory.Property.useRule:
                                break;
                            case GameFactory.Property.blindFold:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is GameDataFactory)
                        {
                            GameDataFactory gameDataFactory = wrapProperty.p as GameDataFactory;
                            // Child
                            {
                                switch (gameDataFactory.getType())
                                {
                                    case GameDataFactory.Type.Default:
                                        {
                                            switch ((DefaultGameDataFactory.Property)wrapProperty.n)
                                            {
                                                case DefaultGameDataFactory.Property.defaultGameType:
                                                    this.notifyChange();
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    case GameDataFactory.Type.Posture:
                                        {
                                            switch ((PostureGameDataFactory.Property)wrapProperty.n)
                                            {
                                                case PostureGameDataFactory.Property.gameData:
                                                    {
                                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                                        this.notifyChange();
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is GameData)
                        {
                            switch ((GameData.Property)wrapProperty.n)
                            {
                                case GameData.Property.gameType:
                                    this.notifyChange();
                                    break;
                                case GameData.Property.useRule:
                                    break;
                                case GameData.Property.requestChangeUseRule:
                                    break;
                                case GameData.Property.blindFold:
                                    break;
                                case GameData.Property.requestChangeBlindFold:
                                    break;
                                case GameData.Property.turn:
                                    break;
                                case GameData.Property.timeControl:
                                    break;
                                case GameData.Property.lastMove:
                                    break;
                                case GameData.Property.state:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}