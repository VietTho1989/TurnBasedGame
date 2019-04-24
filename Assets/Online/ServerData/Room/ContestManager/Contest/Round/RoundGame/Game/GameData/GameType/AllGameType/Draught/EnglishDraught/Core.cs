using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace EnglishDraught
{
    public class Core
    {

        public const bool CanCorrect = true;

        #region makeDefaultPosition

        [DllImport(GameType.BundleName)]
        private static extern int english_draught_makeDefaultPosition(string englishDraughtFen, int maxPly, out IntPtr outEnglishDraughtPtr);

        public static EnglishDraught unityMakeDefaultPosition(string englishDraughtFen, int maxPly)
        {
            // init
            unityInitCore();
            // do job
            EnglishDraught englishDraught = new EnglishDraught();
            {
                // request native
                IntPtr outEnglishDraughtPtr;
                int outEnglishDraughtLength = english_draught_makeDefaultPosition(englishDraughtFen, maxPly, out outEnglishDraughtPtr);
                // make byte array
                byte[] outEnglishDraughtBytes = new byte[outEnglishDraughtLength];
                {
                    Marshal.Copy(outEnglishDraughtPtr, outEnglishDraughtBytes, 0, outEnglishDraughtLength);
                    Marshal.FreeHGlobal(outEnglishDraughtPtr);
                }
                // parse
                EnglishDraught.parse(englishDraught, outEnglishDraughtBytes, 0);
            }
            return englishDraught;
        }

        #endregion

        #region isGameFinish

        [DllImport(GameType.BundleName)]
        private static extern int english_draught_isGameFinish(IntPtr englishDraughtPtr, int englishDraughtLength, bool canCorrect);

        public static int unityIsGameFinish(EnglishDraught englishDraught, bool canCorrect)
        {
            if (englishDraught == null)
            {
                Debug.LogError("englishDraught null");
                return 0;
            }
            // init
            unityInitCore();
            // do job
            int ret = 0;
            {
                byte[] englishDraughtBytes = EnglishDraught.convertToBytes(englishDraught);
                int englishDraughtLength = englishDraughtBytes.Length;
                IntPtr englishDraughtPtr = Marshal.AllocHGlobal(englishDraughtLength);
                try
                {
                    Marshal.Copy(englishDraughtBytes, 0, englishDraughtPtr, englishDraughtLength);
                    ret = english_draught_isGameFinish(englishDraughtPtr, englishDraughtLength, canCorrect);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(englishDraughtPtr);
                }
            }
            return ret;
        }

        #endregion

        #region letComputerThink

        [DllImport(GameType.BundleName)]
        private static extern int english_draught_letComputerThink(IntPtr englishDraughtPtr, int englishDraughtLength, bool canCorrect, bool threeMoveRandom, float fMaxSeconds, System.Int32 g_MaxDepth, System.Int32 pickBestMove, out IntPtr outMovePtr);

        public static EnglishDraughtMove unityLetComputerThink(EnglishDraught englishDraught, bool canCorrect, bool threeMoveRandom, float fMaxSeconds, System.Int32 g_MaxDepth, System.Int32 pickBestMove)
        {
            if (englishDraught == null)
            {
                Debug.LogError("englishDraught null");
                return new EnglishDraughtMove();
            }
            AIController.startThink();
            // init
            unityInitCore();
            // do job
            EnglishDraughtMove move = new EnglishDraughtMove();
            {
                // position
                byte[] englishDraughtBytes = EnglishDraught.convertToBytes(englishDraught);
                int englishDraughtLength = englishDraughtBytes.Length;
                IntPtr englishDraughtPtr = Marshal.AllocHGlobal(englishDraughtLength);
                try
                {
                    Marshal.Copy(englishDraughtBytes, 0, englishDraughtPtr, englishDraughtLength);
                    // request native
                    IntPtr outMovePtr;
                    int outMoveLength = english_draught_letComputerThink(englishDraughtPtr, englishDraughtLength, canCorrect, threeMoveRandom, fMaxSeconds, g_MaxDepth, pickBestMove, out outMovePtr);
                    // set move
                    {
                        byte[] outMoveByteArray = new byte[outMoveLength];
                        {
                            Marshal.Copy(outMovePtr, outMoveByteArray, 0, outMoveLength);
                            Marshal.FreeHGlobal(outMovePtr);
                        }
                        // convert to moveByteArray to move
                        EnglishDraughtMove.parse(move, outMoveByteArray, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(englishDraughtPtr);
                }
            }
            AIController.startEnd();
            return move;
        }

        #endregion

        #region isLegalMove

        [DllImport(GameType.BundleName)]
        private static extern bool english_draught_isLegalMove(IntPtr englishDraughtPtr, int englishDraughtLength, bool canCorrect, IntPtr movePtr, int moveLength);

        public static bool unityIsLegalMove(EnglishDraught englishDraught, bool canCorrect, EnglishDraughtMove move)
        {
            if (englishDraught == null)
            {
                Debug.LogError("englishDraught null");
                return false;
            }
            // init
            unityInitCore();
            // do job
            bool ret = false;
            {
                // position
                byte[] englishDraughtBytes = EnglishDraught.convertToBytes(englishDraught);
                int englishDraughtLength = englishDraughtBytes.Length;
                IntPtr englishDraughtPtr = Marshal.AllocHGlobal(englishDraughtLength);
                // move
                byte[] moveBytes = EnglishDraughtMove.convertToBytes(move);
                int moveLength = moveBytes.Length;
                IntPtr movePtr = Marshal.AllocHGlobal(moveLength);
                try
                {
                    Marshal.Copy(englishDraughtBytes, 0, englishDraughtPtr, englishDraughtLength);
                    Marshal.Copy(moveBytes, 0, movePtr, moveLength);
                    ret = english_draught_isLegalMove(englishDraughtPtr, englishDraughtLength, canCorrect, movePtr, moveLength);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(englishDraughtPtr);
                    Marshal.FreeHGlobal(movePtr);
                }
            }
            return ret;
        }

        #endregion

        #region doMove

        [DllImport(GameType.BundleName)]
        private static extern int english_draught_doMove(IntPtr englishDraughtPtr, int englishDraughtLength, bool canCorrect, IntPtr movePtr, int moveLength, out IntPtr outEnglishDraughtPtr);

        public static EnglishDraught unityDoMove(EnglishDraught englishDraught, bool canCorrect, EnglishDraughtMove move)
        {
            if (englishDraught == null)
            {
                Debug.LogError("englishDraught null");
                return new EnglishDraught();
            }
            // init
            unityInitCore();
            // do job
            EnglishDraught newEnglishDraught = new EnglishDraught();
            {
                // make parameter position
                byte[] englishDraughtBytes = EnglishDraught.convertToBytes(englishDraught);
                int englishDraughtLength = englishDraughtBytes.Length;
                IntPtr englishDraughtPtr = Marshal.AllocHGlobal(englishDraughtLength);
                // make parameter move
                byte[] moveBytes = EnglishDraughtMove.convertToBytes(move);
                int moveLength = moveBytes.Length;
                IntPtr movePtr = Marshal.AllocHGlobal(moveLength);
                // do move
                try
                {
                    Marshal.Copy(englishDraughtBytes, 0, englishDraughtPtr, englishDraughtLength);
                    Marshal.Copy(moveBytes, 0, movePtr, moveLength);
                    // find outRet
                    IntPtr outEnglishDraughtPtr;
                    int outEnglishDraughtLength = english_draught_doMove(englishDraughtPtr, englishDraughtLength, canCorrect, movePtr, moveLength, out outEnglishDraughtPtr);
                    // process result
                    {
                        byte[] outEnglishDraughtBytes = new byte[outEnglishDraughtLength];
                        {
                            Marshal.Copy(outEnglishDraughtPtr, outEnglishDraughtBytes, 0, outEnglishDraughtLength);
                            Marshal.FreeHGlobal(outEnglishDraughtPtr);
                        }
                        // update
                        EnglishDraught.parse(newEnglishDraught, outEnglishDraughtBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(englishDraughtPtr);
                    Marshal.FreeHGlobal(movePtr);
                }
            }
            return newEnglishDraught;
        }

        #endregion

        #region getFen

        // int32_t english_draught_getFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet);
        [DllImport(GameType.BundleName)]
        private static extern int english_draught_getFen(IntPtr englishDraughtPtr, int englishDraughtLength, bool canCorrect, out IntPtr outFenPtr);

        public static string unityGetFen(EnglishDraught englishDraught, bool canCorrect)
        {
            if (englishDraught == null)
            {
                Debug.LogError("englishDraught null");
                return "";
            }
            // init
            unityInitCore();
            // do job
            string strFen = "";
            {
                // make parameter
                byte[] englishDraughtBytes = EnglishDraught.convertToBytes(englishDraught, false);
                int englishDraughtLength = englishDraughtBytes.Length;
                IntPtr englishDraughtPtr = Marshal.AllocHGlobal(englishDraughtLength);
                // do move
                try
                {
                    Marshal.Copy(englishDraughtBytes, 0, englishDraughtPtr, englishDraughtLength);
                    // find outRet
                    IntPtr outFenPtr;
                    int fenLength = english_draught_getFen(englishDraughtPtr, englishDraughtLength, canCorrect, out outFenPtr);
                    // process result
                    {
                        byte[] fenBytes = new byte[fenLength];
                        {
                            Marshal.Copy(outFenPtr, fenBytes, 0, fenLength);
                            Marshal.FreeHGlobal(outFenPtr);
                        }
                        // update ret
                        strFen = System.Text.ASCIIEncoding.Default.GetString(fenBytes);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(englishDraughtPtr);
                }
            }
            return strFen;
        }

        #endregion

        #region getLegalMoves

        [DllImport(GameType.BundleName)]
        private static extern int english_draught_getLegalMoves(IntPtr englishDraughtPtr, int englishDraughtLength, bool canCorrect, out IntPtr outLegalMovesPtr);

        public static List<EnglishDraughtMove> unityGetLegalMoves(EnglishDraught englishDraught, bool canCorrect)
        {
            if (englishDraught == null)
            {
                Debug.LogError("englishDraught null");
                return new List<EnglishDraughtMove>();
            }
            unityInitCore();
            // do job
            List<EnglishDraughtMove> ret = new List<EnglishDraughtMove>();
            {
                // make paramter
                byte[] englishDraughtBytes = EnglishDraught.convertToBytes(englishDraught);
                int englishDraughtLength = englishDraughtBytes.Length;
                IntPtr englishDraughtPtr = Marshal.AllocHGlobal(englishDraughtLength);
                // doMove
                try
                {
                    Marshal.Copy(englishDraughtBytes, 0, englishDraughtPtr, englishDraughtLength);
                    // find new pos
                    IntPtr outLegalMovesPtr;
                    int outLegalMovesLength = english_draught_getLegalMoves(englishDraughtPtr, englishDraughtLength, canCorrect, out outLegalMovesPtr);
                    // process result
                    if (outLegalMovesLength > 0)
                    {
                        byte[] legalMovesBytes = new byte[outLegalMovesLength];
                        {
                            Marshal.Copy(outLegalMovesPtr, legalMovesBytes, 0, outLegalMovesLength);
                            Marshal.FreeHGlobal(outLegalMovesPtr);
                        }
                        // update
                        {
                            int englishDraughtMoveSize = sizeof(System.UInt64) + 12;
                            for (int i = 0; i < legalMovesBytes.Length; i += englishDraughtMoveSize)
                            {
                                if (i + englishDraughtMoveSize <= legalMovesBytes.Length)
                                {
                                    EnglishDraughtMove legalMove = new EnglishDraughtMove();
                                    {
                                        EnglishDraughtMove.parse(legalMove, legalMovesBytes, i);
                                    }
                                    ret.Add(legalMove);
                                }
                                else
                                {
                                    Debug.LogError("legalMovesBytes count error: " + legalMovesBytes.Length + "; " + i);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Cannot find any legal moves: " + englishDraught);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(englishDraughtPtr);
                }
            }
            return ret;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////// init core ///////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        #region setPath

        [DllImport(GameType.BundleName)]
        private static extern bool english_draught_setPath(string newPath);

        #endregion

        #region initCore

        // void english_draught_initCore();
        [DllImport(GameType.BundleName)]
        private static extern void english_draught_initCore();

        #endregion

        private static bool isAlreadyInit = false;

        private static System.Object lockThis = new System.Object();

        public static void unityInitCore()
        {
            lock (lockThis)
            {
                if (!isAlreadyInit)
                {
                    isAlreadyInit = true;
                    // set path
                    {
                        string path = System.IO.Path.Combine(Application.streamingAssetsPath, GameType.AlwaysIn, "EnglishDraught");
                        english_draught_setPath(path);
                        /*#if UNITY_EDITOR
                                                {
                                                    english_draught_setPath(Global.DataPath + "/Plugins/Android/assets/" + GameType.AlwaysIn + "/EnglishDraught");
                                                }
                        #elif UNITY_STANDALONE_OSX
                                                {
                                                    english_draught_setPath(Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.AlwaysIn + "/EnglishDraught");
                                                }
                        #elif UNITY_IPHONE
                                                {
                                                    english_draught_setPath(Global.DataPath+ "/"+GameType.AlwaysIn+"/EnglishDraught");
                                                }
                        #elif UNITY_ANDROID
                                                {
                                                    english_draught_setPath(GameType.AlwaysIn + "/EnglishDraught");
                                                }
                        #endif*/
                    }
                    english_draught_initCore();
                }
                else
                {
                    // Debug.LogError ("already init core");
                }
            }
        }

    }
}