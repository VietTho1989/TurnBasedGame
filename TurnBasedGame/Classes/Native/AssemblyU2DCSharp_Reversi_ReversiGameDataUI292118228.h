#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1092744741.h"

// Reversi.ReversiBoardUI
struct ReversiBoardUI_t388507710;
// Reversi.LastMoveUI
struct LastMoveUI_t2246690057;
// Reversi.ShowHintUI
struct ShowHintUI_t1633490060;
// Reversi.InputUI
struct InputUI_t473539844;
// CheckHaveAnimation`1<Reversi.ReversiGameDataUI/UIData>
struct CheckHaveAnimation_1_t2726215399;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiGameDataUI
struct  ReversiGameDataUI_t292118228  : public UIBehavior_1_t1092744741
{
public:
	// Reversi.ReversiBoardUI Reversi.ReversiGameDataUI::boardPrefab
	ReversiBoardUI_t388507710 * ___boardPrefab_6;
	// Reversi.LastMoveUI Reversi.ReversiGameDataUI::lastMovePrefab
	LastMoveUI_t2246690057 * ___lastMovePrefab_7;
	// Reversi.ShowHintUI Reversi.ReversiGameDataUI::showHintPrefab
	ShowHintUI_t1633490060 * ___showHintPrefab_8;
	// Reversi.InputUI Reversi.ReversiGameDataUI::inputPrefab
	InputUI_t473539844 * ___inputPrefab_9;
	// CheckHaveAnimation`1<Reversi.ReversiGameDataUI/UIData> Reversi.ReversiGameDataUI::checkHaveAnimation
	CheckHaveAnimation_1_t2726215399 * ___checkHaveAnimation_10;

public:
	inline static int32_t get_offset_of_boardPrefab_6() { return static_cast<int32_t>(offsetof(ReversiGameDataUI_t292118228, ___boardPrefab_6)); }
	inline ReversiBoardUI_t388507710 * get_boardPrefab_6() const { return ___boardPrefab_6; }
	inline ReversiBoardUI_t388507710 ** get_address_of_boardPrefab_6() { return &___boardPrefab_6; }
	inline void set_boardPrefab_6(ReversiBoardUI_t388507710 * value)
	{
		___boardPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardPrefab_6, value);
	}

	inline static int32_t get_offset_of_lastMovePrefab_7() { return static_cast<int32_t>(offsetof(ReversiGameDataUI_t292118228, ___lastMovePrefab_7)); }
	inline LastMoveUI_t2246690057 * get_lastMovePrefab_7() const { return ___lastMovePrefab_7; }
	inline LastMoveUI_t2246690057 ** get_address_of_lastMovePrefab_7() { return &___lastMovePrefab_7; }
	inline void set_lastMovePrefab_7(LastMoveUI_t2246690057 * value)
	{
		___lastMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___lastMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_showHintPrefab_8() { return static_cast<int32_t>(offsetof(ReversiGameDataUI_t292118228, ___showHintPrefab_8)); }
	inline ShowHintUI_t1633490060 * get_showHintPrefab_8() const { return ___showHintPrefab_8; }
	inline ShowHintUI_t1633490060 ** get_address_of_showHintPrefab_8() { return &___showHintPrefab_8; }
	inline void set_showHintPrefab_8(ShowHintUI_t1633490060 * value)
	{
		___showHintPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___showHintPrefab_8, value);
	}

	inline static int32_t get_offset_of_inputPrefab_9() { return static_cast<int32_t>(offsetof(ReversiGameDataUI_t292118228, ___inputPrefab_9)); }
	inline InputUI_t473539844 * get_inputPrefab_9() const { return ___inputPrefab_9; }
	inline InputUI_t473539844 ** get_address_of_inputPrefab_9() { return &___inputPrefab_9; }
	inline void set_inputPrefab_9(InputUI_t473539844 * value)
	{
		___inputPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___inputPrefab_9, value);
	}

	inline static int32_t get_offset_of_checkHaveAnimation_10() { return static_cast<int32_t>(offsetof(ReversiGameDataUI_t292118228, ___checkHaveAnimation_10)); }
	inline CheckHaveAnimation_1_t2726215399 * get_checkHaveAnimation_10() const { return ___checkHaveAnimation_10; }
	inline CheckHaveAnimation_1_t2726215399 ** get_address_of_checkHaveAnimation_10() { return &___checkHaveAnimation_10; }
	inline void set_checkHaveAnimation_10(CheckHaveAnimation_1_t2726215399 * value)
	{
		___checkHaveAnimation_10 = value;
		Il2CppCodeGenWriteBarrier(&___checkHaveAnimation_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
