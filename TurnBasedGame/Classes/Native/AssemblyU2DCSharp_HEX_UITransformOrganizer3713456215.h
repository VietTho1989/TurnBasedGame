#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1878247211.h"

// HEX.HexGameDataUI/UIData
struct UIData_t3485590849;
// GameDataBoardCheckTransformChange`1<HEX.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t653330422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.UITransformOrganizer
struct  UITransformOrganizer_t3713456215  : public UpdateBehavior_1_t1878247211
{
public:
	// HEX.HexGameDataUI/UIData HEX.UITransformOrganizer::hexGameDataUIData
	UIData_t3485590849 * ___hexGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<HEX.UITransformOrganizer/UpdateData> HEX.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t653330422 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_hexGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t3713456215, ___hexGameDataUIData_4)); }
	inline UIData_t3485590849 * get_hexGameDataUIData_4() const { return ___hexGameDataUIData_4; }
	inline UIData_t3485590849 ** get_address_of_hexGameDataUIData_4() { return &___hexGameDataUIData_4; }
	inline void set_hexGameDataUIData_4(UIData_t3485590849 * value)
	{
		___hexGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___hexGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t3713456215, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t653330422 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t653330422 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t653330422 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
