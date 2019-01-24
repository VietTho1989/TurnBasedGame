#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3185713538.h"

// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;
// GameDataBoardCheckTransformChange`1<Shogi.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t1960796749;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UITransformOrganizer
struct  UITransformOrganizer_t3086698443  : public UpdateBehavior_1_t3185713538
{
public:
	// Shogi.ShogiGameDataUI/UIData Shogi.UITransformOrganizer::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Shogi.UITransformOrganizer/UpdateData> Shogi.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t1960796749 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_shogiGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t3086698443, ___shogiGameDataUIData_4)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_4() const { return ___shogiGameDataUIData_4; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_4() { return &___shogiGameDataUIData_4; }
	inline void set_shogiGameDataUIData_4(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t3086698443, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t1960796749 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t1960796749 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t1960796749 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
