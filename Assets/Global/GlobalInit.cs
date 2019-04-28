using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using FileSystem;
using GameManager.Match.Swap;

public class GlobalInit : MonoBehaviour
{

    void Awake()
    {
        // Global.DataPath = Application.dataPath;

        // Transport.layer = new LLAPITransport();

        // MakeIdentity
        {
            // DataMakeIdentityUtils.makeIdentity(typeof(SwapPlayerMessage));
        }

        // Set AssetManager
        {
#if UNITY_ANDROID
			{
				// Get activity
				AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
				// Call method
				{
					AndroidJavaClass ajc = new AndroidJavaClass("turnbase.mdc.com.unitynativeplugin.Plugin");
					string ret = ajc.CallStatic<string>("SetAssetManagerForNative", jo);
					Debug.LogError("setAssetManagerForNative: "+ret);
				}
			}
#endif
        }

    }

    void Start()
    {
        // NativeCore
        /*{
            // var watch = System.Diagnostics.Stopwatch.StartNew();
            {
                // TODO Tai sao phai them vao nhi, ko the hieu noi?
                Chess.Core.unityInitCore();
                Shatranj.Core.unityInitCore();
                Makruk.Core.unityInitCore();
                Seirawan.Core.unityInitCore();
                FairyChess.Core.unityInitCore();
                RussianDraught.Core.unityInitCore();

                EnglishDraught.Core.unityInitCore();
                InternationalDraught.Core.unityInitCore();
                RussianDraught.Core.unityInitCore();

                MineSweeper.Core.unityInitCore();

                Reversi.Core.firstInitCore();
                Shogi.Core.unityInitCore();
                Khet.Core.unityInitCore();
            }
            // watch.Stop();
            // var elapsedMs = watch.ElapsedMilliseconds;
            // Debug.Log ("Init Update: " + elapsedMs + "; " + this);
        }*/
        // create folder Save
        {
            try
            {
                string path = Path.Combine(Application.persistentDataPath, FileSystemBrowser.SaveFolder);
                Directory.CreateDirectory(path);
            }
            catch (System.Exception e)
            {
                Debug.LogError("create folder save error: " + e);
            }
        }
        // create folder database
        {
            try
            {
                string path = Path.Combine(Application.persistentDataPath, FileSystemBrowser.DatabaseFolder);
                Directory.CreateDirectory(path);
            }
            catch (System.Exception e)
            {
                Debug.LogError("create folder database error: " + e);
            }
        }
    }

}