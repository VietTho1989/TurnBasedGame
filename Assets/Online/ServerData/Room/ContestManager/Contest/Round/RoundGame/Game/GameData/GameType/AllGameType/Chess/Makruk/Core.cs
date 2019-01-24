using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Makruk
{
	public class Core
	{
		public const bool CanCorrect = true;

		#region init Core

		[DllImport(GameType.BundleName)]
		private static extern void makruk_initCore();

		public static bool isAlreadyInit = false;

		private static System.Object lockInitCore = new System.Object ();

		public static void unityInitCore()
		{
			if (!isAlreadyInit) {
				lock (lockInitCore) {
					if (!isAlreadyInit) {
						isAlreadyInit = true;
						makruk_initCore ();
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}

		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int makruk_makePositionByFen (string strFen, bool isChess960, out IntPtr outMakrukPtr);

		public static Makruk unityMakePositionByFen(string strFen, bool isChess960)
		{
			unityInitCore ();
			// do job
			Makruk makruk = new Makruk();
			{
				// request native
				IntPtr outMakrukPtr;
				int outMakrukLength = makruk_makePositionByFen(strFen, isChess960, out outMakrukPtr);
				// make byte array
				byte[] outMakrukBytes = new byte[outMakrukLength];
				{
					Marshal.Copy (outMakrukPtr, outMakrukBytes, 0, outMakrukLength);
					Marshal.FreeHGlobal (outMakrukPtr);
				}
				// parse
				Makruk.parse(makruk, outMakrukBytes, 0);
			}
			return makruk;
		}

		#endregion

		#region positionToFen

		[DllImport(GameType.BundleName)]
		private static extern int makruk_position_to_fen(IntPtr makrukPtr, int makrukLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityPositionToFen(Makruk makruk, bool canCorrect)
		{
			if (makruk == null) {
				Debug.LogError ("makruk null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] makrukBytes = Makruk.convertToBytes (makruk, false);
				int makrukLength = makrukBytes.Length;
				IntPtr makrukPtr = Marshal.AllocHGlobal (makrukLength);
				// make request
				try {
					Marshal.Copy (makrukBytes, 0, makrukPtr, makrukLength);
					// find outRet
					IntPtr outStrFenPtr;
					int outStrFenLength = makruk_position_to_fen (makrukPtr, makrukLength, canCorrect, out outStrFenPtr);
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
					Marshal.FreeHGlobal (makrukPtr);
				}
			}
			return ret;
		}

		#endregion

		#region isPositionOK

		// TODO Can hoan thien
		// bool isPositionOk(uint8_t* positionBytes, int length, bool canCorrect);

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int makruk_isGameFinish(IntPtr makrukPtr, int makrukLength, bool canCorrect);

		public static int unityIsGameFinish(Makruk makruk, bool canCorrect)
		{
			if(makruk==null){
				Debug.LogError ("makruk null");
				return 0;
			}
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] makrukBytes = Makruk.convertToBytes (makruk);
				int makrukLength = makrukBytes.Length;
				IntPtr makrukPtr = Marshal.AllocHGlobal(makrukLength);
				try{
					Marshal.Copy(makrukBytes, 0, makrukPtr, makrukLength);
					ret = makruk_isGameFinish(makrukPtr, makrukLength, canCorrect);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(makrukPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int makruk_letComputerThink (IntPtr makrukPtr, int makrukLength, bool canCorrect, int depth, int skillLevel, long duration);

		public static int unityLetComputerThink(Makruk makruk, bool canCorrect, int depth, int skillLevel, long duration)
		{
			if(makruk==null){
				Debug.LogError ("makruk null");
				return 0;
			}
			AIController.startThink ();
			unityInitCore ();
			// do job
			int move = 0;
			{
				byte[] makrukBytes = Makruk.convertToBytes (makruk);
				int makrukLength = makrukBytes.Length;
				IntPtr makrukPtr = Marshal.AllocHGlobal(makrukLength);
				try{
					Marshal.Copy(makrukBytes, 0, makrukPtr, makrukLength);
					move = makruk_letComputerThink(makrukPtr, makrukLength, canCorrect, depth, skillLevel, duration);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(makrukPtr);
				}
			}
			AIController.startEnd ();
			return move;
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool makruk_isLegalMove(IntPtr makrukPtr, int makrukLength, bool canCorrect, int move);

		public static bool unityIsLegalMove(Makruk makruk, bool canCorrect, int move)
		{
			if(makruk==null){
				Debug.LogError ("makruk null");
				return false;
			}
			unityInitCore ();
			// do job
			bool ret = false;
			{
				byte[] makrukBytes = Makruk.convertToBytes (makruk);
				int makrukLength = makrukBytes.Length;
				IntPtr makrukPtr = Marshal.AllocHGlobal(makrukLength);
				try{
					Marshal.Copy(makrukBytes, 0, makrukPtr, makrukLength);
					ret = makruk_isLegalMove(makrukPtr, makrukLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(makrukPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int makruk_doMove(IntPtr makrukPtr, int makrukLength, bool canCorrect, int move, out IntPtr outMakrukPtr); 

		public static Makruk unityDoMove(Makruk makruk, bool canCorrect, int move)
		{
			if(makruk==null){
				Debug.LogError ("makruk null");
				return new Makruk();
			}
			unityInitCore ();
			// do job
			Makruk newMakruk = new Makruk();
			{
				// make parameter
				byte[] makrukBytes = Makruk.convertToBytes (makruk);
				int makrukLength = makrukBytes.Length;
				IntPtr makrukPtr = Marshal.AllocHGlobal(makrukLength);
				// make request
				try{
					Marshal.Copy(makrukBytes, 0, makrukPtr, makrukLength);
					// find outRet
					IntPtr outMakrukPtr;
					int outMakrukLength = makruk_doMove(makrukPtr, makrukLength, canCorrect, move, out outMakrukPtr);
					// process result
					{
						byte[] outMakrukBytes = new byte[outMakrukLength];
						{
							Marshal.Copy(outMakrukPtr, outMakrukBytes, 0, outMakrukLength);
							Marshal.FreeHGlobal(outMakrukPtr);
						}
						// update
						Makruk.parse(newMakruk, outMakrukBytes, 0);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(makrukPtr);
				}
			}
			return newMakruk;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int makruk_getLegalMoves(IntPtr makrukPtr, int makrukLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<MakrukMove> unityGetLegalMoves(Makruk makruk, bool canCorrect)
		{
			if (makruk == null) {
				Debug.LogError ("makruk null");
				return new List<MakrukMove> ();
			}
			unityInitCore ();
			// do job
			List<MakrukMove> ret = new List<MakrukMove> ();
			{
				// make paramter
				byte[] makrukBytes = Makruk.convertToBytes (makruk);
				int makrukLength = makrukBytes.Length;
				IntPtr makrukPtr = Marshal.AllocHGlobal (makrukLength);
				// doMove
				try {
					Marshal.Copy (makrukBytes, 0, makrukPtr, makrukLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = makruk_getLegalMoves (makrukPtr, makrukLength, canCorrect, out outLegalMovesPtr);
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
									MakrukMove legalMove = new MakrukMove();
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
						Debug.LogError ("Cannot find any legal moves: " + makruk);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (makrukPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}