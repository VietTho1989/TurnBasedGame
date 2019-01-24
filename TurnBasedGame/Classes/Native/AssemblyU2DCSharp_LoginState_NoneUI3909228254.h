#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1597410393.h"

// LoginState.StateNormalUI
struct StateNormalUI_t1007343942;
// LoginState.StateFailUI
struct StateFailUI_t2444815235;
// LoginState.StateSuccessUI
struct StateSuccessUI_t2865765836;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.NoneUI
struct  NoneUI_t3909228254  : public UIBehavior_1_t1597410393
{
public:
	// LoginState.StateNormalUI LoginState.NoneUI::stateNormalPrefab
	StateNormalUI_t1007343942 * ___stateNormalPrefab_6;
	// LoginState.StateFailUI LoginState.NoneUI::stateFailPrefab
	StateFailUI_t2444815235 * ___stateFailPrefab_7;
	// LoginState.StateSuccessUI LoginState.NoneUI::stateSuccessPrefab
	StateSuccessUI_t2865765836 * ___stateSuccessPrefab_8;
	// UnityEngine.Transform LoginState.NoneUI::stateContainer
	Transform_t3275118058 * ___stateContainer_9;

public:
	inline static int32_t get_offset_of_stateNormalPrefab_6() { return static_cast<int32_t>(offsetof(NoneUI_t3909228254, ___stateNormalPrefab_6)); }
	inline StateNormalUI_t1007343942 * get_stateNormalPrefab_6() const { return ___stateNormalPrefab_6; }
	inline StateNormalUI_t1007343942 ** get_address_of_stateNormalPrefab_6() { return &___stateNormalPrefab_6; }
	inline void set_stateNormalPrefab_6(StateNormalUI_t1007343942 * value)
	{
		___stateNormalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___stateNormalPrefab_6, value);
	}

	inline static int32_t get_offset_of_stateFailPrefab_7() { return static_cast<int32_t>(offsetof(NoneUI_t3909228254, ___stateFailPrefab_7)); }
	inline StateFailUI_t2444815235 * get_stateFailPrefab_7() const { return ___stateFailPrefab_7; }
	inline StateFailUI_t2444815235 ** get_address_of_stateFailPrefab_7() { return &___stateFailPrefab_7; }
	inline void set_stateFailPrefab_7(StateFailUI_t2444815235 * value)
	{
		___stateFailPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___stateFailPrefab_7, value);
	}

	inline static int32_t get_offset_of_stateSuccessPrefab_8() { return static_cast<int32_t>(offsetof(NoneUI_t3909228254, ___stateSuccessPrefab_8)); }
	inline StateSuccessUI_t2865765836 * get_stateSuccessPrefab_8() const { return ___stateSuccessPrefab_8; }
	inline StateSuccessUI_t2865765836 ** get_address_of_stateSuccessPrefab_8() { return &___stateSuccessPrefab_8; }
	inline void set_stateSuccessPrefab_8(StateSuccessUI_t2865765836 * value)
	{
		___stateSuccessPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___stateSuccessPrefab_8, value);
	}

	inline static int32_t get_offset_of_stateContainer_9() { return static_cast<int32_t>(offsetof(NoneUI_t3909228254, ___stateContainer_9)); }
	inline Transform_t3275118058 * get_stateContainer_9() const { return ___stateContainer_9; }
	inline Transform_t3275118058 ** get_address_of_stateContainer_9() { return &___stateContainer_9; }
	inline void set_stateContainer_9(Transform_t3275118058 * value)
	{
		___stateContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___stateContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
