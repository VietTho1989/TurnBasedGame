#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Typing>
struct NetData_1_t3923632736;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingIdentity
struct  TypingIdentity_t864184853  : public DataIdentity_t543951486
{
public:
	// System.Boolean TypingIdentity::isEnable
	bool ___isEnable_17;
	// System.Single TypingIdentity::nextReceiveTime
	float ___nextReceiveTime_18;
	// System.Single TypingIdentity::stopDuration
	float ___stopDuration_19;
	// NetData`1<Typing> TypingIdentity::netData
	NetData_1_t3923632736 * ___netData_20;

public:
	inline static int32_t get_offset_of_isEnable_17() { return static_cast<int32_t>(offsetof(TypingIdentity_t864184853, ___isEnable_17)); }
	inline bool get_isEnable_17() const { return ___isEnable_17; }
	inline bool* get_address_of_isEnable_17() { return &___isEnable_17; }
	inline void set_isEnable_17(bool value)
	{
		___isEnable_17 = value;
	}

	inline static int32_t get_offset_of_nextReceiveTime_18() { return static_cast<int32_t>(offsetof(TypingIdentity_t864184853, ___nextReceiveTime_18)); }
	inline float get_nextReceiveTime_18() const { return ___nextReceiveTime_18; }
	inline float* get_address_of_nextReceiveTime_18() { return &___nextReceiveTime_18; }
	inline void set_nextReceiveTime_18(float value)
	{
		___nextReceiveTime_18 = value;
	}

	inline static int32_t get_offset_of_stopDuration_19() { return static_cast<int32_t>(offsetof(TypingIdentity_t864184853, ___stopDuration_19)); }
	inline float get_stopDuration_19() const { return ___stopDuration_19; }
	inline float* get_address_of_stopDuration_19() { return &___stopDuration_19; }
	inline void set_stopDuration_19(float value)
	{
		___stopDuration_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(TypingIdentity_t864184853, ___netData_20)); }
	inline NetData_1_t3923632736 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3923632736 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3923632736 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
