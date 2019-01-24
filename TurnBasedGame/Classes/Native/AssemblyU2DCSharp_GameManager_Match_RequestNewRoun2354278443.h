#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2057501786.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.WhoCanAskAdapter
struct WhoCanAskAdapter_t1757043496;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.RequestNewRoundAskBtnAcceptUI
struct RequestNewRoundAskBtnAcceptUI_t4081273244;
// GameManager.Match.RequestNewRoundAskBtnCancelUI
struct RequestNewRoundAskBtnCancelUI_t3717245674;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundStateAskUI
struct  RequestNewRoundStateAskUI_t2354278443  : public UIBehavior_1_t2057501786
{
public:
	// UnityEngine.GameObject GameManager.Match.RequestNewRoundStateAskUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Text GameManager.Match.RequestNewRoundStateAskUI::tvVisibility
	Text_t356221433 * ___tvVisibility_7;
	// GameManager.Match.WhoCanAskAdapter GameManager.Match.RequestNewRoundStateAskUI::whoCanAskAdapterPrefab
	WhoCanAskAdapter_t1757043496 * ___whoCanAskAdapterPrefab_8;
	// UnityEngine.Transform GameManager.Match.RequestNewRoundStateAskUI::whoCanAskAdapterContainer
	Transform_t3275118058 * ___whoCanAskAdapterContainer_9;
	// GameManager.Match.RequestNewRoundAskBtnAcceptUI GameManager.Match.RequestNewRoundStateAskUI::btnAcceptPrefab
	RequestNewRoundAskBtnAcceptUI_t4081273244 * ___btnAcceptPrefab_10;
	// GameManager.Match.RequestNewRoundAskBtnCancelUI GameManager.Match.RequestNewRoundStateAskUI::btnCancelPrefab
	RequestNewRoundAskBtnCancelUI_t3717245674 * ___btnCancelPrefab_11;
	// UnityEngine.Transform GameManager.Match.RequestNewRoundStateAskUI::btnContainer
	Transform_t3275118058 * ___btnContainer_12;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_tvVisibility_7() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___tvVisibility_7)); }
	inline Text_t356221433 * get_tvVisibility_7() const { return ___tvVisibility_7; }
	inline Text_t356221433 ** get_address_of_tvVisibility_7() { return &___tvVisibility_7; }
	inline void set_tvVisibility_7(Text_t356221433 * value)
	{
		___tvVisibility_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvVisibility_7, value);
	}

	inline static int32_t get_offset_of_whoCanAskAdapterPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___whoCanAskAdapterPrefab_8)); }
	inline WhoCanAskAdapter_t1757043496 * get_whoCanAskAdapterPrefab_8() const { return ___whoCanAskAdapterPrefab_8; }
	inline WhoCanAskAdapter_t1757043496 ** get_address_of_whoCanAskAdapterPrefab_8() { return &___whoCanAskAdapterPrefab_8; }
	inline void set_whoCanAskAdapterPrefab_8(WhoCanAskAdapter_t1757043496 * value)
	{
		___whoCanAskAdapterPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAskAdapterPrefab_8, value);
	}

	inline static int32_t get_offset_of_whoCanAskAdapterContainer_9() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___whoCanAskAdapterContainer_9)); }
	inline Transform_t3275118058 * get_whoCanAskAdapterContainer_9() const { return ___whoCanAskAdapterContainer_9; }
	inline Transform_t3275118058 ** get_address_of_whoCanAskAdapterContainer_9() { return &___whoCanAskAdapterContainer_9; }
	inline void set_whoCanAskAdapterContainer_9(Transform_t3275118058 * value)
	{
		___whoCanAskAdapterContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAskAdapterContainer_9, value);
	}

	inline static int32_t get_offset_of_btnAcceptPrefab_10() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___btnAcceptPrefab_10)); }
	inline RequestNewRoundAskBtnAcceptUI_t4081273244 * get_btnAcceptPrefab_10() const { return ___btnAcceptPrefab_10; }
	inline RequestNewRoundAskBtnAcceptUI_t4081273244 ** get_address_of_btnAcceptPrefab_10() { return &___btnAcceptPrefab_10; }
	inline void set_btnAcceptPrefab_10(RequestNewRoundAskBtnAcceptUI_t4081273244 * value)
	{
		___btnAcceptPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___btnAcceptPrefab_10, value);
	}

	inline static int32_t get_offset_of_btnCancelPrefab_11() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___btnCancelPrefab_11)); }
	inline RequestNewRoundAskBtnCancelUI_t3717245674 * get_btnCancelPrefab_11() const { return ___btnCancelPrefab_11; }
	inline RequestNewRoundAskBtnCancelUI_t3717245674 ** get_address_of_btnCancelPrefab_11() { return &___btnCancelPrefab_11; }
	inline void set_btnCancelPrefab_11(RequestNewRoundAskBtnCancelUI_t3717245674 * value)
	{
		___btnCancelPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancelPrefab_11, value);
	}

	inline static int32_t get_offset_of_btnContainer_12() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUI_t2354278443, ___btnContainer_12)); }
	inline Transform_t3275118058 * get_btnContainer_12() const { return ___btnContainer_12; }
	inline Transform_t3275118058 ** get_address_of_btnContainer_12() { return &___btnContainer_12; }
	inline void set_btnContainer_12(Transform_t3275118058 * value)
	{
		___btnContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___btnContainer_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
