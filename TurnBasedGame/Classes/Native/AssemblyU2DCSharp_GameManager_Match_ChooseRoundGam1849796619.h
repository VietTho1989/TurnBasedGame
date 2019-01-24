#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen228739542.h"

// GameManager.Match.ChooseRoundGameAdapter
struct ChooseRoundGameAdapter_t2781301438;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundGameUI
struct  ChooseRoundGameUI_t1849796619  : public UIBehavior_1_t228739542
{
public:
	// GameManager.Match.ChooseRoundGameAdapter GameManager.Match.ChooseRoundGameUI::chooseRoundGameAdapterPrefab
	ChooseRoundGameAdapter_t2781301438 * ___chooseRoundGameAdapterPrefab_6;
	// UnityEngine.Transform GameManager.Match.ChooseRoundGameUI::chooseRoundGameAdapterContainer
	Transform_t3275118058 * ___chooseRoundGameAdapterContainer_7;

public:
	inline static int32_t get_offset_of_chooseRoundGameAdapterPrefab_6() { return static_cast<int32_t>(offsetof(ChooseRoundGameUI_t1849796619, ___chooseRoundGameAdapterPrefab_6)); }
	inline ChooseRoundGameAdapter_t2781301438 * get_chooseRoundGameAdapterPrefab_6() const { return ___chooseRoundGameAdapterPrefab_6; }
	inline ChooseRoundGameAdapter_t2781301438 ** get_address_of_chooseRoundGameAdapterPrefab_6() { return &___chooseRoundGameAdapterPrefab_6; }
	inline void set_chooseRoundGameAdapterPrefab_6(ChooseRoundGameAdapter_t2781301438 * value)
	{
		___chooseRoundGameAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundGameAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_chooseRoundGameAdapterContainer_7() { return static_cast<int32_t>(offsetof(ChooseRoundGameUI_t1849796619, ___chooseRoundGameAdapterContainer_7)); }
	inline Transform_t3275118058 * get_chooseRoundGameAdapterContainer_7() const { return ___chooseRoundGameAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chooseRoundGameAdapterContainer_7() { return &___chooseRoundGameAdapterContainer_7; }
	inline void set_chooseRoundGameAdapterContainer_7(Transform_t3275118058 * value)
	{
		___chooseRoundGameAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundGameAdapterContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
