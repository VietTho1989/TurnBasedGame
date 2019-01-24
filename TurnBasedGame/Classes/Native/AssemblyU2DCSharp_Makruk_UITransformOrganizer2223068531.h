#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2520224849.h"

// Makruk.MakrukGameDataUI/UIData
struct UIData_t925552405;
// GameDataBoardCheckTransformChange`1<Makruk.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t1295308060;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.UITransformOrganizer
struct  UITransformOrganizer_t2223068531  : public UpdateBehavior_1_t2520224849
{
public:
	// Makruk.MakrukGameDataUI/UIData Makruk.UITransformOrganizer::makrukGameDataUIData
	UIData_t925552405 * ___makrukGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Makruk.UITransformOrganizer/UpdateData> Makruk.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t1295308060 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_makrukGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2223068531, ___makrukGameDataUIData_4)); }
	inline UIData_t925552405 * get_makrukGameDataUIData_4() const { return ___makrukGameDataUIData_4; }
	inline UIData_t925552405 ** get_address_of_makrukGameDataUIData_4() { return &___makrukGameDataUIData_4; }
	inline void set_makrukGameDataUIData_4(UIData_t925552405 * value)
	{
		___makrukGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___makrukGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2223068531, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t1295308060 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t1295308060 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t1295308060 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
