using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#if UNITY_IPHONE 
	using UnityEditor.iOS.Xcode;
#endif 

public class MyBuildPostprocessor {

	/*[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path) {
		// Debug.LogError ("OnPostProcessBuild: " + buildTarget + "; " + path);
		#if UNITY_IPHONE 
		if (buildTarget == BuildTarget.iOS) {
			string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject proj = new PBXProject();
			proj.ReadFromString(File.ReadAllText(projPath));

			string target = proj.TargetGuidByName("Unity-iPhone");
			// BOOK.DAT for ChineseChess
			{
				if (!File.Exists (Path.Combine (path, "Data/BOOK.DAT"))) {
					File.Copy ("Plugins/Android/assets/AlwaysIn/Xiangqi/BOOK.DAT", Path.Combine (path, "Data/BOOK.DAT"));
				} else {
					Debug.LogError ("Already exist file");
				}
				proj.AddFileToBuild(target, proj.AddFile("Data/BOOK.DAT", "Data/BOOK.DAT", PBXSourceTree.Source));
			}
			// Add folder
			{
				// AlwaysIn
				if (!File.Exists (Path.Combine (path, "Data/AlwaysIn"))) {
					File.Copy ("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCore/Resources/AlwaysIn", Path.Combine (path, "Data/AlwaysIn"));
				} else {
					Debug.LogError ("Already exist file");
				}
				if (!File.Exists (Path.Combine (path, "Data/NotAlwaysIn"))) {
					File.Copy ("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCore/Resources/NotAlwaysIn", Path.Combine (path, "Data/NotAlwaysIn"));
				} else {
					Debug.LogError ("Already exist file");
				}
				// proj.AddFolderReference(path, "/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCore/Resources/AlwaysIn");
				// proj.AddFolderReference(path, "/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCore/Resources/NotAlwaysIn");
			}
			// proj.AddFolderReference ("Resources", "");
			File.WriteAllText(projPath, proj.WriteToString());
		}
		#endif 
	}*/
}

