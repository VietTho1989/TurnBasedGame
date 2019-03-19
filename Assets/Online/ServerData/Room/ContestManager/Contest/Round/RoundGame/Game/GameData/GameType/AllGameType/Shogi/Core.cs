using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Shogi
{
    public class Core
    {

        public const bool CanCorrect = true;

        #region setBookPath

        [DllImport(GameType.BundleName)]
        private static extern bool shogi_setBookPath(string newBookPath);

        public static bool unitySetBookPath(string newBookPath)
        {
            return shogi_setBookPath(newBookPath);
        }

        #endregion

        #region setEvaluatorPath

        [DllImport(GameType.BundleName)]
        private static extern bool shogi_setEvaluatorPath(string newEvaluatorPath);

        public static bool unitySetEvaluatorPath(string newEvaluatorPath)
        {
            return shogi_setEvaluatorPath(newEvaluatorPath);
        }

        #endregion

        [DllImport(GameType.BundleName)]
        private static extern void shogi_initCore();

        #region makePositionByFen

        [DllImport(GameType.BundleName)]
        private static extern int shogi_makePositionByFen(string strFen, out IntPtr outShogiPtr);

        public static Shogi unityMakePositionByFen(string strFen)
        {
            // init
            unityInitCore();
            // do job
            Shogi shogi = new Shogi();
            {
                byte[] shogiBytes;
                {
                    IntPtr outShogiPtr;
                    int newPosLength = shogi_makePositionByFen(strFen, out outShogiPtr);
                    shogiBytes = new byte[newPosLength];
                    Marshal.Copy(outShogiPtr, shogiBytes, 0, newPosLength);
                    Marshal.FreeHGlobal(outShogiPtr);
                }
                // parse
                Shogi.parse(shogi, shogiBytes, 0);
            }
            return shogi;
        }

        #endregion

        #region isGameFinish

        [DllImport(GameType.BundleName)]
        private static extern int shogi_isGameFinish(IntPtr shogiPtr, int length, bool canCorrect);

        public static int unityIsGameFinish(Shogi shogi, bool canCorrect)
        {
            if (shogi == null)
            {
                Debug.LogError("shogi null");
                return 0;
            }
            // init
            unityInitCore();
            // do job
            int ret = 0;
            {
                byte[] shogiBytes = Shogi.convertToBytes(shogi);
                int length = shogiBytes.Length;
                IntPtr shogiPtr = Marshal.AllocHGlobal(length);
                try
                {
                    Marshal.Copy(shogiBytes, 0, shogiPtr, length);
                    ret = shogi_isGameFinish(shogiPtr, length, canCorrect);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(shogiPtr);
                }
            }
            return ret;
        }

        #endregion

        #region letComputerThink

        [DllImport(GameType.BundleName)]
        private static extern uint shogi_letComputerThink(IntPtr shogiPtr, int length, bool canCorrect, int depth, int skillLevel, int mr, int duration, bool useBook);

        public static uint unityLetComputerThink(Shogi shogi, bool canCorrect, int depth, int skillLevel, int mr, int duration, bool useBook)
        {
            if (shogi == null)
            {
                Debug.LogError("shogi null");
                return 0;
            }
            AIController.startThink();
            // init
            unityInitCore();
            firstInitEvaluator();
            // do job
            uint move = 0;
            {
                byte[] shogiBytes = Shogi.convertToBytes(shogi);
                int length = shogiBytes.Length;
                IntPtr shogiPtr = Marshal.AllocHGlobal(length);
                try
                {
                    Marshal.Copy(shogiBytes, 0, shogiPtr, length);
                    move = shogi_letComputerThink(shogiPtr, length, canCorrect, depth, skillLevel, mr, duration, useBook);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(shogiPtr);
                }
            }
            AIController.startEnd();
            return move;
        }

        #endregion

        #region isLegalMove

        [DllImport(GameType.BundleName)]
        private static extern bool shogi_isLegalMove(IntPtr shogiPtr, int length, bool canCorrect, uint move);

        public static bool unityIsLegalMove(Shogi shogi, bool canCorrect, uint move)
        {
            if (shogi == null)
            {
                Debug.LogError("shogi null");
                return false;
            }
            // init
            unityInitCore();
            // do job
            bool ret = false;
            {
                byte[] shogiBytes = Shogi.convertToBytes(shogi);
                int length = shogiBytes.Length;
                IntPtr pnt = Marshal.AllocHGlobal(length);
                try
                {
                    Marshal.Copy(shogiBytes, 0, pnt, length);
                    ret = shogi_isLegalMove(pnt, length, canCorrect, move);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(pnt);
                }
                Debug.Log("isLegalMove: " + ret + "; " + move);
            }
            return ret;
        }

        #endregion

        #region doMove

        [DllImport(GameType.BundleName)]
        private static extern int shogi_doMove(IntPtr shogiPtr, int length, bool canCorrect, uint move, out IntPtr outRet);

        public static Shogi unityDoMove(Shogi shogi, bool canCorrect, uint move)
        {
            if (shogi == null)
            {
                Debug.LogError("shogi null");
                return new Shogi();
            }
            // init
            unityInitCore();
            // do job
            Shogi newShogi = new Shogi();
            {
                // make parameter
                byte[] shogiBytes = Shogi.convertToBytes(shogi);
                int length = shogiBytes.Length;
                IntPtr shogiPtr = Marshal.AllocHGlobal(length);
                // make request
                try
                {
                    Marshal.Copy(shogiBytes, 0, shogiPtr, length);
                    // find outPtr
                    IntPtr newShogiPtr;
                    int newShogiLength = shogi_doMove(shogiPtr, length, canCorrect, move, out newShogiPtr);
                    // process result
                    {
                        byte[] newShogiBytes = new byte[newShogiLength];
                        {
                            Marshal.Copy(newShogiPtr, newShogiBytes, 0, newShogiLength);
                            Marshal.FreeHGlobal(newShogiPtr);
                        }
                        // update
                        Shogi.parse(newShogi, newShogiBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(shogiPtr);
                }
            }
            return newShogi;
        }

        #endregion

        #region GetLegalMoves

        [DllImport(GameType.BundleName)]
        private static extern int shogi_getLegalMoves(IntPtr shogiPtr, int shogiLength, bool canCorrect, out IntPtr outLegalMovesPtr);

        public static List<ShogiMove> unityGetLegalMoves(Shogi shogi, bool canCorrect)
        {
            if (shogi == null)
            {
                Debug.LogError("shogi null");
                return new List<ShogiMove>();
            }
            unityInitCore();
            // do job
            List<ShogiMove> ret = new List<ShogiMove>();
            {
                // make paramter
                byte[] shogiBytes = Shogi.convertToBytes(shogi);
                int shogiLength = shogiBytes.Length;
                IntPtr shogiPtr = Marshal.AllocHGlobal(shogiLength);
                // doMove
                try
                {
                    Marshal.Copy(shogiBytes, 0, shogiPtr, shogiLength);
                    // find new pos
                    IntPtr outLegalMovesPtr;
                    int outLegalMovesLength = shogi_getLegalMoves(shogiPtr, shogiLength, canCorrect, out outLegalMovesPtr);
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
                            for (int i = 0; i < legalMovesBytes.Length; i += 4)
                            {
                                if (i + 4 <= legalMovesBytes.Length)
                                {
                                    ShogiMove legalMove = new ShogiMove();
                                    {
                                        legalMove.move.v = BitConverter.ToUInt32(legalMovesBytes, i);
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
                        Debug.LogError("Cannot find any legal moves: " + shogi);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(shogiPtr);
                }
            }
            return ret;
        }

        #endregion

        #region getCheckersFromBitBoard

        [DllImport(GameType.BundleName)]
        private static extern int shogi_getCheckersFromBitBoard(IntPtr bitboardBytes, out IntPtr outRet);

        public static List<Common.Square> unityGetCheckersFromBitBoard(Common.BitBoard bitboard)
        {
            List<Common.Square> ret = new List<Common.Square>();
            {
                // init
                unityInitCore();
                // do job
                byte[] bitboardByteArray = Common.BitBoard.convertToByte(bitboard);
                int length = bitboardByteArray.Length;
                // make request
                IntPtr unmanagedPtr;
                IntPtr pnt = Marshal.AllocHGlobal(length);
                byte[] outRet;
                try
                {
                    Marshal.Copy(bitboardByteArray, 0, pnt, length);
                    int newPosLength = shogi_getCheckersFromBitBoard(pnt, out unmanagedPtr);
                    // process result
                    {
                        outRet = new byte[newPosLength];
                        Marshal.Copy(unmanagedPtr, outRet, 0, newPosLength);
                        Marshal.FreeHGlobal(unmanagedPtr);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    outRet = new byte[] { };
                }
                finally
                {
                    Marshal.FreeHGlobal(pnt);
                }
                // process outRet
                if (outRet != null && outRet.Length > 0)
                {
                    // parse to int list
                    int count = 0;
                    bool firstTime = true;
                    do
                    {
                        if (count + sizeof(int) <= outRet.Length)
                        {
                            if (!firstTime)
                            {
                                ret.Add((Common.Square)BitConverter.ToInt32(outRet, count));
                            }
                            else
                            {
                                firstTime = false;
                                // int checkNumber = BitConverter.ToInt32 (outRet, count);
                                // Debug.LogError("check number count: "+checkNumber);
                            }
                            count += sizeof(int);
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }
                else
                {
                    Debug.LogError("why outRet null");
                }
            }
            return ret;
        }

        #endregion

        #region check position ok

        [DllImport(GameType.BundleName)]
        private static extern int shogi_checkMyPositionIsOk(IntPtr positionBytes, int length);

        public static int unityCheckMyPositionIsOk(byte[] positionBytes)
        {
            if (positionBytes == null)
            {
                Debug.LogError("positionBytes null");
                return -1;
            }
            // init
            unityInitCore();
            // do job
            int length = positionBytes.Length;
            IntPtr pnt = Marshal.AllocHGlobal(length);
            int ret = -1;
            try
            {
                Marshal.Copy(positionBytes, 0, pnt, length);
                ret = shogi_checkMyPositionIsOk(pnt, length);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                Marshal.FreeHGlobal(pnt);
            }
            Debug.LogError("checkMyPositionOK: " + ret);
            return ret;
        }

        #endregion

        #region changeEvaluatorPath

        [DllImport(GameType.BundleName)]
        private static extern bool shogi_changeEvaluatorPath(string newEvaluatorPath);

        public static bool unityChangeEvaluatorPath(string newEvaluatorPath)
        {
            // init
            unityInitCore();
            // do job
            return shogi_changeEvaluatorPath(newEvaluatorPath);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////// initCore ///////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        #region init Core

        public static bool isAlreadyInit = false;

        private static System.Object lockThis = new System.Object();

        public static void unityInitCore()
        {
            lock (lockThis)
            {
                if (!isAlreadyInit)
                {
                    isAlreadyInit = true;
                    // set data path
                    {
#if UNITY_STANDALONE_OSX

                        // Book
                        {
                            string bookPath = Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.AlwaysIn + "/shogi/book.bin";
                            if (unitySetBookPath(bookPath))
                            {
                                Debug.Log("book exist");
                            }
                            else
                            {
                                Debug.LogError("book not exist: " + bookPath);
                            }
                        }
                        // Evaluator
                        {
                            string evaluatorPath = "";
                            if (unitySetEvaluatorPath(evaluatorPath))
                            {
                                Debug.Log("evaluator exist");
                            }
                            else
                            {
                                Debug.LogError("evaluator not exist: " + evaluatorPath);
                            }
                        }

#elif UNITY_IPHONE

						// Book
						{
							string bookPath = Global.DataPath+ "/"+GameType.AlwaysIn+"/shogi/book.bin";
							if(unitySetBookPath(bookPath)){
								Debug.Log("book exist");
							} else{
								Debug.LogError("book not exist: "+bookPath);
							}
						}
						// Evaluator
						{
							string evaluatorPath = "";
							if(unitySetEvaluatorPath(evaluatorPath)){
								Debug.Log("evaluator exist");
							} else{
								Debug.LogError("evaluator not exist: "+evaluatorPath);
							}
						}

#elif UNITY_ANDROID

						// Book
						{
							string bookPath = GameType.AlwaysIn + "/shogi/book.bin";
							if(unitySetBookPath(bookPath)){
								Debug.Log("book exist");
							} else{
								Debug.LogError("book not exist: "+bookPath);
							}
						}
						// Evaluator
						{
							string evaluatorPath = "";
							if(unitySetEvaluatorPath(evaluatorPath)){
								Debug.Log("evaluator exist");
							} else{
								Debug.LogError("evaluator not exist: "+evaluatorPath);
							}
						}

#endif
                    }
                    // set core
                    shogi_initCore();
                }
                else
                {
                    // Debug.LogError ("already init core");
                }
            }
        }

        #endregion

        #region first init book

        private static bool isAlreadyInitEvaluator = false;

        private static System.Object lockEvaluator = new System.Object();

        private static void firstInitEvaluator()
        {
            lock (lockEvaluator)
            {
                if (!isAlreadyInitEvaluator)
                {
                    isAlreadyInitEvaluator = true;
                    // set book
                    {
#if UNITY_STANDALONE_OSX
                        {
                            string evaluatorPath = Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.NotAlwaysIn + "/shogi/20171106";
                            if (unityChangeEvaluatorPath(evaluatorPath))
                            {
                                Debug.Log("evaluator exist");
                            }
                            else
                            {
                                Debug.LogError("evaluator not exist: " + evaluatorPath);
                            }
                        }
#elif UNITY_IPHONE
						{
							string evaluatorPath = Global.DataPath + "/"+GameType.NotAlwaysIn+"/shogi/20171106";
							if(unityChangeEvaluatorPath(evaluatorPath)){
								Debug.Log("evaluator exist");
							} else{
								Debug.LogError("evaluator not exist: "+evaluatorPath);
							}
						}
#elif UNITY_ANDROID
						/*{
							string evaluatorPath = GameType.NotAlwaysIn + "/shogi/20171106"
							if(unityChangeEvaluatorPath(evaluatorPath)){
								Debug.Log("evaluator exist");
							} else{
								Debug.LogError("evaluator not exist: "+evaluatorPath);
							}*/
#endif
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