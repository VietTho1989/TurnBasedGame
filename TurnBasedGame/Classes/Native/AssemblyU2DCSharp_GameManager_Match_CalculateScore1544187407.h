#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_CalculateScore3035986930.h"

// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.CalculateScoreWinLoseDraw
struct  CalculateScoreWinLoseDraw_t1544187407  : public CalculateScore_t3035986930
{
public:
	// VP`1<System.Single> GameManager.Match.CalculateScoreWinLoseDraw::winScore
	VP_1_t2454786938 * ___winScore_5;
	// VP`1<System.Single> GameManager.Match.CalculateScoreWinLoseDraw::loseScore
	VP_1_t2454786938 * ___loseScore_6;
	// VP`1<System.Single> GameManager.Match.CalculateScoreWinLoseDraw::drawScore
	VP_1_t2454786938 * ___drawScore_7;

public:
	inline static int32_t get_offset_of_winScore_5() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDraw_t1544187407, ___winScore_5)); }
	inline VP_1_t2454786938 * get_winScore_5() const { return ___winScore_5; }
	inline VP_1_t2454786938 ** get_address_of_winScore_5() { return &___winScore_5; }
	inline void set_winScore_5(VP_1_t2454786938 * value)
	{
		___winScore_5 = value;
		Il2CppCodeGenWriteBarrier(&___winScore_5, value);
	}

	inline static int32_t get_offset_of_loseScore_6() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDraw_t1544187407, ___loseScore_6)); }
	inline VP_1_t2454786938 * get_loseScore_6() const { return ___loseScore_6; }
	inline VP_1_t2454786938 ** get_address_of_loseScore_6() { return &___loseScore_6; }
	inline void set_loseScore_6(VP_1_t2454786938 * value)
	{
		___loseScore_6 = value;
		Il2CppCodeGenWriteBarrier(&___loseScore_6, value);
	}

	inline static int32_t get_offset_of_drawScore_7() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDraw_t1544187407, ___drawScore_7)); }
	inline VP_1_t2454786938 * get_drawScore_7() const { return ___drawScore_7; }
	inline VP_1_t2454786938 ** get_address_of_drawScore_7() { return &___drawScore_7; }
	inline void set_drawScore_7(VP_1_t2454786938 * value)
	{
		___drawScore_7 = value;
		Il2CppCodeGenWriteBarrier(&___drawScore_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
