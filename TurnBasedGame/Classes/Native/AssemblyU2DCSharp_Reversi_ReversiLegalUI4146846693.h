#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen316050784.h"

// Reversi.ReversiGameDataUI/UIData
struct UIData_t1808669889;
// GameDataBoardCheckPerspectiveChange`1<Reversi.ReversiLegalUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3571371528;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiLegalUI
struct  ReversiLegalUI_t4146846693  : public UIBehavior_1_t316050784
{
public:
	// Reversi.ReversiGameDataUI/UIData Reversi.ReversiLegalUI::reversiGameDataUIData
	UIData_t1808669889 * ___reversiGameDataUIData_7;
	// GameDataBoardCheckPerspectiveChange`1<Reversi.ReversiLegalUI/UIData> Reversi.ReversiLegalUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3571371528 * ___perspectiveChange_8;

public:
	inline static int32_t get_offset_of_reversiGameDataUIData_7() { return static_cast<int32_t>(offsetof(ReversiLegalUI_t4146846693, ___reversiGameDataUIData_7)); }
	inline UIData_t1808669889 * get_reversiGameDataUIData_7() const { return ___reversiGameDataUIData_7; }
	inline UIData_t1808669889 ** get_address_of_reversiGameDataUIData_7() { return &___reversiGameDataUIData_7; }
	inline void set_reversiGameDataUIData_7(UIData_t1808669889 * value)
	{
		___reversiGameDataUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___reversiGameDataUIData_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(ReversiLegalUI_t4146846693, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3571371528 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t3571371528 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t3571371528 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}
};

struct ReversiLegalUI_t4146846693_StaticFields
{
public:
	// System.Boolean Reversi.ReversiLegalUI::log
	bool ___log_6;

public:
	inline static int32_t get_offset_of_log_6() { return static_cast<int32_t>(offsetof(ReversiLegalUI_t4146846693_StaticFields, ___log_6)); }
	inline bool get_log_6() const { return ___log_6; }
	inline bool* get_address_of_log_6() { return &___log_6; }
	inline void set_log_6(bool value)
	{
		___log_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
