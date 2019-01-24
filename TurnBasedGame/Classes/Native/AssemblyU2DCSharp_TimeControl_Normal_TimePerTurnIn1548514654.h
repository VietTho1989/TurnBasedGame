#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1234302238.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeFloatUI
struct RequestChangeFloatUI_t3993257673;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimePerTurnInfoLimitUI
struct  TimePerTurnInfoLimitUI_t1548514654  : public UIBehavior_1_t1234302238
{
public:
	// System.Boolean TimeControl.Normal.TimePerTurnInfoLimitUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject TimeControl.Normal.TimePerTurnInfoLimitUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeFloatUI TimeControl.Normal.TimePerTurnInfoLimitUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_8;
	// UnityEngine.Transform TimeControl.Normal.TimePerTurnInfoLimitUI::perTurnContainer
	Transform_t3275118058 * ___perTurnContainer_9;
	// Server TimeControl.Normal.TimePerTurnInfoLimitUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitUI_t1548514654, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitUI_t1548514654, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestFloatPrefab_8() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitUI_t1548514654, ___requestFloatPrefab_8)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_8() const { return ___requestFloatPrefab_8; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_8() { return &___requestFloatPrefab_8; }
	inline void set_requestFloatPrefab_8(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_8, value);
	}

	inline static int32_t get_offset_of_perTurnContainer_9() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitUI_t1548514654, ___perTurnContainer_9)); }
	inline Transform_t3275118058 * get_perTurnContainer_9() const { return ___perTurnContainer_9; }
	inline Transform_t3275118058 ** get_address_of_perTurnContainer_9() { return &___perTurnContainer_9; }
	inline void set_perTurnContainer_9(Transform_t3275118058 * value)
	{
		___perTurnContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___perTurnContainer_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitUI_t1548514654, ___server_10)); }
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
