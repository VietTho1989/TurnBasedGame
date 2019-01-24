#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen769297005.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DiscoveredServerUI
struct  DiscoveredServerUI_t4068556825  : public UIBehavior_1_t769297005
{
public:
	// UnityEngine.UI.Text DiscoveredServerUI::tvVersion
	Text_t356221433 * ___tvVersion_6;
	// UnityEngine.UI.Text DiscoveredServerUI::tvIp
	Text_t356221433 * ___tvIp_7;
	// UnityEngine.UI.Text DiscoveredServerUI::tvPlayers
	Text_t356221433 * ___tvPlayers_8;

public:
	inline static int32_t get_offset_of_tvVersion_6() { return static_cast<int32_t>(offsetof(DiscoveredServerUI_t4068556825, ___tvVersion_6)); }
	inline Text_t356221433 * get_tvVersion_6() const { return ___tvVersion_6; }
	inline Text_t356221433 ** get_address_of_tvVersion_6() { return &___tvVersion_6; }
	inline void set_tvVersion_6(Text_t356221433 * value)
	{
		___tvVersion_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvVersion_6, value);
	}

	inline static int32_t get_offset_of_tvIp_7() { return static_cast<int32_t>(offsetof(DiscoveredServerUI_t4068556825, ___tvIp_7)); }
	inline Text_t356221433 * get_tvIp_7() const { return ___tvIp_7; }
	inline Text_t356221433 ** get_address_of_tvIp_7() { return &___tvIp_7; }
	inline void set_tvIp_7(Text_t356221433 * value)
	{
		___tvIp_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvIp_7, value);
	}

	inline static int32_t get_offset_of_tvPlayers_8() { return static_cast<int32_t>(offsetof(DiscoveredServerUI_t4068556825, ___tvPlayers_8)); }
	inline Text_t356221433 * get_tvPlayers_8() const { return ___tvPlayers_8; }
	inline Text_t356221433 ** get_address_of_tvPlayers_8() { return &___tvPlayers_8; }
	inline void set_tvPlayers_8(Text_t356221433 * value)
	{
		___tvPlayers_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvPlayers_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
