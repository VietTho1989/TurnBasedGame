#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk>>
struct VP_1_t18586250;
// LP`1<GameManager.Match.RoundRobin.WhoCanAskHolder/UIData>
struct LP_1_t1065456190;
// System.Collections.Generic.List`1<Human>
struct List_1_t525209625;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.WhoCanAskAdapter/UIData
struct  UIData_t3625680721  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk>> GameManager.Match.RoundRobin.WhoCanAskAdapter/UIData::requestNewRoundRobinStateAsk
	VP_1_t18586250 * ___requestNewRoundRobinStateAsk_20;
	// LP`1<GameManager.Match.RoundRobin.WhoCanAskHolder/UIData> GameManager.Match.RoundRobin.WhoCanAskAdapter/UIData::holders
	LP_1_t1065456190 * ___holders_21;
	// System.Collections.Generic.List`1<Human> GameManager.Match.RoundRobin.WhoCanAskAdapter/UIData::humans
	List_1_t525209625 * ___humans_22;

public:
	inline static int32_t get_offset_of_requestNewRoundRobinStateAsk_20() { return static_cast<int32_t>(offsetof(UIData_t3625680721, ___requestNewRoundRobinStateAsk_20)); }
	inline VP_1_t18586250 * get_requestNewRoundRobinStateAsk_20() const { return ___requestNewRoundRobinStateAsk_20; }
	inline VP_1_t18586250 ** get_address_of_requestNewRoundRobinStateAsk_20() { return &___requestNewRoundRobinStateAsk_20; }
	inline void set_requestNewRoundRobinStateAsk_20(VP_1_t18586250 * value)
	{
		___requestNewRoundRobinStateAsk_20 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundRobinStateAsk_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t3625680721, ___holders_21)); }
	inline LP_1_t1065456190 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t1065456190 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t1065456190 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_humans_22() { return static_cast<int32_t>(offsetof(UIData_t3625680721, ___humans_22)); }
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
