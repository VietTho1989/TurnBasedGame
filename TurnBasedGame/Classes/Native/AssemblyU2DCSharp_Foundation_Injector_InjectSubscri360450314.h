#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// System.String
struct String_t;
// System.Reflection.MemberInfo
struct MemberInfo_t;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Injector/InjectSubscription
struct  InjectSubscription_t360450314  : public Il2CppObject
{
public:
	// System.Type Foundation.Injector/InjectSubscription::MemberType
	Type_t * ___MemberType_0;
	// System.String Foundation.Injector/InjectSubscription::<InjectKey>k__BackingField
	String_t* ___U3CInjectKeyU3Ek__BackingField_1;
	// System.Reflection.MemberInfo Foundation.Injector/InjectSubscription::Member
	MemberInfo_t * ___Member_2;
	// System.Object Foundation.Injector/InjectSubscription::Instance
	Il2CppObject * ___Instance_3;

public:
	inline static int32_t get_offset_of_MemberType_0() { return static_cast<int32_t>(offsetof(InjectSubscription_t360450314, ___MemberType_0)); }
	inline Type_t * get_MemberType_0() const { return ___MemberType_0; }
	inline Type_t ** get_address_of_MemberType_0() { return &___MemberType_0; }
	inline void set_MemberType_0(Type_t * value)
	{
		___MemberType_0 = value;
		Il2CppCodeGenWriteBarrier(&___MemberType_0, value);
	}

	inline static int32_t get_offset_of_U3CInjectKeyU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(InjectSubscription_t360450314, ___U3CInjectKeyU3Ek__BackingField_1)); }
	inline String_t* get_U3CInjectKeyU3Ek__BackingField_1() const { return ___U3CInjectKeyU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CInjectKeyU3Ek__BackingField_1() { return &___U3CInjectKeyU3Ek__BackingField_1; }
	inline void set_U3CInjectKeyU3Ek__BackingField_1(String_t* value)
	{
		___U3CInjectKeyU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CInjectKeyU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_Member_2() { return static_cast<int32_t>(offsetof(InjectSubscription_t360450314, ___Member_2)); }
	inline MemberInfo_t * get_Member_2() const { return ___Member_2; }
	inline MemberInfo_t ** get_address_of_Member_2() { return &___Member_2; }
	inline void set_Member_2(MemberInfo_t * value)
	{
		___Member_2 = value;
		Il2CppCodeGenWriteBarrier(&___Member_2, value);
	}

	inline static int32_t get_offset_of_Instance_3() { return static_cast<int32_t>(offsetof(InjectSubscription_t360450314, ___Instance_3)); }
	inline Il2CppObject * get_Instance_3() const { return ___Instance_3; }
	inline Il2CppObject ** get_address_of_Instance_3() { return &___Instance_3; }
	inline void set_Instance_3(Il2CppObject * value)
	{
		___Instance_3 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
