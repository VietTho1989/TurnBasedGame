using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Chess
{
	public class Core
	{
		
		public const bool CanCorrect = true;

		#region init Core

		[DllImport(GameType.BundleName)]
		private static extern void chess_initCore();

		public static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		public static void unityInitCore()
		{
			if (!isAlreadyInit) {
				lock (lockThis) {
					if (!isAlreadyInit) {
						isAlreadyInit = true;
						chess_initCore ();
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}

		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int chess_makePositionByFen (string strFen, bool isChess960, out IntPtr outChessPtr);

		public static Chess unityMakePositionByFen(string strFen, bool isChess960)
		{
			unityInitCore ();
			// do job
			Chess chess = new Chess();
			{
				// request native
				IntPtr outChessPtr;
				int outChessLength = chess_makePositionByFen(strFen, isChess960, out outChessPtr);
				// make byte array
				byte[] outChessBytes = new byte[outChessLength];
				{
					Marshal.Copy (outChessPtr, outChessBytes, 0, outChessLength);
					Marshal.FreeHGlobal (outChessPtr);
				}
				// parse
				Chess.parse(chess, outChessBytes, 0);
			}
			return chess;
		}

		#endregion

		#region positionToFen

		[DllImport(GameType.BundleName)]
		private static extern int chess_position_to_fen(IntPtr chessPtr, int chessLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityPositionToFen(Chess chess, bool canCorrect)
		{
			if (chess == null) {
				Debug.LogError ("chess null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] chessBytes = Chess.convertToBytes (chess, false);
				int chessLength = chessBytes.Length;
				IntPtr chessPtr = Marshal.AllocHGlobal (chessLength);
				// make request
				try {
					Marshal.Copy (chessBytes, 0, chessPtr, chessLength);
					// find outRet
					IntPtr outStrFenPtr;
					int outStrFenLength = chess_position_to_fen (chessPtr, chessLength, canCorrect, out outStrFenPtr);
					// process result
					{
						byte[] outStrFenBytes = new byte[outStrFenLength];
						{
							Marshal.Copy (outStrFenPtr, outStrFenBytes, 0, outStrFenLength);
							Marshal.FreeHGlobal (outStrFenPtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outStrFenBytes);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (chessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int chess_isGameFinish(IntPtr chessPtr, int chessLength, bool canCorrect);

		public static int unityIsGameFinish(Chess chess, bool canCorrect)
		{
			if(chess==null){
				Debug.LogError ("chess null");
				return 0;
			}
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] chessBytes = Chess.convertToBytes (chess);
				int chessLength = chessBytes.Length;
				IntPtr chessPtr = Marshal.AllocHGlobal(chessLength);
				try{
					Marshal.Copy(chessBytes, 0, chessPtr, chessLength);
					ret = chess_isGameFinish(chessPtr, chessLength, canCorrect);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(chessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int chess_letComputerThink (IntPtr chessPtr, int chessLength, bool canCorrect, int depth, int skillLevel, long duration);

		public static int unityLetComputerThink(Chess chess, bool canCorrect, int depth, int skillLevel, long duration)
		{
			if(chess==null){
				Debug.LogError ("chess null");
				return 0;
			}
			AIController.startThink ();
			unityInitCore ();
			// do job
			int move = 0;
			{
				byte[] chessBytes = Chess.convertToBytes (chess);
				int chessLength = chessBytes.Length;
				IntPtr chessPtr = Marshal.AllocHGlobal(chessLength);
				try{
					Marshal.Copy(chessBytes, 0, chessPtr, chessLength);
					move = chess_letComputerThink(chessPtr, chessLength, canCorrect, depth, skillLevel, duration);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(chessPtr);
				}
			}
			AIController.startEnd ();
			return move;
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool chess_isLegalMove(IntPtr chessPtr, int chessLength, bool canCorrect, int move);

		public static bool unityIsLegalMove(Chess chess, bool canCorrect, int move)
		{
			if(chess==null){
				Debug.LogError ("chess null");
				return false;
			}
			unityInitCore ();
			// do job
			bool ret = false;
			{
				byte[] chessBytes = Chess.convertToBytes (chess);
				int chessLength = chessBytes.Length;
				IntPtr chessPtr = Marshal.AllocHGlobal(chessLength);
				try{
					Marshal.Copy(chessBytes, 0, chessPtr, chessLength);
					ret = chess_isLegalMove(chessPtr, chessLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(chessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int chess_doMove(IntPtr chessPtr, int chessLength, bool canCorrect, int move, out IntPtr outChessPtr); 

		public static Chess unityDoMove(Chess chess, bool canCorrect, int move)
		{
			if(chess==null){
				Debug.LogError ("chess null");
				return new Chess();
			}
			unityInitCore ();
			// do job
			Chess newChess = new Chess();
			{
				// make parameter
				byte[] chessBytes = Chess.convertToBytes (chess);
				int chessLength = chessBytes.Length;
				IntPtr chessPtr = Marshal.AllocHGlobal(chessLength);
				// make request
				try{
					Marshal.Copy(chessBytes, 0, chessPtr, chessLength);
					// find outRet
					IntPtr outChessPtr;
					int outChessLength = chess_doMove(chessPtr, chessLength, canCorrect, move, out outChessPtr);
					// process result
					{
						byte[] outChessBytes = new byte[outChessLength];
						{
							Marshal.Copy(outChessPtr, outChessBytes, 0, outChessLength);
							Marshal.FreeHGlobal(outChessPtr);
						}
						// update
						Chess.parse(newChess, outChessBytes, 0);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(chessPtr);
				}
			}
			return newChess;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int chess_getLegalMoves(IntPtr chessPtr, int chessLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<ChessMove> unityGetLegalMoves(Chess chess, bool canCorrect)
		{
			if (chess == null) {
				Debug.LogError ("chess null");
				return new List<ChessMove> ();
			}
			unityInitCore ();
			// do job
			List<ChessMove> ret = new List<ChessMove> ();
			{
				// make paramter
				byte[] chessBytes = Chess.convertToBytes (chess);
				int chessLength = chessBytes.Length;
				IntPtr chessPtr = Marshal.AllocHGlobal (chessLength);
				// doMove
				try {
					Marshal.Copy (chessBytes, 0, chessPtr, chessLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = chess_getLegalMoves (chessPtr, chessLength, canCorrect, out outLegalMovesPtr);
					// process result
					if (outLegalMovesLength > 0) {
						byte[] legalMovesBytes = new byte[outLegalMovesLength];
						{
							Marshal.Copy (outLegalMovesPtr, legalMovesBytes, 0, outLegalMovesLength);
							Marshal.FreeHGlobal (outLegalMovesPtr);
						}
						// update
						{
							for(int i=0; i<legalMovesBytes.Length; i+=4){
								if(i+4<=legalMovesBytes.Length){
									ChessMove legalMove = new ChessMove();
									{
										legalMove.move.v = BitConverter.ToInt32(legalMovesBytes, i);
									}
									ret.Add(legalMove);
								}else{
									Debug.LogError("legalMovesBytes count error: "+legalMovesBytes.Length+"; "+i);
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find any legal moves: " + chess);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (chessPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}