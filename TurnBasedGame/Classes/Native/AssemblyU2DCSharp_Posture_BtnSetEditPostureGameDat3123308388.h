#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1469838003.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;
// Posture.EditPostureGameDataUI/UIData
struct UIData_t1899453893;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.BtnSetEditPostureGameData
struct  BtnSetEditPostureGameData_t3123308388  : public UIBehavior_1_t1469838003
{
public:
	// UnityEngine.UI.Button Posture.BtnSetEditPostureGameData::btnSet
	Button_t2872111280 * ___btnSet_6;
	// UnityEngine.UI.Text Posture.BtnSetEditPostureGameData::tvSet
	Text_t356221433 * ___tvSet_7;
	// System.Boolean Posture.BtnSetEditPostureGameData::needReset
	bool ___needReset_8;
	// AdvancedCoroutines.Routine Posture.BtnSetEditPostureGameData::wait
	Routine_t2502590640 * ___wait_9;
	// Server Posture.BtnSetEditPostureGameData::server
	Server_t2724320767 * ___server_10;
	// Posture.EditPostureGameDataUI/UIData Posture.BtnSetEditPostureGameData::editPostureGameDataUIData
	UIData_t1899453893 * ___editPostureGameDataUIData_11;

public:
	inline static int32_t get_offset_of_btnSet_6() { return static_cast<int32_t>(offsetof(BtnSetEditPostureGameData_t3123308388, ___btnSet_6)); }
	inline Button_t2872111280 * get_btnSet_6() const { return ___btnSet_6; }
	inline Button_t2872111280 ** get_address_of_btnSet_6() { return &___btnSet_6; }
	inline void set_btnSet_6(Button_t2872111280 * value)
	{
		___btnSet_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnSet_6, value);
	}

	inline static int32_t get_offset_of_tvSet_7() { return static_cast<int32_t>(offsetof(BtnSetEditPostureGameData_t3123308388, ___tvSet_7)); }
	inline Text_t356221433 * get_tvSet_7() const { return ___tvSet_7; }
	inline Text_t356221433 ** get_address_of_tvSet_7() { return &___tvSet_7; }
	inline void set_tvSet_7(Text_t356221433 * value)
	{
		___tvSet_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvSet_7, value);
	}

	inline static int32_t get_offset_of_needReset_8() { return static_cast<int32_t>(offsetof(BtnSetEditPostureGameData_t3123308388, ___needReset_8)); }
	inline bool get_needReset_8() const { return ___needReset_8; }
	inline bool* get_address_of_needReset_8() { return &___needReset_8; }
	inline void set_needReset_8(bool value)
	{
		___needReset_8 = value;
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(BtnSetEditPostureGameData_t3123308388, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(BtnSetEditPostureGameData_t3123308388, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}

	inline static int32_t get_offset_of_editPostureGameDataUIData_11() { return static_cast<int32_t>(offsetof(BtnSetEditPostureGameData_t3123308388, ___editPostureGameDataUIData_11)); }
	inline UIData_t1899453893 * get_editPostureGameDataUIData_11() const { return ___editPostureGameDataUIData_11; }
	inline UIData_t1899453893 ** get_address_of_editPostureGameDataUIData_11() { return &___editPostureGameDataUIData_11; }
	inline void set_editPostureGameDataUIData_11(UIData_t1899453893 * value)
	{
		___editPostureGameDataUIData_11 = value;
		Il2CppCodeGenWriteBarrier(&___editPostureGameDataUIData_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
