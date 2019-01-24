#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1431565449.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// RequestChangeUseRule
struct RequestChangeUseRule_t1485936882;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeUseRuleStateAskBtnAcceptUI
struct  RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574  : public UIBehavior_1_t1431565449
{
public:
	// System.Boolean RequestChangeUseRuleStateAskBtnAcceptUI::needReset
	bool ___needReset_6;
	// UnityEngine.UI.Button RequestChangeUseRuleStateAskBtnAcceptUI::btnAccept
	Button_t2872111280 * ___btnAccept_7;
	// UnityEngine.UI.Text RequestChangeUseRuleStateAskBtnAcceptUI::tvAccept
	Text_t356221433 * ___tvAccept_8;
	// AdvancedCoroutines.Routine RequestChangeUseRuleStateAskBtnAcceptUI::wait
	Routine_t2502590640 * ___wait_9;
	// RequestChangeUseRule RequestChangeUseRuleStateAskBtnAcceptUI::requestChangeUseRule
	RequestChangeUseRule_t1485936882 * ___requestChangeUseRule_10;
	// Server RequestChangeUseRuleStateAskBtnAcceptUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_btnAccept_7() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574, ___btnAccept_7)); }
	inline Button_t2872111280 * get_btnAccept_7() const { return ___btnAccept_7; }
	inline Button_t2872111280 ** get_address_of_btnAccept_7() { return &___btnAccept_7; }
	inline void set_btnAccept_7(Button_t2872111280 * value)
	{
		___btnAccept_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnAccept_7, value);
	}

	inline static int32_t get_offset_of_tvAccept_8() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574, ___tvAccept_8)); }
	inline Text_t356221433 * get_tvAccept_8() const { return ___tvAccept_8; }
	inline Text_t356221433 ** get_address_of_tvAccept_8() { return &___tvAccept_8; }
	inline void set_tvAccept_8(Text_t356221433 * value)
	{
		___tvAccept_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvAccept_8, value);
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_requestChangeUseRule_10() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574, ___requestChangeUseRule_10)); }
	inline RequestChangeUseRule_t1485936882 * get_requestChangeUseRule_10() const { return ___requestChangeUseRule_10; }
	inline RequestChangeUseRule_t1485936882 ** get_address_of_requestChangeUseRule_10() { return &___requestChangeUseRule_10; }
	inline void set_requestChangeUseRule_10(RequestChangeUseRule_t1485936882 * value)
	{
		___requestChangeUseRule_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestChangeUseRule_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateAskBtnAcceptUI_t2594799574, ___server_11)); }
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
