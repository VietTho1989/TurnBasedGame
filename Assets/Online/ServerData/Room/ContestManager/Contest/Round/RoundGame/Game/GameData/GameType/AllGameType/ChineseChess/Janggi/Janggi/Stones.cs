using System;
using UnityEngine;

namespace Janggi
{
	public class StoneHelper
	{
		public enum Stones : uint
		{
			Empty = 0,

			GreenPawn1 = 0x01,
			GreenPawn2 = 0x02,
			GreenPawn3 = 0x04,
			GreenPawn4 = 0x08,
			GreenPawn5 = 0x10,
			GreenElephant1 = 0x20,
			GreenElephant2 = 0x40,
			GreenHorse1 = 0x80,
			GreenHorse2 = 0x0100,
			GreenCannon1 = 0x0200,
			GreenCannon2 = 0x0400,
			GreenChariot1 = 0x0800,
			GreenChariot2 = 0x1000,
			GreenAdvisor1 = 0x2000,
			GreenAdvisor2 = 0x4000,
			GreenGeneral = 0x8000,

			RedPawn1 = 0x010000,
			RedPawn2 = 0x020000,
			RedPawn3 = 0x040000,
			RedPawn4 = 0x080000,
			RedPawn5 = 0x100000,
			RedElephant1 = 0x200000,
			RedElephant2 = 0x400000,
			RedHorse1 = 0x800000,
			RedHorse2 = 0x01000000,
			RedCannon1 = 0x02000000,
			RedCannon2 = 0x04000000,
			RedChariot1 = 0x08000000,
			RedChariot2 = 0x10000000,
			RedAdvisor1 = 0x20000000,
			RedAdvisor2 = 0x40000000,
			RedGeneral = 0x80000000,

			Pawn =  0x001F001F,
			GreenPawn = 0x0000001F,
			RedPawn = 0x001F0000,
			Elephant = 0x00600060,
			Horse =   0x01800180,
			Cannon =   0x06000600,
			GreenCannon = 0x00000600,
			RedCannon = 0x06000000,
			Chariot =  0x18001800,
			GreenChariot = 0x00001800,
			RedChariot = 0x18000000,
			Advisor =   0x60006000,
			General = 0x80008000,
			Green = 0x0000FFFF,
			Red = 0xFFFF0000
		}

		public static bool IsEmpty(uint s){ 
			return s == (uint)Stones.Empty;
		}

		public static bool IsPawn(uint s) { 
			return (s & (uint)Stones.Pawn) != 0;
		}

		public static bool IsGreenPawn(uint s) { 
			return (s & (uint)Stones.GreenPawn) != 0;
		}

		public static bool IsRedPawn(uint s) { 
			return (s & (uint)Stones.RedPawn) != 0;
		}

		public static bool IsElephant(uint s) { 
			return (s & (uint)Stones.Elephant) != 0;
		}

		public static bool IsHorse(uint s) {
			return (s & (uint)Stones.Horse) != 0;
		}

		public static bool IsCannon(uint s) { 
			return (s & (uint)Stones.Cannon) != 0;
		}

		public static bool IsGreenCannon(uint s) { 
			return (s & (uint)Stones.GreenCannon) != 0;
		}

		public static bool IsRedCannon(uint s) { 
			return (s & (uint)Stones.RedCannon) != 0;
		}

		public static bool IsChariot(uint s) { 
			return (s & (uint)Stones.Chariot) != 0;
		}

		public static bool IsGreenChariot(uint s) { 
			return (s & (uint)Stones.GreenChariot) != 0;
		}

		public static bool IsRedChariot(uint s) { 
			return (s & (uint)Stones.RedChariot) != 0;
		}

		public static bool IsAdvisor(uint s) { 
			return (s & (uint)Stones.Advisor) != 0;
		}

		public static bool IsGeneral(uint s) { 
			return (s & (uint)Stones.General) != 0;
		}

		public static bool IsGreen(uint s) {
			return (s & (uint)Stones.Green) != 0;
		}

		public static bool IsRed(uint s) {
			return (s & (uint)Stones.Red) != 0;
		}

		public static bool IsAllied(uint s1, uint s2) { 
			return (s1 != 0 && s2 != 0 && (s1 > 0x8000) ^ (s2 < 0x010000));
		}

		public static bool IsEnemy(uint s1, uint s2) { 
			return (s1 != 0 && s2 != 0 && (s1 > 0x8000) ^ (s2 > 0x8000));
		}

		public static uint Opposite(uint s)
		{
			if (s == 0)
			{
				return 0;
			}
			else if (s > 0x8000)
			{
				return s >> 16;
			}
			else
			{
				return s << 16;
			}
		}

		public static uint Index2Stone(int index)
		{
			return (uint)1 << index;
		}

		private static int[] lookupStone2Index = new int[0x8001];

		public static int Stone2Index(uint stone)
		{
			if (stone > 0x8000)
			{
				return lookupStone2Index[stone >> 16] + 16;
			}
			else
			{
				return lookupStone2Index[stone];
			}
		}


		private static int[] lookupPoint = new int[0x8001];

		public static int GetPoint(uint stone)
		{
			if (stone == 0)
			{
				return 0;
			}
			else if (stone > 0x8000)
			{
				return lookupPoint[stone >> 16];
			}
			else
			{
				return -lookupPoint[stone];
			}
		}

		public static string GetLetter(uint stone, bool myFirst)
		{
			return GetLetter(Stone2Index(stone), myFirst);
		}

		// K: General
		// R: Chariot
		// H: Horse
		// E: Elephant
		// C: Cannon
		// A: Advisor
		// P: Pawn

		private static string[] lookupLetter = {
			".",
			"P","P","P","P","P",
			"E","E","H", "H","C","C", "R", "R","A","A", "K",
			"p","p","p","p","p",
			"e","e","h", "h","c","c", "r", "r","a","a", "k",
		};


		public static string GetLetter(int index, bool myFirst)
		{
			if (myFirst)
			{
				return lookupLetter[index];
			}
			else
			{
				if (index == 0)
				{
					return lookupLetter[0];
				}
				if (index > 16)
				{
					return lookupLetter[index - 16];
				}
				else
				{
					return lookupLetter[index + 16];
				}
			}
		}


		static StoneHelper()
		{
			lookupStone2Index[0] = 0;
			lookupStone2Index[0x01] = 1;
			lookupStone2Index[0x02] = 2;
			lookupStone2Index[0x04] = 3;
			lookupStone2Index[0x08] = 4;
			lookupStone2Index[0x10] = 5;
			lookupStone2Index[0x20] = 6;
			lookupStone2Index[0x40] = 7;
			lookupStone2Index[0x80] = 8;
			lookupStone2Index[0x0100] = 9;
			lookupStone2Index[0x0200] = 10;
			lookupStone2Index[0x0400] = 11;
			lookupStone2Index[0x0800] = 12;
			lookupStone2Index[0x1000] = 13;
			lookupStone2Index[0x2000] = 14;
			lookupStone2Index[0x4000] = 15;
			lookupStone2Index[0x8000] = 16;

			lookupPoint[0] = 0;
			lookupPoint[0x01] = 20;
			lookupPoint[0x02] = 20;
			lookupPoint[0x04] = 20;
			lookupPoint[0x08] = 20;
			lookupPoint[0x10] = 20;

			lookupPoint[0x20] = 30;
			lookupPoint[0x40] = 30;

			lookupPoint[0x80] = 50;
			lookupPoint[0x0100] = 50;

			lookupPoint[0x0200] = 70;
			lookupPoint[0x0400] = 70;

			lookupPoint[0x0800] = 130;
			lookupPoint[0x1000] = 130;

			lookupPoint[0x2000] = 30;
			lookupPoint[0x4000] = 30;

			lookupPoint[0x8000] = 10000;
		}

		public static Stones ConvertToNormalStone(Stones stone)
		{
			Stones ret = stone;
			{
				switch (stone) {
				case StoneHelper.Stones.Empty:
					break;

				case StoneHelper.Stones.GreenPawn1:
				case StoneHelper.Stones.GreenPawn2:
				case StoneHelper.Stones.GreenPawn3:
				case StoneHelper.Stones.GreenPawn4:
				case StoneHelper.Stones.GreenPawn5:
					ret = StoneHelper.Stones.GreenPawn;
					break;
				case StoneHelper.Stones.GreenPawn:
					break;

				case StoneHelper.Stones.GreenElephant1:
				case StoneHelper.Stones.GreenElephant2:
					ret = StoneHelper.Stones.GreenElephant1;
					break;

				case StoneHelper.Stones.GreenHorse1:
				case StoneHelper.Stones.GreenHorse2:
					ret = StoneHelper.Stones.GreenHorse1;
					break;

				case StoneHelper.Stones.GreenCannon1:
				case StoneHelper.Stones.GreenCannon2:
					ret = StoneHelper.Stones.GreenCannon;
					break;
				case StoneHelper.Stones.GreenCannon:
					break;

				case StoneHelper.Stones.GreenChariot1:
				case StoneHelper.Stones.GreenChariot2:
					ret = StoneHelper.Stones.GreenChariot;
					break;
				case StoneHelper.Stones.GreenChariot:
					break;

				case StoneHelper.Stones.GreenAdvisor1:
				case StoneHelper.Stones.GreenAdvisor2:
					ret = StoneHelper.Stones.GreenAdvisor1;
					break;

				case StoneHelper.Stones.GreenGeneral:
					break;

				case StoneHelper.Stones.RedPawn1:
				case StoneHelper.Stones.RedPawn2:
				case StoneHelper.Stones.RedPawn3:
				case StoneHelper.Stones.RedPawn4:
				case StoneHelper.Stones.RedPawn5:
					ret = StoneHelper.Stones.RedPawn;
					break;
				case StoneHelper.Stones.RedPawn:
					break;

				case StoneHelper.Stones.RedElephant1:
				case StoneHelper.Stones.RedElephant2:
					ret = StoneHelper.Stones.RedElephant1;
					break;

				case StoneHelper.Stones.RedHorse1:
				case StoneHelper.Stones.RedHorse2:
					ret = StoneHelper.Stones.RedHorse1;
					break;

				case StoneHelper.Stones.RedCannon1:
				case StoneHelper.Stones.RedCannon2:
					ret = StoneHelper.Stones.RedCannon;
					break;
				case StoneHelper.Stones.RedCannon:
					break;

				case StoneHelper.Stones.RedChariot1:
				case StoneHelper.Stones.RedChariot2:
					ret = StoneHelper.Stones.RedChariot;
					break;
				case StoneHelper.Stones.RedChariot:
					break;

				case StoneHelper.Stones.RedAdvisor1:
				case StoneHelper.Stones.RedAdvisor2:
					ret = StoneHelper.Stones.RedAdvisor1;
					break;

				case StoneHelper.Stones.RedGeneral:
					break;

				case StoneHelper.Stones.Pawn:
					ret = StoneHelper.Stones.GreenPawn;
					break;
				case StoneHelper.Stones.Elephant:
					ret = StoneHelper.Stones.GreenElephant1;
					break;
				case StoneHelper.Stones.Horse:
					ret = StoneHelper.Stones.GreenHorse1;
					break;
				case StoneHelper.Stones.Cannon:
					ret = StoneHelper.Stones.GreenCannon;
					break;
				case StoneHelper.Stones.Chariot:
					ret = StoneHelper.Stones.GreenChariot;
					break;
				case StoneHelper.Stones.Advisor:
					ret = StoneHelper.Stones.GreenAdvisor1;
					break;
				case StoneHelper.Stones.General:
					ret = StoneHelper.Stones.GreenGeneral;
					break;
				case StoneHelper.Stones.Green:
					ret = StoneHelper.Stones.GreenPawn;
					break;
				case StoneHelper.Stones.Red:
					ret = StoneHelper.Stones.RedPawn;
					break;
				default:
					Debug.LogError ("unknown piece: " + ret);
					break;
				}
			}
			return ret;
		}

		public static readonly StoneHelper.Stones[] NormalStones = {
			StoneHelper.Stones.Empty,

			StoneHelper.Stones.GreenPawn,
			StoneHelper.Stones.GreenElephant1,
			StoneHelper.Stones.GreenHorse1,
			StoneHelper.Stones.GreenCannon,
			StoneHelper.Stones.GreenChariot,
			StoneHelper.Stones.GreenAdvisor1,
			StoneHelper.Stones.GreenGeneral,

			StoneHelper.Stones.RedPawn,
			StoneHelper.Stones.RedElephant1,
			StoneHelper.Stones.RedHorse1,
			StoneHelper.Stones.RedCannon,
			StoneHelper.Stones.RedChariot,
			StoneHelper.Stones.RedAdvisor1,
			StoneHelper.Stones.RedGeneral,

		};

	}
}