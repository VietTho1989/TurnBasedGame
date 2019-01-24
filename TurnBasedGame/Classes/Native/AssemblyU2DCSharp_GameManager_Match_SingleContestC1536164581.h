#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1435569274.h"

// GameManager.Match.ContestUI
struct ContestUI_t3044427636;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.SingleContestContentUI
struct  SingleContestContentUI_t1536164581  : public UIBehavior_1_t1435569274
{
public:
	// GameManager.Match.ContestUI GameManager.Match.SingleContestContentUI::contestPrefab
	ContestUI_t3044427636 * ___contestPrefab_6;
	// UnityEngine.Transform GameManager.Match.SingleContestContentUI::contestContainer
	Transform_t3275118058 * ___contestContainer_7;

public:
	inline static int32_t get_offset_of_contestPrefab_6() { return static_cast<int32_t>(offsetof(SingleContestContentUI_t1536164581, ___contestPrefab_6)); }
	inline ContestUI_t3044427636 * get_contestPrefab_6() const { return ___contestPrefab_6; }
	inline ContestUI_t3044427636 ** get_address_of_contestPrefab_6() { return &___contestPrefab_6; }
	inline void set_contestPrefab_6(ContestUI_t3044427636 * value)
	{
		___contestPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___contestPrefab_6, value);
	}

	inline static int32_t get_offset_of_contestContainer_7() { return static_cast<int32_t>(offsetof(SingleContestContentUI_t1536164581, ___contestContainer_7)); }
	inline Transform_t3275118058 * get_contestContainer_7() const { return ___contestContainer_7; }
	inline Transform_t3275118058 ** get_address_of_contestContainer_7() { return &___contestContainer_7; }
	inline void set_contestContainer_7(Transform_t3275118058 * value)
	{
		___contestContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contestContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
