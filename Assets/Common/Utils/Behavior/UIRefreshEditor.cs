using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(UIRefresh))]
public class UIRefreshEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Refresh Prefab Id"))
        {   
            TrashMan.DespawnInterface despawnInterface = Selection.activeGameObject.GetComponent(typeof(TrashMan.DespawnInterface)) as TrashMan.DespawnInterface;
            if(despawnInterface!=null)
            {
                int instanceId = this.GetInstanceID();
                despawnInterface.setInstanceId(instanceId);
            }
            else
            {
                Debug.LogError("despawnInterface null");
            }
        }

        if (GUI.changed)
            EditorUtility.SetDirty(this);

    }

}