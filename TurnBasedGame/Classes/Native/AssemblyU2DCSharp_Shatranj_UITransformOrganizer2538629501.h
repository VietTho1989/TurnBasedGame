#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen97391465.h"

// Shatranj.ShatranjGameDataUI/UIData
struct UIData_t2391886061;
// GameDataBoardCheckTransformChange`1<Shatranj.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t3167441972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UITransformOrganizer
struct  UITransformOrganizer_t2538629501  : public UpdateBehavior_1_t97391465
{
public:
	// Shatranj.ShatranjGameDataUI/UIData Shatranj.UITransformOrganizer::shatranjGameDataUIData
	UIData_t2391886061 * ___shatranjGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Shatranj.UITransformOrganizer/UpdateData> Shatranj.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t3167441972 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_shatranjGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2538629501, ___shatranjGameDataUIData_4)); }
	inline UIData_t2391886061 * get_shatranjGameDataUIData_4() const { return ___shatranjGameDataUIData_4; }
	inline UIData_t2391886061 ** get_address_of_shatranjGameDataUIData_4() { return &___shatranjGameDataUIData_4; }
	inline void set_shatranjGameDataUIData_4(UIData_t2391886061 * value)
	{
		___shatranjGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t2538629501, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t3167441972 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t3167441972 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t3167441972 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
