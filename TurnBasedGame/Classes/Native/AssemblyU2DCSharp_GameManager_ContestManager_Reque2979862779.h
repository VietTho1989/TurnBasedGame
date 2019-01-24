#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1893195584.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameManager.ContestManager.RequestNewContestManagerStateAskUI/UIData
struct UIData_t2512304215;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI
struct  RequestNewContestManagerAskBtnCancelUI_t2979862779  : public UIBehavior_1_t1893195584
{
public:
	// UnityEngine.UI.Button GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI::btnCancel
	Button_t2872111280 * ___btnCancel_6;
	// UnityEngine.UI.Text GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI::tvCancel
	Text_t356221433 * ___tvCancel_7;
	// AdvancedCoroutines.Routine GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI::wait
	Routine_t2502590640 * ___wait_8;
	// GameManager.ContestManager.RequestNewContestManagerStateAskUI/UIData GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI::requestNewContestManagerStateAskUIData
	UIData_t2512304215 * ___requestNewContestManagerStateAskUIData_9;
	// Server GameManager.ContestManager.RequestNewContestManagerAskBtnCancelUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_btnCancel_6() { return static_cast<int32_t>(offsetof(RequestNewContestManagerAskBtnCancelUI_t2979862779, ___btnCancel_6)); }
	inline Button_t2872111280 * get_btnCancel_6() const { return ___btnCancel_6; }
	inline Button_t2872111280 ** get_address_of_btnCancel_6() { return &___btnCancel_6; }
	inline void set_btnCancel_6(Button_t2872111280 * value)
	{
		___btnCancel_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancel_6, value);
	}

	inline static int32_t get_offset_of_tvCancel_7() { return static_cast<int32_t>(offsetof(RequestNewContestManagerAskBtnCancelUI_t2979862779, ___tvCancel_7)); }
	inline Text_t356221433 * get_tvCancel_7() const { return ___tvCancel_7; }
	inline Text_t356221433 ** get_address_of_tvCancel_7() { return &___tvCancel_7; }
	inline void set_tvCancel_7(Text_t356221433 * value)
	{
		___tvCancel_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvCancel_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RequestNewContestManagerAskBtnCancelUI_t2979862779, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_requestNewContestManagerStateAskUIData_9() { return static_cast<int32_t>(offsetof(RequestNewContestManagerAskBtnCancelUI_t2979862779, ___requestNewContestManagerStateAskUIData_9)); }
	inline UIData_t2512304215 * get_requestNewContestManagerStateAskUIData_9() const { return ___requestNewContestManagerStateAskUIData_9; }
	inline UIData_t2512304215 ** get_address_of_requestNewContestManagerStateAskUIData_9() { return &___requestNewContestManagerStateAskUIData_9; }
	inline void set_requestNewContestManagerStateAskUIData_9(UIData_t2512304215 * value)
	{
		___requestNewContestManagerStateAskUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewContestManagerStateAskUIData_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(RequestNewContestManagerAskBtnCancelUI_t2979862779, ___server_10)); }
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
