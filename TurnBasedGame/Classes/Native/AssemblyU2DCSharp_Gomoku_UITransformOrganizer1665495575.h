#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen945112912.h"

// Gomoku.GomokuGameDataUI/UIData
struct UIData_t2272016985;
// GameDataBoardCheckTransformChange`1<Gomoku.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t4015163419;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.UITransformOrganizer
struct  UITransformOrganizer_t1665495575  : public UpdateBehavior_1_t945112912
{
public:
	// Gomoku.GomokuGameDataUI/UIData Gomoku.UITransformOrganizer::gomokuGameDataUIData
	UIData_t2272016985 * ___gomokuGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Gomoku.UITransformOrganizer/UpdateData> Gomoku.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t4015163419 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_gomokuGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t1665495575, ___gomokuGameDataUIData_4)); }
	inline UIData_t2272016985 * get_gomokuGameDataUIData_4() const { return ___gomokuGameDataUIData_4; }
	inline UIData_t2272016985 ** get_address_of_gomokuGameDataUIData_4() { return &___gomokuGameDataUIData_4; }
	inline void set_gomokuGameDataUIData_4(UIData_t2272016985 * value)
	{
		___gomokuGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t1665495575, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t4015163419 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t4015163419 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t4015163419 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
