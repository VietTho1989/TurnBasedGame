#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Reflection.MemberInfo
struct MemberInfo_t;
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsPortableReflection/AttributeQuery
struct  AttributeQuery_t604298480 
{
public:
	// System.Reflection.MemberInfo FullSerializer.Internal.fsPortableReflection/AttributeQuery::MemberInfo
	MemberInfo_t * ___MemberInfo_0;
	// System.Type FullSerializer.Internal.fsPortableReflection/AttributeQuery::AttributeType
	Type_t * ___AttributeType_1;

public:
	inline static int32_t get_offset_of_MemberInfo_0() { return static_cast<int32_t>(offsetof(AttributeQuery_t604298480, ___MemberInfo_0)); }
	inline MemberInfo_t * get_MemberInfo_0() const { return ___MemberInfo_0; }
	inline MemberInfo_t ** get_address_of_MemberInfo_0() { return &___MemberInfo_0; }
	inline void set_MemberInfo_0(MemberInfo_t * value)
	{
		___MemberInfo_0 = value;
		Il2CppCodeGenWriteBarrier(&___MemberInfo_0, value);
	}

	inline static int32_t get_offset_of_AttributeType_1() { return static_cast<int32_t>(offsetof(AttributeQuery_t604298480, ___AttributeType_1)); }
	inline Type_t * get_AttributeType_1() const { return ___AttributeType_1; }
	inline Type_t ** get_address_of_AttributeType_1() { return &___AttributeType_1; }
	inline void set_AttributeType_1(Type_t * value)
	{
		___AttributeType_1 = value;
		Il2CppCodeGenWriteBarrier(&___AttributeType_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of FullSerializer.Internal.fsPortableReflection/AttributeQuery
struct AttributeQuery_t604298480_marshaled_pinvoke
{
	MemberInfo_t * ___MemberInfo_0;
	Type_t * ___AttributeType_1;
};
// Native definition for COM marshalling of FullSerializer.Internal.fsPortableReflection/AttributeQuery
struct AttributeQuery_t604298480_marshaled_com
{
	MemberInfo_t * ___MemberInfo_0;
	Type_t * ___AttributeType_1;
};
