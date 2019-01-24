#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.RequestNewContestManager/State>
struct VP_1_t2652686730;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewContestManager
struct  RequestNewContestManager_t1762177088  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.RequestNewContestManager/State> GameManager.Match.RequestNewContestManager::state
	VP_1_t2652686730 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(RequestNewContestManager_t1762177088, ___state_5)); }
	inline VP_1_t2652686730 * get_state_5() const { return ___state_5; }
	inline VP_1_t2652686730 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2652686730 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
