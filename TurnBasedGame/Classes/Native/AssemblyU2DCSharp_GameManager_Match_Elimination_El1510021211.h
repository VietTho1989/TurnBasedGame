#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2758857725.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameManager.Match.SingleContestFactoryUI
struct SingleContestFactoryUI_t3087354338;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationFactoryUI
struct  EliminationFactoryUI_t1510021211  : public UIBehavior_1_t2758857725
{
public:
	// System.Boolean GameManager.Match.Elimination.EliminationFactoryUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject GameManager.Match.Elimination.EliminationFactoryUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// GameManager.Match.SingleContestFactoryUI GameManager.Match.Elimination.EliminationFactoryUI::singleContestFactoryPrefab
	SingleContestFactoryUI_t3087354338 * ___singleContestFactoryPrefab_8;
	// RequestChangeIntUI GameManager.Match.Elimination.EliminationFactoryUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_9;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationFactoryUI::singleContestFactoryContainer
	Transform_t3275118058 * ___singleContestFactoryContainer_10;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationFactoryUI::initTeamCountLengthContainer
	Transform_t3275118058 * ___initTeamCountLengthContainer_11;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationFactoryUI::initTeamCountsContainer
	Transform_t3275118058 * ___initTeamCountsContainer_12;
	// Server GameManager.Match.Elimination.EliminationFactoryUI::server
	Server_t2724320767 * ___server_13;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_singleContestFactoryPrefab_8() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___singleContestFactoryPrefab_8)); }
	inline SingleContestFactoryUI_t3087354338 * get_singleContestFactoryPrefab_8() const { return ___singleContestFactoryPrefab_8; }
	inline SingleContestFactoryUI_t3087354338 ** get_address_of_singleContestFactoryPrefab_8() { return &___singleContestFactoryPrefab_8; }
	inline void set_singleContestFactoryPrefab_8(SingleContestFactoryUI_t3087354338 * value)
	{
		___singleContestFactoryPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactoryPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_9() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___requestIntPrefab_9)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_9() const { return ___requestIntPrefab_9; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_9() { return &___requestIntPrefab_9; }
	inline void set_requestIntPrefab_9(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_9, value);
	}

	inline static int32_t get_offset_of_singleContestFactoryContainer_10() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___singleContestFactoryContainer_10)); }
	inline Transform_t3275118058 * get_singleContestFactoryContainer_10() const { return ___singleContestFactoryContainer_10; }
	inline Transform_t3275118058 ** get_address_of_singleContestFactoryContainer_10() { return &___singleContestFactoryContainer_10; }
	inline void set_singleContestFactoryContainer_10(Transform_t3275118058 * value)
	{
		___singleContestFactoryContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactoryContainer_10, value);
	}

	inline static int32_t get_offset_of_initTeamCountLengthContainer_11() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___initTeamCountLengthContainer_11)); }
	inline Transform_t3275118058 * get_initTeamCountLengthContainer_11() const { return ___initTeamCountLengthContainer_11; }
	inline Transform_t3275118058 ** get_address_of_initTeamCountLengthContainer_11() { return &___initTeamCountLengthContainer_11; }
	inline void set_initTeamCountLengthContainer_11(Transform_t3275118058 * value)
	{
		___initTeamCountLengthContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___initTeamCountLengthContainer_11, value);
	}

	inline static int32_t get_offset_of_initTeamCountsContainer_12() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___initTeamCountsContainer_12)); }
	inline Transform_t3275118058 * get_initTeamCountsContainer_12() const { return ___initTeamCountsContainer_12; }
	inline Transform_t3275118058 ** get_address_of_initTeamCountsContainer_12() { return &___initTeamCountsContainer_12; }
	inline void set_initTeamCountsContainer_12(Transform_t3275118058 * value)
	{
		___initTeamCountsContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___initTeamCountsContainer_12, value);
	}

	inline static int32_t get_offset_of_server_13() { return static_cast<int32_t>(offsetof(EliminationFactoryUI_t1510021211, ___server_13)); }
	inline Server_t2724320767 * get_server_13() const { return ___server_13; }
	inline Server_t2724320767 ** get_address_of_server_13() { return &___server_13; }
	inline void set_server_13(Server_t2724320767 * value)
	{
		___server_13 = value;
		Il2CppCodeGenWriteBarrier(&___server_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
