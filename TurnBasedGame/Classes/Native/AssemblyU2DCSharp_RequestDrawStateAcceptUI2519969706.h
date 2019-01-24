#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen88566515.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameIsPlayingChange`1<RequestDrawStateAccept>
struct GameIsPlayingChange_1_t2381527478;
// GameCheckPlayerChange`1<RequestDrawStateAccept>
struct GameCheckPlayerChange_1_t100608533;
// RoomCheckChangeAdminChange`1<RequestDrawStateAccept>
struct RoomCheckChangeAdminChange_1_t259389130;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawStateAcceptUI
struct  RequestDrawStateAcceptUI_t2519969706  : public UIBehavior_1_t88566515
{
public:
	// UnityEngine.UI.Text RequestDrawStateAcceptUI::tvContent
	Text_t356221433 * ___tvContent_6;
	// UnityEngine.UI.Image RequestDrawStateAcceptUI::uiButton
	Image_t2042527209 * ___uiButton_7;
	// GameIsPlayingChange`1<RequestDrawStateAccept> RequestDrawStateAcceptUI::gameIsPlayingChange
	GameIsPlayingChange_1_t2381527478 * ___gameIsPlayingChange_8;
	// GameCheckPlayerChange`1<RequestDrawStateAccept> RequestDrawStateAcceptUI::gameCheckPlayerChange
	GameCheckPlayerChange_1_t100608533 * ___gameCheckPlayerChange_9;
	// RoomCheckChangeAdminChange`1<RequestDrawStateAccept> RequestDrawStateAcceptUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t259389130 * ___roomCheckAdminChange_10;

public:
	inline static int32_t get_offset_of_tvContent_6() { return static_cast<int32_t>(offsetof(RequestDrawStateAcceptUI_t2519969706, ___tvContent_6)); }
	inline Text_t356221433 * get_tvContent_6() const { return ___tvContent_6; }
	inline Text_t356221433 ** get_address_of_tvContent_6() { return &___tvContent_6; }
	inline void set_tvContent_6(Text_t356221433 * value)
	{
		___tvContent_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvContent_6, value);
	}

	inline static int32_t get_offset_of_uiButton_7() { return static_cast<int32_t>(offsetof(RequestDrawStateAcceptUI_t2519969706, ___uiButton_7)); }
	inline Image_t2042527209 * get_uiButton_7() const { return ___uiButton_7; }
	inline Image_t2042527209 ** get_address_of_uiButton_7() { return &___uiButton_7; }
	inline void set_uiButton_7(Image_t2042527209 * value)
	{
		___uiButton_7 = value;
		Il2CppCodeGenWriteBarrier(&___uiButton_7, value);
	}

	inline static int32_t get_offset_of_gameIsPlayingChange_8() { return static_cast<int32_t>(offsetof(RequestDrawStateAcceptUI_t2519969706, ___gameIsPlayingChange_8)); }
	inline GameIsPlayingChange_1_t2381527478 * get_gameIsPlayingChange_8() const { return ___gameIsPlayingChange_8; }
	inline GameIsPlayingChange_1_t2381527478 ** get_address_of_gameIsPlayingChange_8() { return &___gameIsPlayingChange_8; }
	inline void set_gameIsPlayingChange_8(GameIsPlayingChange_1_t2381527478 * value)
	{
		___gameIsPlayingChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_8, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_9() { return static_cast<int32_t>(offsetof(RequestDrawStateAcceptUI_t2519969706, ___gameCheckPlayerChange_9)); }
	inline GameCheckPlayerChange_1_t100608533 * get_gameCheckPlayerChange_9() const { return ___gameCheckPlayerChange_9; }
	inline GameCheckPlayerChange_1_t100608533 ** get_address_of_gameCheckPlayerChange_9() { return &___gameCheckPlayerChange_9; }
	inline void set_gameCheckPlayerChange_9(GameCheckPlayerChange_1_t100608533 * value)
	{
		___gameCheckPlayerChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_9, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_10() { return static_cast<int32_t>(offsetof(RequestDrawStateAcceptUI_t2519969706, ___roomCheckAdminChange_10)); }
	inline RoomCheckChangeAdminChange_1_t259389130 * get_roomCheckAdminChange_10() const { return ___roomCheckAdminChange_10; }
	inline RoomCheckChangeAdminChange_1_t259389130 ** get_address_of_roomCheckAdminChange_10() { return &___roomCheckAdminChange_10; }
	inline void set_roomCheckAdminChange_10(RoomCheckChangeAdminChange_1_t259389130 * value)
	{
		___roomCheckAdminChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
