#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4287587548.h"

// LoginUI
struct LoginUI_t1439696001;
// AfterLoginUI
struct AfterLoginUI_t1677138701;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NormalUI
struct  NormalUI_t3753177153  : public UIBehavior_1_t4287587548
{
public:
	// LoginUI NormalUI::loginUIPrefab
	LoginUI_t1439696001 * ___loginUIPrefab_6;
	// AfterLoginUI NormalUI::afterLoginPrefab
	AfterLoginUI_t1677138701 * ___afterLoginPrefab_7;

public:
	inline static int32_t get_offset_of_loginUIPrefab_6() { return static_cast<int32_t>(offsetof(NormalUI_t3753177153, ___loginUIPrefab_6)); }
	inline LoginUI_t1439696001 * get_loginUIPrefab_6() const { return ___loginUIPrefab_6; }
	inline LoginUI_t1439696001 ** get_address_of_loginUIPrefab_6() { return &___loginUIPrefab_6; }
	inline void set_loginUIPrefab_6(LoginUI_t1439696001 * value)
	{
		___loginUIPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___loginUIPrefab_6, value);
	}

	inline static int32_t get_offset_of_afterLoginPrefab_7() { return static_cast<int32_t>(offsetof(NormalUI_t3753177153, ___afterLoginPrefab_7)); }
	inline AfterLoginUI_t1677138701 * get_afterLoginPrefab_7() const { return ___afterLoginPrefab_7; }
	inline AfterLoginUI_t1677138701 ** get_address_of_afterLoginPrefab_7() { return &___afterLoginPrefab_7; }
	inline void set_afterLoginPrefab_7(AfterLoginUI_t1677138701 * value)
	{
		___afterLoginPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___afterLoginPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
