#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_HEX_InputUI_UIData_Sub593265707.h"

// VP`1<ReferenceData`1<HEX.Hex>>
struct VP_1_t864248728;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.UseRuleInputUI/UIData
struct  UIData_t2454890833  : public Sub_t593265707
{
public:
	// VP`1<ReferenceData`1<HEX.Hex>> HEX.UseRuleInputUI/UIData::hex
	VP_1_t864248728 * ___hex_5;

public:
	inline static int32_t get_offset_of_hex_5() { return static_cast<int32_t>(offsetof(UIData_t2454890833, ___hex_5)); }
	inline VP_1_t864248728 * get_hex_5() const { return ___hex_5; }
	inline VP_1_t864248728 ** get_address_of_hex_5() { return &___hex_5; }
	inline void set_hex_5(VP_1_t864248728 * value)
	{
		___hex_5 = value;
		Il2CppCodeGenWriteBarrier(&___hex_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
