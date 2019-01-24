#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen277915616.h"

// MineSweeper.MineSweeperGameDataUI/UIData
struct UIData_t1952477953;
// GameDataBoardCheckTransformChange`1<MineSweeper.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t3347966123;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.UITransformOrganizer
struct  UITransformOrganizer_t4036211183  : public UpdateBehavior_1_t277915616
{
public:
	// MineSweeper.MineSweeperGameDataUI/UIData MineSweeper.UITransformOrganizer::mineSweeperGameDataUIData
	UIData_t1952477953 * ___mineSweeperGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<MineSweeper.UITransformOrganizer/UpdateData> MineSweeper.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t3347966123 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_mineSweeperGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t4036211183, ___mineSweeperGameDataUIData_4)); }
	inline UIData_t1952477953 * get_mineSweeperGameDataUIData_4() const { return ___mineSweeperGameDataUIData_4; }
	inline UIData_t1952477953 ** get_address_of_mineSweeperGameDataUIData_4() { return &___mineSweeperGameDataUIData_4; }
	inline void set_mineSweeperGameDataUIData_4(UIData_t1952477953 * value)
	{
		___mineSweeperGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t4036211183, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t3347966123 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t3347966123 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t3347966123 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
