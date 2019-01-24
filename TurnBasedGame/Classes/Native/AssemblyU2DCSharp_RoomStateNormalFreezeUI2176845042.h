#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1440020925.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomStateNormalFreezeUI
struct  RoomStateNormalFreezeUI_t2176845042  : public UIBehavior_1_t1440020925
{
public:
	// UnityEngine.UI.Button RoomStateNormalFreezeUI::btnFreeze
	Button_t2872111280 * ___btnFreeze_6;
	// UnityEngine.UI.Text RoomStateNormalFreezeUI::tvFreeze
	Text_t356221433 * ___tvFreeze_7;
	// AdvancedCoroutines.Routine RoomStateNormalFreezeUI::wait
	Routine_t2502590640 * ___wait_8;
	// Server RoomStateNormalFreezeUI::server
	Server_t2724320767 * ___server_9;

public:
	inline static int32_t get_offset_of_btnFreeze_6() { return static_cast<int32_t>(offsetof(RoomStateNormalFreezeUI_t2176845042, ___btnFreeze_6)); }
	inline Button_t2872111280 * get_btnFreeze_6() const { return ___btnFreeze_6; }
	inline Button_t2872111280 ** get_address_of_btnFreeze_6() { return &___btnFreeze_6; }
	inline void set_btnFreeze_6(Button_t2872111280 * value)
	{
		___btnFreeze_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnFreeze_6, value);
	}

	inline static int32_t get_offset_of_tvFreeze_7() { return static_cast<int32_t>(offsetof(RoomStateNormalFreezeUI_t2176845042, ___tvFreeze_7)); }
	inline Text_t356221433 * get_tvFreeze_7() const { return ___tvFreeze_7; }
	inline Text_t356221433 ** get_address_of_tvFreeze_7() { return &___tvFreeze_7; }
	inline void set_tvFreeze_7(Text_t356221433 * value)
	{
		___tvFreeze_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvFreeze_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RoomStateNormalFreezeUI_t2176845042, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_server_9() { return static_cast<int32_t>(offsetof(RoomStateNormalFreezeUI_t2176845042, ___server_9)); }
	inline Server_t2724320767 * get_server_9() const { return ___server_9; }
	inline Server_t2724320767 ** get_address_of_server_9() { return &___server_9; }
	inline void set_server_9(Server_t2724320767 * value)
	{
		___server_9 = value;
		Il2CppCodeGenWriteBarrier(&___server_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
