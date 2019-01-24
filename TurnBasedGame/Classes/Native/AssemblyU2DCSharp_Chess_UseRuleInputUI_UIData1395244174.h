#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Chess_InputUI_UIData_Sub4053741090.h"

// VP`1<ReferenceData`1<Chess.Chess>>
struct VP_1_t1603404227;
// VP`1<Chess.UseRuleInputUI/UIData/State>
struct VP_1_t2887818118;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRuleInputUI/UIData
struct  UIData_t1395244174  : public Sub_t4053741090
{
public:
	// VP`1<ReferenceData`1<Chess.Chess>> Chess.UseRuleInputUI/UIData::chess
	VP_1_t1603404227 * ___chess_5;
	// VP`1<Chess.UseRuleInputUI/UIData/State> Chess.UseRuleInputUI/UIData::state
	VP_1_t2887818118 * ___state_6;

public:
	inline static int32_t get_offset_of_chess_5() { return static_cast<int32_t>(offsetof(UIData_t1395244174, ___chess_5)); }
	inline VP_1_t1603404227 * get_chess_5() const { return ___chess_5; }
	inline VP_1_t1603404227 ** get_address_of_chess_5() { return &___chess_5; }
	inline void set_chess_5(VP_1_t1603404227 * value)
	{
		___chess_5 = value;
		Il2CppCodeGenWriteBarrier(&___chess_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t1395244174, ___state_6)); }
	inline VP_1_t2887818118 * get_state_6() const { return ___state_6; }
	inline VP_1_t2887818118 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2887818118 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
