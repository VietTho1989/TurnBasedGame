using UnityEngine;
using System.Runtime.InteropServices;
using System.Reflection;
using System;

public class UniClipboard
{
    static IBoard _board;
    static IBoard board{
        get{
            if (_board == null) {
                #if UNITY_ANDROID && !UNITY_EDITOR
                _board = new AndroidBoard();
                #elif UNITY_IOS && !UNITY_EDITOR
                _board = new IOSBoard ();
                #else
                _board = new StandardBoard(); 
                #endif
            }
            return _board;
        }
    }

    public static void SetText(string str){
        board.SetText (str);
    }

    public static string GetText(){
        return board.GetText ();
    }
}

interface IBoard{
    void SetText(string str);
    string GetText();
}

class StandardBoard : IBoard {
    private static PropertyInfo m_systemCopyBufferProperty = null;
    private static PropertyInfo GetSystemCopyBufferProperty() {
        if (m_systemCopyBufferProperty == null) {
            Type T = typeof(GUIUtility);
            m_systemCopyBufferProperty = T.GetProperty("systemCopyBuffer", BindingFlags.Static | BindingFlags.Public);
            if (m_systemCopyBufferProperty == null)
            {
                m_systemCopyBufferProperty =
                    T.GetProperty("systemCopyBuffer", BindingFlags.Static | BindingFlags.NonPublic);
            }

            if (m_systemCopyBufferProperty == null)
            {
                throw new Exception(
                    "Can't access internal member 'GUIUtility.systemCopyBuffer' it may have been removed / renamed");
            }
        }
        return m_systemCopyBufferProperty;
    }
    public void SetText(string str) {
        PropertyInfo P = GetSystemCopyBufferProperty();
        P.SetValue(null, str, null);
    }
    public string GetText(){
        PropertyInfo P = GetSystemCopyBufferProperty();
        return (string)P.GetValue(null, null);
    }
}

#if UNITY_IOS
class IOSBoard : IBoard {
    [DllImport("__Internal")]
    static extern void SetText_ (string str);
    [DllImport("__Internal")]
    static extern string GetText_();

    public void SetText(string str){
        if (Application.platform != RuntimePlatform.OSXEditor) {
            SetText_ (str);
        }
    }

    public string GetText(){
        return GetText_();
    }
}
#endif

#if UNITY_ANDROID
class AndroidBoard : IBoard {

    AndroidJavaClass cb = new AndroidJavaClass("jp.ne.donuts.uniclipboard.Clipboard");

    public void SetText(string str){
        Debug.Log ("Set Text At AndroidBoard: " + str);
        cb.CallStatic ("setText", str);
    }

    public string GetText(){
        return cb.CallStatic<string> ("getText");
    }
}
#endif
