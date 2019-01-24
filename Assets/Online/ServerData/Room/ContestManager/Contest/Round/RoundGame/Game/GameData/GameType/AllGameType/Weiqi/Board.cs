using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Weiqi
{
	/** TODO neu ko use rule, co the cho size2 = -1 lam dau hieu*/
	public class Board : Data
	{
		public const int history_hash_bits = 12;

		private static readonly bool log = false;

		/** int size;*/
		public VP<int> size;
		/** int size2;*/
		public VP<int> size2;
		/** int bits2;*/
		public VP<int> bits2;
		/** int captures[S_MAX];*/
		public LP<int> captures;
		/** float komi;*/
		public VP<float> komi;
		/** int handicap;*/
		public VP<int> handicap;
		/** enum go_ruleset rules;*/
		public VP<int> rules;

		/** int moves;*/
		public VP<int> moves;
		/** struct move last_move;*/
		public VP<WeiqiMove> last_move;
		/** struct move last_move2;*/
		public VP<WeiqiMove> last_move2;
		/** FB_ONLY(struct move last_move3);*/
		public VP<WeiqiMove> last_move3;
		/** FB_ONLY(struct move last_move4);*/
		public VP<WeiqiMove> last_move4;
		/** FB_ONLY(bool superko_violation);*/
		public VP<byte> superko_violation;

		/** enum stone b[BOARD_MAX_COORDS];*/
		public LP<int> b;
		/** group_t g[BOARD_MAX_COORDS];*/
		public LP<int> g;
		/** coord_t p[BOARD_MAX_COORDS];*/
		public LP<int> pp;

		/** FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];*/
		public LP<System.UInt32> pat3;

		/** struct group gi[BOARD_MAX_COORDS];*/
		public LP<Group> gi;

		/** FB_ONLY(group_t c)[BOARD_MAX_GROUPS];*/
		public LP<int> c;
		/** FB_ONLY(int clen);*/
		public VP<int> clen;

		/** FB_ONLY(struct board_symmetry symmetry);*/
		public VP<BoardSymmetry> symmetry;

		/** FB_ONLY(struct move last_ko);*/
		public VP<WeiqiMove> last_ko;
		/** FB_ONLY(int last_ko_age);*/
		public VP<int> last_ko_age;

		/** struct move ko;*/
		public VP<WeiqiMove> ko;

		/** int quicked;*/
		public VP<int> quicked;

		/** FB_ONLY(hash_t history_hash)[1 << history_hash_bits];*/
		public LP<System.UInt64> history_hash;
		/** FB_ONLY(hash_t hash);*/
		public VP<System.UInt64> hash;
		/** FB_ONLY(hash_t qhash)[4];*/
		public LP<System.UInt64> qhash;

		#region method

		public int getCaptures(int color)
		{
			if (color >= 0 && color < this.captures.vs.Count) {
				return this.captures.vs [color];
			} else {
				Debug.LogError ("error, getCaptures: unknown color: " + color);
				return 0;
			}
		}

		public static Common.stone GetBoardStone(List<int> b, int coord)
		{
			if (coord >= 0 && coord < b.Count) {
				return (Common.stone)b [coord];
			} else {
				return (Common.stone)0;
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			size,
			size2,
			bits2,
			captures,
			komi,
			handicap,
			rules,

			moves,
			last_move,
			last_move2,
			last_move3,
			last_move4,
			superko_violation,

			b,
			g,
			pp,

			pat3,

			gi,

			c,
			clen,

			symmetry,

			last_ko,
			last_ko_age,

			ko,

			quicked,

			history_hash,
			hash,
			qhash
		}

		public Board() : base()
		{
			/** int size;*/
			this.size = new VP<int> (this, (byte)Property.size, 0);
			/** int size2;*/
			this.size2 = new VP<int> (this, (byte)Property.size2, 0);
			/** int bits2;*/
			this.bits2 = new VP<int> (this, (byte)Property.bits2, 0);
			/** int captures[S_MAX];*/
			this.captures = new LP<int> (this, (byte)Property.captures);
			/** float komi;*/
			this.komi = new VP<float> (this, (byte)Property.komi, 0);
			/** int handicap;*/
			this.handicap = new VP<int> (this, (byte)Property.handicap, 0);
			/** enum go_ruleset rules;*/
			this.rules = new VP<int> (this, (byte)Property.rules, 0);

			/** int moves;*/
			this.moves = new VP<int> (this, (byte)Property.moves, 0);
			/** struct move last_move;*/
			this.last_move = new VP<WeiqiMove> (this, (byte)Property.last_move, new WeiqiMove ());
			/** struct move last_move2;*/
			this.last_move2 = new VP<WeiqiMove> (this, (byte)Property.last_move2, new WeiqiMove ());
			/** FB_ONLY(struct move last_move3);*/
			this.last_move3 = new VP<WeiqiMove> (this, (byte)Property.last_move3, new WeiqiMove ());
			/** FB_ONLY(struct move last_move4);*/
			this.last_move4 = new VP<WeiqiMove> (this, (byte)Property.last_move4, new WeiqiMove ());
			/** FB_ONLY(bool superko_violation);*/
			this.superko_violation = new VP<byte> (this, (byte)Property.superko_violation, 0);

			/** enum stone b[BOARD_MAX_COORDS];*/
			this.b = new LP<int> (this, (byte)Property.b);
			/** group_t g[BOARD_MAX_COORDS];*/
			this.g = new LP<int> (this, (byte)Property.g);
			/** coord_t p[BOARD_MAX_COORDS];*/
			this.pp = new LP<int> (this, (byte)Property.pp);

			/** FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];*/
			this.pat3 = new LP<uint> (this, (byte)Property.pat3);

			/** struct group gi[BOARD_MAX_COORDS];*/
			this.gi = new LP<Group> (this, (byte)Property.gi);

			/** FB_ONLY(group_t c)[BOARD_MAX_GROUPS];*/
			this.c = new LP<int> (this, (byte)Property.c);
			/** FB_ONLY(int clen);*/
			this.clen = new VP<int> (this, (byte)Property.clen, 0);

			/** FB_ONLY(struct board_symmetry symmetry);*/
			this.symmetry = new VP<BoardSymmetry> (this, (byte)Property.symmetry, new BoardSymmetry ());

			/** FB_ONLY(struct move last_ko);*/
			this.last_ko = new VP<WeiqiMove> (this, (byte)Property.last_ko, new WeiqiMove ());
			/** FB_ONLY(int last_ko_age);*/
			this.last_ko_age = new VP<int> (this, (byte)Property.last_ko_age, 0);

			/** struct move ko;*/
			this.ko = new VP<WeiqiMove> (this, (byte)Property.ko, new WeiqiMove ());

			/** int quicked;*/
			this.quicked = new VP<int> (this, (byte)Property.quicked, 0);

			/** FB_ONLY(hash_t history_hash)[1 << history_hash_bits];*/
			this.history_hash = new LP<ulong> (this, (byte)Property.history_hash);
			/** FB_ONLY(hash_t hash);*/
			this.hash = new VP<ulong> (this, (byte)Property.hash, 0);
			/** FB_ONLY(hash_t qhash)[4];*/
			this.qhash = new LP<ulong> (this, (byte)Property.qhash);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// b
				if (ret) {
					if (this.b.vs.Count == 0) {
						Debug.LogError ("b don't have piece");
						ret = false;
					}
				}
				// gi
				if (ret) {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is BoardIdentity) {
							BoardIdentity boardIdentity = dataIdentity as BoardIdentity;
							if (boardIdentity.gi != this.gi.vs.Count) {
								Debug.LogError ("gi not load full");
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

		public static byte[] convertToBytes(Board board)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** int size;*/
						writer.Write (board.size.v);
						/** int size2;*/
						writer.Write (board.size2.v);
						/** int bits2;*/
						writer.Write (board.bits2.v);
						/** int captures[S_MAX];*/
						{
							for (int i = 0; i < (int)Common.stone.S_MAX; i++) {
								// get value
								int value = 0;
								{
									if (i < board.captures.vs.Count) {
										value = board.captures.vs [i];
									} else {
										Debug.LogError ("error, index:  captures: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** float komi;*/
						writer.Write (board.komi.v);
						/** int handicap;*/
						writer.Write (board.handicap.v);
						/** enum go_ruleset rules;*/
						writer.Write (board.rules.v);

						/** int moves;*/
						writer.Write (board.moves.v);
						/** struct move last_move;*/
						writer.Write (WeiqiMove.convertToBytes (board.last_move.v));
						/** struct move last_move2;*/
						writer.Write (WeiqiMove.convertToBytes (board.last_move2.v));
						/** FB_ONLY(struct move last_move3);*/
						writer.Write (WeiqiMove.convertToBytes (board.last_move3.v));
						/** FB_ONLY(struct move last_move4);*/
						writer.Write (WeiqiMove.convertToBytes (board.last_move4.v));
						/** FB_ONLY(bool superko_violation);*/
						writer.Write (board.superko_violation.v);

						/** enum stone b[BOARD_MAX_COORDS];*/
						{
							// this.b = new LP<int> (this, Property.b.ToString ());
							for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
								// get value
								int value = 0;
								{
									if (i < board.b.vs.Count) {
										value = board.b.vs [i];
									} else {
										Debug.LogError ("error, index:  b: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** group_t g[BOARD_MAX_COORDS];*/
						{
							// this.g = new LP<int> (this, Property.g.ToString ());
							for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
								// get value
								int value = 0;
								{
									if (i < board.g.vs.Count) {
										value = board.g.vs [i];
									} else {
										Debug.LogError ("error, index:  g: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** coord_t p[BOARD_MAX_COORDS];*/
						{
							// this.pp = new LP<int> (this, Property.pp.ToString ());
							for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
								// get value
								int value = 0;
								{
									if (i < board.pp.vs.Count) {
										value = board.pp.vs [i];
									} else {
										Debug.LogError ("error, index:  pp: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}

						/** FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];*/
						{
							// this.pat3 = new LP<uint> (this, Property.pat3.ToString ());
							for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
								// get value
								uint value = 0;
								{
									if (i < board.pat3.vs.Count) {
										value = board.pat3.vs [i];
									} else {
										Debug.LogError ("error, index: pat3: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}

						/** struct group gi[BOARD_MAX_COORDS];*/
						{
							// this.gi = new LP<Group> (this, Property.gi.ToString ());
							for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
								// get value
								Group value = new Group();
								{
									if (i < board.gi.vs.Count) {
										value = board.gi.vs [i];
									} else {
										Debug.LogError ("error, index:  gi: " + board);
									}
								}
								// write
								writer.Write (Group.convertToBytes(value));
							}
						}

						/** FB_ONLY(group_t c)[BOARD_MAX_GROUPS];*/
						{
							// this.c = new LP<int> (this, Property.c.ToString ());
							for (int i = 0; i < Common.BOARD_MAX_GROUPS; i++) {
								// get value
								int value = 0;
								{
									if (i < board.c.vs.Count) {
										value = board.c.vs [i];
									} else {
										Debug.LogError ("error, index: c: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** FB_ONLY(int clen);*/
						writer.Write (board.clen.v);

						/** FB_ONLY(struct board_symmetry symmetry);*/
						writer.Write (BoardSymmetry.convertToBytes (board.symmetry.v));

						/** FB_ONLY(struct move last_ko);*/
						writer.Write (WeiqiMove.convertToBytes (board.last_ko.v));
						/** FB_ONLY(int last_ko_age);*/
						writer.Write (board.last_ko_age.v);

						/** struct move ko;*/
						writer.Write (WeiqiMove.convertToBytes (board.ko.v));

						/** int quicked;*/
						writer.Write (board.quicked.v);

						/** FB_ONLY(hash_t history_hash)[1 << history_hash_bits];*/
						{
							// this.history_hash = new LP<ulong> (this, Property.history_hash.ToString ());
							for (int i = 0; i < (1 << history_hash_bits); i++) {
								// get value
								ulong value = 0;
								{
									if (i < board.history_hash.vs.Count) {
										value = board.history_hash.vs [i];
									} else {
										Debug.LogError ("error, index: history_hash: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** FB_ONLY(hash_t hash);*/
						writer.Write (board.hash.v);
						/** FB_ONLY(hash_t qhash)[4];*/
						{
							// this.qhash = new LP<ulong> (this, Property.qhash.ToString ());
							for (int i = 0; i < 4; i++) {
								// get value
								ulong value = 0;
								{
									if (i < board.qhash.vs.Count) {
										value = board.qhash.vs [i];
									} else {
										Debug.LogError ("error, index: qhash: " + board);
									}
								}
								// write
								writer.Write (value);
							}
						}
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Board board, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** int size;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.size.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: size: " + count);
					}
					break;
				case 1:
					/** int size2;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.size2.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: size2: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: size2: " + count);
					}
					break;
				case 2:
					/** int bits2;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.bits2.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: bits2: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: bits2: " + count);
					}
					break;
				case 3:
					/** int captures[S_MAX];*/
					{
						board.captures.clear ();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.stone.S_MAX; i++) {
							if (count + size <= byteArray.Length) {
								board.captures.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: captures: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: captures: " + count);
					}
					break;
				case 4:
					/** float komi;*/
					{
						int size = sizeof(float);
						if (count + size <= byteArray.Length) {
							board.komi.v = BitConverter.ToSingle (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: komi: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: komi: " + count);
					}
					break;
				case 5:
					/** int handicap;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.handicap.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: handicap: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: handicap: " + count);
					}
					break;
				case 6:
					/** enum go_ruleset rules;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.rules.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: rules: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: rules: " + count);
					}
					break;

				case 7:
					/** int moves;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.moves.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: moves: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: moves: " + count);
					}
					break;
				case 8:
					/** struct move last_move;*/
					{
						WeiqiMove lastMove = new WeiqiMove();
						// parse
						{
							int byteLength = WeiqiMove.parse (lastMove, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							lastMove.uid = board.last_move.makeId ();
							board.last_move.v = lastMove;
						} else {
							Debug.LogError ("parse lastMove error");
						}
						// Debug.LogError ("board parse: last_move: " + count);
					}
					break;
				case 9:
					/** struct move last_move2;*/
					{
						WeiqiMove lastMove2 = new WeiqiMove();
						// parse
						{
							int byteLength = WeiqiMove.parse (lastMove2, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							lastMove2.uid = board.last_move2.makeId ();
							board.last_move2.v = lastMove2;
						} else {
							Debug.LogError ("parse lastMove2 error");
						}
						// Debug.LogError ("board parse: last_move2: " + count);
					}
					break;
				case 10:
					/** FB_ONLY(struct move last_move3);*/
					{
						WeiqiMove lastMove3 = new WeiqiMove();
						// parse
						{
							int byteLength = WeiqiMove.parse (lastMove3, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							lastMove3.uid = board.last_move3.makeId ();
							board.last_move3.v = lastMove3;
						} else {
							Debug.LogError ("parse lastMove3 error");
						}
						// Debug.LogError ("board parse: last_move3: " + count);
					}
					break;
				case 11:
					/** FB_ONLY(struct move last_move4);*/
					{
						WeiqiMove lastMove4 = new WeiqiMove();
						// parse
						{
							int byteLength = WeiqiMove.parse (lastMove4, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							lastMove4.uid = board.last_move4.makeId ();
							board.last_move4.v = lastMove4;
						} else {
							Debug.LogError ("parse lastMove4 error");
						}
						// Debug.LogError ("board parse: last_move4: " + count);
					}
					break;
				case 12:
					/** FB_ONLY(bool superko_violation);*/
					{
						int size = sizeof(byte);
						if (count + size < byteArray.Length) {
							board.superko_violation.v = byteArray [count];
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: superko_violation: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: superko_violation: " + count);
					}
					break;

				case 13:
					/** enum stone b[BOARD_MAX_COORDS];*/
					{
						board.b.clear ();
						int size = sizeof(int);
						for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
							if (count + size <= byteArray.Length) {
								board.b.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: b: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: b: " + count);
					}
					break;
				case 14:
					/** group_t g[BOARD_MAX_COORDS];*/
					{
						board.g.clear ();
						int size = sizeof(int);
						for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
							if (count + size <= byteArray.Length) {
								board.g.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: g: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: g: " + count);
					}
					break;
				case 15:
					/** coord_t p[BOARD_MAX_COORDS];*/
					{
						board.pp.clear ();
						int size = sizeof(int);
						for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
							if (count + size <= byteArray.Length) {
								board.pp.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: pp: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: p: " + count);
					}
					break;

				case 16:
					/** FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];*/
					{
						board.pat3.clear ();
						int size = sizeof(uint);
						for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
							if (count + size <= byteArray.Length) {
								board.pat3.add (BitConverter.ToUInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: pat3: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: pat3: " + count);
					}
					break;

				case 17:
					/** struct group gi[BOARD_MAX_COORDS];*/
					{
						board.gi.clear ();
						// parse
						List<Group> gi = new List<Group> ();
						for (int i = 0; i < Common.BOARD_MAX_COORDS; i++) {
							Group group = new Group ();
							int byteLength = Group.parse (group, byteArray, count);
							if (byteLength > 0) {
								// add to list
								{
									gi.Add (group);
								}
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								break;
							}
						}
						// add to board
						for (int i = 0; i < gi.Count; i++) {
							Group group = gi [i];
							{
								group.uid = board.gi.makeId ();
							}
							board.gi.add (group);
						}
						// Debug.LogError ("board parse: gi: " + count);
					}
					break;

				case 18:
					/** FB_ONLY(group_t c)[BOARD_MAX_GROUPS];*/
					{
						board.c.clear ();
						int size = sizeof(int);
						for (int i = 0; i < Common.BOARD_MAX_GROUPS; i++) {
							if (count + size <= byteArray.Length) {
								board.c.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: c: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: c: " + count);
					}
					break;
				case 19:
					/** FB_ONLY(int clen);*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.clen.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: clen: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: clen: " + count);
					}
					break;

				case 20:
					/** FB_ONLY(struct board_symmetry symmetry);*/
					{
						BoardSymmetry symmetry = new BoardSymmetry();
						// parse
						{
							int byteLength = BoardSymmetry.parse (symmetry, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							symmetry.uid = board.symmetry.makeId ();
							board.symmetry.v = symmetry;
						} else {
							Debug.LogError ("parse symmetry error");
						}
						// Debug.LogError ("board parse: symmetry: " + count);
					}
					break;

				case 21:
					/** FB_ONLY(struct move last_ko);*/
					{
						WeiqiMove lastKo = new WeiqiMove();
						// parse
						{
							int byteLength = WeiqiMove.parse (lastKo, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							lastKo.uid = board.last_ko.makeId ();
							board.last_ko.v = lastKo;
						} else {
							Debug.LogError ("parse last_ko error");
						}
						// Debug.LogError ("board parse: last_ko: " + count);
					}
					break;
				case 22:
					/** FB_ONLY(int last_ko_age);*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.last_ko_age.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: last_ko_age: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: last_ko_age: " + count);
					}
					break;

				case 23:
					/** struct move ko;*/
					{
						WeiqiMove ko = new WeiqiMove();
						// parse
						{
							int byteLength = WeiqiMove.parse (ko, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							ko.uid = board.ko.makeId ();
							board.ko.v = ko;
						} else {
							Debug.LogError ("parse ko error");
						}
						// Debug.LogError ("board parse: ko: " + count);
					}
					break;

				case 24:
					/** int quicked;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							board.quicked.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: quicked: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: quicked: " + count);
					}
					break;

				case 25:
					/** FB_ONLY(hash_t history_hash)[1 << history_hash_bits];*/
					{
						board.history_hash.clear ();
						int size = sizeof(ulong);
						for (int i = 0; i < (1 << history_hash_bits); i++) {
							if (count + size <= byteArray.Length) {
								board.history_hash.add (BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: history_hash: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: history_hash: " + count);
					}
					break;
				case 26:
					/** FB_ONLY(hash_t hash);*/
					{
						int size = sizeof(ulong);
						if (count + size <= byteArray.Length) {
							board.hash.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: hash: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.LogError ("board parse: hash: " + count);
					}
					break;
				case 27:
					/** FB_ONLY(hash_t qhash)[4];*/
					{
						board.qhash.clear ();
						int size = sizeof(ulong);
						for (int i = 0; i < 4; i++) {
							if (count + size <= byteArray.Length) {
								board.qhash.add (BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: qhash: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.LogError ("board parse: qhash: " + count);
					}
					break;
				default:
					alreadyPassAll = true;
					break;
				}
				index++;
				if (!isParseCorrect) {
					if(log)
						Debug.LogError ("not parse correct");
					break;
				}
				if (alreadyPassAll) {
					break;
				}
			}
			// return
			if (!isParseCorrect) {
				Debug.LogError ("parse board fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse board success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}