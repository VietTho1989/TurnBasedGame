#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen835421174.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.Transform
struct Transform_t3275118058;
// WaitHumanInputUI
struct WaitHumanInputUI_t4263887976;
// WaitAIInputUI
struct WaitAIInputUI_t1572023195;
// ClientInputUI
struct ClientInputUI_t403850141;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitInputActionUI
struct  WaitInputActionUI_t2098345273  : public UIBehavior_1_t835421174
{
public:
	// UnityEngine.UI.Text WaitInputActionUI::tvServerTime
	Text_t356221433 * ___tvServerTime_6;
	// UnityEngine.UI.Text WaitInputActionUI::tvClientTime
	Text_t356221433 * ___tvClientTime_7;
	// UnityEngine.UI.Text WaitInputActionUI::tvCheckLegalMove
	Text_t356221433 * ___tvCheckLegalMove_8;
	// UnityEngine.Transform WaitInputActionUI::subContainer
	Transform_t3275118058 * ___subContainer_9;
	// WaitHumanInputUI WaitInputActionUI::waitHumanInputUIPrefab
	WaitHumanInputUI_t4263887976 * ___waitHumanInputUIPrefab_10;
	// WaitAIInputUI WaitInputActionUI::waitAIInputUIPrefab
	WaitAIInputUI_t1572023195 * ___waitAIInputUIPrefab_11;
	// UnityEngine.Transform WaitInputActionUI::clientInputUIContainer
	Transform_t3275118058 * ___clientInputUIContainer_12;
	// ClientInputUI WaitInputActionUI::clientInputUIPrefab
	ClientInputUI_t403850141 * ___clientInputUIPrefab_13;

public:
	inline static int32_t get_offset_of_tvServerTime_6() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___tvServerTime_6)); }
	inline Text_t356221433 * get_tvServerTime_6() const { return ___tvServerTime_6; }
	inline Text_t356221433 ** get_address_of_tvServerTime_6() { return &___tvServerTime_6; }
	inline void set_tvServerTime_6(Text_t356221433 * value)
	{
		___tvServerTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvServerTime_6, value);
	}

	inline static int32_t get_offset_of_tvClientTime_7() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___tvClientTime_7)); }
	inline Text_t356221433 * get_tvClientTime_7() const { return ___tvClientTime_7; }
	inline Text_t356221433 ** get_address_of_tvClientTime_7() { return &___tvClientTime_7; }
	inline void set_tvClientTime_7(Text_t356221433 * value)
	{
		___tvClientTime_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvClientTime_7, value);
	}

	inline static int32_t get_offset_of_tvCheckLegalMove_8() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___tvCheckLegalMove_8)); }
	inline Text_t356221433 * get_tvCheckLegalMove_8() const { return ___tvCheckLegalMove_8; }
	inline Text_t356221433 ** get_address_of_tvCheckLegalMove_8() { return &___tvCheckLegalMove_8; }
	inline void set_tvCheckLegalMove_8(Text_t356221433 * value)
	{
		___tvCheckLegalMove_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvCheckLegalMove_8, value);
	}

	inline static int32_t get_offset_of_subContainer_9() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___subContainer_9)); }
	inline Transform_t3275118058 * get_subContainer_9() const { return ___subContainer_9; }
	inline Transform_t3275118058 ** get_address_of_subContainer_9() { return &___subContainer_9; }
	inline void set_subContainer_9(Transform_t3275118058 * value)
	{
		___subContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_9, value);
	}

	inline static int32_t get_offset_of_waitHumanInputUIPrefab_10() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___waitHumanInputUIPrefab_10)); }
	inline WaitHumanInputUI_t4263887976 * get_waitHumanInputUIPrefab_10() const { return ___waitHumanInputUIPrefab_10; }
	inline WaitHumanInputUI_t4263887976 ** get_address_of_waitHumanInputUIPrefab_10() { return &___waitHumanInputUIPrefab_10; }
	inline void set_waitHumanInputUIPrefab_10(WaitHumanInputUI_t4263887976 * value)
	{
		___waitHumanInputUIPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___waitHumanInputUIPrefab_10, value);
	}

	inline static int32_t get_offset_of_waitAIInputUIPrefab_11() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___waitAIInputUIPrefab_11)); }
	inline WaitAIInputUI_t1572023195 * get_waitAIInputUIPrefab_11() const { return ___waitAIInputUIPrefab_11; }
	inline WaitAIInputUI_t1572023195 ** get_address_of_waitAIInputUIPrefab_11() { return &___waitAIInputUIPrefab_11; }
	inline void set_waitAIInputUIPrefab_11(WaitAIInputUI_t1572023195 * value)
	{
		___waitAIInputUIPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___waitAIInputUIPrefab_11, value);
	}

	inline static int32_t get_offset_of_clientInputUIContainer_12() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___clientInputUIContainer_12)); }
	inline Transform_t3275118058 * get_clientInputUIContainer_12() const { return ___clientInputUIContainer_12; }
	inline Transform_t3275118058 ** get_address_of_clientInputUIContainer_12() { return &___clientInputUIContainer_12; }
	inline void set_clientInputUIContainer_12(Transform_t3275118058 * value)
	{
		___clientInputUIContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___clientInputUIContainer_12, value);
	}

	inline static int32_t get_offset_of_clientInputUIPrefab_13() { return static_cast<int32_t>(offsetof(WaitInputActionUI_t2098345273, ___clientInputUIPrefab_13)); }
	inline ClientInputUI_t403850141 * get_clientInputUIPrefab_13() const { return ___clientInputUIPrefab_13; }
	inline ClientInputUI_t403850141 ** get_address_of_clientInputUIPrefab_13() { return &___clientInputUIPrefab_13; }
	inline void set_clientInputUIPrefab_13(ClientInputUI_t403850141 * value)
	{
		___clientInputUIPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___clientInputUIPrefab_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
