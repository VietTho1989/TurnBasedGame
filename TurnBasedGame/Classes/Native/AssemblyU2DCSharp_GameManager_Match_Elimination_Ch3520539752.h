#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationContent>>
struct VP_1_t1792904301;
// VP`1<GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData>
struct VP_1_t2073390467;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseEliminationRoundUI/UIData
struct  UIData_t3520539752  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationContent>> GameManager.Match.Elimination.ChooseEliminationRoundUI/UIData::eliminationContent
	VP_1_t1792904301 * ___eliminationContent_5;
	// VP`1<GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData> GameManager.Match.Elimination.ChooseEliminationRoundUI/UIData::chooseEliminationRoundAdapter
	VP_1_t2073390467 * ___chooseEliminationRoundAdapter_6;

public:
	inline static int32_t get_offset_of_eliminationContent_5() { return static_cast<int32_t>(offsetof(UIData_t3520539752, ___eliminationContent_5)); }
	inline VP_1_t1792904301 * get_eliminationContent_5() const { return ___eliminationContent_5; }
	inline VP_1_t1792904301 ** get_address_of_eliminationContent_5() { return &___eliminationContent_5; }
	inline void set_eliminationContent_5(VP_1_t1792904301 * value)
	{
		___eliminationContent_5 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationContent_5, value);
	}

	inline static int32_t get_offset_of_chooseEliminationRoundAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t3520539752, ___chooseEliminationRoundAdapter_6)); }
	inline VP_1_t2073390467 * get_chooseEliminationRoundAdapter_6() const { return ___chooseEliminationRoundAdapter_6; }
	inline VP_1_t2073390467 ** get_address_of_chooseEliminationRoundAdapter_6() { return &___chooseEliminationRoundAdapter_6; }
	inline void set_chooseEliminationRoundAdapter_6(VP_1_t2073390467 * value)
	{
		___chooseEliminationRoundAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseEliminationRoundAdapter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
