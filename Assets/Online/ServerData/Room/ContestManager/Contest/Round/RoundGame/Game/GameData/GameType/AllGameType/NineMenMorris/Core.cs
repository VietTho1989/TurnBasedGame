using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NineMenMorris
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region initCore

		private static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		public static void unityInitCore()
		{
			if (!isAlreadyInit) {
				lock (lockThis) {
					if (!isAlreadyInit) {
						isAlreadyInit = true;
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}

		#endregion

		#region makeDefaultPosition

		[DllImport(GameType.BundleName)]
		private static extern int nmm_makeDefaultPosition (out IntPtr outNineMenMorrisDraughtPtr);

		public static NineMenMorris unityMakeDefaultPosition()
		{
			// init
			unityInitCore ();
			// do job
			NineMenMorris nineMenMorris = new NineMenMorris ();
			{
				// request native
				IntPtr outNineMenMorrisPtr;
				int outNineMenMorrisLength = nmm_makeDefaultPosition (out outNineMenMorrisPtr);
				// make byte array
				byte[] outNineMenMorrisBytes = new byte[outNineMenMorrisLength];
				{
					Marshal.Copy (outNineMenMorrisPtr, outNineMenMorrisBytes, 0, outNineMenMorrisLength);
					Marshal.FreeHGlobal (outNineMenMorrisPtr);
				}
				// parse
				NineMenMorris.parse (nineMenMorris, outNineMenMorrisBytes, 0);
			}
			return nineMenMorris;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int nmm_isGameFinish(IntPtr nineMenMorrisPtr, int nineMenMorrisLength, bool canCorrect);

		public static int unityIsGameFinish(NineMenMorris nineMenMorris, bool canCorrect)
		{
			if (nineMenMorris == null) {
				Debug.LogError ("nineMenMorris null");
				return 0;
			}
			// init
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] nineMenMorrisBytes = NineMenMorris.convertToBytes (nineMenMorris);
				int nineMenMorrisLength = nineMenMorrisBytes.Length;
				IntPtr nineMenMorrisPtr = Marshal.AllocHGlobal (nineMenMorrisLength);
				try {
					Marshal.Copy (nineMenMorrisBytes, 0, nineMenMorrisPtr, nineMenMorrisLength);
					ret = nmm_isGameFinish (nineMenMorrisPtr, nineMenMorrisLength, canCorrect);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (nineMenMorrisPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int nmm_letComputerThink (IntPtr nineMenMorrisPtr, int nineMenMorrisLength, bool canCorrect, int MaxNormal, int MaxPositioning, int MaxBlackAndWhite3, int MaxBlackOrWhite3, int pickBestMove, out IntPtr outMovePtr);

		public static NineMenMorrisMove unityLetComputerThink(NineMenMorris nineMenMorris, bool canCorrect, int MaxNormal, int MaxPositioning, int MaxBlackAndWhite3, int MaxBlackOrWhite3, int pickBestMove)
		{
			if (nineMenMorris == null) {
				Debug.LogError ("nineMenMorris null");
				return new NineMenMorrisMove ();
			}
			AIController.startThink ();
			// init
			unityInitCore ();
			// do job
			NineMenMorrisMove move = new NineMenMorrisMove ();
			{
				// position
				byte[] nineMenMorrisBytes = NineMenMorris.convertToBytes (nineMenMorris);
				int nineMenMorrisLength = nineMenMorrisBytes.Length;
				IntPtr nineMenMorrisPtr = Marshal.AllocHGlobal (nineMenMorrisLength);
				try {
					Marshal.Copy (nineMenMorrisBytes, 0, nineMenMorrisPtr, nineMenMorrisLength);
					// request native
					IntPtr outMovePtr;
					int outMoveLength = nmm_letComputerThink (nineMenMorrisPtr, nineMenMorrisLength, canCorrect, MaxNormal, MaxPositioning, MaxBlackAndWhite3, MaxBlackOrWhite3, pickBestMove, out outMovePtr);
					if (outMoveLength > 0) {
						// set move
						{
							byte[] outMoveByteArray = new byte[outMoveLength];
							{
								Marshal.Copy (outMovePtr, outMoveByteArray, 0, outMoveLength);
								Marshal.FreeHGlobal (outMovePtr);
							}
							// convert to moveByteArray to move
							NineMenMorrisMove.parse (move, outMoveByteArray, 0);
						}
					} else {
						Debug.LogError ("Don't have move length");
						move = null;
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (nineMenMorrisPtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool nmm_isLegalMove(IntPtr nineMenMorrisPtr, int nineMenMorrisLength, bool canCorrect, IntPtr movePtr, int moveLength);

		public static bool unityIsLegalMove(NineMenMorris nineMenMorris, bool canCorrect, NineMenMorrisMove move)
		{
			if (nineMenMorris == null) {
				Debug.LogError ("nineMenMorris null");
				return false;
			}
			// init
			unityInitCore ();
			// do job
			bool ret = false;
			{
				// position
				byte[] nineMenMorrisBytes = NineMenMorris.convertToBytes (nineMenMorris);
				int nineMenMorrisLength = nineMenMorrisBytes.Length;
				IntPtr nineMenMorrisPtr = Marshal.AllocHGlobal (nineMenMorrisLength);
				// move
				byte[] moveBytes = NineMenMorrisMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				try {
					Marshal.Copy (nineMenMorrisBytes, 0, nineMenMorrisPtr, nineMenMorrisLength);
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					ret = nmm_isLegalMove (nineMenMorrisPtr, nineMenMorrisLength, canCorrect, movePtr, moveLength);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (nineMenMorrisPtr);
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int nmm_doMove(IntPtr nineMenMorrisPtr, int nineMenMorrisLength, bool canCorrect, IntPtr movePtr, int moveLength, out IntPtr outNineMenMorrisPtr);

		public static NineMenMorris unityDoMove(NineMenMorris nineMenMorris, bool canCorrect, NineMenMorrisMove move)
		{
			if (nineMenMorris == null) {
				Debug.LogError ("nineMenMorris null");
				return new NineMenMorris ();
			}
			// init
			unityInitCore ();
			// do job
			NineMenMorris newNineMenMorris = new NineMenMorris ();
			{
				// make parameter position
				byte[] nineMenMorrisBytes = NineMenMorris.convertToBytes (nineMenMorris);
				int nineMenMorrisLength = nineMenMorrisBytes.Length;
				IntPtr nineMenMorrisPtr = Marshal.AllocHGlobal (nineMenMorrisLength);
				// make parameter move
				byte[] moveBytes = NineMenMorrisMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				// do move
				try {
					Marshal.Copy (nineMenMorrisBytes, 0, nineMenMorrisPtr, nineMenMorrisLength);
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					// find outRet
					IntPtr outNineMenMorrisPtr;
					int outNineMenMorrisLength = nmm_doMove (nineMenMorrisPtr, nineMenMorrisLength, canCorrect, movePtr, moveLength, out outNineMenMorrisPtr);
					// process result
					{
						byte[] outNineMenMorrisBytes = new byte[outNineMenMorrisLength];
						{
							Marshal.Copy (outNineMenMorrisPtr, outNineMenMorrisBytes, 0, outNineMenMorrisLength);
							Marshal.FreeHGlobal (outNineMenMorrisPtr);
						}
						// update
						NineMenMorris.parse (newNineMenMorris, outNineMenMorrisBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (nineMenMorrisPtr);
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return newNineMenMorris;
		}

		#endregion

		#region getLegalMove

		[DllImport(GameType.BundleName)]
		private static extern int nmm_getLegalMoves(IntPtr nineMenMorrisPtr, int nineMenMorrisLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<NineMenMorrisMove> unityGetLegalMoves(NineMenMorris nineMenMorris, bool canCorrect)
		{
			if (nineMenMorris == null) {
				Debug.LogError ("nineMenMorris null");
				return new List<NineMenMorrisMove> ();
			}
			unityInitCore ();
			// do job
			List<NineMenMorrisMove> ret = new List<NineMenMorrisMove> ();
			{
				// make paramter
				byte[] nineMenMorrisBytes = NineMenMorris.convertToBytes (nineMenMorris);
				int nineMenMorrisLength = nineMenMorrisBytes.Length;
				IntPtr nineMenMorrisPtr = Marshal.AllocHGlobal (nineMenMorrisLength);
				// doMove
				try {
					Marshal.Copy (nineMenMorrisBytes, 0, nineMenMorrisPtr, nineMenMorrisLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = nmm_getLegalMoves (nineMenMorrisPtr, nineMenMorrisLength, canCorrect, out outLegalMovesPtr);
					// process result
					if (outLegalMovesLength > 0) {
						byte[] legalMovesBytes = new byte[outLegalMovesLength];
						{
							Marshal.Copy (outLegalMovesPtr, legalMovesBytes, 0, outLegalMovesLength);
							Marshal.FreeHGlobal (outLegalMovesPtr);
						}
						// update
						{
							int nineMenMorrisMoveSize = NineMenMorrisMove.GetSize ();
							for (int i = 0; i < legalMovesBytes.Length; i += nineMenMorrisMoveSize) {
								if (i + nineMenMorrisMoveSize <= legalMovesBytes.Length) {
									NineMenMorrisMove legalMove = new NineMenMorrisMove ();
									{
										NineMenMorrisMove.parse (legalMove, legalMovesBytes, i);
									}
									ret.Add (legalMove);
								} else {
									Debug.LogError ("legalMovesBytes count error: " + legalMovesBytes.Length + "; " + i);
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find any legal moves: " + nineMenMorris);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (nineMenMorrisPtr);
				}
			}
			return ret;
		}

		#endregion

		#region printPosition

		[DllImport(GameType.BundleName)]
		private static extern int nmm_printPosition(IntPtr nineMenMorrisPtr, int nineMenMorrisLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(NineMenMorris nineMenMorris, bool canCorrect)
		{
			if (nineMenMorris == null) {
				Debug.LogError ("nineMenMorris null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] nineMenMorrisBytes = NineMenMorris.convertToBytes (nineMenMorris);
				int nineMenMorrisLength = nineMenMorrisBytes.Length;
				IntPtr nineMenMorrisPtr = Marshal.AllocHGlobal (nineMenMorrisLength);
				// make request
				try {
					Marshal.Copy (nineMenMorrisBytes, 0, nineMenMorrisPtr, nineMenMorrisLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = nmm_printPosition (nineMenMorrisPtr, nineMenMorrisLength, canCorrect, out outStrPositionPtr);
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
					Marshal.FreeHGlobal (nineMenMorrisPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}