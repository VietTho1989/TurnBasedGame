#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Diagnostics_TraceListener3414949279.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Diagnostics.DefaultTraceListener
struct  DefaultTraceListener_t1568159610  : public TraceListener_t3414949279
{
public:
	// System.String System.Diagnostics.DefaultTraceListener::logFileName
	String_t* ___logFileName_10;
	// System.Boolean System.Diagnostics.DefaultTraceListener::assertUiEnabled
	bool ___assertUiEnabled_11;

public:
	inline static int32_t get_offset_of_logFileName_10() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610, ___logFileName_10)); }
	inline String_t* get_logFileName_10() const { return ___logFileName_10; }
	inline String_t** get_address_of_logFileName_10() { return &___logFileName_10; }
	inline void set_logFileName_10(String_t* value)
	{
		___logFileName_10 = value;
		Il2CppCodeGenWriteBarrier(&___logFileName_10, value);
	}

	inline static int32_t get_offset_of_assertUiEnabled_11() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610, ___assertUiEnabled_11)); }
	inline bool get_assertUiEnabled_11() const { return ___assertUiEnabled_11; }
	inline bool* get_address_of_assertUiEnabled_11() { return &___assertUiEnabled_11; }
	inline void set_assertUiEnabled_11(bool value)
	{
		___assertUiEnabled_11 = value;
	}
};

struct DefaultTraceListener_t1568159610_StaticFields
{
public:
	// System.Boolean System.Diagnostics.DefaultTraceListener::OnWin32
	bool ___OnWin32_7;
	// System.String System.Diagnostics.DefaultTraceListener::MonoTracePrefix
	String_t* ___MonoTracePrefix_8;
	// System.String System.Diagnostics.DefaultTraceListener::MonoTraceFile
	String_t* ___MonoTraceFile_9;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Diagnostics.DefaultTraceListener::<>f__switch$map3
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map3_12;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Diagnostics.DefaultTraceListener::<>f__switch$map4
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map4_13;

public:
	inline static int32_t get_offset_of_OnWin32_7() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610_StaticFields, ___OnWin32_7)); }
	inline bool get_OnWin32_7() const { return ___OnWin32_7; }
	inline bool* get_address_of_OnWin32_7() { return &___OnWin32_7; }
	inline void set_OnWin32_7(bool value)
	{
		___OnWin32_7 = value;
	}

	inline static int32_t get_offset_of_MonoTracePrefix_8() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610_StaticFields, ___MonoTracePrefix_8)); }
	inline String_t* get_MonoTracePrefix_8() const { return ___MonoTracePrefix_8; }
	inline String_t** get_address_of_MonoTracePrefix_8() { return &___MonoTracePrefix_8; }
	inline void set_MonoTracePrefix_8(String_t* value)
	{
		___MonoTracePrefix_8 = value;
		Il2CppCodeGenWriteBarrier(&___MonoTracePrefix_8, value);
	}

	inline static int32_t get_offset_of_MonoTraceFile_9() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610_StaticFields, ___MonoTraceFile_9)); }
	inline String_t* get_MonoTraceFile_9() const { return ___MonoTraceFile_9; }
	inline String_t** get_address_of_MonoTraceFile_9() { return &___MonoTraceFile_9; }
	inline void set_MonoTraceFile_9(String_t* value)
	{
		___MonoTraceFile_9 = value;
		Il2CppCodeGenWriteBarrier(&___MonoTraceFile_9, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map3_12() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610_StaticFields, ___U3CU3Ef__switchU24map3_12)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map3_12() const { return ___U3CU3Ef__switchU24map3_12; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map3_12() { return &___U3CU3Ef__switchU24map3_12; }
	inline void set_U3CU3Ef__switchU24map3_12(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map3_12 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map3_12, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map4_13() { return static_cast<int32_t>(offsetof(DefaultTraceListener_t1568159610_StaticFields, ___U3CU3Ef__switchU24map4_13)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map4_13() const { return ___U3CU3Ef__switchU24map4_13; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map4_13() { return &___U3CU3Ef__switchU24map4_13; }
	inline void set_U3CU3Ef__switchU24map4_13(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map4_13 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map4_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
