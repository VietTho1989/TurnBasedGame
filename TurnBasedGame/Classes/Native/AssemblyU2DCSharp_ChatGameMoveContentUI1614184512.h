#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3575226921.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// ChatMessage
struct ChatMessage_t2384228687;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatGameMoveContentUI
struct  ChatGameMoveContentUI_t1614184512  : public UIBehavior_1_t3575226921
{
public:
	// UnityEngine.UI.Text ChatGameMoveContentUI::tvTime
	Text_t356221433 * ___tvTime_6;
	// UnityEngine.UI.Text ChatGameMoveContentUI::tvContent
	Text_t356221433 * ___tvContent_7;
	// ChatMessage ChatGameMoveContentUI::chatMessage
	ChatMessage_t2384228687 * ___chatMessage_8;

public:
	inline static int32_t get_offset_of_tvTime_6() { return static_cast<int32_t>(offsetof(ChatGameMoveContentUI_t1614184512, ___tvTime_6)); }
	inline Text_t356221433 * get_tvTime_6() const { return ___tvTime_6; }
	inline Text_t356221433 ** get_address_of_tvTime_6() { return &___tvTime_6; }
	inline void set_tvTime_6(Text_t356221433 * value)
	{
		___tvTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvTime_6, value);
	}

	inline static int32_t get_offset_of_tvContent_7() { return static_cast<int32_t>(offsetof(ChatGameMoveContentUI_t1614184512, ___tvContent_7)); }
	inline Text_t356221433 * get_tvContent_7() const { return ___tvContent_7; }
	inline Text_t356221433 ** get_address_of_tvContent_7() { return &___tvContent_7; }
	inline void set_tvContent_7(Text_t356221433 * value)
	{
		___tvContent_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvContent_7, value);
	}

	inline static int32_t get_offset_of_chatMessage_8() { return static_cast<int32_t>(offsetof(ChatGameMoveContentUI_t1614184512, ___chatMessage_8)); }
	inline ChatMessage_t2384228687 * get_chatMessage_8() const { return ___chatMessage_8; }
	inline ChatMessage_t2384228687 ** get_address_of_chatMessage_8() { return &___chatMessage_8; }
	inline void set_chatMessage_8(ChatMessage_t2384228687 * value)
	{
		___chatMessage_8 = value;
		Il2CppCodeGenWriteBarrier(&___chatMessage_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
