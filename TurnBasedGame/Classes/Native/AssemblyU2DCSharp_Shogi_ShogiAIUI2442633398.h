#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen614295723.h"

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

// Shogi.ShogiAIUI
struct  ShogiAIUI_t2442633398  : public UIBehavior_1_t614295723
{
public:
	// System.Boolean Shogi.ShogiAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject Shogi.ShogiAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform Shogi.ShogiAIUI::depthContainer
	Transform_t3275118058 * ___depthContainer_8;
	// UnityEngine.Transform Shogi.ShogiAIUI::skillLevelContainer
	Transform_t3275118058 * ___skillLevelContainer_9;
	// UnityEngine.Transform Shogi.ShogiAIUI::mrContainer
	Transform_t3275118058 * ___mrContainer_10;
	// UnityEngine.Transform Shogi.ShogiAIUI::durationContainer
	Transform_t3275118058 * ___durationContainer_11;
	// UnityEngine.Transform Shogi.ShogiAIUI::useBookContainer
	Transform_t3275118058 * ___useBookContainer_12;
	// RequestChangeIntUI Shogi.ShogiAIUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_13;
	// RequestChangeBoolUI Shogi.ShogiAIUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_14;
	// Server Shogi.ShogiAIUI::server
	Server_t2724320767 * ___server_15;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_depthContainer_8() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___depthContainer_8)); }
	inline Transform_t3275118058 * get_depthContainer_8() const { return ___depthContainer_8; }
	inline Transform_t3275118058 ** get_address_of_depthContainer_8() { return &___depthContainer_8; }
	inline void set_depthContainer_8(Transform_t3275118058 * value)
	{
		___depthContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___depthContainer_8, value);
	}

	inline static int32_t get_offset_of_skillLevelContainer_9() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___skillLevelContainer_9)); }
	inline Transform_t3275118058 * get_skillLevelContainer_9() const { return ___skillLevelContainer_9; }
	inline Transform_t3275118058 ** get_address_of_skillLevelContainer_9() { return &___skillLevelContainer_9; }
	inline void set_skillLevelContainer_9(Transform_t3275118058 * value)
	{
		___skillLevelContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___skillLevelContainer_9, value);
	}

	inline static int32_t get_offset_of_mrContainer_10() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___mrContainer_10)); }
	inline Transform_t3275118058 * get_mrContainer_10() const { return ___mrContainer_10; }
	inline Transform_t3275118058 ** get_address_of_mrContainer_10() { return &___mrContainer_10; }
	inline void set_mrContainer_10(Transform_t3275118058 * value)
	{
		___mrContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___mrContainer_10, value);
	}

	inline static int32_t get_offset_of_durationContainer_11() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___durationContainer_11)); }
	inline Transform_t3275118058 * get_durationContainer_11() const { return ___durationContainer_11; }
	inline Transform_t3275118058 ** get_address_of_durationContainer_11() { return &___durationContainer_11; }
	inline void set_durationContainer_11(Transform_t3275118058 * value)
	{
		___durationContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___durationContainer_11, value);
	}

	inline static int32_t get_offset_of_useBookContainer_12() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___useBookContainer_12)); }
	inline Transform_t3275118058 * get_useBookContainer_12() const { return ___useBookContainer_12; }
	inline Transform_t3275118058 ** get_address_of_useBookContainer_12() { return &___useBookContainer_12; }
	inline void set_useBookContainer_12(Transform_t3275118058 * value)
	{
		___useBookContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___useBookContainer_12, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_13() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___requestIntPrefab_13)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_13() const { return ___requestIntPrefab_13; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_13() { return &___requestIntPrefab_13; }
	inline void set_requestIntPrefab_13(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_13, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_14() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___requestBoolPrefab_14)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_14() const { return ___requestBoolPrefab_14; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_14() { return &___requestBoolPrefab_14; }
	inline void set_requestBoolPrefab_14(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_14 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_14, value);
	}

	inline static int32_t get_offset_of_server_15() { return static_cast<int32_t>(offsetof(ShogiAIUI_t2442633398, ___server_15)); }
	inline Server_t2724320767 * get_server_15() const { return ___server_15; }
	inline Server_t2724320767 ** get_address_of_server_15() { return &___server_15; }
	inline void set_server_15(Server_t2724320767 * value)
	{
		___server_15 = value;
		Il2CppCodeGenWriteBarrier(&___server_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
