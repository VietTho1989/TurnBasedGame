#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk>>
struct VP_1_t3854964077;
// LP`1<GameManager.Match.Elimination.WhoCanAskHolder/UIData>
struct LP_1_t1341521315;
// System.Collections.Generic.List`1<Human>
struct List_1_t525209625;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.WhoCanAskAdapter/UIData
struct  UIData_t3892698598  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk>> GameManager.Match.Elimination.WhoCanAskAdapter/UIData::requestNewEliminationRoundStateAsk
	VP_1_t3854964077 * ___requestNewEliminationRoundStateAsk_20;
	// LP`1<GameManager.Match.Elimination.WhoCanAskHolder/UIData> GameManager.Match.Elimination.WhoCanAskAdapter/UIData::holders
	LP_1_t1341521315 * ___holders_21;
	// System.Collections.Generic.List`1<Human> GameManager.Match.Elimination.WhoCanAskAdapter/UIData::humans
	List_1_t525209625 * ___humans_22;

public:
	inline static int32_t get_offset_of_requestNewEliminationRoundStateAsk_20() { return static_cast<int32_t>(offsetof(UIData_t3892698598, ___requestNewEliminationRoundStateAsk_20)); }
	inline VP_1_t3854964077 * get_requestNewEliminationRoundStateAsk_20() const { return ___requestNewEliminationRoundStateAsk_20; }
	inline VP_1_t3854964077 ** get_address_of_requestNewEliminationRoundStateAsk_20() { return &___requestNewEliminationRoundStateAsk_20; }
	inline void set_requestNewEliminationRoundStateAsk_20(VP_1_t3854964077 * value)
	{
		___requestNewEliminationRoundStateAsk_20 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewEliminationRoundStateAsk_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t3892698598, ___holders_21)); }
	inline LP_1_t1341521315 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t1341521315 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t1341521315 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_humans_22() { return static_cast<int32_t>(offsetof(UIData_t3892698598, ___humans_22)); }
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
