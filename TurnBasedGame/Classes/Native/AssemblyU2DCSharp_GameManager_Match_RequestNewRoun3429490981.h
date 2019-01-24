#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.RequestNewRound>>
struct VP_1_t982030338;
// VP`1<GameManager.Match.RequestNewRoundInformUI/UIData/LimitUI>
struct VP_1_t4284542569;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundInformUI/UIData
struct  UIData_t3429490981  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RequestNewRound>> GameManager.Match.RequestNewRoundInformUI/UIData::requestNewRound
	VP_1_t982030338 * ___requestNewRound_5;
	// VP`1<GameManager.Match.RequestNewRoundInformUI/UIData/LimitUI> GameManager.Match.RequestNewRoundInformUI/UIData::limitUI
	VP_1_t4284542569 * ___limitUI_6;

public:
	inline static int32_t get_offset_of_requestNewRound_5() { return static_cast<int32_t>(offsetof(UIData_t3429490981, ___requestNewRound_5)); }
	inline VP_1_t982030338 * get_requestNewRound_5() const { return ___requestNewRound_5; }
	inline VP_1_t982030338 ** get_address_of_requestNewRound_5() { return &___requestNewRound_5; }
	inline void set_requestNewRound_5(VP_1_t982030338 * value)
	{
		___requestNewRound_5 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRound_5, value);
	}

	inline static int32_t get_offset_of_limitUI_6() { return static_cast<int32_t>(offsetof(UIData_t3429490981, ___limitUI_6)); }
	inline VP_1_t4284542569 * get_limitUI_6() const { return ___limitUI_6; }
	inline VP_1_t4284542569 ** get_address_of_limitUI_6() { return &___limitUI_6; }
	inline void set_limitUI_6(VP_1_t4284542569 * value)
	{
		___limitUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___limitUI_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
