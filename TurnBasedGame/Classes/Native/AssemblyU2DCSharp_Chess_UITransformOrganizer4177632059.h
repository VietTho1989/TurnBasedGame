#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen506073310.h"

// Chess.ChessGameDataUI/UIData
struct UIData_t3548078401;
// GameDataBoardCheckTransformChange`1<Chess.UITransformOrganizer/UpdateData>
struct GameDataBoardCheckTransformChange_1_t3576123817;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UITransformOrganizer
struct  UITransformOrganizer_t4177632059  : public UpdateBehavior_1_t506073310
{
public:
	// Chess.ChessGameDataUI/UIData Chess.UITransformOrganizer::chessGameDataUIData
	UIData_t3548078401 * ___chessGameDataUIData_4;
	// GameDataBoardCheckTransformChange`1<Chess.UITransformOrganizer/UpdateData> Chess.UITransformOrganizer::gameDataBoardCheckTransformChange
	GameDataBoardCheckTransformChange_1_t3576123817 * ___gameDataBoardCheckTransformChange_5;

public:
	inline static int32_t get_offset_of_chessGameDataUIData_4() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t4177632059, ___chessGameDataUIData_4)); }
	inline UIData_t3548078401 * get_chessGameDataUIData_4() const { return ___chessGameDataUIData_4; }
	inline UIData_t3548078401 ** get_address_of_chessGameDataUIData_4() { return &___chessGameDataUIData_4; }
	inline void set_chessGameDataUIData_4(UIData_t3548078401 * value)
	{
		___chessGameDataUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___chessGameDataUIData_4, value);
	}

	inline static int32_t get_offset_of_gameDataBoardCheckTransformChange_5() { return static_cast<int32_t>(offsetof(UITransformOrganizer_t4177632059, ___gameDataBoardCheckTransformChange_5)); }
	inline GameDataBoardCheckTransformChange_1_t3576123817 * get_gameDataBoardCheckTransformChange_5() const { return ___gameDataBoardCheckTransformChange_5; }
	inline GameDataBoardCheckTransformChange_1_t3576123817 ** get_address_of_gameDataBoardCheckTransformChange_5() { return &___gameDataBoardCheckTransformChange_5; }
	inline void set_gameDataBoardCheckTransformChange_5(GameDataBoardCheckTransformChange_1_t3576123817 * value)
	{
		___gameDataBoardCheckTransformChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardCheckTransformChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
