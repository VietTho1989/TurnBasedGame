#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Xiangqi_InputUI_UIData_Sub48225255.h"

// VP`1<ReferenceData`1<Xiangqi.Xiangqi>>
struct VP_1_t2689160972;
// VP`1<Xiangqi.UseRuleInputUI/UIData/State>
struct VP_1_t34693595;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UseRuleInputUI/UIData
struct  UIData_t768424281  : public Sub_t48225255
{
public:
	// VP`1<ReferenceData`1<Xiangqi.Xiangqi>> Xiangqi.UseRuleInputUI/UIData::xiangqi
	VP_1_t2689160972 * ___xiangqi_5;
	// VP`1<Xiangqi.UseRuleInputUI/UIData/State> Xiangqi.UseRuleInputUI/UIData::state
	VP_1_t34693595 * ___state_6;

public:
	inline static int32_t get_offset_of_xiangqi_5() { return static_cast<int32_t>(offsetof(UIData_t768424281, ___xiangqi_5)); }
	inline VP_1_t2689160972 * get_xiangqi_5() const { return ___xiangqi_5; }
	inline VP_1_t2689160972 ** get_address_of_xiangqi_5() { return &___xiangqi_5; }
	inline void set_xiangqi_5(VP_1_t2689160972 * value)
	{
		___xiangqi_5 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqi_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t768424281, ___state_6)); }
	inline VP_1_t34693595 * get_state_6() const { return ___state_6; }
	inline VP_1_t34693595 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t34693595 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
