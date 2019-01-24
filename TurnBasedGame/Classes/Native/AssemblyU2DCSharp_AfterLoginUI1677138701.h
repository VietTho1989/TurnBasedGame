#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4204284784.h"

// User
struct User_t719925459;
// GlobalViewUI
struct GlobalViewUI_t3088109732;
// GlobalBanUI
struct GlobalBanUI_t3692963186;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AfterLoginUI
struct  AfterLoginUI_t1677138701  : public UIBehavior_1_t4204284784
{
public:
	// User AfterLoginUI::profileUser
	User_t719925459 * ___profileUser_6;
	// GlobalViewUI AfterLoginUI::globalViewPrefab
	GlobalViewUI_t3088109732 * ___globalViewPrefab_7;
	// GlobalBanUI AfterLoginUI::globalBanPrefab
	GlobalBanUI_t3692963186 * ___globalBanPrefab_8;

public:
	inline static int32_t get_offset_of_profileUser_6() { return static_cast<int32_t>(offsetof(AfterLoginUI_t1677138701, ___profileUser_6)); }
	inline User_t719925459 * get_profileUser_6() const { return ___profileUser_6; }
	inline User_t719925459 ** get_address_of_profileUser_6() { return &___profileUser_6; }
	inline void set_profileUser_6(User_t719925459 * value)
	{
		___profileUser_6 = value;
		Il2CppCodeGenWriteBarrier(&___profileUser_6, value);
	}

	inline static int32_t get_offset_of_globalViewPrefab_7() { return static_cast<int32_t>(offsetof(AfterLoginUI_t1677138701, ___globalViewPrefab_7)); }
	inline GlobalViewUI_t3088109732 * get_globalViewPrefab_7() const { return ___globalViewPrefab_7; }
	inline GlobalViewUI_t3088109732 ** get_address_of_globalViewPrefab_7() { return &___globalViewPrefab_7; }
	inline void set_globalViewPrefab_7(GlobalViewUI_t3088109732 * value)
	{
		___globalViewPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___globalViewPrefab_7, value);
	}

	inline static int32_t get_offset_of_globalBanPrefab_8() { return static_cast<int32_t>(offsetof(AfterLoginUI_t1677138701, ___globalBanPrefab_8)); }
	inline GlobalBanUI_t3692963186 * get_globalBanPrefab_8() const { return ___globalBanPrefab_8; }
	inline GlobalBanUI_t3692963186 ** get_address_of_globalBanPrefab_8() { return &___globalBanPrefab_8; }
	inline void set_globalBanPrefab_8(GlobalBanUI_t3692963186 * value)
	{
		___globalBanPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___globalBanPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
