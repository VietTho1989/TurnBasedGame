#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Ban>>
struct VP_1_t3711979308;
// VP`1<BanUI/UIData/Sub>
struct VP_1_t1690834741;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BanUI/UIData
struct  UIData_t817695906  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Ban>> BanUI/UIData::ban
	VP_1_t3711979308 * ___ban_5;
	// VP`1<BanUI/UIData/Sub> BanUI/UIData::sub
	VP_1_t1690834741 * ___sub_6;

public:
	inline static int32_t get_offset_of_ban_5() { return static_cast<int32_t>(offsetof(UIData_t817695906, ___ban_5)); }
	inline VP_1_t3711979308 * get_ban_5() const { return ___ban_5; }
	inline VP_1_t3711979308 ** get_address_of_ban_5() { return &___ban_5; }
	inline void set_ban_5(VP_1_t3711979308 * value)
	{
		___ban_5 = value;
		Il2CppCodeGenWriteBarrier(&___ban_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t817695906, ___sub_6)); }
	inline VP_1_t1690834741 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1690834741 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1690834741 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
