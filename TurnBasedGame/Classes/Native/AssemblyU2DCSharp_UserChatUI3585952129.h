#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1129437302.h"

// ChatRoomUI
struct ChatRoomUI_t826248531;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserChatUI
struct  UserChatUI_t3585952129  : public UIBehavior_1_t1129437302
{
public:
	// ChatRoomUI UserChatUI::chatRoomPrefab
	ChatRoomUI_t826248531 * ___chatRoomPrefab_6;
	// UnityEngine.Transform UserChatUI::chatRoomContainer
	Transform_t3275118058 * ___chatRoomContainer_7;

public:
	inline static int32_t get_offset_of_chatRoomPrefab_6() { return static_cast<int32_t>(offsetof(UserChatUI_t3585952129, ___chatRoomPrefab_6)); }
	inline ChatRoomUI_t826248531 * get_chatRoomPrefab_6() const { return ___chatRoomPrefab_6; }
	inline ChatRoomUI_t826248531 ** get_address_of_chatRoomPrefab_6() { return &___chatRoomPrefab_6; }
	inline void set_chatRoomPrefab_6(ChatRoomUI_t826248531 * value)
	{
		___chatRoomPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoomPrefab_6, value);
	}

	inline static int32_t get_offset_of_chatRoomContainer_7() { return static_cast<int32_t>(offsetof(UserChatUI_t3585952129, ___chatRoomContainer_7)); }
	inline Transform_t3275118058 * get_chatRoomContainer_7() const { return ___chatRoomContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chatRoomContainer_7() { return &___chatRoomContainer_7; }
	inline void set_chatRoomContainer_7(Transform_t3275118058 * value)
	{
		___chatRoomContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoomContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
