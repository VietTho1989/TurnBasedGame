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

// AccountEmailMessage
struct  AccountEmailMessage_t974452568  : public MessageBase_t2552428296
{
public:
	// System.String AccountEmailMessage::email
	String_t* ___email_0;
	// System.String AccountEmailMessage::password
	String_t* ___password_1;

public:
	inline static int32_t get_offset_of_email_0() { return static_cast<int32_t>(offsetof(AccountEmailMessage_t974452568, ___email_0)); }
	inline String_t* get_email_0() const { return ___email_0; }
	inline String_t** get_address_of_email_0() { return &___email_0; }
	inline void set_email_0(String_t* value)
	{
		___email_0 = value;
		Il2CppCodeGenWriteBarrier(&___email_0, value);
	}

	inline static int32_t get_offset_of_password_1() { return static_cast<int32_t>(offsetof(AccountEmailMessage_t974452568, ___password_1)); }
	inline String_t* get_password_1() const { return ___password_1; }
	inline String_t** get_address_of_password_1() { return &___password_1; }
	inline void set_password_1(String_t* value)
	{
		___password_1 = value;
		Il2CppCodeGenWriteBarrier(&___password_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
