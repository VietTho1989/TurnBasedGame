#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1556091837.h"

// Gomoku.BoardUI
struct BoardUI_t760474964;
// Gomoku.LastMoveUI
struct LastMoveUI_t3371419453;
// Gomoku.ShowHintUI
struct ShowHintUI_t3723161080;
// Gomoku.InputUI
struct InputUI_t2120662820;
// CheckHaveAnimation`1<Gomoku.GomokuGameDataUI/UIData>
struct CheckHaveAnimation_1_t3189562495;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuGameDataUI
struct  GomokuGameDataUI_t3096118948  : public UIBehavior_1_t1556091837
{
public:
	// Gomoku.BoardUI Gomoku.GomokuGameDataUI::boardPrefab
	BoardUI_t760474964 * ___boardPrefab_6;
	// Gomoku.LastMoveUI Gomoku.GomokuGameDataUI::lastMovePrefab
	LastMoveUI_t3371419453 * ___lastMovePrefab_7;
	// Gomoku.ShowHintUI Gomoku.GomokuGameDataUI::showHintPrefab
	ShowHintUI_t3723161080 * ___showHintPrefab_8;
	// Gomoku.InputUI Gomoku.GomokuGameDataUI::inputPrefab
	InputUI_t2120662820 * ___inputPrefab_9;
	// CheckHaveAnimation`1<Gomoku.GomokuGameDataUI/UIData> Gomoku.GomokuGameDataUI::checkHaveAnimation
	CheckHaveAnimation_1_t3189562495 * ___checkHaveAnimation_10;

public:
	inline static int32_t get_offset_of_boardPrefab_6() { return static_cast<int32_t>(offsetof(GomokuGameDataUI_t3096118948, ___boardPrefab_6)); }
	inline BoardUI_t760474964 * get_boardPrefab_6() const { return ___boardPrefab_6; }
	inline BoardUI_t760474964 ** get_address_of_boardPrefab_6() { return &___boardPrefab_6; }
	inline void set_boardPrefab_6(BoardUI_t760474964 * value)
	{
		___boardPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardPrefab_6, value);
	}

	inline static int32_t get_offset_of_lastMovePrefab_7() { return static_cast<int32_t>(offsetof(GomokuGameDataUI_t3096118948, ___lastMovePrefab_7)); }
	inline LastMoveUI_t3371419453 * get_lastMovePrefab_7() const { return ___lastMovePrefab_7; }
	inline LastMoveUI_t3371419453 ** get_address_of_lastMovePrefab_7() { return &___lastMovePrefab_7; }
	inline void set_lastMovePrefab_7(LastMoveUI_t3371419453 * value)
	{
		___lastMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___lastMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_showHintPrefab_8() { return static_cast<int32_t>(offsetof(GomokuGameDataUI_t3096118948, ___showHintPrefab_8)); }
	inline ShowHintUI_t3723161080 * get_showHintPrefab_8() const { return ___showHintPrefab_8; }
	inline ShowHintUI_t3723161080 ** get_address_of_showHintPrefab_8() { return &___showHintPrefab_8; }
	inline void set_showHintPrefab_8(ShowHintUI_t3723161080 * value)
	{
		___showHintPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___showHintPrefab_8, value);
	}

	inline static int32_t get_offset_of_inputPrefab_9() { return static_cast<int32_t>(offsetof(GomokuGameDataUI_t3096118948, ___inputPrefab_9)); }
	inline InputUI_t2120662820 * get_inputPrefab_9() const { return ___inputPrefab_9; }
	inline InputUI_t2120662820 ** get_address_of_inputPrefab_9() { return &___inputPrefab_9; }
	inline void set_inputPrefab_9(InputUI_t2120662820 * value)
	{
		___inputPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___inputPrefab_9, value);
	}

	inline static int32_t get_offset_of_checkHaveAnimation_10() { return static_cast<int32_t>(offsetof(GomokuGameDataUI_t3096118948, ___checkHaveAnimation_10)); }
	inline CheckHaveAnimation_1_t3189562495 * get_checkHaveAnimation_10() const { return ___checkHaveAnimation_10; }
	inline CheckHaveAnimation_1_t3189562495 ** get_address_of_checkHaveAnimation_10() { return &___checkHaveAnimation_10; }
	inline void set_checkHaveAnimation_10(CheckHaveAnimation_1_t3189562495 * value)
	{
		___checkHaveAnimation_10 = value;
		Il2CppCodeGenWriteBarrier(&___checkHaveAnimation_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
