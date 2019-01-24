#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<WaitAIInput>
struct NetData_1_t717571224;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInputIdentity
struct  WaitAIInputIdentity_t1151487549  : public DataIdentity_t543951486
{
public:
	// System.UInt32 WaitAIInputIdentity::userThink
	uint32_t ___userThink_17;
	// System.UInt32 WaitAIInputIdentity::rethink
	uint32_t ___rethink_18;
	// NetData`1<WaitAIInput> WaitAIInputIdentity::netData
	NetData_1_t717571224 * ___netData_19;

public:
	inline static int32_t get_offset_of_userThink_17() { return static_cast<int32_t>(offsetof(WaitAIInputIdentity_t1151487549, ___userThink_17)); }
	inline uint32_t get_userThink_17() const { return ___userThink_17; }
	inline uint32_t* get_address_of_userThink_17() { return &___userThink_17; }
	inline void set_userThink_17(uint32_t value)
	{
		___userThink_17 = value;
	}

	inline static int32_t get_offset_of_rethink_18() { return static_cast<int32_t>(offsetof(WaitAIInputIdentity_t1151487549, ___rethink_18)); }
	inline uint32_t get_rethink_18() const { return ___rethink_18; }
	inline uint32_t* get_address_of_rethink_18() { return &___rethink_18; }
	inline void set_rethink_18(uint32_t value)
	{
		___rethink_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(WaitAIInputIdentity_t1151487549, ___netData_19)); }
	inline NetData_1_t717571224 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t717571224 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t717571224 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
