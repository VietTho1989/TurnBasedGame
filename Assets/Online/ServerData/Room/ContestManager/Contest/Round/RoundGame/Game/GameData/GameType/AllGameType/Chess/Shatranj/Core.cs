using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Shatranj
{
	public class Core
	{
		public const bool CanCorrect = true;

		#region init Core

		[DllImport(GameType.BundleName)]
		private static extern void shatranj_initCore();

		public static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		public static void unityInitCore()
		{
			lock (lockThis) {
				if (!isAlreadyInit) {
					isAlreadyInit = true;
					shatranj_initCore ();
				} else {
					// Debug.LogError ("already init core");
				}
			}
		}

		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int shatranj_makePositionByFen (string strFen, bool isChess960, out IntPtr outShatranjPtr);

		public static Shatranj unityMakePositionByFen(string strFen, bool isChess960)
		{
			unityInitCore ();
			// do job
			Shatranj shatranj = new Shatranj();
			{
				// request native
				IntPtr outShatranjPtr;
				int outShatranjLength = shatranj_makePositionByFen(strFen, isChess960, out outShatranjPtr);
				// make byte array
				byte[] outShatranjBytes = new byte[outShatranjLength];
				{
					Marshal.Copy (outShatranjPtr, outShatranjBytes, 0, outShatranjLength);
					Marshal.FreeHGlobal (outShatranjPtr);
				}
				// parse
				Shatranj.parse(shatranj, outShatranjBytes, 0);
			}
			return shatranj;
		}

		#endregion

		#region positionToFen

		[DllImport(GameType.BundleName)]
		private static extern int shatranj_position_to_fen(IntPtr shatranjPtr, int shatranjLength, bool canCorrect, out IntPtr outStrFenPtr);

		public static string unityPositionToFen(Shatranj shatranj, bool canCorrect)
		{
			if (shatranj == null) {
				Debug.LogError ("shatranj null");
				return "";
			}
			unityInitCore ();
			string ret = "";
			// do job
			{
				// make parameter
				byte[] shatranjBytes = Shatranj.convertToBytes (shatranj, false);
				int shatranjLength = shatranjBytes.Length;
				IntPtr shatranjPtr = Marshal.AllocHGlobal (shatranjLength);
				// make request
				try {
					Marshal.Copy (shatranjBytes, 0, shatranjPtr, shatranjLength);
					// find outRet
					IntPtr outStrFenPtr;
					int outStrFenLength = shatranj_position_to_fen (shatranjPtr, shatranjLength, canCorrect, out outStrFenPtr);
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
					Marshal.FreeHGlobal (shatranjPtr);
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
		private static extern int shatranj_isGameFinish(IntPtr shatranjPtr, int shatranjLength, bool canCorrect);

		public static int unityIsGameFinish(Shatranj shatranj, bool canCorrect)
		{
			if(shatranj==null){
				Debug.LogError ("shatranj null");
				return 0;
			}
			unityInitCore ();
			// do job
			int ret = 0;
			{
				byte[] shatranjBytes = Shatranj.convertToBytes (shatranj);
				int shatranjLength = shatranjBytes.Length;
				IntPtr shatranjPtr = Marshal.AllocHGlobal(shatranjLength);
				try{
					Marshal.Copy(shatranjBytes, 0, shatranjPtr, shatranjLength);
					ret = shatranj_isGameFinish(shatranjPtr, shatranjLength, canCorrect);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(shatranjPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern int shatranj_letComputerThink (IntPtr shatranjPtr, int shatranjLength, bool canCorrect, int depth, int skillLevel, long duration);

		public static int unityLetComputerThink(Shatranj shatranj, bool canCorrect, int depth, int skillLevel, long duration)
		{
			if(shatranj==null){
				Debug.LogError ("shatranj null");
				return 0;
			}
			AIController.startThink ();
			unityInitCore ();
			// do job
			int move = 0;
			{
				byte[] shatranjBytes = Shatranj.convertToBytes (shatranj);
				int shatranjLength = shatranjBytes.Length;
				IntPtr shatranjPtr = Marshal.AllocHGlobal(shatranjLength);
				try{
					Marshal.Copy(shatranjBytes, 0, shatranjPtr, shatranjLength);
					move = shatranj_letComputerThink(shatranjPtr, shatranjLength, canCorrect, depth, skillLevel, duration);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(shatranjPtr);
				}
			}
			AIController.startEnd ();
			return move;
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool shatranj_isLegalMove(IntPtr shatranjPtr, int shatranjLength, bool canCorrect, int move);

		public static bool unityIsLegalMove(Shatranj shatranj, bool canCorrect, int move)
		{
			if(shatranj==null){
				Debug.LogError ("shatranj null");
				return false;
			}
			unityInitCore ();
			// do job
			bool ret = false;
			{
				byte[] shatranjBytes = Shatranj.convertToBytes (shatranj);
				int shatranjLength = shatranjBytes.Length;
				IntPtr shatranjPtr = Marshal.AllocHGlobal(shatranjLength);
				try{
					Marshal.Copy(shatranjBytes, 0, shatranjPtr, shatranjLength);
					ret = shatranj_isLegalMove(shatranjPtr, shatranjLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(shatranjPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int shatranj_doMove(IntPtr shatranjPtr, int shatranjLength, bool canCorrect, int move, out IntPtr outShatranjPtr); 

		public static Shatranj unityDoMove(Shatranj shatranj, bool canCorrect, int move)
		{
			if(shatranj==null){
				Debug.LogError ("shatranj null");
				return new Shatranj();
			}
			unityInitCore ();
			// do job
			Shatranj newShatranj = new Shatranj();
			{
				// make parameter
				byte[] shatranjBytes = Shatranj.convertToBytes (shatranj);
				int shatranjLength = shatranjBytes.Length;
				IntPtr shatranjPtr = Marshal.AllocHGlobal(shatranjLength);
				// make request
				try{
					Marshal.Copy(shatranjBytes, 0, shatranjPtr, shatranjLength);
					// find outRet
					IntPtr outShatranjPtr;
					int outShatranjLength = shatranj_doMove(shatranjPtr, shatranjLength, canCorrect, move, out outShatranjPtr);
					// process result
					{
						byte[] outShatranjBytes = new byte[outShatranjLength];
						{
							Marshal.Copy(outShatranjPtr, outShatranjBytes, 0, outShatranjLength);
							Marshal.FreeHGlobal(outShatranjPtr);
						}
						// update
						Shatranj.parse(newShatranj, outShatranjBytes, 0);
					}
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(shatranjPtr);
				}
			}
			return newShatranj;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int shatranj_getLegalMoves(IntPtr shatranjPtr, int shatranjLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<ShatranjMove> unityGetLegalMoves(Shatranj shatranj, bool canCorrect)
		{
			if (shatranj == null) {
				Debug.LogError ("shatranj null");
				return new List<ShatranjMove> ();
			}
			unityInitCore ();
			// do job
			List<ShatranjMove> ret = new List<ShatranjMove> ();
			{
				// make paramter
				byte[] shatranjBytes = Shatranj.convertToBytes (shatranj);
				int shatranjLength = shatranjBytes.Length;
				IntPtr shatranjPtr = Marshal.AllocHGlobal (shatranjLength);
				// doMove
				try {
					Marshal.Copy (shatranjBytes, 0, shatranjPtr, shatranjLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = shatranj_getLegalMoves (shatranjPtr, shatranjLength, canCorrect, out outLegalMovesPtr);
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
									ShatranjMove legalMove = new ShatranjMove();
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
						Debug.LogError ("Cannot find any legal moves: " + shatranj);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (shatranjPtr);
				}
			}
			return ret;
		}

		#endregion

	}
}