using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Seirawan
{
	public class Core
	{
		public const bool CanCorrect = true;

		#region init Core

		[DllImport(GameType.BundleName)]
		private static extern void seirawan_initCore();

		public static bool isAlreadyInit = false;

		private static System.Object lockInitCore = new System.Object ();

		public static void unityInitCore()
		{
			// Debug.LogError ("start unityInitCore");
			if (!isAlreadyInit) {
				lock (lockInitCore) {
					// Debug.LogError ("unityInitCore");
					if (!isAlreadyInit) {
						isAlreadyInit = true;
						seirawan_initCore ();
					} else {
						// Debug.LogError ("already init core");
					}
				}
			}
		}

		#endregion

		#region getStrPosition

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_getStrPosition(IntPtr seirawanPtr, int seirawanLength, bool canCorrect, out IntPtr outStrPositionPtr);

		public static string unityGetStrPosition(Seirawan seirawan, bool canCorrect)
		{
			if(seirawan==null){
				Debug.LogError ("seirawan null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal(seirawanLength);
				// make request
				try{
					Marshal.Copy(seirawanBytes, 0, seirawanPtr, seirawanLength);
					// find outRet
					IntPtr outStrPositionPtr;
					int outStrPositionLength = seirawan_getStrPosition(seirawanPtr, seirawanLength, canCorrect, out outStrPositionPtr);
					// process result
					{
						byte[] outStrPositionBytes = new byte[outStrPositionLength];
						{
							Marshal.Copy(outStrPositionPtr, outStrPositionBytes, 0, outStrPositionLength);
							Marshal.FreeHGlobal(outStrPositionPtr);
						}
						// update
						ret = System.Text.ASCIIEncoding.Default.GetString (outStrPositionBytes);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(seirawanPtr);
				}
			}
			return ret;
		}

		#endregion

		#region getPositionFen

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_getPositionFen(IntPtr seirawanPtr, int seirawanLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityGetPositionFen(Seirawan seirawan, bool canCorrect)
		{
			if(seirawan==null){
				Debug.LogError ("seirawan null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan, false);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal(seirawanLength);
				// make request
				try{
					Marshal.Copy(seirawanBytes, 0, seirawanPtr, seirawanLength);
					// find outRet
					IntPtr outFenPtr;
					int outFenLength = seirawan_getPositionFen(seirawanPtr, seirawanLength, canCorrect, out outFenPtr);
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
					Marshal.FreeHGlobal(seirawanPtr);
				}
			}
			return ret;
		}

		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_makePositionByFen (string strFen, bool isChess960, out IntPtr outSeirawanPtr);

		public static Seirawan unityMakePositionByFen(string strFen, bool isChess960)
		{
			unityInitCore ();
			// do job
			Seirawan seirawan = new Seirawan();
			{
				// request native
				IntPtr outSeirawanPtr;
				int outSeirawanLength = seirawan_makePositionByFen(strFen, isChess960, out outSeirawanPtr);
				// make byte array
				byte[] outSeirawanBytes = new byte[outSeirawanLength];
				{
					Marshal.Copy (outSeirawanPtr, outSeirawanBytes, 0, outSeirawanLength);
					Marshal.FreeHGlobal (outSeirawanPtr);
				}
				// parse
				Seirawan.parse(seirawan, outSeirawanBytes, 0);
			}
			return seirawan;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_isGameFinish(IntPtr seirawanPtr, int seirawanLength, bool canCorrect);

		public static int unityIsGameFinish(Seirawan seirawan, bool canCorrect)
		{
			if(seirawan==null){
				Debug.LogError ("seirawan null");
				return 0;
			}
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal(seirawanLength);
				try{
					Marshal.Copy(seirawanBytes, 0, seirawanPtr, seirawanLength);
					ret = seirawan_isGameFinish(seirawanPtr, seirawanLength, canCorrect);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(seirawanPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_letComputerThink (IntPtr seirawanPtr, int seirawanLength, bool canCorrect, int depth, int skillLevel, long duration);

		public static int unityLetComputerThink(Seirawan seirawan, bool canCorrect, int depth, int skillLevel, long duration)
		{
			if(seirawan==null){
				Debug.LogError ("seirawan null");
				return 0;
			}
			AIController.startThink ();
			unityInitCore ();
			// do job
			int move = 0;
			{
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal(seirawanLength);
				try{
					Marshal.Copy(seirawanBytes, 0, seirawanPtr, seirawanLength);
					move = seirawan_letComputerThink(seirawanPtr, seirawanLength, canCorrect, depth, skillLevel, duration);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(seirawanPtr);
				}
			}
			AIController.startEnd ();
			return move;
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool seirawan_isLegalMove(IntPtr seirawanPtr, int seirawanLength, bool canCorrect, int move);

		public static bool unityIsLegalMove(Seirawan seirawan, bool canCorrect, int move)
		{
			if(seirawan==null){
				Debug.LogError ("seirawan null");
				return false;
			}
			unityInitCore ();
			// do job
			bool ret = false;
			{
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal(seirawanLength);
				try{
					Marshal.Copy(seirawanBytes, 0, seirawanPtr, seirawanLength);
					ret = seirawan_isLegalMove(seirawanPtr, seirawanLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(seirawanPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_doMove(IntPtr seirawanPtr, int seirawanLength, bool canCorrect, int move, out IntPtr outSeirawanPtr); 

		public static Seirawan unityDoMove(Seirawan seirawan, bool canCorrect, int move)
		{
			if(seirawan==null){
				Debug.LogError ("seirawan null");
				return new Seirawan();
			}
			unityInitCore ();
			// do job
			Seirawan newSeirawan = new Seirawan();
			{
				// make parameter
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal(seirawanLength);
				// make request
				try{
					Marshal.Copy(seirawanBytes, 0, seirawanPtr, seirawanLength);
					// find outRet
					IntPtr outSeirawanPtr;
					int outSeirawanLength = seirawan_doMove(seirawanPtr, seirawanLength, canCorrect, move, out outSeirawanPtr);
					// process result
					{
						byte[] outSeirawanBytes = new byte[outSeirawanLength];
						{
							Marshal.Copy(outSeirawanPtr, outSeirawanBytes, 0, outSeirawanLength);
							Marshal.FreeHGlobal(outSeirawanPtr);
						}
						// update
						Seirawan.parse(newSeirawan, outSeirawanBytes, 0);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(seirawanPtr);
				}
			}
			return newSeirawan;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int seirawan_getLegalMoves(IntPtr seirawanPtr, int seirawanLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<SeirawanMove> unityGetLegalMoves(Seirawan seirawan, bool canCorrect)
		{
			if (seirawan == null) {
				Debug.LogError ("seirawan null");
				return new List<SeirawanMove> ();
			}
			unityInitCore ();
			// do job
			List<SeirawanMove> ret = new List<SeirawanMove> ();
			{
				// make paramter
				byte[] seirawanBytes = Seirawan.convertToBytes (seirawan);
				int seirawanLength = seirawanBytes.Length;
				IntPtr seirawanPtr = Marshal.AllocHGlobal (seirawanLength);
				// doMove
				try {
					Marshal.Copy (seirawanBytes, 0, seirawanPtr, seirawanLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = seirawan_getLegalMoves (seirawanPtr, seirawanLength, canCorrect, out outLegalMovesPtr);
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
									SeirawanMove legalMove = new SeirawanMove();
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
						Debug.LogError ("Cannot find any legal moves: " + seirawan);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (seirawanPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}