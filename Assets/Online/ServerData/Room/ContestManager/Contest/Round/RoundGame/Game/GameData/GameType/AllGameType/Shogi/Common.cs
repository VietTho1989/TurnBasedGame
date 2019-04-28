using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Shogi
{
    public class Common
    {
        [System.Serializable]
        public struct BitBoard
        {
            public System.UInt64 p0;
            public System.UInt64 p1;

            public BitBoard(System.UInt64 p0, System.UInt64 p1)
            {
                this.p0 = p0;
                this.p1 = p1;
            }

            public override string ToString()
            {
                return p0 + ";" + p1;
            }

            public static byte[] convertToByte(BitBoard bitboard)
            {
                byte[] byteArray;
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(memStream))
                    {
                        // write value
                        {
                            writer.Write(bitboard.p0);
                            writer.Write(bitboard.p1);
                        }
                        // write to byteArray
                        byteArray = memStream.ToArray();
                    }
                }
                return byteArray;
            }
        }

        [System.Serializable]
        public class SyncListBitBoard : SyncListStruct<BitBoard>
        {

        }

        public enum PieceType
        {
            // Pro* は 元の 駒の種類に 8 を加算したもの。
            PTPromote = 8,
            Occupied = 0, // 各 PieceType の or をとったもの。

            Pawn,
            Lance,
            Knight,
            Silver,
            Bishop,
            Rook,
            Gold,
            King,
            ProPawn,
            ProLance,
            ProKnight,
            ProSilver,
            Horse,
            Dragon,

            PieceTypeNum,

            GoldHorseDragon // 単にtemnplate引数として使用
        };

        public enum Piece
        {
            // B* に 16 を加算することで、W* を表す。
            // Promoted を加算することで、成りを表す。
            Empty = 0,
            UnPromoted = 0,
            Promoted = 8,

            BPawn = 1,
            BLance,
            BKnight,
            BSilver,
            BBishop,
            BRook,
            BGold,
            BKing,
            BProPawn,
            BProLance,
            BProKnight,
            BProSilver,
            BHorse,
            BDragon, // BDragon = 14

            WPawn = 17,
            WLance,
            WKnight,
            WSilver,
            WBishop,
            WRook,
            WGold,
            WKing,
            WProPawn,
            WProLance,
            WProKnight,
            WProSilver,
            WHorse,
            WDragon,

            PieceNone // PieceNone = 31  これを 32 にした方が多重配列のときに有利か。
        };

        public static readonly Common.Piece[] CanChosenPieces = {
            Common.Piece.BPawn,
            Common.Piece.BLance,
            Common.Piece.BKnight,
            Common.Piece.BSilver,
            Common.Piece.BBishop,
            Common.Piece.BRook,
            Common.Piece.BGold,
            Common.Piece.BKing,
            Common.Piece.BProPawn,
            Common.Piece.BProLance,
            Common.Piece.BProKnight,
            Common.Piece.BProSilver,
            Common.Piece.BHorse,
            Common.Piece.BDragon,

            Common.Piece.WPawn,
            Common.Piece.WLance,
            Common.Piece.WKnight,
            Common.Piece.WSilver,
            Common.Piece.WBishop,
            Common.Piece.WRook,
            Common.Piece.WGold,
            Common.Piece.WKing,
            Common.Piece.WProPawn,
            Common.Piece.WProLance,
            Common.Piece.WProKnight,
            Common.Piece.WProSilver,
            Common.Piece.WHorse,
            Common.Piece.WDragon
        };

        public static Common.Piece getPromotion(Common.Piece piece)
        {
            switch (piece)
            {
                case Piece.BPawn:
                    return Piece.BProPawn;
                case Piece.BLance:
                    return Piece.BProLance;
                case Piece.BKnight:
                    return Piece.BProKnight;
                case Piece.BSilver:
                    return Piece.BProSilver;
                case Piece.BBishop:
                    return Piece.BHorse;
                case Piece.BRook:
                    return Piece.BDragon;

                case Piece.WPawn:
                    return Piece.WProPawn;
                case Piece.WLance:
                    return Piece.WProLance;
                case Piece.WKnight:
                    return Piece.WProKnight;
                case Piece.WSilver:
                    return Piece.WProSilver;
                case Piece.WBishop:
                    return Piece.WHorse;
                case Piece.WRook:
                    return Piece.WDragon;
                default:
                    return piece;
            }
        }

        /**
		 * check piece is real piece or empty
		 * */
        public static bool isRealPiece(Piece piece)
        {
            switch (piece)
            {
                case Piece.BPawn:
                case Piece.BLance:
                case Piece.BKnight:
                case Piece.BSilver:
                case Piece.BBishop:
                case Piece.BRook:
                case Piece.BGold:
                case Piece.BKing:
                case Piece.BProPawn:
                case Piece.BProLance:
                case Piece.BProKnight:
                case Piece.BProSilver:
                case Piece.BHorse:
                case Piece.BDragon:
                case Piece.WPawn:
                case Piece.WLance:
                case Piece.WKnight:
                case Piece.WSilver:
                case Piece.WBishop:
                case Piece.WRook:
                case Piece.WGold:
                case Piece.WKing:
                case Piece.WProPawn:
                case Piece.WProLance:
                case Piece.WProKnight:
                case Piece.WProSilver:
                case Piece.WHorse:
                case Piece.WDragon:
                    return true;
                default:
                    return false;
            }
        }

        public static Common.Piece colorAndPieceTypeToPiece(Common.Color c, Common.PieceType pt)
        {
            return (Common.Piece)(((int)c << 4) | (int)pt);
        }

        public enum Square
        {
            SQ11, SQ12, SQ13, SQ14, SQ15, SQ16, SQ17, SQ18, SQ19,
            SQ21, SQ22, SQ23, SQ24, SQ25, SQ26, SQ27, SQ28, SQ29,
            SQ31, SQ32, SQ33, SQ34, SQ35, SQ36, SQ37, SQ38, SQ39,
            SQ41, SQ42, SQ43, SQ44, SQ45, SQ46, SQ47, SQ48, SQ49,
            SQ51, SQ52, SQ53, SQ54, SQ55, SQ56, SQ57, SQ58, SQ59,
            SQ61, SQ62, SQ63, SQ64, SQ65, SQ66, SQ67, SQ68, SQ69,
            SQ71, SQ72, SQ73, SQ74, SQ75, SQ76, SQ77, SQ78, SQ79,
            SQ81, SQ82, SQ83, SQ84, SQ85, SQ86, SQ87, SQ88, SQ89,
            SQ91, SQ92, SQ93, SQ94, SQ95, SQ96, SQ97, SQ98, SQ99,
            SquareNum, // = 81
            SquareNoLeftNum = SQ61,
            B_hand_pawn = SquareNum + -1,
            B_hand_lance = B_hand_pawn + 18,
            B_hand_knight = B_hand_lance + 4,
            B_hand_silver = B_hand_knight + 4,
            B_hand_gold = B_hand_silver + 4,
            B_hand_bishop = B_hand_gold + 4,
            B_hand_rook = B_hand_bishop + 2,
            W_hand_pawn = B_hand_rook + 2,
            W_hand_lance = W_hand_pawn + 18,
            W_hand_knight = W_hand_lance + 4,
            W_hand_silver = W_hand_knight + 4,
            W_hand_gold = W_hand_silver + 4,
            W_hand_bishop = W_hand_gold + 4,
            W_hand_rook = W_hand_bishop + 2,
            SquareHandNum = W_hand_rook + 3
        };

        public static Common.Square makeSquare(File f, Rank r)
        {
            return (Common.Square)((int)f * 9 + r);
        }

        public static bool isInsideBoard(int positionX, int positionY)
        {
            if (positionX >= 0 && positionX < 9 && positionY >= 0 && positionY < 9)
            {
                return true;
            }
            else
            {
                Debug.LogError("why not inside board: " + positionX + "; " + positionY);
                return false;
            }
        }

        public enum Color
        {
            Black, White, ColorNum
        };

        public enum EvalIndex : int
        { // TriangularArray で計算する為に 32bit にしている。
            f_hand_pawn = 0, // 0
            e_hand_pawn = f_hand_pawn + 19,
            f_hand_lance = e_hand_pawn + 19,
            e_hand_lance = f_hand_lance + 5,
            f_hand_knight = e_hand_lance + 5,
            e_hand_knight = f_hand_knight + 5,
            f_hand_silver = e_hand_knight + 5,
            e_hand_silver = f_hand_silver + 5,
            f_hand_gold = e_hand_silver + 5,
            e_hand_gold = f_hand_gold + 5,
            f_hand_bishop = e_hand_gold + 5,
            e_hand_bishop = f_hand_bishop + 3,
            f_hand_rook = e_hand_bishop + 3,
            e_hand_rook = f_hand_rook + 3,
            fe_hand_end = e_hand_rook + 3,

            f_pawn = fe_hand_end,
            e_pawn = f_pawn + 81,
            f_lance = e_pawn + 81,
            e_lance = f_lance + 81,
            f_knight = e_lance + 81,
            e_knight = f_knight + 81,
            f_silver = e_knight + 81,
            e_silver = f_silver + 81,
            f_gold = e_silver + 81,
            e_gold = f_gold + 81,
            f_bishop = e_gold + 81,
            e_bishop = f_bishop + 81,
            f_horse = e_bishop + 81,
            e_horse = f_horse + 81,
            f_rook = e_horse + 81,
            e_rook = f_rook + 81,
            f_dragon = e_rook + 81,
            e_dragon = f_dragon + 81,
            fe_end = e_dragon + 81
        };

        #region Score

        const int MaxPly = 128;

        public enum Score : int
        {
            ScoreZero = 0,
            ScoreDraw = 0,
            ScoreMaxEvaluate = 30000,
            ScoreMateLong = 30002,
            ScoreMate1Ply = 32599,
            ScoreMate0Ply = 32600,
            ScoreMateInMaxPly = ScoreMate0Ply - MaxPly,
            ScoreMatedInMaxPly = -(ScoreMate0Ply - MaxPly),//-ScoreMateInMaxPly,
            ScoreInfinite = 32601,
            ScoreNotEvaluated = int.MaxValue,// INT_MAX,
            ScoreNone = 32602
        };

        #endregion

        public enum HandPiece
        {
            HPawn,
            HLance,
            HKnight,
            HSilver,
            HGold,
            HBishop,
            HRook,
            HandPieceNum
        };

        public static readonly Common.HandPiece[] CanChosenHandPiecs = {
            Common.HandPiece.HPawn,
            Common.HandPiece.HLance,
            Common.HandPiece.HKnight,
            Common.HandPiece.HSilver,
            Common.HandPiece.HGold,
            Common.HandPiece.HBishop,
            Common.HandPiece.HRook
        };

        public class ColorAndHandPiece
        {

            public Common.Color color;

            public Common.HandPiece handPiece;

            public override bool Equals(object obj)
            {
                if (obj != null && obj is ColorAndHandPiece)
                {
                    ColorAndHandPiece other = obj as ColorAndHandPiece;
                    return this.color == other.color && this.handPiece == other.handPiece;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return color.GetHashCode() + handPiece.GetHashCode();
            }

        }

        #region print move

        public static readonly string[] HandPieceToStringTable = { "P*", "L*", "N*", "S*", "G*", "B*", "R*" };

        static string handPieceToString(Common.HandPiece hp)
        {
            int hpIndex = (int)hp;
            if (hpIndex >= 0 && hpIndex < HandPieceToStringTable.Length)
            {
                return HandPieceToStringTable[hpIndex];
            }
            else
            {
                Debug.LogError("error, handPieceToString: index error: " + hpIndex + "; " + hp);
                return HandPieceToStringTable[0];
            }
        }

        public static string printMove(uint move)
        {
            ShogiMove shogiMove = new ShogiMove();
            {
                shogiMove.move.v = move;
            }
            Common.Square from = shogiMove.from();
            Common.Square to = shogiMove.to();
            if (shogiMove.isDrop())
            {
                return handPieceToString(shogiMove.handPieceDropped()) + squareToStringUSI(to);
            }
            string usi = squareToStringUSI(from) + squareToStringUSI(to);
            if (shogiMove.isPromotion() != 0)
            {
                usi += "+";
            }
            return usi;
        }

        #region Rank

        public enum Rank
        {
            Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Rank7, Rank8, Rank9, RankNum
        };

        public static readonly Rank[] SquareToRank = {
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9,
            Rank.Rank1, Rank.Rank2, Rank.Rank3, Rank.Rank4, Rank.Rank5, Rank.Rank6, Rank.Rank7, Rank.Rank8, Rank.Rank9
        };

        static bool isInSquare(Common.Square s)
        {
            return (0 <= s) && (s < Common.Square.SquareNum);
        }

        public static Rank makeRank(Common.Square s)
        {
            if (!(isInSquare(s)))
            {
                Debug.LogError("error, assert(isInSquare(s))");
                s = Common.Square.SQ11;
            }
            return SquareToRank[(int)s];
        }

        #endregion

        #region File

        public enum File
        {
            File1, File2, File3, File4, File5, File6, File7, File8, File9, FileNum,
            FileNoLeftNum = File6
        };

        public static readonly File[] SquareToFile = {
            File.File1, File.File1, File.File1, File.File1, File.File1, File.File1, File.File1, File.File1, File.File1,
            File.File2, File.File2, File.File2, File.File2, File.File2, File.File2, File.File2, File.File2, File.File2,
            File.File3, File.File3, File.File3, File.File3, File.File3, File.File3, File.File3, File.File3, File.File3,
            File.File4, File.File4, File.File4, File.File4, File.File4, File.File4, File.File4, File.File4, File.File4,
            File.File5, File.File5, File.File5, File.File5, File.File5, File.File5, File.File5, File.File5, File.File5,
            File.File6, File.File6, File.File6, File.File6, File.File6, File.File6, File.File6, File.File6, File.File6,
            File.File7, File.File7, File.File7, File.File7, File.File7, File.File7, File.File7, File.File7, File.File7,
            File.File8, File.File8, File.File8, File.File8, File.File8, File.File8, File.File8, File.File8, File.File8,
            File.File9, File.File9, File.File9, File.File9, File.File9, File.File9, File.File9, File.File9, File.File9
        };

        public static File makeFile(Common.Square s)
        {
            if (!(isInSquare(s)))
            {
                Debug.LogError("error, assert(isInSquare(s))");
                s = Common.Square.SQ11;
            }
            return SquareToFile[(int)s];
        }

        #endregion

        static char fileToCharUSI(File f)
        {
            return (char)('1' + f);
        }

        static char rankToCharUSI(Rank r)
        {
            return (char)('a' + r);
        }

        static string squareToStringUSI(Common.Square sq)
        {
            Rank r = makeRank(sq);
            File f = makeFile(sq);
            return fileToCharUSI(f).ToString() + rankToCharUSI(r).ToString();
        }

        #endregion


        #region print Position

        public static readonly string[] PieceToCharCSATable = {" * ", "+FU", "+KY", "+KE", "+GI", "+KA", "+HI", "+KI", "+OU", "+TO", "+NY", "+NK", "+NG", "+UM", "+RY", "", "", "-FU", "-KY", "-KE", "-GI", "-KA", "-HI", "-KI", "-OU", "-TO", "-NY", "-NK", "-NG", "-UM", "-RY"
        };

        public static string printPosition(Shogi shogi)
        {
            // make string
            StringBuilder ss = new StringBuilder();
            {
                // board
                {
                    ss.Append("'  9  8  7  6  5  4  3  2  1\n");
                    int i = 0;
                    for (Rank r = Rank.Rank1; r < Rank.RankNum; ++r)
                    {
                        ++i;
                        ss.Append("P" + i);
                        for (File f = File.File9; File.File1 <= f; --f)
                        {
                            Piece pc = shogi.getPiece(makeSquare(f, r));
                            {
                                int pcIndex = (int)pc;
                                if (pcIndex >= 0 && pcIndex < PieceToCharCSATable.Length)
                                {
                                    ss.Append(PieceToCharCSATable[(int)pc]);
                                }
                                else
                                {
                                    Debug.LogError("error, pcIndex: " + pcIndex);
                                    ss.Append(PieceToCharCSATable[0]);
                                }
                            }
                        }
                        ss.Append("\n");
                    }
                }
                // printHand
                {
                    ss.AppendLine(printHand(shogi, Color.Black));
                    ss.AppendLine(printHand(shogi, Color.White));
                }
                ss.Append(shogi.turn.v == (int)Color.Black ? "+\n" : "-\n");
                ss.Append("\n");
                ss.Append("key = " + shogi.getKey() + "\n");
            }
            return ss.ToString();
        }

        static string printHandPiece(Shogi shogi, HandPiece hp, Color c, string str)
        {
            StringBuilder builder = new StringBuilder();
            if (Shogi.numOf(Shogi.getHand(shogi.hand.vs, c), hp) != 0)
            {
                builder.Append("P" + (c == Color.Black ? "+" : "-"));
                for (System.UInt32 i = 0; i < Shogi.numOf(Shogi.getHand(shogi.hand.vs, c), hp); ++i)
                {
                    builder.Append("00" + str);
                }
            }
            return builder.ToString();
        }

        static string printHand(Shogi shogi, Color c)
        {
            StringBuilder builder = new StringBuilder();
            {
                // HPawn
                {
                    string strHand = printHandPiece(shogi, HandPiece.HPawn, c, "FU");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
                // HLance
                {
                    string strHand = printHandPiece(shogi, HandPiece.HLance, c, "KY");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
                // HKnight
                {
                    string strHand = printHandPiece(shogi, HandPiece.HKnight, c, "KE");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
                // HSilver
                {
                    string strHand = printHandPiece(shogi, HandPiece.HSilver, c, "GI");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
                // HGold
                {
                    string strHand = printHandPiece(shogi, HandPiece.HGold, c, "KI");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
                // HBishop
                {
                    string strHand = printHandPiece(shogi, HandPiece.HBishop, c, "KA");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
                // HRook
                {
                    string strHand = printHandPiece(shogi, HandPiece.HRook, c, "HI");
                    if (!string.IsNullOrEmpty(strHand))
                    {
                        builder.AppendLine(strHand);
                    }
                }
            }
            return builder.ToString();
        }

        #endregion

        #region position to fen

        public static readonly string[] PieceToCharUSITable = {
            "", "P", "L", "N", "S", "B", "R", "G", "K", "+P", "+L", "+N", "+S", "+B", "+R", "", "",
            "p", "l", "n", "s", "b", "r", "g", "k", "+p", "+l", "+n", "+s", "+b", "+r"
        };
        public static string pieceToCharUSI(Common.Piece pc)
        {
            if ((int)pc >= 0 && (int)pc < PieceToCharUSITable.Length)
            {
                return PieceToCharUSITable[(int)pc];
            }
            else
            {
                Debug.LogError("error, pieceToCharUSI: index error: " + pc);
                return PieceToCharUSITable[0];
            }
        }

        public static string positionToFen(Shogi shogi)
        {
            StringBuilder ss = new StringBuilder();
            {
                int space = 0;
                for (Rank rank = Rank.Rank1; rank <= Rank.Rank9; ++rank)
                {
                    for (File file = File.File9; file >= File.File1; --file)
                    {
                        Square sq = makeSquare(file, rank);
                        Piece pc = shogi.getPiece(sq);
                        if (pc == Piece.Empty)
                            ++space;
                        else
                        {
                            if (space > 0)
                            {
                                ss.Append("" + space);
                                space = 0;
                            }
                            ss.Append(pieceToCharUSI(pc));
                        }
                    }
                    if (space > 0)
                    {
                        ss.Append("" + space);
                        space = 0;
                    }
                    if (rank != Rank.Rank9)
                        ss.Append("/");
                }
                ss.Append(shogi.turn.v == (int)Color.Black ? " b " : " w ");
                // hand
                if (Shogi.getHand(shogi.hand.vs, Color.Black) == 0 && Shogi.getHand(shogi.hand.vs, Color.White) == 0)
                    ss.Append("- ");
                else
                {
                    // USI の規格として、持ち駒の表記順は決まっており、先手、後手の順で、それぞれ 飛、角、金、銀、桂、香、歩 の順。
                    Common.HandPiece[] handPieces = { HandPiece.HRook, HandPiece.HBishop, HandPiece.HGold, HandPiece.HSilver, HandPiece.HKnight, HandPiece.HLance, HandPiece.HPawn };
                    for (Color color = Color.Black; color < Color.ColorNum; ++color)
                    {
                        foreach (Common.HandPiece hp in handPieces)
                        {
                            uint num = Shogi.numOf(Shogi.getHand(shogi.hand.vs, color), hp);
                            if (num == 0)
                                continue;
                            if (num != 1)
                                ss.Append("" + num);
                            Piece pc = colorAndHandPieceToPiece(color, hp);
                            ss.Append(pieceToCharUSI(pc));
                        }
                    }
                    ss.Append(" ");
                }
                ss.Append("" + shogi.gamePly.v);
            }
            return ss.ToString();
        }

        static readonly PieceType[] HandPieceToPieceTypeTable = {
            PieceType.Pawn,
            PieceType.Lance,
            PieceType.Knight,
            PieceType.Silver,
            PieceType.Gold,
            PieceType.Bishop,
            PieceType.Rook
        };

        static Common.PieceType handPieceToPieceType(Common.HandPiece hp)
        {
            if ((int)hp >= 0 && (int)hp < HandPieceToPieceTypeTable.Length)
            {
                return HandPieceToPieceTypeTable[(int)hp];
            }
            else
            {
                return HandPieceToPieceTypeTable[0];
            }
        }

        static Common.Piece colorAndHandPieceToPiece(Common.Color c, Common.HandPiece hp)
        {
            return colorAndPieceTypeToPiece(c, handPieceToPieceType(hp));
        }

        #endregion

        public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
        {
            x = 8 - Mathf.RoundToInt(localPosition.x - (0.5f - 4.5f));
            y = 8 - Mathf.RoundToInt(localPosition.y - (0.5f - 4.5f));
        }

        public static Vector3 convertSquareToLocalPosition(Common.Square square)
        {
            Vector3 localPosition = new Vector3();
            {
                localPosition.x = (8 - (int)Common.makeFile(square)) + 0.5f - 4.5f;
                localPosition.y = (8 - (int)Common.makeRank(square)) + 0.5f - 4.5f;
                localPosition.z = 0;
            }
            return localPosition;
        }

    }
}