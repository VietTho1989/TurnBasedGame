using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

public class Startup : AssetPostprocessor
{

	/*static Startup()
	{
		
	}*/

	[UnityEditor.Callbacks.DidReloadScripts]
	static void OnScriptsReloaded()
	{
		/*bool needSave = false;
		string[] assetsPaths = AssetDatabase.GetAllAssetPaths ();
		foreach (string assetPath in assetsPaths) {
			if (assetPath.Contains (".prefab")) {  
				GameObject rootPrefab = AssetDatabase.LoadAssetAtPath<GameObject> (assetPath);
				if (rootPrefab != null) {
					TrashMan.DespawnInterface[] despawnInterfaces = rootPrefab.GetComponents<TrashMan.DespawnInterface>();
					if (despawnInterfaces.Length > 0) {
						bool haveDirty = false;
						for (int i = 0; i < despawnInterfaces.Length; i++) {
							// Debug.Log ("despawnInterface update: " + despawnInterfaces [i] + "; " + rootPrefab.GetInstanceID ());
							TrashMan.DespawnInterface despawnInterface = despawnInterfaces[i];
							int instanceId = rootPrefab.GetInstanceID();
							if (despawnInterface.getInstanceId () != instanceId) {
								despawnInterface.setInstanceId (instanceId);
								haveDirty = true;
							}
						}
						if (haveDirty) {
							needSave = true;
							EditorUtility.SetDirty (rootPrefab);
						} else {
							// Debug.Log ("Don't have dirty: " + rootPrefab);
						}
					}
				} else {
					Debug.LogError ("rootPrefab null: " + assetPath);
				}
			}
		}
		if (needSave) {
			AssetDatabase.SaveAssets ();
		} else {
			// Debug.Log ("Don't need save");
		}*/
	}
}

#endif