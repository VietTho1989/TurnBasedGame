#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.Authentication.Digest>
struct Dictionary_2_t1974178844;
// System.Object
struct Il2CppObject;
// System.String[]
struct StringU5BU5D_t1642385972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Authentication.DigestStore
struct  DigestStore_t674131537  : public Il2CppObject
{
public:

public:
};

struct DigestStore_t674131537_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.Authentication.Digest> BestHTTP.Authentication.DigestStore::Digests
	Dictionary_2_t1974178844 * ___Digests_0;
	// System.Object BestHTTP.Authentication.DigestStore::Locker
	Il2CppObject * ___Locker_1;
	// System.String[] BestHTTP.Authentication.DigestStore::SupportedAlgorithms
	StringU5BU5D_t1642385972* ___SupportedAlgorithms_2;

public:
	inline static int32_t get_offset_of_Digests_0() { return static_cast<int32_t>(offsetof(DigestStore_t674131537_StaticFields, ___Digests_0)); }
	inline Dictionary_2_t1974178844 * get_Digests_0() const { return ___Digests_0; }
	inline Dictionary_2_t1974178844 ** get_address_of_Digests_0() { return &___Digests_0; }
	inline void set_Digests_0(Dictionary_2_t1974178844 * value)
	{
		___Digests_0 = value;
		Il2CppCodeGenWriteBarrier(&___Digests_0, value);
	}

	inline static int32_t get_offset_of_Locker_1() { return static_cast<int32_t>(offsetof(DigestStore_t674131537_StaticFields, ___Locker_1)); }
	inline Il2CppObject * get_Locker_1() const { return ___Locker_1; }
	inline Il2CppObject ** get_address_of_Locker_1() { return &___Locker_1; }
	inline void set_Locker_1(Il2CppObject * value)
	{
		___Locker_1 = value;
		Il2CppCodeGenWriteBarrier(&___Locker_1, value);
	}

	inline static int32_t get_offset_of_SupportedAlgorithms_2() { return static_cast<int32_t>(offsetof(DigestStore_t674131537_StaticFields, ___SupportedAlgorithms_2)); }
	inline StringU5BU5D_t1642385972* get_SupportedAlgorithms_2() const { return ___SupportedAlgorithms_2; }
	inline StringU5BU5D_t1642385972** get_address_of_SupportedAlgorithms_2() { return &___SupportedAlgorithms_2; }
	inline void set_SupportedAlgorithms_2(StringU5BU5D_t1642385972* value)
	{
		___SupportedAlgorithms_2 = value;
		Il2CppCodeGenWriteBarrier(&___SupportedAlgorithms_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
