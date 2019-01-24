using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class VariantMap
	{

		public static Dictionary<Common.VariantType, Variant> variants = new Dictionary<Common.VariantType, Variant>();

		static VariantMap()
		{
			Variant chess = new Variant ();
			{
				chess.endgameEval = true;
			}
			;
			Variant makruk = new Variant ();
			{
				makruk.remove_piece (Common.PieceType.BISHOP);
				makruk.remove_piece (Common.PieceType.QUEEN);
				makruk.add_piece (Common.PieceType.KHON, 's');
				makruk.add_piece (Common.PieceType.MET, 'm');
				makruk.startFen = "rnsmksnr/8/pppppppp/8/8/PPPPPPPP/8/RNSKMSNR w - - 0 1";
				makruk.promotionRank = Common.Rank.RANK_6;
				makruk.promotionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.MET };
				makruk.endgameEval = true;
				makruk.doubleStep = false;
				makruk.castling = false;
			}
			Variant asean = new Variant ();
			{
				asean.remove_piece (Common.PieceType.BISHOP);
				asean.remove_piece (Common.PieceType.QUEEN);
				asean.add_piece (Common.PieceType.KHON, 'b');
				asean.add_piece (Common.PieceType.MET, 'q');
				asean.startFen = "rnbqkbnr/8/pppppppp/8/8/PPPPPPPP/8/RNBQKBNR w - - 0 1";
				asean.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.ROOK,
					Common.PieceType.KNIGHT,
					Common.PieceType.KHON,
					Common.PieceType.MET
				};
				asean.endgameEval = true;
				asean.doubleStep = false;
				asean.castling = false;
			}
			Variant aiwok = new Variant ();
			{
				aiwok.remove_piece (Common.PieceType.BISHOP);
				aiwok.remove_piece (Common.PieceType.QUEEN);
				aiwok.add_piece (Common.PieceType.KHON, 's');
				aiwok.add_piece (Common.PieceType.AIWOK, 'a');
				aiwok.startFen = "rnsaksnr/8/pppppppp/8/8/PPPPPPPP/8/RNSKASNR w - - 0 1";
				aiwok.promotionRank = Common.Rank.RANK_6;
				aiwok.promotionPieceTypes = new HashSet<Common.PieceType>{ Common.PieceType.AIWOK };
				aiwok.endgameEval = true;
				aiwok.doubleStep = false;
				aiwok.castling = false;
			}
			Variant shatranj = new Variant ();
			{
				shatranj.remove_piece (Common.PieceType.BISHOP);
				shatranj.remove_piece (Common.PieceType.QUEEN);
				shatranj.add_piece (Common.PieceType.ALFIL, 'b');
				shatranj.add_piece (Common.PieceType.FERS, 'q');
				shatranj.startFen = "rnbkqbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBKQBNR w - - 0 1";
				shatranj.promotionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.FERS };
				shatranj.endgameEval = true;
				shatranj.doubleStep = false;
				shatranj.castling = false;
				shatranj.bareKingValue = -(int)Common.Value.VALUE_MATE;
				shatranj.bareKingMove = true;
				shatranj.stalemateValue = -(int)Common.Value.VALUE_MATE;
			}
			Variant amazon = new Variant ();
			{
				amazon.remove_piece (Common.PieceType.QUEEN);
				amazon.add_piece (Common.PieceType.AMAZON, 'a');
				amazon.startFen = "rnbakbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBAKBNR w KQkq - 0 1";
				amazon.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.AMAZON,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT
				};
				amazon.endgameEval = true;
			}
			Variant hoppelpoppel = new Variant ();
			{
				hoppelpoppel.remove_piece (Common.PieceType.KNIGHT);
				hoppelpoppel.remove_piece (Common.PieceType.BISHOP);
				hoppelpoppel.add_piece (Common.PieceType.KNIBIS, 'n');
				hoppelpoppel.add_piece (Common.PieceType.BISKNI, 'b');
				hoppelpoppel.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.QUEEN,
					Common.PieceType.ROOK,
					Common.PieceType.BISKNI,
					Common.PieceType.KNIBIS
				};
				hoppelpoppel.endgameEval = true;
			}
			Variant kingofthehill = new Variant ();
			{
				// TODO kingofthehill.whiteFlag = make_bitboard(SQ_D4, SQ_E4, SQ_D5, SQ_E5);
				// TODO kingofthehill.blackFlag = make_bitboard(SQ_D4, SQ_E4, SQ_D5, SQ_E5);
				kingofthehill.flagMove = false;
			}
			Variant racingkings = new Variant ();
			{
				racingkings.startFen = "8/8/8/8/8/8/krbnNBRK/qrbnNBRQ w - - 0 1";
				// TODO racingkings.whiteFlag = Rank8BB;
				// racingkings.blackFlag = Rank8BB;
				racingkings.flagMove = true;
				racingkings.castling = false;
				racingkings.checking = false;
			}
			Variant losers = new Variant ();
			{
				losers.checkmateValue = (int)Common.Value.VALUE_MATE;
				losers.stalemateValue = (int)Common.Value.VALUE_MATE;
				losers.bareKingValue = (int)Common.Value.VALUE_MATE;
				losers.bareKingMove = false;
				losers.mustCapture = true;
			}
			Variant giveaway = new Variant ();
			{
				giveaway.remove_piece (Common.PieceType.KING);
				giveaway.add_piece (Common.PieceType.COMMONER, 'k');
				giveaway.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
				giveaway.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.COMMONER,
					Common.PieceType.QUEEN,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT
				};
				giveaway.stalemateValue = (int)Common.Value.VALUE_MATE;
				giveaway.extinctionValue = (int)Common.Value.VALUE_MATE;
				giveaway.extinctionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.ALL_PIECES };
				giveaway.mustCapture = true;
			}
			Variant antichess = new Variant ();
			{
				antichess.remove_piece (Common.PieceType.KING);
				antichess.add_piece (Common.PieceType.COMMONER, 'k');
				antichess.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w - - 0 1";
				antichess.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.COMMONER,
					Common.PieceType.QUEEN,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT
				};
				antichess.stalemateValue = (int)Common.Value.VALUE_MATE;
				antichess.extinctionValue = (int)Common.Value.VALUE_MATE;
				antichess.extinctionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.ALL_PIECES };
				antichess.castling = false;
				antichess.mustCapture = true;
			}
			Variant extinction = new Variant ();
			{
				extinction.remove_piece (Common.PieceType.KING);
				extinction.add_piece (Common.PieceType.COMMONER, 'k');
				extinction.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
				extinction.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.COMMONER,
					Common.PieceType.QUEEN,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT
				};
				extinction.extinctionValue = -(int)Common.Value.VALUE_MATE;
				extinction.extinctionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.COMMONER,
					Common.PieceType.QUEEN,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT,
					Common.PieceType.PAWN
				};
			}
			Variant kinglet = new Variant ();
			{
				kinglet.remove_piece (Common.PieceType.KING);
				kinglet.add_piece (Common.PieceType.COMMONER, 'k');
				kinglet.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
				kinglet.promotionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.COMMONER };
				kinglet.extinctionValue = -(int)Common.Value.VALUE_MATE;
				kinglet.extinctionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.PAWN };
			}
			Variant threecheck = new Variant ();
			{
				threecheck.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 3+3 0 1";
				threecheck.maxCheckCount = 3;
			}
			Variant fivecheck = new Variant ();
			{
				fivecheck.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 5+5 0 1";
				fivecheck.maxCheckCount = 5;
			}
			Variant crazyhouse = new Variant ();
			{
				crazyhouse.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR[] w KQkq - 0 1";
				crazyhouse.pieceDrops = true;
				crazyhouse.capturesToHand = true;
			}
			Variant loop = new Variant ();
			{
				loop.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR[] w KQkq - 0 1";
				loop.pieceDrops = true;
				loop.capturesToHand = true;
				loop.dropLoop = true;
			}
			Variant chessgi = new Variant ();
			{
				chessgi.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR[] w KQkq - 0 1";
				chessgi.pieceDrops = true;
				chessgi.dropLoop = true;
				chessgi.capturesToHand = true;
				chessgi.firstRankDrops = true;
			}
			Variant pocketknight = new Variant ();
			{
				pocketknight.startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR[Nn] w KQkq - 0 1";
				pocketknight.pieceDrops = true;
				pocketknight.capturesToHand = false;
			}
			Variant euroshogi = new Variant ();
			{
				euroshogi.reset_pieces ();
				euroshogi.add_piece (Common.PieceType.SHOGI_PAWN, 'p');
				euroshogi.add_piece (Common.PieceType.EUROSHOGI_KNIGHT, 'n');
				euroshogi.add_piece (Common.PieceType.GOLD, 'g');
				euroshogi.add_piece (Common.PieceType.BISHOP, 'b');
				euroshogi.add_piece (Common.PieceType.HORSE, 'h');
				euroshogi.add_piece (Common.PieceType.ROOK, 'r');
				euroshogi.add_piece (Common.PieceType.KING, 'k');
				euroshogi.add_piece (Common.PieceType.DRAGON, 'd');
				euroshogi.startFen = "1nbgkgn1/1r4b1/pppppppp/8/8/PPPPPPPP/1B4R1/1NGKGBN1[-] w 0 1";
				euroshogi.pieceDrops = true;
				euroshogi.capturesToHand = true;
				euroshogi.promotionRank = Common.Rank.RANK_6;
				euroshogi.promotionPieceTypes = new HashSet<Common.PieceType>{ };
				euroshogi.doubleStep = false;
				euroshogi.castling = false;
				euroshogi.promotedPieceType [(int)Common.PieceType.SHOGI_PAWN] = Common.PieceType.GOLD;
				euroshogi.promotedPieceType [(int)Common.PieceType.EUROSHOGI_KNIGHT] = Common.PieceType.GOLD;
				euroshogi.promotedPieceType [(int)Common.PieceType.SILVER] = Common.PieceType.GOLD;
				euroshogi.promotedPieceType [(int)Common.PieceType.BISHOP] = Common.PieceType.HORSE;
				euroshogi.promotedPieceType [(int)Common.PieceType.ROOK] = Common.PieceType.DRAGON;
				euroshogi.mandatoryPiecePromotion = true;
			}
			Variant judkinsshogi = new Variant ();
			{
				judkinsshogi.maxRank = Common.Rank.RANK_6;
				judkinsshogi.maxFile = Common.File.FILE_F;
				judkinsshogi.reset_pieces ();
				judkinsshogi.add_piece (Common.PieceType.SHOGI_PAWN, 'p');
				judkinsshogi.add_piece (Common.PieceType.SHOGI_KNIGHT, 'n');
				judkinsshogi.add_piece (Common.PieceType.SILVER, 's');
				judkinsshogi.add_piece (Common.PieceType.GOLD, 'g');
				judkinsshogi.add_piece (Common.PieceType.BISHOP, 'b');
				judkinsshogi.add_piece (Common.PieceType.HORSE, 'h');
				judkinsshogi.add_piece (Common.PieceType.ROOK, 'r');
				judkinsshogi.add_piece (Common.PieceType.DRAGON, 'd');
				judkinsshogi.add_piece (Common.PieceType.KING, 'k');
				judkinsshogi.startFen = "rbnsgk/5p/6/6/P5/KGSNBR[-] w 0 1";
				judkinsshogi.pieceDrops = true;
				judkinsshogi.capturesToHand = true;
				judkinsshogi.promotionRank = Common.Rank.RANK_5;
				judkinsshogi.promotionPieceTypes = new HashSet<Common.PieceType> { };
				judkinsshogi.doubleStep = false;
				judkinsshogi.castling = false;
				judkinsshogi.promotedPieceType [(int)Common.PieceType.SHOGI_PAWN] = Common.PieceType.GOLD;
				judkinsshogi.promotedPieceType [(int)Common.PieceType.SHOGI_KNIGHT] = Common.PieceType.GOLD;
				judkinsshogi.promotedPieceType [(int)Common.PieceType.SILVER] = Common.PieceType.GOLD;
				judkinsshogi.promotedPieceType [(int)Common.PieceType.BISHOP] = Common.PieceType.HORSE;
				judkinsshogi.promotedPieceType [(int)Common.PieceType.ROOK] = Common.PieceType.DRAGON;
			}
			Variant minishogi = new Variant ();
			{
				minishogi.maxRank = Common.Rank.RANK_5;
				minishogi.maxFile = Common.File.FILE_E;
				minishogi.reset_pieces ();
				minishogi.add_piece (Common.PieceType.SHOGI_PAWN, 'p');
				minishogi.add_piece (Common.PieceType.SILVER, 's');
				minishogi.add_piece (Common.PieceType.GOLD, 'g');
				minishogi.add_piece (Common.PieceType.BISHOP, 'b');
				minishogi.add_piece (Common.PieceType.HORSE, 'h');
				minishogi.add_piece (Common.PieceType.ROOK, 'r');
				minishogi.add_piece (Common.PieceType.DRAGON, 'd');
				minishogi.add_piece (Common.PieceType.KING, 'k');
				minishogi.startFen = "rbsgk/4p/5/P4/KGSBR[-] w 0 1";
				minishogi.pieceDrops = true;
				minishogi.capturesToHand = true;
				minishogi.promotionRank = Common.Rank.RANK_5;
				minishogi.promotionPieceTypes = new HashSet<Common.PieceType> { };
				minishogi.doubleStep = false;
				minishogi.castling = false;
				minishogi.promotedPieceType [(int)Common.PieceType.SHOGI_PAWN] = Common.PieceType.GOLD;
				minishogi.promotedPieceType [(int)Common.PieceType.SILVER] = Common.PieceType.GOLD;
				minishogi.promotedPieceType [(int)Common.PieceType.BISHOP] = Common.PieceType.HORSE;
				minishogi.promotedPieceType [(int)Common.PieceType.ROOK] = Common.PieceType.DRAGON;
			}
			Variant losalamos = new Variant ();
			{
				losalamos.maxRank = Common.Rank.RANK_6;
				losalamos.maxFile = Common.File.FILE_F;
				losalamos.remove_piece (Common.PieceType.BISHOP);
				losalamos.startFen = "rnqknr/pppppp/6/6/PPPPPP/RNQKNR w - - 0 1";
				losalamos.promotionRank = Common.Rank.RANK_6;
				losalamos.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.QUEEN,
					Common.PieceType.ROOK,
					Common.PieceType.KNIGHT
				};
				losalamos.doubleStep = false;
				losalamos.castling = false;
			}
			Variant almost = new Variant ();
			{
				almost.remove_piece (Common.PieceType.QUEEN);
				almost.add_piece (Common.PieceType.CHANCELLOR, 'c');
				almost.startFen = "rnbckbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBCKBNR w KQkq - 0 1";
				almost.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.CHANCELLOR,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT
				};
				almost.endgameEval = true;
			}
			Variant chigorin = new Variant ();
			{
				chigorin.add_piece (Common.PieceType.CHANCELLOR, 'c');
				chigorin.startFen = "rbbqkbbr/pppppppp/8/8/8/8/PPPPPPPP/RNNCKNNR w KQkq - 0 1";
				chigorin.promotionPieceTypes = new HashSet<Common.PieceType> {
					Common.PieceType.QUEEN,
					Common.PieceType.CHANCELLOR,
					Common.PieceType.ROOK,
					Common.PieceType.BISHOP,
					Common.PieceType.KNIGHT
				};
				chigorin.endgameEval = true;
			}
			Variant shatar = new Variant ();
			{
				shatar.remove_piece (Common.PieceType.QUEEN);
				shatar.add_piece (Common.PieceType.BERS, 'j');
				shatar.startFen = "rnbjkbnr/ppp1pppp/8/3p4/3P4/8/PPP1PPPP/RNBJKBNR w - - 0 1";
				shatar.promotionPieceTypes = new HashSet<Common.PieceType> { Common.PieceType.BERS };
				shatar.endgameEval = true;
				shatar.doubleStep = false;
				shatar.castling = false;
				shatar.bareKingValue = (int)Common.Value.VALUE_DRAW;
				// TODO: illegal checkmates
			}

			// Add to UCI_Variant option
			variants.Add (Common.VariantType.chess, chess);
			variants.Add (Common.VariantType.standard, chess);
			variants.Add (Common.VariantType.makruk, makruk);
			variants.Add (Common.VariantType.asean, asean);
			variants.Add (Common.VariantType.ai_wok, aiwok);
			variants.Add (Common.VariantType.shatranj, shatranj);
			variants.Add (Common.VariantType.amazon, amazon);
			variants.Add (Common.VariantType.hoppelpoppel, hoppelpoppel);
			variants.Add (Common.VariantType.kingofthehill, kingofthehill);
			variants.Add (Common.VariantType.racingkings, racingkings);
			variants.Add (Common.VariantType.losers, losers);
			variants.Add (Common.VariantType.giveaway, giveaway);
			variants.Add (Common.VariantType.antichess, antichess);
			variants.Add (Common.VariantType.extinction, extinction);
			variants.Add (Common.VariantType.kinglet, kinglet);
			variants.Add (Common.VariantType.three_check, threecheck);
			variants.Add (Common.VariantType.five_check, fivecheck);
			variants.Add (Common.VariantType.crazyhouse, crazyhouse);
			variants.Add (Common.VariantType.loop, loop);
			variants.Add (Common.VariantType.chessgi, chessgi);
			variants.Add (Common.VariantType.pocketknight, pocketknight);
			variants.Add (Common.VariantType.euroshogi, euroshogi);
			variants.Add (Common.VariantType.judkinshogi, judkinsshogi);
			variants.Add (Common.VariantType.minishogi, minishogi);
			variants.Add (Common.VariantType.losalamos, losalamos);
			variants.Add (Common.VariantType.almost, almost);
			variants.Add (Common.VariantType.chigorin, chigorin);
			variants.Add (Common.VariantType.shatar, shatar);
		}

		public static string GetStartFen(Common.VariantType variantType)
		{
			return variants [variantType].startFen;
		}

		#region EnableVariants

		public static Common.VariantType[] EnableVariants = {
			Common.VariantType.asean,
			Common.VariantType.ai_wok,
			Common.VariantType.amazon,
			Common.VariantType.hoppelpoppel,
			Common.VariantType.kingofthehill,
			Common.VariantType.racingkings,
			Common.VariantType.losers,
			Common.VariantType.giveaway,
			Common.VariantType.antichess,
			Common.VariantType.extinction,
			Common.VariantType.kinglet,
			Common.VariantType.three_check,
			Common.VariantType.five_check,
			Common.VariantType.crazyhouse,
			Common.VariantType.loop,
			Common.VariantType.chessgi,
			Common.VariantType.pocketknight,
			Common.VariantType.euroshogi,
			Common.VariantType.judkinshogi,
			Common.VariantType.minishogi,
			Common.VariantType.losalamos,
			Common.VariantType.almost,
			Common.VariantType.chigorin,
			Common.VariantType.shatar
		};

		public static int getEnableVariantIndex(Common.VariantType variantType)
		{
			int index = 0;
			{
				for (int i = 0; i < EnableVariants.Length; i++) {
					if (EnableVariants [i] == variantType) {
						index = i;
					}
				}
			}
			return index;
		}

		#endregion

	}
}