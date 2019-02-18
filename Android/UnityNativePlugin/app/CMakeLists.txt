cmake_minimum_required(VERSION 3.4.1)

set(CMAKE_CXX_LINK_FLAGS "${CMAKE_CXX_LINK_FLAGS} -latomic")

add_library( # Sets the name of the library.
             NativeCore

             # Sets the library as a shared library.
             SHARED

             src/main/cpp/Platform.cpp

             # Gomoku
             src/main/cpp/gomoku/gomoku_jni.cpp
             src/main/cpp/gomoku/gomoku_main.cpp
             src/main/cpp/gomoku/gomoku_position.cpp
             src/main/cpp/gomoku/ai/gomoku_ai_controller.cpp
             src/main/cpp/gomoku/ai/gomoku_eval.cpp
             src/main/cpp/gomoku/ai/gomoku_negamax.cpp
             src/main/cpp/gomoku/ai/gomoku_utils.cpp
             src/main/cpp/gomoku/api/gomoku_renju_api.cpp

             # InternationalDraught
             src/main/cpp/InternationalDraught/international_draught_bb_base.cpp
             src/main/cpp/InternationalDraught/international_draught_bb_comp.cpp
             src/main/cpp/InternationalDraught/international_draught_bb_index.cpp
             src/main/cpp/InternationalDraught/international_draught_bit.cpp
             src/main/cpp/InternationalDraught/international_draught_book.cpp
             src/main/cpp/InternationalDraught/international_draught_common.cpp
             src/main/cpp/InternationalDraught/international_draught_eval.cpp
             src/main/cpp/InternationalDraught/international_draught_fen.cpp
             src/main/cpp/InternationalDraught/international_draught_hash.cpp
             src/main/cpp/InternationalDraught/international_draught_jni.cpp
             src/main/cpp/InternationalDraught/international_draught_libmy.cpp
             src/main/cpp/InternationalDraught/international_draught_list.cpp
             src/main/cpp/InternationalDraught/international_draught_main.cpp
             src/main/cpp/InternationalDraught/international_draught_move.cpp
             src/main/cpp/InternationalDraught/international_draught_move_gen.cpp
             src/main/cpp/InternationalDraught/international_draught_MyBase.cpp
             src/main/cpp/InternationalDraught/international_draught_pos.cpp
             src/main/cpp/InternationalDraught/international_draught_position.cpp
             src/main/cpp/InternationalDraught/international_draught_score.cpp
             src/main/cpp/InternationalDraught/international_draught_search.cpp
             src/main/cpp/InternationalDraught/international_draught_sort.cpp
             src/main/cpp/InternationalDraught/international_draught_thread.cpp
             src/main/cpp/InternationalDraught/international_draught_tt.cpp
             src/main/cpp/InternationalDraught/international_draught_util.cpp
             src/main/cpp/InternationalDraught/international_draught_var.cpp

             # EnglishDraught
             src/main/cpp/EnglishDraught/english_draught_jni.cpp
             src/main/cpp/EnglishDraught/english_draught_main.cpp
             src/main/cpp/EnglishDraught/engine/english_draught_ai.cpp
             src/main/cpp/EnglishDraught/engine/english_draught_board.cpp
             src/main/cpp/EnglishDraught/engine/english_draught_database.cpp
             src/main/cpp/EnglishDraught/engine/english_draught_movegen.cpp

             # RussianDraught
             src/main/cpp/RussianDraught/russian_draught_jni.cpp
             src/main/cpp/RussianDraught/russian_draught_main.cpp
             src/main/cpp/RussianDraught/russian_draught_EdAcessImp.cpp
             src/main/cpp/RussianDraught/russian_draught_KestoG_1_5.cpp

        # ChineseCheckers
        src/main/cpp/ChineseCheckers/chinese_checkers_jni.cpp
        src/main/cpp/ChineseCheckers/chinese_checkers_main.cpp
        src/main/cpp/ChineseCheckers/chinese_checkers_board.cpp
        src/main/cpp/ChineseCheckers/chinese_checkers_interface.cpp
        src/main/cpp/ChineseCheckers/chinese_checkers_movegenerator.cpp
        src/main/cpp/ChineseCheckers/chinese_checkers_ricefish.cpp
        src/main/cpp/ChineseCheckers/chinese_checkers_search.cpp

             # Reversi
             src/main/cpp/Reversi/reversi_blur.cpp
             src/main/cpp/Reversi/reversi_board.cpp
             src/main/cpp/Reversi/reversi_common.cpp
             src/main/cpp/Reversi/reversi_crtbk.cpp
             src/main/cpp/Reversi/reversi_endgame.cpp
             src/main/cpp/Reversi/reversi_endhash.cpp
             src/main/cpp/Reversi/reversi_eval.cpp
             src/main/cpp/Reversi/reversi_evalbuilder.cpp
             src/main/cpp/Reversi/reversi_hash.cpp
             src/main/cpp/Reversi/reversi_jni.cpp
             src/main/cpp/Reversi/reversi_main.cpp
             src/main/cpp/Reversi/reversi_openings.cpp
             src/main/cpp/Reversi/reversi_patternbuilder.cpp
             src/main/cpp/Reversi/reversi_player.cpp
             src/main/cpp/Reversi/reversi_position.cpp
             src/main/cpp/Reversi/reversi_PRNG.cpp
             src/main/cpp/Reversi/reversi_protocol.cpp
             src/main/cpp/Reversi/reversi_testgame.cpp
             src/main/cpp/Reversi/reversi_testsuites.cpp
             src/main/cpp/Reversi/reversi_tuneheuristic.cpp
             src/main/cpp/Reversi/reversi_wrapper.cpp

             # Shatranj
             src/main/cpp/Shatranj/shatranj_jni.cpp
             src/main/cpp/Shatranj/shatranj_main.cpp
             src/main/cpp/Shatranj/shatranj_bitbase.cpp
             src/main/cpp/Shatranj/shatranj_bitboard.cpp
             src/main/cpp/Shatranj/shatranj_endgame.cpp
             src/main/cpp/Shatranj/shatranj_evaluate.cpp
             src/main/cpp/Shatranj/shatranj_material.cpp
             src/main/cpp/Shatranj/shatranj_misc.cpp
             src/main/cpp/Shatranj/shatranj_movegen.cpp
             src/main/cpp/Shatranj/shatranj_movepick.cpp
             src/main/cpp/Shatranj/shatranj_pawns.cpp
             src/main/cpp/Shatranj/shatranj_position.cpp
             src/main/cpp/Shatranj/shatranj_psqt.cpp
             src/main/cpp/Shatranj/shatranj_search.cpp
             src/main/cpp/Shatranj/shatranj_tbprobe.cpp
             src/main/cpp/Shatranj/shatranj_thread.cpp
             src/main/cpp/Shatranj/shatranj_timeman.cpp
             src/main/cpp/Shatranj/shatranj_tt.cpp
             src/main/cpp/Shatranj/shatranj_uci.cpp
             src/main/cpp/Shatranj/shatranj_ucioption.cpp

             # Makruk
             src/main/cpp/Makruk/makruk_jni.cpp
             src/main/cpp/Makruk/makruk_main.cpp
             src/main/cpp/Makruk/engine/makruk_benchmark.cpp
             src/main/cpp/Makruk/engine/makruk_bitbase.cpp
             src/main/cpp/Makruk/engine/makruk_bitboard.cpp
             src/main/cpp/Makruk/engine/makruk_endgame.cpp
             src/main/cpp/Makruk/engine/makruk_evaluate.cpp
             src/main/cpp/Makruk/engine/makruk_material.cpp
             src/main/cpp/Makruk/engine/makruk_misc.cpp
             src/main/cpp/Makruk/engine/makruk_movegen.cpp
             src/main/cpp/Makruk/engine/makruk_movepick.cpp
             src/main/cpp/Makruk/engine/makruk_pawns.cpp
             src/main/cpp/Makruk/engine/makruk_position.cpp
             src/main/cpp/Makruk/engine/makruk_psqt.cpp
             src/main/cpp/Makruk/engine/makruk_search.cpp
             src/main/cpp/Makruk/engine/makruk_thread.cpp
             src/main/cpp/Makruk/engine/makruk_timeman.cpp
             src/main/cpp/Makruk/engine/makruk_tt.cpp
             src/main/cpp/Makruk/engine/makruk_uci.cpp
             src/main/cpp/Makruk/engine/makruk_ucioption.cpp
             src/main/cpp/Makruk/engine/syzygy/makruk_tbprobe.cpp

             # Seirawan
             src/main/cpp/Seirawan/seirawan_jni.cpp
             src/main/cpp/Seirawan/seirawan_main.cpp
             src/main/cpp/Seirawan/seirawan_benchmark.cpp
             src/main/cpp/Seirawan/seirawan_bitbase.cpp
             src/main/cpp/Seirawan/seirawan_bitboard.cpp
             src/main/cpp/Seirawan/seirawan_endgame.cpp
             src/main/cpp/Seirawan/seirawan_evaluate.cpp
             src/main/cpp/Seirawan/seirawan_material.cpp
             src/main/cpp/Seirawan/seirawan_misc.cpp
             src/main/cpp/Seirawan/seirawan_movegen.cpp
             src/main/cpp/Seirawan/seirawan_movepick.cpp
             src/main/cpp/Seirawan/seirawan_pawns.cpp
             src/main/cpp/Seirawan/seirawan_position.cpp
             src/main/cpp/Seirawan/seirawan_psqt.cpp
             src/main/cpp/Seirawan/seirawan_search.cpp
             src/main/cpp/Seirawan/seirawan_thread.cpp
             src/main/cpp/Seirawan/seirawan_timeman.cpp
             src/main/cpp/Seirawan/seirawan_tt.cpp
             src/main/cpp/Seirawan/seirawan_uci.cpp
             src/main/cpp/Seirawan/seirawan_ucioption.cpp
             src/main/cpp/Seirawan/syzygy/seirawan_tbprobe.cpp

             # FairyChess
             src/main/cpp/FairyChess/fairy_chess_jni.cpp
             src/main/cpp/FairyChess/fairy_chess_main.cpp
             src/main/cpp/FairyChess/syzygy/fairy_chess_tbprobe.cpp
             src/main/cpp/FairyChess/fairy_chess_benchmark.cpp
             src/main/cpp/FairyChess/fairy_chess_bitbase.cpp
             src/main/cpp/FairyChess/fairy_chess_bitboard.cpp
             src/main/cpp/FairyChess/fairy_chess_endgame.cpp
             src/main/cpp/FairyChess/fairy_chess_evaluate.cpp
             src/main/cpp/FairyChess/fairy_chess_material.cpp
             src/main/cpp/FairyChess/fairy_chess_misc.cpp
             src/main/cpp/FairyChess/fairy_chess_movegen.cpp
             src/main/cpp/FairyChess/fairy_chess_movepick.cpp
             src/main/cpp/FairyChess/fairy_chess_pawns.cpp
             src/main/cpp/FairyChess/fairy_chess_position.cpp
             src/main/cpp/FairyChess/fairy_chess_psqt.cpp
             src/main/cpp/FairyChess/fairy_chess_search.cpp
             src/main/cpp/FairyChess/fairy_chess_thread.cpp
             src/main/cpp/FairyChess/fairy_chess_timeman.cpp
             src/main/cpp/FairyChess/fairy_chess_tt.cpp
             src/main/cpp/FairyChess/fairy_chess_uci.cpp
             src/main/cpp/FairyChess/fairy_chess_ucioption.cpp
             src/main/cpp/FairyChess/fairy_chess_variant.cpp

             # Shogi
             src/main/cpp/shogi/shogi_jni.cpp
             src/main/cpp/shogi/shogi_main.cpp
             src/main/cpp/shogi/core/shogi_benchmark.cpp
             src/main/cpp/shogi/core/shogi_bitboard.cpp
             src/main/cpp/shogi/core/shogi_book.cpp
             src/main/cpp/shogi/core/shogi_common.cpp
             src/main/cpp/shogi/core/shogi_evalList.cpp
             src/main/cpp/shogi/core/shogi_evaluate.cpp
             src/main/cpp/shogi/core/shogi_generateMoves.cpp
             src/main/cpp/shogi/core/shogi_hand.cpp
             src/main/cpp/shogi/core/shogi_init.cpp
             src/main/cpp/shogi/core/shogi_move.cpp
             src/main/cpp/shogi/core/shogi_movePicker.cpp
             src/main/cpp/shogi/core/shogi_mt64bit.cpp
             src/main/cpp/shogi/core/shogi_pieceScore.cpp
             src/main/cpp/shogi/core/shogi_position.cpp
             src/main/cpp/shogi/core/shogi_search.cpp
             src/main/cpp/shogi/core/shogi_square.cpp
             src/main/cpp/shogi/core/shogi_thread.cpp
             src/main/cpp/shogi/core/shogi_timeManager.cpp
             src/main/cpp/shogi/core/shogi_tt.cpp
             src/main/cpp/shogi/core/shogi_usi.cpp

             # chess
             src/main/cpp/StockFishChess/chess_main.cpp
             src/main/cpp/StockFishChess/chess_stock_fish_jni.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_bitbase.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_tbprobe.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_benchmark.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_bitboard.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_endgame.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_evaluate.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_material.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_misc.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_movegen.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_movepick.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_pawns.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_position.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_psqt.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_search.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_thread.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_timeman.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_tt.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_uci.cpp
             src/main/cpp/StockFishChess/Core/chess_stock_fish_ucioption.cpp

             # weqi
             src/main/cpp/weiqi/weiqi_board.cpp
             src/main/cpp/weiqi/weiqi_dcnn.cpp
             src/main/cpp/weiqi/weiqi_engine.cpp
             src/main/cpp/weiqi/weiqi_fbook.cpp
             src/main/cpp/weiqi/weiqi_gogui.cpp
             src/main/cpp/weiqi/weiqi_jni.cpp
             src/main/cpp/weiqi/weiqi_main.cpp
             src/main/cpp/weiqi/weiqi_move.cpp
             src/main/cpp/weiqi/weiqi_mq.cpp
             src/main/cpp/weiqi/weiqi_ownermap.cpp
             src/main/cpp/weiqi/weiqi_pattern.cpp
             src/main/cpp/weiqi/weiqi_pattern3.cpp
             src/main/cpp/weiqi/weiqi_patternprob.cpp
             src/main/cpp/weiqi/weiqi_patternsp.cpp
             src/main/cpp/weiqi/weiqi_playout.cpp
             src/main/cpp/weiqi/weiqi_position.cpp
             src/main/cpp/weiqi/weiqi_probdist.cpp
             src/main/cpp/weiqi/weiqi_random.cpp
             src/main/cpp/weiqi/weiqi_random_engine.cpp
             src/main/cpp/weiqi/weiqi_stats.cpp
             src/main/cpp/weiqi/weiqi_stone.cpp
             src/main/cpp/weiqi/weiqi_timeinfo.cpp
             src/main/cpp/weiqi/weiqi_util.cpp
             src/main/cpp/weiqi/distributed/weiqi_distributed.cpp
             src/main/cpp/weiqi/distributed/engines/weiqi_josekibase.cpp
             src/main/cpp/weiqi/distributed/engines/weiqi_montecarlo.cpp
             src/main/cpp/weiqi/distributed/engines/weiqi_patternplay.cpp
             src/main/cpp/weiqi/distributed/engines/weiqi_patternscan.cpp
             src/main/cpp/weiqi/playout/weiqi_light.cpp
             src/main/cpp/weiqi/playout/weiqi_moggy.cpp
             src/main/cpp/weiqi/tatics/weiqi_1lib.cpp
             src/main/cpp/weiqi/tatics/weiqi_2lib.cpp
             src/main/cpp/weiqi/tatics/weiqi_dragon.cpp
             src/main/cpp/weiqi/tatics/weiqi_ladder.cpp
             src/main/cpp/weiqi/tatics/weiqi_nakade.cpp
             src/main/cpp/weiqi/tatics/weiqi_nlib.cpp
             src/main/cpp/weiqi/tatics/weiqi_seki.cpp
             src/main/cpp/weiqi/tatics/weiqi_selfatari.cpp
             src/main/cpp/weiqi/tatics/weiqi_tactics_util.cpp
             src/main/cpp/weiqi/uct/policy/weiqi_generic.cpp
             src/main/cpp/weiqi/uct/policy/weiqi_ucb1.cpp
             src/main/cpp/weiqi/uct/policy/weiqi_ucb1amaf.cpp
             src/main/cpp/weiqi/uct/weiqi_dynkomi.cpp
             src/main/cpp/weiqi/uct/weiqi_plugins.cpp
             src/main/cpp/weiqi/uct/weiqi_prior.cpp
             src/main/cpp/weiqi/uct/weiqi_search.cpp
             src/main/cpp/weiqi/uct/weiqi_slave.cpp
             src/main/cpp/weiqi/uct/weiqi_tree.cpp
             src/main/cpp/weiqi/uct/weiqi_uct.cpp
             src/main/cpp/weiqi/uct/weiqi_walk.cpp

             # xiangqi
             src/main/cpp/Xiangqi/xiangqi_main.cpp
             src/main/cpp/Xiangqi/xiangqi_jni.cpp
             src/main/cpp/Xiangqi/base/xiangqi_x86asm.cpp
             src/main/cpp/Xiangqi/cchess/xiangqi_cchess.cpp
             src/main/cpp/Xiangqi/cchess/xiangqi_pgnfile.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_book.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_evaluate.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_genmoves.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_hash.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_movesort.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_position.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_preeval.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_pregen.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_search.cpp
             src/main/cpp/Xiangqi/eleeye/xiangqi_ucci.cpp

             # mineSweeper
             src/main/cpp/MineSweeper/mine_sweeper_main.cpp
             src/main/cpp/MineSweeper/mine_sweeper_jni.cpp
             src/main/cpp/MineSweeper/mine_sweeper_board.cpp
             src/main/cpp/MineSweeper/mine_sweeper_Solver.cpp

             # hex
             src/main/cpp/Hex/hex_main.cpp
             src/main/cpp/Hex/hex_jni.cpp
             src/main/cpp/Hex/fhcore/hex_board.cpp
             src/main/cpp/Hex/fhcore/hex_color.cpp
             src/main/cpp/Hex/fhcore/hex_disjointset.cpp
             src/main/cpp/Hex/fhcore/hex_eval.cpp
             src/main/cpp/Hex/fhcore/hex_hexutils.cpp
             src/main/cpp/Hex/fhcore/hex_iengine.cpp
             src/main/cpp/Hex/fhcore/hex_mcts.cpp
             src/main/cpp/Hex/fhcore/hex_position.cpp
             src/main/cpp/Hex/fhcore/hex_record.cpp

             # solitaire
             src/main/cpp/Solitaire/solitaire_main.cpp
             src/main/cpp/Solitaire/solitaire_jni.cpp
             src/main/cpp/Solitaire/solitaire_Card.cpp
             src/main/cpp/Solitaire/solitaire_Move.cpp
             src/main/cpp/Solitaire/solitaire_Pile.cpp
             src/main/cpp/Solitaire/solitaire_Solitaire.cpp

            # khet
            src/main/cpp/Khet/khet_main.cpp
            src/main/cpp/Khet/khet_jni.cpp
            src/main/cpp/Khet/khet_Board.cpp
            src/main/cpp/Khet/khet_Calculator.cpp
            src/main/cpp/Khet/khet_CommsHandler.cpp
            src/main/cpp/Khet/khet_Evaluator.cpp
            src/main/cpp/Khet/khet_Laser.cpp
            src/main/cpp/Khet/khet_MoveGenerator.cpp
            src/main/cpp/Khet/khet_Search.cpp
            src/main/cpp/Khet/khet_Utils.cpp

        # nmm
        src/main/cpp/nmm/nmm_main.cpp
        src/main/cpp/nmm/nmm_jni.cpp
        src/main/cpp/nmm/nmm_board.cpp
        src/main/cpp/nmm/nmm_evaluator.cpp
        src/main/cpp/nmm/nmmagent.cpp

             # Provides a relative path to your source file(s).
             src/main/cpp/native-lib.cpp )

find_library(log-lib log )
find_library(android-lib android)

target_link_libraries( # Specifies the target library.
                       NativeCore

                       # Links the target library to the log library
                       # included in the NDK.
                       ${log-lib}
                       ${android-lib})