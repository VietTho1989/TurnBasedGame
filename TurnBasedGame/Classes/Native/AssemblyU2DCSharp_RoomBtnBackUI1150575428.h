#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2613736741.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// RoomBtnBackConfirmUI
struct RoomBtnBackConfirmUI_t451739796;
// RoomCheckChangeAdminChange`1<Room>
struct RoomCheckChangeAdminChange_1_t232354087;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomBtnBackUI
struct  RoomBtnBackUI_t1150575428  : public UIBehavior_1_t2613736741
{
public:
	// UnityEngine.UI.Button RoomBtnBackUI::btnBack
	Button_t2872111280 * ___btnBack_6;
	// UnityEngine.UI.Text RoomBtnBackUI::tvBack
	Text_t356221433 * ___tvBack_7;
	// AdvancedCoroutines.Routine RoomBtnBackUI::wait
	Routine_t2502590640 * ___wait_8;
	// RoomBtnBackConfirmUI RoomBtnBackUI::confirmPrefab
	RoomBtnBackConfirmUI_t451739796 * ___confirmPrefab_9;
	// RoomCheckChangeAdminChange`1<Room> RoomBtnBackUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t232354087 * ___roomCheckAdminChange_10;
	// Server RoomBtnBackUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_btnBack_6() { return static_cast<int32_t>(offsetof(RoomBtnBackUI_t1150575428, ___btnBack_6)); }
	inline Button_t2872111280 * get_btnBack_6() const { return ___btnBack_6; }
	inline Button_t2872111280 ** get_address_of_btnBack_6() { return &___btnBack_6; }
	inline void set_btnBack_6(Button_t2872111280 * value)
	{
		___btnBack_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnBack_6, value);
	}

	inline static int32_t get_offset_of_tvBack_7() { return static_cast<int32_t>(offsetof(RoomBtnBackUI_t1150575428, ___tvBack_7)); }
	inline Text_t356221433 * get_tvBack_7() const { return ___tvBack_7; }
	inline Text_t356221433 ** get_address_of_tvBack_7() { return &___tvBack_7; }
	inline void set_tvBack_7(Text_t356221433 * value)
	{
		___tvBack_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvBack_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RoomBtnBackUI_t1150575428, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_confirmPrefab_9() { return static_cast<int32_t>(offsetof(RoomBtnBackUI_t1150575428, ___confirmPrefab_9)); }
	inline RoomBtnBackConfirmUI_t451739796 * get_confirmPrefab_9() const { return ___confirmPrefab_9; }
	inline RoomBtnBackConfirmUI_t451739796 ** get_address_of_confirmPrefab_9() { return &___confirmPrefab_9; }
	inline void set_confirmPrefab_9(RoomBtnBackConfirmUI_t451739796 * value)
	{
		___confirmPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___confirmPrefab_9, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_10() { return static_cast<int32_t>(offsetof(RoomBtnBackUI_t1150575428, ___roomCheckAdminChange_10)); }
	inline RoomCheckChangeAdminChange_1_t232354087 * get_roomCheckAdminChange_10() const { return ___roomCheckAdminChange_10; }
	inline RoomCheckChangeAdminChange_1_t232354087 ** get_address_of_roomCheckAdminChange_10() { return &___roomCheckAdminChange_10; }
	inline void set_roomCheckAdminChange_10(RoomCheckChangeAdminChange_1_t232354087 * value)
	{
		___roomCheckAdminChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(RoomBtnBackUI_t1150575428, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
