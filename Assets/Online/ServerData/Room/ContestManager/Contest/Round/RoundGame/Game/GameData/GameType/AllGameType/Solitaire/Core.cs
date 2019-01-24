using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Solitaire
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region initCore

		private static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		private static void unityInitCore()
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
		private static extern int solitaire_makeDefaultPosition (int drawCount, out IntPtr outSolitairePtr);

		public static Solitaire unityMakeDefaultPosition(int drawCount)
		{
			// init
			unityInitCore ();
			// do job
			Solitaire solitaire = new Solitaire();
			{
				// request native
				IntPtr outSolitairePtr;
				int outSolitaireLength = solitaire_makeDefaultPosition(drawCount, out outSolitairePtr);
				// make byte array
				byte[] outSolitaireBytes = new byte[outSolitaireLength];
				{
					Marshal.Copy (outSolitairePtr, outSolitaireBytes, 0, outSolitaireLength);
					Marshal.FreeHGlobal (outSolitairePtr);
				}
				// parse
				Solitaire.parse(solitaire, outSolitaireBytes, 0);
			}
			return solitaire;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int solitaire_isGameFinish(IntPtr solitairePtr, int solitaireLength, bool canCorrect);

		public static int unityIsGameFinish(Solitaire solitaire, bool canCorrect)
		{
			if (solitaire == null) {
				Debug.LogError ("solitaire null");
				return 0;
			}
			// init
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] solitaireBytes = Solitaire.convertToBytes (solitaire);
				int solitaireLength = solitaireBytes.Length;
				IntPtr solitairePtr = Marshal.AllocHGlobal (solitaireLength);
				try {
					Marshal.Copy (solitaireBytes, 0, solitairePtr, solitaireLength);
					ret = solitaire_isGameFinish (solitairePtr, solitaireLength, canCorrect);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (solitairePtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int solitaire_letComputerThink (IntPtr solitairePtr, int solitaireLength, bool canCorrect, int multiThreaded, int maxClosedCount, bool fastMode, out IntPtr outMovePtr);

		public static SolitaireSolved unityLetComputerThink(Solitaire solitaire, bool canCorrect, int multiThreaded, int maxClosedCount, bool fastMode)
		{
			if(solitaire==null){
				Debug.LogError ("solitaire null");
				return new SolitaireSolved();
			}
			AIController.startThink ();
			// init
			unityInitCore ();
			// do job
			SolitaireSolved move = new SolitaireSolved();
			{
				// position
				byte[] solitaireBytes = Solitaire.convertToBytes(solitaire);
				int solitaireLength = solitaireBytes.Length;
				IntPtr solitairePtr = Marshal.AllocHGlobal (solitaireLength);
				try {
					Marshal.Copy (solitaireBytes, 0, solitairePtr, solitaireLength);
					// request native
					IntPtr outMovePtr;
					int outMoveLength = solitaire_letComputerThink (solitairePtr, solitaireLength, canCorrect, multiThreaded, maxClosedCount, fastMode, out outMovePtr);
					// set move
					{
						byte[] outMoveByteArray = new byte[outMoveLength];
						{
							Marshal.Copy(outMovePtr, outMoveByteArray, 0, outMoveLength);
							Marshal.FreeHGlobal(outMovePtr);
						}
						// convert to moveByteArray to move
						SolitaireSolved.parse(move, outMoveByteArray, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal(solitairePtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int solitaire_doMove(IntPtr solitairePtr, int solitaireLength, bool canCorrect, IntPtr movePtr, int moveLength, out IntPtr outSolitairePtr);

		public static Solitaire unityDoMove(Solitaire solitaire, bool canCorrect, SolitaireMove move)
		{
			if (solitaire == null) {
				Debug.LogError ("solitaire null");
				return new Solitaire ();
			}
			// init
			unityInitCore ();
			// do job
			Solitaire newSolitaire = new Solitaire ();
			{
				// make parameter position
				byte[] solitaireBytes = Solitaire.convertToBytes (solitaire);
				int solitaireLength = solitaireBytes.Length;
				IntPtr solitairePtr = Marshal.AllocHGlobal (solitaireLength);
				// make parameter move
				byte[] moveBytes = SolitaireMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				// do move
				try {
					Marshal.Copy (solitaireBytes, 0, solitairePtr, solitaireLength);
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					// find outRet
					IntPtr outSolitairePtr;
					int outSolitaireLength = solitaire_doMove (solitairePtr, solitaireLength, canCorrect, movePtr, moveLength, out outSolitairePtr);
					// process result
					{
						byte[] outSolitaireBytes = new byte[outSolitaireLength];
						{
							Marshal.Copy (outSolitairePtr, outSolitaireBytes, 0, outSolitaireLength);
							Marshal.FreeHGlobal (outSolitairePtr);
						}
						// update
						Solitaire.parse (newSolitaire, outSolitaireBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (solitairePtr);
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return newSolitaire;
		}

		#endregion

		#region reset

		[DllImport(GameType.BundleName)]
		private static extern int solitaire_reset(IntPtr solitairePtr, int solitaireLength, bool canCorrect, out IntPtr outSolitairePtr);

		public static Solitaire unityReset(Solitaire solitaire, bool canCorrect)
		{
			if (solitaire == null) {
				Debug.LogError ("solitaire null");
				return new Solitaire ();
			}
			// init
			unityInitCore ();
			// do job
			Solitaire newSolitaire = new Solitaire ();
			{
				// make parameter position
				byte[] solitaireBytes = Solitaire.convertToBytes (solitaire);
				int solitaireLength = solitaireBytes.Length;
				IntPtr solitairePtr = Marshal.AllocHGlobal (solitaireLength);
				// reset
				try {
					Marshal.Copy (solitaireBytes, 0, solitairePtr, solitaireLength);
					// find outRet
					IntPtr outSolitairePtr;
					int outSolitaireLength = solitaire_reset (solitairePtr, solitaireLength, canCorrect, out outSolitairePtr);
					// process result
					{
						byte[] outSolitaireBytes = new byte[outSolitaireLength];
						{
							Marshal.Copy (outSolitairePtr, outSolitaireBytes, 0, outSolitaireLength);
							Marshal.FreeHGlobal (outSolitairePtr);
						}
						// update
						Solitaire.parse (newSolitaire, outSolitaireBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (solitairePtr);
				}
			}
			return newSolitaire;
		}

		#endregion

		#region print Board

		[DllImport(GameType.BundleName)]
		private static extern int solitaire_printPosition(IntPtr solitairePtr, int solitaireLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityPrintPosition(Solitaire solitaire, bool canCorrect)
		{
			if (solitaire == null) {
				Debug.LogError ("solitaire null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] solitaireBytes = Solitaire.convertToBytes (solitaire);
				int solitaireLength = solitaireBytes.Length;
				IntPtr solitairePtr = Marshal.AllocHGlobal (solitaireLength);
				// make request
				try {
					Marshal.Copy (solitaireBytes, 0, solitairePtr, solitaireLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = solitaire_printPosition (solitairePtr, solitaireLength, canCorrect, out outStrPositionPtr);
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
					Marshal.FreeHGlobal (solitairePtr);
				}
			}
			return ret;
		}

		#endregion

		#region print Move

		[DllImport(GameType.BundleName)]
		private static extern int solitaire_printMove(IntPtr solitairePtr, int solitaireLength, bool canCorrect, IntPtr movePtr, int moveLength, out IntPtr outMovePtr);

		public static string unityPrintMove(Solitaire solitaire, bool canCorrect, SolitaireMove move)
		{
			if (solitaire == null) {
				Debug.LogError ("solitaire null");
				return "";
			}
			// init
			unityInitCore ();
			// do job
			string ret = "";
			{
				// make parameter position
				byte[] solitaireBytes = Solitaire.convertToBytes (solitaire);
				int solitaireLength = solitaireBytes.Length;
				IntPtr solitairePtr = Marshal.AllocHGlobal (solitaireLength);
				// make parameter move
				byte[] moveBytes = SolitaireMove.convertToBytes (move);
				int moveLength = moveBytes.Length;
				IntPtr movePtr = Marshal.AllocHGlobal (moveLength);
				// do move
				try {
					Marshal.Copy (solitaireBytes, 0, solitairePtr, solitaireLength);
					Marshal.Copy (moveBytes, 0, movePtr, moveLength);
					// find outRet
					IntPtr outSolitairePtr;
					int outSolitaireLength = solitaire_printMove (solitairePtr, solitaireLength, canCorrect, movePtr, moveLength, out outSolitairePtr);
					// process result
					{
						byte[] outStrMoveBytes = new byte[outSolitaireLength];
						{
							Marshal.Copy (outSolitairePtr, outStrMoveBytes, 0, outSolitaireLength);
							Marshal.FreeHGlobal (outSolitairePtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outStrMoveBytes);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (solitairePtr);
					Marshal.FreeHGlobal (movePtr);
				}
			}
			return ret;
		}

		#endregion

	}
}