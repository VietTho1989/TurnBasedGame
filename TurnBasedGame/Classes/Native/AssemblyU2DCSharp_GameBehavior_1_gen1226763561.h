#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// LoginState.StepLogin
struct StepLogin_t3890517435;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameBehavior`1<LoginState.StepLogin>
struct  GameBehavior_1_t1226763561  : public MonoBehaviour_t1158329972
{
public:
	// K GameBehavior`1::data
	StepLogin_t3890517435 * ___data_2;

public:
	inline static int32_t get_offset_of_data_2() { return static_cast<int32_t>(offsetof(GameBehavior_1_t1226763561, ___data_2)); }
	inline StepLogin_t3890517435 * get_data_2() const { return ___data_2; }
	inline StepLogin_t3890517435 ** get_address_of_data_2() { return &___data_2; }
	inline void set_data_2(StepLogin_t3890517435 * value)
	{
		___data_2 = value;
		Il2CppCodeGenWriteBarrier(&___data_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
