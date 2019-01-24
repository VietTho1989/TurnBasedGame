#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen617151892.h"

// ConfirmBackHostUI
struct ConfirmBackHostUI_t1652411987;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AfterLoginMainBtnBackHostUI
struct  AfterLoginMainBtnBackHostUI_t1001921425  : public UIBehavior_1_t617151892
{
public:
	// ConfirmBackHostUI AfterLoginMainBtnBackHostUI::confirmUIPrefab
	ConfirmBackHostUI_t1652411987 * ___confirmUIPrefab_6;
	// UnityEngine.Transform AfterLoginMainBtnBackHostUI::confirmUIContainer
	Transform_t3275118058 * ___confirmUIContainer_7;

public:
	inline static int32_t get_offset_of_confirmUIPrefab_6() { return static_cast<int32_t>(offsetof(AfterLoginMainBtnBackHostUI_t1001921425, ___confirmUIPrefab_6)); }
	inline ConfirmBackHostUI_t1652411987 * get_confirmUIPrefab_6() const { return ___confirmUIPrefab_6; }
	inline ConfirmBackHostUI_t1652411987 ** get_address_of_confirmUIPrefab_6() { return &___confirmUIPrefab_6; }
	inline void set_confirmUIPrefab_6(ConfirmBackHostUI_t1652411987 * value)
	{
		___confirmUIPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___confirmUIPrefab_6, value);
	}

	inline static int32_t get_offset_of_confirmUIContainer_7() { return static_cast<int32_t>(offsetof(AfterLoginMainBtnBackHostUI_t1001921425, ___confirmUIContainer_7)); }
	inline Transform_t3275118058 * get_confirmUIContainer_7() const { return ___confirmUIContainer_7; }
	inline Transform_t3275118058 ** get_address_of_confirmUIContainer_7() { return &___confirmUIContainer_7; }
	inline void set_confirmUIContainer_7(Transform_t3275118058 * value)
	{
		___confirmUIContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___confirmUIContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
