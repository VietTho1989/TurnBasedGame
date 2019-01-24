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

// Mono.Xml.Schema.XsdIdentityStep
struct  XsdIdentityStep_t452377251  : public Il2CppObject
{
public:
	// System.Boolean Mono.Xml.Schema.XsdIdentityStep::IsCurrent
	bool ___IsCurrent_0;
	// System.Boolean Mono.Xml.Schema.XsdIdentityStep::IsAttribute
	bool ___IsAttribute_1;
	// System.Boolean Mono.Xml.Schema.XsdIdentityStep::IsAnyName
	bool ___IsAnyName_2;
	// System.String Mono.Xml.Schema.XsdIdentityStep::NsName
	String_t* ___NsName_3;
	// System.String Mono.Xml.Schema.XsdIdentityStep::Name
	String_t* ___Name_4;
	// System.String Mono.Xml.Schema.XsdIdentityStep::Namespace
	String_t* ___Namespace_5;

public:
	inline static int32_t get_offset_of_IsCurrent_0() { return static_cast<int32_t>(offsetof(XsdIdentityStep_t452377251, ___IsCurrent_0)); }
	inline bool get_IsCurrent_0() const { return ___IsCurrent_0; }
	inline bool* get_address_of_IsCurrent_0() { return &___IsCurrent_0; }
	inline void set_IsCurrent_0(bool value)
	{
		___IsCurrent_0 = value;
	}

	inline static int32_t get_offset_of_IsAttribute_1() { return static_cast<int32_t>(offsetof(XsdIdentityStep_t452377251, ___IsAttribute_1)); }
	inline bool get_IsAttribute_1() const { return ___IsAttribute_1; }
	inline bool* get_address_of_IsAttribute_1() { return &___IsAttribute_1; }
	inline void set_IsAttribute_1(bool value)
	{
		___IsAttribute_1 = value;
	}

	inline static int32_t get_offset_of_IsAnyName_2() { return static_cast<int32_t>(offsetof(XsdIdentityStep_t452377251, ___IsAnyName_2)); }
	inline bool get_IsAnyName_2() const { return ___IsAnyName_2; }
	inline bool* get_address_of_IsAnyName_2() { return &___IsAnyName_2; }
	inline void set_IsAnyName_2(bool value)
	{
		___IsAnyName_2 = value;
	}

	inline static int32_t get_offset_of_NsName_3() { return static_cast<int32_t>(offsetof(XsdIdentityStep_t452377251, ___NsName_3)); }
	inline String_t* get_NsName_3() const { return ___NsName_3; }
	inline String_t** get_address_of_NsName_3() { return &___NsName_3; }
	inline void set_NsName_3(String_t* value)
	{
		___NsName_3 = value;
		Il2CppCodeGenWriteBarrier(&___NsName_3, value);
	}

	inline static int32_t get_offset_of_Name_4() { return static_cast<int32_t>(offsetof(XsdIdentityStep_t452377251, ___Name_4)); }
	inline String_t* get_Name_4() const { return ___Name_4; }
	inline String_t** get_address_of_Name_4() { return &___Name_4; }
	inline void set_Name_4(String_t* value)
	{
		___Name_4 = value;
		Il2CppCodeGenWriteBarrier(&___Name_4, value);
	}

	inline static int32_t get_offset_of_Namespace_5() { return static_cast<int32_t>(offsetof(XsdIdentityStep_t452377251, ___Namespace_5)); }
	inline String_t* get_Namespace_5() const { return ___Namespace_5; }
	inline String_t** get_address_of_Namespace_5() { return &___Namespace_5; }
	inline void set_Namespace_5(String_t* value)
	{
		___Namespace_5 = value;
		Il2CppCodeGenWriteBarrier(&___Namespace_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
