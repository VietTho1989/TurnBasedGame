#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1997928878.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateAcceptUI
struct  FriendStateAcceptUI_t1992713063  : public UIBehavior_1_t1997928878
{
public:
	// UnityEngine.UI.Button FriendStateAcceptUI::btnUnFriend
	Button_t2872111280 * ___btnUnFriend_6;
	// UnityEngine.GameObject FriendStateAcceptUI::requestingIndicator
	GameObject_t1756533147 * ___requestingIndicator_7;
	// AdvancedCoroutines.Routine FriendStateAcceptUI::wait
	Routine_t2502590640 * ___wait_8;
	// Server FriendStateAcceptUI::server
	Server_t2724320767 * ___server_9;

public:
	inline static int32_t get_offset_of_btnUnFriend_6() { return static_cast<int32_t>(offsetof(FriendStateAcceptUI_t1992713063, ___btnUnFriend_6)); }
	inline Button_t2872111280 * get_btnUnFriend_6() const { return ___btnUnFriend_6; }
	inline Button_t2872111280 ** get_address_of_btnUnFriend_6() { return &___btnUnFriend_6; }
	inline void set_btnUnFriend_6(Button_t2872111280 * value)
	{
		___btnUnFriend_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnFriend_6, value);
	}

	inline static int32_t get_offset_of_requestingIndicator_7() { return static_cast<int32_t>(offsetof(FriendStateAcceptUI_t1992713063, ___requestingIndicator_7)); }
	inline GameObject_t1756533147 * get_requestingIndicator_7() const { return ___requestingIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_requestingIndicator_7() { return &___requestingIndicator_7; }
	inline void set_requestingIndicator_7(GameObject_t1756533147 * value)
	{
		___requestingIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestingIndicator_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(FriendStateAcceptUI_t1992713063, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_server_9() { return static_cast<int32_t>(offsetof(FriendStateAcceptUI_t1992713063, ___server_9)); }
	inline Server_t2724320767 * get_server_9() const { return ___server_9; }
	inline Server_t2724320767 ** get_address_of_server_9() { return &___server_9; }
	inline void set_server_9(Server_t2724320767 * value)
	{
		___server_9 = value;
		Il2CppCodeGenWriteBarrier(&___server_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
