using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xiangqi.UseRule;

namespace Xiangqi
{
	public class Core
	{

		public const bool CanCorrect = true;

		#region setBookPath

		[DllImport(GameType.BundleName)]
		private static extern bool xiangqi_setBookPath(string newBookPath);

		public static bool unitySetBookPath(string newBookPath)
		{
			return xiangqi_setBookPath (newBookPath);
		}

		#endregion

		#region initCore

		[DllImport(GameType.BundleName)]
		private static extern void xiangqi_initCore();

		public static void unityInitCore()
		{
			xiangqi_initCore ();
		}

		#endregion

		#region makePositionByFen

		[DllImport(GameType.BundleName)]
		private static extern int xiangqi_makePositionByFen(string strFen, out IntPtr outXiangqiPtr);

		public static Xiangqi unityMakePositionByFen(string strFen)
		{
			// init
			firstInitCore();
			// do job
			Xiangqi xiangqi = new Xiangqi ();
			{
				// request native
				IntPtr outXiangqiPtr;
				int outXiangqiLength = xiangqi_makePositionByFen(strFen, out outXiangqiPtr);
				// make byte aray
				byte[] outXiangqiBytes = new byte[outXiangqiLength];
				{
					Marshal.Copy (outXiangqiPtr, outXiangqiBytes, 0, outXiangqiLength);
					Marshal.FreeHGlobal (outXiangqiPtr);
				}
				// Parse
				Xiangqi.parse(xiangqi, outXiangqiBytes, 0);
			}
			return xiangqi;
		}

		#endregion

		#region isGameFinish

		[DllImport(GameType.BundleName)]
		private static extern int xiangqi_isGameFinish(IntPtr xiangqiPtr, int xiangqiLength, bool canCorrect);

		public static int unityIsGameFinish(Xiangqi xiangqi, bool canCorrect)
		{
			if(xiangqi==null){
				Debug.LogError ("xiangqi null");
				return 0;
			}
			// init
			firstInitCore ();
			// do job
			int ret = 0;
			{
				byte[] xiangqiBytes = Xiangqi.convertToBytes (xiangqi);
				int xiangqiLength = xiangqiBytes.Length;
				IntPtr xiangqiPtr = Marshal.AllocHGlobal(xiangqiLength);
				try{
					Marshal.Copy(xiangqiBytes, 0, xiangqiPtr, xiangqiLength);
					ret = xiangqi_isGameFinish(xiangqiPtr, xiangqiLength, canCorrect);
				} catch(Exception e){
					Debug.LogError (e);
				} finally{
					Marshal.FreeHGlobal(xiangqiPtr);
				}
			}
			return ret;
		}

		#endregion

		#region letComputerThink

		[DllImport(GameType.BundleName)]
		private static extern System.UInt32 xiangqi_letComputerThink(IntPtr xiangqiPtr, int xiangqiLength, bool canCorrect, int depth, int lngLimitTime, bool useBook, int pickBestMove);

		public static uint unityLetComputerThink(Xiangqi xiangqi, bool canCorrect, int depth, int lngLimitTime, bool useBook, int pickBestMove)
		{
			if(xiangqi==null){
				Debug.LogError ("xiangqi null");
				return 0;
			}
			AIController.startThink ();
			// init
			firstInitCore ();
			firstInitBook ();
			// do job
			uint move = 0;
			{
				byte[] xiangqiBytes = Xiangqi.convertToBytes(xiangqi);
				int xiangqiLength = xiangqiBytes.Length;
				IntPtr xiangqiPtr = Marshal.AllocHGlobal(xiangqiLength);
				try{
					Marshal.Copy(xiangqiBytes, 0, xiangqiPtr, xiangqiLength);
					move = xiangqi_letComputerThink(xiangqiPtr, xiangqiLength, canCorrect, depth, lngLimitTime, useBook, pickBestMove);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(xiangqiPtr);
				}
			}
			AIController.startEnd ();
			return move; 
		}

		#endregion

		#region isLegalMove

		[DllImport(GameType.BundleName)]
		private static extern bool xiangqi_isLegalMove(IntPtr xiangqiPtr, int xiangqiLength, bool canCorrect, System.UInt32 move);

		public static bool unityIsLegalMove(Xiangqi xiangqi, bool canCorrect, System.UInt32 move)
		{
			if(xiangqi==null){
				Debug.LogError ("xiangqi null");
				return false;
			}
			// init
			firstInitCore ();
			// do job
			bool ret = false;
			{
				byte[] xiangqiBytes = Xiangqi.convertToBytes(xiangqi);
				int xiangqiLength = xiangqiBytes.Length;
				IntPtr xiangqiPtr = Marshal.AllocHGlobal(xiangqiLength);
				try{
					Marshal.Copy(xiangqiBytes, 0, xiangqiPtr, xiangqiLength);
					ret = xiangqi_isLegalMove(xiangqiPtr, xiangqiLength, canCorrect, move);
				} catch(Exception e){
					Debug.LogError(e);
				} finally{
					Marshal.FreeHGlobal(xiangqiPtr);
				}
			}
			return ret;
		}

		#endregion

		#region doMove

		[DllImport(GameType.BundleName)]
		private static extern int xiangqi_doMove(IntPtr xiangqiPtr, int xiangqiLength, bool canCorrect, System.UInt32 move, out IntPtr outXiangqiPtr);

		public static Xiangqi unityDoMove(Xiangqi xiangqi, bool canCorrect, System.UInt32 move)
		{
			if (xiangqi == null) {
				Debug.LogError ("xiangqi null");
				return new Xiangqi();
			}
			// init
			firstInitCore ();
			// do job
			Xiangqi newXiangqi = new Xiangqi();
			{
				// make paramter
				byte[] xiangqiBytes = Xiangqi.convertToBytes (xiangqi);
				int xiangqiLength = xiangqiBytes.Length;
				IntPtr xiangqiPtr = Marshal.AllocHGlobal (xiangqiLength);
				// doMove
				try {
					Marshal.Copy (xiangqiBytes, 0, xiangqiPtr, xiangqiLength);
					// find new pos
					IntPtr newXiangqiPtr;
					int newXiangqiLength = xiangqi_doMove (xiangqiPtr, xiangqiLength, canCorrect, move, out newXiangqiPtr);
					// process result
					{
						byte[] newXiangqiBytes = new byte[newXiangqiLength];
						{
							Marshal.Copy (newXiangqiPtr, newXiangqiBytes, 0, newXiangqiLength);
							Marshal.FreeHGlobal(newXiangqiPtr);
						}
						// update
						Xiangqi.parse(newXiangqi, newXiangqiBytes, 0);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal(xiangqiPtr);
				}
			}
			return newXiangqi;
		}

		#endregion

		#region getLegalMoves

		[DllImport(GameType.BundleName)]
		private static extern int xiangqi_getLegalMoves(IntPtr xiangqiPtr, int xiangqiLength, bool canCorrect, out IntPtr outLegalMovesPtr);

		public static List<LegalMove> unityGetLegalMoves(Xiangqi xiangqi, bool canCorrect)
		{
			if (xiangqi == null) {
				Debug.LogError ("xiangqi null: " + xiangqi);
				return new List<LegalMove> ();
			}
			// init
			firstInitCore ();
			// do job
			List<LegalMove> ret = new List<LegalMove>();
			{
				// make paramter
				byte[] xiangqiBytes = Xiangqi.convertToBytes (xiangqi);
				int xiangqiLength = xiangqiBytes.Length;
				IntPtr xiangqiPtr = Marshal.AllocHGlobal (xiangqiLength);
				// doMove
				try {
					Marshal.Copy (xiangqiBytes, 0, xiangqiPtr, xiangqiLength);
					// find new pos
					IntPtr outLegalMovesPtr;
					int outLegalMovesLength = xiangqi_getLegalMoves (xiangqiPtr, xiangqiLength, canCorrect, out outLegalMovesPtr);
					// process result
					if (outLegalMovesLength > 0) {
						byte[] legalMovesBytes = new byte[outLegalMovesLength];
						{
							Marshal.Copy (outLegalMovesPtr, legalMovesBytes, 0, outLegalMovesLength);
							Marshal.FreeHGlobal (outLegalMovesPtr);
						}
						// update
						{
							for(int i=0; i<legalMovesBytes.Length; i+=8){
								if(i+7<legalMovesBytes.Length){
									LegalMove legalMove = new LegalMove();
									{
										legalMove.move.v = BitConverter.ToUInt32(legalMovesBytes, i);
										legalMove.repStatus.v = BitConverter.ToInt32(legalMovesBytes, i+4);
									}
									ret.Add(legalMove);
								}else{
									Debug.LogError("legalMovesBytes count error: "+legalMovesBytes.Length+"; "+i+"; "+(5*i+4));
								}
							}
						}
					} else {
						Debug.LogError ("Cannot find any legal moves: " + xiangqi);
					}
				} catch (Exception e) {
					Debug.LogError (e);
				} finally {
					Marshal.FreeHGlobal (xiangqiPtr);
				}
			}
			return ret;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////
		///////////////////////////// Init //////////////////////////
		///////////////////////////////////////////////////////////////////////////////////////////////

		#region first init core

		private static bool isAlreadyInit = false;

		private static System.Object lockThis = new System.Object ();

		private static void firstInitCore()
		{
			lock (lockThis) {
				if (!isAlreadyInit) {
					isAlreadyInit = true;
					// set core
					unityInitCore();
				} else {
					// Debug.LogError ("already init core");
				}
			}
		}

		#endregion

		#region first init book

		private static bool isAlreadyInitBook = false;

		private static System.Object lockBook = new System.Object ();

		private static void firstInitBook()
		{
			lock (lockBook) {
				if (!isAlreadyInitBook) {
					isAlreadyInitBook = true;
					// set book
					{
                        string path = GameType.MakeCorePath(GameType.AlwaysIn, "Xiangqi", "BOOK.DAT");
                        bool success = unitySetBookPath(path);
                        Debug.LogError(success ? "set book path success" : "set book path fail");

                        /*#if UNITY_EDITOR
                                                {
                                                    string path = Global.DataPath + "/Plugins/Android/assets/" + GameType.AlwaysIn + "/Xiangqi/BOOK.DAT";
                                                    bool success = unitySetBookPath(path);
                                                    Debug.LogError(success ? "set book path success" : "set book path fail");
                                                }
                        #elif UNITY_STANDALONE_OSX
                                                {
                                                    string path = Global.DataPath+ "/Plugins/UnityNativeCore.bundle/Contents/Resources/"+GameType.AlwaysIn+"/Xiangqi/BOOK.DAT";
                                                    bool success = unitySetBookPath(path);
                                                    Debug.LogError(success ? "set book path success" : "set book path fail");
                                                }
                        #elif UNITY_IPHONE
                                                {
                                                    string path = Global.DataPath+ "/"+GameType.AlwaysIn+"/Xiangqi/BOOK.DAT";
                                                    bool success = unitySetBookPath(path);
                                                    Debug.LogError(success ? "set book path success" : "set book path fail");
                                                }
                        #elif UNITY_ANDROID
                                                {
                                                    string path = GameType.AlwaysIn + "/Xiangqi/BOOK.DAT";
                                                    unitySetBookPath(path);
                                                }
                        #endif*/
                    }
				} else {
					// Debug.LogError ("already init core");
				}
			}
		}

		#endregion

	}
}