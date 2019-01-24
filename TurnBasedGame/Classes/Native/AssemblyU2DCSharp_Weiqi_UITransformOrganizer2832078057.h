#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen296158023.h"

// Weiqi.WeiqiGameDataUI/UIData
struct UIData_t3165614177;
// GameDataBoardCheckTransformChange`1<Weiqi.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t3366208530;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.UITransformOrganizer
struct  UITransformOrganizer_t2832078057  : public UpdateBehavior_1_t296158023
{
public:
	// Weiqi.WeiqiGameDataUI/UIData Weiqi.UITransformOrganizer::weiqiGameDataUIData
	UIData_t3165614177 * ___weiqiGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Weiqi.UITransformOrganizer/UpdateData> Weiqi.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t3366208530 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_weiqiGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2832078057, ___weiqiGameDataUIData_4)); }
	inline UIData_t3165614177 * get_weiqiGameDataUIData_4() const { return ___weiqiGameDataUIData_4; }
	inline UIData_t3165614177 ** get_address_of_weiqiGameDataUIData_4() { return &___weiqiGameDataUIData_4; }
	inline void set_weiqiGameDataUIData_4(UIData_t3165614177 * value)
	{
		___weiqiGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2832078057, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t3366208530 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t3366208530 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t3366208530 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
