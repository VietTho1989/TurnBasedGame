#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<InputData>
struct NetData_1_t859716837;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InputDataIdentity
struct  InputDataIdentity_t56036326  : public DataIdentity_t543951486
{
public:
	// System.UInt32 InputDataIdentity::userSend
	uint32_t ___userSend_17;
	// System.Single InputDataIdentity::serverTime
	float ___serverTime_18;
	// System.Single InputDataIdentity::clientTime
	float ___clientTime_19;
	// NetData`1<InputData> InputDataIdentity::netData
	NetData_1_t859716837 * ___netData_20;

public:
	inline static int32_t get_offset_of_userSend_17() { return static_cast<int32_t>(offsetof(InputDataIdentity_t56036326, ___userSend_17)); }
	inline uint32_t get_userSend_17() const { return ___userSend_17; }
	inline uint32_t* get_address_of_userSend_17() { return &___userSend_17; }
	inline void set_userSend_17(uint32_t value)
	{
		___userSend_17 = value;
	}

	inline static int32_t get_offset_of_serverTime_18() { return static_cast<int32_t>(offsetof(InputDataIdentity_t56036326, ___serverTime_18)); }
	inline float get_serverTime_18() const { return ___serverTime_18; }
	inline float* get_address_of_serverTime_18() { return &___serverTime_18; }
	inline void set_serverTime_18(float value)
	{
		___serverTime_18 = value;
	}

	inline static int32_t get_offset_of_clientTime_19() { return static_cast<int32_t>(offsetof(InputDataIdentity_t56036326, ___clientTime_19)); }
	inline float get_clientTime_19() const { return ___clientTime_19; }
	inline float* get_address_of_clientTime_19() { return &___clientTime_19; }
	inline void set_clientTime_19(float value)
	{
		___clientTime_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(InputDataIdentity_t56036326, ___netData_20)); }
	inline NetData_1_t859716837 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t859716837 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t859716837 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
