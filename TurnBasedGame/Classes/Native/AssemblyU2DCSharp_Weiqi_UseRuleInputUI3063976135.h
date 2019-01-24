#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2481844775.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// Weiqi.WeiqiGameDataUI/UIData
struct UIData_t3165614177;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.UseRuleInputUI
struct  UseRuleInputUI_t3063976135  : public UIBehavior_1_t2481844775
{
public:
	// UnityEngine.GameObject Weiqi.UseRuleInputUI::passContainer
	GameObject_t1756533147 * ___passContainer_6;
	// Weiqi.WeiqiGameDataUI/UIData Weiqi.UseRuleInputUI::weiqiGameDataUIData
	UIData_t3165614177 * ___weiqiGameDataUIData_7;

public:
	inline static int32_t get_offset_of_passContainer_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3063976135, ___passContainer_6)); }
	inline GameObject_t1756533147 * get_passContainer_6() const { return ___passContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_passContainer_6() { return &___passContainer_6; }
	inline void set_passContainer_6(GameObject_t1756533147 * value)
	{
		___passContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___passContainer_6, value);
	}

	inline static int32_t get_offset_of_weiqiGameDataUIData_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3063976135, ___weiqiGameDataUIData_7)); }
	inline UIData_t3165614177 * get_weiqiGameDataUIData_7() const { return ___weiqiGameDataUIData_7; }
	inline UIData_t3165614177 ** get_address_of_weiqiGameDataUIData_7() { return &___weiqiGameDataUIData_7; }
	inline void set_weiqiGameDataUIData_7(UIData_t3165614177 * value)
	{
		___weiqiGameDataUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiGameDataUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
