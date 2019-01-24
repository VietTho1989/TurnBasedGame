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

// Country
struct  Country_t1439527382  : public Il2CppObject
{
public:
	// System.Int32 Country::<Id>k__BackingField
	int32_t ___U3CIdU3Ek__BackingField_3;
	// System.String Country::<CodeAlpha2>k__BackingField
	String_t* ___U3CCodeAlpha2U3Ek__BackingField_4;
	// System.String Country::<CodeAlpha3>k__BackingField
	String_t* ___U3CCodeAlpha3U3Ek__BackingField_5;
	// System.String Country::Name
	String_t* ___Name_6;

public:
	inline static int32_t get_offset_of_U3CIdU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Country_t1439527382, ___U3CIdU3Ek__BackingField_3)); }
	inline int32_t get_U3CIdU3Ek__BackingField_3() const { return ___U3CIdU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CIdU3Ek__BackingField_3() { return &___U3CIdU3Ek__BackingField_3; }
	inline void set_U3CIdU3Ek__BackingField_3(int32_t value)
	{
		___U3CIdU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CCodeAlpha2U3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Country_t1439527382, ___U3CCodeAlpha2U3Ek__BackingField_4)); }
	inline String_t* get_U3CCodeAlpha2U3Ek__BackingField_4() const { return ___U3CCodeAlpha2U3Ek__BackingField_4; }
	inline String_t** get_address_of_U3CCodeAlpha2U3Ek__BackingField_4() { return &___U3CCodeAlpha2U3Ek__BackingField_4; }
	inline void set_U3CCodeAlpha2U3Ek__BackingField_4(String_t* value)
	{
		___U3CCodeAlpha2U3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCodeAlpha2U3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CCodeAlpha3U3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(Country_t1439527382, ___U3CCodeAlpha3U3Ek__BackingField_5)); }
	inline String_t* get_U3CCodeAlpha3U3Ek__BackingField_5() const { return ___U3CCodeAlpha3U3Ek__BackingField_5; }
	inline String_t** get_address_of_U3CCodeAlpha3U3Ek__BackingField_5() { return &___U3CCodeAlpha3U3Ek__BackingField_5; }
	inline void set_U3CCodeAlpha3U3Ek__BackingField_5(String_t* value)
	{
		___U3CCodeAlpha3U3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCodeAlpha3U3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_Name_6() { return static_cast<int32_t>(offsetof(Country_t1439527382, ___Name_6)); }
	inline String_t* get_Name_6() const { return ___Name_6; }
	inline String_t** get_address_of_Name_6() { return &___Name_6; }
	inline void set_Name_6(String_t* value)
	{
		___Name_6 = value;
		Il2CppCodeGenWriteBarrier(&___Name_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
