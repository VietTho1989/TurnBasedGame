#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.Contest>>
struct VP_1_t1875269615;
// VP`1<GameManager.Match.ChooseRoundAdapter/UIData>
struct VP_1_t1121192409;
// VP`1<GameManager.Match.RequestNewRoundInformUI/UIData>
struct VP_1_t3807767987;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundUI/UIData
struct  UIData_t3991930736  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Contest>> GameManager.Match.ChooseRoundUI/UIData::contest
	VP_1_t1875269615 * ___contest_5;
	// VP`1<GameManager.Match.ChooseRoundAdapter/UIData> GameManager.Match.ChooseRoundUI/UIData::chooseRoundAdapter
	VP_1_t1121192409 * ___chooseRoundAdapter_6;
	// VP`1<GameManager.Match.RequestNewRoundInformUI/UIData> GameManager.Match.ChooseRoundUI/UIData::requestNewRoundInformUIData
	VP_1_t3807767987 * ___requestNewRoundInformUIData_7;

public:
	inline static int32_t get_offset_of_contest_5() { return static_cast<int32_t>(offsetof(UIData_t3991930736, ___contest_5)); }
	inline VP_1_t1875269615 * get_contest_5() const { return ___contest_5; }
	inline VP_1_t1875269615 ** get_address_of_contest_5() { return &___contest_5; }
	inline void set_contest_5(VP_1_t1875269615 * value)
	{
		___contest_5 = value;
		Il2CppCodeGenWriteBarrier(&___contest_5, value);
	}

	inline static int32_t get_offset_of_chooseRoundAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t3991930736, ___chooseRoundAdapter_6)); }
	inline VP_1_t1121192409 * get_chooseRoundAdapter_6() const { return ___chooseRoundAdapter_6; }
	inline VP_1_t1121192409 ** get_address_of_chooseRoundAdapter_6() { return &___chooseRoundAdapter_6; }
	inline void set_chooseRoundAdapter_6(VP_1_t1121192409 * value)
	{
		___chooseRoundAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundAdapter_6, value);
	}

	inline static int32_t get_offset_of_requestNewRoundInformUIData_7() { return static_cast<int32_t>(offsetof(UIData_t3991930736, ___requestNewRoundInformUIData_7)); }
	inline VP_1_t3807767987 * get_requestNewRoundInformUIData_7() const { return ___requestNewRoundInformUIData_7; }
	inline VP_1_t3807767987 ** get_address_of_requestNewRoundInformUIData_7() { return &___requestNewRoundInformUIData_7; }
	inline void set_requestNewRoundInformUIData_7(VP_1_t3807767987 * value)
	{
		___requestNewRoundInformUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundInformUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
