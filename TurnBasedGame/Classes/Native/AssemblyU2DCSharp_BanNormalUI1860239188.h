#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3525756907.h"

// User
struct User_t719925459;
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

// BanNormalUI
struct  BanNormalUI_t1860239188  : public UIBehavior_1_t3525756907
{
public:
	// User BanNormalUI::profileUser
	User_t719925459 * ___profileUser_6;
	// User BanNormalUI::toBanUser
	User_t719925459 * ___toBanUser_7;
	// UnityEngine.UI.Button BanNormalUI::btnBan
	Button_t2872111280 * ___btnBan_8;
	// UnityEngine.UI.Text BanNormalUI::txtRequestState
	Text_t356221433 * ___txtRequestState_9;
	// AdvancedCoroutines.Routine BanNormalUI::wait
	Routine_t2502590640 * ___wait_10;
	// Server BanNormalUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_profileUser_6() { return static_cast<int32_t>(offsetof(BanNormalUI_t1860239188, ___profileUser_6)); }
	inline User_t719925459 * get_profileUser_6() const { return ___profileUser_6; }
	inline User_t719925459 ** get_address_of_profileUser_6() { return &___profileUser_6; }
	inline void set_profileUser_6(User_t719925459 * value)
	{
		___profileUser_6 = value;
		Il2CppCodeGenWriteBarrier(&___profileUser_6, value);
	}

	inline static int32_t get_offset_of_toBanUser_7() { return static_cast<int32_t>(offsetof(BanNormalUI_t1860239188, ___toBanUser_7)); }
	inline User_t719925459 * get_toBanUser_7() const { return ___toBanUser_7; }
	inline User_t719925459 ** get_address_of_toBanUser_7() { return &___toBanUser_7; }
	inline void set_toBanUser_7(User_t719925459 * value)
	{
		___toBanUser_7 = value;
		Il2CppCodeGenWriteBarrier(&___toBanUser_7, value);
	}

	inline static int32_t get_offset_of_btnBan_8() { return static_cast<int32_t>(offsetof(BanNormalUI_t1860239188, ___btnBan_8)); }
	inline Button_t2872111280 * get_btnBan_8() const { return ___btnBan_8; }
	inline Button_t2872111280 ** get_address_of_btnBan_8() { return &___btnBan_8; }
	inline void set_btnBan_8(Button_t2872111280 * value)
	{
		___btnBan_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnBan_8, value);
	}

	inline static int32_t get_offset_of_txtRequestState_9() { return static_cast<int32_t>(offsetof(BanNormalUI_t1860239188, ___txtRequestState_9)); }
	inline Text_t356221433 * get_txtRequestState_9() const { return ___txtRequestState_9; }
	inline Text_t356221433 ** get_address_of_txtRequestState_9() { return &___txtRequestState_9; }
	inline void set_txtRequestState_9(Text_t356221433 * value)
	{
		___txtRequestState_9 = value;
		Il2CppCodeGenWriteBarrier(&___txtRequestState_9, value);
	}

	inline static int32_t get_offset_of_wait_10() { return static_cast<int32_t>(offsetof(BanNormalUI_t1860239188, ___wait_10)); }
	inline Routine_t2502590640 * get_wait_10() const { return ___wait_10; }
	inline Routine_t2502590640 ** get_address_of_wait_10() { return &___wait_10; }
	inline void set_wait_10(Routine_t2502590640 * value)
	{
		___wait_10 = value;
		Il2CppCodeGenWriteBarrier(&___wait_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(BanNormalUI_t1860239188, ___server_11)); }
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
