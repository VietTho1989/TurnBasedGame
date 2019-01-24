#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Policy.CodeConnectAccess
struct  CodeConnectAccess_t3638993531  : public Il2CppObject
{
public:
	// System.String System.Security.Policy.CodeConnectAccess::_scheme
	String_t* ____scheme_4;
	// System.Int32 System.Security.Policy.CodeConnectAccess::_port
	int32_t ____port_5;

public:
	inline static int32_t get_offset_of__scheme_4() { return static_cast<int32_t>(offsetof(CodeConnectAccess_t3638993531, ____scheme_4)); }
	inline String_t* get__scheme_4() const { return ____scheme_4; }
	inline String_t** get_address_of__scheme_4() { return &____scheme_4; }
	inline void set__scheme_4(String_t* value)
	{
		____scheme_4 = value;
		Il2CppCodeGenWriteBarrier(&____scheme_4, value);
	}

	inline static int32_t get_offset_of__port_5() { return static_cast<int32_t>(offsetof(CodeConnectAccess_t3638993531, ____port_5)); }
	inline int32_t get__port_5() const { return ____port_5; }
	inline int32_t* get_address_of__port_5() { return &____port_5; }
	inline void set__port_5(int32_t value)
	{
		____port_5 = value;
	}
};

struct CodeConnectAccess_t3638993531_StaticFields
{
public:
	// System.String System.Security.Policy.CodeConnectAccess::AnyScheme
	String_t* ___AnyScheme_0;
	// System.Int32 System.Security.Policy.CodeConnectAccess::DefaultPort
	int32_t ___DefaultPort_1;
	// System.Int32 System.Security.Policy.CodeConnectAccess::OriginPort
	int32_t ___OriginPort_2;
	// System.String System.Security.Policy.CodeConnectAccess::OriginScheme
	String_t* ___OriginScheme_3;

public:
	inline static int32_t get_offset_of_AnyScheme_0() { return static_cast<int32_t>(offsetof(CodeConnectAccess_t3638993531_StaticFields, ___AnyScheme_0)); }
	inline String_t* get_AnyScheme_0() const { return ___AnyScheme_0; }
	inline String_t** get_address_of_AnyScheme_0() { return &___AnyScheme_0; }
	inline void set_AnyScheme_0(String_t* value)
	{
		___AnyScheme_0 = value;
		Il2CppCodeGenWriteBarrier(&___AnyScheme_0, value);
	}

	inline static int32_t get_offset_of_DefaultPort_1() { return static_cast<int32_t>(offsetof(CodeConnectAccess_t3638993531_StaticFields, ___DefaultPort_1)); }
	inline int32_t get_DefaultPort_1() const { return ___DefaultPort_1; }
	inline int32_t* get_address_of_DefaultPort_1() { return &___DefaultPort_1; }
	inline void set_DefaultPort_1(int32_t value)
	{
		___DefaultPort_1 = value;
	}

	inline static int32_t get_offset_of_OriginPort_2() { return static_cast<int32_t>(offsetof(CodeConnectAccess_t3638993531_StaticFields, ___OriginPort_2)); }
	inline int32_t get_OriginPort_2() const { return ___OriginPort_2; }
	inline int32_t* get_address_of_OriginPort_2() { return &___OriginPort_2; }
	inline void set_OriginPort_2(int32_t value)
	{
		___OriginPort_2 = value;
	}

	inline static int32_t get_offset_of_OriginScheme_3() { return static_cast<int32_t>(offsetof(CodeConnectAccess_t3638993531_StaticFields, ___OriginScheme_3)); }
	inline String_t* get_OriginScheme_3() const { return ___OriginScheme_3; }
	inline String_t** get_address_of_OriginScheme_3() { return &___OriginScheme_3; }
	inline void set_OriginScheme_3(String_t* value)
	{
		___OriginScheme_3 = value;
		Il2CppCodeGenWriteBarrier(&___OriginScheme_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
