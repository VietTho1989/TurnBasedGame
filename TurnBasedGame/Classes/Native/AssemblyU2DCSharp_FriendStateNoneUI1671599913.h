#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3281132380.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
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

// FriendStateNoneUI
struct  FriendStateNoneUI_t1671599913  : public UIBehavior_1_t3281132380
{
public:
	// UnityEngine.GameObject FriendStateNoneUI::requestingIndicator
	GameObject_t1756533147 * ___requestingIndicator_6;
	// UnityEngine.UI.Button FriendStateNoneUI::btnMakeFriend
	Button_t2872111280 * ___btnMakeFriend_7;
	// UnityEngine.UI.Button FriendStateNoneUI::btnBan
	Button_t2872111280 * ___btnBan_8;
	// AdvancedCoroutines.Routine FriendStateNoneUI::wait
	Routine_t2502590640 * ___wait_9;
	// Server FriendStateNoneUI::server
	Server_t2724320767 * ___server_10;
	// Friend FriendStateNoneUI::friend
	Friend_t3555014108 * ___friend_11;

public:
	inline static int32_t get_offset_of_requestingIndicator_6() { return static_cast<int32_t>(offsetof(FriendStateNoneUI_t1671599913, ___requestingIndicator_6)); }
	inline GameObject_t1756533147 * get_requestingIndicator_6() const { return ___requestingIndicator_6; }
	inline GameObject_t1756533147 ** get_address_of_requestingIndicator_6() { return &___requestingIndicator_6; }
	inline void set_requestingIndicator_6(GameObject_t1756533147 * value)
	{
		___requestingIndicator_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestingIndicator_6, value);
	}

	inline static int32_t get_offset_of_btnMakeFriend_7() { return static_cast<int32_t>(offsetof(FriendStateNoneUI_t1671599913, ___btnMakeFriend_7)); }
	inline Button_t2872111280 * get_btnMakeFriend_7() const { return ___btnMakeFriend_7; }
	inline Button_t2872111280 ** get_address_of_btnMakeFriend_7() { return &___btnMakeFriend_7; }
	inline void set_btnMakeFriend_7(Button_t2872111280 * value)
	{
		___btnMakeFriend_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnMakeFriend_7, value);
	}

	inline static int32_t get_offset_of_btnBan_8() { return static_cast<int32_t>(offsetof(FriendStateNoneUI_t1671599913, ___btnBan_8)); }
	inline Button_t2872111280 * get_btnBan_8() const { return ___btnBan_8; }
	inline Button_t2872111280 ** get_address_of_btnBan_8() { return &___btnBan_8; }
	inline void set_btnBan_8(Button_t2872111280 * value)
	{
		___btnBan_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnBan_8, value);
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(FriendStateNoneUI_t1671599913, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(FriendStateNoneUI_t1671599913, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}

	inline static int32_t get_offset_of_friend_11() { return static_cast<int32_t>(offsetof(FriendStateNoneUI_t1671599913, ___friend_11)); }
	inline Friend_t3555014108 * get_friend_11() const { return ___friend_11; }
	inline Friend_t3555014108 ** get_address_of_friend_11() { return &___friend_11; }
	inline void set_friend_11(Friend_t3555014108 * value)
	{
		___friend_11 = value;
		Il2CppCodeGenWriteBarrier(&___friend_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
