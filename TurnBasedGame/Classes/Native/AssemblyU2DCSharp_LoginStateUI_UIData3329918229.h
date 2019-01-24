#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Login>>
struct VP_1_t3004649086;
// VP`1<LoginStateUI/UIData/Sub>
struct VP_1_t375687236;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginStateUI/UIData
struct  UIData_t3329918229  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Login>> LoginStateUI/UIData::login
	VP_1_t3004649086 * ___login_5;
	// VP`1<LoginStateUI/UIData/Sub> LoginStateUI/UIData::sub
	VP_1_t375687236 * ___sub_6;

public:
	inline static int32_t get_offset_of_login_5() { return static_cast<int32_t>(offsetof(UIData_t3329918229, ___login_5)); }
	inline VP_1_t3004649086 * get_login_5() const { return ___login_5; }
	inline VP_1_t3004649086 ** get_address_of_login_5() { return &___login_5; }
	inline void set_login_5(VP_1_t3004649086 * value)
	{
		___login_5 = value;
		Il2CppCodeGenWriteBarrier(&___login_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3329918229, ___sub_6)); }
	inline VP_1_t375687236 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t375687236 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t375687236 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
