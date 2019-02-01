using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ChineseCheckers
{
    public class Core
    {

        public const bool CanCorrect = true;

        #region initCore

        private static bool isAlreadyInit = false;

        private static System.Object lockThis = new System.Object();

        public static void unityInitCore()
        {
            if (!isAlreadyInit)
            {
                lock (lockThis)
                {
                    if (!isAlreadyInit)
                    {
                        isAlreadyInit = true;
                    }
                    else
                    {
                        // Debug.LogError ("already init core");
                    }
                }
            }
        }

        #endregion

        #region makePositionByFen

        [DllImport(GameType.BundleName)]
        private static extern int chinese_checkers_makePositionByFen(string strFen, out IntPtr outNineMenMorrisDraughtPtr);

        public static ChineseCheckers unityMakePositionByFen(string strFen)
        {
            // init
            unityInitCore();
            // do job
            ChineseCheckers chineseCheckers = new ChineseCheckers();
            {
                // request native
                IntPtr outChineseCheckersPtr;
                int outChineseCheckersLength = chinese_checkers_makePositionByFen(strFen, out outChineseCheckersPtr);
                // make byte array
                byte[] outChineseCheckersBytes = new byte[outChineseCheckersLength];
                {
                    Marshal.Copy(outChineseCheckersPtr, outChineseCheckersBytes, 0, outChineseCheckersLength);
                    Marshal.FreeHGlobal(outChineseCheckersPtr);
                }
                // parse
                ChineseCheckers.parse(chineseCheckers, outChineseCheckersBytes, 0);
            }
            return chineseCheckers;
        }

        #endregion

        #region isGameFinish

        [DllImport(GameType.BundleName)]
        private static extern int chinese_checkers_isGameFinish(IntPtr chineseCheckersPtr, int chineseCheckersLength, bool canCorrect);

        public static int unityIsGameFinish(ChineseCheckers chineseCheckers, bool canCorrect)
        {
            if (chineseCheckers == null)
            {
                Debug.LogError("chineseCheckers null");
                return 0;
            }
            // init
            unityInitCore();
            // do job
            int ret = 0;
            {
                byte[] chineseCheckersBytes = ChineseCheckers.convertToBytes(chineseCheckers);
                int chineseCheckersLength = chineseCheckersBytes.Length;
                IntPtr chineseCheckersPtr = Marshal.AllocHGlobal(chineseCheckersLength);
                try
                {
                    Marshal.Copy(chineseCheckersBytes, 0, chineseCheckersPtr, chineseCheckersLength);
                    ret = chinese_checkers_isGameFinish(chineseCheckersPtr, chineseCheckersLength, canCorrect);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(chineseCheckersPtr);
                }
            }
            return ret;
        }

        #endregion

        #region letComputerThink
       
        [DllImport(GameType.BundleName)]
        private static extern int chinese_checkers_letComputerThink(IntPtr chineseCheckersPtr, int chineseCheckersLength, bool canCorrect, int type, int depth, int time, int node, int pickBestMove, out IntPtr outMovePtr);

        public static ChineseCheckersMove unityLetComputerThink(ChineseCheckers chineseCheckers, bool canCorrect, int type, int depth, int time, int node, int pickBestMove)
        {
            if (chineseCheckers == null)
            {
                Debug.LogError("chineseCheckers null");
                return new ChineseCheckersMove();
            }
            AIController.startThink();
            // init
            unityInitCore();
            // do job
            ChineseCheckersMove move = new ChineseCheckersMove();
            {
                // position
                byte[] chineseCheckersBytes = ChineseCheckers.convertToBytes(chineseCheckers);
                int chineseCheckersLength = chineseCheckersBytes.Length;
                IntPtr chineseCheckersPtr = Marshal.AllocHGlobal(chineseCheckersLength);
                try
                {
                    Marshal.Copy(chineseCheckersBytes, 0, chineseCheckersPtr, chineseCheckersLength);
                    // request native
                    IntPtr outMovePtr;
                    int outMoveLength = chinese_checkers_letComputerThink(chineseCheckersPtr, chineseCheckersLength, canCorrect, type, depth, time, node, pickBestMove, out outMovePtr);
                    if (outMoveLength > 0)
                    {
                        // set move
                        {
                            byte[] outMoveByteArray = new byte[outMoveLength];
                            {
                                Marshal.Copy(outMovePtr, outMoveByteArray, 0, outMoveLength);
                                Marshal.FreeHGlobal(outMovePtr);
                            }
                            // convert to moveByteArray to move
                            ChineseCheckersMove.parse(move, outMoveByteArray, 0);
                        }
                    }
                    else
                    {
                        Debug.LogError("Don't have move length");
                        move = null;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(chineseCheckersPtr);
                }
            }
            AIController.startEnd();
            return move;
        }

        #endregion

        #region isLegalMove

        [DllImport(GameType.BundleName)]
        private static extern bool chinese_checkers_isLegalMove(IntPtr chineseCheckersPtr, int chineseCheckersLength, bool canCorrect, IntPtr movePtr, int moveLength);

        public static bool unityIsLegalMove(ChineseCheckers chineseCheckers, bool canCorrect, ChineseCheckersMove move)
        {
            if (chineseCheckers == null)
            {
                Debug.LogError("chineseCheckers null");
                return false;
            }
            // init
            unityInitCore();
            // do job
            bool ret = false;
            {
                // position
                byte[] chineseCheckersBytes = ChineseCheckers.convertToBytes(chineseCheckers);
                int chineseCheckersLength = chineseCheckersBytes.Length;
                IntPtr chineseCheckersPtr = Marshal.AllocHGlobal(chineseCheckersLength);
                // move
                byte[] moveBytes = ChineseCheckersMove.convertToBytes(move);
                int moveLength = moveBytes.Length;
                IntPtr movePtr = Marshal.AllocHGlobal(moveLength);
                try
                {
                    Marshal.Copy(chineseCheckersBytes, 0, chineseCheckersPtr, chineseCheckersLength);
                    Marshal.Copy(moveBytes, 0, movePtr, moveLength);
                    ret = chinese_checkers_isLegalMove(chineseCheckersPtr, chineseCheckersLength, canCorrect, movePtr, moveLength);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(chineseCheckersPtr);
                    Marshal.FreeHGlobal(movePtr);
                }
            }
            return ret;
        }

        #endregion

        #region doMove

        [DllImport(GameType.BundleName)]
        private static extern int chinese_checkers_doMove(IntPtr chineseCheckersPtr, int chineseCheckersLength, bool canCorrect, IntPtr movePtr, int moveLength, out IntPtr outChineseChecekrsPtr);

        public static ChineseCheckers unityDoMove(ChineseCheckers chineseCheckers, bool canCorrect, ChineseCheckersMove move)
        {
            if (chineseCheckers == null)
            {
                Debug.LogError("chineseCheckers null");
                return new ChineseCheckers();
            }
            // init
            unityInitCore();
            // do job
            ChineseCheckers newChineseCheckers = new ChineseCheckers();
            {
                // make parameter position
                byte[] chineseCheckersBytes = ChineseCheckers.convertToBytes(chineseCheckers);
                int chineseCheckersLength = chineseCheckersBytes.Length;
                IntPtr chineseCheckersPtr = Marshal.AllocHGlobal(chineseCheckersLength);
                // make parameter move
                byte[] moveBytes = ChineseCheckersMove.convertToBytes(move);
                int moveLength = moveBytes.Length;
                IntPtr movePtr = Marshal.AllocHGlobal(moveLength);
                // do move
                try
                {
                    Marshal.Copy(chineseCheckersBytes, 0, chineseCheckersPtr, chineseCheckersLength);
                    Marshal.Copy(moveBytes, 0, movePtr, moveLength);
                    // find outRet
                    IntPtr outChineseCheckersPtr;
                    int outChineseCheckersLength = chinese_checkers_doMove(chineseCheckersPtr, chineseCheckersLength, canCorrect, movePtr, moveLength, out outChineseCheckersPtr);
                    // process result
                    {
                        byte[] outChineseCheckersBytes = new byte[outChineseCheckersLength];
                        {
                            Marshal.Copy(outChineseCheckersPtr, outChineseCheckersBytes, 0, outChineseCheckersLength);
                            Marshal.FreeHGlobal(outChineseCheckersPtr);
                        }
                        // update
                        ChineseCheckers.parse(newChineseCheckers, outChineseCheckersBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(chineseCheckersPtr);
                    Marshal.FreeHGlobal(movePtr);
                }
            }
            return newChineseCheckers;
        }

        #endregion

        #region getLegalMoves

        [DllImport(GameType.BundleName)]
        private static extern int chinese_checkers_getLegalMoves(IntPtr chineseCheckersPtr, int chineseCheckersLength, bool canCorrect, out IntPtr outLegalMovesPtr);

        public static List<ChineseCheckersMove> unityGetLegalMoves(ChineseCheckers chineseCheckers, bool canCorrect)
        {
            if (chineseCheckers == null)
            {
                Debug.LogError("chineseCheckers null");
                return new List<ChineseCheckersMove>();
            }
            unityInitCore();
            // do job
            List<ChineseCheckersMove> ret = new List<ChineseCheckersMove>();
            {
                // make paramter
                byte[] chineseCheckersBytes = ChineseCheckers.convertToBytes(chineseCheckers);
                int chineseCheckersLength = chineseCheckersBytes.Length;
                IntPtr chineseCheckersPtr = Marshal.AllocHGlobal(chineseCheckersLength);
                // doMove
                try
                {
                    Marshal.Copy(chineseCheckersBytes, 0, chineseCheckersPtr, chineseCheckersLength);
                    // find new pos
                    IntPtr outLegalMovesPtr;
                    int outLegalMovesLength = chinese_checkers_getLegalMoves(chineseCheckersPtr, chineseCheckersLength, canCorrect, out outLegalMovesPtr);
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
                            int chineseCheckersMoveSize = ChineseCheckersMove.GetSize();
                            for (int i = 0; i < legalMovesBytes.Length; i += chineseCheckersMoveSize)
                            {
                                if (i + chineseCheckersMoveSize <= legalMovesBytes.Length)
                                {
                                    ChineseCheckersMove legalMove = new ChineseCheckersMove();
                                    {
                                        ChineseCheckersMove.parse(legalMove, legalMovesBytes, i);
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
                        Debug.LogError("Cannot find any legal moves: " + chineseCheckers);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(chineseCheckersPtr);
                }
            }
            return ret;
        }

        #endregion

        #region print

        [DllImport(GameType.BundleName)]
        private static extern int chinese_checkers_printPosition(IntPtr chineseCheckersPtr, int chineseCheckersLength, bool canCorrect, out IntPtr outStrPositionPtr);

        public static string unityGetStrPosition(ChineseCheckers chineseCheckers, bool canCorrect)
        {
            if (chineseCheckers == null)
            {
                Debug.LogError("chineseCheckers null");
                return "";
            }
            unityInitCore();
            string ret = "";
            // do job
            {
                // make parameter
                byte[] chineseCheckersBytes = ChineseCheckers.convertToBytes(chineseCheckers);
                int chineseCheckersLength = chineseCheckersBytes.Length;
                IntPtr chineseCheckersPtr = Marshal.AllocHGlobal(chineseCheckersLength);
                // make request
                try
                {
                    Marshal.Copy(chineseCheckersBytes, 0, chineseCheckersPtr, chineseCheckersLength);
                    // find outRet
                    IntPtr outStrPositionPtr;
                    int outStrPositionLength = chinese_checkers_printPosition(chineseCheckersPtr, chineseCheckersLength, canCorrect, out outStrPositionPtr);
                    // process result
                    {
                        byte[] outStrPositionBytes = new byte[outStrPositionLength];
                        {
                            Marshal.Copy(outStrPositionPtr, outStrPositionBytes, 0, outStrPositionLength);
                            Marshal.FreeHGlobal(outStrPositionPtr);
                        }
                        // update
                        ret = System.Text.ASCIIEncoding.Default.GetString(outStrPositionBytes);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(chineseCheckersPtr);
                }
            }
            return ret;
        }

        #endregion

    }
}