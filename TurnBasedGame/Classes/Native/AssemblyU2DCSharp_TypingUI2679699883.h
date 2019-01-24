#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4164524704.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// TypingSendUpdate
struct TypingSendUpdate_t2532589604;
// ChatRoom
struct ChatRoom_t3954744523;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingUI
struct  TypingUI_t2679699883  : public UIBehavior_1_t4164524704
{
public:
	// UnityEngine.UI.Text TypingUI::tvContent
	Text_t356221433 * ___tvContent_6;
	// TypingSendUpdate TypingUI::typingSendUpdate
	TypingSendUpdate_t2532589604 * ___typingSendUpdate_7;
	// ChatRoom TypingUI::chatRoom
	ChatRoom_t3954744523 * ___chatRoom_8;

public:
	inline static int32_t get_offset_of_tvContent_6() { return static_cast<int32_t>(offsetof(TypingUI_t2679699883, ___tvContent_6)); }
	inline Text_t356221433 * get_tvContent_6() const { return ___tvContent_6; }
	inline Text_t356221433 ** get_address_of_tvContent_6() { return &___tvContent_6; }
	inline void set_tvContent_6(Text_t356221433 * value)
	{
		___tvContent_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvContent_6, value);
	}

	inline static int32_t get_offset_of_typingSendUpdate_7() { return static_cast<int32_t>(offsetof(TypingUI_t2679699883, ___typingSendUpdate_7)); }
	inline TypingSendUpdate_t2532589604 * get_typingSendUpdate_7() const { return ___typingSendUpdate_7; }
	inline TypingSendUpdate_t2532589604 ** get_address_of_typingSendUpdate_7() { return &___typingSendUpdate_7; }
	inline void set_typingSendUpdate_7(TypingSendUpdate_t2532589604 * value)
	{
		___typingSendUpdate_7 = value;
		Il2CppCodeGenWriteBarrier(&___typingSendUpdate_7, value);
	}

	inline static int32_t get_offset_of_chatRoom_8() { return static_cast<int32_t>(offsetof(TypingUI_t2679699883, ___chatRoom_8)); }
	inline ChatRoom_t3954744523 * get_chatRoom_8() const { return ___chatRoom_8; }
	inline ChatRoom_t3954744523 ** get_address_of_chatRoom_8() { return &___chatRoom_8; }
	inline void set_chatRoom_8(ChatRoom_t3954744523 * value)
	{
		___chatRoom_8 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoom_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
