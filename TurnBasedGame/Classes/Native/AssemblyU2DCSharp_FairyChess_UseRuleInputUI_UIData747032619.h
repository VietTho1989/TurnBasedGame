#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FairyChess_InputUI_UIData_Sub2386736321.h"

// VP`1<ReferenceData`1<FairyChess.FairyChess>>
struct VP_1_t3341857400;
// VP`1<FairyChess.UseRuleInputUI/UIData/State>
struct VP_1_t2897247177;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UseRuleInputUI/UIData
struct  UIData_t747032619  : public Sub_t2386736321
{
public:
	// VP`1<ReferenceData`1<FairyChess.FairyChess>> FairyChess.UseRuleInputUI/UIData::fairyChess
	VP_1_t3341857400 * ___fairyChess_5;
	// VP`1<FairyChess.UseRuleInputUI/UIData/State> FairyChess.UseRuleInputUI/UIData::state
	VP_1_t2897247177 * ___state_6;

public:
	inline static int32_t get_offset_of_fairyChess_5() { return static_cast<int32_t>(offsetof(UIData_t747032619, ___fairyChess_5)); }
	inline VP_1_t3341857400 * get_fairyChess_5() const { return ___fairyChess_5; }
	inline VP_1_t3341857400 ** get_address_of_fairyChess_5() { return &___fairyChess_5; }
	inline void set_fairyChess_5(VP_1_t3341857400 * value)
	{
		___fairyChess_5 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChess_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t747032619, ___state_6)); }
	inline VP_1_t2897247177 * get_state_6() const { return ___state_6; }
	inline VP_1_t2897247177 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2897247177 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
