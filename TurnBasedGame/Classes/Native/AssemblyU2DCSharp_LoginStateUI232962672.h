#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2613993081.h"

// LoginState.NoneUI
struct NoneUI_t3909228254;
// LoginState.LogUI
struct LogUI_t1659339182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginStateUI
struct  LoginStateUI_t232962672  : public UIBehavior_1_t2613993081
{
public:
	// LoginState.NoneUI LoginStateUI::nonePrefab
	NoneUI_t3909228254 * ___nonePrefab_6;
	// LoginState.LogUI LoginStateUI::logPrefab
	LogUI_t1659339182 * ___logPrefab_7;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(LoginStateUI_t232962672, ___nonePrefab_6)); }
	inline NoneUI_t3909228254 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline NoneUI_t3909228254 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(NoneUI_t3909228254 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_logPrefab_7() { return static_cast<int32_t>(offsetof(LoginStateUI_t232962672, ___logPrefab_7)); }
	inline LogUI_t1659339182 * get_logPrefab_7() const { return ___logPrefab_7; }
	inline LogUI_t1659339182 ** get_address_of_logPrefab_7() { return &___logPrefab_7; }
	inline void set_logPrefab_7(LogUI_t1659339182 * value)
	{
		___logPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___logPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
