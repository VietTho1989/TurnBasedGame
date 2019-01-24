#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountFacebookMessage
struct  AccountFacebookMessage_t2067448874  : public MessageBase_t2552428296
{
public:
	// System.String AccountFacebookMessage::userId
	String_t* ___userId_0;
	// System.String AccountFacebookMessage::firstName
	String_t* ___firstName_1;
	// System.String AccountFacebookMessage::lastName
	String_t* ___lastName_2;

public:
	inline static int32_t get_offset_of_userId_0() { return static_cast<int32_t>(offsetof(AccountFacebookMessage_t2067448874, ___userId_0)); }
	inline String_t* get_userId_0() const { return ___userId_0; }
	inline String_t** get_address_of_userId_0() { return &___userId_0; }
	inline void set_userId_0(String_t* value)
	{
		___userId_0 = value;
		Il2CppCodeGenWriteBarrier(&___userId_0, value);
	}

	inline static int32_t get_offset_of_firstName_1() { return static_cast<int32_t>(offsetof(AccountFacebookMessage_t2067448874, ___firstName_1)); }
	inline String_t* get_firstName_1() const { return ___firstName_1; }
	inline String_t** get_address_of_firstName_1() { return &___firstName_1; }
	inline void set_firstName_1(String_t* value)
	{
		___firstName_1 = value;
		Il2CppCodeGenWriteBarrier(&___firstName_1, value);
	}

	inline static int32_t get_offset_of_lastName_2() { return static_cast<int32_t>(offsetof(AccountFacebookMessage_t2067448874, ___lastName_2)); }
	inline String_t* get_lastName_2() const { return ___lastName_2; }
	inline String_t** get_address_of_lastName_2() { return &___lastName_2; }
	inline void set_lastName_2(String_t* value)
	{
		___lastName_2 = value;
		Il2CppCodeGenWriteBarrier(&___lastName_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
