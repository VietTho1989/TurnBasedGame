#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen4268855345.h"

// Xiangqi.XiangqiGameDataUI/UIData
struct UIData_t2895034497;
// GameDataBoardCheckTransformChange`1<Xiangqi.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t3043938556;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UITransformOrganizer
struct  UITransformOrganizer_t312609281  : public UpdateBehavior_1_t4268855345
{
public:
	// Xiangqi.XiangqiGameDataUI/UIData Xiangqi.UITransformOrganizer::xiangqiGameDataUIData
	UIData_t2895034497 * ___xiangqiGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Xiangqi.UITransformOrganizer/UpdateData> Xiangqi.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t3043938556 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_xiangqiGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t312609281, ___xiangqiGameDataUIData_4)); }
	inline UIData_t2895034497 * get_xiangqiGameDataUIData_4() const { return ___xiangqiGameDataUIData_4; }
	inline UIData_t2895034497 ** get_address_of_xiangqiGameDataUIData_4() { return &___xiangqiGameDataUIData_4; }
	inline void set_xiangqiGameDataUIData_4(UIData_t2895034497 * value)
	{
		___xiangqiGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t312609281, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t3043938556 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t3043938556 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t3043938556 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
