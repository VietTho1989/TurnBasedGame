#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Facebook_Unity_Example_ConsoleBa4290192428.h"

// System.String
struct String_t;
// System.Collections.Generic.IList`1<System.String>
struct IList_1_t2570160834;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Example.LogView
struct  LogView_t3192394209  : public ConsoleBase_t4290192428
{
public:

public:
};

struct LogView_t3192394209_StaticFields
{
public:
	// System.String Facebook.Unity.Example.LogView::datePatt
	String_t* ___datePatt_13;
	// System.Collections.Generic.IList`1<System.String> Facebook.Unity.Example.LogView::events
	Il2CppObject* ___events_14;

public:
	inline static int32_t get_offset_of_datePatt_13() { return static_cast<int32_t>(offsetof(LogView_t3192394209_StaticFields, ___datePatt_13)); }
	inline String_t* get_datePatt_13() const { return ___datePatt_13; }
	inline String_t** get_address_of_datePatt_13() { return &___datePatt_13; }
	inline void set_datePatt_13(String_t* value)
	{
		___datePatt_13 = value;
		Il2CppCodeGenWriteBarrier(&___datePatt_13, value);
	}

	inline static int32_t get_offset_of_events_14() { return static_cast<int32_t>(offsetof(LogView_t3192394209_StaticFields, ___events_14)); }
	inline Il2CppObject* get_events_14() const { return ___events_14; }
	inline Il2CppObject** get_address_of_events_14() { return &___events_14; }
	inline void set_events_14(Il2CppObject* value)
	{
		___events_14 = value;
		Il2CppCodeGenWriteBarrier(&___events_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
