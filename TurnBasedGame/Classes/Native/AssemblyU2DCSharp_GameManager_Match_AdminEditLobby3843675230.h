#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen2879353748.h"

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

// GameManager.Match.AdminEditLobbyPlayerChooseHumanHolder
struct  AdminEditLobbyPlayerChooseHumanHolder_t3843675230  : public SriaHolderBehavior_1_t2879353748
{
public:
	// UnityEngine.UI.Text GameManager.Match.AdminEditLobbyPlayerChooseHumanHolder::tvName
	Text_t356221433 * ___tvName_16;
	// AccountAvatarUI GameManager.Match.AdminEditLobbyPlayerChooseHumanHolder::avatarPrefab
	AccountAvatarUI_t3584502088 * ___avatarPrefab_17;
	// UnityEngine.Transform GameManager.Match.AdminEditLobbyPlayerChooseHumanHolder::avatarContainer
	Transform_t3275118058 * ___avatarContainer_18;

public:
	inline static int32_t get_offset_of_tvName_16() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerChooseHumanHolder_t3843675230, ___tvName_16)); }
	inline Text_t356221433 * get_tvName_16() const { return ___tvName_16; }
	inline Text_t356221433 ** get_address_of_tvName_16() { return &___tvName_16; }
	inline void set_tvName_16(Text_t356221433 * value)
	{
		___tvName_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_16, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_17() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerChooseHumanHolder_t3843675230, ___avatarPrefab_17)); }
	inline AccountAvatarUI_t3584502088 * get_avatarPrefab_17() const { return ___avatarPrefab_17; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_avatarPrefab_17() { return &___avatarPrefab_17; }
	inline void set_avatarPrefab_17(AccountAvatarUI_t3584502088 * value)
	{
		___avatarPrefab_17 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_17, value);
	}

	inline static int32_t get_offset_of_avatarContainer_18() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerChooseHumanHolder_t3843675230, ___avatarContainer_18)); }
	inline Transform_t3275118058 * get_avatarContainer_18() const { return ___avatarContainer_18; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_18() { return &___avatarContainer_18; }
	inline void set_avatarContainer_18(Transform_t3275118058 * value)
	{
		___avatarContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
