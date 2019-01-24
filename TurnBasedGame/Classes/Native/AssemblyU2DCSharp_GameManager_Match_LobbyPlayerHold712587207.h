#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3491188970.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// InformAvatarUI
struct InformAvatarUI_t2288633734;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.LobbyPlayerBtnSetReady
struct LobbyPlayerBtnSetReady_t83975174;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyPlayerHolder
struct  LobbyPlayerHolder_t712587207  : public UIBehavior_1_t3491188970
{
public:
	// UnityEngine.UI.Text GameManager.Match.LobbyPlayerHolder::tvName
	Text_t356221433 * ___tvName_6;
	// UnityEngine.UI.Text GameManager.Match.LobbyPlayerHolder::tvPlayerIndex
	Text_t356221433 * ___tvPlayerIndex_7;
	// InformAvatarUI GameManager.Match.LobbyPlayerHolder::avatarPrefab
	InformAvatarUI_t2288633734 * ___avatarPrefab_8;
	// UnityEngine.Transform GameManager.Match.LobbyPlayerHolder::avatarContainer
	Transform_t3275118058 * ___avatarContainer_9;
	// GameManager.Match.LobbyPlayerBtnSetReady GameManager.Match.LobbyPlayerHolder::btnReadyPrefab
	LobbyPlayerBtnSetReady_t83975174 * ___btnReadyPrefab_10;
	// UnityEngine.Transform GameManager.Match.LobbyPlayerHolder::btnReadyContainer
	Transform_t3275118058 * ___btnReadyContainer_11;

public:
	inline static int32_t get_offset_of_tvName_6() { return static_cast<int32_t>(offsetof(LobbyPlayerHolder_t712587207, ___tvName_6)); }
	inline Text_t356221433 * get_tvName_6() const { return ___tvName_6; }
	inline Text_t356221433 ** get_address_of_tvName_6() { return &___tvName_6; }
	inline void set_tvName_6(Text_t356221433 * value)
	{
		___tvName_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_6, value);
	}

	inline static int32_t get_offset_of_tvPlayerIndex_7() { return static_cast<int32_t>(offsetof(LobbyPlayerHolder_t712587207, ___tvPlayerIndex_7)); }
	inline Text_t356221433 * get_tvPlayerIndex_7() const { return ___tvPlayerIndex_7; }
	inline Text_t356221433 ** get_address_of_tvPlayerIndex_7() { return &___tvPlayerIndex_7; }
	inline void set_tvPlayerIndex_7(Text_t356221433 * value)
	{
		___tvPlayerIndex_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvPlayerIndex_7, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_8() { return static_cast<int32_t>(offsetof(LobbyPlayerHolder_t712587207, ___avatarPrefab_8)); }
	inline InformAvatarUI_t2288633734 * get_avatarPrefab_8() const { return ___avatarPrefab_8; }
	inline InformAvatarUI_t2288633734 ** get_address_of_avatarPrefab_8() { return &___avatarPrefab_8; }
	inline void set_avatarPrefab_8(InformAvatarUI_t2288633734 * value)
	{
		___avatarPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_8, value);
	}

	inline static int32_t get_offset_of_avatarContainer_9() { return static_cast<int32_t>(offsetof(LobbyPlayerHolder_t712587207, ___avatarContainer_9)); }
	inline Transform_t3275118058 * get_avatarContainer_9() const { return ___avatarContainer_9; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_9() { return &___avatarContainer_9; }
	inline void set_avatarContainer_9(Transform_t3275118058 * value)
	{
		___avatarContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_9, value);
	}

	inline static int32_t get_offset_of_btnReadyPrefab_10() { return static_cast<int32_t>(offsetof(LobbyPlayerHolder_t712587207, ___btnReadyPrefab_10)); }
	inline LobbyPlayerBtnSetReady_t83975174 * get_btnReadyPrefab_10() const { return ___btnReadyPrefab_10; }
	inline LobbyPlayerBtnSetReady_t83975174 ** get_address_of_btnReadyPrefab_10() { return &___btnReadyPrefab_10; }
	inline void set_btnReadyPrefab_10(LobbyPlayerBtnSetReady_t83975174 * value)
	{
		___btnReadyPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___btnReadyPrefab_10, value);
	}

	inline static int32_t get_offset_of_btnReadyContainer_11() { return static_cast<int32_t>(offsetof(LobbyPlayerHolder_t712587207, ___btnReadyContainer_11)); }
	inline Transform_t3275118058 * get_btnReadyContainer_11() const { return ___btnReadyContainer_11; }
	inline Transform_t3275118058 ** get_address_of_btnReadyContainer_11() { return &___btnReadyContainer_11; }
	inline void set_btnReadyContainer_11(Transform_t3275118058 * value)
	{
		___btnReadyContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___btnReadyContainer_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
