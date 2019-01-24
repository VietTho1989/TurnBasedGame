#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4153088199.h"

// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NewChatMessageNumberUI
struct  NewChatMessageNumberUI_t1030822160  : public UIBehavior_1_t4153088199
{
public:
	// RequestChangeStringUI NewChatMessageNumberUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_6;
	// UnityEngine.Transform NewChatMessageNumberUI::newCountContainer
	Transform_t3275118058 * ___newCountContainer_7;

public:
	inline static int32_t get_offset_of_requestStringPrefab_6() { return static_cast<int32_t>(offsetof(NewChatMessageNumberUI_t1030822160, ___requestStringPrefab_6)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_6() const { return ___requestStringPrefab_6; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_6() { return &___requestStringPrefab_6; }
	inline void set_requestStringPrefab_6(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_6, value);
	}

	inline static int32_t get_offset_of_newCountContainer_7() { return static_cast<int32_t>(offsetof(NewChatMessageNumberUI_t1030822160, ___newCountContainer_7)); }
	inline Transform_t3275118058 * get_newCountContainer_7() const { return ___newCountContainer_7; }
	inline Transform_t3275118058 ** get_address_of_newCountContainer_7() { return &___newCountContainer_7; }
	inline void set_newCountContainer_7(Transform_t3275118058 * value)
	{
		___newCountContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___newCountContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
