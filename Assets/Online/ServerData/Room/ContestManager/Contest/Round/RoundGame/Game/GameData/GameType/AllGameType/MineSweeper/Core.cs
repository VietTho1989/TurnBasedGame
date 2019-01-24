using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MineSweeper
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region makeDefaultPosition

		[DllImport(GameType.BundleName)]
		private static extern int mine_sweeper_makeDefaultPosition (int N, int M, int K, out IntPtr outMineSweeperPtr);

		public static MineSweeper unityMakeDefaultPosition(int N, int M, int K)
		{
			// init
			unityInitCore ();
			// do job
			MineSweeper mineSweeper = new MineSweeper ();
			{
				// request native
				IntPtr outMineSweeperPtr;
				int newMineSweeperLength = mine_sweeper_makeDefaultPosition (N, M, K, out outMineSweeperPtr);
				// make byte array
				byte[] outMineSweeperBytes = new byte[newMineSweeperLength];
				{
					Marshal.Copy (outMineSweeperPtr, outMineSweeperBytes, 0, newMineSweeperLength);
					Marshal.FreeHGlobal (outMineSweeperPtr);
				}
				// parse
				MineSweeper.parse (mineSweeper, outMineSweeperBytes, 0);
			}
			return mineSweeper;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int mine_sweeper_isGameFinish(IntPtr mineSweeperPtr, int length, bool canCorrect);

		public static int unityIsGameFinish(MineSweeper mineSweeper, bool canCorrect)
		{
			if (mineSweeper == null) {
				Debug.LogError ("positionBytes null");
				return 0;
			}
			// init
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] mineSweeperBytes = MineSweeper.convertToBytes (mineSweeper);
				int length = mineSweeperBytes.Length;
				IntPtr mineSweeperPtr = Marshal.AllocHGlobal (length);
				try {
					Marshal.Copy (mineSweeperBytes, 0, mineSweeperPtr, length);
					ret = mine_sweeper_isGameFinish (mineSweeperPtr, length, canCorrect);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (mineSweeperPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int mine_sweeper_letComputerThink(IntPtr mineSweeperPtr, int length, bool canCorrect, int firstMoveType);

		public static int unityLetComputerThink(MineSweeper mineSweeper, bool canCorrect, int firstMoveType)
		{
			if (mineSweeper == null) {
				Debug.LogError ("positionBytes null");
				return -1;
			}
			AIController.startThink ();
			// init
			unityInitCore ();
			// do job
			int move = -1;
			{
				// position
				byte[] positionBytes = MineSweeper.convertToBytes(mineSweeper);
				int length = positionBytes.Length;
				IntPtr mineSweeperPtr = Marshal.AllocHGlobal (length);
				try {
					Marshal.Copy (positionBytes, 0, mineSweeperPtr, length);
					move = mine_sweeper_letComputerThink (mineSweeperPtr, length, canCorrect, firstMoveType);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal(mineSweeperPtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool mine_sweeper_isLegalMove(IntPtr mineSweeperPtr, int length, bool canCorrect, int move);

		public static bool unityIsLegalMove(MineSweeper mineSweeper, bool canCorrect, int move)
		{
			if (mineSweeper == null) {
				Debug.LogError ("positionBytes null");
				return false;
			}
			// init
			unityInitCore ();
			// do job
			bool ret = false;
			{
				// position
				byte[] mineSweeperBytes = MineSweeper.convertToBytes (mineSweeper);
				int mineSweeperLength = mineSweeperBytes.Length;
				IntPtr mineSweeperPtr = Marshal.AllocHGlobal (mineSweeperLength);
				// check legal move
				try {
					Marshal.Copy (mineSweeperBytes, 0, mineSweeperPtr, mineSweeperLength);
					ret = mine_sweeper_isLegalMove (mineSweeperPtr, mineSweeperLength, canCorrect, move);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (mineSweeperPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int mine_sweeper_doMove (IntPtr mineSweeperPtr, int mineSweeperLength, bool canCorrect, int move, out IntPtr outMineSweeperPtr);

		public static MineSweeper unityDoMove(MineSweeper mineSweeper, bool canCorrect, int move)
		{
			if (mineSweeper == null) {
				Debug.LogError ("mineSweeper null");
				return new MineSweeper ();
			}
			// init
			unityInitCore ();
			// do job
			MineSweeper newMineSweeper = new MineSweeper ();
			{
				// make parameter
				byte[] mineSweeperBytes = MineSweeper.convertToBytes (mineSweeper);
				int mineSweeperLength = mineSweeperBytes.Length;
				IntPtr mineSweeperPtr = Marshal.AllocHGlobal (mineSweeperLength);
				// do move
				try {
					Marshal.Copy (mineSweeperBytes, 0, mineSweeperPtr, mineSweeperLength);
					// find outRet
					IntPtr outMineSweeperPtr;
					int newMineSweeperLength = mine_sweeper_doMove (mineSweeperPtr, mineSweeperLength, canCorrect, move, out outMineSweeperPtr);
					// process result
					{
						byte[] outMineSweeperBytes = new byte[newMineSweeperLength];
						{
							Marshal.Copy (outMineSweeperPtr, outMineSweeperBytes, 0, newMineSweeperLength);
							Marshal.FreeHGlobal (outMineSweeperPtr);
						}
						// update
						MineSweeper.parse (newMineSweeper, outMineSweeperBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (mineSweeperPtr);
				}
			}
			return newMineSweeper;
		}

		#endregion

		#region printPosition

		[DllImport(GameType.BundleName)]
		private static extern int mine_sweeper_printPosition(IntPtr mineSweeperPtr, int mineSweeperLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(MineSweeper mineSweeper, bool canCorrect)
		{
			if (mineSweeper == null) {
				Debug.LogError ("mineSweeper null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] mineSweeperBytes = MineSweeper.convertToBytes (mineSweeper);
				int mineSweeperLength = mineSweeperBytes.Length;
				IntPtr mineSweeperPtr = Marshal.AllocHGlobal (mineSweeperLength);
				// make request
				try {
					Marshal.Copy (mineSweeperBytes, 0, mineSweeperPtr, mineSweeperLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = mine_sweeper_printPosition (mineSweeperPtr, mineSweeperLength, canCorrect, out outStrPositionPtr);
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
					Marshal.FreeHGlobal (mineSweeperPtr);
				}
			}
			return ret;
		}

		#endregion

		//////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////// InitCore ////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////
		 
		public static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		public static void unityInitCore()
		{
			lock (lockThis) {
				if (!isAlreadyInit) {
					isAlreadyInit = true;
				}
			}
		}

	}
}