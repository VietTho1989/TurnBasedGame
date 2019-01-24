#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Account>>
struct VP_1_t3783708792;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountAvatarUI/UIData
struct  UIData_t3169155181  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Account>> AccountAvatarUI/UIData::account
	VP_1_t3783708792 * ___account_5;

public:
	inline static int32_t get_offset_of_account_5() { return static_cast<int32_t>(offsetof(UIData_t3169155181, ___account_5)); }
	inline VP_1_t3783708792 * get_account_5() const { return ___account_5; }
	inline VP_1_t3783708792 ** get_address_of_account_5() { return &___account_5; }
	inline void set_account_5(VP_1_t3783708792 * value)
	{
		___account_5 = value;
		Il2CppCodeGenWriteBarrier(&___account_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
