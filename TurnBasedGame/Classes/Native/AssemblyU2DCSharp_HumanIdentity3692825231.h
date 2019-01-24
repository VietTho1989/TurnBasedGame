#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_User_SEX3934230676.h"

// System.String
struct String_t;
// NetData`1<Human>
struct NetData_1_t1402437018;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanIdentity
struct  HumanIdentity_t3692825231  : public DataIdentity_t543951486
{
public:
	// System.UInt32 HumanIdentity::playerId
	uint32_t ___playerId_17;
	// System.String HumanIdentity::email
	String_t* ___email_18;
	// System.String HumanIdentity::phoneNumber
	String_t* ___phoneNumber_19;
	// System.String HumanIdentity::status
	String_t* ___status_20;
	// System.Int64 HumanIdentity::birthday
	int64_t ___birthday_21;
	// User/SEX HumanIdentity::sex
	int32_t ___sex_22;
	// NetData`1<Human> HumanIdentity::netData
	NetData_1_t1402437018 * ___netData_23;

public:
	inline static int32_t get_offset_of_playerId_17() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___playerId_17)); }
	inline uint32_t get_playerId_17() const { return ___playerId_17; }
	inline uint32_t* get_address_of_playerId_17() { return &___playerId_17; }
	inline void set_playerId_17(uint32_t value)
	{
		___playerId_17 = value;
	}

	inline static int32_t get_offset_of_email_18() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___email_18)); }
	inline String_t* get_email_18() const { return ___email_18; }
	inline String_t** get_address_of_email_18() { return &___email_18; }
	inline void set_email_18(String_t* value)
	{
		___email_18 = value;
		Il2CppCodeGenWriteBarrier(&___email_18, value);
	}

	inline static int32_t get_offset_of_phoneNumber_19() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___phoneNumber_19)); }
	inline String_t* get_phoneNumber_19() const { return ___phoneNumber_19; }
	inline String_t** get_address_of_phoneNumber_19() { return &___phoneNumber_19; }
	inline void set_phoneNumber_19(String_t* value)
	{
		___phoneNumber_19 = value;
		Il2CppCodeGenWriteBarrier(&___phoneNumber_19, value);
	}

	inline static int32_t get_offset_of_status_20() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___status_20)); }
	inline String_t* get_status_20() const { return ___status_20; }
	inline String_t** get_address_of_status_20() { return &___status_20; }
	inline void set_status_20(String_t* value)
	{
		___status_20 = value;
		Il2CppCodeGenWriteBarrier(&___status_20, value);
	}

	inline static int32_t get_offset_of_birthday_21() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___birthday_21)); }
	inline int64_t get_birthday_21() const { return ___birthday_21; }
	inline int64_t* get_address_of_birthday_21() { return &___birthday_21; }
	inline void set_birthday_21(int64_t value)
	{
		___birthday_21 = value;
	}

	inline static int32_t get_offset_of_sex_22() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___sex_22)); }
	inline int32_t get_sex_22() const { return ___sex_22; }
	inline int32_t* get_address_of_sex_22() { return &___sex_22; }
	inline void set_sex_22(int32_t value)
	{
		___sex_22 = value;
	}

	inline static int32_t get_offset_of_netData_23() { return static_cast<int32_t>(offsetof(HumanIdentity_t3692825231, ___netData_23)); }
	inline NetData_1_t1402437018 * get_netData_23() const { return ___netData_23; }
	inline NetData_1_t1402437018 ** get_address_of_netData_23() { return &___netData_23; }
	inline void set_netData_23(NetData_1_t1402437018 * value)
	{
		___netData_23 = value;
		Il2CppCodeGenWriteBarrier(&___netData_23, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
