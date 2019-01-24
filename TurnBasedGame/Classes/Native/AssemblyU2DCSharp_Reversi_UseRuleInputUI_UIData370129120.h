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
// VP`1<Reversi.UseRuleInputUI/UIData/State>
struct VP_1_t2515823012;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.UseRuleInputUI/UIData
struct  UIData_t370129120  : public Sub_t886518512
{
public:
	// VP`1<ReferenceData`1<Reversi.Reversi>> Reversi.UseRuleInputUI/UIData::reversi
	VP_1_t2036835161 * ___reversi_5;
	// VP`1<Reversi.UseRuleInputUI/UIData/State> Reversi.UseRuleInputUI/UIData::state
	VP_1_t2515823012 * ___state_6;

public:
	inline static int32_t get_offset_of_reversi_5() { return static_cast<int32_t>(offsetof(UIData_t370129120, ___reversi_5)); }
	inline VP_1_t2036835161 * get_reversi_5() const { return ___reversi_5; }
	inline VP_1_t2036835161 ** get_address_of_reversi_5() { return &___reversi_5; }
	inline void set_reversi_5(VP_1_t2036835161 * value)
	{
		___reversi_5 = value;
		Il2CppCodeGenWriteBarrier(&___reversi_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t370129120, ___state_6)); }
	inline VP_1_t2515823012 * get_state_6() const { return ___state_6; }
	inline VP_1_t2515823012 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2515823012 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
