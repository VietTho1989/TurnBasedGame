#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// System.String
struct String_t;
// NetData`1<AccountFacebook>
struct NetData_1_t3012825032;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountFacebookIdentity
struct  AccountFacebookIdentity_t4286810389  : public DataIdentity_t543951486
{
public:
	// System.String AccountFacebookIdentity::userId
	String_t* ___userId_17;
	// System.String AccountFacebookIdentity::firstName
	String_t* ___firstName_18;
	// System.String AccountFacebookIdentity::lastName
	String_t* ___lastName_19;
	// NetData`1<AccountFacebook> AccountFacebookIdentity::netData
	NetData_1_t3012825032 * ___netData_20;

public:
	inline static int32_t get_offset_of_userId_17() { return static_cast<int32_t>(offsetof(AccountFacebookIdentity_t4286810389, ___userId_17)); }
	inline String_t* get_userId_17() const { return ___userId_17; }
	inline String_t** get_address_of_userId_17() { return &___userId_17; }
	inline void set_userId_17(String_t* value)
	{
		___userId_17 = value;
		Il2CppCodeGenWriteBarrier(&___userId_17, value);
	}

	inline static int32_t get_offset_of_firstName_18() { return static_cast<int32_t>(offsetof(AccountFacebookIdentity_t4286810389, ___firstName_18)); }
	inline String_t* get_firstName_18() const { return ___firstName_18; }
	inline String_t** get_address_of_firstName_18() { return &___firstName_18; }
	inline void set_firstName_18(String_t* value)
	{
		___firstName_18 = value;
		Il2CppCodeGenWriteBarrier(&___firstName_18, value);
	}

	inline static int32_t get_offset_of_lastName_19() { return static_cast<int32_t>(offsetof(AccountFacebookIdentity_t4286810389, ___lastName_19)); }
	inline String_t* get_lastName_19() const { return ___lastName_19; }
	inline String_t** get_address_of_lastName_19() { return &___lastName_19; }
	inline void set_lastName_19(String_t* value)
	{
		___lastName_19 = value;
		Il2CppCodeGenWriteBarrier(&___lastName_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(AccountFacebookIdentity_t4286810389, ___netData_20)); }
	inline NetData_1_t3012825032 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3012825032 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3012825032 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
