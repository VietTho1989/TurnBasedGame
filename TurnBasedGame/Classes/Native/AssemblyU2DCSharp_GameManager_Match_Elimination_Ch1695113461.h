#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationContent>>
struct VP_1_t1792904301;
// LP`1<GameManager.Match.Elimination.ChooseEliminationRoundHolder/UIData>
struct LP_1_t3733746424;
// System.Collections.Generic.List`1<GameManager.Match.Elimination.EliminationRound>
struct List_1_t2516658387;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData
struct  UIData_t1695113461  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationContent>> GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData::eliminationContent
	VP_1_t1792904301 * ___eliminationContent_20;
	// LP`1<GameManager.Match.Elimination.ChooseEliminationRoundHolder/UIData> GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData::holders
	LP_1_t3733746424 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.Elimination.EliminationRound> GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData::eliminationRounds
	List_1_t2516658387 * ___eliminationRounds_22;

public:
	inline static int32_t get_offset_of_eliminationContent_20() { return static_cast<int32_t>(offsetof(UIData_t1695113461, ___eliminationContent_20)); }
	inline VP_1_t1792904301 * get_eliminationContent_20() const { return ___eliminationContent_20; }
	inline VP_1_t1792904301 ** get_address_of_eliminationContent_20() { return &___eliminationContent_20; }
	inline void set_eliminationContent_20(VP_1_t1792904301 * value)
	{
		___eliminationContent_20 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationContent_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t1695113461, ___holders_21)); }
	inline LP_1_t3733746424 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3733746424 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3733746424 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_eliminationRounds_22() { return static_cast<int32_t>(offsetof(UIData_t1695113461, ___eliminationRounds_22)); }
	inline List_1_t2516658387 * get_eliminationRounds_22() const { return ___eliminationRounds_22; }
	inline List_1_t2516658387 ** get_address_of_eliminationRounds_22() { return &___eliminationRounds_22; }
	inline void set_eliminationRounds_22(List_1_t2516658387 * value)
	{
		___eliminationRounds_22 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRounds_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
