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
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.PlayerTime
struct  PlayerTime_t389697442  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> TimeControl.HourGlass.PlayerTime::playerIndex
	VP_1_t2450154454 * ___playerIndex_7;
	// VP`1<System.Single> TimeControl.HourGlass.PlayerTime::serverTime
	VP_1_t2454786938 * ___serverTime_8;
	// VP`1<System.Single> TimeControl.HourGlass.PlayerTime::clientTime
	VP_1_t2454786938 * ___clientTime_9;
	// VP`1<System.Single> TimeControl.HourGlass.PlayerTime::lagCompensation
	VP_1_t2454786938 * ___lagCompensation_10;

public:
	inline static int32_t get_offset_of_playerIndex_7() { return static_cast<int32_t>(offsetof(PlayerTime_t389697442, ___playerIndex_7)); }
	inline VP_1_t2450154454 * get_playerIndex_7() const { return ___playerIndex_7; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_7() { return &___playerIndex_7; }
	inline void set_playerIndex_7(VP_1_t2450154454 * value)
	{
		___playerIndex_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_7, value);
	}

	inline static int32_t get_offset_of_serverTime_8() { return static_cast<int32_t>(offsetof(PlayerTime_t389697442, ___serverTime_8)); }
	inline VP_1_t2454786938 * get_serverTime_8() const { return ___serverTime_8; }
	inline VP_1_t2454786938 ** get_address_of_serverTime_8() { return &___serverTime_8; }
	inline void set_serverTime_8(VP_1_t2454786938 * value)
	{
		___serverTime_8 = value;
		Il2CppCodeGenWriteBarrier(&___serverTime_8, value);
	}

	inline static int32_t get_offset_of_clientTime_9() { return static_cast<int32_t>(offsetof(PlayerTime_t389697442, ___clientTime_9)); }
	inline VP_1_t2454786938 * get_clientTime_9() const { return ___clientTime_9; }
	inline VP_1_t2454786938 ** get_address_of_clientTime_9() { return &___clientTime_9; }
	inline void set_clientTime_9(VP_1_t2454786938 * value)
	{
		___clientTime_9 = value;
		Il2CppCodeGenWriteBarrier(&___clientTime_9, value);
	}

	inline static int32_t get_offset_of_lagCompensation_10() { return static_cast<int32_t>(offsetof(PlayerTime_t389697442, ___lagCompensation_10)); }
	inline VP_1_t2454786938 * get_lagCompensation_10() const { return ___lagCompensation_10; }
	inline VP_1_t2454786938 ** get_address_of_lagCompensation_10() { return &___lagCompensation_10; }
	inline void set_lagCompensation_10(VP_1_t2454786938 * value)
	{
		___lagCompensation_10 = value;
		Il2CppCodeGenWriteBarrier(&___lagCompensation_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
