using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Janggi
{
	public class Board
	{

		public uint[,] stones;//돌이 놓여진 상태
		public uint[,] targets;//해당 위치를 노리고 있는 돌
		public uint[,] blocks;//해당 위치때문에 못 움직이는 돌

		public Common.Pos[] positions;

		bool isMyTurn;
		public int Point;

		Common.Move prevMove = Common.Move.Empty;
		public Common.Move PrevMove
		{
			get {
				return prevMove;
			}
		}

		public bool IsMyTurn
		{
			get {
				return isMyTurn;
			}
			set{
				isMyTurn = value;
			}
		}

		bool isMyFirst;
		public bool IsMyFirst
		{
			get {
				return isMyFirst;
			}
			set{
				isMyFirst = value;
			}
		}

		readonly public static int Width = 9;
		readonly public static int Height = 10;
		readonly public static int StoneCount = 33;

		public Board(Board board)
		{
			stones = (uint[,])board.stones.Clone();
			targets = (uint[,])board.targets.Clone();
			blocks = (uint[,])board.blocks.Clone();
			positions = (Common.Pos[])board.positions.Clone();

			Point = board.Point;
			isMyTurn = board.isMyTurn;
			isMyFirst = board.IsMyFirst;
		}

		public enum Tables
		{
			Inner,
			Outer,
			Left,
			Right
		}

		public Board()
		{
			SetUp();
		}

		public void SetUp()
		{
			stones = new uint[Height, Width];
			targets = new uint[Height, Width];
			blocks = new uint[Height, Width];
			positions = new Common.Pos[StoneCount];

			Point = 0;

			// Changed?.Invoke(this);
			if (Changed != null) {
				Changed.Invoke (this);
			}
		}

		public Board(Tables myTable, Tables yoTable, bool myFirst)
		{
			SetUp(myTable, yoTable, myFirst);
		}

		public void SetUp(Tables myTable, Tables yoTable, bool myfirst)
		{
			SetUp();

			stones[0, 0] = (uint)StoneHelper.Stones.RedChariot1;
			stones[0, 3] = (uint)StoneHelper.Stones.RedAdvisor1;
			stones[0, 5] = (uint)StoneHelper.Stones.RedAdvisor2;
			stones[0, 8] = (uint)StoneHelper.Stones.RedChariot2;
			stones[1, 4] = (uint)StoneHelper.Stones.RedGeneral;
			stones[2, 1] = (uint)StoneHelper.Stones.RedCannon1;
			stones[2, 7] = (uint)StoneHelper.Stones.RedCannon2;
			stones[3, 0] = (uint)StoneHelper.Stones.RedPawn1;
			stones[3, 2] = (uint)StoneHelper.Stones.RedPawn2;
			stones[3, 4] = (uint)StoneHelper.Stones.RedPawn3;
			stones[3, 6] = (uint)StoneHelper.Stones.RedPawn4;
			stones[3, 8] = (uint)StoneHelper.Stones.RedPawn5;

			stones[6, 0] = (uint)StoneHelper.Stones.GreenPawn1;
			stones[6, 2] = (uint)StoneHelper.Stones.GreenPawn2;
			stones[6, 4] = (uint)StoneHelper.Stones.GreenPawn3;
			stones[6, 6] = (uint)StoneHelper.Stones.GreenPawn4;
			stones[6, 8] = (uint)StoneHelper.Stones.GreenPawn5;
			stones[7, 1] = (uint)StoneHelper.Stones.GreenCannon1;
			stones[7, 7] = (uint)StoneHelper.Stones.GreenCannon2;
			stones[8, 4] = (uint)StoneHelper.Stones.GreenGeneral;
			stones[9, 0] = (uint)StoneHelper.Stones.GreenChariot1;
			stones[9, 3] = (uint)StoneHelper.Stones.GreenAdvisor1;
			stones[9, 5] = (uint)StoneHelper.Stones.GreenAdvisor2;
			stones[9, 8] = (uint)StoneHelper.Stones.GreenChariot2;

			if (myTable == Tables.Inner)
			{
				stones[9, 1] = (uint)StoneHelper.Stones.GreenHorse1;
				stones[9, 2] = (uint)StoneHelper.Stones.GreenElephant1;
				stones[9, 6] = (uint)StoneHelper.Stones.GreenElephant2;
				stones[9, 7] = (uint)StoneHelper.Stones.GreenHorse2;
			}
			else if (myTable == Tables.Outer)
			{
				stones[9, 1] = (uint)StoneHelper.Stones.GreenElephant1;
				stones[9, 2] = (uint)StoneHelper.Stones.GreenHorse1;
				stones[9, 6] = (uint)StoneHelper.Stones.GreenHorse2;
				stones[9, 7] = (uint)StoneHelper.Stones.GreenElephant2;
			}
			else if (myTable == Tables.Left)
			{
				stones[9, 1] = (uint)StoneHelper.Stones.GreenElephant1;
				stones[9, 2] = (uint)StoneHelper.Stones.GreenHorse1;
				stones[9, 6] = (uint)StoneHelper.Stones.GreenElephant2;
				stones[9, 7] = (uint)StoneHelper.Stones.GreenHorse2;
			}
			else
			{
				stones[9, 1] = (uint)StoneHelper.Stones.GreenHorse1;
				stones[9, 2] = (uint)StoneHelper.Stones.GreenElephant1;
				stones[9, 6] = (uint)StoneHelper.Stones.GreenHorse2;
				stones[9, 7] = (uint)StoneHelper.Stones.GreenElephant2;
			}

			if (yoTable == Tables.Inner)
			{
				stones[0, 1] = (uint)StoneHelper.Stones.RedHorse1;
				stones[0, 2] = (uint)StoneHelper.Stones.RedElephant1;
				stones[0, 6] = (uint)StoneHelper.Stones.RedElephant2;
				stones[0, 7] = (uint)StoneHelper.Stones.RedHorse2;
			}
			else if (yoTable == Tables.Outer)
			{
				stones[0, 1] = (uint)StoneHelper.Stones.RedElephant1;
				stones[0, 2] = (uint)StoneHelper.Stones.RedHorse1;
				stones[0, 6] = (uint)StoneHelper.Stones.RedHorse2;
				stones[0, 7] = (uint)StoneHelper.Stones.RedElephant2;
			}
			else if (yoTable == Tables.Left)
			{
				stones[0, 1] = (uint)StoneHelper.Stones.RedHorse1;
				stones[0, 2] = (uint)StoneHelper.Stones.RedElephant1;
				stones[0, 6] = (uint)StoneHelper.Stones.RedHorse2;
				stones[0, 7] = (uint)StoneHelper.Stones.RedElephant2;
			}
			else
			{
				stones[0, 1] = (uint)StoneHelper.Stones.RedElephant1;
				stones[0, 2] = (uint)StoneHelper.Stones.RedHorse1;
				stones[0, 6] = (uint)StoneHelper.Stones.RedElephant2;
				stones[0, 7] = (uint)StoneHelper.Stones.RedHorse2;
			}

			if (myfirst)
			{
				Point = -15;
				isMyTurn = true;
			}
			else
			{
				Point = 15;
				isMyTurn = false;
			}

			isMyFirst = myfirst;

			setUpPosAndTargets();

			// Changed?.Invoke(this);
			if (Changed != null) {
				Changed.Invoke (this);
			}
		}

		/// <summary>
		/// stones만 정의했을 때, 나머지 타겟, pos등을 정리해준다.
		/// </summary>
		public void setUpPosAndTargets()
		{
			//position
			for (int i = 0; i < positions.Length; i++) {
				positions [i] = Common.Pos.Empty;
			}

			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					if (!StoneHelper.IsEmpty (stones [y, x])) {
						positions [StoneHelper.Stone2Index (stones [y, x])] = new Common.Pos (x, y);
					}
				}
			}

			//targets and blocks
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					blocks [y, x] = 0;
					targets [y, x] = 0;
				}
			}

			for (int i = 0; i < 32; i++) {
				// TODO Tam bo uint stone = (uint)1 << i;

				Common.Pos p = GetPos (i + 1);
				if (!p.IsEmpty) {
					setTargets (p);
				}
			}
		}

		public bool Equals(Board b)
		{
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					if (stones [y, x] != b.stones [y, x]) {
						return false;
					}
				}
			}

			return true;
		}

		//상대방 입장에서 보도록 회전시킨다.
		//판을 180도 돌리는 효과
		public Board GetOpposite()
		{
			Board nuBoard = new Board ();
			//이전 포석을 보관하고

			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					//회전된 새로운 위치
					int nx = Width - x - 1;
					int ny = Height - y - 1;

					//편을 바꿔서 넣는다.
					nuBoard.stones [ny, nx] = StoneHelper.Opposite (stones [y, x]);
				}
			}

			nuBoard.Point = -Point;
			nuBoard.isMyTurn = !isMyTurn;
			nuBoard.isMyFirst = !isMyFirst;

			nuBoard.setUpPosAndTargets ();

			return nuBoard;
		}

		public void Set(uint[,] stones, bool isMyFirst, bool isMyTurn)
		{
			Point = 0;

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					this.stones[y, x] = stones[y, x];
					Point += StoneHelper.GetPoint(stones[y, x]);
				}
			}

			this.isMyFirst = isMyFirst;
			this.isMyTurn = isMyTurn;

			setUpPosAndTargets();
		}

		//좌우로 뒤집는 효과
		public Board GetFlip()
		{
			Board nuBoard = new Board();
			//이전 포석을 보관하고

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					//회전된 새로운 위치
					int nx = Width - x - 1;
					int ny = y;

					//편 바꾸지 않고 그냥 넣어야지.
					nuBoard.stones[ny, nx] = stones[y, x];
				}
			}

			nuBoard.Point = Point;
			nuBoard.isMyTurn = isMyTurn;
			nuBoard.isMyFirst = isMyFirst;

			nuBoard.setUpPosAndTargets();

			//나머진 다 똑같다.


			return nuBoard;
		}

		public float[] GetProms(float[] gp)
		{
			List<Common.Move> moves = GetAllPossibleMoves();
			float[] proms = new float[moves.Count];

			for (int i = 0; i < moves.Count; i++)
			{
				Common.Move move = moves[i];
				int index = Common.Move.move2index[move];
				float prom = proms[index];
				proms[i] = prom;
			}

			return proms;
		}


		public Common.Move GetRandomMove(float[] proms, out float total)
		{
			List<Common.Move> moves = GetAllPossibleMoves();

			total = 0;
			for (int i = 0; i < proms.Length; i++)
			{
				total += proms[i];
			}

			//얼마나 policy network가 그지같으면 불가능한 움직임만 확률로 나왔을까.
			if (total == 0)
			{
				int best = Global.Next(moves.Count);
				return moves[best];
			}
			else
			{
				float best = (float)(Global.NextDouble() * total);
				float sum = 0;
				for (int i = 0; i < proms.Length; i++)
				{
					sum += proms[i];
					if (sum > best)
					{
						return moves[i];
					}
				}

				//throw new Exception("거의 이런 일은 없다.");
				return moves.Last();
			}
		}

		public Common.Move GetBsetMove(float[] proms)
		{
			List<Common.Move> moves = GetAllPossibleMoves ();
			float bestProm = 0;
			int bestIndex = -1;
			for (int i = 0; i < moves.Count; i++) {
				int index = Common.Move.move2index [moves [i]];
				float prom = proms [index];

				if (prom > bestProm) {
					bestProm = prom;
					bestIndex = i;
				}
			}

			//얼마나 policy network가 그지같으면 불가능한 움직임만 확률로 나왔을까.
			if (bestIndex == -1) {
				int best = Global.Next (moves.Count);
				return moves [best];
			} else {
				return moves [bestIndex];
			}
		}

		List<Common.Move> allPossibleMoves = null;
		public List<Common.Move> GetAllPossibleMoves()
		{
			if (allPossibleMoves != null) {
				return allPossibleMoves;
			}

			if (IsMyTurn) {
				allPossibleMoves = GetAllMyMoves ();
			} else {
				allPossibleMoves = GetAllYoMoves ();
			}

			return allPossibleMoves;
		}

		//무브를 아예 보드에 저장해놓는다.
		// TODO Tam bo List<Common.Move> allMyMoves = null;
		private List<Common.Move> GetAllMyMoves()
		{
			List<Common.Move> moves = new List<Common.Move> ();

			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					//내 돌이 이 자리를 노리고 있으면서 이 자리가 내 돌이 아니라면
					if (StoneHelper.IsGreen (targets [y, x]) && !StoneHelper.IsGreen (stones [y, x])) {
						//어떤 돌이 이 자리를 노리고 있는지 검색한다.
						for (int i = 0; i < 16; i++) {
							uint stone = (uint)1 << i;
							if ((targets [y, x] & stone) != 0) {
								moves.Add (new Common.Move (GetPos (i + 1), new Common.Pos (x, y)));
							}
						}
					}
				}
			}

			moves.Add (Common.Move.Empty);
			return moves;
		}


		private List<Common.Move> GetAllYoMoves()
		{
			List<Common.Move> moves = new List<Common.Move> ();

			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					if (StoneHelper.IsRed (targets [y, x]) && !StoneHelper.IsRed (stones [y, x])) {
						for (int i = 0; i < 16; i++) {
							uint stone = (uint)0x00010000 << i;
							if ((targets [y, x] & stone) != 0) {
								moves.Add (new Common.Move (GetPos (i + 17), new Common.Pos (x, y)));
							}
						}
					}
				}
			}

			moves.Add (Common.Move.Empty);
			return moves;
		}

		public List<Common.Pos> GetAllMoves(Common.Pos from)
		{
			if (StoneHelper.IsEmpty (stones [from.Y, from.X])) {
				return new List<Common.Pos> ();
			}

			List<Common.Pos> moves = new List<Common.Pos> ();
			uint stone = stones [from.Y, from.X];

			bool isMine = StoneHelper.IsGreen (stones [from.Y, from.X]);

			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					//타겟이면서 내 돌이 아닐 때,
					if ((targets [y, x] & stone) != 0 && (StoneHelper.IsEmpty (stones [y, x]) || isMine == StoneHelper.IsRed (stones [y, x]))) {
						moves.Add (new Common.Pos (x, y));
					}
				}
			}
			return moves;
		}

		/*public ref uint this[Common.Pos pos]
		{
			get { 
				return ref stones[pos.Y, pos.X];
			}
		}

		public ref uint this[int y, int x]
		{
			get {
				return ref stones[y, x];
			}
		}*/

		static Tuple<Common.Pos, Common.Pos>[] wayAndBlockMa = new Tuple<Common.Pos, Common.Pos>[8]
		{new Tuple<Common.Pos, Common.Pos>(new Common.Pos(-2, 1), new Common.Pos(-1, 0))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(-2, -1), new Common.Pos(-1, 0))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(-1, -2), new Common.Pos(0, -1))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(1, -2), new Common.Pos(0, -1))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(2, -1), new Common.Pos(1, 0))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(2, 1), new Common.Pos(1, 0))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(1, 2), new Common.Pos(0, 1))
			,new Tuple<Common.Pos, Common.Pos>(new Common.Pos(-1, 2), new Common.Pos(0, 1))
		};
		static Tuple<Common.Pos, Common.Pos, Common.Pos>[] wayAndBlockSang = new Tuple<Common.Pos, Common.Pos, Common.Pos>[8]
		{
			new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(-3, 2), new Common.Pos(-2, 1), new Common.Pos(-1, 0))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(-3, -2), new Common.Pos(-2, -1), new Common.Pos(-1, 0))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(-2, -3), new Common.Pos(-1, -2), new Common.Pos(0, -1))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(2, -3), new Common.Pos(1, -2), new Common.Pos(0, -1))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(3, -2), new Common.Pos(2, -1), new Common.Pos(1, 0))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(3, 2), new Common.Pos(2, 1), new Common.Pos(1, 0))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(2, 3), new Common.Pos(1, 2), new Common.Pos(0, 1))
			,new Tuple<Common.Pos, Common.Pos, Common.Pos>(new Common.Pos(-2, 3), new Common.Pos(-1, 2), new Common.Pos(0, 1))
		};
		static List<Common.Pos>[,] wayInGoong = new List<Common.Pos>[,]
		{
			{ new List<Common.Pos>(){ new Common.Pos(1, 0), new Common.Pos(1, 1), new Common.Pos(0, 1) },
				new List<Common.Pos>(){ new Common.Pos(2, 0), new Common.Pos(1, 1), new Common.Pos(0, 0) },
				new List<Common.Pos>(){ new Common.Pos(2, 1), new Common.Pos(1, 1), new Common.Pos(1, 0) }
			},

			{ new List<Common.Pos>(){ new Common.Pos(0, 0), new Common.Pos(1, 1), new Common.Pos(0, 2) },
				new List<Common.Pos>(){ new Common.Pos(0, 1), new Common.Pos(0, 0), new Common.Pos(1, 0), new Common.Pos(2, 0), new Common.Pos(2, 1), new Common.Pos(2, 2), new Common.Pos(1, 2), new Common.Pos(0, 2)},
				new List<Common.Pos>(){ new Common.Pos(1, 1), new Common.Pos(2, 0), new Common.Pos(2, 2) }
			},

			{ new List<Common.Pos>(){ new Common.Pos(0, 1), new Common.Pos(1, 1), new Common.Pos(1, 2) },
				new List<Common.Pos>(){ new Common.Pos(0, 2), new Common.Pos(1, 1), new Common.Pos(2, 2) },
				new List<Common.Pos>(){ new Common.Pos(1, 2), new Common.Pos(1, 1), new Common.Pos(2, 1) }
			}
		};
		public static Common.Pos[] wayJol = {
			new Common.Pos(-1, 0), new Common.Pos(1, 0), new Common.Pos(0, -1), new Common.Pos(0, 1)
		};

		private bool confirmAndAdd1(int x, int y, uint stoneFrom)
		{
			// uint stoneTo = stones [y, x];
			targets [y, x] |= stoneFrom;
			blocks [y, x] |= stoneFrom;
			if (stones [y, x] == 0) {
				return true;
			} else {
				return false;
			}
		}

		private bool confirmAndAdd2(ref bool dari, int x, int y, uint stoneFrom)
		{
			uint stoneTo = stones[y, x];
			//다리가 없으면 다리를 발견한다.
			if (dari == false)
			{
				blocks[y, x] |= stoneFrom;
				if (stoneTo == 0)
				{
					return true;
				}
				else if (!StoneHelper.IsCannon(stoneTo))
				{
					dari = true;
					return true;
				}
				else
				{
					return false;
				}
			}
			//다리를 발견한 뒤로는 차와 같은데 포만 못 먹는다.
			else
			{
				if (stones[y, x] == 0)
				{
					targets[y, x] |= stoneFrom;
					blocks[y, x] |= stoneFrom;
					return true;
				}
				else
				{
					blocks[y, x] |= stoneFrom;
					if (!StoneHelper.IsCannon(stones[y, x]))
					{
						targets[y, x] |= stoneFrom;
					}
					return false;
				}
			}
		}

		private void setTargets(Common.Pos pos)
		{
			int px = pos.X;
			int py = pos.Y;

			uint stoneFrom = stones [pos.Y, pos.X];// this[pos];
			if (stoneFrom == 0) {
				return;
			} else if (StoneHelper.IsChariot (stoneFrom)) {
				for (int y = py - 1; y >= 0; y--) {
					if (!confirmAndAdd1 (px, y, stoneFrom)) {
						break;
					}
				}

				for (int y = py + 1; y < Height; y++) {
					if (!confirmAndAdd1 (px, y, stoneFrom)) {
						break;
					}
				}

				for (int x = px - 1; x >= 0; x--) {
					if (!confirmAndAdd1 (x, py, stoneFrom)) {
						break;
					}
				}

				for (int x = px + 1; x < Width; x++) {
					if (!confirmAndAdd1 (x, py, stoneFrom)) {
						break;
					}
				}

				//궁 안에서 대각선 움직임 검사
				//좌상
				if (px == 3 && (py == 0 || py == 7)) {
					for (int x = px + 1, y = py + 1; x < 6; x++, y++) {
						if (!confirmAndAdd1 (x, y, stoneFrom)) {
							break;
						}
					}
				}

				//좌하
				else if (px == 3 && (py == 2 || py == 9)) {
					for (int x = px + 1, y = py - 1; x < 6; x++, y--) {
						if (!confirmAndAdd1 (x, y, stoneFrom)) {
							break;
						}
					}
				}

				//우상
				else if (px == 5 && (py == 0 || py == 7)) {
					for (int x = px - 1, y = py + 1; x >= 3; x--, y++) {
						if (!confirmAndAdd1 (x, y, stoneFrom)) {
							break;
						}
					}
				}

				//우하
				else if (px == 5 && (py == 2 || py == 9)) {
					for (int x = px - 1, y = py - 1; x >= 3; x--, y--) {
						if (!confirmAndAdd1 (x, y, stoneFrom)) {
							break;
						}
					}
				}

				//TODO : 궁 가운데 있을 경우
				else if (px == 4 && (py == 1 || py == 8)) {
					for (int y = py - 1; y <= py + 1; y++) {
						for (int x = px - 1; x <= px + 1; x++) {
							if (x != px || y != py) {
								confirmAndAdd1 (x, y, stoneFrom);
							}
						}
					}
				}
			} else if (StoneHelper.IsCannon (stoneFrom)) {
				bool dari = false;

				dari = false;
				for (int y = py - 1; y >= 0; y--) {
					if (!confirmAndAdd2 (ref dari, px, y, stoneFrom)) {
						break;
					}
				}

				dari = false;
				for (int y = py + 1; y < Height; y++) {
					if (!confirmAndAdd2 (ref dari, px, y, stoneFrom)) {
						break;
					}
				}

				dari = false;
				for (int x = px - 1; x >= 0; x--) {
					if (!confirmAndAdd2 (ref dari, x, py, stoneFrom)) {
						break;
					}
				}

				dari = false;
				for (int x = px + 1; x < Width; x++) {
					if (!confirmAndAdd2 (ref dari, x, py, stoneFrom)) {
						break;
					}
				}

				//궁 안에서 대각선 움직임 검사
				//좌상
				if (px == 3 && (py == 0 || py == 7)) {
					dari = false;
					for (int x = px + 1, y = py + 1; x < 6; x++, y++) {
						if (!confirmAndAdd2 (ref dari, x, y, stoneFrom)) {
							break;
						}
					}
				}

				//좌하
				else if (px == 3 && (py == 2 || py == 9)) {
					dari = false;
					for (int x = px + 1, y = py - 1; x < 6; x++, y--) {
						if (!confirmAndAdd2 (ref dari, x, y, stoneFrom)) {
							break;
						}
					}
				}

				//우상
				else if (px == 5 && (py == 0 || py == 7)) {
					dari = false;
					for (int x = px - 1, y = py + 1; x >= 3; x--, y++) {
						if (!confirmAndAdd2 (ref dari, x, y, stoneFrom)) {
							break;
						}
					}
				}

				//우하
				else if (px == 5 && (py == 2 || py == 9)) {
					dari = false;
					for (int x = px - 1, y = py - 1; x >= 3; x--, y--) {
						if (!confirmAndAdd2 (ref dari, x, y, stoneFrom)) {
							break;
						}
					}
				}

				//궁 가운데 있을 경우 포는 대각선 움직임이 없다.
			} else if (StoneHelper.IsHorse (stoneFrom)) {
				//8개의 착수 가능점을 일일이 확인한다.
				//좌-하부터 시계방향으로

				//길과 멱의 상대적 위치
				for (int i = 0; i < 8; i++) {
					Common.Pos nu = pos + wayAndBlockMa [i].Item1;
					//경계 밖으로 나갈 경우
					if (nu.X < 0 || nu.X >= Width || nu.Y < 0 || nu.Y >= Height) {
						continue;
					}

					Common.Pos block = pos + wayAndBlockMa [i].Item2;
					blocks [block.Y, block.X] |= stoneFrom;
					//if (this [block] != 0) {
					if (stones [block.Y, block.X] != 0) {
						continue;
					}

					targets [nu.Y, nu.X] |= stoneFrom;
				}
			}
			else if (StoneHelper.IsElephant(stoneFrom))
			{
				//길과 멱의 상대적 위치
				for (int i = 0; i < 8; i++)
				{
					Common.Pos to = pos + wayAndBlockSang[i].Item1;
					//경계 밖으로 나갈 경우
					if (to.X < 0 || to.X >= Width || to.Y < 0 || to.Y >= Height)
					{
						continue;
					}

					Common.Pos block2 = pos + wayAndBlockSang[i].Item3;
					blocks[block2.Y, block2.X] |= stoneFrom;
					// if (this[block2] != 0)
					if (stones [block2.Y, block2.X] != 0) {
						continue;
					}

					Common.Pos block1 = pos + wayAndBlockSang[i].Item2;
					blocks[block1.Y, block1.X] |= stoneFrom;

					if (stones [block1.Y, block1.X] != 0) {; //if (this [block1] != 0) {
						continue;
					}

					targets[to.Y, to.X] |= stoneFrom;
				}
			}
			//궁/사
			else if (StoneHelper.IsGeneral(stoneFrom) || StoneHelper.IsAdvisor(stoneFrom))
			{
				Common.Pos origin;

				if (StoneHelper.IsGreen(stoneFrom))
				{
					origin = new Common.Pos(3, 7);
				}
				else
				{
					origin = new Common.Pos(3, 0);
				}

				Common.Pos relPos = pos - origin;
				foreach (var e in wayInGoong[relPos.Y, relPos.X])
				{
					Common.Pos to = origin + e;
					// TODO Tam bo uint stoneTo = stones[to.Y, to.X]; //this[to];

					targets[to.Y, to.X] |= stoneFrom;
				}
			}
			//졸
			else if (StoneHelper.IsPawn(stoneFrom) && StoneHelper.IsGreen(stoneFrom))
			{
				//TODO : else를 만들어야 하는데...
				if (px - 1 >= 0)
				{
					targets[py, px - 1] |= stoneFrom;
				}

				if (px + 1 < Width)
				{

					targets[py, px + 1] |= stoneFrom;
				}

				if (py - 1 >= 0)
				{
					targets[py - 1, px] |= stoneFrom;
				}

				//우상으로 진출
				if (pos.Equals(3, 2))
				{
					targets[1, 4] |= stoneFrom;
				}
				else if (pos.Equals(4, 1))
				{
					targets[0, 5] |= stoneFrom;
				}
				//좌상으로 진출
				else if (pos.Equals(5, 2))
				{
					targets[1, 4] |= stoneFrom;
				}
				else if (pos.Equals(4, 1))
				{
					targets[0, 3] |= stoneFrom;
				}
			}
			else if (StoneHelper.IsPawn(stoneFrom) && StoneHelper.IsRed(stoneFrom))
			{
				if (px - 1 >= 0)
				{
					targets[py, px - 1] |= stoneFrom;
				}

				if (px + 1 < Width)
				{
					targets[py, px + 1] |= stoneFrom;
				}

				if (py + 1 < Height)
				{
					targets[py + 1, px] |= stoneFrom;
				}

				//우하로 진출
				if (pos.Equals(3, 7))
				{
					targets[8, 4] |= stoneFrom;
				}
				else if (pos.Equals(4, 8))
				{
					targets[9, 5] |= stoneFrom;
				}
				//좌하로 진출
				else if (pos.Equals(5, 7))
				{
					targets[8, 4] |= stoneFrom;
				}
				else if (pos.Equals(4, 8))
				{
					targets[9, 3] |= stoneFrom;
				}
			}
			else
			{
				throw new Exception("ERROR");
			}
		}

		private void removeTargets(uint stone)
		{
			uint _stone = ~stone;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					targets[y, x] &= _stone;
					blocks[y, x] &= _stone;
				}
			}
		}

		private void recalcTargets(Common.Pos pos)
		{
			// TODO Tam bo uint target = targets[pos.Y, pos.X];
			uint block = blocks[pos.Y, pos.X];


			for (int i = 0; i < 32; i++)
			{
				uint stone = (uint)1 << i;
				if ((block & stone) > 0)
				{
					removeTargets(stone);
					Common.Pos from = GetPos(i + 1);
					if (!from.IsEmpty)
					{
						setTargets(from);
					}
				}
			}
		}

		public delegate void ChangedHandler(Board board);
		public event ChangedHandler Changed;

		public void MoveNext(Common.Move move)
		{
			allPossibleMoves = null;
			prevMove = move;
			if (!move.IsEmpty)
			{
				uint stone = stones [move.From.Y, move.From.X];// this[move.From];

				//궁내의 이상한 움직임 방지
				if (StoneHelper.IsAdvisor(stone) || StoneHelper.IsGeneral(stone))
				{
					if (move.To.X < 3 || move.To.X > 5)
					{
						return;
					}
					else if (StoneHelper.IsGreen(stone))
					{
						if (move.To.Y < 7)
						{
							return;
						}
					}
					else if (StoneHelper.IsRed(stone))
					{
						if (move.To.Y > 2)
						{
							return;
						}
					}
				}

				//도착 위치에 물체가 있으면
				uint stoneTo = stones[move.To.Y, move.To.X];// this[move.To];
				if (stoneTo != 0)
				{
					//타겟을 지워준다.
					removeTargets(stoneTo);
					Point += StoneHelper.GetPoint(stoneTo);
					positions[StoneHelper.Stone2Index(stoneTo)] = Common.Pos.Empty;
				}

				//기물을 제거
				stones[move.From.Y, move.From.X] = 0;;// this[move.From] = 0;
				//움직이려는 기물에 대한 target, block을 지워줌
				removeTargets(stone);
				//도착 위치에 세워놓고,
				stones[move.To.Y, move.To.X] = stone;//this[move.To] = stone;

				//기물이 있던 자리에 대해서 계산을 다시 해줌
				recalcTargets(move.From);
				//도착 위치에 대해서도 계산을 다시 해줌
				recalcTargets(move.To);
				setTargets(move.To);

				positions[StoneHelper.Stone2Index(stone)] = move.To;
			}

			isMyTurn = !isMyTurn;

			// Changed?.Invoke(this);
			if (Changed != null) {
				Changed.Invoke (this);
			}
		}

		public Board GetNext(Common.Move move)
		{
			Board board = new Board(this);
			board.MoveNext(move);
			return board;
		}

		public bool IsMyWin
		{
			get {
				return Point > 5000;
			}
		}

		public bool IsYoWin
		{
			get {
				return Point < -5000;
			}
		}

		public bool IsFinished
		{
			get {
				return IsMyWin || IsYoWin;
			}
		}

		#region 기물의 위치를 찾는 것 관련

		//원래는 positions를 구현해야 하지만 지금은 그냥 놔둠

		public Common.Pos GetPos(uint stone)
		{
			return positions[StoneHelper.Stone2Index(stone)];
		}

		public Common.Pos GetPos(int index)
		{
			return positions[index];
		}

		#endregion

		#region MCTS 관련

		public int ExpectedPoint(Common.Move move)
		{
			// return Point + StoneHelper.GetPoint(this[move.To]);
			return Point + StoneHelper.GetPoint(stones[move.To.Y, move.To.X]);
		}

		//차례와 관계없이 내가 이길 확률.
		public float Judge()
		{
			//내 점수를 더한다.
			int p1 = Point;

			//잡을 수 있는 점수
			int p2 = CountTake();

			//잡힐 점수
			int p3 = CountTaken();

			//궁의 위치가 위에 있으면 불안
			int p4 = 0;

			if (GetPos(16).Y == 7)
			{
				p4 -= 10;
			}
			else if (GetPos(32).Y == 2)
			{
				p4 += 10;
			}

			//포의 안형
			int p5 = 0;

			if (GetPos(10).Y >= 7)
			{
				p5 += 5;
			}
			if (GetPos(11).Y >= 7)
			{
				p5 += 5;
			}

			if (GetPos(27).Y <= 2)
			{
				p5 -= 5;
			}

			if (GetPos(26).Y <= 2)
			{
				p5 -= 5;
			}

			//p6
			//마상은 일단 중앙진출이 좋다.
			int p6 = 0;
			const int outMa = 3;
			for (int x = 0; x < Width; x++)
			{
				uint stone = stones[0, x];
				if (StoneHelper.IsHorse(stone) || StoneHelper.IsElephant(stone))
				{
					p6 += StoneHelper.IsGreen(stone) ? -outMa : outMa;
				}

				stone = stones[Height - 1, x];
				if (StoneHelper.IsHorse(stone) || StoneHelper.IsElephant(stone))
				{
					p6 += StoneHelper.IsGreen(stone) ? -outMa : outMa;
				}
			}

			for (int y = 0; y < Height; y++)
			{
				uint stone = stones[y, 0];
				if (StoneHelper.IsHorse(stone) || StoneHelper.IsElephant(stone))
				{
					p6 += StoneHelper.IsGreen(stone) ? -outMa : outMa;
				}

				stone = stones[y, Width - 1];
				if (StoneHelper.IsHorse(stone) || StoneHelper.IsElephant(stone))
				{
					p6 += StoneHelper.IsGreen(stone) ? -outMa : outMa;
				}
			}

			//차길, 포길은 무조건 +2
			int p7 = 0;

			const int addCha = 2;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					uint target = targets[y, x];
					if (StoneHelper.IsGreenChariot(target))
					{
						p7 += addCha;
					}
					else if (StoneHelper.IsRedChariot(target))
					{
						p7 -= addCha;
					}

					if (StoneHelper.IsGreenCannon(target))
					{
						p7 += addCha;
					}
					else if (StoneHelper.IsRedCannon(target))
					{
						p7 -= addCha;
					}
				}
			}

			//졸끼리 붙어있으면 +2
			int p8 = 0;
			const int addJol = 2;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width - 1; x++)
				{
					uint target = targets[y, x];
					if (StoneHelper.IsGreenPawn(target))
					{
						if (StoneHelper.IsGreenPawn(targets[y, x + 1]))
						{
							p8 += addJol;
						}
					}
					if (StoneHelper.IsRedPawn(target))
					{
						if (StoneHelper.IsRedPawn(targets[y, x + 1]))
						{
							p8 -= addJol;
						}
					}
				}
			}

			if (IsMyTurn)
			{
				p2 /= 6;
				p3 /= 6;
			}
			else
			{
				p2 /= 6;
				p3 /= 6;
			}



			float score = p1 + p2 + p3 + p4 + p5 + p6 + p7;

			score = score / 400 + 0.5f;
			if (score < 0)
			{
				score = 0;
			}
			else if (score > 1)
			{
				score = 1;
			}

			return score;
		}

		//총 잡을 수 있는 기물
		public int CountTake()
		{
			int sum = 0;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					if (StoneHelper.IsRed(stones[y, x]))
					{
						if (StoneHelper.IsGreen(targets[y, x]))
						{
							if (StoneHelper.IsGeneral(stones[y, x]))
							{
								sum += 150;
							}
							else
							{
								sum += StoneHelper.GetPoint(stones[y, x]);
							}

						}
					}
				}
			}
			return sum;
		}

		//잡을 수 있는 기물 중 가장 비싼 것
		public int MaxTake()
		{
			int max = 0;
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					if (StoneHelper.IsRed (stones [y, x])) {
						if (targets [y, x] > 0) {
							if (StoneHelper.IsGeneral (stones [y, x])) {
								return 200;

							} else {
								int p = StoneHelper.GetPoint (stones [y, x]);
								if (p > max) {
									max = p;
								}
							}

						}
					}
				}
			}
			return max;
		}

		//총 잡힐 기물
		public int CountTaken()
		{
			int sum = 0;
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					if (StoneHelper.IsGreen (stones [y, x])) {
						if (StoneHelper.IsRed (targets [y, x])) {
							if (StoneHelper.IsGeneral (stones [y, x])) {
								sum -= 200;
							} else {
								sum += StoneHelper.GetPoint (stones [y, x]);
							}
						}
					}
				}
			}
			return sum;
		}

		//잡힐 수 있는 기물 중 가장 비싼 것
		public int MinTaken()
		{
			//마이너스라서..
			int min = 0;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					if (StoneHelper.IsGreen(stones[y, x]))
					{
						if (targets[y, x] > 0)
						{
							if (StoneHelper.IsGeneral(stones[y, x]))
							{
								return -200;
							}
							else
							{
								int p = StoneHelper.GetPoint(stones[y, x]);
								if (p < min)
								{
									min = p;
								}
							}
						}
					}
				}
			}
			return min;
		}









		#endregion



		#region 텍스트 출력

		static string[] lettersCho = {
			"＋",
			"卒", "象", "馬", "包", "車", "士", "楚",
			"兵", "象", "馬", "包", "車", "士", "漢",
		};

		static string[] lettersHan = {
			"＋",
			"兵", "象", "馬", "包", "車", "士", "漢",
			"卒", "象", "馬", "包", "車", "士", "楚",
		};

		public string ToStringStones()
		{
			string[] letters;
			if (IsMyTurn)
			{
				letters = lettersCho;
			}
			else
			{
				letters = lettersHan;
			}
			string result = "";
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					result += (letters[(int)stones[y, x]] + " ");// (letters[(int)this[y, x]] + " ");
				}
				result += '\n';
			}

			return result;
		}

		public string PrintStones()
		{
			StringBuilder result = new StringBuilder ();
			{
				for (int y = 0; y < Height; y++) {
					for (int x = 0; x < Width; x++) {
						uint stone = stones [y, x];// this[y, x];
						result.Append (StoneHelper.GetLetter (stone, IsMyFirst) + " ");
					}
					result.AppendLine ();
				}
			}
			return result.ToString ();
		}

		public override string ToString()
		{
			string[] letters;

			if (IsMyFirst) {
				letters = lettersCho;
			} else {
				letters = lettersHan;
			}
			Debug.Log (letters);

			string result = "";
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					uint stone = stones [y, x]; //this[y, x];

					result += StoneHelper.Stone2Index (stone);
					result += " ";
				}
				result += "||";
			}

			return result;
		}

		#endregion


		public static int[] index2layer = new int[]
		{
			0, 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8,
			9, 9, 9, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15
		};

		public byte[] GetBytes()
		{
			//스톤 레이어 16개
			//선수레이어 1개
			//그냥 패딩 1개
			//각 위치별 target 90개
			// => 118 개 헐
			//누구 차례인지는 표시하지 않음..... 그냥 무조건 아래쪽 차례.


			byte[,,] layer = new byte[10, 9, 118];

			int fromLayer = 18;//to 117
			for (int y = 0; y < 10; y++)
			{
				for (int x = 0; x < 9; x++)
				{
					//스톤 칠하기
					uint stone = stones[y, x];
					int k = index2layer[StoneHelper.Stone2Index(stone)];
					layer[y, x, k] = 1;

					//타겟 칠하기
					if (!StoneHelper.IsEmpty(stone))
					{
						for (int ty = 0; ty < 10; ty++)
						{
							for (int tx = 0; tx < 9; tx++)
							{
								if ((targets[ty, tx] & stone) != 0)
								{
									layer[ty, tx, fromLayer] = 1;
								}
							}
						}
					}

					fromLayer++;

					//그냥 패딩

					layer[y, x, 17] = 1;
				}
			}


			if (IsMyFirst)
			{
				for (int y = 0; y < 10; y++)
				{
					for (int x = 0; x < 9; x++)
					{
						layer[y, x, 16] = 1;
					}
				}
			}

			byte[] data = new byte[10 * 9 * 118];


			Buffer.BlockCopy(layer, 0, data, 0, data.Length * sizeof(byte));

			//int index = 0;
			//for (int y = 0; y < 10; y++)
			//{
			//	for (int x = 0; x < 9; x++)
			//	{
			//		for (int k = 0; k < 118; k++)
			//		{
			//			data[index++] = layer[y, x, k];
			//		}
			//	}
			//}

			return data;
		}
	}
}