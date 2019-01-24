#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2801892952.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameManager.Match.Swap.WhoCanAskAdapter
struct WhoCanAskAdapter_t1998236408;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAskUI
struct  SwapRequestStateAskUI_t1746527184  : public UIBehavior_1_t2801892952
{
public:
	// UnityEngine.GameObject GameManager.Match.Swap.SwapRequestStateAskUI::btnContainer
	GameObject_t1756533147 * ___btnContainer_6;
	// UnityEngine.UI.Button GameManager.Match.Swap.SwapRequestStateAskUI::btnAccept
	Button_t2872111280 * ___btnAccept_7;
	// UnityEngine.UI.Text GameManager.Match.Swap.SwapRequestStateAskUI::tvAccept
	Text_t356221433 * ___tvAccept_8;
	// UnityEngine.UI.Button GameManager.Match.Swap.SwapRequestStateAskUI::btnRefuse
	Button_t2872111280 * ___btnRefuse_9;
	// UnityEngine.UI.Text GameManager.Match.Swap.SwapRequestStateAskUI::tvRefuse
	Text_t356221433 * ___tvRefuse_10;
	// AdvancedCoroutines.Routine GameManager.Match.Swap.SwapRequestStateAskUI::wait
	Routine_t2502590640 * ___wait_11;
	// GameManager.Match.Swap.WhoCanAskAdapter GameManager.Match.Swap.SwapRequestStateAskUI::whoCanAskAdapterPrefab
	WhoCanAskAdapter_t1998236408 * ___whoCanAskAdapterPrefab_12;
	// UnityEngine.Transform GameManager.Match.Swap.SwapRequestStateAskUI::whoCanAskAdapterContainer
	Transform_t3275118058 * ___whoCanAskAdapterContainer_13;
	// Server GameManager.Match.Swap.SwapRequestStateAskUI::server
	Server_t2724320767 * ___server_14;

public:
	inline static int32_t get_offset_of_btnContainer_6() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___btnContainer_6)); }
	inline GameObject_t1756533147 * get_btnContainer_6() const { return ___btnContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_btnContainer_6() { return &___btnContainer_6; }
	inline void set_btnContainer_6(GameObject_t1756533147 * value)
	{
		___btnContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnContainer_6, value);
	}

	inline static int32_t get_offset_of_btnAccept_7() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___btnAccept_7)); }
	inline Button_t2872111280 * get_btnAccept_7() const { return ___btnAccept_7; }
	inline Button_t2872111280 ** get_address_of_btnAccept_7() { return &___btnAccept_7; }
	inline void set_btnAccept_7(Button_t2872111280 * value)
	{
		___btnAccept_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnAccept_7, value);
	}

	inline static int32_t get_offset_of_tvAccept_8() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___tvAccept_8)); }
	inline Text_t356221433 * get_tvAccept_8() const { return ___tvAccept_8; }
	inline Text_t356221433 ** get_address_of_tvAccept_8() { return &___tvAccept_8; }
	inline void set_tvAccept_8(Text_t356221433 * value)
	{
		___tvAccept_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvAccept_8, value);
	}

	inline static int32_t get_offset_of_btnRefuse_9() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___btnRefuse_9)); }
	inline Button_t2872111280 * get_btnRefuse_9() const { return ___btnRefuse_9; }
	inline Button_t2872111280 ** get_address_of_btnRefuse_9() { return &___btnRefuse_9; }
	inline void set_btnRefuse_9(Button_t2872111280 * value)
	{
		___btnRefuse_9 = value;
		Il2CppCodeGenWriteBarrier(&___btnRefuse_9, value);
	}

	inline static int32_t get_offset_of_tvRefuse_10() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___tvRefuse_10)); }
	inline Text_t356221433 * get_tvRefuse_10() const { return ___tvRefuse_10; }
	inline Text_t356221433 ** get_address_of_tvRefuse_10() { return &___tvRefuse_10; }
	inline void set_tvRefuse_10(Text_t356221433 * value)
	{
		___tvRefuse_10 = value;
		Il2CppCodeGenWriteBarrier(&___tvRefuse_10, value);
	}

	inline static int32_t get_offset_of_wait_11() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___wait_11)); }
	inline Routine_t2502590640 * get_wait_11() const { return ___wait_11; }
	inline Routine_t2502590640 ** get_address_of_wait_11() { return &___wait_11; }
	inline void set_wait_11(Routine_t2502590640 * value)
	{
		___wait_11 = value;
		Il2CppCodeGenWriteBarrier(&___wait_11, value);
	}

	inline static int32_t get_offset_of_whoCanAskAdapterPrefab_12() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___whoCanAskAdapterPrefab_12)); }
	inline WhoCanAskAdapter_t1998236408 * get_whoCanAskAdapterPrefab_12() const { return ___whoCanAskAdapterPrefab_12; }
	inline WhoCanAskAdapter_t1998236408 ** get_address_of_whoCanAskAdapterPrefab_12() { return &___whoCanAskAdapterPrefab_12; }
	inline void set_whoCanAskAdapterPrefab_12(WhoCanAskAdapter_t1998236408 * value)
	{
		___whoCanAskAdapterPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAskAdapterPrefab_12, value);
	}

	inline static int32_t get_offset_of_whoCanAskAdapterContainer_13() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___whoCanAskAdapterContainer_13)); }
	inline Transform_t3275118058 * get_whoCanAskAdapterContainer_13() const { return ___whoCanAskAdapterContainer_13; }
	inline Transform_t3275118058 ** get_address_of_whoCanAskAdapterContainer_13() { return &___whoCanAskAdapterContainer_13; }
	inline void set_whoCanAskAdapterContainer_13(Transform_t3275118058 * value)
	{
		___whoCanAskAdapterContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAskAdapterContainer_13, value);
	}

	inline static int32_t get_offset_of_server_14() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUI_t1746527184, ___server_14)); }
	inline Server_t2724320767 * get_server_14() const { return ___server_14; }
	inline Server_t2724320767 ** get_address_of_server_14() { return &___server_14; }
	inline void set_server_14(Server_t2724320767 * value)
	{
		___server_14 = value;
		Il2CppCodeGenWriteBarrier(&___server_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
