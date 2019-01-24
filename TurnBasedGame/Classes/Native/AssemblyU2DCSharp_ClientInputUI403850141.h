#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2116246334.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// ClientInputNoneUI
struct ClientInputNoneUI_t773335015;
// ClientInputSendUI
struct ClientInputSendUI_t2019273637;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientInputUI
struct  ClientInputUI_t403850141  : public UIBehavior_1_t2116246334
{
public:
	// UnityEngine.Transform ClientInputUI::subContainer
	Transform_t3275118058 * ___subContainer_6;
	// ClientInputNoneUI ClientInputUI::nonePrefab
	ClientInputNoneUI_t773335015 * ___nonePrefab_7;
	// ClientInputSendUI ClientInputUI::sendPrefab
	ClientInputSendUI_t2019273637 * ___sendPrefab_8;

public:
	inline static int32_t get_offset_of_subContainer_6() { return static_cast<int32_t>(offsetof(ClientInputUI_t403850141, ___subContainer_6)); }
	inline Transform_t3275118058 * get_subContainer_6() const { return ___subContainer_6; }
	inline Transform_t3275118058 ** get_address_of_subContainer_6() { return &___subContainer_6; }
	inline void set_subContainer_6(Transform_t3275118058 * value)
	{
		___subContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_6, value);
	}

	inline static int32_t get_offset_of_nonePrefab_7() { return static_cast<int32_t>(offsetof(ClientInputUI_t403850141, ___nonePrefab_7)); }
	inline ClientInputNoneUI_t773335015 * get_nonePrefab_7() const { return ___nonePrefab_7; }
	inline ClientInputNoneUI_t773335015 ** get_address_of_nonePrefab_7() { return &___nonePrefab_7; }
	inline void set_nonePrefab_7(ClientInputNoneUI_t773335015 * value)
	{
		___nonePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_7, value);
	}

	inline static int32_t get_offset_of_sendPrefab_8() { return static_cast<int32_t>(offsetof(ClientInputUI_t403850141, ___sendPrefab_8)); }
	inline ClientInputSendUI_t2019273637 * get_sendPrefab_8() const { return ___sendPrefab_8; }
	inline ClientInputSendUI_t2019273637 ** get_address_of_sendPrefab_8() { return &___sendPrefab_8; }
	inline void set_sendPrefab_8(ClientInputSendUI_t2019273637 * value)
	{
		___sendPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___sendPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
