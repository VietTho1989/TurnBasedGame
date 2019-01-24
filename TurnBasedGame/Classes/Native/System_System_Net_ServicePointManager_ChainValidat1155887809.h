#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Security_Cryptography_X509Certificat2461349531.h"

// System.Object
struct Il2CppObject;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.ServicePointManager/ChainValidationHelper
struct  ChainValidationHelper_t1155887809  : public Il2CppObject
{
public:
	// System.Object System.Net.ServicePointManager/ChainValidationHelper::sender
	Il2CppObject * ___sender_0;
	// System.String System.Net.ServicePointManager/ChainValidationHelper::host
	String_t* ___host_1;

public:
	inline static int32_t get_offset_of_sender_0() { return static_cast<int32_t>(offsetof(ChainValidationHelper_t1155887809, ___sender_0)); }
	inline Il2CppObject * get_sender_0() const { return ___sender_0; }
	inline Il2CppObject ** get_address_of_sender_0() { return &___sender_0; }
	inline void set_sender_0(Il2CppObject * value)
	{
		___sender_0 = value;
		Il2CppCodeGenWriteBarrier(&___sender_0, value);
	}

	inline static int32_t get_offset_of_host_1() { return static_cast<int32_t>(offsetof(ChainValidationHelper_t1155887809, ___host_1)); }
	inline String_t* get_host_1() const { return ___host_1; }
	inline String_t** get_address_of_host_1() { return &___host_1; }
	inline void set_host_1(String_t* value)
	{
		___host_1 = value;
		Il2CppCodeGenWriteBarrier(&___host_1, value);
	}
};

struct ChainValidationHelper_t1155887809_StaticFields
{
public:
	// System.Boolean System.Net.ServicePointManager/ChainValidationHelper::is_macosx
	bool ___is_macosx_2;
	// System.Security.Cryptography.X509Certificates.X509KeyUsageFlags System.Net.ServicePointManager/ChainValidationHelper::s_flags
	int32_t ___s_flags_3;

public:
	inline static int32_t get_offset_of_is_macosx_2() { return static_cast<int32_t>(offsetof(ChainValidationHelper_t1155887809_StaticFields, ___is_macosx_2)); }
	inline bool get_is_macosx_2() const { return ___is_macosx_2; }
	inline bool* get_address_of_is_macosx_2() { return &___is_macosx_2; }
	inline void set_is_macosx_2(bool value)
	{
		___is_macosx_2 = value;
	}

	inline static int32_t get_offset_of_s_flags_3() { return static_cast<int32_t>(offsetof(ChainValidationHelper_t1155887809_StaticFields, ___s_flags_3)); }
	inline int32_t get_s_flags_3() const { return ___s_flags_3; }
	inline int32_t* get_address_of_s_flags_3() { return &___s_flags_3; }
	inline void set_s_flags_3(int32_t value)
	{
		___s_flags_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
