#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2990006123.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.XiangqiAIUI
struct  XiangqiAIUI_t1559434699  : public UIBehavior_1_t2990006123
{
public:
	// System.Boolean Xiangqi.XiangqiAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject Xiangqi.XiangqiAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform Xiangqi.XiangqiAIUI::depthContainer
	Transform_t3275118058 * ___depthContainer_8;
	// UnityEngine.Transform Xiangqi.XiangqiAIUI::thinkTimeContainer
	Transform_t3275118058 * ___thinkTimeContainer_9;
	// UnityEngine.Transform Xiangqi.XiangqiAIUI::useBookContainer
	Transform_t3275118058 * ___useBookContainer_10;
	// UnityEngine.Transform Xiangqi.XiangqiAIUI::pickBestMoveContainer
	Transform_t3275118058 * ___pickBestMoveContainer_11;
	// RequestChangeIntUI Xiangqi.XiangqiAIUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_12;
	// RequestChangeBoolUI Xiangqi.XiangqiAIUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_13;
	// Server Xiangqi.XiangqiAIUI::server
	Server_t2724320767 * ___server_14;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_depthContainer_8() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___depthContainer_8)); }
	inline Transform_t3275118058 * get_depthContainer_8() const { return ___depthContainer_8; }
	inline Transform_t3275118058 ** get_address_of_depthContainer_8() { return &___depthContainer_8; }
	inline void set_depthContainer_8(Transform_t3275118058 * value)
	{
		___depthContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___depthContainer_8, value);
	}

	inline static int32_t get_offset_of_thinkTimeContainer_9() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___thinkTimeContainer_9)); }
	inline Transform_t3275118058 * get_thinkTimeContainer_9() const { return ___thinkTimeContainer_9; }
	inline Transform_t3275118058 ** get_address_of_thinkTimeContainer_9() { return &___thinkTimeContainer_9; }
	inline void set_thinkTimeContainer_9(Transform_t3275118058 * value)
	{
		___thinkTimeContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___thinkTimeContainer_9, value);
	}

	inline static int32_t get_offset_of_useBookContainer_10() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___useBookContainer_10)); }
	inline Transform_t3275118058 * get_useBookContainer_10() const { return ___useBookContainer_10; }
	inline Transform_t3275118058 ** get_address_of_useBookContainer_10() { return &___useBookContainer_10; }
	inline void set_useBookContainer_10(Transform_t3275118058 * value)
	{
		___useBookContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___useBookContainer_10, value);
	}

	inline static int32_t get_offset_of_pickBestMoveContainer_11() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___pickBestMoveContainer_11)); }
	inline Transform_t3275118058 * get_pickBestMoveContainer_11() const { return ___pickBestMoveContainer_11; }
	inline Transform_t3275118058 ** get_address_of_pickBestMoveContainer_11() { return &___pickBestMoveContainer_11; }
	inline void set_pickBestMoveContainer_11(Transform_t3275118058 * value)
	{
		___pickBestMoveContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___pickBestMoveContainer_11, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_12() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___requestIntPrefab_12)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_12() const { return ___requestIntPrefab_12; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_12() { return &___requestIntPrefab_12; }
	inline void set_requestIntPrefab_12(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_12, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_13() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___requestBoolPrefab_13)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_13() const { return ___requestBoolPrefab_13; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_13() { return &___requestBoolPrefab_13; }
	inline void set_requestBoolPrefab_13(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_13, value);
	}

	inline static int32_t get_offset_of_server_14() { return static_cast<int32_t>(offsetof(XiangqiAIUI_t1559434699, ___server_14)); }
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
