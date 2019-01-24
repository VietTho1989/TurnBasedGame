using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <summary>Added to a GameObject that has a Button component, it loads <see cref="sceneName"/> scene when the button is clicked</summary>
	public class LoadSceneOnClick : MonoBehaviour
	{
		/// <summary>The scene to load on click</summary>
		public string sceneName;
		//public int numScenesToSkipWhenLoadingPrevScene;
		//public int numScenesToSkipWhenLoadingNextScene;
		//public LoadMode loadMode = LoadMode.GIVEN_SCENE_NAME;


		void Start()
		{
			GetComponent<Button>().onClick.AddListener(LoadScene);
		}

		void LoadScene()
		{

			//if (loadMode == LoadMode.GIVEN_SCENE_NAME)
#if UNITY_5_3_OR_NEWER
				UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
#else
				Application.LoadLevel(sceneName);
#endif
//			else
//			{
//				int incr = loadMode == LoadMode.PREV_SCENE ? -(1 + numScenesToSkipWhenLoadingPrevScene) : 1 + numScenesToSkipWhenLoadingNextScene;
//				int numScenes;
//				int curIdx;
//#if UNITY_5_3_OR_NEWER
//				curIdx = SceneManager.GetActiveScene().buildIndex;
//				numScenes = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings
//				UnityEngine.SceneManagement.SceneManager.LoadScene(GetIdxToLoad(curIdx, numScenes, incr));
//#else
//				curIdx = Application.loadedLevel;
//				numScenes = Application.levelCount;
//				Application.LoadLevel(GetIdxToLoad(curIdx, numScenes, incr));
//#endif
//			}
		}

		int GetIdxToLoad(int curIdx, int numScenes, int incr) { return ((curIdx + numScenes) + incr) % numScenes; }


		//public enum LoadMode { GIVEN_SCENE_NAME, NEXT_SCENE, PREV_SCENE };
	}
}