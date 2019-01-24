#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1333445220.h"

// RussianDraught.RussianDraughtGameDataUI/UIData
struct UIData_t155296009;
// GameDataBoardCheckTransformChange`1<RussianDraught.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t108528431;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.UITransformOrganizer
struct  UITransformOrganizer_t3987529151  : public UpdateBehavior_1_t1333445220
{
public:
	// RussianDraught.RussianDraughtGameDataUI/UIData RussianDraught.UITransformOrganizer::russianDraughtGameDataUIData
	UIData_t155296009 * ___russianDraughtGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<RussianDraught.UITransformOrganizer/UpdateData> RussianDraught.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t108528431 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_russianDraughtGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t3987529151, ___russianDraughtGameDataUIData_4)); }
	inline UIData_t155296009 * get_russianDraughtGameDataUIData_4() const { return ___russianDraughtGameDataUIData_4; }
	inline UIData_t155296009 ** get_address_of_russianDraughtGameDataUIData_4() { return &___russianDraughtGameDataUIData_4; }
	inline void set_russianDraughtGameDataUIData_4(UIData_t155296009 * value)
	{
		___russianDraughtGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t3987529151, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t108528431 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t108528431 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t108528431 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
