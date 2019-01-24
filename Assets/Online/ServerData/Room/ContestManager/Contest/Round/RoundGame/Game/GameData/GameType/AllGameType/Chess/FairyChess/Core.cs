using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FairyChess
{
	public class Core
	{
		public const bool CanCorrect = true;

		#region init Core

		[DllImport(GameType.BundleName)]
		private static extern void fairy_chess_initCore();

		public static bool isAlreadyInit = false;

		private static System.Object lockFairyChessInit = new System.Object ();

		public static void unityInitCore()
		{
			if (!isAlreadyInit) {
				lock (lockFairyChessInit) {
					if (!isAlreadyInit) {
						isAlreadyInit = true;
						fairy_chess_initCore ();
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}

		#endregion

		#region getStrPosition

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_getStrPosition(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(FairyChess fairyChess, bool canCorrect)
		{
			if (fairyChess == null) {
				Debug.LogError ("fairyChess null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal (fairyChessLength);
				// make request
				try {
					Marshal.Copy (fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = fairy_chess_getStrPosition (fairyChessPtr, fairyChessLength, canCorrect, out outStrPositionPtr);
					// process result
					{
						byte[] outStrPositionBytes = new byte[outStrPositionLength];
						{
							Marshal.Copy (outStrPositionPtr, outStrPositionBytes, 0, outStrPositionLength);
							Marshal.FreeHGlobal (outStrPositionPtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outStrPositionBytes);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (fairyChessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region getPositionFen

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_getPositionFen(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityGetPositionFen(FairyChess fairyChess, bool canCorrect)
		{
			if(fairyChess==null){
				Debug.LogError ("fairyChess null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess, false);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal(fairyChessLength);
				// make request
				try{
					Marshal.Copy(fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					// find outRet
					IntPtr outFenPtr;
					int outFenLength = fairy_chess_getPositionFen(fairyChessPtr, fairyChessLength, canCorrect, out outFenPtr);
					// process result
					{
						byte[] outFenBytes = new byte[outFenLength];
						{
							Marshal.Copy(outFenPtr, outFenBytes, 0, outFenLength);
							Marshal.FreeHGlobal(outFenPtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outFenBytes);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(fairyChessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region getStrMove

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_getStrMove(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, int move, out IntPtr outStrMovePtr);

		public static string unityGetStrMove(FairyChess fairyChess, bool canCorrect, int move)
		{
			if (fairyChess == null) {
				Debug.LogError ("fairyChess null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal (fairyChessLength);
				// make request
				try {
					Marshal.Copy (fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					// find outRet
					IntPtr outStrMovePtr;
					int outStrMoveLength = fairy_chess_getStrMove (fairyChessPtr, fairyChessLength, canCorrect, move, out outStrMovePtr);
					// process result
					{
						byte[] outStrMoveBytes = new byte[outStrMoveLength];
						{
							Marshal.Copy (outStrMovePtr, outStrMoveBytes, 0, outStrMoveLength);
							Marshal.FreeHGlobal (outStrMovePtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outStrMoveBytes);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (fairyChessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_makePositionByFen (Common.VariantType variantType, string strFen, bool isChess960, out IntPtr outFairyChessPtr);

		public static FairyChess unityMakePositionByFen(Common.VariantType variantType, string strFen, bool isChess960)
		{
			unityInitCore ();
			// do job
			FairyChess fairyChess = new FairyChess();
			{
				// request native
				IntPtr outFairyChessPtr;
				int outFairyChessLength = fairy_chess_makePositionByFen(variantType, strFen, isChess960, out outFairyChessPtr);
				// make byte array
				byte[] outFairyChessBytes = new byte[outFairyChessLength];
				{
					Marshal.Copy (outFairyChessPtr, outFairyChessBytes, 0, outFairyChessLength);
					Marshal.FreeHGlobal (outFairyChessPtr);
				}
				// parse
				FairyChess.parse(fairyChess, outFairyChessBytes, 0);
			}
			return fairyChess;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_isGameFinish(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect);

		public static int unityIsGameFinish(FairyChess fairyChess, bool canCorrect)
		{
			if(fairyChess==null){
				Debug.LogError ("fairyChess null");
				return 0;
			}
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal(fairyChessLength);
				try{
					Marshal.Copy(fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					ret = fairy_chess_isGameFinish(fairyChessPtr, fairyChessLength, canCorrect);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(fairyChessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_letComputerThink (IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, int depth, int skillLevel, long duration);

		public static int unityLetComputerThink(FairyChess fairyChess, bool canCorrect, int depth, int skillLevel, long duration)
		{
			if(fairyChess==null){
				Debug.LogError ("fairyChess null");
				return 0;
			}
			AIController.startThink ();
			unityInitCore ();
			// do job
			int move = 0;
			{
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal(fairyChessLength);
				try{
					Marshal.Copy(fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					move = fairy_chess_letComputerThink(fairyChessPtr, fairyChessLength, canCorrect, depth, skillLevel, duration);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(fairyChessPtr);
				}
			}
			AIController.startEnd ();
			return move;
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool fairy_chess_isLegalMove(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, int move);

		public static bool unityIsLegalMove(FairyChess fairyChess, bool canCorrect, int move)
		{
			if(fairyChess==null){
				Debug.LogError ("fairyChess null");
				return false;
			}
			unityInitCore ();
			// do job
			bool ret = false;
			{
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal(fairyChessLength);
				try{
					Marshal.Copy(fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					ret = fairy_chess_isLegalMove(fairyChessPtr, fairyChessLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(fairyChessPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_doMove(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, int move, out IntPtr outFairyChessPtr); 

		public static FairyChess unityDoMove(FairyChess fairyChess, bool canCorrect, int move)
		{
			if(fairyChess==null){
				Debug.LogError ("fairyChess null");
				return new FairyChess();
			}
			unityInitCore ();
			// do job
			FairyChess newFairyChess = new FairyChess();
			{
				// make parameter
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal(fairyChessLength);
				// make request
				try{
					Marshal.Copy(fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					// find outRet
					IntPtr outFairyChessPtr;
					int outFairyChessLength = fairy_chess_doMove(fairyChessPtr, fairyChessLength, canCorrect, move, out outFairyChessPtr);
					// process result
					{
						byte[] outFairyChessBytes = new byte[outFairyChessLength];
						{
							Marshal.Copy(outFairyChessPtr, outFairyChessBytes, 0, outFairyChessLength);
							Marshal.FreeHGlobal(outFairyChessPtr);
						}
						// update
						FairyChess.parse(newFairyChess, outFairyChessBytes, 0);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(fairyChessPtr);
				}
			}
			return newFairyChess;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int fairy_chess_getLegalMoves(IntPtr fairyChessPtr, int fairyChessLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<FairyChessMove> unityGetLegalMoves(FairyChess fairyChess, bool canCorrect)
		{
			if (fairyChess == null) {
				Debug.LogError ("fairyChess null");
				return new List<FairyChessMove> ();
			}
			unityInitCore ();
			// do job
			List<FairyChessMove> ret = new List<FairyChessMove> ();
			{
				// make paramter
				byte[] fairyChessBytes = FairyChess.convertToBytes (fairyChess);
				int fairyChessLength = fairyChessBytes.Length;
				IntPtr fairyChessPtr = Marshal.AllocHGlobal (fairyChessLength);
				// doMove
				try {
					Marshal.Copy (fairyChessBytes, 0, fairyChessPtr, fairyChessLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = fairy_chess_getLegalMoves (fairyChessPtr, fairyChessLength, canCorrect, out outLegalMovesPtr);
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
									FairyChessMove legalMove = new FairyChessMove();
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
						Debug.LogError ("Cannot find any legal moves: " + fairyChess);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (fairyChessPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}