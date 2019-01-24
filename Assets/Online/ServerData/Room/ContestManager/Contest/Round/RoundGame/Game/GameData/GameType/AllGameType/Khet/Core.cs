using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Khet
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region init Core

		[DllImport(GameType.BundleName)]
		private static extern void khet_initCore();

		public static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		public static void unityInitCore()
		{
			if (!isAlreadyInit) {
				lock (lockThis) {
					if (!isAlreadyInit) {
						isAlreadyInit = true;
						khet_initCore ();
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}


		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int khet_makePositionByFen (string strFen, out IntPtr outKhetPtr);

		public static Khet unityMakePositionByFen(string strFen)
		{
			unityInitCore ();
			// do job
			Khet khet = new Khet ();
			{
				// request native
				IntPtr outKhetPtr;
				int outKhetLength = khet_makePositionByFen (strFen, out outKhetPtr);
				// make byte array
				byte[] outKhetBytes = new byte[outKhetLength];
				{
					Marshal.Copy (outKhetPtr, outKhetBytes, 0, outKhetLength);
					Marshal.FreeHGlobal (outKhetPtr);
				}
				// parse
				Khet.parse (khet, outKhetBytes, 0);
			}
			return khet;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int khet_isGameFinish(IntPtr khetPtr, int khetLength, bool canCorrect);

		public static int unityIsGameFinish(Khet khet, bool canCorrect)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return 0;
			}
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					ret = khet_isGameFinish (khetPtr, khetLength, canCorrect);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern uint khet_letComputerThink (IntPtr khetPtr, int khetLength, bool canCorrect, bool infinite, int moveTime, int depth, int pickBestMove);

		public static uint unityLetComputerThink(Khet khet, bool canCorrect, bool infinite, int moveTime, int depth, int pickBestMove)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return 0;
			}
			Debug.LogError ("unityLetComputerThink: " + infinite + ", " + moveTime + ", " + pickBestMove);
			AIController.startThink ();
			unityInitCore ();
			// do job
			uint move = 0;
			{
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					move = khet_letComputerThink (khetPtr, khetLength, canCorrect, infinite, moveTime, depth, pickBestMove);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			AIController.startEnd ();
			return move;
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool khet_isLegalMove(IntPtr khetPtr, int khetLength, bool canCorrect, uint move);

		public static bool unityIsLegalMove(Khet khet, bool canCorrect, uint move)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return false;
			}
			unityInitCore ();
			// do job
			bool ret = false;
			{
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					ret = khet_isLegalMove (khetPtr, khetLength, canCorrect, move);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int khet_doMove(IntPtr khetPtr, int khetLength, bool canCorrect, uint move, out IntPtr outKhetPtr); 

		public static Khet unityDoMove(Khet khet, bool canCorrect, uint move)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return new Khet ();
			}
			unityInitCore ();
			// do job
			Khet newKhet = new Khet ();
			{
				// make parameter
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				// make request
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					// find outRet
					IntPtr outKhetPtr;
					int outKhetLength = khet_doMove (khetPtr, khetLength, canCorrect, move, out outKhetPtr);
					// process result
					{
						byte[] outKhetBytes = new byte[outKhetLength];
						{
							Marshal.Copy (outKhetPtr, outKhetBytes, 0, outKhetLength);
							Marshal.FreeHGlobal (outKhetPtr);
						}
						// update
						Khet.parse (newKhet, outKhetBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return newKhet;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int khet_getLegalMoves(IntPtr khetPtr, int khetLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<KhetMove> unityGetLegalMoves(Khet khet, bool canCorrect)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return new List<KhetMove> ();
			}
			unityInitCore ();
			// do job
			List<KhetMove> ret = new List<KhetMove> ();
			{
				// make paramter
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				// doMove
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = khet_getLegalMoves (khetPtr, khetLength, canCorrect, out outLegalMovesPtr);
					// process result
					if (outLegalMovesLength > 0) {
						byte[] legalMovesBytes = new byte[outLegalMovesLength];
						{
							Marshal.Copy (outLegalMovesPtr, legalMovesBytes, 0, outLegalMovesLength);
							Marshal.FreeHGlobal (outLegalMovesPtr);
						}
						// update
						{
							for (int i = 0; i < legalMovesBytes.Length; i += 4) {
								if (i + 4 <= legalMovesBytes.Length) {
									KhetMove legalMove = new KhetMove ();
									{
										legalMove.move.v = BitConverter.ToUInt32 (legalMovesBytes, i);
									}
									ret.Add (legalMove);
								} else {
									Debug.LogError ("legalMovesBytes count error: " + legalMovesBytes.Length + "; " + i);
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find any legal moves: " + khet);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}
			
		#endregion

		#region positionToFen

		[DllImport(GameType.BundleName)]
		private static extern int khet_position_to_fen(IntPtr khetPtr, int khetLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityPositionToFen(Khet khet, bool canCorrect)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] khetBytes = Khet.convertToBytes (khet, false);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				// make request
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					// find outRet
					IntPtr outStrFenPtr;
					int outStrFenLength = khet_position_to_fen (khetPtr, khetLength, canCorrect, out outStrFenPtr);
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
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}

		#endregion

		#region getStrPosition

		[DllImport(GameType.BundleName)]
		private static extern int khet_getStrPosition(IntPtr khetPtr, int khetLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(Khet khet, bool canCorrect)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				// make request
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = khet_getStrPosition (khetPtr, khetLength, canCorrect, out outStrPositionPtr);
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
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}

		#endregion

		#region getStrMove

		[DllImport(GameType.BundleName)]
		private static extern int khet_getStrMove(uint move, out IntPtr outStrMovePtr);

		public static string unityGetStrMove(uint move)
		{
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make request
				try {
					// find outRet
					IntPtr outStrMovePtr;
					int outStrPositionLength = khet_getStrMove (move, out outStrMovePtr);
					// process result
					{
						byte[] outStrPositionBytes = new byte[outStrPositionLength];
						{
							Marshal.Copy (outStrMovePtr, outStrPositionBytes, 0, outStrPositionLength);
							Marshal.FreeHGlobal (outStrMovePtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outStrPositionBytes);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					
				}
			}
			return ret;
		}

		#endregion

		#region get laser path

		[DllImport(GameType.BundleName)]
		private static extern int khet_getLaserPath(IntPtr khetPtr, int khetLength, bool canCorrect, out IntPtr outLaserPathPtr);

		public static int[] unityGetLaserPath(Khet khet, bool canCorrect)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return null;
			}
			unityInitCore ();
			// do job
			int[] ret = new int[2*Common.BoardArea];
			{
				// init
				{
					for (int i = 0; i < 2*Common.BoardArea; i++) {
						ret [i] = -1;
					}
				}
				// make paramter
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				// doMove
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					// find new pos
					IntPtr outLaserPathPtr;
					int outLaserPathLength = khet_getLaserPath (khetPtr, khetLength, canCorrect, out outLaserPathPtr);
					// process result
					if (outLaserPathLength > 0) {
						byte[] laserPathBytes = new byte[outLaserPathLength];
						{
							Marshal.Copy (outLaserPathPtr, laserPathBytes, 0, outLaserPathLength);
							Marshal.FreeHGlobal (outLaserPathPtr);
						}
						// update
						{
							int index = 0;
							for (int i = 0; i < laserPathBytes.Length; i += 4) {
								if (i + 4 <= laserPathBytes.Length) {
									if (index >= 0 && index < 2*Common.BoardArea) {
										ret [index] = BitConverter.ToInt32 (laserPathBytes, i);
										index++;
									} else {
										Debug.LogError ("index error: " + index);
									}
								} else {
									Debug.LogError ("laserPathBytes count error: " + laserPathBytes.Length + "; " + i);
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find laser path: " + khet);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}
			
		#endregion

		#region getMyLaserPath

		[DllImport(GameType.BundleName)]
		private static extern int khet_getMyLaserPath(IntPtr khetPtr, int khetLength, bool canCorrect, int player, out IntPtr outLaserPathPtr);

		public static List<int> unityGetMyLaserPath(Khet khet, bool canCorrect, Common.Player player)
		{
			if (khet == null) {
				Debug.LogError ("khet null");
				return new List<int>();
			}
			unityInitCore ();
			// do job
			List<int> ret = new List<int>();
			{
				// make paramter
				byte[] khetBytes = Khet.convertToBytes (khet);
				int khetLength = khetBytes.Length;
				IntPtr khetPtr = Marshal.AllocHGlobal (khetLength);
				// doMove
				try {
					Marshal.Copy (khetBytes, 0, khetPtr, khetLength);
					// find new pos
					IntPtr outLaserPathPtr;
					int outLaserPathLength = khet_getMyLaserPath (khetPtr, khetLength, canCorrect, (int)player, out outLaserPathPtr);
					// process result
					if (outLaserPathLength > 0) {
						byte[] laserPathBytes = new byte[outLaserPathLength];
						{
							Marshal.Copy (outLaserPathPtr, laserPathBytes, 0, outLaserPathLength);
							Marshal.FreeHGlobal (outLaserPathPtr);
						}
						// update
						{
							for (int i = 0; i < laserPathBytes.Length; i += 4) {
								if (i + 4 <= laserPathBytes.Length) {
									ret.Add(BitConverter.ToInt32 (laserPathBytes, i));
								} else {
									Debug.LogError ("laserPathBytes count error: " + laserPathBytes.Length + "; " + i);
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find laser path: " + khet);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (khetPtr);
				}
			}
			return ret;
		}

		#endregion

		// int32_t khet_getMyLaserPath(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t player, uint8_t* &outLaserPath);

	}
}