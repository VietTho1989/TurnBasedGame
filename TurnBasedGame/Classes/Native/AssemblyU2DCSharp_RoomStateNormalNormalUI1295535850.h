#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen472857749.h"

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

// RoomStateNormalNormalUI
struct  RoomStateNormalNormalUI_t1295535850  : public UIBehavior_1_t472857749
{
public:
	// UnityEngine.UI.Button RoomStateNormalNormalUI::btnNormal
	Button_t2872111280 * ___btnNormal_6;
	// UnityEngine.UI.Text RoomStateNormalNormalUI::tvNormal
	Text_t356221433 * ___tvNormal_7;
	// AdvancedCoroutines.Routine RoomStateNormalNormalUI::wait
	Routine_t2502590640 * ___wait_8;
	// Server RoomStateNormalNormalUI::server
	Server_t2724320767 * ___server_9;

public:
	inline static int32_t get_offset_of_btnNormal_6() { return static_cast<int32_t>(offsetof(RoomStateNormalNormalUI_t1295535850, ___btnNormal_6)); }
	inline Button_t2872111280 * get_btnNormal_6() const { return ___btnNormal_6; }
	inline Button_t2872111280 ** get_address_of_btnNormal_6() { return &___btnNormal_6; }
	inline void set_btnNormal_6(Button_t2872111280 * value)
	{
		___btnNormal_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnNormal_6, value);
	}

	inline static int32_t get_offset_of_tvNormal_7() { return static_cast<int32_t>(offsetof(RoomStateNormalNormalUI_t1295535850, ___tvNormal_7)); }
	inline Text_t356221433 * get_tvNormal_7() const { return ___tvNormal_7; }
	inline Text_t356221433 ** get_address_of_tvNormal_7() { return &___tvNormal_7; }
	inline void set_tvNormal_7(Text_t356221433 * value)
	{
		___tvNormal_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvNormal_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RoomStateNormalNormalUI_t1295535850, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_server_9() { return static_cast<int32_t>(offsetof(RoomStateNormalNormalUI_t1295535850, ___server_9)); }
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
