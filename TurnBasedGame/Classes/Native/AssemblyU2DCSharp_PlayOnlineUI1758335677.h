#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen331976302.h"

// MenuOnlineUI
struct MenuOnlineUI_t3176950206;
// ClientUI
struct ClientUI_t3739067731;
// ServerOnlineUI
struct ServerOnlineUI_t2936644942;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayOnlineUI
struct  PlayOnlineUI_t1758335677  : public UIBehavior_1_t331976302
{
public:
	// MenuOnlineUI PlayOnlineUI::menuOnlineUIPrefab
	MenuOnlineUI_t3176950206 * ___menuOnlineUIPrefab_6;
	// ClientUI PlayOnlineUI::clientUIPrefab
	ClientUI_t3739067731 * ___clientUIPrefab_7;
	// ServerOnlineUI PlayOnlineUI::serverUIPrefab
	ServerOnlineUI_t2936644942 * ___serverUIPrefab_8;

public:
	inline static int32_t get_offset_of_menuOnlineUIPrefab_6() { return static_cast<int32_t>(offsetof(PlayOnlineUI_t1758335677, ___menuOnlineUIPrefab_6)); }
	inline MenuOnlineUI_t3176950206 * get_menuOnlineUIPrefab_6() const { return ___menuOnlineUIPrefab_6; }
	inline MenuOnlineUI_t3176950206 ** get_address_of_menuOnlineUIPrefab_6() { return &___menuOnlineUIPrefab_6; }
	inline void set_menuOnlineUIPrefab_6(MenuOnlineUI_t3176950206 * value)
	{
		___menuOnlineUIPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___menuOnlineUIPrefab_6, value);
	}

	inline static int32_t get_offset_of_clientUIPrefab_7() { return static_cast<int32_t>(offsetof(PlayOnlineUI_t1758335677, ___clientUIPrefab_7)); }
	inline ClientUI_t3739067731 * get_clientUIPrefab_7() const { return ___clientUIPrefab_7; }
	inline ClientUI_t3739067731 ** get_address_of_clientUIPrefab_7() { return &___clientUIPrefab_7; }
	inline void set_clientUIPrefab_7(ClientUI_t3739067731 * value)
	{
		___clientUIPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clientUIPrefab_7, value);
	}

	inline static int32_t get_offset_of_serverUIPrefab_8() { return static_cast<int32_t>(offsetof(PlayOnlineUI_t1758335677, ___serverUIPrefab_8)); }
	inline ServerOnlineUI_t2936644942 * get_serverUIPrefab_8() const { return ___serverUIPrefab_8; }
	inline ServerOnlineUI_t2936644942 ** get_address_of_serverUIPrefab_8() { return &___serverUIPrefab_8; }
	inline void set_serverUIPrefab_8(ServerOnlineUI_t2936644942 * value)
	{
		___serverUIPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___serverUIPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
