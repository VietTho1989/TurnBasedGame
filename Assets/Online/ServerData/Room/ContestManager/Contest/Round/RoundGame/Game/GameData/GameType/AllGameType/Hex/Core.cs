using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HEX
{
	public class Core : MonoBehaviour
	{

		public const bool CanCorrect = true;

		#region makeDefaultPosition

		[DllImport(GameType.BundleName)]
		private static extern int hex_makeDefaultPosition (System.UInt16 boardSize, out IntPtr outHexPtr);

		public static Hex unityMakeDefaultPosition(System.UInt16 boardSize)
		{
			// init
			unityInitCore ();
			// do job
			Hex hex = new Hex ();
			{
				// request native
				IntPtr outHexPtr;
				int newHexLength = hex_makeDefaultPosition (boardSize, out outHexPtr);
				// make byte array
				byte[] outHexBytes = new byte[newHexLength];
				{
					Marshal.Copy (outHexPtr, outHexBytes, 0, newHexLength);
					Marshal.FreeHGlobal (outHexPtr);
				}
				// parse
				Hex.parse (hex, outHexBytes, 0);
			}
			return hex;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int hex_isGameFinish(IntPtr hexPtr, int length, bool canCorrect);

		public static int unityIsGameFinish(Hex hex, bool canCorrect)
		{
			if (hex == null) {
				Debug.LogError ("positionBytes null");
				return 0;
			}
			// init
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] hexBytes = Hex.convertToBytes (hex);
				int length = hexBytes.Length;
				IntPtr hexPtr = Marshal.AllocHGlobal (length);
				try {
					Marshal.Copy (hexBytes, 0, hexPtr, length);
					ret = hex_isGameFinish (hexPtr, length, canCorrect);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (hexPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern System.UInt16 hex_letComputerThink(IntPtr hexPtr, int length, bool canCorrect, int limitTime, bool firstMoveCenter);

		public static System.UInt16 unityLetComputerThink(Hex hex, bool canCorrect, int limitTime, bool firstMoveCenter)
		{
			if (hex == null) {
				Debug.LogError ("positionBytes null");
				return 0;
			}
			AIController.startThink ();
			// init
			unityInitCore ();
			// do job
			System.UInt16 move = 0;
			{
				// position
				byte[] positionBytes = Hex.convertToBytes(hex);
				int length = positionBytes.Length;
				IntPtr hexPtr = Marshal.AllocHGlobal (length);
				try {
					Marshal.Copy (positionBytes, 0, hexPtr, length);
					move = hex_letComputerThink (hexPtr, length, canCorrect, limitTime, firstMoveCenter);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal(hexPtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}
			
		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool hex_isLegalMove(IntPtr hexPtr, int length, bool canCorrect, System.UInt16 move);

		public static bool unityIsLegalMove(Hex hex, bool canCorrect, System.UInt16 move)
		{
			if (hex == null) {
				Debug.LogError ("positionBytes null");
				return false;
			}
			// init
			unityInitCore ();
			// do job
			bool ret = false;
			{
				// position
				byte[] hexBytes = Hex.convertToBytes (hex);
				int hexLength = hexBytes.Length;
				IntPtr hexPtr = Marshal.AllocHGlobal (hexLength);
				// check legal move
				try {
					Marshal.Copy (hexBytes, 0, hexPtr, hexLength);
					ret =hex_isLegalMove (hexPtr, hexLength, canCorrect, move);
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (hexPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int hex_doMove (IntPtr hexPtr, int hexLength, bool canCorrect, System.UInt16 move, out IntPtr outHexPtr);

		public static Hex unityDoMove(Hex hex, bool canCorrect, System.UInt16 move)
		{
			if (hex == null) {
				Debug.LogError ("hex null");
				return new Hex ();
			}
			// init
			unityInitCore ();
			// do job
			Hex newHex = new Hex ();
			{
				// make parameter
				byte[] hexBytes = Hex.convertToBytes (hex);
				int hexLength = hexBytes.Length;
				IntPtr hexPtr = Marshal.AllocHGlobal (hexLength);
				// do move
				try {
					Marshal.Copy (hexBytes, 0, hexPtr, hexLength);
					// find outRet
					IntPtr outHexPtr;
					int newHexLength = hex_doMove (hexPtr, hexLength, canCorrect, move, out outHexPtr);
					// process result
					{
						byte[] outHexBytes = new byte[newHexLength];
						{
							Marshal.Copy (outHexPtr, outHexBytes, 0, newHexLength);
							Marshal.FreeHGlobal (outHexPtr);
						}
						// update
						Hex.parse (newHex, outHexBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (hexPtr);
				}
			}
			return newHex;
		}

		#endregion

		#region printPosition

		[DllImport(GameType.BundleName)]
		private static extern int hex_printPosition(IntPtr hexPtr, int hexLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(Hex hex, bool canCorrect)
		{
			if (hex == null) {
				Debug.LogError ("hex null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] hexBytes = Hex.convertToBytes (hex);
				int hexLength = hexBytes.Length;
				IntPtr hexPtr = Marshal.AllocHGlobal (hexLength);
				// make request
				try {
					Marshal.Copy (hexBytes, 0, hexPtr, hexLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = hex_printPosition (hexPtr, hexLength, canCorrect, out outStrPositionPtr);
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
					Marshal.FreeHGlobal (hexPtr);
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