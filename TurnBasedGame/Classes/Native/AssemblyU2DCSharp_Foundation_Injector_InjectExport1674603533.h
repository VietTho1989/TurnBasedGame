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
// System.Object
struct Il2CppObject;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Injector/InjectExport
struct  InjectExport_t1674603533  : public Il2CppObject
{
public:
	// System.Type Foundation.Injector/InjectExport::MemberType
	Type_t * ___MemberType_0;
	// System.Object Foundation.Injector/InjectExport::Instance
	Il2CppObject * ___Instance_1;
	// System.String Foundation.Injector/InjectExport::<InjectKey>k__BackingField
	String_t* ___U3CInjectKeyU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_MemberType_0() { return static_cast<int32_t>(offsetof(InjectExport_t1674603533, ___MemberType_0)); }
	inline Type_t * get_MemberType_0() const { return ___MemberType_0; }
	inline Type_t ** get_address_of_MemberType_0() { return &___MemberType_0; }
	inline void set_MemberType_0(Type_t * value)
	{
		___MemberType_0 = value;
		Il2CppCodeGenWriteBarrier(&___MemberType_0, value);
	}

	inline static int32_t get_offset_of_Instance_1() { return static_cast<int32_t>(offsetof(InjectExport_t1674603533, ___Instance_1)); }
	inline Il2CppObject * get_Instance_1() const { return ___Instance_1; }
	inline Il2CppObject ** get_address_of_Instance_1() { return &___Instance_1; }
	inline void set_Instance_1(Il2CppObject * value)
	{
		___Instance_1 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_1, value);
	}

	inline static int32_t get_offset_of_U3CInjectKeyU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(InjectExport_t1674603533, ___U3CInjectKeyU3Ek__BackingField_2)); }
	inline String_t* get_U3CInjectKeyU3Ek__BackingField_2() const { return ___U3CInjectKeyU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CInjectKeyU3Ek__BackingField_2() { return &___U3CInjectKeyU3Ek__BackingField_2; }
	inline void set_U3CInjectKeyU3Ek__BackingField_2(String_t* value)
	{
		___U3CInjectKeyU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CInjectKeyU3Ek__BackingField_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
