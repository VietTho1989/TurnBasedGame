using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Weiqi
{
    /**
	 * TODO UnityInitCore chay rat lau
	 * */
    public class Core
    {

        public const bool CanCorrect = true;

        #region init Core

        [DllImport(GameType.BundleName)]
        private static extern void weiqi_initCore();

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////// Native Method ///////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        #region setFileName

        [DllImport(GameType.BundleName)]
        private static extern bool weiqi_setFileName(string newSpatialDictFileName, string newPatternFileName);

        #endregion

        #region setBookPath

        [DllImport(GameType.BundleName)]
        private static extern bool weiqi_setBookPath(string newBookPath);

        #endregion

        #region makeDefaultPosition

        [DllImport(GameType.BundleName)]
        private static extern int weiqi_makeDefaultPosition(int size, float komi, int rule, int handicap, out IntPtr outWeiqiPtr);

        public static Weiqi unityMakeDefaultPosition(int size, float komi, int rule, int handicap)
        {
            // init
            unityInitCore();
            // do job
            Weiqi weiqi = new Weiqi();
            {
                // request native
                IntPtr outWeiqiPtr;
                int outWeiqiLength = weiqi_makeDefaultPosition(size, komi, rule, handicap, out outWeiqiPtr);
                // make byte array
                byte[] outWeiqiBytes = new byte[outWeiqiLength];
                {
                    Marshal.Copy(outWeiqiPtr, outWeiqiBytes, 0, outWeiqiLength);
                    Marshal.FreeHGlobal(outWeiqiPtr);
                }
                // parse
                Weiqi.parse(weiqi, outWeiqiBytes, 0);
            }
            return weiqi;
        }

        #endregion

        #region makeCustomPosition

        [DllImport(GameType.BundleName)]
        private static extern int weiqi_makeCustomPosition(int size, float komi, int rule, int[] board, int captureBlack, int captureWhite, int lastMoveColor, out IntPtr outWeiqiPtr);

        public static Weiqi unityMakeCustomPosition(int size, float komi, int rule, int[] board, int captureBlack, int captureWhite, int lastMoveColor)
        {
            // init
            unityInitCore();
            // do job
            Weiqi weiqi = new Weiqi();
            {
                // request native
                IntPtr outWeiqiPtr;
                int outWeiqiLength = weiqi_makeCustomPosition(size, komi, rule, board, captureBlack, captureWhite, lastMoveColor, out outWeiqiPtr);
                // make byte array
                byte[] outWeiqiBytes = new byte[outWeiqiLength];
                {
                    Marshal.Copy(outWeiqiPtr, outWeiqiBytes, 0, outWeiqiLength);
                    Marshal.FreeHGlobal(outWeiqiPtr);
                }
                // parse
                Weiqi.parse(weiqi, outWeiqiBytes, 0);
            }
            return weiqi;
        }

        #endregion

        #region isGameFinish

        [DllImport(GameType.BundleName)]
        private static extern int weiqi_isGameFinish(IntPtr weiqiPtr, int weiqiLength, bool canCorrect);

        public static int unityIsGameFinish(Weiqi weiqi, bool canCorrect)
        {
            if (weiqi == null)
            {
                Debug.LogError("weiqi null");
                return 0;
            }
            // init
            unityInitCore();
            // do job
            int ret = 0;
            {
                byte[] weiqiBytes = Weiqi.convertToBytes(weiqi);
                int weiqiLength = weiqiBytes.Length;
                IntPtr weiqiPtr = Marshal.AllocHGlobal(weiqiLength);
                try
                {
                    Marshal.Copy(weiqiBytes, 0, weiqiPtr, weiqiLength);
                    ret = weiqi_isGameFinish(weiqiPtr, weiqiLength, canCorrect);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(weiqiPtr);
                }
            }
            return ret;
        }

        #endregion

        #region letComputerThink

        [DllImport(GameType.BundleName)]
        private static extern int weiqi_letComputerThink(IntPtr weiqiPtr, int weiqiLength, bool canCorrect, bool canResign, bool usebook, long time, int games, int engine, out IntPtr outMovePtr);

        public static WeiqiMove unityLetComputerThink(Weiqi weiqi, bool canCorrect, bool canResign, bool usebook, long time, int games, int engine)
        {
            if (weiqi == null)
            {
                Debug.LogError("weiqi null");
                return new WeiqiMove();
            }
            // correct input
            {
                if(engine!= (int)Common.engine_id.E_RANDOM && engine!= (int)Common.engine_id.E_UCT)
                {
                    Debug.LogError("engine error: " + engine);
                    engine = (int)Common.engine_id.E_UCT;
                }
            }
            AIController.startThink();
            // init
            unityInitCore();
            firstInitBook();
            // do job
            WeiqiMove move = new WeiqiMove();
            {
                // position
                byte[] weiqiBytes = Weiqi.convertToBytes(weiqi);
                int weiqiLength = weiqiBytes.Length;
                IntPtr weiqiPtr = Marshal.AllocHGlobal(weiqiLength);
                try
                {
                    Marshal.Copy(weiqiBytes, 0, weiqiPtr, weiqiLength);
                    // request native
                    IntPtr outMovePtr;
                    int outMoveLength = weiqi_letComputerThink(weiqiPtr, weiqiLength, canCorrect, canResign, usebook, time, games, engine, out outMovePtr);
                    // set move
                    {
                        byte[] outMoveByteArray = new byte[outMoveLength];
                        {
                            Marshal.Copy(outMovePtr, outMoveByteArray, 0, outMoveLength);
                            Marshal.FreeHGlobal(outMovePtr);
                        }
                        // convert to moveByteArray to move
                        WeiqiMove.parse(move, outMoveByteArray, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(weiqiPtr);
                }
            }
            AIController.startEnd();
            return move;
        }

        #endregion

        #region isLegalMove

        [DllImport(GameType.BundleName)]
        private static extern bool weiqi_isLegalMove(IntPtr weiqiPtr, int weiqiLength, bool canCorrect, IntPtr movePtr, int moveLength);

        public static bool unityIsLegalMove(Weiqi weiqi, bool canCorrect, WeiqiMove move)
        {
            if (weiqi == null)
            {
                Debug.LogError("weiqi null");
                return false;
            }
            // init
            unityInitCore();
            // do job
            bool ret = false;
            {
                // position
                byte[] weiqiBytes = Weiqi.convertToBytes(weiqi);
                int weiqiLength = weiqiBytes.Length;
                IntPtr weiqiPtr = Marshal.AllocHGlobal(weiqiLength);
                // move
                byte[] moveBytes = WeiqiMove.convertToBytes(move);
                int moveLength = moveBytes.Length;
                IntPtr movePtr = Marshal.AllocHGlobal(moveLength);
                try
                {
                    Marshal.Copy(weiqiBytes, 0, weiqiPtr, weiqiLength);
                    Marshal.Copy(moveBytes, 0, movePtr, moveLength);
                    ret = weiqi_isLegalMove(weiqiPtr, weiqiLength, canCorrect, movePtr, moveLength);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(weiqiPtr);
                    Marshal.FreeHGlobal(movePtr);
                }
                // Debug.Log ("isLegalMove: " + ret + "; " + move.color.v + "; " + move.coord.v);
            }
            return ret;
        }

        #endregion

        #region doMove

        [DllImport(GameType.BundleName)]
        private static extern int weiqi_doMove(IntPtr weiqiPtr, int weiqiLength, bool canCorrect, IntPtr movePtr, int moveLength, bool needUpdateScore, out IntPtr outWeiqiPtr);

        public static Weiqi unityDoMove(Weiqi weiqi, bool canCorrect, WeiqiMove move, bool needUpdateScore)
        {
            if (weiqi == null)
            {
                Debug.LogError("weiqi null");
                return new Weiqi();
            }
            // init
            unityInitCore();
            // do job
            Weiqi newWeiqi = new Weiqi();
            {
                // make parameter position
                byte[] weiqiBytes = Weiqi.convertToBytes(weiqi);
                int weiqiLength = weiqiBytes.Length;
                IntPtr weiqiPtr = Marshal.AllocHGlobal(weiqiLength);
                // make parameter move
                byte[] moveBytes = WeiqiMove.convertToBytes(move);
                int moveLength = moveBytes.Length;
                IntPtr movePtr = Marshal.AllocHGlobal(moveLength);
                // do move
                try
                {
                    Marshal.Copy(weiqiBytes, 0, weiqiPtr, weiqiLength);
                    Marshal.Copy(moveBytes, 0, movePtr, moveLength);
                    // find outRet
                    IntPtr outWeiqiPtr;
                    int outWeiqiLength = weiqi_doMove(weiqiPtr, weiqiLength, canCorrect, movePtr, moveLength, needUpdateScore, out outWeiqiPtr);
                    // process result
                    {
                        byte[] outWeiqiBytes = new byte[outWeiqiLength];
                        {
                            Marshal.Copy(outWeiqiPtr, outWeiqiBytes, 0, outWeiqiLength);
                            Marshal.FreeHGlobal(outWeiqiPtr);
                        }
                        // update
                        Weiqi.parse(newWeiqi, outWeiqiBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(weiqiPtr);
                    Marshal.FreeHGlobal(movePtr);
                }
            }
            return newWeiqi;
        }

        #endregion

        #region UpdateScore

        [DllImport(GameType.BundleName)]
        private static extern int weiqi_updateScore(IntPtr weiqiPtr, int weiqiLength, bool canCorrect, out IntPtr outWeqiPtr);

        public static Weiqi unityUpdateScore(Weiqi weiqi, bool canCorrect)
        {
            if (weiqi == null)
            {
                Debug.LogError("weiqi null");
                return new Weiqi();
            }
            // init
            unityInitCore();
            // do job
            Weiqi newWeiqi = new Weiqi();
            {
                // make parameter position
                byte[] weiqiBytes = Weiqi.convertToBytes(weiqi);
                int weiqiLength = weiqiBytes.Length;
                IntPtr weiqiPtr = Marshal.AllocHGlobal(weiqiLength);
                // do move
                try
                {
                    Marshal.Copy(weiqiBytes, 0, weiqiPtr, weiqiLength);
                    // find outRet
                    IntPtr outWeiqiPtr;
                    int outWeiqiLength = weiqi_updateScore(weiqiPtr, weiqiLength, canCorrect, out outWeiqiPtr);
                    // process result
                    {
                        byte[] outWeiqiBytes = new byte[outWeiqiLength];
                        {
                            Marshal.Copy(outWeiqiPtr, outWeiqiBytes, 0, outWeiqiLength);
                            Marshal.FreeHGlobal(outWeiqiPtr);
                        }
                        // update
                        Weiqi.parse(newWeiqi, outWeiqiBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(weiqiPtr);
                }
            }
            return newWeiqi;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////// init core ///////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        private static bool isAlreadyInit = false;

        private static System.Object lockThis = new System.Object();

        private static string spatialDictFileName = "";

        private static string patternFileName = "";

        public static void setNewFile(string newSpatialDictFileName, string newPatternFileName)
        {
            lock (lockThis)
            {
                if (!spatialDictFileName.Equals(newSpatialDictFileName))
                {
                    spatialDictFileName = newSpatialDictFileName;
                    isAlreadyInit = false;
                }
                if (!patternFileName.Equals(newPatternFileName))
                {
                    patternFileName = newPatternFileName;
                    isAlreadyInit = false;
                }
            }
        }

        private static void unityInitCore()
        {
            lock (lockThis)
            {
                if (!isAlreadyInit)
                {
                    isAlreadyInit = true;
                    weiqi_initCore();
                    // set file
                    {
#if UNITY_STANDALONE_OSX
                        {

                        }
#elif UNITY_IPHONE
						{

						}
#elif UNITY_ANDROID
						{
							
						}
#endif
                    }
                }
                else
                {
                    // Debug.LogError ("already init core");
                }
            }
        }

        #region first init book

        private static bool isAlreadyInitBook = false;

        private static System.Object lockBook = new System.Object();

        private static void firstInitBook()
        {
            lock (lockBook)
            {
                if (!isAlreadyInitBook)
                {
                    isAlreadyInitBook = true;
                    // set book
                    {
                        weiqi_setFileName(string.IsNullOrEmpty(spatialDictFileName) ? GameType.MakeCorePath(GameType.NotAlwaysIn, "weiqi", "patterns.spat") : spatialDictFileName,
                               string.IsNullOrEmpty(patternFileName) ? GameType.MakeCorePath(GameType.NotAlwaysIn, "weiqi", "patterns.prob") : patternFileName);
                        weiqi_setBookPath(GameType.MakeCorePath(GameType.AlwaysIn, "weiqi", "book.dat"));

                        /*#if UNITY_EDITOR
                                                {
                                                    weiqi_setFileName(string.IsNullOrEmpty(spatialDictFileName) ? Global.DataPath + "/Plugins/Android/assets/" + GameType.NotAlwaysIn + "/weiqi/patterns.spat" : spatialDictFileName,
                                                        string.IsNullOrEmpty(patternFileName) ? Global.DataPath + "/Plugins/Android/assets/" + GameType.NotAlwaysIn + "/weiqi/patterns.prob" : patternFileName);
                                                    weiqi_setBookPath(Global.DataPath + "/Plugins/Android/assets/" + GameType.AlwaysIn + "/weiqi/book.dat");
                                                }
                        #elif UNITY_STANDALONE_OSX
                                                {
                                                    weiqi_setFileName(string.IsNullOrEmpty(spatialDictFileName) ? Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.NotAlwaysIn + "/weiqi/patterns.spat" : spatialDictFileName,
                                                        string.IsNullOrEmpty(patternFileName) ? Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.NotAlwaysIn + "/weiqi/patterns.prob" : patternFileName);
                                                    weiqi_setBookPath(Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.AlwaysIn + "/weiqi/book.dat");
                                                }
                        #elif UNITY_IPHONE
                                                {
                                                    weiqi_setFileName(string.IsNullOrEmpty(spatialDictFileName) ? Global.DataPath+ "/"+GameType.NotAlwaysIn+"/weiqi/patterns.spat" : spatialDictFileName, 
                                                        string.IsNullOrEmpty(patternFileName) ? Global.DataPath+ "/"+GameType.NotAlwaysIn+"/weiqi/patterns.prob" : patternFileName);
                                                    weiqi_setBookPath(Global.DataPath+ "/"+GameType.AlwaysIn+"/weiqi/book.dat");
                                                }
                        #elif UNITY_ANDROID
                                                {
                                                    weiqi_setFileName(string.IsNullOrEmpty(spatialDictFileName) ? GameType.NotAlwaysIn+ "/weiqi/patterns.spat" : spatialDictFileName, 
                                                        string.IsNullOrEmpty(patternFileName) ? GameType.NotAlwaysIn+"/weiqi/patterns.prob" : patternFileName);
                                                    weiqi_setBookPath(GameType.AlwaysIn + "/weiqi/book.dat");
                                                }
                        #endif*/
                    }
                }
                else
                {
                    // Debug.LogError ("already init core");
                }
            }
        }

        #endregion

    }
}