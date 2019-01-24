using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Shogi.NoneRule;

namespace Shogi
{
	public class Shogi : GameType
	{

		public const string DefaultStartPositionSFEN = "lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b - 1";

		#region Property

		/** Bitboard byTypeBB_[PieceTypeNum];*/
		public LP<Common.BitBoard> byTypeBB;

		/** Bitboard byColorBB_[ColorNum];*/
		public LP<Common.BitBoard> byColorBB;

		/** Bitboard goldsBB_;*/
		public VP<Common.BitBoard> goldsBB;

		#region piece

		/** Piece piece_[SquareNum];*/
		public LP<int> piece;

		public Common.Piece getPiece(Common.Square sq)
		{ 
			int sqIndex = (int)sq;
			if (sqIndex >= 0 && sqIndex < this.piece.vs.Count) {
				return (Common.Piece)this.piece.vs [sqIndex];
			} else {
				Debug.LogError ("error, getPiece: index error: " + sqIndex + "; " + sq + "; " + this);
				return Common.Piece.Empty;
			} 
		}

		public void setPieceOn(Common.Square square, Common.Piece piece)
		{
			int sqIndex = (int)square;
			if (sqIndex >= 0 && sqIndex < this.piece.vs.Count) {
				this.piece.set (sqIndex, (int)piece);
			} else {
				Debug.LogError ("error, getPiece: index error: " + sqIndex + "; " + square + "; " + this);
			} 
		}

		#endregion

		/** Square kingSquare_[ColorNum];*/
		public LP<int> kingSquare;

		#region hand

		/** Hand hand_[ColorNum];*/
		public LP<System.UInt32> hand;

		const int HPawnShiftBits   =  0;
		const int HLanceShiftBits  =  6;
		const int HKnightShiftBits = 10;
		const int HSilverShiftBits = 14;
		const int HGoldShiftBits   = 18;
		const int HBishopShiftBits = 22;
		const int HRookShiftBits   = 25;
		const System.UInt32 HPawnMask   = 0x1f << HPawnShiftBits;
		const System.UInt32 HLanceMask  = 0x7  << HLanceShiftBits;
		const System.UInt32 HKnightMask = 0x7  << HKnightShiftBits;
		const System.UInt32 HSilverMask = 0x7  << HSilverShiftBits;
		const System.UInt32 HGoldMask   = 0x7  << HGoldShiftBits;
		const System.UInt32 HBishopMask = 0x3  << HBishopShiftBits;
		const System.UInt32 HRookMask   = 0x3  << HRookShiftBits;

		public static readonly int[] HandPieceShiftBits = {
			HPawnShiftBits,
			HLanceShiftBits,
			HKnightShiftBits,
			HSilverShiftBits,
			HGoldShiftBits,
			HBishopShiftBits,
			HRookShiftBits
		};

		public static readonly System.UInt32[] HandPieceMask = 
		{
			HPawnMask,
			HLanceMask,
			HKnightMask,
			HSilverMask,
			HGoldMask,
			HBishopMask,
			HRookMask
		};

		public static System.UInt32 numOf(uint value, Common.HandPiece handPiece)
		{
			// HandPieceMask[handPiece]
			System.UInt32 handPieceMask = HandPieceMask [0];
			{
				if ((int)handPiece >= 0 && (int)handPiece < HandPieceMask.Length) {
					handPieceMask = HandPieceMask [(int)handPiece];
				} else {
					Debug.LogError ("error, handPieceMask: " + handPiece);
				}
			}
			// HandPieceShiftBits[handPiece]
			int handPieceShiftBits = HandPieceShiftBits[0];
			{
				if ((int)handPiece >= 0 && (int)handPiece < HandPieceShiftBits.Length) {
					handPieceShiftBits = HandPieceShiftBits [(int)handPiece];
				} else {
					Debug.LogError ("error, handPieceShiftBits: " + handPiece);
				}
			}
			// return
			return (value & handPieceMask) >> handPieceShiftBits;
		}

		public static uint getHand(List<uint> hand, Common.Color c)
		{ 
			if ((int)c >= 0 && (int)c < hand.Count) {
				return hand [(int)c]; 
			} else {
				Debug.LogError ("get hand error: " + c);
				return 0;
			}
		}

		#region setHand

		public static readonly uint[] HandPieceOne = {
			1 << HPawnShiftBits,
			1 << HLanceShiftBits,
			1 << HKnightShiftBits,
			1 << HSilverShiftBits,
			1 << HGoldShiftBits,
			1 << HBishopShiftBits,
			1 << HRookShiftBits
		};

		public void setPieceCountInHand (Common.HandPiece handPiece, Common.Color color, int pieceCount)
		{
			// find handPieceOne
			uint handPieceOne = HandPieceOne [0];
			{
				if ((int)handPiece >= 0 && (int)handPiece < HandPieceOne.Length) {
					handPieceOne = HandPieceOne [(int)handPiece];
				} else {
					Debug.LogError ("error, handPieceShiftBits: " + handPiece);
				}
			}
			Debug.LogError ("setPieceCountInHand: " + handPiece + ", " + color + ", " + pieceCount + ", " + handPieceOne);
			// get current
			uint hand = getHand (this.hand.vs, color);
			// get new hand
			uint currentCount = numOf(hand, handPiece);
			hand += (uint)((pieceCount - currentCount) * handPieceOne);
			// set
			this.hand.set ((int)color, hand);
		}

		#endregion

		#endregion

		// black move first, white move later
		/** Color turn_;*/
		public VP<int> turn;

		/** EvalList evalList_;*/
		public VP<EvalList> evalList;

		/** StateInfo startState_; : theo thu tu tu turn thap den turn cao*/
		public LP<StateInfo> startState;

		/** StateInfo* st_; : theo thu tu tu turn thap den turn cao*/
		public LP<StateInfo> st;

		public System.UInt64 getKey() 
		{ 
			StateInfo stateInfo = null;
			{
				if (st.vs.Count > 0) {
					stateInfo = st.vs [st.vs.Count - 1];
				} else {
					Debug.LogError ("why st count = 0: " + this);
				}
			}
			return stateInfo != null ? stateInfo.key() : 0; 
		}

		public Common.BitBoard getCheckers()
		{
			if (this.st.vs.Count > 0) {
				StateInfo st = this.st.vs [this.st.vs.Count - 1];
				return st.checkersBB.v;
			} else {
				return new Common.BitBoard ();
			}
		}

		public struct CheckerInfo
		{
			public Common.Square square;
			public Common.Piece piece;

			public override string ToString ()
			{
				return "" + square + ";" + piece;
			}
		}

		public List<CheckerInfo> getCheckersPositionList()
		{
			List<CheckerInfo> ret = new List<CheckerInfo> ();
			{
				Common.BitBoard checkers = this.getCheckers ();
				List<Common.Square> squares = Core.unityGetCheckersFromBitBoard (checkers);
				for (int i = 0; i < squares.Count; i++) {
					Common.Square square = squares [i];
					// Make new checkerInfo
					{
						CheckerInfo checkerInfo = new CheckerInfo ();
						{
							checkerInfo.square = square;
							// get piece
							{
								Common.Piece piece = Common.Piece.Empty;
								{
									int index = (int)square;
									if (index >= 0 && index < this.piece.vs.Count) {
										piece = (Common.Piece)this.piece.vs [index];
									} else {
										Debug.LogError ("index error: " + index + "; " + this.piece.vs.Count);
									}
								}
								checkerInfo.piece = piece;
							}
						}
						ret.Add (checkerInfo);
					}
				}
			}
			return ret;
		}

		/** Ply gamePly_;*/
		public VP<int> gamePly;

		/** s64 nodes_;*/
		public VP<System.Int64> nodes;

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			byTypeBB,
			byColorBB,
			goldsBB,
			piece,
			kingSquare,
			hand,
			turn,
			evalList,
			startState,
			st,
			gamePly,
			nodes,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Shogi()
		{
			AllowNames.Add ((byte)Property.byTypeBB);
			AllowNames.Add ((byte)Property.byColorBB);
			AllowNames.Add ((byte)Property.goldsBB);
			AllowNames.Add ((byte)Property.piece);
			AllowNames.Add ((byte)Property.kingSquare);
			AllowNames.Add ((byte)Property.hand);
			AllowNames.Add ((byte)Property.turn);
			AllowNames.Add ((byte)Property.evalList);
			AllowNames.Add ((byte)Property.startState);
			AllowNames.Add ((byte)Property.st);
			AllowNames.Add ((byte)Property.gamePly);
			AllowNames.Add ((byte)Property.nodes);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Shogi() : base()
		{
			this.byTypeBB = new LP<Common.BitBoard>(this, (byte)Property.byTypeBB);
			this.byColorBB = new LP<Common.BitBoard>(this, (byte)Property.byColorBB);
			this.goldsBB = new VP<Common.BitBoard>(this, (byte)Property.goldsBB, new Common.BitBoard());
			this.piece = new LP<int>(this, (byte)Property.piece);
			this.kingSquare = new LP<int>(this, (byte)Property.kingSquare);
			this.hand = new LP<uint>(this, (byte)Property.hand);
			this.turn = new VP<int>(this, (byte)Property.turn, (int)Common.Color.Black);
			this.evalList = new VP<EvalList>(this, (byte)Property.evalList, new EvalList());
			this.startState = new LP<StateInfo>(this, (byte)Property.startState);
			this.st = new LP<StateInfo>(this, (byte)Property.st);
			this.gamePly = new VP<int>(this, (byte)Property.gamePly, 0);
			this.nodes = new VP<long>(this, (byte)Property.nodes, 0);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// board
				if (ret) {
					if (this.piece.vs.Count == 0) {
						Debug.LogError ("Don't have piece");
						ret = false;
					}
				}
				// st
				if (ret) {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ShogiIdentity) {
							ShogiIdentity shogiIdentity = dataIdentity as ShogiIdentity;
							if (shogiIdentity.startState != this.startState.vs.Count || shogiIdentity.st != this.st.vs.Count) {
								Debug.LogError ("st not load full");
								ret = false;
							}
						} else {
							Debug.LogError ("why not chessIdentity");
						}
					}
				}
			}
			return ret;
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Shogi shogi, bool needCheckCustom = true)
		{
			// custom
			if (shogi.isCustom.v && needCheckCustom) {
				string strFen = Common.positionToFen (shogi);
				// Debug.LogError ("shogi custom fen: " + strFen);
				Shogi newShogi = Core.unityMakePositionByFen (strFen);
				return convertToBytes (newShogi);
			}
			// normal
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// Bitboard byTypeBB_[PieceTypeNum];
						{
							if (shogi.byTypeBB.vs.Count != (int)Common.PieceType.PieceTypeNum) {
								Debug.LogError ("parse shogi byTypeBB count error");
							}
							for (int i = 0; i < (int)Common.PieceType.PieceTypeNum; i++) {
								// get value
								Common.BitBoard value = new Common.BitBoard ();
								{
									if (i < shogi.byTypeBB.vs.Count) {
										value = shogi.byTypeBB.vs [i];
									} else {
										Debug.LogError ("index error:  byTypeBB: " + shogi);
									}
								}
								// write
								writer.Write (value.p0);
								writer.Write (value.p1);
							}
						}

						// Bitboard byColorBB_[ColorNum];
						{
							if (shogi.byColorBB.vs.Count != (int)Common.Color.ColorNum) {
								Debug.LogError ("parse shogi byColorBB count error");
							}
							for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
								// get value
								Common.BitBoard value = new Common.BitBoard ();
								{
									if (i < shogi.byColorBB.vs.Count) {
										value = shogi.byColorBB.vs [i];
									} else {
										Debug.LogError ("index error:  byColorBB: " + shogi);
									}
								}
								// write
								writer.Write (value.p0);
								writer.Write (value.p1);
							}
						}
						// Bitboard goldsBB_;
						{
							writer.Write (shogi.goldsBB.v.p0);
							writer.Write (shogi.goldsBB.v.p1);
						}
						// Piece piece_[SquareNum];
						{
							if (shogi.piece.vs.Count != (int)Common.Square.SquareNum) {
								Debug.LogError ("parse shogi piece count error");
							}
							for (int i = 0; i < (int)Common.Square.SquareNum; i++) {
								// get value
								int value = 0;
								{
									if (i < shogi.piece.vs.Count) {
										value = shogi.piece.vs [i];
									} else {
										Debug.LogError ("index error:  piece: " + shogi);
									}
								}
								// write
								writer.Write (value);
							}
						}
						// Square kingSquare_[ColorNum];
						{
							if (shogi.kingSquare.vs.Count != (int)Common.Color.ColorNum) {
								Debug.LogError ("parse shogi kingSquare count error");
							}
							for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
								// get value
								int value = 0;
								{
									if (i < shogi.kingSquare.vs.Count) {
										value = shogi.kingSquare.vs [i];
									} else {
										Debug.LogError ("index error:  kingSquare: " + shogi);
									}
								}
								// write
								writer.Write (value);
							}
						}

						// Hand hand_[ColorNum];
						{
							if (shogi.hand.vs.Count != (int)Common.Color.ColorNum) {
								Debug.LogError ("parse shogi hand count error");
							}
							for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
								// get value
								uint value = 0;
								{
									if (i < shogi.hand.vs.Count) {
										value = shogi.hand.vs [i];
									} else {
										Debug.LogError ("index error:  hand: " + shogi);
									}
								}
								// write
								writer.Write (value);
							}
						}
						// Color turn_;
						writer.Write(shogi.turn.v);
						// EvalList evalList_;
						writer.Write(EvalList.convertToBytes(shogi.evalList.v));
						// StateInfo startState_;
						{
							writer.Write (shogi.startState.vs.Count);// int
							for (int i = 0; i < shogi.startState.vs.Count; i++) {
								StateInfo stateInfo = shogi.startState.vs [i];
								writer.Write (StateInfo.convertToBytes (stateInfo));
							}
						}
						// StateInfo* st_;
						{
							writer.Write (shogi.st.vs.Count);
							for (int i = 0; i < shogi.st.vs.Count; i++) {
								StateInfo stateInfo = shogi.st.vs [i];
								writer.Write (StateInfo.convertToBytes (stateInfo));
							}
						}
						// Ply gamePly_;
						writer.Write(shogi.gamePly.v);
						// s64 nodes_;
						writer.Write(shogi.nodes.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static bool parseLog = false;

		public static int parse(Shogi shogi, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: byTypeBB: " + count);
						// Bitboard byTypeBB_[PieceTypeNum];
						shogi.byTypeBB.clear();
						for (int i = 0; i < (int)Common.PieceType.PieceTypeNum; i++) {
							// p0
							System.UInt64 p0 = 0;
							if (isParseCorrect) {
								if (count + sizeof(ulong) <= byteArray.Length) {
									p0 = BitConverter.ToUInt64 (byteArray, count);
									count += sizeof(ulong);
								} else {
									Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
								}
							}
							// p1
							System.UInt64 p1 = 0;
							if (isParseCorrect) {
								if (count + sizeof(ulong) <= byteArray.Length) {
									p1 = BitConverter.ToUInt64 (byteArray, count);
									count += sizeof(ulong);
								} else {
									Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
								}
							}
							// set value
							if (isParseCorrect) {
								shogi.byTypeBB.add (new Common.BitBoard (p0, p1));
							}
						}
					}
					break;
				case 1:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: byColorBB: " + count);
						// Bitboard byColorBB_[ColorNum];
						shogi.byColorBB.clear();
						for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
							// p0
							System.UInt64 p0 = 0;
							if (isParseCorrect) {
								if (count + sizeof(ulong) <= byteArray.Length) {
									p0 = BitConverter.ToUInt64 (byteArray, count);
									count += sizeof(ulong);
								} else {
									Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
								}
							}
							// p1
							System.UInt64 p1 = 0;
							if (isParseCorrect) {
								if (count + sizeof(ulong) <= byteArray.Length) {
									p1 = BitConverter.ToUInt64 (byteArray, count);
									count += sizeof(ulong);
								} else {
									Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
								}
							}
							// set value
							if (isParseCorrect) {
								shogi.byColorBB.add (new Common.BitBoard (p0, p1));
							}
						}
					}
					break;
				case 2:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: goldsBB: " + count);
						// Bitboard goldsBB_;
						// p0
						System.UInt64 p0 = 0;
						if (isParseCorrect) {
							if (count + sizeof(ulong) <= byteArray.Length) {
								p0 = BitConverter.ToUInt64 (byteArray, count);
								count += sizeof(ulong);
							} else {
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// p1
						System.UInt64 p1 = 0;
						if (isParseCorrect) {
							if (count + sizeof(ulong) <= byteArray.Length) {
								p1 = BitConverter.ToUInt64 (byteArray, count);
								count += sizeof(ulong);
							} else {
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// set value
						if (isParseCorrect) {
							shogi.goldsBB.v = new Common.BitBoard (p0, p1);
						}
					}
					break;
				case 3:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: piece: " + count);
						// Piece piece_[SquareNum];
						shogi.piece.clear();
						for (int i = 0; i < (int)Common.Square.SquareNum; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								shogi.piece.add(BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								Debug.LogError ("array not enough length: piece: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 4:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: kingSquare: " + count);
						// Square kingSquare_[ColorNum];
						shogi.kingSquare.clear();
						for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								shogi.kingSquare.add(BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								Debug.LogError ("array not enough length: kingSquare: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 5:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: hand: " + count);
						// Hand hand_[ColorNum];
						shogi.hand.clear();
						for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
							if (count + sizeof(uint) <= byteArray.Length) {
								shogi.hand.add(BitConverter.ToUInt32 (byteArray, count));
								count += sizeof(uint);
							} else {
								Debug.LogError ("array not enough length: kingSquare: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 6:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: turn: " + count);
						// Color turn_;
						if (count + sizeof(int) <= byteArray.Length) {
							shogi.turn.v = BitConverter.ToInt32 (byteArray, count);
							count += sizeof(int);
						} else {
							Debug.LogError ("array not enough length: turn: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 7:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: evalList: " + count);
						// EvalList evalList_;
						EvalList evalList = new EvalList();
						// parse
						{
							int byteLength = EvalList.parse (evalList, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							evalList.uid = shogi.evalList.makeId ();
							shogi.evalList.v = evalList;
						} else {
							Debug.LogError ("parse evalList error");
						}
					}
					break;
				case 8:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: startState: " + count);
						// StateInfo startState_;
						shogi.startState.clear ();
						int stateInfoNumber = 0;
						{
							if (count + sizeof(int) <= byteArray.Length) {
								stateInfoNumber = BitConverter.ToInt32 (byteArray, count);
								count += sizeof(int);
							} else {
								Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// parse
						{
							// Debug.LogError ("parse position stateInfo: " + stateInfoNumber);
							// get list of stateInfo
							List<StateInfo> sts = new List<StateInfo> ();
							for (int i = 0; i < stateInfoNumber; i++) {
								StateInfo st = new StateInfo ();
								int stateInfoByteLength = StateInfo.parse (st, byteArray, count);
								if (stateInfoByteLength > 0) {
									// add to chess
									sts.Add (st);
									// increase pointer
									count += stateInfoByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
							// add to chess data
							for (int i = 0; i < sts.Count; i++) {
								StateInfo st = sts [i];
								st.uid = shogi.startState.makeId ();
								shogi.startState.add (st);
							}
							// Debug.LogError ("shogi startState: " + shogi.startState.vs.Count);
						}
					}
					break;
				case 9:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: st: " + count);
						// StateInfo* st_;
						shogi.st.clear ();
						int stateInfoNumber = 0;
						{
							if (count + sizeof(int) <= byteArray.Length) {
								stateInfoNumber = BitConverter.ToInt32 (byteArray, count);
								count += sizeof(int);
							} else {
								Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// parse
						{
							// Debug.LogError ("parse position stateInfo: " + stateInfoNumber);
							// get list of stateInfo
							List<StateInfo> sts = new List<StateInfo> ();
							for (int i = 0; i < stateInfoNumber; i++) {
								StateInfo st = new StateInfo ();
								int stateInfoByteLength = StateInfo.parse (st, byteArray, count);
								if (stateInfoByteLength > 0) {
									// add to chess
									sts.Add (st);
									// increase pointer
									count += stateInfoByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
							// add to chess data
							for (int i = 0; i < sts.Count; i++) {
								StateInfo st = sts [i];
								{
									st.uid = shogi.st.makeId ();
								}
								shogi.st.add (st);
							}
							// Debug.LogError ("shogi st: " + shogi.st.vs.Count);
						}
					}
					break;
				case 10:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: gamePly: " + count);
						// Ply gamePly_;
						if (count + sizeof(int) <= byteArray.Length) {
							shogi.gamePly.v = BitConverter.ToInt32 (byteArray, count);
							count += sizeof(int);
						} else {
							Debug.LogError ("array not enough length: gamePly: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 11:
					{
						if (parseLog)
							Debug.LogError ("parse shogi: nodes_: " + count);
						// s64 nodes_;
						if (count + sizeof(long) <= byteArray.Length) {
							shogi.nodes.v = BitConverter.ToInt64 (byteArray, count);
							count += sizeof(long);
						} else {
							Debug.LogError ("array not enough length: gamePly: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				// Debug.LogError ("count: " + count + "; " + index);
				index++;
				if (!isParseCorrect) {
					Debug.LogError ("not parse correct");
					break;
				}
				if (alreadyPassAll) {
					break;
				}
			}
			// return
			if (!isParseCorrect) {
				Debug.LogError ("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

		#endregion

		#region implement interface

		public override Type getType ()
		{
			return GameType.Type.SHOGI;
		}

		public override int getTeamCount ()
		{
			return 2;
		}

		public override int getPerspectiveCount ()
		{
			return 2;
		}

		public override int getPlayerIndex ()
		{
			// Black move first
			switch (this.turn.v) {
			case (int)Common.Color.Black:
				return 0;
			case (int)Common.Color.White:
				return 1;
			default:
				Debug.LogError ("unknown turn : " + this.turn.v);
				return 0;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.ShogiMove:
						{
							ShogiMove shogiMove = (ShogiMove)gameMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, shogiMove.move.v);
						}
					// break;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.ShogiCustomSet:
					case GameMove.Type.ShogiCustomMove:
					case GameMove.Type.ShogiCustomHand:
					case GameMove.Type.Clear:
					case GameMove.Type.EndTurn:
						return true;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						return true;
					}
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
			return false;
		}

		#region processGameMove

		private void processCustomGameMove(GameMove gameMove)
		{
			if (gameMove != null) {
				// make tempShogi
				Shogi tempShogi = DataUtils.cloneData (this) as Shogi;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.ShogiCustomSet:
						{
							NoneRule.ShogiCustomSet shogiCustomSet = gameMove as NoneRule.ShogiCustomSet;
							// set piece
							{
								tempShogi.setPieceOn (shogiCustomSet.square.v, shogiCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempShogi.piece.vs.Count; i++) {
								tempShogi.piece.vs [i] = (int)Common.Piece.Empty;
							}
						}
						break;
					case GameMove.Type.ShogiCustomMove:
						{
							NoneRule.ShogiCustomMove shogiCustomMove = gameMove as NoneRule.ShogiCustomMove;
							// update
							{
								tempShogi.setPieceOn (shogiCustomMove.dest.v, tempShogi.getPiece (shogiCustomMove.from.v));
								tempShogi.setPieceOn (shogiCustomMove.from.v, Common.Piece.Empty);
							}
						}
						break;
					case GameMove.Type.ShogiCustomHand:
						{
							ShogiCustomHand shogiCustomHand = gameMove as ShogiCustomHand;
							// Debug.LogError ("shogiCustomHand: " + shogiCustomHand.print ());
							// update
							{
								tempShogi.setPieceCountInHand (shogiCustomHand.handPiece.v, shogiCustomHand.color.v, shogiCustomHand.pieceCount.v);
							}
						}
						break;
					default:
						Debug.LogError ("unknown type: " + gameMove.getType () + "; " + this);
						needUpdate = false;
						break;
					}
				}
				// Update
				if (needUpdate) {
					tempShogi.isCustom.v = true;
					DataUtils.copyData (this, tempShogi, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove (GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.ShogiMove:
				{
					// get information
					ShogiMove shogiMove = (ShogiMove)gameMove;
					// make request to native
					Shogi newShogi = Core.unityDoMove (this, Core.CanCorrect, shogiMove.move.v);
					// update
					DataUtils.copyData (this, newShogi, AllowNames);
				}
				break;
			case GameMove.Type.EndTurn:
				{
					if (this.turn.v == (int)Common.Color.Black) {
						this.turn.v = (int)Common.Color.White;
					} else {
						this.turn.v = (int)Common.Color.Black;
					}
					this.isCustom.v = true;
				}
				break;
			case GameMove.Type.None:
				break;
			case GameMove.Type.ShogiCustomMove:
			case GameMove.Type.ShogiCustomSet:
			case GameMove.Type.ShogiCustomHand:
			case GameMove.Type.Clear:
				this.processCustomGameMove (gameMove);
				break;
			default:
				Debug.LogError ("unknown gameMove: " + gameMove + "; " + this);
				this.processCustomGameMove (gameMove);
				break;
			}
		}

		#endregion

		#region getAIMove

		public override GameMove getAIMove (Computer.AI computerAI, bool isFindHint)
		{
			GameMove ret = new NonMove ();
			{
				// check is userNormalMove
				bool useNormalMove = true;
				{
					if (GameData.IsUseRule (this)) {
						useNormalMove = true;
					} else {
						useNormalMove = false;
						/*GameData gameData = this.findDataInParent<GameData>();
						if (gameData != null) {
							Turn turn = gameData.turn.v;
							if (turn != null) {
								if (turn.turn.v % 4 == 0 || turn.turn.v % 4 == 2) {
									useNormalMove = false;
								}
							} else {
								Debug.LogError ("turn null: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}*/
					}
				}
				// process
				if (useNormalMove) {
					// sleep until get enough data
					{
						int count = 0;
						while (true) {
							if (isLoadFull ()) {
								break;
							} else {
								System.Threading.Thread.Sleep (1000);
								Debug.LogError ("need sleep: " + count);
								count++;
								if (count >= 360) {
									Debug.LogError ("why don't have data");
									return new NonMove ();
								}
							}
						}
					}
					// find ai
					ShogiAI ai = (computerAI != null && computerAI is ShogiAI) ? (ShogiAI)computerAI : new ShogiAI ();
					// search
					uint move = Core.unityLetComputerThink (this, Core.CanCorrect, ai.depth.v, ai.skillLevel.v, 
						ai.mr.v, ai.duration.v, ai.useBook.v);
					// Debug.LogError ("find shogi move: " + move + "; " + Core.unityMoveToString (move) + "; " + byteArray.Length);
					if (move != 0) {
						ShogiMove shogiMove = new ShogiMove ();
						{
							shogiMove.move.v = move;
						}
						ret = shogiMove;
					} else {
						Debug.LogError ("why cannot find move: " + this);
					}
				} else {
					GameMove customMove = getCustomMove ();
					if (customMove != null) {
						ret = customMove;
					} else {
						Debug.LogError ("customMove null: " + this);
					}
				}
			}
			return ret;
		}

		public GameMove getCustomMove()
		{
			// find moves
			List<GameMove> moves = new List<GameMove> ();
			{
				// get inHand
				{
					Common.Color[] colors = { Common.Color.White, Common.Color.Black };
					foreach (Common.Color color in colors) {
						foreach (Common.HandPiece handPiece in Common.CanChosenPieces) {
							uint currentPieceCount = Shogi.numOf (Shogi.getHand (this.hand.vs, color), handPiece);
							for (int pieceCount = 0; pieceCount < 8; pieceCount++) {
								if (currentPieceCount != pieceCount) {
									ShogiCustomHand shogiCustomHand = new ShogiCustomHand ();
									{
										shogiCustomHand.handPiece.v = handPiece;
										shogiCustomHand.color.v = color;
										shogiCustomHand.pieceCount.v = pieceCount;
									}
									moves.Add (shogiCustomHand);
								}
							}
						}
					}
				}
				// get custom set
				{
					for (int x = 0; x < 9; x++) {
						for (int y = 0; y < 9; y++) {
							Common.Square square = Common.makeSquare ((Common.File)x, (Common.Rank)y);
							// get current
							Common.Piece currentPiece = this.getPiece (square);
							if (Common.isRealPiece(currentPiece)) {
								if (currentPiece != Common.Piece.BKing && currentPiece != Common.Piece.WKing) {
									foreach (Common.Piece piece in Common.CanChosenPieces) {
										if (piece != currentPiece && piece != Common.Piece.BKing && piece != Common.Piece.WKing) {
											NoneRule.ShogiCustomSet shogiCustomSet = new NoneRule.ShogiCustomSet ();
											{
												shogiCustomSet.square.v = square;
												shogiCustomSet.piece.v = piece;
											}
											moves.Add (shogiCustomSet);
										}
									}
								}
							}
						}
					}
				}
				// get custom move
				{
					for (int x = 0; x < 9; x++) {
						for (int y = 0; y < 9; y++) {
							Common.Square square = Common.makeSquare ((Common.File)x, (Common.Rank)y);
							Common.Piece piece = this.getPiece (square);
							if (Common.isRealPiece(piece)) {
								if (piece != Common.Piece.BKing && piece != Common.Piece.WKing) {
									for (int destX = 0; destX < 9; destX++) {
										for (int destY = 0; destY < 9; destY++) {
											if (destX != x || destY != y) {
												Common.Square destSquare = Common.makeSquare ((Common.File)destX, (Common.Rank)destY);
												Common.Piece destPiece = this.getPiece (destSquare);
												if (destPiece != Common.Piece.BKing && destPiece != Common.Piece.WKing) {
													ShogiCustomMove shogiCustomMove = new ShogiCustomMove ();
													{
														shogiCustomMove.from.v = square;
														shogiCustomMove.dest.v = destSquare;
													}
													moves.Add (shogiCustomMove);
												}
											}
										}
									}
								}
							}
						}
					}
				}
				// get clear
				{
					Clear clear = new Clear ();
					{

					}
					moves.Add (clear);
				}
				// endTurn
				{
					EndTurn endTurn = new EndTurn ();
					{

					}
					moves.Add (endTurn);
				}
			}
			// choose
			if (moves.Count > 0) {
				System.Random random = new System.Random ();
				int index = random.Next (0, moves.Count);
				if (index >= 0 && index < moves.Count) {
					return moves [index];
				} else {
					Debug.LogError ("index error: " + index + "; " + this);
					return null;
				}
			} else {
				return null;
			}
		}

		#endregion

		public override Result isGameFinish ()
		{
			Result result = Result.makeDefault ();
			// process
			if (GameData.IsUseRule (this)) {
				int isGameFinish = Core.unityIsGameFinish (this, Core.CanCorrect);
				switch (isGameFinish) {
				case 0:
					{
						result.isGameFinish = false;
					}
					break;
				case 1:
					// black win
					{
						// Debug.LogError ("black: PlayerIndex 0 win: \n" + Core.unityPositionToString (Shogi.convertToBytes (this), Core.CanCorrect));
						Debug.LogError ("checkers: " + this.getCheckers ());
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 1));// black
						result.scores.Add (new GameType.Score (1, 0));// white
					}
					break;
				case 2:
					// white win
					{
						// Debug.LogError ("white: PlayerIndex 1 win: \n" + Core.unityPositionToString (Shogi.convertToBytes (this), Core.CanCorrect));
						Debug.LogError ("checkers: " + this.getCheckers ());
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0));// white
						result.scores.Add (new GameType.Score (1, 1));// black
					}
					break;
				case 3:
					// draw
					{
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0));// white
						result.scores.Add (new GameType.Score (1, 0));// black
					}
					break;
				default:
					Debug.LogError ("unknown result: " + this);
					break;
				}
			} else {
				bool isTooManyTurn = false;
				{
					GameData gameData = this.findDataInParent<GameData> ();
					if (gameData != null) {
						Turn turn = gameData.turn.v;
						if (turn != null) {
							if (turn.turn.v >= 1000) {
								isTooManyTurn = true;
							}
						} else {
							Debug.LogError ("turn null: " + this);
						}
					} else {
						Debug.LogError ("gameData null: " + this);
					}
				}
				if (isTooManyTurn) {
					// draw
					result.isGameFinish = true;
					// score
					result.scores.Add (new GameType.Score (0, 0.5f));// white
					result.scores.Add (new GameType.Score (1, 0.5f));// black
				}
			}
			// return
			return result;
		}

		#endregion

	}
}