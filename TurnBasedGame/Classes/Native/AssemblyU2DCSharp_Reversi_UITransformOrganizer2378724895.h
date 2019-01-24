#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1956301696.h"

// Reversi.ReversiGameDataUI/UIData
struct UIData_t1808669889;
// GameDataBoardCheckTransformChange`1<Reversi.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t731384907;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.UITransformOrganizer
struct  UITransformOrganizer_t2378724895  : public UpdateBehavior_1_t1956301696
{
public:
	// Reversi.ReversiGameDataUI/UIData Reversi.UITransformOrganizer::reversiGameDataUIData
	UIData_t1808669889 * ___reversiGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Reversi.UITransformOrganizer/UpdateData> Reversi.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t731384907 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_reversiGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2378724895, ___reversiGameDataUIData_4)); }
	inline UIData_t1808669889 * get_reversiGameDataUIData_4() const { return ___reversiGameDataUIData_4; }
	inline UIData_t1808669889 ** get_address_of_reversiGameDataUIData_4() { return &___reversiGameDataUIData_4; }
	inline void set_reversiGameDataUIData_4(UIData_t1808669889 * value)
	{
		___reversiGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___reversiGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2378724895, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t731384907 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t731384907 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t731384907 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
