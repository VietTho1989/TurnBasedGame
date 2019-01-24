using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Reversi
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region setBookPath

		// void setBookPath(const char* newBookPath);

		[DllImport(GameType.BundleName)]
		private static extern void reversi_setBookPath(string newBookPath);

		public static void unitySetBookPath(string newBookPath)
		{
			reversi_setBookPath (newBookPath);
		}

		#endregion

		#region makeDefaultPosition

		[DllImport(GameType.BundleName)]
		private static extern int reversi_makeDefaultPosition(out IntPtr outReversiPtr);

		public static Reversi unityMakeDefaultPosition()
		{
			// init
			firstInitCore();
			// do job
			Reversi reversi = new Reversi();
			{
				// request native
				IntPtr outReversiPtr;
				int outReversiLength = reversi_makeDefaultPosition(out outReversiPtr);
				// make byte array
				byte[] outReversiBytes = new byte[outReversiLength];
				{
					Marshal.Copy(outReversiPtr, outReversiBytes, 0, outReversiLength);
					Marshal.FreeHGlobal(outReversiPtr);
				}
				// parse
				Reversi.parse(reversi, outReversiBytes, 0);
			}
			return reversi;
		}

		#endregion

		#region

		[DllImport(GameType.BundleName)]
		private static extern int reversi_isGameFinish(IntPtr reversiPtr, int reversiLength, bool canCorrect);

		public static int unityIsGameFinish(Reversi reversi, bool canCorrect)
		{
			if(reversi==null){
				Debug.LogError ("reversi null");
				return 0;
			}
			// init
			firstInitCore ();
			// do job
			int ret = 0;
			{
				byte[] reversiBytes = Reversi.convertToBytes (reversi);
				int reversiLength = reversiBytes.Length;
				IntPtr reversiPtr = Marshal.AllocHGlobal(reversiLength);
				try{
					Marshal.Copy(reversiBytes, 0, reversiPtr, reversiLength);
					ret = reversi_isGameFinish(reversiPtr, reversiLength, canCorrect);
				} catch(Exception e){
					Debug.LogError (e);
				} finally{
					Marshal.FreeHGlobal(reversiPtr);
				}
			}
			return ret;
		}

		#endregion

		#region

		[DllImport(GameType.BundleName)]
		private static extern sbyte reversi_letComputerThink(IntPtr reversiPtr, int reversiLength, bool canCorrect, int sort, int min, int max, int end, int msLeft, bool useBook, int percent);

		public static sbyte unityLetComputerThink(Reversi reversi, bool canCorrect, int sort, int min, int max, int end, int msLeft, bool useBook, int percent)
		{
			if(reversi==null){
				Debug.LogError ("reversi null");
				return 0;
			}
			AIController.startThink ();
			// init
			firstInitCore ();
			// do job
			sbyte move = 0;
			{
				byte[] reversiBytes = Reversi.convertToBytes (reversi);
				int reversiLength = reversiBytes.Length;
				IntPtr reversiPtr = Marshal.AllocHGlobal(reversiLength);
				try{
					Marshal.Copy(reversiBytes, 0, reversiPtr, reversiLength);
					move = reversi_letComputerThink(reversiPtr, reversiLength, canCorrect, sort, min, max, end, msLeft, useBook, percent);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(reversiPtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}

		#endregion

		#region

		[DllImport(GameType.BundleName)]
		private static extern bool reversi_isLegalMove(IntPtr reversiPtr, int reversiLength, bool canCorrect, sbyte move);

		public static bool unityIsLegalMove(Reversi reversi, bool canCorrect, sbyte move)
		{
			if(reversi==null){
				Debug.LogError ("reversi null");
				return false;
			}
			// init
			firstInitCore ();
			// do job
			bool ret = false;
			{
				byte[] reversiBytes = Reversi.convertToBytes (reversi);
				int reversiLength = reversiBytes.Length;
				IntPtr reversiPtr = Marshal.AllocHGlobal(reversiLength);
				try{
					Marshal.Copy(reversiBytes, 0, reversiPtr, reversiLength);
					ret = reversi_isLegalMove(reversiPtr, reversiLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(reversiPtr);
				}
			}
			return ret;
		}

		#endregion

		#region

		[DllImport(GameType.BundleName)]
		private static extern int reversi_doMove(IntPtr reversiPtr, int reversiLength, bool canCorrect, sbyte move, out IntPtr outReversiPtr);

		public static Reversi unityDoMove(Reversi reversi, bool canCorrect, sbyte move)
		{
			if (reversi == null) {
				Debug.LogError ("reversi null");
				return new Reversi();
			}
			// init
			firstInitCore ();
			// do job
			Reversi newReversi = new Reversi();
			{
				// make parameter
				byte[] reversiBytes = Reversi.convertToBytes (reversi);
				int reversiLength = reversiBytes.Length;
				IntPtr reversiPtr = Marshal.AllocHGlobal (reversiLength);
				// make request
				try {
					Marshal.Copy (reversiBytes, 0, reversiPtr, reversiLength);
					// find outRet
					IntPtr outReversiPtr;
					int outReversiLength = reversi_doMove (reversiPtr, reversiLength, canCorrect, move, out outReversiPtr);
					// process result
					{
						byte[] outReversiBytes = new byte[outReversiLength];
						{
							Marshal.Copy (outReversiPtr, outReversiBytes, 0, outReversiLength);
							Marshal.FreeHGlobal(outReversiPtr);
						}
						// update
						Reversi.parse(newReversi, outReversiBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal(reversiPtr);
				}
			}
			return newReversi;
		}

		#endregion

		#region getLegalMoves

		public static List<ReversiMove> unityGetLegalMoves(Reversi reversi, bool canCorrect)
		{
			if (reversi == null) {
				Debug.LogError ("reversi null");
				return new List<ReversiMove> ();
			}
			firstInitCore ();
			// do job
			List<ReversiMove> ret = new List<ReversiMove> ();
			{
				System.UInt64 taken = reversi.white.v | reversi.black.v;
				System.UInt64 legal = Common.getLegal (reversi.white.v, reversi.black.v, reversi.side.v);
				for (int y = 0; y < 8; y++) {
					for (int x = 0; x < 8; x++) {
						int position = 8 * y + x;
						if ((taken & Common.MOVEMASK [position]) == 0) {
							if ((legal & Common.MOVEMASK [position]) != 0) {
								ReversiMove reversiMove = new ReversiMove ();
								{
									reversiMove.move.v = (sbyte)position;
								}
								ret.Add (reversiMove);
							}
						}
					}
				}
			}
			return ret;
		}

		#endregion

		// TODO Co the tao fen

		#region first init

		private static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		private static void firstInitCore()
		{
			lock (lockThis) {
				if (!isAlreadyInit) {
					isAlreadyInit = true;
					// set book
					{

						#if UNITY_STANDALONE_OSX
						{
							string path = Global.DataPath+ "/Plugins/UnityNativeCore.bundle/Contents/Resources/"+GameType.AlwaysIn+"/Reversi";
							// Debug.LogError("bookPath: "+path);
							unitySetBookPath(path);
						}
						#elif UNITY_IPHONE 
						{
							string path = Global.DataPath+ "/"+GameType.AlwaysIn+"/Reversi";
							// Debug.LogError("bookPath: "+path);
							unitySetBookPath(path);
						}
						#elif UNITY_ANDROID
						{
							string path = GameType.AlwaysIn+ "/Reversi";
							// Debug.LogError("bookPath: "+path);
							unitySetBookPath(path);
						}
						#endif
					}
				} else {
					// Debug.LogError ("already init core");
				}
			}
		}

		#endregion

	}
}