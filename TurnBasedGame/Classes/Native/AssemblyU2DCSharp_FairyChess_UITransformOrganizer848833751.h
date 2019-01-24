#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1347269681.h"

// FairyChess.FairyChessGameDataUI/UIData
struct UIData_t3976046997;
// GameDataBoardCheckTransformChange`1<FairyChess.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t122352892;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UITransformOrganizer
struct  UITransformOrganizer_t848833751  : public UpdateBehavior_1_t1347269681
{
public:
	// FairyChess.FairyChessGameDataUI/UIData FairyChess.UITransformOrganizer::fairyChessGameDataUIData
	UIData_t3976046997 * ___fairyChessGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<FairyChess.UITransformOrganizer/UpdateData> FairyChess.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t122352892 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_fairyChessGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t848833751, ___fairyChessGameDataUIData_4)); }
	inline UIData_t3976046997 * get_fairyChessGameDataUIData_4() const { return ___fairyChessGameDataUIData_4; }
	inline UIData_t3976046997 ** get_address_of_fairyChessGameDataUIData_4() { return &___fairyChessGameDataUIData_4; }
	inline void set_fairyChessGameDataUIData_4(UIData_t3976046997 * value)
	{
		___fairyChessGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChessGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t848833751, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t122352892 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t122352892 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t122352892 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
