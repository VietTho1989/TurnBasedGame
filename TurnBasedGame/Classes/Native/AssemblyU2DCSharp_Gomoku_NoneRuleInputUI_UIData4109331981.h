#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Gomoku_InputUI_UIData_Sub1880797204.h"

// VP`1<ReferenceData`1<Gomoku.Gomoku>>
struct VP_1_t2098049877;
// VP`1<Gomoku.NoneRuleInputUI/UIData/Sub>
struct VP_1_t2867908490;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.NoneRuleInputUI/UIData
struct  UIData_t4109331981  : public Sub_t1880797204
{
public:
	// VP`1<ReferenceData`1<Gomoku.Gomoku>> Gomoku.NoneRuleInputUI/UIData::gomoku
	VP_1_t2098049877 * ___gomoku_5;
	// VP`1<Gomoku.NoneRuleInputUI/UIData/Sub> Gomoku.NoneRuleInputUI/UIData::sub
	VP_1_t2867908490 * ___sub_6;

public:
	inline static int32_t get_offset_of_gomoku_5() { return static_cast<int32_t>(offsetof(UIData_t4109331981, ___gomoku_5)); }
	inline VP_1_t2098049877 * get_gomoku_5() const { return ___gomoku_5; }
	inline VP_1_t2098049877 ** get_address_of_gomoku_5() { return &___gomoku_5; }
	inline void set_gomoku_5(VP_1_t2098049877 * value)
	{
		___gomoku_5 = value;
		Il2CppCodeGenWriteBarrier(&___gomoku_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t4109331981, ___sub_6)); }
	inline VP_1_t2867908490 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2867908490 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2867908490 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
