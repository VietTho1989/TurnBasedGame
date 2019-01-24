#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Swap.SwapRequestStateAsk>>
struct VP_1_t3839648117;
// LP`1<GameManager.Match.Swap.WhoCanAskHolder/UIData>
struct LP_1_t660031465;
// System.Collections.Generic.List`1<Human>
struct List_1_t525209625;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.WhoCanAskAdapter/UIData
struct  UIData_t1902404260  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Swap.SwapRequestStateAsk>> GameManager.Match.Swap.WhoCanAskAdapter/UIData::swapRequestStateAsk
	VP_1_t3839648117 * ___swapRequestStateAsk_20;
	// LP`1<GameManager.Match.Swap.WhoCanAskHolder/UIData> GameManager.Match.Swap.WhoCanAskAdapter/UIData::holders
	LP_1_t660031465 * ___holders_21;
	// System.Collections.Generic.List`1<Human> GameManager.Match.Swap.WhoCanAskAdapter/UIData::humans
	List_1_t525209625 * ___humans_22;

public:
	inline static int32_t get_offset_of_swapRequestStateAsk_20() { return static_cast<int32_t>(offsetof(UIData_t1902404260, ___swapRequestStateAsk_20)); }
	inline VP_1_t3839648117 * get_swapRequestStateAsk_20() const { return ___swapRequestStateAsk_20; }
	inline VP_1_t3839648117 ** get_address_of_swapRequestStateAsk_20() { return &___swapRequestStateAsk_20; }
	inline void set_swapRequestStateAsk_20(VP_1_t3839648117 * value)
	{
		___swapRequestStateAsk_20 = value;
		Il2CppCodeGenWriteBarrier(&___swapRequestStateAsk_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t1902404260, ___holders_21)); }
	inline LP_1_t660031465 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t660031465 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t660031465 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_humans_22() { return static_cast<int32_t>(offsetof(UIData_t1902404260, ___humans_22)); }
	inline List_1_t525209625 * get_humans_22() const { return ___humans_22; }
	inline List_1_t525209625 ** get_address_of_humans_22() { return &___humans_22; }
	inline void set_humans_22(List_1_t525209625 * value)
	{
		___humans_22 = value;
		Il2CppCodeGenWriteBarrier(&___humans_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
