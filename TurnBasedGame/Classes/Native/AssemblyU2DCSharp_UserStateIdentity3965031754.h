#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_UserState_State968094678.h"

// NetData`1<UserState>
struct NetData_1_t2001698029;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserStateIdentity
struct  UserStateIdentity_t3965031754  : public DataIdentity_t543951486
{
public:
	// UserState/State UserStateIdentity::state
	int32_t ___state_17;
	// System.Boolean UserStateIdentity::hide
	bool ___hide_18;
	// System.Int64 UserStateIdentity::time
	int64_t ___time_19;
	// NetData`1<UserState> UserStateIdentity::netData
	NetData_1_t2001698029 * ___netData_20;

public:
	inline static int32_t get_offset_of_state_17() { return static_cast<int32_t>(offsetof(UserStateIdentity_t3965031754, ___state_17)); }
	inline int32_t get_state_17() const { return ___state_17; }
	inline int32_t* get_address_of_state_17() { return &___state_17; }
	inline void set_state_17(int32_t value)
	{
		___state_17 = value;
	}

	inline static int32_t get_offset_of_hide_18() { return static_cast<int32_t>(offsetof(UserStateIdentity_t3965031754, ___hide_18)); }
	inline bool get_hide_18() const { return ___hide_18; }
	inline bool* get_address_of_hide_18() { return &___hide_18; }
	inline void set_hide_18(bool value)
	{
		___hide_18 = value;
	}

	inline static int32_t get_offset_of_time_19() { return static_cast<int32_t>(offsetof(UserStateIdentity_t3965031754, ___time_19)); }
	inline int64_t get_time_19() const { return ___time_19; }
	inline int64_t* get_address_of_time_19() { return &___time_19; }
	inline void set_time_19(int64_t value)
	{
		___time_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(UserStateIdentity_t3965031754, ___netData_20)); }
	inline NetData_1_t2001698029 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t2001698029 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t2001698029 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
