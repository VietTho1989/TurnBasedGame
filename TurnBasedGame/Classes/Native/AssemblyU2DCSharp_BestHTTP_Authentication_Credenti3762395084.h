﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_Authentication_Authenti1276453517.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Authentication.Credentials
struct  Credentials_t3762395084  : public Il2CppObject
{
public:
	// BestHTTP.Authentication.AuthenticationTypes BestHTTP.Authentication.Credentials::<Type>k__BackingField
	int32_t ___U3CTypeU3Ek__BackingField_0;
	// System.String BestHTTP.Authentication.Credentials::<UserName>k__BackingField
	String_t* ___U3CUserNameU3Ek__BackingField_1;
	// System.String BestHTTP.Authentication.Credentials::<Password>k__BackingField
	String_t* ___U3CPasswordU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CTypeU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Credentials_t3762395084, ___U3CTypeU3Ek__BackingField_0)); }
	inline int32_t get_U3CTypeU3Ek__BackingField_0() const { return ___U3CTypeU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CTypeU3Ek__BackingField_0() { return &___U3CTypeU3Ek__BackingField_0; }
	inline void set_U3CTypeU3Ek__BackingField_0(int32_t value)
	{
		___U3CTypeU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CUserNameU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Credentials_t3762395084, ___U3CUserNameU3Ek__BackingField_1)); }
	inline String_t* get_U3CUserNameU3Ek__BackingField_1() const { return ___U3CUserNameU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CUserNameU3Ek__BackingField_1() { return &___U3CUserNameU3Ek__BackingField_1; }
	inline void set_U3CUserNameU3Ek__BackingField_1(String_t* value)
	{
		___U3CUserNameU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUserNameU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CPasswordU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Credentials_t3762395084, ___U3CPasswordU3Ek__BackingField_2)); }
	inline String_t* get_U3CPasswordU3Ek__BackingField_2() const { return ___U3CPasswordU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CPasswordU3Ek__BackingField_2() { return &___U3CPasswordU3Ek__BackingField_2; }
	inline void set_U3CPasswordU3Ek__BackingField_2(String_t* value)
	{
		___U3CPasswordU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CPasswordU3Ek__BackingField_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
