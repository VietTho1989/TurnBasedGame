#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3061958270.h"

// BtnChooseChatUI
struct BtnChooseChatUI_t3467192357;
// UnityEngine.Transform
struct Transform_t3275118058;
// ChatRoomUI
struct ChatRoomUI_t826248531;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalChatUI
struct  GlobalChatUI_t3148187871  : public UIBehavior_1_t3061958270
{
public:
	// BtnChooseChatUI GlobalChatUI::btnChooseChatPrefab
	BtnChooseChatUI_t3467192357 * ___btnChooseChatPrefab_6;
	// UnityEngine.Transform GlobalChatUI::btnChooseChatContainer
	Transform_t3275118058 * ___btnChooseChatContainer_7;
	// ChatRoomUI GlobalChatUI::chatRoomPrefab
	ChatRoomUI_t826248531 * ___chatRoomPrefab_8;
	// UnityEngine.Transform GlobalChatUI::chatRoomContainer
	Transform_t3275118058 * ___chatRoomContainer_9;

public:
	inline static int32_t get_offset_of_btnChooseChatPrefab_6() { return static_cast<int32_t>(offsetof(GlobalChatUI_t3148187871, ___btnChooseChatPrefab_6)); }
	inline BtnChooseChatUI_t3467192357 * get_btnChooseChatPrefab_6() const { return ___btnChooseChatPrefab_6; }
	inline BtnChooseChatUI_t3467192357 ** get_address_of_btnChooseChatPrefab_6() { return &___btnChooseChatPrefab_6; }
	inline void set_btnChooseChatPrefab_6(BtnChooseChatUI_t3467192357 * value)
	{
		___btnChooseChatPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnChooseChatPrefab_6, value);
	}

	inline static int32_t get_offset_of_btnChooseChatContainer_7() { return static_cast<int32_t>(offsetof(GlobalChatUI_t3148187871, ___btnChooseChatContainer_7)); }
	inline Transform_t3275118058 * get_btnChooseChatContainer_7() const { return ___btnChooseChatContainer_7; }
	inline Transform_t3275118058 ** get_address_of_btnChooseChatContainer_7() { return &___btnChooseChatContainer_7; }
	inline void set_btnChooseChatContainer_7(Transform_t3275118058 * value)
	{
		___btnChooseChatContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnChooseChatContainer_7, value);
	}

	inline static int32_t get_offset_of_chatRoomPrefab_8() { return static_cast<int32_t>(offsetof(GlobalChatUI_t3148187871, ___chatRoomPrefab_8)); }
	inline ChatRoomUI_t826248531 * get_chatRoomPrefab_8() const { return ___chatRoomPrefab_8; }
	inline ChatRoomUI_t826248531 ** get_address_of_chatRoomPrefab_8() { return &___chatRoomPrefab_8; }
	inline void set_chatRoomPrefab_8(ChatRoomUI_t826248531 * value)
	{
		___chatRoomPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoomPrefab_8, value);
	}

	inline static int32_t get_offset_of_chatRoomContainer_9() { return static_cast<int32_t>(offsetof(GlobalChatUI_t3148187871, ___chatRoomContainer_9)); }
	inline Transform_t3275118058 * get_chatRoomContainer_9() const { return ___chatRoomContainer_9; }
	inline Transform_t3275118058 ** get_address_of_chatRoomContainer_9() { return &___chatRoomContainer_9; }
	inline void set_chatRoomContainer_9(Transform_t3275118058 * value)
	{
		___chatRoomContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoomContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
