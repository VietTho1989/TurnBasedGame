#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3269953254.h"

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

// RequestChangeUseRuleStateNoneUI
struct  RequestChangeUseRuleStateNoneUI_t307445893  : public UIBehavior_1_t3269953254
{
public:
	// UnityEngine.UI.Button RequestChangeUseRuleStateNoneUI::btnRequest
	Button_t2872111280 * ___btnRequest_6;
	// UnityEngine.UI.Text RequestChangeUseRuleStateNoneUI::tvRequest
	Text_t356221433 * ___tvRequest_7;
	// AdvancedCoroutines.Routine RequestChangeUseRuleStateNoneUI::wait
	Routine_t2502590640 * ___wait_8;
	// RequestChangeUseRule RequestChangeUseRuleStateNoneUI::requestChangeUseRule
	RequestChangeUseRule_t1485936882 * ___requestChangeUseRule_9;
	// Server RequestChangeUseRuleStateNoneUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_btnRequest_6() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateNoneUI_t307445893, ___btnRequest_6)); }
	inline Button_t2872111280 * get_btnRequest_6() const { return ___btnRequest_6; }
	inline Button_t2872111280 ** get_address_of_btnRequest_6() { return &___btnRequest_6; }
	inline void set_btnRequest_6(Button_t2872111280 * value)
	{
		___btnRequest_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnRequest_6, value);
	}

	inline static int32_t get_offset_of_tvRequest_7() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateNoneUI_t307445893, ___tvRequest_7)); }
	inline Text_t356221433 * get_tvRequest_7() const { return ___tvRequest_7; }
	inline Text_t356221433 ** get_address_of_tvRequest_7() { return &___tvRequest_7; }
	inline void set_tvRequest_7(Text_t356221433 * value)
	{
		___tvRequest_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvRequest_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateNoneUI_t307445893, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_requestChangeUseRule_9() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateNoneUI_t307445893, ___requestChangeUseRule_9)); }
	inline RequestChangeUseRule_t1485936882 * get_requestChangeUseRule_9() const { return ___requestChangeUseRule_9; }
	inline RequestChangeUseRule_t1485936882 ** get_address_of_requestChangeUseRule_9() { return &___requestChangeUseRule_9; }
	inline void set_requestChangeUseRule_9(RequestChangeUseRule_t1485936882 * value)
	{
		___requestChangeUseRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestChangeUseRule_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleStateNoneUI_t307445893, ___server_10)); }
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
