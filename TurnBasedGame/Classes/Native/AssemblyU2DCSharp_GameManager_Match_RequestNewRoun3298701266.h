#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2713565833.h"

// GameManager.Match.RequestNewRoundNoLimitInformUI
struct RequestNewRoundNoLimitInformUI_t1947190874;
// GameManager.Match.RequestNewRoundHaveLimitInformUI
struct RequestNewRoundHaveLimitInformUI_t3040101343;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundInformUI
struct  RequestNewRoundInformUI_t3298701266  : public UIBehavior_1_t2713565833
{
public:
	// GameManager.Match.RequestNewRoundNoLimitInformUI GameManager.Match.RequestNewRoundInformUI::noLimitPrefab
	RequestNewRoundNoLimitInformUI_t1947190874 * ___noLimitPrefab_6;
	// GameManager.Match.RequestNewRoundHaveLimitInformUI GameManager.Match.RequestNewRoundInformUI::haveLimitPrefab
	RequestNewRoundHaveLimitInformUI_t3040101343 * ___haveLimitPrefab_7;
	// UnityEngine.Transform GameManager.Match.RequestNewRoundInformUI::limitUIContainer
	Transform_t3275118058 * ___limitUIContainer_8;

public:
	inline static int32_t get_offset_of_noLimitPrefab_6() { return static_cast<int32_t>(offsetof(RequestNewRoundInformUI_t3298701266, ___noLimitPrefab_6)); }
	inline RequestNewRoundNoLimitInformUI_t1947190874 * get_noLimitPrefab_6() const { return ___noLimitPrefab_6; }
	inline RequestNewRoundNoLimitInformUI_t1947190874 ** get_address_of_noLimitPrefab_6() { return &___noLimitPrefab_6; }
	inline void set_noLimitPrefab_6(RequestNewRoundNoLimitInformUI_t1947190874 * value)
	{
		___noLimitPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___noLimitPrefab_6, value);
	}

	inline static int32_t get_offset_of_haveLimitPrefab_7() { return static_cast<int32_t>(offsetof(RequestNewRoundInformUI_t3298701266, ___haveLimitPrefab_7)); }
	inline RequestNewRoundHaveLimitInformUI_t3040101343 * get_haveLimitPrefab_7() const { return ___haveLimitPrefab_7; }
	inline RequestNewRoundHaveLimitInformUI_t3040101343 ** get_address_of_haveLimitPrefab_7() { return &___haveLimitPrefab_7; }
	inline void set_haveLimitPrefab_7(RequestNewRoundHaveLimitInformUI_t3040101343 * value)
	{
		___haveLimitPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___haveLimitPrefab_7, value);
	}

	inline static int32_t get_offset_of_limitUIContainer_8() { return static_cast<int32_t>(offsetof(RequestNewRoundInformUI_t3298701266, ___limitUIContainer_8)); }
	inline Transform_t3275118058 * get_limitUIContainer_8() const { return ___limitUIContainer_8; }
	inline Transform_t3275118058 ** get_address_of_limitUIContainer_8() { return &___limitUIContainer_8; }
	inline void set_limitUIContainer_8(Transform_t3275118058 * value)
	{
		___limitUIContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___limitUIContainer_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
