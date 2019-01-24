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
// VP`1<GameManager.Match.RequestNewRoundUI/UIData/Sub>
struct VP_1_t2974226557;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundUI/UIData
struct  UIData_t842891104  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RequestNewRound>> GameManager.Match.RequestNewRoundUI/UIData::requestNewRound
	VP_1_t982030338 * ___requestNewRound_5;
	// VP`1<GameManager.Match.RequestNewRoundUI/UIData/Sub> GameManager.Match.RequestNewRoundUI/UIData::sub
	VP_1_t2974226557 * ___sub_6;

public:
	inline static int32_t get_offset_of_requestNewRound_5() { return static_cast<int32_t>(offsetof(UIData_t842891104, ___requestNewRound_5)); }
	inline VP_1_t982030338 * get_requestNewRound_5() const { return ___requestNewRound_5; }
	inline VP_1_t982030338 ** get_address_of_requestNewRound_5() { return &___requestNewRound_5; }
	inline void set_requestNewRound_5(VP_1_t982030338 * value)
	{
		___requestNewRound_5 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRound_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t842891104, ___sub_6)); }
	inline VP_1_t2974226557 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2974226557 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2974226557 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
