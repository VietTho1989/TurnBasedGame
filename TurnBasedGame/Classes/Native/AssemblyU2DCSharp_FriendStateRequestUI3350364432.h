#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4114211609.h"

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

// FriendStateRequestUI
struct  FriendStateRequestUI_t3350364432  : public UIBehavior_1_t4114211609
{
public:
	// UnityEngine.GameObject FriendStateRequestUI::requestingIndicator
	GameObject_t1756533147 * ___requestingIndicator_6;
	// UnityEngine.UI.Button FriendStateRequestUI::btnAccept
	Button_t2872111280 * ___btnAccept_7;
	// UnityEngine.UI.Button FriendStateRequestUI::btnRefuse
	Button_t2872111280 * ___btnRefuse_8;
	// UnityEngine.UI.Button FriendStateRequestUI::btnCancel
	Button_t2872111280 * ___btnCancel_9;
	// AdvancedCoroutines.Routine FriendStateRequestUI::wait
	Routine_t2502590640 * ___wait_10;
	// Server FriendStateRequestUI::server
	Server_t2724320767 * ___server_11;
	// Friend FriendStateRequestUI::friend
	Friend_t3555014108 * ___friend_12;

public:
	inline static int32_t get_offset_of_requestingIndicator_6() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___requestingIndicator_6)); }
	inline GameObject_t1756533147 * get_requestingIndicator_6() const { return ___requestingIndicator_6; }
	inline GameObject_t1756533147 ** get_address_of_requestingIndicator_6() { return &___requestingIndicator_6; }
	inline void set_requestingIndicator_6(GameObject_t1756533147 * value)
	{
		___requestingIndicator_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestingIndicator_6, value);
	}

	inline static int32_t get_offset_of_btnAccept_7() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___btnAccept_7)); }
	inline Button_t2872111280 * get_btnAccept_7() const { return ___btnAccept_7; }
	inline Button_t2872111280 ** get_address_of_btnAccept_7() { return &___btnAccept_7; }
	inline void set_btnAccept_7(Button_t2872111280 * value)
	{
		___btnAccept_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnAccept_7, value);
	}

	inline static int32_t get_offset_of_btnRefuse_8() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___btnRefuse_8)); }
	inline Button_t2872111280 * get_btnRefuse_8() const { return ___btnRefuse_8; }
	inline Button_t2872111280 ** get_address_of_btnRefuse_8() { return &___btnRefuse_8; }
	inline void set_btnRefuse_8(Button_t2872111280 * value)
	{
		___btnRefuse_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnRefuse_8, value);
	}

	inline static int32_t get_offset_of_btnCancel_9() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___btnCancel_9)); }
	inline Button_t2872111280 * get_btnCancel_9() const { return ___btnCancel_9; }
	inline Button_t2872111280 ** get_address_of_btnCancel_9() { return &___btnCancel_9; }
	inline void set_btnCancel_9(Button_t2872111280 * value)
	{
		___btnCancel_9 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancel_9, value);
	}

	inline static int32_t get_offset_of_wait_10() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___wait_10)); }
	inline Routine_t2502590640 * get_wait_10() const { return ___wait_10; }
	inline Routine_t2502590640 ** get_address_of_wait_10() { return &___wait_10; }
	inline void set_wait_10(Routine_t2502590640 * value)
	{
		___wait_10 = value;
		Il2CppCodeGenWriteBarrier(&___wait_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}

	inline static int32_t get_offset_of_friend_12() { return static_cast<int32_t>(offsetof(FriendStateRequestUI_t3350364432, ___friend_12)); }
	inline Friend_t3555014108 * get_friend_12() const { return ___friend_12; }
	inline Friend_t3555014108 ** get_address_of_friend_12() { return &___friend_12; }
	inline void set_friend_12(Friend_t3555014108 * value)
	{
		___friend_12 = value;
		Il2CppCodeGenWriteBarrier(&___friend_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
