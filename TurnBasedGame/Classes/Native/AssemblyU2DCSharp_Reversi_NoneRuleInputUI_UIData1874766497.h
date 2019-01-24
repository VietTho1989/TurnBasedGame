#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Reversi_InputUI_UIData_Sub886518512.h"

// VP`1<ReferenceData`1<Reversi.Reversi>>
struct VP_1_t2036835161;
// VP`1<Reversi.NoneRuleInputUI/UIData/Sub>
struct VP_1_t848906334;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.NoneRuleInputUI/UIData
struct  UIData_t1874766497  : public Sub_t886518512
{
public:
	// VP`1<ReferenceData`1<Reversi.Reversi>> Reversi.NoneRuleInputUI/UIData::reversi
	VP_1_t2036835161 * ___reversi_5;
	// VP`1<Reversi.NoneRuleInputUI/UIData/Sub> Reversi.NoneRuleInputUI/UIData::sub
	VP_1_t848906334 * ___sub_6;

public:
	inline static int32_t get_offset_of_reversi_5() { return static_cast<int32_t>(offsetof(UIData_t1874766497, ___reversi_5)); }
	inline VP_1_t2036835161 * get_reversi_5() const { return ___reversi_5; }
	inline VP_1_t2036835161 ** get_address_of_reversi_5() { return &___reversi_5; }
	inline void set_reversi_5(VP_1_t2036835161 * value)
	{
		___reversi_5 = value;
		Il2CppCodeGenWriteBarrier(&___reversi_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1874766497, ___sub_6)); }
	inline VP_1_t848906334 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t848906334 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t848906334 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
