#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2047815257.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// EmptyInformUI
struct EmptyInformUI_t539044954;
// HumanUI
struct HumanUI_t990511461;
// ComputerUI
struct ComputerUI_t1250452161;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.Swap.SwapRequestStateAskUI
struct SwapRequestStateAskUI_t1746527184;
// GameManager.Match.Swap.SwapRequestStateAcceptUI
struct SwapRequestStateAcceptUI_t2002878207;
// GameManager.Match.Swap.SwapRequestStateCancelUI
struct SwapRequestStateCancelUI_t2663517873;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.HaveRequestSwapPlayerUI
struct  HaveRequestSwapPlayerUI_t1879398137  : public UIBehavior_1_t2047815257
{
public:
	// UnityEngine.UI.Text GameManager.Match.Swap.HaveRequestSwapPlayerUI::tvPlayerIndex
	Text_t356221433 * ___tvPlayerIndex_6;
	// UnityEngine.UI.Text GameManager.Match.Swap.HaveRequestSwapPlayerUI::tvTeamIndex
	Text_t356221433 * ___tvTeamIndex_7;
	// EmptyInformUI GameManager.Match.Swap.HaveRequestSwapPlayerUI::emptyPrefab
	EmptyInformUI_t539044954 * ___emptyPrefab_8;
	// HumanUI GameManager.Match.Swap.HaveRequestSwapPlayerUI::humanPrefab
	HumanUI_t990511461 * ___humanPrefab_9;
	// ComputerUI GameManager.Match.Swap.HaveRequestSwapPlayerUI::computerPrefab
	ComputerUI_t1250452161 * ___computerPrefab_10;
	// UnityEngine.Transform GameManager.Match.Swap.HaveRequestSwapPlayerUI::informUIContainer
	Transform_t3275118058 * ___informUIContainer_11;
	// GameManager.Match.Swap.SwapRequestStateAskUI GameManager.Match.Swap.HaveRequestSwapPlayerUI::askPrefab
	SwapRequestStateAskUI_t1746527184 * ___askPrefab_12;
	// GameManager.Match.Swap.SwapRequestStateAcceptUI GameManager.Match.Swap.HaveRequestSwapPlayerUI::acceptPrefab
	SwapRequestStateAcceptUI_t2002878207 * ___acceptPrefab_13;
	// GameManager.Match.Swap.SwapRequestStateCancelUI GameManager.Match.Swap.HaveRequestSwapPlayerUI::cancelPrefab
	SwapRequestStateCancelUI_t2663517873 * ___cancelPrefab_14;
	// UnityEngine.Transform GameManager.Match.Swap.HaveRequestSwapPlayerUI::stateUIContainer
	Transform_t3275118058 * ___stateUIContainer_15;

public:
	inline static int32_t get_offset_of_tvPlayerIndex_6() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___tvPlayerIndex_6)); }
	inline Text_t356221433 * get_tvPlayerIndex_6() const { return ___tvPlayerIndex_6; }
	inline Text_t356221433 ** get_address_of_tvPlayerIndex_6() { return &___tvPlayerIndex_6; }
	inline void set_tvPlayerIndex_6(Text_t356221433 * value)
	{
		___tvPlayerIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvPlayerIndex_6, value);
	}

	inline static int32_t get_offset_of_tvTeamIndex_7() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___tvTeamIndex_7)); }
	inline Text_t356221433 * get_tvTeamIndex_7() const { return ___tvTeamIndex_7; }
	inline Text_t356221433 ** get_address_of_tvTeamIndex_7() { return &___tvTeamIndex_7; }
	inline void set_tvTeamIndex_7(Text_t356221433 * value)
	{
		___tvTeamIndex_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvTeamIndex_7, value);
	}

	inline static int32_t get_offset_of_emptyPrefab_8() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___emptyPrefab_8)); }
	inline EmptyInformUI_t539044954 * get_emptyPrefab_8() const { return ___emptyPrefab_8; }
	inline EmptyInformUI_t539044954 ** get_address_of_emptyPrefab_8() { return &___emptyPrefab_8; }
	inline void set_emptyPrefab_8(EmptyInformUI_t539044954 * value)
	{
		___emptyPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___emptyPrefab_8, value);
	}

	inline static int32_t get_offset_of_humanPrefab_9() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___humanPrefab_9)); }
	inline HumanUI_t990511461 * get_humanPrefab_9() const { return ___humanPrefab_9; }
	inline HumanUI_t990511461 ** get_address_of_humanPrefab_9() { return &___humanPrefab_9; }
	inline void set_humanPrefab_9(HumanUI_t990511461 * value)
	{
		___humanPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___humanPrefab_9, value);
	}

	inline static int32_t get_offset_of_computerPrefab_10() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___computerPrefab_10)); }
	inline ComputerUI_t1250452161 * get_computerPrefab_10() const { return ___computerPrefab_10; }
	inline ComputerUI_t1250452161 ** get_address_of_computerPrefab_10() { return &___computerPrefab_10; }
	inline void set_computerPrefab_10(ComputerUI_t1250452161 * value)
	{
		___computerPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___computerPrefab_10, value);
	}

	inline static int32_t get_offset_of_informUIContainer_11() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___informUIContainer_11)); }
	inline Transform_t3275118058 * get_informUIContainer_11() const { return ___informUIContainer_11; }
	inline Transform_t3275118058 ** get_address_of_informUIContainer_11() { return &___informUIContainer_11; }
	inline void set_informUIContainer_11(Transform_t3275118058 * value)
	{
		___informUIContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___informUIContainer_11, value);
	}

	inline static int32_t get_offset_of_askPrefab_12() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___askPrefab_12)); }
	inline SwapRequestStateAskUI_t1746527184 * get_askPrefab_12() const { return ___askPrefab_12; }
	inline SwapRequestStateAskUI_t1746527184 ** get_address_of_askPrefab_12() { return &___askPrefab_12; }
	inline void set_askPrefab_12(SwapRequestStateAskUI_t1746527184 * value)
	{
		___askPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_12, value);
	}

	inline static int32_t get_offset_of_acceptPrefab_13() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___acceptPrefab_13)); }
	inline SwapRequestStateAcceptUI_t2002878207 * get_acceptPrefab_13() const { return ___acceptPrefab_13; }
	inline SwapRequestStateAcceptUI_t2002878207 ** get_address_of_acceptPrefab_13() { return &___acceptPrefab_13; }
	inline void set_acceptPrefab_13(SwapRequestStateAcceptUI_t2002878207 * value)
	{
		___acceptPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___acceptPrefab_13, value);
	}

	inline static int32_t get_offset_of_cancelPrefab_14() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___cancelPrefab_14)); }
	inline SwapRequestStateCancelUI_t2663517873 * get_cancelPrefab_14() const { return ___cancelPrefab_14; }
	inline SwapRequestStateCancelUI_t2663517873 ** get_address_of_cancelPrefab_14() { return &___cancelPrefab_14; }
	inline void set_cancelPrefab_14(SwapRequestStateCancelUI_t2663517873 * value)
	{
		___cancelPrefab_14 = value;
		Il2CppCodeGenWriteBarrier(&___cancelPrefab_14, value);
	}

	inline static int32_t get_offset_of_stateUIContainer_15() { return static_cast<int32_t>(offsetof(HaveRequestSwapPlayerUI_t1879398137, ___stateUIContainer_15)); }
	inline Transform_t3275118058 * get_stateUIContainer_15() const { return ___stateUIContainer_15; }
	inline Transform_t3275118058 ** get_address_of_stateUIContainer_15() { return &___stateUIContainer_15; }
	inline void set_stateUIContainer_15(Transform_t3275118058 * value)
	{
		___stateUIContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___stateUIContainer_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
