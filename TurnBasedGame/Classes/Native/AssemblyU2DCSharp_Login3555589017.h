#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Login/State>
struct VP_1_t3041147819;
// VP`1<Account>
struct VP_1_t417958433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Login
struct  Login_t3555589017  : public Data_t3569509720
{
public:
	// VP`1<Login/State> Login::state
	VP_1_t3041147819 * ___state_5;
	// VP`1<Account> Login::account
	VP_1_t417958433 * ___account_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(Login_t3555589017, ___state_5)); }
	inline VP_1_t3041147819 * get_state_5() const { return ___state_5; }
	inline VP_1_t3041147819 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3041147819 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_account_6() { return static_cast<int32_t>(offsetof(Login_t3555589017, ___account_6)); }
	inline VP_1_t417958433 * get_account_6() const { return ___account_6; }
	inline VP_1_t417958433 ** get_address_of_account_6() { return &___account_6; }
	inline void set_account_6(VP_1_t417958433 * value)
	{
		___account_6 = value;
		Il2CppCodeGenWriteBarrier(&___account_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
