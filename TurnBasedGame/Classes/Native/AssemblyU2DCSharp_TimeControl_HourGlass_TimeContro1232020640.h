#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<TimeControl.HourGlass.TimeControlHourGlass>
struct NetData_1_t4098304347;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.TimeControlHourGlassIdentity
struct  TimeControlHourGlassIdentity_t1232020640  : public DataIdentity_t543951486
{
public:
	// System.Single TimeControl.HourGlass.TimeControlHourGlassIdentity::initTime
	float ___initTime_17;
	// System.Single TimeControl.HourGlass.TimeControlHourGlassIdentity::lagCompensation
	float ___lagCompensation_18;
	// NetData`1<TimeControl.HourGlass.TimeControlHourGlass> TimeControl.HourGlass.TimeControlHourGlassIdentity::netData
	NetData_1_t4098304347 * ___netData_19;

public:
	inline static int32_t get_offset_of_initTime_17() { return static_cast<int32_t>(offsetof(TimeControlHourGlassIdentity_t1232020640, ___initTime_17)); }
	inline float get_initTime_17() const { return ___initTime_17; }
	inline float* get_address_of_initTime_17() { return &___initTime_17; }
	inline void set_initTime_17(float value)
	{
		___initTime_17 = value;
	}

	inline static int32_t get_offset_of_lagCompensation_18() { return static_cast<int32_t>(offsetof(TimeControlHourGlassIdentity_t1232020640, ___lagCompensation_18)); }
	inline float get_lagCompensation_18() const { return ___lagCompensation_18; }
	inline float* get_address_of_lagCompensation_18() { return &___lagCompensation_18; }
	inline void set_lagCompensation_18(float value)
	{
		___lagCompensation_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(TimeControlHourGlassIdentity_t1232020640, ___netData_19)); }
	inline NetData_1_t4098304347 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t4098304347 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t4098304347 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
