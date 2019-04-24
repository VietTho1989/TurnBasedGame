using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace InternationalDraught
{
    public class Core
    {
        public const bool CanCorrect = true;

        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// set path /////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////

        [DllImport(GameType.BundleName)]
        private static extern bool international_draught_setBookPath(string newBookPath);

        [DllImport(GameType.BundleName)]
        private static extern bool international_draught_setBBPath(string newBBPath);

        [DllImport(GameType.BundleName)]
        private static extern bool international_draught_setEvalPath(string newEvalPath);

        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// Match /////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////

        #region makeDefaultPosition

        [DllImport(GameType.BundleName)]
        private static extern int international_draught_makeDefaultPosition(int variantType, string fen, out IntPtr outInternationalDraughtPtr);

        public static InternationalDraught unityMakeDefaultPosition(int variantType, string fen)
        {
            // init
            unityInitCore();
            // do job
            InternationalDraught internationalDraught = new InternationalDraught();
            {
                // request native
                IntPtr outInternationalDraughtPtr;
                int newPosLength = international_draught_makeDefaultPosition(variantType, fen, out outInternationalDraughtPtr);
                // make byte array
                byte[] outInternationalDraughtBytes = new byte[newPosLength];
                {
                    Marshal.Copy(outInternationalDraughtPtr, outInternationalDraughtBytes, 0, newPosLength);
                    Marshal.FreeHGlobal(outInternationalDraughtPtr);
                }
                // parse
                InternationalDraught.parse(internationalDraught, outInternationalDraughtBytes, 0);
            }
            return internationalDraught;
        }

        #endregion

        #region isGameFinish

        [DllImport(GameType.BundleName)]
        private static extern int international_draught_isGameFinish(IntPtr internationalDraughtPtr, int length, bool canCorrect);

        public static int unityIsGameFinish(InternationalDraught internationalDraught, bool canCorrect)
        {
            if (internationalDraught == null)
            {
                Debug.LogError("positionBytes null");
                return 0;
            }
            // init
            unityInitCore();
            // do job
            int ret = 0;
            {
                byte[] internationalDraughtBytes = InternationalDraught.convertToBytes(internationalDraught);
                int length = internationalDraughtBytes.Length;
                IntPtr internationalDraughtPtr = Marshal.AllocHGlobal(length);
                try
                {
                    Marshal.Copy(internationalDraughtBytes, 0, internationalDraughtPtr, length);
                    ret = international_draught_isGameFinish(internationalDraughtPtr, length, canCorrect);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(internationalDraughtPtr);
                }
            }
            return ret;
        }

        #endregion

        #region letComputerThink

        [DllImport(GameType.BundleName)]
        private static extern System.UInt64 international_draught_letComputerThink(IntPtr internationalDraughtPtr, int length, bool canCorrect, bool move, bool book, int depth, float time, bool input, bool useEndGameDatabase, int pickBestMove);

        public static System.UInt64 unityLetComputerThink(InternationalDraught internationalDraught, bool canCorrect, bool isMove, bool book, int depth, float time, bool input, bool useEndGameDatabase, int pickBestMove)
        {
            if (internationalDraught == null)
            {
                Debug.LogError("positionBytes null");
                return 0;
            }
            AIController.startThink();
            // init
            unityInitCore();
            // do job
            System.UInt64 move = 0;
            {
                // position
                byte[] positionBytes = InternationalDraught.convertToBytes(internationalDraught);
                int length = positionBytes.Length;
                IntPtr internationalDraughtPtr = Marshal.AllocHGlobal(length);
                try
                {
                    Marshal.Copy(positionBytes, 0, internationalDraughtPtr, length);
                    move = international_draught_letComputerThink(internationalDraughtPtr, length, canCorrect, isMove, book, depth, time, input, useEndGameDatabase, pickBestMove);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(internationalDraughtPtr);
                }
            }
            AIController.startEnd();
            return move;
        }

        #endregion

        #region isLegalMove

        [DllImport(GameType.BundleName)]
        private static extern bool international_draught_isLegalMove(IntPtr positionPtr, int length, bool canCorrect, System.UInt64 move);

        public static bool unityIsLegalMove(InternationalDraught internationalDraught, bool canCorrect, System.UInt64 move)
        {
            if (internationalDraught == null)
            {
                Debug.LogError("positionBytes null");
                return false;
            }
            // init
            unityInitCore();
            // do job
            bool ret = false;
            {
                // position
                byte[] positionBytes = InternationalDraught.convertToBytes(internationalDraught);
                int length = positionBytes.Length;
                IntPtr positionPtr = Marshal.AllocHGlobal(length);
                // check legal move
                try
                {
                    Marshal.Copy(positionBytes, 0, positionPtr, length);
                    ret = international_draught_isLegalMove(positionPtr, length, canCorrect, move);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(positionPtr);
                }
            }
            return ret;
        }

        #endregion

        #region doMove

        [DllImport(GameType.BundleName)]
        private static extern int international_draught_doMove(IntPtr internationalDraughtPtr, int length, bool canCorrect, System.UInt64 move, out IntPtr outInternationalDraughtPtr);

        public static InternationalDraught unityDoMove(InternationalDraught internationalDraught, bool canCorrect, System.UInt64 move)
        {
            if (internationalDraught == null)
            {
                Debug.LogError("internationalDraught null");
                return new InternationalDraught();
            }
            // init
            unityInitCore();
            // do job
            InternationalDraught newInternationalDraught = new InternationalDraught();
            {
                // make parameter
                byte[] internationalDraughtBytes = InternationalDraught.convertToBytes(internationalDraught);
                int internationalDraughtLength = internationalDraughtBytes.Length;
                IntPtr internationalDraughtPtr = Marshal.AllocHGlobal(internationalDraughtLength);
                // do move
                try
                {
                    Marshal.Copy(internationalDraughtBytes, 0, internationalDraughtPtr, internationalDraughtLength);
                    // find outRet
                    IntPtr outInternationalDraughtPtr;
                    int newInternationalDraughtLength = international_draught_doMove(internationalDraughtPtr, internationalDraughtLength, canCorrect, move, out outInternationalDraughtPtr);
                    // process result
                    {
                        byte[] outInternationalDraughtBytes = new byte[newInternationalDraughtLength];
                        {
                            Marshal.Copy(outInternationalDraughtPtr, outInternationalDraughtBytes, 0, newInternationalDraughtLength);
                            Marshal.FreeHGlobal(outInternationalDraughtPtr);
                        }
                        // update
                        InternationalDraught.parse(newInternationalDraught, outInternationalDraughtBytes, 0);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(internationalDraughtPtr);
                }
            }
            return newInternationalDraught;
        }

        #endregion

        #region Fen

        [DllImport(GameType.BundleName)]
        private static extern int international_draught_getFen(IntPtr posPtr, int length, bool canCorrect, out IntPtr outFenPtr);

        public static string unityGetFen(Pos pos, bool canCorrect)
        {
            if (pos == null)
            {
                Debug.LogError("pos null");
                return "";
            }
            // init
            unityInitCore();
            // do job
            string strFen = "";
            {
                // make parameter
                byte[] posBytes = Pos.convertToBytes(pos);
                int posLength = posBytes.Length;
                IntPtr posPtr = Marshal.AllocHGlobal(posLength);
                // do move
                try
                {
                    Marshal.Copy(posBytes, 0, posPtr, posLength);
                    // find outRet
                    IntPtr outFenPtr;
                    int fenLength = international_draught_getFen(posPtr, posLength, canCorrect, out outFenPtr);
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
                    Marshal.FreeHGlobal(posPtr);
                }
            }
            return strFen;
        }

        #endregion

        #region GetLegalMoves

        [DllImport(GameType.BundleName)]
        private static extern int international_draught_getLegalMoves(IntPtr internationalDraughtPtr, int internationalDraughtLength, bool canCorrect, out IntPtr outLegalMovesPtr);

        public static List<InternationalDraughtMove> unityGetLegalMoves(InternationalDraught internationalDraught, bool canCorrect)
        {
            if (internationalDraught == null)
            {
                Debug.LogError("internationalDraught null");
                return new List<InternationalDraughtMove>();
            }
            unityInitCore();
            // do job
            List<InternationalDraughtMove> ret = new List<InternationalDraughtMove>();
            {
                // make paramter
                byte[] internationalDraughtBytes = InternationalDraught.convertToBytes(internationalDraught);
                int internationalDraughtLength = internationalDraughtBytes.Length;
                IntPtr internationalDraughtPtr = Marshal.AllocHGlobal(internationalDraughtLength);
                // doMove
                try
                {
                    Marshal.Copy(internationalDraughtBytes, 0, internationalDraughtPtr, internationalDraughtLength);
                    // find new pos
                    IntPtr outLegalMovesPtr;
                    int outLegalMovesLength = international_draught_getLegalMoves(internationalDraughtPtr, internationalDraughtLength, canCorrect, out outLegalMovesPtr);
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
                            for (int i = 0; i < legalMovesBytes.Length; i += sizeof(System.UInt64))
                            {
                                if (i + sizeof(System.UInt64) <= legalMovesBytes.Length)
                                {
                                    InternationalDraughtMove legalMove = new InternationalDraughtMove();
                                    {
                                        legalMove.move.v = BitConverter.ToUInt64(legalMovesBytes, i);
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
                        Debug.LogError("Cannot find any legal moves: " + internationalDraught);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    Marshal.FreeHGlobal(internationalDraughtPtr);
                }
            }
            return ret;
        }

        #endregion

        #region getMoveSquareList

        [DllImport(GameType.BundleName)]
        private static extern int international_draught_getMoveSquareList(System.UInt64 move, out IntPtr outMoveSquareListPtr);

        public static List<int> unityGetMoveSquareList(System.UInt64 move)
        {
            unityInitCore();
            // do job
            List<int> ret = new List<int>();
            {
                // doMove
                try
                {
                    // find new pos
                    IntPtr outMoveSquareListPtr;
                    int outMoveSquareListLength = international_draught_getMoveSquareList(move, out outMoveSquareListPtr);
                    // process result
                    if (outMoveSquareListLength > 0)
                    {
                        byte[] legalMovesBytes = new byte[outMoveSquareListLength];
                        {
                            Marshal.Copy(outMoveSquareListPtr, legalMovesBytes, 0, outMoveSquareListLength);
                            Marshal.FreeHGlobal(outMoveSquareListPtr);
                        }
                        // update
                        {
                            for (int i = 0; i < legalMovesBytes.Length; i += sizeof(int))
                            {
                                if (i + sizeof(int) <= legalMovesBytes.Length)
                                {
                                    ret.Add(BitConverter.ToInt32(legalMovesBytes, i));
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
                        Debug.LogError("Cannot find square: " + move);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
            if (ret.Count >= 4)
            {
                // Debug.LogError ("moveSquareList1: " + Common.printSquareList (ret));
                List<int> squares = new List<int>();
                {
                    // Add from
                    squares.Add(ret[0]);
                    // Add between
                    {
                        // Make between
                        List<int> betweens = new List<int>();
                        {
                            for (int i = 1; i < ret.Count - 1; i++)
                            {
                                betweens.Add(ret[i]);
                            }
                        }
                        // Add 
                        // Debug.LogError ("between Count: " + betweens.Count);
                        int count = betweens.Count;
                        while (count >= 2)
                        {
                            // lastSquare
                            int lastSquare = squares[squares.Count - 1];
                            int lastSquareX = Common.square_file(lastSquare);
                            int lastSquareY = Common.square_rank(lastSquare);
                            // find between
                            int between = -1;
                            {
                                int distance = int.MaxValue;
                                for (int i = 0; i < betweens.Count; i++)
                                {
                                    int check = betweens[i];
                                    // Check
                                    int checkX = Common.square_file(check);
                                    int checkY = Common.square_rank(check);
                                    if (Math.Abs(checkX - lastSquareX) == Math.Abs(checkY - lastSquareY))
                                    {
                                        if (Math.Abs(checkX - lastSquareX) < distance)
                                        {
                                            distance = Math.Abs(checkX - lastSquareX);
                                            between = check;
                                        }
                                    }
                                }
                                if (!betweens.Remove(between))
                                {
                                    Debug.LogError("Cannot find between: " + between);
                                }
                            }
                            if (between > 0)
                            {
                                // between
                                int squareX = Common.square_file(between);
                                int squareY = Common.square_rank(between);
                                // make new square
                                squares.Add(Common.square_make(squareX + 1 * (squareX > lastSquareX ? 1 : -1), squareY + (squareY > lastSquareY ? 1 : -1)));
                            }
                            else
                            {
                                Debug.LogError("why cannot find between: " + move);
                                break;
                            }
                            count--;
                        }
                    }
                    // Add to
                    squares.Add(ret[ret.Count - 1]);
                }
                // make ret
                {
                    ret.Clear();
                    ret.AddRange(squares);
                }
                // Debug.LogError ("moveSquareList: " + Common.printSquareList (ret));
            }
            else if (ret.Count == 3)
            {
                ret.RemoveAt(1);
            }
            return ret;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////// InitCore ////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport(GameType.BundleName)]
        private static extern void international_draught_initCore();

        public static bool isAlreadyInit = false;

        private static System.Object lockThis = new System.Object();

        public static void unityInitCore()
        {
            lock (lockThis)
            {
                if (!isAlreadyInit)
                {
                    isAlreadyInit = true;
                    // initCore
                    international_draught_initCore();
                    // set path
                    {
                        if (international_draught_setBBPath(GameType.MakeCorePath(GameType.NotAlwaysIn, "InternationalDraught", "data", "bb")))
                        {
                            Debug.Log("setBBPath success");
                        }
                        else
                        {
                            Debug.LogError("error, setBBPath fail");
                        }
                        if (international_draught_setBookPath(GameType.MakeCorePath(GameType.AlwaysIn, "InternationalDraught", "book")))
                        {
                            Debug.Log("setBookPath success");
                        }
                        else
                        {
                            Debug.LogError("error, setBBPath fail");
                        }
                        if (international_draught_setEvalPath(GameType.MakeCorePath(GameType.AlwaysIn, "InternationalDraught")))
                        {
                            Debug.Log("setEvalPath success");
                        }
                        else
                        {
                            Debug.LogError("error, setEvalPath fail");
                        }
                        /*#if UNITY_EDITOR
                                                {
                                                    if (international_draught_setBBPath(Global.DataPath + "/Plugins/Android/assets/" + GameType.NotAlwaysIn + "/InternationalDraught/data/bb"))
                                                    {
                                                        Debug.Log("setBBPath success");
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if (international_draught_setBookPath(Global.DataPath + "/Plugins/Android/assets/" + GameType.AlwaysIn + "/InternationalDraught/book"))
                                                    {
                                                        Debug.Log("setBookPath success");
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if (international_draught_setEvalPath(Global.DataPath + "/Plugins/Android/assets/" + GameType.AlwaysIn + "/InternationalDraught"))
                                                    {
                                                        Debug.Log("setEvalPath success");
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("error, setEvalPath fail");
                                                    }
                                                }
                        #elif UNITY_STANDALONE_OSX
                                                {
                                                    if (international_draught_setBBPath(Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.NotAlwaysIn + "/InternationalDraught/data/bb"))
                                                    {
                                                        Debug.Log("setBBPath success");
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if (international_draught_setBookPath(Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.AlwaysIn + "/InternationalDraught/book"))
                                                    {
                                                        Debug.Log("setBookPath success");
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if (international_draught_setEvalPath(Global.DataPath + "/Plugins/UnityNativeCore.bundle/Contents/Resources/" + GameType.AlwaysIn + "/InternationalDraught"))
                                                    {
                                                        Debug.Log("setEvalPath success");
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("error, setEvalPath fail");
                                                    }
                                                }
                        #elif UNITY_IPHONE
                                                {
                                                    if(international_draught_setBBPath(Global.DataPath+"/"+GameType.NotAlwaysIn+"/InternationalDraught/data/bb")){
                                                        Debug.Log("setBBPath success");
                                                    }else{
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if(international_draught_setBookPath(Global.DataPath+"/"+GameType.AlwaysIn+"/InternationalDraught/book")){
                                                        Debug.Log("setBookPath success");
                                                    }else{
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if(international_draught_setEvalPath(Global.DataPath+"/"+GameType.AlwaysIn+"/InternationalDraught")){
                                                        Debug.Log("setEvalPath success");
                                                    }else{
                                                        Debug.LogError("error, setEvalPath fail");
                                                    }
                                                }
                        #elif UNITY_ANDROID
                                                {
                                                    if(international_draught_setBBPath(GameType.NotAlwaysIn + "/InternationalDraught/data/bb")){
                                                        Debug.Log("setBBPath success");
                                                    }else{
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if(international_draught_setBookPath(GameType.AlwaysIn + "/InternationalDraught/book")){
                                                        Debug.Log("setBookPath success");
                                                    }else{
                                                        Debug.LogError("error, setBBPath fail");
                                                    }
                                                    if(international_draught_setEvalPath(GameType.AlwaysIn + "/InternationalDraught")){
                                                        Debug.Log("setEvalPath success");
                                                    }else{
                                                        Debug.LogError("error, setEvalPath fail");
                                                    }
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
    }
}