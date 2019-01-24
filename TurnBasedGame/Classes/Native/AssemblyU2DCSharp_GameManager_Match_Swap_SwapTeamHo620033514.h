#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen900501847.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.Swap.SwapPlayerUI
struct SwapPlayerUI_t2383735516;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapTeamHolder
struct  SwapTeamHolder_t620033514  : public SriaHolderBehavior_1_t900501847
{
public:
	// UnityEngine.UI.Text GameManager.Match.Swap.SwapTeamHolder::tvTeamIndex
	Text_t356221433 * ___tvTeamIndex_16;
	// GameManager.Match.Swap.SwapPlayerUI GameManager.Match.Swap.SwapTeamHolder::swapPlayerPrefab
	SwapPlayerUI_t2383735516 * ___swapPlayerPrefab_17;
	// UnityEngine.Transform GameManager.Match.Swap.SwapTeamHolder::swapPlayerContainer
	Transform_t3275118058 * ___swapPlayerContainer_18;

public:
	inline static int32_t get_offset_of_tvTeamIndex_16() { return static_cast<int32_t>(offsetof(SwapTeamHolder_t620033514, ___tvTeamIndex_16)); }
	inline Text_t356221433 * get_tvTeamIndex_16() const { return ___tvTeamIndex_16; }
	inline Text_t356221433 ** get_address_of_tvTeamIndex_16() { return &___tvTeamIndex_16; }
	inline void set_tvTeamIndex_16(Text_t356221433 * value)
	{
		___tvTeamIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvTeamIndex_16, value);
	}

	inline static int32_t get_offset_of_swapPlayerPrefab_17() { return static_cast<int32_t>(offsetof(SwapTeamHolder_t620033514, ___swapPlayerPrefab_17)); }
	inline SwapPlayerUI_t2383735516 * get_swapPlayerPrefab_17() const { return ___swapPlayerPrefab_17; }
	inline SwapPlayerUI_t2383735516 ** get_address_of_swapPlayerPrefab_17() { return &___swapPlayerPrefab_17; }
	inline void set_swapPlayerPrefab_17(SwapPlayerUI_t2383735516 * value)
	{
		___swapPlayerPrefab_17 = value;
		Il2CppCodeGenWriteBarrier(&___swapPlayerPrefab_17, value);
	}

	inline static int32_t get_offset_of_swapPlayerContainer_18() { return static_cast<int32_t>(offsetof(SwapTeamHolder_t620033514, ___swapPlayerContainer_18)); }
	inline Transform_t3275118058 * get_swapPlayerContainer_18() const { return ___swapPlayerContainer_18; }
	inline Transform_t3275118058 ** get_address_of_swapPlayerContainer_18() { return &___swapPlayerContainer_18; }
	inline void set_swapPlayerContainer_18(Transform_t3275118058 * value)
	{
		___swapPlayerContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___swapPlayerContainer_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
