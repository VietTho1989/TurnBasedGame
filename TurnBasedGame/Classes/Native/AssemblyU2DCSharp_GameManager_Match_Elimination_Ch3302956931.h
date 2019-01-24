#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2136727279.h"

// GameManager.Match.Elimination.ChooseBracketAdapter
struct ChooseBracketAdapter_t4242167612;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketUI
struct  ChooseBracketUI_t3302956931  : public UIBehavior_1_t2136727279
{
public:
	// GameManager.Match.Elimination.ChooseBracketAdapter GameManager.Match.Elimination.ChooseBracketUI::chooseBracketAdapterPrefab
	ChooseBracketAdapter_t4242167612 * ___chooseBracketAdapterPrefab_6;
	// UnityEngine.Transform GameManager.Match.Elimination.ChooseBracketUI::chooseBracketAdapterContainer
	Transform_t3275118058 * ___chooseBracketAdapterContainer_7;

public:
	inline static int32_t get_offset_of_chooseBracketAdapterPrefab_6() { return static_cast<int32_t>(offsetof(ChooseBracketUI_t3302956931, ___chooseBracketAdapterPrefab_6)); }
	inline ChooseBracketAdapter_t4242167612 * get_chooseBracketAdapterPrefab_6() const { return ___chooseBracketAdapterPrefab_6; }
	inline ChooseBracketAdapter_t4242167612 ** get_address_of_chooseBracketAdapterPrefab_6() { return &___chooseBracketAdapterPrefab_6; }
	inline void set_chooseBracketAdapterPrefab_6(ChooseBracketAdapter_t4242167612 * value)
	{
		___chooseBracketAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_chooseBracketAdapterContainer_7() { return static_cast<int32_t>(offsetof(ChooseBracketUI_t3302956931, ___chooseBracketAdapterContainer_7)); }
	inline Transform_t3275118058 * get_chooseBracketAdapterContainer_7() const { return ___chooseBracketAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chooseBracketAdapterContainer_7() { return &___chooseBracketAdapterContainer_7; }
	inline void set_chooseBracketAdapterContainer_7(Transform_t3275118058 * value)
	{
		___chooseBracketAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketAdapterContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
