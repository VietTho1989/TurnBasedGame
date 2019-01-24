#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen398266276.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// GlobalChatUI/UIData
struct UIData_t3777883418;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BtnChooseChatUI
struct  BtnChooseChatUI_t3467192357  : public UIBehavior_1_t398266276
{
public:
	// UnityEngine.UI.Button BtnChooseChatUI::btnTopic
	Button_t2872111280 * ___btnTopic_6;
	// UnityEngine.UI.Text BtnChooseChatUI::txtTopic
	Text_t356221433 * ___txtTopic_7;
	// GlobalChatUI/UIData BtnChooseChatUI::globalChatUIData
	UIData_t3777883418 * ___globalChatUIData_8;

public:
	inline static int32_t get_offset_of_btnTopic_6() { return static_cast<int32_t>(offsetof(BtnChooseChatUI_t3467192357, ___btnTopic_6)); }
	inline Button_t2872111280 * get_btnTopic_6() const { return ___btnTopic_6; }
	inline Button_t2872111280 ** get_address_of_btnTopic_6() { return &___btnTopic_6; }
	inline void set_btnTopic_6(Button_t2872111280 * value)
	{
		___btnTopic_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnTopic_6, value);
	}

	inline static int32_t get_offset_of_txtTopic_7() { return static_cast<int32_t>(offsetof(BtnChooseChatUI_t3467192357, ___txtTopic_7)); }
	inline Text_t356221433 * get_txtTopic_7() const { return ___txtTopic_7; }
	inline Text_t356221433 ** get_address_of_txtTopic_7() { return &___txtTopic_7; }
	inline void set_txtTopic_7(Text_t356221433 * value)
	{
		___txtTopic_7 = value;
		Il2CppCodeGenWriteBarrier(&___txtTopic_7, value);
	}

	inline static int32_t get_offset_of_globalChatUIData_8() { return static_cast<int32_t>(offsetof(BtnChooseChatUI_t3467192357, ___globalChatUIData_8)); }
	inline UIData_t3777883418 * get_globalChatUIData_8() const { return ___globalChatUIData_8; }
	inline UIData_t3777883418 ** get_address_of_globalChatUIData_8() { return &___globalChatUIData_8; }
	inline void set_globalChatUIData_8(UIData_t3777883418 * value)
	{
		___globalChatUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___globalChatUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
