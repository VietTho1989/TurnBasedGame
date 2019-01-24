#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>>
struct VP_1_t3658899499;
// VP`1<InformUI>
struct VP_1_t1548385733;
// VP`1<GameManager.Match.Swap.SwapPlayerInformUI/UIData/Sub>
struct VP_1_t1004395678;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapPlayerInformUI/UIData
struct  UIData_t489476107  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>> GameManager.Match.Swap.SwapPlayerInformUI/UIData::teamPlayer
	VP_1_t3658899499 * ___teamPlayer_5;
	// VP`1<InformUI> GameManager.Match.Swap.SwapPlayerInformUI/UIData::informUI
	VP_1_t1548385733 * ___informUI_6;
	// VP`1<GameManager.Match.Swap.SwapPlayerInformUI/UIData/Sub> GameManager.Match.Swap.SwapPlayerInformUI/UIData::sub
	VP_1_t1004395678 * ___sub_7;

public:
	inline static int32_t get_offset_of_teamPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t489476107, ___teamPlayer_5)); }
	inline VP_1_t3658899499 * get_teamPlayer_5() const { return ___teamPlayer_5; }
	inline VP_1_t3658899499 ** get_address_of_teamPlayer_5() { return &___teamPlayer_5; }
	inline void set_teamPlayer_5(VP_1_t3658899499 * value)
	{
		___teamPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamPlayer_5, value);
	}

	inline static int32_t get_offset_of_informUI_6() { return static_cast<int32_t>(offsetof(UIData_t489476107, ___informUI_6)); }
	inline VP_1_t1548385733 * get_informUI_6() const { return ___informUI_6; }
	inline VP_1_t1548385733 ** get_address_of_informUI_6() { return &___informUI_6; }
	inline void set_informUI_6(VP_1_t1548385733 * value)
	{
		___informUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___informUI_6, value);
	}

	inline static int32_t get_offset_of_sub_7() { return static_cast<int32_t>(offsetof(UIData_t489476107, ___sub_7)); }
	inline VP_1_t1004395678 * get_sub_7() const { return ___sub_7; }
	inline VP_1_t1004395678 ** get_address_of_sub_7() { return &___sub_7; }
	inline void set_sub_7(VP_1_t1004395678 * value)
	{
		___sub_7 = value;
		Il2CppCodeGenWriteBarrier(&___sub_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
