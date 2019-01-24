#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3075027806.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.Transform
struct Transform_t3275118058;
// WaitAIInputNoneUI
struct WaitAIInputNoneUI_t3493126353;
// WaitAIInputSearchUI
struct WaitAIInputSearchUI_t2248836777;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInputUI
struct  WaitAIInputUI_t1572023195  : public UIBehavior_1_t3075027806
{
public:
	// UnityEngine.UI.Text WaitAIInputUI::tvUserThink
	Text_t356221433 * ___tvUserThink_6;
	// UnityEngine.Transform WaitAIInputUI::subContainer
	Transform_t3275118058 * ___subContainer_7;
	// WaitAIInputNoneUI WaitAIInputUI::nonePrefab
	WaitAIInputNoneUI_t3493126353 * ___nonePrefab_8;
	// WaitAIInputSearchUI WaitAIInputUI::searchPrefab
	WaitAIInputSearchUI_t2248836777 * ___searchPrefab_9;

public:
	inline static int32_t get_offset_of_tvUserThink_6() { return static_cast<int32_t>(offsetof(WaitAIInputUI_t1572023195, ___tvUserThink_6)); }
	inline Text_t356221433 * get_tvUserThink_6() const { return ___tvUserThink_6; }
	inline Text_t356221433 ** get_address_of_tvUserThink_6() { return &___tvUserThink_6; }
	inline void set_tvUserThink_6(Text_t356221433 * value)
	{
		___tvUserThink_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvUserThink_6, value);
	}

	inline static int32_t get_offset_of_subContainer_7() { return static_cast<int32_t>(offsetof(WaitAIInputUI_t1572023195, ___subContainer_7)); }
	inline Transform_t3275118058 * get_subContainer_7() const { return ___subContainer_7; }
	inline Transform_t3275118058 ** get_address_of_subContainer_7() { return &___subContainer_7; }
	inline void set_subContainer_7(Transform_t3275118058 * value)
	{
		___subContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_7, value);
	}

	inline static int32_t get_offset_of_nonePrefab_8() { return static_cast<int32_t>(offsetof(WaitAIInputUI_t1572023195, ___nonePrefab_8)); }
	inline WaitAIInputNoneUI_t3493126353 * get_nonePrefab_8() const { return ___nonePrefab_8; }
	inline WaitAIInputNoneUI_t3493126353 ** get_address_of_nonePrefab_8() { return &___nonePrefab_8; }
	inline void set_nonePrefab_8(WaitAIInputNoneUI_t3493126353 * value)
	{
		___nonePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_8, value);
	}

	inline static int32_t get_offset_of_searchPrefab_9() { return static_cast<int32_t>(offsetof(WaitAIInputUI_t1572023195, ___searchPrefab_9)); }
	inline WaitAIInputSearchUI_t2248836777 * get_searchPrefab_9() const { return ___searchPrefab_9; }
	inline WaitAIInputSearchUI_t2248836777 ** get_address_of_searchPrefab_9() { return &___searchPrefab_9; }
	inline void set_searchPrefab_9(WaitAIInputSearchUI_t2248836777 * value)
	{
		___searchPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___searchPrefab_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
