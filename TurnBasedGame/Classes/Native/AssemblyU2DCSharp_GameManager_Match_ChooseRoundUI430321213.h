#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3276005588.h"

// GameManager.Match.ChooseRoundAdapter
struct ChooseRoundAdapter_t849407876;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.RequestNewRoundInformUI
struct RequestNewRoundInformUI_t3298701266;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundUI
struct  ChooseRoundUI_t430321213  : public UIBehavior_1_t3276005588
{
public:
	// GameManager.Match.ChooseRoundAdapter GameManager.Match.ChooseRoundUI::chooseRoundAdapterPrefab
	ChooseRoundAdapter_t849407876 * ___chooseRoundAdapterPrefab_6;
	// UnityEngine.Transform GameManager.Match.ChooseRoundUI::chooseRoundAdapterContainer
	Transform_t3275118058 * ___chooseRoundAdapterContainer_7;
	// GameManager.Match.RequestNewRoundInformUI GameManager.Match.ChooseRoundUI::requestNewRoundInformPrefab
	RequestNewRoundInformUI_t3298701266 * ___requestNewRoundInformPrefab_8;
	// UnityEngine.Transform GameManager.Match.ChooseRoundUI::requestNewRoundInformContainer
	Transform_t3275118058 * ___requestNewRoundInformContainer_9;

public:
	inline static int32_t get_offset_of_chooseRoundAdapterPrefab_6() { return static_cast<int32_t>(offsetof(ChooseRoundUI_t430321213, ___chooseRoundAdapterPrefab_6)); }
	inline ChooseRoundAdapter_t849407876 * get_chooseRoundAdapterPrefab_6() const { return ___chooseRoundAdapterPrefab_6; }
	inline ChooseRoundAdapter_t849407876 ** get_address_of_chooseRoundAdapterPrefab_6() { return &___chooseRoundAdapterPrefab_6; }
	inline void set_chooseRoundAdapterPrefab_6(ChooseRoundAdapter_t849407876 * value)
	{
		___chooseRoundAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_chooseRoundAdapterContainer_7() { return static_cast<int32_t>(offsetof(ChooseRoundUI_t430321213, ___chooseRoundAdapterContainer_7)); }
	inline Transform_t3275118058 * get_chooseRoundAdapterContainer_7() const { return ___chooseRoundAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chooseRoundAdapterContainer_7() { return &___chooseRoundAdapterContainer_7; }
	inline void set_chooseRoundAdapterContainer_7(Transform_t3275118058 * value)
	{
		___chooseRoundAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundAdapterContainer_7, value);
	}

	inline static int32_t get_offset_of_requestNewRoundInformPrefab_8() { return static_cast<int32_t>(offsetof(ChooseRoundUI_t430321213, ___requestNewRoundInformPrefab_8)); }
	inline RequestNewRoundInformUI_t3298701266 * get_requestNewRoundInformPrefab_8() const { return ___requestNewRoundInformPrefab_8; }
	inline RequestNewRoundInformUI_t3298701266 ** get_address_of_requestNewRoundInformPrefab_8() { return &___requestNewRoundInformPrefab_8; }
	inline void set_requestNewRoundInformPrefab_8(RequestNewRoundInformUI_t3298701266 * value)
	{
		___requestNewRoundInformPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundInformPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestNewRoundInformContainer_9() { return static_cast<int32_t>(offsetof(ChooseRoundUI_t430321213, ___requestNewRoundInformContainer_9)); }
	inline Transform_t3275118058 * get_requestNewRoundInformContainer_9() const { return ___requestNewRoundInformContainer_9; }
	inline Transform_t3275118058 ** get_address_of_requestNewRoundInformContainer_9() { return &___requestNewRoundInformContainer_9; }
	inline void set_requestNewRoundInformContainer_9(Transform_t3275118058 * value)
	{
		___requestNewRoundInformContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundInformContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
