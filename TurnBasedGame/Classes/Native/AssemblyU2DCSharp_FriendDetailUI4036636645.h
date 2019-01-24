#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2583261430.h"

// ChatRoomUI
struct ChatRoomUI_t826248531;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendDetailUI
struct  FriendDetailUI_t4036636645  : public UIBehavior_1_t2583261430
{
public:
	// ChatRoomUI FriendDetailUI::chatRoomPrefab
	ChatRoomUI_t826248531 * ___chatRoomPrefab_6;
	// UnityEngine.Transform FriendDetailUI::chatRoomContainer
	Transform_t3275118058 * ___chatRoomContainer_7;

public:
	inline static int32_t get_offset_of_chatRoomPrefab_6() { return static_cast<int32_t>(offsetof(FriendDetailUI_t4036636645, ___chatRoomPrefab_6)); }
	inline ChatRoomUI_t826248531 * get_chatRoomPrefab_6() const { return ___chatRoomPrefab_6; }
	inline ChatRoomUI_t826248531 ** get_address_of_chatRoomPrefab_6() { return &___chatRoomPrefab_6; }
	inline void set_chatRoomPrefab_6(ChatRoomUI_t826248531 * value)
	{
		___chatRoomPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoomPrefab_6, value);
	}

	inline static int32_t get_offset_of_chatRoomContainer_7() { return static_cast<int32_t>(offsetof(FriendDetailUI_t4036636645, ___chatRoomContainer_7)); }
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
