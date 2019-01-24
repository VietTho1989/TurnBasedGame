#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2102514937.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SeirawanCustomHandUI
struct  SeirawanCustomHandUI_t3517776034  : public UIBehavior_1_t2102514937
{
public:
	// UnityEngine.UI.Image Seirawan.NoneRule.SeirawanCustomHandUI::imgHint
	Image_t2042527209 * ___imgHint_6;
	// UnityEngine.GameObject Seirawan.NoneRule.SeirawanCustomHandUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_7;

public:
	inline static int32_t get_offset_of_imgHint_6() { return static_cast<int32_t>(offsetof(SeirawanCustomHandUI_t3517776034, ___imgHint_6)); }
	inline Image_t2042527209 * get_imgHint_6() const { return ___imgHint_6; }
	inline Image_t2042527209 ** get_address_of_imgHint_6() { return &___imgHint_6; }
	inline void set_imgHint_6(Image_t2042527209 * value)
	{
		___imgHint_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(SeirawanCustomHandUI_t3517776034, ___contentContainer_7)); }
	inline GameObject_t1756533147 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(GameObject_t1756533147 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
