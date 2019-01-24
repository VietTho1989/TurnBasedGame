#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3979240285.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;
// Friend
struct Friend_t3555014108;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateBanUI
struct  FriendStateBanUI_t3381559536  : public UIBehavior_1_t3979240285
{
public:
	// UnityEngine.UI.Button FriendStateBanUI::btnUnBan
	Button_t2872111280 * ___btnUnBan_6;
	// UnityEngine.GameObject FriendStateBanUI::requestingIndicator
	GameObject_t1756533147 * ___requestingIndicator_7;
	// AdvancedCoroutines.Routine FriendStateBanUI::wait
	Routine_t2502590640 * ___wait_8;
	// Server FriendStateBanUI::server
	Server_t2724320767 * ___server_9;
	// Friend FriendStateBanUI::friend
	Friend_t3555014108 * ___friend_10;

public:
	inline static int32_t get_offset_of_btnUnBan_6() { return static_cast<int32_t>(offsetof(FriendStateBanUI_t3381559536, ___btnUnBan_6)); }
	inline Button_t2872111280 * get_btnUnBan_6() const { return ___btnUnBan_6; }
	inline Button_t2872111280 ** get_address_of_btnUnBan_6() { return &___btnUnBan_6; }
	inline void set_btnUnBan_6(Button_t2872111280 * value)
	{
		___btnUnBan_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnBan_6, value);
	}

	inline static int32_t get_offset_of_requestingIndicator_7() { return static_cast<int32_t>(offsetof(FriendStateBanUI_t3381559536, ___requestingIndicator_7)); }
	inline GameObject_t1756533147 * get_requestingIndicator_7() const { return ___requestingIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_requestingIndicator_7() { return &___requestingIndicator_7; }
	inline void set_requestingIndicator_7(GameObject_t1756533147 * value)
	{
		___requestingIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestingIndicator_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(FriendStateBanUI_t3381559536, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_server_9() { return static_cast<int32_t>(offsetof(FriendStateBanUI_t3381559536, ___server_9)); }
	inline Server_t2724320767 * get_server_9() const { return ___server_9; }
	inline Server_t2724320767 ** get_address_of_server_9() { return &___server_9; }
	inline void set_server_9(Server_t2724320767 * value)
	{
		___server_9 = value;
		Il2CppCodeGenWriteBarrier(&___server_9, value);
	}

	inline static int32_t get_offset_of_friend_10() { return static_cast<int32_t>(offsetof(FriendStateBanUI_t3381559536, ___friend_10)); }
	inline Friend_t3555014108 * get_friend_10() const { return ___friend_10; }
	inline Friend_t3555014108 ** get_address_of_friend_10() { return &___friend_10; }
	inline void set_friend_10(Friend_t3555014108 * value)
	{
		___friend_10 = value;
		Il2CppCodeGenWriteBarrier(&___friend_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
