#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsAotVersionInfo/Member
struct  Member_t459758263 
{
public:
	// System.String FullSerializer.fsAotVersionInfo/Member::MemberName
	String_t* ___MemberName_0;
	// System.String FullSerializer.fsAotVersionInfo/Member::JsonName
	String_t* ___JsonName_1;
	// System.String FullSerializer.fsAotVersionInfo/Member::StorageType
	String_t* ___StorageType_2;
	// System.String FullSerializer.fsAotVersionInfo/Member::OverrideConverterType
	String_t* ___OverrideConverterType_3;

public:
	inline static int32_t get_offset_of_MemberName_0() { return static_cast<int32_t>(offsetof(Member_t459758263, ___MemberName_0)); }
	inline String_t* get_MemberName_0() const { return ___MemberName_0; }
	inline String_t** get_address_of_MemberName_0() { return &___MemberName_0; }
	inline void set_MemberName_0(String_t* value)
	{
		___MemberName_0 = value;
		Il2CppCodeGenWriteBarrier(&___MemberName_0, value);
	}

	inline static int32_t get_offset_of_JsonName_1() { return static_cast<int32_t>(offsetof(Member_t459758263, ___JsonName_1)); }
	inline String_t* get_JsonName_1() const { return ___JsonName_1; }
	inline String_t** get_address_of_JsonName_1() { return &___JsonName_1; }
	inline void set_JsonName_1(String_t* value)
	{
		___JsonName_1 = value;
		Il2CppCodeGenWriteBarrier(&___JsonName_1, value);
	}

	inline static int32_t get_offset_of_StorageType_2() { return static_cast<int32_t>(offsetof(Member_t459758263, ___StorageType_2)); }
	inline String_t* get_StorageType_2() const { return ___StorageType_2; }
	inline String_t** get_address_of_StorageType_2() { return &___StorageType_2; }
	inline void set_StorageType_2(String_t* value)
	{
		___StorageType_2 = value;
		Il2CppCodeGenWriteBarrier(&___StorageType_2, value);
	}

	inline static int32_t get_offset_of_OverrideConverterType_3() { return static_cast<int32_t>(offsetof(Member_t459758263, ___OverrideConverterType_3)); }
	inline String_t* get_OverrideConverterType_3() const { return ___OverrideConverterType_3; }
	inline String_t** get_address_of_OverrideConverterType_3() { return &___OverrideConverterType_3; }
	inline void set_OverrideConverterType_3(String_t* value)
	{
		___OverrideConverterType_3 = value;
		Il2CppCodeGenWriteBarrier(&___OverrideConverterType_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of FullSerializer.fsAotVersionInfo/Member
struct Member_t459758263_marshaled_pinvoke
{
	char* ___MemberName_0;
	char* ___JsonName_1;
	char* ___StorageType_2;
	char* ___OverrideConverterType_3;
};
// Native definition for COM marshalling of FullSerializer.fsAotVersionInfo/Member
struct Member_t459758263_marshaled_com
{
	Il2CppChar* ___MemberName_0;
	Il2CppChar* ___JsonName_1;
	Il2CppChar* ___StorageType_2;
	Il2CppChar* ___OverrideConverterType_3;
};
