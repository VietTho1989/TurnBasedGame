#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<GameManager.Match.ContestManager/State>
struct VP_1_t3720897473;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManager
struct  ContestManager_t1690251033  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.ContestManager::index
	VP_1_t2450154454 * ___index_5;
	// VP`1<GameManager.Match.ContestManager/State> GameManager.Match.ContestManager::state
	VP_1_t3720897473 * ___state_6;

public:
	inline static int32_t get_offset_of_index_5() { return static_cast<int32_t>(offsetof(ContestManager_t1690251033, ___index_5)); }
	inline VP_1_t2450154454 * get_index_5() const { return ___index_5; }
	inline VP_1_t2450154454 ** get_address_of_index_5() { return &___index_5; }
	inline void set_index_5(VP_1_t2450154454 * value)
	{
		___index_5 = value;
		Il2CppCodeGenWriteBarrier(&___index_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(ContestManager_t1690251033, ___state_6)); }
	inline VP_1_t3720897473 * get_state_6() const { return ___state_6; }
	inline VP_1_t3720897473 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t3720897473 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
