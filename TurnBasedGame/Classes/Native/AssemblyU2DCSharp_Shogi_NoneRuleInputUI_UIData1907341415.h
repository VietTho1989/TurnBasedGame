#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Shogi_InputUI_UIData_Sub3564588102.h"

// VP`1<ReferenceData`1<Shogi.Shogi>>
struct VP_1_t1424602871;
// VP`1<Shogi.NoneRuleInputUI/UIData/Sub>
struct VP_1_t2297211696;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRuleInputUI/UIData
struct  UIData_t1907341415  : public Sub_t3564588102
{
public:
	// VP`1<ReferenceData`1<Shogi.Shogi>> Shogi.NoneRuleInputUI/UIData::shogi
	VP_1_t1424602871 * ___shogi_5;
	// VP`1<Shogi.NoneRuleInputUI/UIData/Sub> Shogi.NoneRuleInputUI/UIData::sub
	VP_1_t2297211696 * ___sub_6;

public:
	inline static int32_t get_offset_of_shogi_5() { return static_cast<int32_t>(offsetof(UIData_t1907341415, ___shogi_5)); }
	inline VP_1_t1424602871 * get_shogi_5() const { return ___shogi_5; }
	inline VP_1_t1424602871 ** get_address_of_shogi_5() { return &___shogi_5; }
	inline void set_shogi_5(VP_1_t1424602871 * value)
	{
		___shogi_5 = value;
		Il2CppCodeGenWriteBarrier(&___shogi_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1907341415, ___sub_6)); }
	inline VP_1_t2297211696 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2297211696 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2297211696 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
