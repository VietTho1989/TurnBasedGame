#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2395210906.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// AccountUI
struct AccountUI_t1735092883;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// RequestChangeLongUI
struct RequestChangeLongUI_t921704931;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// BanUI
struct BanUI_t2500187775;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanUI
struct  HumanUI_t990511461  : public UIBehavior_1_t2395210906
{
public:
	// System.Boolean HumanUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject HumanUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeIntUI HumanUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_8;
	// AccountUI HumanUI::accountPrefab
	AccountUI_t1735092883 * ___accountPrefab_9;
	// RequestChangeStringUI HumanUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_10;
	// RequestChangeLongUI HumanUI::requestLongPrefab
	RequestChangeLongUI_t921704931 * ___requestLongPrefab_11;
	// RequestChangeEnumUI HumanUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_12;
	// BanUI HumanUI::banPrefab
	BanUI_t2500187775 * ___banPrefab_13;
	// UnityEngine.Transform HumanUI::playerIdContainer
	Transform_t3275118058 * ___playerIdContainer_14;
	// UnityEngine.Transform HumanUI::accountContainer
	Transform_t3275118058 * ___accountContainer_15;
	// UnityEngine.Transform HumanUI::emailContainer
	Transform_t3275118058 * ___emailContainer_16;
	// UnityEngine.Transform HumanUI::phoneNumberContainer
	Transform_t3275118058 * ___phoneNumberContainer_17;
	// UnityEngine.Transform HumanUI::statusContainer
	Transform_t3275118058 * ___statusContainer_18;
	// UnityEngine.Transform HumanUI::birthdayContainer
	Transform_t3275118058 * ___birthdayContainer_19;
	// UnityEngine.Transform HumanUI::sexContainer
	Transform_t3275118058 * ___sexContainer_20;
	// UnityEngine.Transform HumanUI::banContainer
	Transform_t3275118058 * ___banContainer_21;
	// Server HumanUI::server
	Server_t2724320767 * ___server_22;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_8() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___requestIntPrefab_8)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_8() const { return ___requestIntPrefab_8; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_8() { return &___requestIntPrefab_8; }
	inline void set_requestIntPrefab_8(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_8, value);
	}

	inline static int32_t get_offset_of_accountPrefab_9() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___accountPrefab_9)); }
	inline AccountUI_t1735092883 * get_accountPrefab_9() const { return ___accountPrefab_9; }
	inline AccountUI_t1735092883 ** get_address_of_accountPrefab_9() { return &___accountPrefab_9; }
	inline void set_accountPrefab_9(AccountUI_t1735092883 * value)
	{
		___accountPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___accountPrefab_9, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_10() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___requestStringPrefab_10)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_10() const { return ___requestStringPrefab_10; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_10() { return &___requestStringPrefab_10; }
	inline void set_requestStringPrefab_10(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_10, value);
	}

	inline static int32_t get_offset_of_requestLongPrefab_11() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___requestLongPrefab_11)); }
	inline RequestChangeLongUI_t921704931 * get_requestLongPrefab_11() const { return ___requestLongPrefab_11; }
	inline RequestChangeLongUI_t921704931 ** get_address_of_requestLongPrefab_11() { return &___requestLongPrefab_11; }
	inline void set_requestLongPrefab_11(RequestChangeLongUI_t921704931 * value)
	{
		___requestLongPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestLongPrefab_11, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_12() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___requestEnumPrefab_12)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_12() const { return ___requestEnumPrefab_12; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_12() { return &___requestEnumPrefab_12; }
	inline void set_requestEnumPrefab_12(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_12, value);
	}

	inline static int32_t get_offset_of_banPrefab_13() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___banPrefab_13)); }
	inline BanUI_t2500187775 * get_banPrefab_13() const { return ___banPrefab_13; }
	inline BanUI_t2500187775 ** get_address_of_banPrefab_13() { return &___banPrefab_13; }
	inline void set_banPrefab_13(BanUI_t2500187775 * value)
	{
		___banPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___banPrefab_13, value);
	}

	inline static int32_t get_offset_of_playerIdContainer_14() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___playerIdContainer_14)); }
	inline Transform_t3275118058 * get_playerIdContainer_14() const { return ___playerIdContainer_14; }
	inline Transform_t3275118058 ** get_address_of_playerIdContainer_14() { return &___playerIdContainer_14; }
	inline void set_playerIdContainer_14(Transform_t3275118058 * value)
	{
		___playerIdContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___playerIdContainer_14, value);
	}

	inline static int32_t get_offset_of_accountContainer_15() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___accountContainer_15)); }
	inline Transform_t3275118058 * get_accountContainer_15() const { return ___accountContainer_15; }
	inline Transform_t3275118058 ** get_address_of_accountContainer_15() { return &___accountContainer_15; }
	inline void set_accountContainer_15(Transform_t3275118058 * value)
	{
		___accountContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___accountContainer_15, value);
	}

	inline static int32_t get_offset_of_emailContainer_16() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___emailContainer_16)); }
	inline Transform_t3275118058 * get_emailContainer_16() const { return ___emailContainer_16; }
	inline Transform_t3275118058 ** get_address_of_emailContainer_16() { return &___emailContainer_16; }
	inline void set_emailContainer_16(Transform_t3275118058 * value)
	{
		___emailContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___emailContainer_16, value);
	}

	inline static int32_t get_offset_of_phoneNumberContainer_17() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___phoneNumberContainer_17)); }
	inline Transform_t3275118058 * get_phoneNumberContainer_17() const { return ___phoneNumberContainer_17; }
	inline Transform_t3275118058 ** get_address_of_phoneNumberContainer_17() { return &___phoneNumberContainer_17; }
	inline void set_phoneNumberContainer_17(Transform_t3275118058 * value)
	{
		___phoneNumberContainer_17 = value;
		Il2CppCodeGenWriteBarrier(&___phoneNumberContainer_17, value);
	}

	inline static int32_t get_offset_of_statusContainer_18() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___statusContainer_18)); }
	inline Transform_t3275118058 * get_statusContainer_18() const { return ___statusContainer_18; }
	inline Transform_t3275118058 ** get_address_of_statusContainer_18() { return &___statusContainer_18; }
	inline void set_statusContainer_18(Transform_t3275118058 * value)
	{
		___statusContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___statusContainer_18, value);
	}

	inline static int32_t get_offset_of_birthdayContainer_19() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___birthdayContainer_19)); }
	inline Transform_t3275118058 * get_birthdayContainer_19() const { return ___birthdayContainer_19; }
	inline Transform_t3275118058 ** get_address_of_birthdayContainer_19() { return &___birthdayContainer_19; }
	inline void set_birthdayContainer_19(Transform_t3275118058 * value)
	{
		___birthdayContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___birthdayContainer_19, value);
	}

	inline static int32_t get_offset_of_sexContainer_20() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___sexContainer_20)); }
	inline Transform_t3275118058 * get_sexContainer_20() const { return ___sexContainer_20; }
	inline Transform_t3275118058 ** get_address_of_sexContainer_20() { return &___sexContainer_20; }
	inline void set_sexContainer_20(Transform_t3275118058 * value)
	{
		___sexContainer_20 = value;
		Il2CppCodeGenWriteBarrier(&___sexContainer_20, value);
	}

	inline static int32_t get_offset_of_banContainer_21() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___banContainer_21)); }
	inline Transform_t3275118058 * get_banContainer_21() const { return ___banContainer_21; }
	inline Transform_t3275118058 ** get_address_of_banContainer_21() { return &___banContainer_21; }
	inline void set_banContainer_21(Transform_t3275118058 * value)
	{
		___banContainer_21 = value;
		Il2CppCodeGenWriteBarrier(&___banContainer_21, value);
	}

	inline static int32_t get_offset_of_server_22() { return static_cast<int32_t>(offsetof(HumanUI_t990511461, ___server_22)); }
	inline Server_t2724320767 * get_server_22() const { return ___server_22; }
	inline Server_t2724320767 ** get_address_of_server_22() { return &___server_22; }
	inline void set_server_22(Server_t2724320767 * value)
	{
		___server_22 = value;
		Il2CppCodeGenWriteBarrier(&___server_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
