#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// GameManager.Match.RequestNewRoundStateNone
struct RequestNewRoundStateNone_t3006680492;
// GameManager.Match.Contest
struct Contest_t2426209546;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.CheckCanMakeNewRoundChange`1<GameManager.Match.RequestNewRoundStateNone>
struct  CheckCanMakeNewRoundChange_1_t134180888  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.CheckCanMakeNewRoundChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K GameManager.Match.CheckCanMakeNewRoundChange`1::data
	RequestNewRoundStateNone_t3006680492 * ___data_6;
	// GameManager.Match.Contest GameManager.Match.CheckCanMakeNewRoundChange`1::contest
	Contest_t2426209546 * ___contest_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(CheckCanMakeNewRoundChange_1_t134180888, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(CheckCanMakeNewRoundChange_1_t134180888, ___data_6)); }
	inline RequestNewRoundStateNone_t3006680492 * get_data_6() const { return ___data_6; }
	inline RequestNewRoundStateNone_t3006680492 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(RequestNewRoundStateNone_t3006680492 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_contest_7() { return static_cast<int32_t>(offsetof(CheckCanMakeNewRoundChange_1_t134180888, ___contest_7)); }
	inline Contest_t2426209546 * get_contest_7() const { return ___contest_7; }
	inline Contest_t2426209546 ** get_address_of_contest_7() { return &___contest_7; }
	inline void set_contest_7(Contest_t2426209546 * value)
	{
		___contest_7 = value;
		Il2CppCodeGenWriteBarrier(&___contest_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
