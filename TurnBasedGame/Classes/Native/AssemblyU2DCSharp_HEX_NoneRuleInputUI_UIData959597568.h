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
// VP`1<HEX.NoneRuleInputUI/UIData/Sub>
struct VP_1_t1925650377;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.NoneRuleInputUI/UIData
struct  UIData_t959597568  : public Sub_t593265707
{
public:
	// VP`1<ReferenceData`1<HEX.Hex>> HEX.NoneRuleInputUI/UIData::hex
	VP_1_t864248728 * ___hex_5;
	// VP`1<HEX.NoneRuleInputUI/UIData/Sub> HEX.NoneRuleInputUI/UIData::sub
	VP_1_t1925650377 * ___sub_6;

public:
	inline static int32_t get_offset_of_hex_5() { return static_cast<int32_t>(offsetof(UIData_t959597568, ___hex_5)); }
	inline VP_1_t864248728 * get_hex_5() const { return ___hex_5; }
	inline VP_1_t864248728 ** get_address_of_hex_5() { return &___hex_5; }
	inline void set_hex_5(VP_1_t864248728 * value)
	{
		___hex_5 = value;
		Il2CppCodeGenWriteBarrier(&___hex_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t959597568, ___sub_6)); }
	inline VP_1_t1925650377 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1925650377 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1925650377 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
