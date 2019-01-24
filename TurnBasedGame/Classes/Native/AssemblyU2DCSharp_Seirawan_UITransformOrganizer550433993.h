#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3450728808.h"

// Seirawan.SeirawanGameDataUI/UIData
struct UIData_t641257977;
// GameDataBoardCheckTransformChange`1<Seirawan.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t2225812019;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.UITransformOrganizer
struct  UITransformOrganizer_t550433993  : public UpdateBehavior_1_t3450728808
{
public:
	// Seirawan.SeirawanGameDataUI/UIData Seirawan.UITransformOrganizer::seirawanGameDataUIData
	UIData_t641257977 * ___seirawanGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Seirawan.UITransformOrganizer/UpdateData> Seirawan.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t2225812019 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_seirawanGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t550433993, ___seirawanGameDataUIData_4)); }
	inline UIData_t641257977 * get_seirawanGameDataUIData_4() const { return ___seirawanGameDataUIData_4; }
	inline UIData_t641257977 ** get_address_of_seirawanGameDataUIData_4() { return &___seirawanGameDataUIData_4; }
	inline void set_seirawanGameDataUIData_4(UIData_t641257977 * value)
	{
		___seirawanGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___seirawanGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t550433993, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t2225812019 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t2225812019 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t2225812019 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
