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
// NetData`1<AccountEmail>
struct NetData_1_t3995512964;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountEmailIdentity
struct  AccountEmailIdentity_t1368478625  : public DataIdentity_t543951486
{
public:
	// System.String AccountEmailIdentity::email
	String_t* ___email_17;
	// System.String AccountEmailIdentity::password
	String_t* ___password_18;
	// System.String AccountEmailIdentity::customName
	String_t* ___customName_19;
	// System.String AccountEmailIdentity::avatarUrl
	String_t* ___avatarUrl_20;
	// NetData`1<AccountEmail> AccountEmailIdentity::netData
	NetData_1_t3995512964 * ___netData_21;

public:
	inline static int32_t get_offset_of_email_17() { return static_cast<int32_t>(offsetof(AccountEmailIdentity_t1368478625, ___email_17)); }
	inline String_t* get_email_17() const { return ___email_17; }
	inline String_t** get_address_of_email_17() { return &___email_17; }
	inline void set_email_17(String_t* value)
	{
		___email_17 = value;
		Il2CppCodeGenWriteBarrier(&___email_17, value);
	}

	inline static int32_t get_offset_of_password_18() { return static_cast<int32_t>(offsetof(AccountEmailIdentity_t1368478625, ___password_18)); }
	inline String_t* get_password_18() const { return ___password_18; }
	inline String_t** get_address_of_password_18() { return &___password_18; }
	inline void set_password_18(String_t* value)
	{
		___password_18 = value;
		Il2CppCodeGenWriteBarrier(&___password_18, value);
	}

	inline static int32_t get_offset_of_customName_19() { return static_cast<int32_t>(offsetof(AccountEmailIdentity_t1368478625, ___customName_19)); }
	inline String_t* get_customName_19() const { return ___customName_19; }
	inline String_t** get_address_of_customName_19() { return &___customName_19; }
	inline void set_customName_19(String_t* value)
	{
		___customName_19 = value;
		Il2CppCodeGenWriteBarrier(&___customName_19, value);
	}

	inline static int32_t get_offset_of_avatarUrl_20() { return static_cast<int32_t>(offsetof(AccountEmailIdentity_t1368478625, ___avatarUrl_20)); }
	inline String_t* get_avatarUrl_20() const { return ___avatarUrl_20; }
	inline String_t** get_address_of_avatarUrl_20() { return &___avatarUrl_20; }
	inline void set_avatarUrl_20(String_t* value)
	{
		___avatarUrl_20 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrl_20, value);
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(AccountEmailIdentity_t1368478625, ___netData_21)); }
	inline NetData_1_t3995512964 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t3995512964 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t3995512964 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
