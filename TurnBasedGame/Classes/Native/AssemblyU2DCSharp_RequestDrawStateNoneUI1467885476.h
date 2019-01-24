#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4252708393.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// GameIsPlayingChange`1<RequestDrawStateNone>
struct GameIsPlayingChange_1_t2588357472;
// GameCheckPlayerChange`1<RequestDrawStateNone>
struct GameCheckPlayerChange_1_t307438527;
// RoomCheckChangeAdminChange`1<RequestDrawStateNone>
struct RoomCheckChangeAdminChange_1_t466219124;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawStateNoneUI
struct  RequestDrawStateNoneUI_t1467885476  : public UIBehavior_1_t4252708393
{
public:
	// UnityEngine.UI.Button RequestDrawStateNoneUI::btnRequestDraw
	Button_t2872111280 * ___btnRequestDraw_6;
	// GameIsPlayingChange`1<RequestDrawStateNone> RequestDrawStateNoneUI::gameIsPlayingChange
	GameIsPlayingChange_1_t2588357472 * ___gameIsPlayingChange_7;
	// GameCheckPlayerChange`1<RequestDrawStateNone> RequestDrawStateNoneUI::gameCheckPlayerChange
	GameCheckPlayerChange_1_t307438527 * ___gameCheckPlayerChange_8;
	// RoomCheckChangeAdminChange`1<RequestDrawStateNone> RequestDrawStateNoneUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t466219124 * ___roomCheckAdminChange_9;

public:
	inline static int32_t get_offset_of_btnRequestDraw_6() { return static_cast<int32_t>(offsetof(RequestDrawStateNoneUI_t1467885476, ___btnRequestDraw_6)); }
	inline Button_t2872111280 * get_btnRequestDraw_6() const { return ___btnRequestDraw_6; }
	inline Button_t2872111280 ** get_address_of_btnRequestDraw_6() { return &___btnRequestDraw_6; }
	inline void set_btnRequestDraw_6(Button_t2872111280 * value)
	{
		___btnRequestDraw_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnRequestDraw_6, value);
	}

	inline static int32_t get_offset_of_gameIsPlayingChange_7() { return static_cast<int32_t>(offsetof(RequestDrawStateNoneUI_t1467885476, ___gameIsPlayingChange_7)); }
	inline GameIsPlayingChange_1_t2588357472 * get_gameIsPlayingChange_7() const { return ___gameIsPlayingChange_7; }
	inline GameIsPlayingChange_1_t2588357472 ** get_address_of_gameIsPlayingChange_7() { return &___gameIsPlayingChange_7; }
	inline void set_gameIsPlayingChange_7(GameIsPlayingChange_1_t2588357472 * value)
	{
		___gameIsPlayingChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_7, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_8() { return static_cast<int32_t>(offsetof(RequestDrawStateNoneUI_t1467885476, ___gameCheckPlayerChange_8)); }
	inline GameCheckPlayerChange_1_t307438527 * get_gameCheckPlayerChange_8() const { return ___gameCheckPlayerChange_8; }
	inline GameCheckPlayerChange_1_t307438527 ** get_address_of_gameCheckPlayerChange_8() { return &___gameCheckPlayerChange_8; }
	inline void set_gameCheckPlayerChange_8(GameCheckPlayerChange_1_t307438527 * value)
	{
		___gameCheckPlayerChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_8, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_9() { return static_cast<int32_t>(offsetof(RequestDrawStateNoneUI_t1467885476, ___roomCheckAdminChange_9)); }
	inline RoomCheckChangeAdminChange_1_t466219124 * get_roomCheckAdminChange_9() const { return ___roomCheckAdminChange_9; }
	inline RoomCheckChangeAdminChange_1_t466219124 ** get_address_of_roomCheckAdminChange_9() { return &___roomCheckAdminChange_9; }
	inline void set_roomCheckAdminChange_9(RoomCheckChangeAdminChange_1_t466219124 * value)
	{
		___roomCheckAdminChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
