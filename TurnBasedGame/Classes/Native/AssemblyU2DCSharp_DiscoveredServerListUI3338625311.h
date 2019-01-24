#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2363989406.h"

// DiscoveredServerUI
struct DiscoveredServerUI_t4068556825;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DiscoveredServerListUI
struct  DiscoveredServerListUI_t3338625311  : public UIBehavior_1_t2363989406
{
public:
	// DiscoveredServerUI DiscoveredServerListUI::serverPrefab
	DiscoveredServerUI_t4068556825 * ___serverPrefab_6;
	// UnityEngine.Transform DiscoveredServerListUI::content
	Transform_t3275118058 * ___content_7;

public:
	inline static int32_t get_offset_of_serverPrefab_6() { return static_cast<int32_t>(offsetof(DiscoveredServerListUI_t3338625311, ___serverPrefab_6)); }
	inline DiscoveredServerUI_t4068556825 * get_serverPrefab_6() const { return ___serverPrefab_6; }
	inline DiscoveredServerUI_t4068556825 ** get_address_of_serverPrefab_6() { return &___serverPrefab_6; }
	inline void set_serverPrefab_6(DiscoveredServerUI_t4068556825 * value)
	{
		___serverPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___serverPrefab_6, value);
	}

	inline static int32_t get_offset_of_content_7() { return static_cast<int32_t>(offsetof(DiscoveredServerListUI_t3338625311, ___content_7)); }
	inline Transform_t3275118058 * get_content_7() const { return ___content_7; }
	inline Transform_t3275118058 ** get_address_of_content_7() { return &___content_7; }
	inline void set_content_7(Transform_t3275118058 * value)
	{
		___content_7 = value;
		Il2CppCodeGenWriteBarrier(&___content_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
