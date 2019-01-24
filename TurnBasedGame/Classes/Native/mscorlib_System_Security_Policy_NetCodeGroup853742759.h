#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Security_Policy_CodeGroup1856851900.h"

// System.String
struct String_t;
// System.Collections.Hashtable
struct Hashtable_t909839986;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Policy.NetCodeGroup
struct  NetCodeGroup_t853742759  : public CodeGroup_t1856851900
{
public:
	// System.Collections.Hashtable System.Security.Policy.NetCodeGroup::_rules
	Hashtable_t909839986 * ____rules_8;
	// System.Int32 System.Security.Policy.NetCodeGroup::_hashcode
	int32_t ____hashcode_9;

public:
	inline static int32_t get_offset_of__rules_8() { return static_cast<int32_t>(offsetof(NetCodeGroup_t853742759, ____rules_8)); }
	inline Hashtable_t909839986 * get__rules_8() const { return ____rules_8; }
	inline Hashtable_t909839986 ** get_address_of__rules_8() { return &____rules_8; }
	inline void set__rules_8(Hashtable_t909839986 * value)
	{
		____rules_8 = value;
		Il2CppCodeGenWriteBarrier(&____rules_8, value);
	}

	inline static int32_t get_offset_of__hashcode_9() { return static_cast<int32_t>(offsetof(NetCodeGroup_t853742759, ____hashcode_9)); }
	inline int32_t get__hashcode_9() const { return ____hashcode_9; }
	inline int32_t* get_address_of__hashcode_9() { return &____hashcode_9; }
	inline void set__hashcode_9(int32_t value)
	{
		____hashcode_9 = value;
	}
};

struct NetCodeGroup_t853742759_StaticFields
{
public:
	// System.String System.Security.Policy.NetCodeGroup::AbsentOriginScheme
	String_t* ___AbsentOriginScheme_6;
	// System.String System.Security.Policy.NetCodeGroup::AnyOtherOriginScheme
	String_t* ___AnyOtherOriginScheme_7;

public:
	inline static int32_t get_offset_of_AbsentOriginScheme_6() { return static_cast<int32_t>(offsetof(NetCodeGroup_t853742759_StaticFields, ___AbsentOriginScheme_6)); }
	inline String_t* get_AbsentOriginScheme_6() const { return ___AbsentOriginScheme_6; }
	inline String_t** get_address_of_AbsentOriginScheme_6() { return &___AbsentOriginScheme_6; }
	inline void set_AbsentOriginScheme_6(String_t* value)
	{
		___AbsentOriginScheme_6 = value;
		Il2CppCodeGenWriteBarrier(&___AbsentOriginScheme_6, value);
	}

	inline static int32_t get_offset_of_AnyOtherOriginScheme_7() { return static_cast<int32_t>(offsetof(NetCodeGroup_t853742759_StaticFields, ___AnyOtherOriginScheme_7)); }
	inline String_t* get_AnyOtherOriginScheme_7() const { return ___AnyOtherOriginScheme_7; }
	inline String_t** get_address_of_AnyOtherOriginScheme_7() { return &___AnyOtherOriginScheme_7; }
	inline void set_AnyOtherOriginScheme_7(String_t* value)
	{
		___AnyOtherOriginScheme_7 = value;
		Il2CppCodeGenWriteBarrier(&___AnyOtherOriginScheme_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
