#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_TimeSpan3430258949.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Caching.HTTPCacheMaintananceParams
struct  HTTPCacheMaintananceParams_t558833957  : public Il2CppObject
{
public:
	// System.TimeSpan BestHTTP.Caching.HTTPCacheMaintananceParams::<DeleteOlder>k__BackingField
	TimeSpan_t3430258949  ___U3CDeleteOlderU3Ek__BackingField_0;
	// System.UInt64 BestHTTP.Caching.HTTPCacheMaintananceParams::<MaxCacheSize>k__BackingField
	uint64_t ___U3CMaxCacheSizeU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CDeleteOlderU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(HTTPCacheMaintananceParams_t558833957, ___U3CDeleteOlderU3Ek__BackingField_0)); }
	inline TimeSpan_t3430258949  get_U3CDeleteOlderU3Ek__BackingField_0() const { return ___U3CDeleteOlderU3Ek__BackingField_0; }
	inline TimeSpan_t3430258949 * get_address_of_U3CDeleteOlderU3Ek__BackingField_0() { return &___U3CDeleteOlderU3Ek__BackingField_0; }
	inline void set_U3CDeleteOlderU3Ek__BackingField_0(TimeSpan_t3430258949  value)
	{
		___U3CDeleteOlderU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CMaxCacheSizeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(HTTPCacheMaintananceParams_t558833957, ___U3CMaxCacheSizeU3Ek__BackingField_1)); }
	inline uint64_t get_U3CMaxCacheSizeU3Ek__BackingField_1() const { return ___U3CMaxCacheSizeU3Ek__BackingField_1; }
	inline uint64_t* get_address_of_U3CMaxCacheSizeU3Ek__BackingField_1() { return &___U3CMaxCacheSizeU3Ek__BackingField_1; }
	inline void set_U3CMaxCacheSizeU3Ek__BackingField_1(uint64_t value)
	{
		___U3CMaxCacheSizeU3Ek__BackingField_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
