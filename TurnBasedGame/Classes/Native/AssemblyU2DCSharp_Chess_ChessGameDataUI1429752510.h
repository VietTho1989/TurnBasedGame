#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2832153253.h"

// Chess.BoardUI
struct BoardUI_t2531315704;
// Chess.LastMoveUI
struct LastMoveUI_t3916666241;
// Chess.ShowHintUI
struct ShowHintUI_t865079400;
// Chess.InputUI
struct InputUI_t2115290124;
// CheckHaveAnimation`1<Chess.ChessGameDataUI/UIData>
struct CheckHaveAnimation_1_t170656615;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.ChessGameDataUI
struct  ChessGameDataUI_t1429752510  : public UIBehavior_1_t2832153253
{
public:
	// Chess.BoardUI Chess.ChessGameDataUI::boardPrefab
	BoardUI_t2531315704 * ___boardPrefab_6;
	// Chess.LastMoveUI Chess.ChessGameDataUI::lastMovePrefab
	LastMoveUI_t3916666241 * ___lastMovePrefab_7;
	// Chess.ShowHintUI Chess.ChessGameDataUI::showHintPrefab
	ShowHintUI_t865079400 * ___showHintPrefab_8;
	// Chess.InputUI Chess.ChessGameDataUI::inputPrefab
	InputUI_t2115290124 * ___inputPrefab_9;
	// CheckHaveAnimation`1<Chess.ChessGameDataUI/UIData> Chess.ChessGameDataUI::checkHaveAnimation
	CheckHaveAnimation_1_t170656615 * ___checkHaveAnimation_10;

public:
	inline static int32_t get_offset_of_boardPrefab_6() { return static_cast<int32_t>(offsetof(ChessGameDataUI_t1429752510, ___boardPrefab_6)); }
	inline BoardUI_t2531315704 * get_boardPrefab_6() const { return ___boardPrefab_6; }
	inline BoardUI_t2531315704 ** get_address_of_boardPrefab_6() { return &___boardPrefab_6; }
	inline void set_boardPrefab_6(BoardUI_t2531315704 * value)
	{
		___boardPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardPrefab_6, value);
	}

	inline static int32_t get_offset_of_lastMovePrefab_7() { return static_cast<int32_t>(offsetof(ChessGameDataUI_t1429752510, ___lastMovePrefab_7)); }
	inline LastMoveUI_t3916666241 * get_lastMovePrefab_7() const { return ___lastMovePrefab_7; }
	inline LastMoveUI_t3916666241 ** get_address_of_lastMovePrefab_7() { return &___lastMovePrefab_7; }
	inline void set_lastMovePrefab_7(LastMoveUI_t3916666241 * value)
	{
		___lastMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___lastMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_showHintPrefab_8() { return static_cast<int32_t>(offsetof(ChessGameDataUI_t1429752510, ___showHintPrefab_8)); }
	inline ShowHintUI_t865079400 * get_showHintPrefab_8() const { return ___showHintPrefab_8; }
	inline ShowHintUI_t865079400 ** get_address_of_showHintPrefab_8() { return &___showHintPrefab_8; }
	inline void set_showHintPrefab_8(ShowHintUI_t865079400 * value)
	{
		___showHintPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___showHintPrefab_8, value);
	}

	inline static int32_t get_offset_of_inputPrefab_9() { return static_cast<int32_t>(offsetof(ChessGameDataUI_t1429752510, ___inputPrefab_9)); }
	inline InputUI_t2115290124 * get_inputPrefab_9() const { return ___inputPrefab_9; }
	inline InputUI_t2115290124 ** get_address_of_inputPrefab_9() { return &___inputPrefab_9; }
	inline void set_inputPrefab_9(InputUI_t2115290124 * value)
	{
		___inputPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___inputPrefab_9, value);
	}

	inline static int32_t get_offset_of_checkHaveAnimation_10() { return static_cast<int32_t>(offsetof(ChessGameDataUI_t1429752510, ___checkHaveAnimation_10)); }
	inline CheckHaveAnimation_1_t170656615 * get_checkHaveAnimation_10() const { return ___checkHaveAnimation_10; }
	inline CheckHaveAnimation_1_t170656615 ** get_address_of_checkHaveAnimation_10() { return &___checkHaveAnimation_10; }
	inline void set_checkHaveAnimation_10(CheckHaveAnimation_1_t170656615 * value)
	{
		___checkHaveAnimation_10 = value;
		Il2CppCodeGenWriteBarrier(&___checkHaveAnimation_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
