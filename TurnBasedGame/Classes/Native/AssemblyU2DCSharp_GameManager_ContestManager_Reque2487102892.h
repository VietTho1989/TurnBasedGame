#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1796379067.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.ContestManager.WhoCanAskAdapter
struct WhoCanAskAdapter_t2749595768;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.ContestManager.RequestNewContestManagerAskBtnAcceptUI
struct RequestNewContestManagerAskBtnAcceptUI_t3081588969;
// GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI
struct RequestNewContestManagerAskBtnCancelUI_t2979862779;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.ContestManager.RequestNewContestManagerStateAskUI
struct  RequestNewContestManagerStateAskUI_t2487102892  : public UIBehavior_1_t1796379067
{
public:
	// UnityEngine.GameObject GameManager.ContestManager.RequestNewContestManagerStateAskUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Text GameManager.ContestManager.RequestNewContestManagerStateAskUI::tvVisibility
	Text_t356221433 * ___tvVisibility_7;
	// GameManager.ContestManager.WhoCanAskAdapter GameManager.ContestManager.RequestNewContestManagerStateAskUI::whoCanAskAdapterPrefab
	WhoCanAskAdapter_t2749595768 * ___whoCanAskAdapterPrefab_8;
	// UnityEngine.Transform GameManager.ContestManager.RequestNewContestManagerStateAskUI::whoCanAskAdapterContainer
	Transform_t3275118058 * ___whoCanAskAdapterContainer_9;
	// GameManager.ContestManager.RequestNewContestManagerAskBtnAcceptUI GameManager.ContestManager.RequestNewContestManagerStateAskUI::btnAcceptPrefab
	RequestNewContestManagerAskBtnAcceptUI_t3081588969 * ___btnAcceptPrefab_10;
	// GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI GameManager.ContestManager.RequestNewContestManagerStateAskUI::btnCancelPrefab
	RequestNewContestManagerAskBtnCancelUI_t2979862779 * ___btnCancelPrefab_11;
	// UnityEngine.Transform GameManager.ContestManager.RequestNewContestManagerStateAskUI::btnContainer
	Transform_t3275118058 * ___btnContainer_12;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_tvVisibility_7() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___tvVisibility_7)); }
	inline Text_t356221433 * get_tvVisibility_7() const { return ___tvVisibility_7; }
	inline Text_t356221433 ** get_address_of_tvVisibility_7() { return &___tvVisibility_7; }
	inline void set_tvVisibility_7(Text_t356221433 * value)
	{
		___tvVisibility_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvVisibility_7, value);
	}

	inline static int32_t get_offset_of_whoCanAskAdapterPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___whoCanAskAdapterPrefab_8)); }
	inline WhoCanAskAdapter_t2749595768 * get_whoCanAskAdapterPrefab_8() const { return ___whoCanAskAdapterPrefab_8; }
	inline WhoCanAskAdapter_t2749595768 ** get_address_of_whoCanAskAdapterPrefab_8() { return &___whoCanAskAdapterPrefab_8; }
	inline void set_whoCanAskAdapterPrefab_8(WhoCanAskAdapter_t2749595768 * value)
	{
		___whoCanAskAdapterPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAskAdapterPrefab_8, value);
	}

	inline static int32_t get_offset_of_whoCanAskAdapterContainer_9() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___whoCanAskAdapterContainer_9)); }
	inline Transform_t3275118058 * get_whoCanAskAdapterContainer_9() const { return ___whoCanAskAdapterContainer_9; }
	inline Transform_t3275118058 ** get_address_of_whoCanAskAdapterContainer_9() { return &___whoCanAskAdapterContainer_9; }
	inline void set_whoCanAskAdapterContainer_9(Transform_t3275118058 * value)
	{
		___whoCanAskAdapterContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAskAdapterContainer_9, value);
	}

	inline static int32_t get_offset_of_btnAcceptPrefab_10() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___btnAcceptPrefab_10)); }
	inline RequestNewContestManagerAskBtnAcceptUI_t3081588969 * get_btnAcceptPrefab_10() const { return ___btnAcceptPrefab_10; }
	inline RequestNewContestManagerAskBtnAcceptUI_t3081588969 ** get_address_of_btnAcceptPrefab_10() { return &___btnAcceptPrefab_10; }
	inline void set_btnAcceptPrefab_10(RequestNewContestManagerAskBtnAcceptUI_t3081588969 * value)
	{
		___btnAcceptPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___btnAcceptPrefab_10, value);
	}

	inline static int32_t get_offset_of_btnCancelPrefab_11() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___btnCancelPrefab_11)); }
	inline RequestNewContestManagerAskBtnCancelUI_t2979862779 * get_btnCancelPrefab_11() const { return ___btnCancelPrefab_11; }
	inline RequestNewContestManagerAskBtnCancelUI_t2979862779 ** get_address_of_btnCancelPrefab_11() { return &___btnCancelPrefab_11; }
	inline void set_btnCancelPrefab_11(RequestNewContestManagerAskBtnCancelUI_t2979862779 * value)
	{
		___btnCancelPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancelPrefab_11, value);
	}

	inline static int32_t get_offset_of_btnContainer_12() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUI_t2487102892, ___btnContainer_12)); }
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
