using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace Posture
{
    public class ChoosePostureUpdate : UpdateBehavior<ChoosePostureUI.UIData>
    {

        #region Rountine Load Data

        private Routine loadData;

        public IEnumerator TaskLoadData()
        {
            if (this.data != null)
            {
                // Load Data
                List<PostureGameData> postureGameDatas = new List<PostureGameData>();
                {
                    int count = 0;
                    switch (this.data.gameType.v)
                    {
                        case GameType.Type.CHESS:
                            {

                            }
                            break;
                        case GameType.Type.Xiangqi:
                            {
                                TextAsset textAsset = Resources.Load<TextAsset>("XiangqiPostures");
                                if (textAsset != null && textAsset.text != null)
                                {
                                    Debug.LogError("posture text: " + textAsset.text);
                                    string[] txtPostures = textAsset.text.Split(System.Environment.NewLine.ToCharArray());
                                    for (int i = 0; i < txtPostures.Length; i += 2)
                                    {
                                        if (i >= 0 && i < txtPostures.Length && i + 1 >= 0 && i + 1 < txtPostures.Length)
                                        {
                                            string postureName = txtPostures[i];
                                            string fen = txtPostures[i + 1];
                                            // Make new PostureGameData
                                            {
                                                PostureGameData postureGameData = new PostureGameData();
                                                {
                                                    // index
                                                    postureGameData.postureIndex.v = postureGameDatas.Count;
                                                    // name
                                                    postureGameData.name.v = postureName;
                                                    // gameData
                                                    {
                                                        GameData gameData = new GameData();
                                                        {
                                                            Xiangqi.Xiangqi xiangqi = Xiangqi.Core.unityMakePositionByFen(fen);
                                                            {
                                                                xiangqi.uid = gameData.gameType.makeId();
                                                            }
                                                            gameData.gameType.v = xiangqi;
                                                        }
                                                        postureGameData.gameData.v = gameData;
                                                    }
                                                }
                                                postureGameDatas.Add(postureGameData);
                                                {
                                                    count++;
                                                    if (count >= 20)
                                                    {
                                                        count = 0;
                                                        yield return null;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("index error: " + i);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("load xiangqi error");
                                }
                            }
                            break;
                        case GameType.Type.SHOGI:
                            break;
                        case GameType.Type.ROCK_SCISSOR_PAPER:
                            break;
                        default:
                            Debug.LogError("unknown gameType: " + this.data.gameType.v);
                            break;
                    }
                }
                // Process
                {
                    if (this.data.state.v == ChoosePostureUI.UIData.State.Loading)
                    {
                        if (postureGameDatas != null)
                        {
                            Debug.LogError("postureGameDatas count: " + postureGameDatas.Count);
                            int count = 0;
                            for (int i = 0; i < postureGameDatas.Count; i++)
                            {
                                PostureGameData postureGameData = postureGameDatas[i];
                                {
                                    postureGameData.uid = this.data.gameDatas.makeId();
                                }
                                this.data.gameDatas.add(postureGameData);
                                {
                                    count++;
                                    if (count >= 20)
                                    {
                                        count = 0;
                                        yield return null;
                                    }
                                    // yield return new Wait (0.005f);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("Why postureGameDatas null");
                        }
                        // Change state
                        this.data.state.v = ChoosePostureUI.UIData.State.Show;
                    }
                    else
                    {
                        Debug.LogError("Why wrong state: " + this.data.state.v);
                    }
                }
            }
            else
            {
                Debug.LogError("loadPostureData null");
            }
            yield return null;
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(loadData);
            }
            return ret;
        }

        #endregion

        #region Update

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnRefresh()
        {
            Debug.LogError("onClickBtnRefresh");
            if (this.data != null)
            {
                if (this.data.state.v == ChoosePostureUI.UIData.State.Show)
                {
                    this.data.state.v = ChoosePostureUI.UIData.State.Load;
                }
            }
        }

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // Remove gameData with wrong gameType
                    for (int i = this.data.gameDatas.vs.Count - 1; i >= 0; i--)
                    {
                        PostureGameData postureGameData = this.data.gameDatas.vs[i];
                        if (postureGameData.gameData.v.gameType.v.getType() != this.data.gameType.v)
                        {
                            Debug.LogError("remove wrong gameData: " + postureGameData);
                            this.data.gameDatas.remove(postureGameData);
                        }
                    }
                    // State
                    switch (this.data.state.v)
                    {
                        case ChoosePostureUI.UIData.State.None:
                            {
                                destroyRoutine(loadData);
                                this.data.state.v = ChoosePostureUI.UIData.State.Load;
                            }
                            break;
                        case ChoosePostureUI.UIData.State.Load:
                            {
                                destroyRoutine(loadData);
                                this.data.state.v = ChoosePostureUI.UIData.State.Loading;
                            }
                            break;
                        case ChoosePostureUI.UIData.State.Loading:
                            {
                                // start coroutine load
                                if (Routine.IsNull(loadData))
                                {
                                    loadData = CoroutineManager.StartCoroutine(TaskLoadData(), this.gameObject);
                                }
                                else
                                {
                                    Debug.LogError("Why loadGame != null");
                                }
                            }
                            break;
                        case ChoosePostureUI.UIData.State.Show:
                            {
                                destroyRoutine(loadData);
                            }
                            break;
                        default:
                            Debug.LogError("unknown state: " + this.data.state.v);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("loadPostureData null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return false;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChoosePostureUI.UIData)
            {
                ChoosePostureUI.UIData loadPostureData = data as ChoosePostureUI.UIData;
                // Child
                {
                    loadPostureData.gameDatas.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is PostureGameData)
                {
                    PostureGameData postureGameData = data as PostureGameData;
                    // Child
                    {
                        postureGameData.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is GameData)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is ChoosePostureUI.UIData)
            {
                ChoosePostureUI.UIData loadPostureData = data as ChoosePostureUI.UIData;
                // Child
                {
                    loadPostureData.gameDatas.allRemoveCallBack(this);
                }
                this.setDataNull(loadPostureData);
                return;
            }
            // Child
            {
                if (data is PostureGameData)
                {
                    PostureGameData postureGameData = data as PostureGameData;
                    // Child
                    {
                        postureGameData.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is GameData)
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
            if (wrapProperty.p is ChoosePostureUI.UIData)
            {
                switch ((ChoosePostureUI.UIData.Property)wrapProperty.n)
                {
                    case ChoosePostureUI.UIData.Property.state:
                        dirty = true;
                        break;
                    case ChoosePostureUI.UIData.Property.gameType:
                        {
                            dirty = true;
                            if (this.data != null)
                            {
                                this.data.state.v = ChoosePostureUI.UIData.State.Load;
                            }
                            else
                            {
                                Debug.LogError("data null: " + this);
                            }
                        }
                        break;
                    case ChoosePostureUI.UIData.Property.gameDatas:
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
                if (wrapProperty.p is PostureGameData)
                {
                    switch ((PostureGameData.Property)wrapProperty.n)
                    {
                        case PostureGameData.Property.name:
                            break;
                        case PostureGameData.Property.gameData:
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
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            dirty = true;
                            break;
                        case GameData.Property.useRule:
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
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        static void WriteString(string txt)
        {
            string path = "Assets/Resources/XiangqiPostures.txt";
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.Write(txt);
            writer.Close();
        }
    }

}