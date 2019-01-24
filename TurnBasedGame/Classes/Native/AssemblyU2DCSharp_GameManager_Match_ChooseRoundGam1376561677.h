#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Round>>
struct VP_1_t3178215331;
// LP`1<GameManager.Match.ChooseRoundGameHolder/UIData>
struct LP_1_t3180524210;
// System.Collections.Generic.List`1<GameManager.Match.RoundGame>
struct List_1_t2399185004;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundGameAdapter/UIData
struct  UIData_t1376561677  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Round>> GameManager.Match.ChooseRoundGameAdapter/UIData::round
	VP_1_t3178215331 * ___round_20;
	// LP`1<GameManager.Match.ChooseRoundGameHolder/UIData> GameManager.Match.ChooseRoundGameAdapter/UIData::holders
	LP_1_t3180524210 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.RoundGame> GameManager.Match.ChooseRoundGameAdapter/UIData::roundGames
	List_1_t2399185004 * ___roundGames_22;

public:
	inline static int32_t get_offset_of_round_20() { return static_cast<int32_t>(offsetof(UIData_t1376561677, ___round_20)); }
	inline VP_1_t3178215331 * get_round_20() const { return ___round_20; }
	inline VP_1_t3178215331 ** get_address_of_round_20() { return &___round_20; }
	inline void set_round_20(VP_1_t3178215331 * value)
	{
		___round_20 = value;
		Il2CppCodeGenWriteBarrier(&___round_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t1376561677, ___holders_21)); }
	inline LP_1_t3180524210 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3180524210 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3180524210 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_roundGames_22() { return static_cast<int32_t>(offsetof(UIData_t1376561677, ___roundGames_22)); }
	inline List_1_t2399185004 * get_roundGames_22() const { return ___roundGames_22; }
	inline List_1_t2399185004 ** get_address_of_roundGames_22() { return &___roundGames_22; }
	inline void set_roundGames_22(List_1_t2399185004 * value)
	{
		___roundGames_22 = value;
		Il2CppCodeGenWriteBarrier(&___roundGames_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
