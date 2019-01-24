#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3574781093.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameManager.Match.SingleContestFactoryUI
struct SingleContestFactoryUI_t3087354338;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinFactoryUI
struct  RoundRobinFactoryUI_t1021493882  : public UIBehavior_1_t3574781093
{
public:
	// System.Boolean GameManager.Match.RoundRobin.RoundRobinFactoryUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject GameManager.Match.RoundRobin.RoundRobinFactoryUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// GameManager.Match.SingleContestFactoryUI GameManager.Match.RoundRobin.RoundRobinFactoryUI::singleContestFactoryPrefab
	SingleContestFactoryUI_t3087354338 * ___singleContestFactoryPrefab_8;
	// RequestChangeIntUI GameManager.Match.RoundRobin.RoundRobinFactoryUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_9;
	// RequestChangeBoolUI GameManager.Match.RoundRobin.RoundRobinFactoryUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_10;
	// UnityEngine.Transform GameManager.Match.RoundRobin.RoundRobinFactoryUI::singleContestFactoryContainer
	Transform_t3275118058 * ___singleContestFactoryContainer_11;
	// UnityEngine.Transform GameManager.Match.RoundRobin.RoundRobinFactoryUI::teamCountContainer
	Transform_t3275118058 * ___teamCountContainer_12;
	// UnityEngine.Transform GameManager.Match.RoundRobin.RoundRobinFactoryUI::needReturnRoundContainer
	Transform_t3275118058 * ___needReturnRoundContainer_13;
	// Server GameManager.Match.RoundRobin.RoundRobinFactoryUI::server
	Server_t2724320767 * ___server_14;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_singleContestFactoryPrefab_8() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___singleContestFactoryPrefab_8)); }
	inline SingleContestFactoryUI_t3087354338 * get_singleContestFactoryPrefab_8() const { return ___singleContestFactoryPrefab_8; }
	inline SingleContestFactoryUI_t3087354338 ** get_address_of_singleContestFactoryPrefab_8() { return &___singleContestFactoryPrefab_8; }
	inline void set_singleContestFactoryPrefab_8(SingleContestFactoryUI_t3087354338 * value)
	{
		___singleContestFactoryPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactoryPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_9() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___requestIntPrefab_9)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_9() const { return ___requestIntPrefab_9; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_9() { return &___requestIntPrefab_9; }
	inline void set_requestIntPrefab_9(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_9, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_10() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___requestBoolPrefab_10)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_10() const { return ___requestBoolPrefab_10; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_10() { return &___requestBoolPrefab_10; }
	inline void set_requestBoolPrefab_10(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_10, value);
	}

	inline static int32_t get_offset_of_singleContestFactoryContainer_11() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___singleContestFactoryContainer_11)); }
	inline Transform_t3275118058 * get_singleContestFactoryContainer_11() const { return ___singleContestFactoryContainer_11; }
	inline Transform_t3275118058 ** get_address_of_singleContestFactoryContainer_11() { return &___singleContestFactoryContainer_11; }
	inline void set_singleContestFactoryContainer_11(Transform_t3275118058 * value)
	{
		___singleContestFactoryContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactoryContainer_11, value);
	}

	inline static int32_t get_offset_of_teamCountContainer_12() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___teamCountContainer_12)); }
	inline Transform_t3275118058 * get_teamCountContainer_12() const { return ___teamCountContainer_12; }
	inline Transform_t3275118058 ** get_address_of_teamCountContainer_12() { return &___teamCountContainer_12; }
	inline void set_teamCountContainer_12(Transform_t3275118058 * value)
	{
		___teamCountContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___teamCountContainer_12, value);
	}

	inline static int32_t get_offset_of_needReturnRoundContainer_13() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___needReturnRoundContainer_13)); }
	inline Transform_t3275118058 * get_needReturnRoundContainer_13() const { return ___needReturnRoundContainer_13; }
	inline Transform_t3275118058 ** get_address_of_needReturnRoundContainer_13() { return &___needReturnRoundContainer_13; }
	inline void set_needReturnRoundContainer_13(Transform_t3275118058 * value)
	{
		___needReturnRoundContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___needReturnRoundContainer_13, value);
	}

	inline static int32_t get_offset_of_server_14() { return static_cast<int32_t>(offsetof(RoundRobinFactoryUI_t1021493882, ___server_14)); }
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
