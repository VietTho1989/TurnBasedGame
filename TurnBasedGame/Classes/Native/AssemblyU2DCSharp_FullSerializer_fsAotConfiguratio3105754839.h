#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_FullSerializer_fsAotConfiguration611353360.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsAotConfiguration/Entry
struct  Entry_t3105754839 
{
public:
	// FullSerializer.fsAotConfiguration/AotState FullSerializer.fsAotConfiguration/Entry::State
	int32_t ___State_0;
	// System.String FullSerializer.fsAotConfiguration/Entry::FullTypeName
	String_t* ___FullTypeName_1;

public:
	inline static int32_t get_offset_of_State_0() { return static_cast<int32_t>(offsetof(Entry_t3105754839, ___State_0)); }
	inline int32_t get_State_0() const { return ___State_0; }
	inline int32_t* get_address_of_State_0() { return &___State_0; }
	inline void set_State_0(int32_t value)
	{
		___State_0 = value;
	}

	inline static int32_t get_offset_of_FullTypeName_1() { return static_cast<int32_t>(offsetof(Entry_t3105754839, ___FullTypeName_1)); }
	inline String_t* get_FullTypeName_1() const { return ___FullTypeName_1; }
	inline String_t** get_address_of_FullTypeName_1() { return &___FullTypeName_1; }
	inline void set_FullTypeName_1(String_t* value)
	{
		___FullTypeName_1 = value;
		Il2CppCodeGenWriteBarrier(&___FullTypeName_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of FullSerializer.fsAotConfiguration/Entry
struct Entry_t3105754839_marshaled_pinvoke
{
	int32_t ___State_0;
	char* ___FullTypeName_1;
};
// Native definition for COM marshalling of FullSerializer.fsAotConfiguration/Entry
struct Entry_t3105754839_marshaled_com
{
	int32_t ___State_0;
	Il2CppChar* ___FullTypeName_1;
};
