#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>>
struct VP_1_t3658899499;
// LP`1<GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanHolder/UIData>
struct LP_1_t1300646462;
// System.Collections.Generic.List`1<Human>
struct List_1_t525209625;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter/UIData
struct  UIData_t2547446721  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>> GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter/UIData::teamPlayer
	VP_1_t3658899499 * ___teamPlayer_20;
	// LP`1<GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanHolder/UIData> GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter/UIData::holders
	LP_1_t1300646462 * ___holders_21;
	// System.Collections.Generic.List`1<Human> GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter/UIData::humans
	List_1_t525209625 * ___humans_22;

public:
	inline static int32_t get_offset_of_teamPlayer_20() { return static_cast<int32_t>(offsetof(UIData_t2547446721, ___teamPlayer_20)); }
	inline VP_1_t3658899499 * get_teamPlayer_20() const { return ___teamPlayer_20; }
	inline VP_1_t3658899499 ** get_address_of_teamPlayer_20() { return &___teamPlayer_20; }
	inline void set_teamPlayer_20(VP_1_t3658899499 * value)
	{
		___teamPlayer_20 = value;
		Il2CppCodeGenWriteBarrier(&___teamPlayer_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t2547446721, ___holders_21)); }
	inline LP_1_t1300646462 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t1300646462 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t1300646462 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_humans_22() { return static_cast<int32_t>(offsetof(UIData_t2547446721, ___humans_22)); }
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
