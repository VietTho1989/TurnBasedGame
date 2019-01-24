#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Swap_NoRequest1475119037.h"

// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>>
struct VP_1_t3658899499;
// VP`1<GamePlayer/Inform/Type>
struct VP_1_t2215072796;
// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData>
struct VP_1_t3571065865;
// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData>
struct VP_1_t2367412397;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerUI/UIData
struct  UIData_t1177005818  : public Sub_t1475119037
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>> GameManager.Match.Swap.AdminRequestSwapPlayerUI/UIData::teamPlayer
	VP_1_t3658899499 * ___teamPlayer_5;
	// VP`1<GamePlayer/Inform/Type> GameManager.Match.Swap.AdminRequestSwapPlayerUI/UIData::show
	VP_1_t2215072796 * ___show_6;
	// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData> GameManager.Match.Swap.AdminRequestSwapPlayerUI/UIData::human
	VP_1_t3571065865 * ___human_7;
	// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData> GameManager.Match.Swap.AdminRequestSwapPlayerUI/UIData::computer
	VP_1_t2367412397 * ___computer_8;

public:
	inline static int32_t get_offset_of_teamPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t1177005818, ___teamPlayer_5)); }
	inline VP_1_t3658899499 * get_teamPlayer_5() const { return ___teamPlayer_5; }
	inline VP_1_t3658899499 ** get_address_of_teamPlayer_5() { return &___teamPlayer_5; }
	inline void set_teamPlayer_5(VP_1_t3658899499 * value)
	{
		___teamPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamPlayer_5, value);
	}

	inline static int32_t get_offset_of_show_6() { return static_cast<int32_t>(offsetof(UIData_t1177005818, ___show_6)); }
	inline VP_1_t2215072796 * get_show_6() const { return ___show_6; }
	inline VP_1_t2215072796 ** get_address_of_show_6() { return &___show_6; }
	inline void set_show_6(VP_1_t2215072796 * value)
	{
		___show_6 = value;
		Il2CppCodeGenWriteBarrier(&___show_6, value);
	}

	inline static int32_t get_offset_of_human_7() { return static_cast<int32_t>(offsetof(UIData_t1177005818, ___human_7)); }
	inline VP_1_t3571065865 * get_human_7() const { return ___human_7; }
	inline VP_1_t3571065865 ** get_address_of_human_7() { return &___human_7; }
	inline void set_human_7(VP_1_t3571065865 * value)
	{
		___human_7 = value;
		Il2CppCodeGenWriteBarrier(&___human_7, value);
	}

	inline static int32_t get_offset_of_computer_8() { return static_cast<int32_t>(offsetof(UIData_t1177005818, ___computer_8)); }
	inline VP_1_t2367412397 * get_computer_8() const { return ___computer_8; }
	inline VP_1_t2367412397 ** get_address_of_computer_8() { return &___computer_8; }
	inline void set_computer_8(VP_1_t2367412397 * value)
	{
		___computer_8 = value;
		Il2CppCodeGenWriteBarrier(&___computer_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
