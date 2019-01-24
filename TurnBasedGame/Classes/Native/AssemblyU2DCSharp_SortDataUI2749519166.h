#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3907161999.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SortDataUI
struct  SortDataUI_t2749519166  : public UIBehavior_1_t3907161999
{
public:
	// System.Boolean SortDataUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject SortDataUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeStringUI SortDataUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_8;
	// RequestChangeEnumUI SortDataUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_9;
	// UnityEngine.Transform SortDataUI::filterContainer
	Transform_t3275118058 * ___filterContainer_10;
	// UnityEngine.Transform SortDataUI::sortTypeContainer
	Transform_t3275118058 * ___sortTypeContainer_11;
	// Server SortDataUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_8() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___requestStringPrefab_8)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_8() const { return ___requestStringPrefab_8; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_8() { return &___requestStringPrefab_8; }
	inline void set_requestStringPrefab_8(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_9() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___requestEnumPrefab_9)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_9() const { return ___requestEnumPrefab_9; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_9() { return &___requestEnumPrefab_9; }
	inline void set_requestEnumPrefab_9(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_9, value);
	}

	inline static int32_t get_offset_of_filterContainer_10() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___filterContainer_10)); }
	inline Transform_t3275118058 * get_filterContainer_10() const { return ___filterContainer_10; }
	inline Transform_t3275118058 ** get_address_of_filterContainer_10() { return &___filterContainer_10; }
	inline void set_filterContainer_10(Transform_t3275118058 * value)
	{
		___filterContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___filterContainer_10, value);
	}

	inline static int32_t get_offset_of_sortTypeContainer_11() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___sortTypeContainer_11)); }
	inline Transform_t3275118058 * get_sortTypeContainer_11() const { return ___sortTypeContainer_11; }
	inline Transform_t3275118058 ** get_address_of_sortTypeContainer_11() { return &___sortTypeContainer_11; }
	inline void set_sortTypeContainer_11(Transform_t3275118058 * value)
	{
		___sortTypeContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___sortTypeContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(SortDataUI_t2749519166, ___server_12)); }
	inline Server_t2724320767 * get_server_12() const { return ___server_12; }
	inline Server_t2724320767 ** get_address_of_server_12() { return &___server_12; }
	inline void set_server_12(Server_t2724320767 * value)
	{
		___server_12 = value;
		Il2CppCodeGenWriteBarrier(&___server_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
