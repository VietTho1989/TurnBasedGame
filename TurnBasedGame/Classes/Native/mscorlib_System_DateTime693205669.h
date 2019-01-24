#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "mscorlib_System_TimeSpan3430258949.h"
#include "mscorlib_System_DateTimeKind2186819611.h"
#include "mscorlib_System_DateTime693205669.h"

// System.String
struct String_t;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.DateTime
struct  DateTime_t693205669 
{
public:
	// System.TimeSpan System.DateTime::ticks
	TimeSpan_t3430258949  ___ticks_10;
	// System.DateTimeKind System.DateTime::kind
	int32_t ___kind_11;

public:
	inline static int32_t get_offset_of_ticks_10() { return static_cast<int32_t>(offsetof(DateTime_t693205669, ___ticks_10)); }
	inline TimeSpan_t3430258949  get_ticks_10() const { return ___ticks_10; }
	inline TimeSpan_t3430258949 * get_address_of_ticks_10() { return &___ticks_10; }
	inline void set_ticks_10(TimeSpan_t3430258949  value)
	{
		___ticks_10 = value;
	}

	inline static int32_t get_offset_of_kind_11() { return static_cast<int32_t>(offsetof(DateTime_t693205669, ___kind_11)); }
	inline int32_t get_kind_11() const { return ___kind_11; }
	inline int32_t* get_address_of_kind_11() { return &___kind_11; }
	inline void set_kind_11(int32_t value)
	{
		___kind_11 = value;
	}
};

struct DateTime_t693205669_StaticFields
{
public:
	// System.DateTime System.DateTime::MaxValue
	DateTime_t693205669  ___MaxValue_12;
	// System.DateTime System.DateTime::MinValue
	DateTime_t693205669  ___MinValue_13;
	// System.String[] System.DateTime::ParseTimeFormats
	StringU5BU5D_t1642385972* ___ParseTimeFormats_14;
	// System.String[] System.DateTime::ParseYearDayMonthFormats
	StringU5BU5D_t1642385972* ___ParseYearDayMonthFormats_15;
	// System.String[] System.DateTime::ParseYearMonthDayFormats
	StringU5BU5D_t1642385972* ___ParseYearMonthDayFormats_16;
	// System.String[] System.DateTime::ParseDayMonthYearFormats
	StringU5BU5D_t1642385972* ___ParseDayMonthYearFormats_17;
	// System.String[] System.DateTime::ParseMonthDayYearFormats
	StringU5BU5D_t1642385972* ___ParseMonthDayYearFormats_18;
	// System.String[] System.DateTime::MonthDayShortFormats
	StringU5BU5D_t1642385972* ___MonthDayShortFormats_19;
	// System.String[] System.DateTime::DayMonthShortFormats
	StringU5BU5D_t1642385972* ___DayMonthShortFormats_20;
	// System.Int32[] System.DateTime::daysmonth
	Int32U5BU5D_t3030399641* ___daysmonth_21;
	// System.Int32[] System.DateTime::daysmonthleap
	Int32U5BU5D_t3030399641* ___daysmonthleap_22;
	// System.Object System.DateTime::to_local_time_span_object
	Il2CppObject * ___to_local_time_span_object_23;
	// System.Int64 System.DateTime::last_now
	int64_t ___last_now_24;

public:
	inline static int32_t get_offset_of_MaxValue_12() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___MaxValue_12)); }
	inline DateTime_t693205669  get_MaxValue_12() const { return ___MaxValue_12; }
	inline DateTime_t693205669 * get_address_of_MaxValue_12() { return &___MaxValue_12; }
	inline void set_MaxValue_12(DateTime_t693205669  value)
	{
		___MaxValue_12 = value;
	}

	inline static int32_t get_offset_of_MinValue_13() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___MinValue_13)); }
	inline DateTime_t693205669  get_MinValue_13() const { return ___MinValue_13; }
	inline DateTime_t693205669 * get_address_of_MinValue_13() { return &___MinValue_13; }
	inline void set_MinValue_13(DateTime_t693205669  value)
	{
		___MinValue_13 = value;
	}

	inline static int32_t get_offset_of_ParseTimeFormats_14() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___ParseTimeFormats_14)); }
	inline StringU5BU5D_t1642385972* get_ParseTimeFormats_14() const { return ___ParseTimeFormats_14; }
	inline StringU5BU5D_t1642385972** get_address_of_ParseTimeFormats_14() { return &___ParseTimeFormats_14; }
	inline void set_ParseTimeFormats_14(StringU5BU5D_t1642385972* value)
	{
		___ParseTimeFormats_14 = value;
		Il2CppCodeGenWriteBarrier(&___ParseTimeFormats_14, value);
	}

	inline static int32_t get_offset_of_ParseYearDayMonthFormats_15() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___ParseYearDayMonthFormats_15)); }
	inline StringU5BU5D_t1642385972* get_ParseYearDayMonthFormats_15() const { return ___ParseYearDayMonthFormats_15; }
	inline StringU5BU5D_t1642385972** get_address_of_ParseYearDayMonthFormats_15() { return &___ParseYearDayMonthFormats_15; }
	inline void set_ParseYearDayMonthFormats_15(StringU5BU5D_t1642385972* value)
	{
		___ParseYearDayMonthFormats_15 = value;
		Il2CppCodeGenWriteBarrier(&___ParseYearDayMonthFormats_15, value);
	}

	inline static int32_t get_offset_of_ParseYearMonthDayFormats_16() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___ParseYearMonthDayFormats_16)); }
	inline StringU5BU5D_t1642385972* get_ParseYearMonthDayFormats_16() const { return ___ParseYearMonthDayFormats_16; }
	inline StringU5BU5D_t1642385972** get_address_of_ParseYearMonthDayFormats_16() { return &___ParseYearMonthDayFormats_16; }
	inline void set_ParseYearMonthDayFormats_16(StringU5BU5D_t1642385972* value)
	{
		___ParseYearMonthDayFormats_16 = value;
		Il2CppCodeGenWriteBarrier(&___ParseYearMonthDayFormats_16, value);
	}

	inline static int32_t get_offset_of_ParseDayMonthYearFormats_17() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___ParseDayMonthYearFormats_17)); }
	inline StringU5BU5D_t1642385972* get_ParseDayMonthYearFormats_17() const { return ___ParseDayMonthYearFormats_17; }
	inline StringU5BU5D_t1642385972** get_address_of_ParseDayMonthYearFormats_17() { return &___ParseDayMonthYearFormats_17; }
	inline void set_ParseDayMonthYearFormats_17(StringU5BU5D_t1642385972* value)
	{
		___ParseDayMonthYearFormats_17 = value;
		Il2CppCodeGenWriteBarrier(&___ParseDayMonthYearFormats_17, value);
	}

	inline static int32_t get_offset_of_ParseMonthDayYearFormats_18() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___ParseMonthDayYearFormats_18)); }
	inline StringU5BU5D_t1642385972* get_ParseMonthDayYearFormats_18() const { return ___ParseMonthDayYearFormats_18; }
	inline StringU5BU5D_t1642385972** get_address_of_ParseMonthDayYearFormats_18() { return &___ParseMonthDayYearFormats_18; }
	inline void set_ParseMonthDayYearFormats_18(StringU5BU5D_t1642385972* value)
	{
		___ParseMonthDayYearFormats_18 = value;
		Il2CppCodeGenWriteBarrier(&___ParseMonthDayYearFormats_18, value);
	}

	inline static int32_t get_offset_of_MonthDayShortFormats_19() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___MonthDayShortFormats_19)); }
	inline StringU5BU5D_t1642385972* get_MonthDayShortFormats_19() const { return ___MonthDayShortFormats_19; }
	inline StringU5BU5D_t1642385972** get_address_of_MonthDayShortFormats_19() { return &___MonthDayShortFormats_19; }
	inline void set_MonthDayShortFormats_19(StringU5BU5D_t1642385972* value)
	{
		___MonthDayShortFormats_19 = value;
		Il2CppCodeGenWriteBarrier(&___MonthDayShortFormats_19, value);
	}

	inline static int32_t get_offset_of_DayMonthShortFormats_20() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___DayMonthShortFormats_20)); }
	inline StringU5BU5D_t1642385972* get_DayMonthShortFormats_20() const { return ___DayMonthShortFormats_20; }
	inline StringU5BU5D_t1642385972** get_address_of_DayMonthShortFormats_20() { return &___DayMonthShortFormats_20; }
	inline void set_DayMonthShortFormats_20(StringU5BU5D_t1642385972* value)
	{
		___DayMonthShortFormats_20 = value;
		Il2CppCodeGenWriteBarrier(&___DayMonthShortFormats_20, value);
	}

	inline static int32_t get_offset_of_daysmonth_21() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___daysmonth_21)); }
	inline Int32U5BU5D_t3030399641* get_daysmonth_21() const { return ___daysmonth_21; }
	inline Int32U5BU5D_t3030399641** get_address_of_daysmonth_21() { return &___daysmonth_21; }
	inline void set_daysmonth_21(Int32U5BU5D_t3030399641* value)
	{
		___daysmonth_21 = value;
		Il2CppCodeGenWriteBarrier(&___daysmonth_21, value);
	}

	inline static int32_t get_offset_of_daysmonthleap_22() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___daysmonthleap_22)); }
	inline Int32U5BU5D_t3030399641* get_daysmonthleap_22() const { return ___daysmonthleap_22; }
	inline Int32U5BU5D_t3030399641** get_address_of_daysmonthleap_22() { return &___daysmonthleap_22; }
	inline void set_daysmonthleap_22(Int32U5BU5D_t3030399641* value)
	{
		___daysmonthleap_22 = value;
		Il2CppCodeGenWriteBarrier(&___daysmonthleap_22, value);
	}

	inline static int32_t get_offset_of_to_local_time_span_object_23() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___to_local_time_span_object_23)); }
	inline Il2CppObject * get_to_local_time_span_object_23() const { return ___to_local_time_span_object_23; }
	inline Il2CppObject ** get_address_of_to_local_time_span_object_23() { return &___to_local_time_span_object_23; }
	inline void set_to_local_time_span_object_23(Il2CppObject * value)
	{
		___to_local_time_span_object_23 = value;
		Il2CppCodeGenWriteBarrier(&___to_local_time_span_object_23, value);
	}

	inline static int32_t get_offset_of_last_now_24() { return static_cast<int32_t>(offsetof(DateTime_t693205669_StaticFields, ___last_now_24)); }
	inline int64_t get_last_now_24() const { return ___last_now_24; }
	inline int64_t* get_address_of_last_now_24() { return &___last_now_24; }
	inline void set_last_now_24(int64_t value)
	{
		___last_now_24 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
