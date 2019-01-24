#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameType/Score
struct  Score_t1751330547  : public Il2CppObject
{
public:
	// System.Int32 GameType/Score::playerIndex
	int32_t ___playerIndex_0;
	// System.Single GameType/Score::score
	float ___score_1;

public:
	inline static int32_t get_offset_of_playerIndex_0() { return static_cast<int32_t>(offsetof(Score_t1751330547, ___playerIndex_0)); }
	inline int32_t get_playerIndex_0() const { return ___playerIndex_0; }
	inline int32_t* get_address_of_playerIndex_0() { return &___playerIndex_0; }
	inline void set_playerIndex_0(int32_t value)
	{
		___playerIndex_0 = value;
	}

	inline static int32_t get_offset_of_score_1() { return static_cast<int32_t>(offsetof(Score_t1751330547, ___score_1)); }
	inline float get_score_1() const { return ___score_1; }
	inline float* get_address_of_score_1() { return &___score_1; }
	inline void set_score_1(float value)
	{
		___score_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
