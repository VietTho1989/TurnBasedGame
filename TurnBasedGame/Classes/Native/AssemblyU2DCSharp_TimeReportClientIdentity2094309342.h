#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<TimeReportClient>
struct NetData_1_t2155906321;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeReportClientIdentity
struct  TimeReportClientIdentity_t2094309342  : public DataIdentity_t543951486
{
public:
	// System.UInt32 TimeReportClientIdentity::userId
	uint32_t ___userId_17;
	// System.Single TimeReportClientIdentity::delta
	float ___delta_18;
	// System.Single TimeReportClientIdentity::reportTime
	float ___reportTime_19;
	// NetData`1<TimeReportClient> TimeReportClientIdentity::netData
	NetData_1_t2155906321 * ___netData_20;

public:
	inline static int32_t get_offset_of_userId_17() { return static_cast<int32_t>(offsetof(TimeReportClientIdentity_t2094309342, ___userId_17)); }
	inline uint32_t get_userId_17() const { return ___userId_17; }
	inline uint32_t* get_address_of_userId_17() { return &___userId_17; }
	inline void set_userId_17(uint32_t value)
	{
		___userId_17 = value;
	}

	inline static int32_t get_offset_of_delta_18() { return static_cast<int32_t>(offsetof(TimeReportClientIdentity_t2094309342, ___delta_18)); }
	inline float get_delta_18() const { return ___delta_18; }
	inline float* get_address_of_delta_18() { return &___delta_18; }
	inline void set_delta_18(float value)
	{
		___delta_18 = value;
	}

	inline static int32_t get_offset_of_reportTime_19() { return static_cast<int32_t>(offsetof(TimeReportClientIdentity_t2094309342, ___reportTime_19)); }
	inline float get_reportTime_19() const { return ___reportTime_19; }
	inline float* get_address_of_reportTime_19() { return &___reportTime_19; }
	inline void set_reportTime_19(float value)
	{
		___reportTime_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(TimeReportClientIdentity_t2094309342, ___netData_20)); }
	inline NetData_1_t2155906321 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t2155906321 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t2155906321 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
