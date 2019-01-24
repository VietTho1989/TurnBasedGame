#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_FullSerializer_fsResult862419890.h"

// System.String[]
struct StringU5BU5D_t1642385972;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsResult
struct  fsResult_t862419890 
{
public:
	// System.Boolean FullSerializer.fsResult::_success
	bool ____success_1;
	// System.Collections.Generic.List`1<System.String> FullSerializer.fsResult::_messages
	List_1_t1398341365 * ____messages_2;

public:
	inline static int32_t get_offset_of__success_1() { return static_cast<int32_t>(offsetof(fsResult_t862419890, ____success_1)); }
	inline bool get__success_1() const { return ____success_1; }
	inline bool* get_address_of__success_1() { return &____success_1; }
	inline void set__success_1(bool value)
	{
		____success_1 = value;
	}

	inline static int32_t get_offset_of__messages_2() { return static_cast<int32_t>(offsetof(fsResult_t862419890, ____messages_2)); }
	inline List_1_t1398341365 * get__messages_2() const { return ____messages_2; }
	inline List_1_t1398341365 ** get_address_of__messages_2() { return &____messages_2; }
	inline void set__messages_2(List_1_t1398341365 * value)
	{
		____messages_2 = value;
		Il2CppCodeGenWriteBarrier(&____messages_2, value);
	}
};

struct fsResult_t862419890_StaticFields
{
public:
	// System.String[] FullSerializer.fsResult::EmptyStringArray
	StringU5BU5D_t1642385972* ___EmptyStringArray_0;
	// FullSerializer.fsResult FullSerializer.fsResult::Success
	fsResult_t862419890  ___Success_3;

public:
	inline static int32_t get_offset_of_EmptyStringArray_0() { return static_cast<int32_t>(offsetof(fsResult_t862419890_StaticFields, ___EmptyStringArray_0)); }
	inline StringU5BU5D_t1642385972* get_EmptyStringArray_0() const { return ___EmptyStringArray_0; }
	inline StringU5BU5D_t1642385972** get_address_of_EmptyStringArray_0() { return &___EmptyStringArray_0; }
	inline void set_EmptyStringArray_0(StringU5BU5D_t1642385972* value)
	{
		___EmptyStringArray_0 = value;
		Il2CppCodeGenWriteBarrier(&___EmptyStringArray_0, value);
	}

	inline static int32_t get_offset_of_Success_3() { return static_cast<int32_t>(offsetof(fsResult_t862419890_StaticFields, ___Success_3)); }
	inline fsResult_t862419890  get_Success_3() const { return ___Success_3; }
	inline fsResult_t862419890 * get_address_of_Success_3() { return &___Success_3; }
	inline void set_Success_3(fsResult_t862419890  value)
	{
		___Success_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of FullSerializer.fsResult
struct fsResult_t862419890_marshaled_pinvoke
{
	int32_t ____success_1;
	List_1_t1398341365 * ____messages_2;
};
// Native definition for COM marshalling of FullSerializer.fsResult
struct fsResult_t862419890_marshaled_com
{
	int32_t ____success_1;
	List_1_t1398341365 * ____messages_2;
};
