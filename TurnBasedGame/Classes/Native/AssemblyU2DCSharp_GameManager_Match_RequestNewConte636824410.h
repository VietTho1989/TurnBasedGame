#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3796314697.h"

// GameManager.ContestManager.RequestNewContestManagerStateNoneUI
struct RequestNewContestManagerStateNoneUI_t1232656401;
// GameManager.ContestManager.RequestNewContestManagerStateAskUI
struct RequestNewContestManagerStateAskUI_t2487102892;
// GameManager.ContestManager.RequestNewContestManagerStateAcceptUI
struct RequestNewContestManagerStateAcceptUI_t453476519;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewContestManagerUI
struct  RequestNewContestManagerUI_t636824410  : public UIBehavior_1_t3796314697
{
public:
	// GameManager.ContestManager.RequestNewContestManagerStateNoneUI GameManager.Match.RequestNewContestManagerUI::nonePrefab
	RequestNewContestManagerStateNoneUI_t1232656401 * ___nonePrefab_6;
	// GameManager.ContestManager.RequestNewContestManagerStateAskUI GameManager.Match.RequestNewContestManagerUI::askPrefab
	RequestNewContestManagerStateAskUI_t2487102892 * ___askPrefab_7;
	// GameManager.ContestManager.RequestNewContestManagerStateAcceptUI GameManager.Match.RequestNewContestManagerUI::acceptPrefab
	RequestNewContestManagerStateAcceptUI_t453476519 * ___acceptPrefab_8;
	// UnityEngine.Transform GameManager.Match.RequestNewContestManagerUI::subContainer
	Transform_t3275118058 * ___subContainer_9;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(RequestNewContestManagerUI_t636824410, ___nonePrefab_6)); }
	inline RequestNewContestManagerStateNoneUI_t1232656401 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline RequestNewContestManagerStateNoneUI_t1232656401 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(RequestNewContestManagerStateNoneUI_t1232656401 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_askPrefab_7() { return static_cast<int32_t>(offsetof(RequestNewContestManagerUI_t636824410, ___askPrefab_7)); }
	inline RequestNewContestManagerStateAskUI_t2487102892 * get_askPrefab_7() const { return ___askPrefab_7; }
	inline RequestNewContestManagerStateAskUI_t2487102892 ** get_address_of_askPrefab_7() { return &___askPrefab_7; }
	inline void set_askPrefab_7(RequestNewContestManagerStateAskUI_t2487102892 * value)
	{
		___askPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_7, value);
	}

	inline static int32_t get_offset_of_acceptPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewContestManagerUI_t636824410, ___acceptPrefab_8)); }
	inline RequestNewContestManagerStateAcceptUI_t453476519 * get_acceptPrefab_8() const { return ___acceptPrefab_8; }
	inline RequestNewContestManagerStateAcceptUI_t453476519 ** get_address_of_acceptPrefab_8() { return &___acceptPrefab_8; }
	inline void set_acceptPrefab_8(RequestNewContestManagerStateAcceptUI_t453476519 * value)
	{
		___acceptPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___acceptPrefab_8, value);
	}

	inline static int32_t get_offset_of_subContainer_9() { return static_cast<int32_t>(offsetof(RequestNewContestManagerUI_t636824410, ___subContainer_9)); }
	inline Transform_t3275118058 * get_subContainer_9() const { return ___subContainer_9; }
	inline Transform_t3275118058 ** get_address_of_subContainer_9() { return &___subContainer_9; }
	inline void set_subContainer_9(Transform_t3275118058 * value)
	{
		___subContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
