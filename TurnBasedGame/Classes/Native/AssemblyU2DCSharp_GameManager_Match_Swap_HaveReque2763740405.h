#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Swap_SwapPlayer626118672.h"

// VP`1<ReferenceData`1<GameManager.Match.Swap.SwapRequest>>
struct VP_1_t3453884191;
// VP`1<InformUI>
struct VP_1_t1548385733;
// VP`1<GameManager.Match.Swap.HaveRequestSwapPlayerUI/UIData/StateUI>
struct VP_1_t3033608279;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.HaveRequestSwapPlayerUI/UIData
struct  UIData_t2763740405  : public Sub_t626118672
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Swap.SwapRequest>> GameManager.Match.Swap.HaveRequestSwapPlayerUI/UIData::swapRequest
	VP_1_t3453884191 * ___swapRequest_5;
	// VP`1<InformUI> GameManager.Match.Swap.HaveRequestSwapPlayerUI/UIData::informUI
	VP_1_t1548385733 * ___informUI_6;
	// VP`1<GameManager.Match.Swap.HaveRequestSwapPlayerUI/UIData/StateUI> GameManager.Match.Swap.HaveRequestSwapPlayerUI/UIData::stateUI
	VP_1_t3033608279 * ___stateUI_7;

public:
	inline static int32_t get_offset_of_swapRequest_5() { return static_cast<int32_t>(offsetof(UIData_t2763740405, ___swapRequest_5)); }
	inline VP_1_t3453884191 * get_swapRequest_5() const { return ___swapRequest_5; }
	inline VP_1_t3453884191 ** get_address_of_swapRequest_5() { return &___swapRequest_5; }
	inline void set_swapRequest_5(VP_1_t3453884191 * value)
	{
		___swapRequest_5 = value;
		Il2CppCodeGenWriteBarrier(&___swapRequest_5, value);
	}

	inline static int32_t get_offset_of_informUI_6() { return static_cast<int32_t>(offsetof(UIData_t2763740405, ___informUI_6)); }
	inline VP_1_t1548385733 * get_informUI_6() const { return ___informUI_6; }
	inline VP_1_t1548385733 ** get_address_of_informUI_6() { return &___informUI_6; }
	inline void set_informUI_6(VP_1_t1548385733 * value)
	{
		___informUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___informUI_6, value);
	}

	inline static int32_t get_offset_of_stateUI_7() { return static_cast<int32_t>(offsetof(UIData_t2763740405, ___stateUI_7)); }
	inline VP_1_t3033608279 * get_stateUI_7() const { return ___stateUI_7; }
	inline VP_1_t3033608279 ** get_address_of_stateUI_7() { return &___stateUI_7; }
	inline void set_stateUI_7(VP_1_t3033608279 * value)
	{
		___stateUI_7 = value;
		Il2CppCodeGenWriteBarrier(&___stateUI_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
