#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String>
struct Dictionary_2_t4124789860;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics
struct  AdvancedCoroutinesStatistics_t1824772116  : public Il2CppObject
{
public:

public:
};

struct AdvancedCoroutinesStatistics_t1824772116_StaticFields
{
public:
	// System.Boolean AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::IsActive
	bool ___IsActive_0;
	// System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String> AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::_rouitinesStatistics
	Dictionary_2_t4124789860 * ____rouitinesStatistics_1;
	// System.Int32 AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::<TotalCoroutinesStarts>k__BackingField
	int32_t ___U3CTotalCoroutinesStartsU3Ek__BackingField_2;
	// System.Int32 AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::<TotalCoroutinesStops>k__BackingField
	int32_t ___U3CTotalCoroutinesStopsU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_IsActive_0() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_t1824772116_StaticFields, ___IsActive_0)); }
	inline bool get_IsActive_0() const { return ___IsActive_0; }
	inline bool* get_address_of_IsActive_0() { return &___IsActive_0; }
	inline void set_IsActive_0(bool value)
	{
		___IsActive_0 = value;
	}

	inline static int32_t get_offset_of__rouitinesStatistics_1() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_t1824772116_StaticFields, ____rouitinesStatistics_1)); }
	inline Dictionary_2_t4124789860 * get__rouitinesStatistics_1() const { return ____rouitinesStatistics_1; }
	inline Dictionary_2_t4124789860 ** get_address_of__rouitinesStatistics_1() { return &____rouitinesStatistics_1; }
	inline void set__rouitinesStatistics_1(Dictionary_2_t4124789860 * value)
	{
		____rouitinesStatistics_1 = value;
		Il2CppCodeGenWriteBarrier(&____rouitinesStatistics_1, value);
	}

	inline static int32_t get_offset_of_U3CTotalCoroutinesStartsU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_t1824772116_StaticFields, ___U3CTotalCoroutinesStartsU3Ek__BackingField_2)); }
	inline int32_t get_U3CTotalCoroutinesStartsU3Ek__BackingField_2() const { return ___U3CTotalCoroutinesStartsU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CTotalCoroutinesStartsU3Ek__BackingField_2() { return &___U3CTotalCoroutinesStartsU3Ek__BackingField_2; }
	inline void set_U3CTotalCoroutinesStartsU3Ek__BackingField_2(int32_t value)
	{
		___U3CTotalCoroutinesStartsU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CTotalCoroutinesStopsU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_t1824772116_StaticFields, ___U3CTotalCoroutinesStopsU3Ek__BackingField_3)); }
	inline int32_t get_U3CTotalCoroutinesStopsU3Ek__BackingField_3() const { return ___U3CTotalCoroutinesStopsU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CTotalCoroutinesStopsU3Ek__BackingField_3() { return &___U3CTotalCoroutinesStopsU3Ek__BackingField_3; }
	inline void set_U3CTotalCoroutinesStopsU3Ek__BackingField_3(int32_t value)
	{
		___U3CTotalCoroutinesStopsU3Ek__BackingField_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
