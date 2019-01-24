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
// NetData`1<AccountAdmin>
struct NetData_1_t3594036539;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountAdminIdentity
struct  AccountAdminIdentity_t1439930988  : public DataIdentity_t543951486
{
public:
	// System.String AccountAdminIdentity::customName
	String_t* ___customName_17;
	// System.String AccountAdminIdentity::avatarUrl
	String_t* ___avatarUrl_18;
	// NetData`1<AccountAdmin> AccountAdminIdentity::netData
	NetData_1_t3594036539 * ___netData_19;

public:
	inline static int32_t get_offset_of_customName_17() { return static_cast<int32_t>(offsetof(AccountAdminIdentity_t1439930988, ___customName_17)); }
	inline String_t* get_customName_17() const { return ___customName_17; }
	inline String_t** get_address_of_customName_17() { return &___customName_17; }
	inline void set_customName_17(String_t* value)
	{
		___customName_17 = value;
		Il2CppCodeGenWriteBarrier(&___customName_17, value);
	}

	inline static int32_t get_offset_of_avatarUrl_18() { return static_cast<int32_t>(offsetof(AccountAdminIdentity_t1439930988, ___avatarUrl_18)); }
	inline String_t* get_avatarUrl_18() const { return ___avatarUrl_18; }
	inline String_t** get_address_of_avatarUrl_18() { return &___avatarUrl_18; }
	inline void set_avatarUrl_18(String_t* value)
	{
		___avatarUrl_18 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrl_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(AccountAdminIdentity_t1439930988, ___netData_19)); }
	inline NetData_1_t3594036539 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3594036539 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3594036539 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
