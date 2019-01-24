using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RussianDraught
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_makePositionByFen (string strFen, out IntPtr outRussianDraughtPtr);

		public static RussianDraught unityMakePositionByFen(string strFen)
		{
			// init
			unityInitCore ();
			// do job
			RussianDraught russianDraught = new RussianDraught ();
			{
				// request native
				IntPtr outRussianDraughtPtr;
				int outRussianDraughtLength = russian_draught_makePositionByFen (strFen, out outRussianDraughtPtr);
				// make byte array
				byte[] outRussianDraughtBytes = new byte[outRussianDraughtLength];
				{
					Marshal.Copy (outRussianDraughtPtr, outRussianDraughtBytes, 0, outRussianDraughtLength);
					Marshal.FreeHGlobal (outRussianDraughtPtr);
				}
				// parse
				RussianDraught.parse (russianDraught, outRussianDraughtBytes, 0);
			}
			return russianDraught;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_isGameFinish(IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect);

		public static int unityIsGameFinish(RussianDraught russianDraught, bool canCorrect)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return 0;
			}
			// init
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					ret = russian_draught_isGameFinish (russianDraughtPtr, russianDraughtLength, canCorrect);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (russianDraughtPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_letComputerThink (IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect, System.Int32 timeLimit, System.Int32 pickBestMove, out IntPtr outMovePtr);

		public static RussianDraughtMove unityLetComputerThink(RussianDraught russianDraught, bool canCorrect, System.Int32 timeLimit, System.Int32 pickBestMove)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return new RussianDraughtMove ();
			}
			AIController.startThink ();
			// init
			unityInitCore ();
			// do job
			RussianDraughtMove move = new RussianDraughtMove ();
			{
				// position
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					// request native
					IntPtr outMovePtr;
					int outMoveLength = russian_draught_letComputerThink (russianDraughtPtr, russianDraughtLength, canCorrect, timeLimit, pickBestMove, out outMovePtr);
					if(outMoveLength>0){
						// set move
						{
							byte[] outMoveByteArray = new byte[outMoveLength];
							{
								Marshal.Copy (outMovePtr, outMoveByteArray, 0, outMoveLength);
								Marshal.FreeHGlobal (outMovePtr);
							}
							// convert to moveByteArray to move
							RussianDraughtMove.parse (move, outMoveByteArray, 0);
						}
					}else{
						Debug.LogError("Don't have move length");
						move = null;
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (russianDraughtPtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool russian_draught_isLegalMove(IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect, IntPtr movePtr, int moveLength);

		public static bool unityIsLegalMove(RussianDraught russianDraught, bool canCorrect, RussianDraughtMove move)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return false;
			}
			// init
			unityInitCore ();
			// do job
			bool ret = false;
			{
				// position
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				// move
				byte[] moveBytes = RussianDraughtMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					ret = russian_draught_isLegalMove (russianDraughtPtr, russianDraughtLength, canCorrect, movePtr, moveLength);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (russianDraughtPtr);
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_doMove(IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect, IntPtr movePtr, int moveLength, out IntPtr outRussianDraughtPtr);

		public static RussianDraught unityDoMove(RussianDraught russianDraught, bool canCorrect, RussianDraughtMove move)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return new RussianDraught ();
			}
			// init
			unityInitCore ();
			// do job
			RussianDraught newRussianDraught = new RussianDraught ();
			{
				// make parameter position
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				// make parameter move
				byte[] moveBytes = RussianDraughtMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				// do move
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					// find outRet
					IntPtr outRussianDraughtPtr;
					int outRussianDraughtLength = russian_draught_doMove (russianDraughtPtr, russianDraughtLength, canCorrect, movePtr, moveLength, out outRussianDraughtPtr);
					// process result
					{
						byte[] outRussianDraughtBytes = new byte[outRussianDraughtLength];
						{
							Marshal.Copy (outRussianDraughtPtr, outRussianDraughtBytes, 0, outRussianDraughtLength);
							Marshal.FreeHGlobal (outRussianDraughtPtr);
						}
						// update
						RussianDraught.parse (newRussianDraught, outRussianDraughtBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (russianDraughtPtr);
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return newRussianDraught;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_getLegalMoves(IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<RussianDraughtMove> unityGetLegalMoves(RussianDraught russianDraught, bool canCorrect)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return new List<RussianDraughtMove> ();
			}
			unityInitCore ();
			// do job
			List<RussianDraughtMove> ret = new List<RussianDraughtMove> ();
			{
				// make paramter
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				// doMove
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = russian_draught_getLegalMoves (russianDraughtPtr, russianDraughtLength, canCorrect, out outLegalMovesPtr);
					// process result
					if (outLegalMovesLength > 0) {
						byte[] legalMovesBytes = new byte[outLegalMovesLength];
						{
							Marshal.Copy (outLegalMovesPtr, legalMovesBytes, 0, outLegalMovesLength);
							Marshal.FreeHGlobal (outLegalMovesPtr);
						}
						// update
						{
							int russianDraughtMoveSize = 36;
							for (int i = 0; i < legalMovesBytes.Length; i += russianDraughtMoveSize) {
								if (i + russianDraughtMoveSize <= legalMovesBytes.Length) {
									RussianDraughtMove legalMove = new RussianDraughtMove ();
									{
										RussianDraughtMove.parse (legalMove, legalMovesBytes, i);
									}
									ret.Add (legalMove);
								} else {
									Debug.LogError ("legalMovesBytes count error: " + legalMovesBytes.Length + "; " + i);
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find any legal moves: " + russianDraught);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (russianDraughtPtr);
				}
			}
			return ret;
		}

		#endregion

		#region printPosition

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_printPosition(IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(RussianDraught russianDraught, bool canCorrect)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				// make request
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = russian_draught_printPosition (russianDraughtPtr, russianDraughtLength, canCorrect, out outStrPositionPtr);
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
					Marshal.FreeHGlobal (russianDraughtPtr);
				}
			}
			return ret;
		}

		#endregion

		#region printMove

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_printMove (IntPtr movePtr, int moveLength, bool canCorrect, out IntPtr outStrMovePtr);

		public static string unityGetStrMove(RussianDraughtMove move, bool canCorrect)
		{
			if (move == null) {
				Debug.LogError ("move null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] moveBytes = RussianDraughtMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				// make request
				try {
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					// find outRet
					IntPtr outStrMovePtr;
					int outStrMoveLength = russian_draught_printMove (movePtr, moveLength, canCorrect, out outStrMovePtr);
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
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return ret;
		}

		#endregion

		#region initCore

		[DllImport(GameType.BundleName)]
		private static extern void russian_draught_initCore();

		private static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		public static void unityInitCore()
		{
			if (!isAlreadyInit) {
				lock (lockThis) {
					if (!isAlreadyInit) {
						isAlreadyInit = true;
						russian_draught_initCore ();
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}

		#endregion

		#region positionToFen

		[DllImport(GameType.BundleName)]
		private static extern int russian_draught_position_to_fen(IntPtr russianDraughtPtr, int russianDraughtLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityPositionToFen(RussianDraught russianDraught, bool canCorrect)
		{
			if (russianDraught == null) {
				Debug.LogError ("russianDraught null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] russianDraughtBytes = RussianDraught.convertToBytes (russianDraught, false);
				int russianDraughtLength = russianDraughtBytes.Length;
				IntPtr russianDraughtPtr = Marshal.AllocHGlobal (russianDraughtLength);
				// make request
				try {
					Marshal.Copy (russianDraughtBytes, 0, russianDraughtPtr, russianDraughtLength);
					// find outRet
					IntPtr outStrFenPtr;
					int outStrFenLength = russian_draught_position_to_fen (russianDraughtPtr, russianDraughtLength, canCorrect, out outStrFenPtr);
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
					Marshal.FreeHGlobal (russianDraughtPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}