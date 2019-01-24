#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameMove>
struct VP_1_t2240176003;
// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InputData
struct  InputData_t613368312  : public Data_t3569509720
{
public:
	// VP`1<GameMove> InputData::gameMove
	VP_1_t2240176003 * ___gameMove_5;
	// VP`1<System.UInt32> InputData::userSend
	VP_1_t2527959027 * ___userSend_6;
	// VP`1<System.Single> InputData::serverTime
	VP_1_t2454786938 * ___serverTime_7;
	// VP`1<System.Single> InputData::clientTime
	VP_1_t2454786938 * ___clientTime_8;

public:
	inline static int32_t get_offset_of_gameMove_5() { return static_cast<int32_t>(offsetof(InputData_t613368312, ___gameMove_5)); }
	inline VP_1_t2240176003 * get_gameMove_5() const { return ___gameMove_5; }
	inline VP_1_t2240176003 ** get_address_of_gameMove_5() { return &___gameMove_5; }
	inline void set_gameMove_5(VP_1_t2240176003 * value)
	{
		___gameMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameMove_5, value);
	}

	inline static int32_t get_offset_of_userSend_6() { return static_cast<int32_t>(offsetof(InputData_t613368312, ___userSend_6)); }
	inline VP_1_t2527959027 * get_userSend_6() const { return ___userSend_6; }
	inline VP_1_t2527959027 ** get_address_of_userSend_6() { return &___userSend_6; }
	inline void set_userSend_6(VP_1_t2527959027 * value)
	{
		___userSend_6 = value;
		Il2CppCodeGenWriteBarrier(&___userSend_6, value);
	}

	inline static int32_t get_offset_of_serverTime_7() { return static_cast<int32_t>(offsetof(InputData_t613368312, ___serverTime_7)); }
	inline VP_1_t2454786938 * get_serverTime_7() const { return ___serverTime_7; }
	inline VP_1_t2454786938 ** get_address_of_serverTime_7() { return &___serverTime_7; }
	inline void set_serverTime_7(VP_1_t2454786938 * value)
	{
		___serverTime_7 = value;
		Il2CppCodeGenWriteBarrier(&___serverTime_7, value);
	}

	inline static int32_t get_offset_of_clientTime_8() { return static_cast<int32_t>(offsetof(InputData_t613368312, ___clientTime_8)); }
	inline VP_1_t2454786938 * get_clientTime_8() const { return ___clientTime_8; }
	inline VP_1_t2454786938 ** get_address_of_clientTime_8() { return &___clientTime_8; }
	inline void set_clientTime_8(VP_1_t2454786938 * value)
	{
		___clientTime_8 = value;
		Il2CppCodeGenWriteBarrier(&___clientTime_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
