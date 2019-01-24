#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen1951968540.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// AccountAvatarUI
struct AccountAvatarUI_t3584502088;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserHolder
struct  RoomUserHolder_t1048028558  : public SriaHolderBehavior_1_t1951968540
{
public:
	// UnityEngine.UI.Text RoomUserHolder::tvName
	Text_t356221433 * ___tvName_16;
	// UnityEngine.UI.Text RoomUserHolder::tvRole
	Text_t356221433 * ___tvRole_17;
	// UnityEngine.UI.Text RoomUserHolder::tvState
	Text_t356221433 * ___tvState_18;
	// AccountAvatarUI RoomUserHolder::avatarPrefab
	AccountAvatarUI_t3584502088 * ___avatarPrefab_19;
	// UnityEngine.Transform RoomUserHolder::avatarContainer
	Transform_t3275118058 * ___avatarContainer_20;

public:
	inline static int32_t get_offset_of_tvName_16() { return static_cast<int32_t>(offsetof(RoomUserHolder_t1048028558, ___tvName_16)); }
	inline Text_t356221433 * get_tvName_16() const { return ___tvName_16; }
	inline Text_t356221433 ** get_address_of_tvName_16() { return &___tvName_16; }
	inline void set_tvName_16(Text_t356221433 * value)
	{
		___tvName_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_16, value);
	}

	inline static int32_t get_offset_of_tvRole_17() { return static_cast<int32_t>(offsetof(RoomUserHolder_t1048028558, ___tvRole_17)); }
	inline Text_t356221433 * get_tvRole_17() const { return ___tvRole_17; }
	inline Text_t356221433 ** get_address_of_tvRole_17() { return &___tvRole_17; }
	inline void set_tvRole_17(Text_t356221433 * value)
	{
		___tvRole_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvRole_17, value);
	}

	inline static int32_t get_offset_of_tvState_18() { return static_cast<int32_t>(offsetof(RoomUserHolder_t1048028558, ___tvState_18)); }
	inline Text_t356221433 * get_tvState_18() const { return ___tvState_18; }
	inline Text_t356221433 ** get_address_of_tvState_18() { return &___tvState_18; }
	inline void set_tvState_18(Text_t356221433 * value)
	{
		___tvState_18 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_18, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_19() { return static_cast<int32_t>(offsetof(RoomUserHolder_t1048028558, ___avatarPrefab_19)); }
	inline AccountAvatarUI_t3584502088 * get_avatarPrefab_19() const { return ___avatarPrefab_19; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_avatarPrefab_19() { return &___avatarPrefab_19; }
	inline void set_avatarPrefab_19(AccountAvatarUI_t3584502088 * value)
	{
		___avatarPrefab_19 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_19, value);
	}

	inline static int32_t get_offset_of_avatarContainer_20() { return static_cast<int32_t>(offsetof(RoomUserHolder_t1048028558, ___avatarContainer_20)); }
	inline Transform_t3275118058 * get_avatarContainer_20() const { return ___avatarContainer_20; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_20() { return &___avatarContainer_20; }
	inline void set_avatarContainer_20(Transform_t3275118058 * value)
	{
		___avatarContainer_20 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
