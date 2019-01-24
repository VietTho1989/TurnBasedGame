#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen663651281.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// UserUI/UIData
struct UIData_t695240280;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BtnUpdateUser
struct  BtnUpdateUser_t3342334074  : public UIBehavior_1_t663651281
{
public:
	// UnityEngine.UI.Button BtnUpdateUser::btnApply
	Button_t2872111280 * ___btnApply_6;
	// UnityEngine.UI.Text BtnUpdateUser::txtApply
	Text_t356221433 * ___txtApply_7;
	// AdvancedCoroutines.Routine BtnUpdateUser::wait
	Routine_t2502590640 * ___wait_8;
	// UserUI/UIData BtnUpdateUser::userUIData
	UIData_t695240280 * ___userUIData_9;
	// Server BtnUpdateUser::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_btnApply_6() { return static_cast<int32_t>(offsetof(BtnUpdateUser_t3342334074, ___btnApply_6)); }
	inline Button_t2872111280 * get_btnApply_6() const { return ___btnApply_6; }
	inline Button_t2872111280 ** get_address_of_btnApply_6() { return &___btnApply_6; }
	inline void set_btnApply_6(Button_t2872111280 * value)
	{
		___btnApply_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnApply_6, value);
	}

	inline static int32_t get_offset_of_txtApply_7() { return static_cast<int32_t>(offsetof(BtnUpdateUser_t3342334074, ___txtApply_7)); }
	inline Text_t356221433 * get_txtApply_7() const { return ___txtApply_7; }
	inline Text_t356221433 ** get_address_of_txtApply_7() { return &___txtApply_7; }
	inline void set_txtApply_7(Text_t356221433 * value)
	{
		___txtApply_7 = value;
		Il2CppCodeGenWriteBarrier(&___txtApply_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(BtnUpdateUser_t3342334074, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_userUIData_9() { return static_cast<int32_t>(offsetof(BtnUpdateUser_t3342334074, ___userUIData_9)); }
	inline UIData_t695240280 * get_userUIData_9() const { return ___userUIData_9; }
	inline UIData_t695240280 ** get_address_of_userUIData_9() { return &___userUIData_9; }
	inline void set_userUIData_9(UIData_t695240280 * value)
	{
		___userUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___userUIData_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(BtnUpdateUser_t3342334074, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
