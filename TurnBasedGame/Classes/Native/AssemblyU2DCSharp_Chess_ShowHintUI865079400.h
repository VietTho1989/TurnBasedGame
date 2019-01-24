#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2568192669.h"

// Chess.ChessMoveUI
struct ChessMoveUI_t3171707265;
// Chess.NoneRule.ChessCustomSetUI
struct ChessCustomSetUI_t507609497;
// Chess.NoneRule.ChessCustomMoveUI
struct ChessCustomMoveUI_t1974963002;
// Chess.ChessGameDataUI/UIData
struct UIData_t3548078401;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.ShowHintUI
struct  ShowHintUI_t865079400  : public UIBehavior_1_t2568192669
{
public:
	// Chess.ChessMoveUI Chess.ShowHintUI::chessMovePrefab
	ChessMoveUI_t3171707265 * ___chessMovePrefab_6;
	// Chess.NoneRule.ChessCustomSetUI Chess.ShowHintUI::chessCustomSetPrefab
	ChessCustomSetUI_t507609497 * ___chessCustomSetPrefab_7;
	// Chess.NoneRule.ChessCustomMoveUI Chess.ShowHintUI::chessCustomMovePrefab
	ChessCustomMoveUI_t1974963002 * ___chessCustomMovePrefab_8;
	// Chess.ChessGameDataUI/UIData Chess.ShowHintUI::chessGameDataUIData
	UIData_t3548078401 * ___chessGameDataUIData_9;
	// GameDataUI/UIData Chess.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_10;

public:
	inline static int32_t get_offset_of_chessMovePrefab_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t865079400, ___chessMovePrefab_6)); }
	inline ChessMoveUI_t3171707265 * get_chessMovePrefab_6() const { return ___chessMovePrefab_6; }
	inline ChessMoveUI_t3171707265 ** get_address_of_chessMovePrefab_6() { return &___chessMovePrefab_6; }
	inline void set_chessMovePrefab_6(ChessMoveUI_t3171707265 * value)
	{
		___chessMovePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chessMovePrefab_6, value);
	}

	inline static int32_t get_offset_of_chessCustomSetPrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t865079400, ___chessCustomSetPrefab_7)); }
	inline ChessCustomSetUI_t507609497 * get_chessCustomSetPrefab_7() const { return ___chessCustomSetPrefab_7; }
	inline ChessCustomSetUI_t507609497 ** get_address_of_chessCustomSetPrefab_7() { return &___chessCustomSetPrefab_7; }
	inline void set_chessCustomSetPrefab_7(ChessCustomSetUI_t507609497 * value)
	{
		___chessCustomSetPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___chessCustomSetPrefab_7, value);
	}

	inline static int32_t get_offset_of_chessCustomMovePrefab_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t865079400, ___chessCustomMovePrefab_8)); }
	inline ChessCustomMoveUI_t1974963002 * get_chessCustomMovePrefab_8() const { return ___chessCustomMovePrefab_8; }
	inline ChessCustomMoveUI_t1974963002 ** get_address_of_chessCustomMovePrefab_8() { return &___chessCustomMovePrefab_8; }
	inline void set_chessCustomMovePrefab_8(ChessCustomMoveUI_t1974963002 * value)
	{
		___chessCustomMovePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___chessCustomMovePrefab_8, value);
	}

	inline static int32_t get_offset_of_chessGameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t865079400, ___chessGameDataUIData_9)); }
	inline UIData_t3548078401 * get_chessGameDataUIData_9() const { return ___chessGameDataUIData_9; }
	inline UIData_t3548078401 ** get_address_of_chessGameDataUIData_9() { return &___chessGameDataUIData_9; }
	inline void set_chessGameDataUIData_9(UIData_t3548078401 * value)
	{
		___chessGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___chessGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_10() { return static_cast<int32_t>(offsetof(ShowHintUI_t865079400, ___gameDataUIData_10)); }
	inline UIData_t306925783 * get_gameDataUIData_10() const { return ___gameDataUIData_10; }
	inline UIData_t306925783 ** get_address_of_gameDataUIData_10() { return &___gameDataUIData_10; }
	inline void set_gameDataUIData_10(UIData_t306925783 * value)
	{
		___gameDataUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
