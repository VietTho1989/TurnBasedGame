using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Gomoku
{
    public class Core
    {
        public const bool CanCorrect = true;

        #region makeDefaultPosition

        [DllImport(GameType.BundleName)]
        private static extern int gomoku_makeDefaultPosition(int size, out IntPtr outGomokuPtr);

        public static Gomoku unityMakeDefaultPosition(int size)
        {
            Gomoku gomoku = new Gomoku();
            {
                // request native
                IntPtr outGomokuPtr;
                int outGomokuLength = gomoku_makeDefaultPosition(size, out outGomokuPtr);
                // make byte array
                byte[] outGomokuBytes = new byte[outGomokuLength];
                {
                    Marshal.Copy(outGomokuPtr, outGomokuBytes, 0, outGomokuLength);
                    Marshal.FreeHGlobal(outGomokuPtr);
                }
                // parse
                Gomoku.parse(gomoku, outGomokuBytes, 0);
            }
            return gomoku;
        }

        #endregion

        #region isGameFinish

        [DllImport(GameType.BundleName)]
        private static extern int gomoku_isGameFinish(IntPtr gomokuPtr, int gomokuLength, bool canCorrect);

        public static int unityIsGameFinish(Gomoku gomoku, bool canCorrect)
        {
            if (gomoku == null)
            {
                Debug.LogError("gomoku null");
                return 0;
            }
            // do job
            int ret = 0;
            {
                byte[] gomokuBytes = Gomoku.convertToBytes(gomoku);
                int gomokuLength = gomokuBytes.Length;
                IntPtr gomokuPtr = Marshal.AllocHGlobal(gomokuLength);
                try
                {
                    Marshal.Copy(gomokuBytes, 0, gomokuPtr, gomokuLength);
                    ret = gomoku_isGameFinish(gomokuPtr, gomokuLength, canCorrect);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(gomokuPtr);
                }
            }
            return ret;
        }

        #endregion

        #region letComputerThink

        [DllImport(GameType.BundleName)]
        private static extern int gomoku_letComputerThink(IntPtr gomokuPtr, int gomokuLength, bool canCorrect, int searchDepth, int timeLimit, int level);

        public static int unityLetComputerThink(Gomoku gomoku, bool canCorrect, int searchDepth, int timeLimit, int level)
        {
            if (gomoku == null)
            {
                Debug.LogError("positionBytes null");
                return -1;
            }
            AIController.startThink();
            // do job
            int move = -1;
            {
                // position
                byte[] gomokuBytes = Gomoku.convertToBytes(gomoku);
                int gomokuLength = gomokuBytes.Length;
                IntPtr gomokuPtr = Marshal.AllocHGlobal(gomokuLength);
                try
                {
                    Marshal.Copy(gomokuBytes, 0, gomokuPtr, gomokuLength);
                    move = gomoku_letComputerThink(gomokuPtr, gomokuLength, canCorrect, searchDepth, timeLimit, level);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(gomokuPtr);
                }
            }
            AIController.startEnd();
            return move;
        }

        #endregion

        #region isLegalMove

        [DllImport(GameType.BundleName)]
        private static extern bool gomoku_isLegalMove(IntPtr gomokuPtr, int gomokuLength, bool canCorrect, int move);

        public static bool unityIsLegalMove(Gomoku gomoku, bool canCorrect, int move)
        {
            if (gomoku == null)
            {
                Debug.LogError("gomoku null");
                return false;
            }
            // do job
            bool ret = false;
            {
                // position
                byte[] gomokuBytes = Gomoku.convertToBytes(gomoku);
                int gomokuLength = gomokuBytes.Length;
                IntPtr gomokuPtr = Marshal.AllocHGlobal(gomokuLength);
                // check legal move
                try
                {
                    Marshal.Copy(gomokuBytes, 0, gomokuPtr, gomokuLength);
                    ret = gomoku_isLegalMove(gomokuPtr, gomokuLength, canCorrect, move);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(gomokuPtr);
                }
            }
            return ret;
        }

        #endregion

        #region doMove

        [DllImport(GameType.BundleName)]
        private static extern int gomoku_doMove(IntPtr gomokuPtr, int gomokuLength, bool canCorrect, int move, out IntPtr outGomokuPtr);

        public static Gomoku unityDoMove(Gomoku gomoku, bool canCorrect, int move)
        {
            if (gomoku == null)
            {
                Debug.LogError("gomoky null");
                return new Gomoku();
            }
            // do job
            Gomoku newGomoku = new Gomoku();
            {
                // make parameter
                byte[] gomokuBytes = Gomoku.convertToBytes(gomoku);
                int gomokuLength = gomokuBytes.Length;
                IntPtr gomokuPtr = Marshal.AllocHGlobal(gomokuLength);
                // do move
                try
                {
                    Marshal.Copy(gomokuBytes, 0, gomokuPtr, gomokuLength);
                    // find outRet
                    IntPtr outGomokuPtr;
                    int outGomokuLength = gomoku_doMove(gomokuPtr, gomokuLength, canCorrect, move, out outGomokuPtr);
                    // process result
                    {
                        byte[] outGomokuBytes = new byte[outGomokuLength];
                        {
                            Marshal.Copy(outGomokuPtr, outGomokuBytes, 0, outGomokuLength);
                            Marshal.FreeHGlobal(outGomokuPtr);
                        }
                        // update
                        Gomoku.parse(newGomoku, outGomokuBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(gomokuPtr);
                }
            }
            return newGomoku;
        }

        #endregion

    }
}