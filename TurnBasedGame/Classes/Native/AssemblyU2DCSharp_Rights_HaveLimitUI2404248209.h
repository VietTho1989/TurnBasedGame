#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen865918203.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.HaveLimitUI
struct  HaveLimitUI_t2404248209  : public UIBehavior_1_t865918203
{
public:
	// System.Boolean Rights.HaveLimitUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject Rights.HaveLimitUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeIntUI Rights.HaveLimitUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_8;
	// UnityEngine.Transform Rights.HaveLimitUI::limitContainer
	Transform_t3275118058 * ___limitContainer_9;
	// Server Rights.HaveLimitUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(HaveLimitUI_t2404248209, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(HaveLimitUI_t2404248209, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_8() { return static_cast<int32_t>(offsetof(HaveLimitUI_t2404248209, ___requestIntPrefab_8)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_8() const { return ___requestIntPrefab_8; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_8() { return &___requestIntPrefab_8; }
	inline void set_requestIntPrefab_8(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_8, value);
	}

	inline static int32_t get_offset_of_limitContainer_9() { return static_cast<int32_t>(offsetof(HaveLimitUI_t2404248209, ___limitContainer_9)); }
	inline Transform_t3275118058 * get_limitContainer_9() const { return ___limitContainer_9; }
	inline Transform_t3275118058 ** get_address_of_limitContainer_9() { return &___limitContainer_9; }
	inline void set_limitContainer_9(Transform_t3275118058 * value)
	{
		___limitContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___limitContainer_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(HaveLimitUI_t2404248209, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
