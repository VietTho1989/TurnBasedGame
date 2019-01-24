#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen403860717.h"

// GameManager.Match.NormalEditLobbyPlayerBtnSetUI
struct NormalEditLobbyPlayerBtnSetUI_t1651374228;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.NormalEditLobbyPlayerBtnEmptyUI
struct NormalEditLobbyPlayerBtnEmptyUI_t4289746797;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.NormalEditLobbyPlayerUI
struct  NormalEditLobbyPlayerUI_t1765868628  : public UIBehavior_1_t403860717
{
public:
	// GameManager.Match.NormalEditLobbyPlayerBtnSetUI GameManager.Match.NormalEditLobbyPlayerUI::btnSetPrefab
	NormalEditLobbyPlayerBtnSetUI_t1651374228 * ___btnSetPrefab_6;
	// UnityEngine.Transform GameManager.Match.NormalEditLobbyPlayerUI::btnSetContainer
	Transform_t3275118058 * ___btnSetContainer_7;
	// GameManager.Match.NormalEditLobbyPlayerBtnEmptyUI GameManager.Match.NormalEditLobbyPlayerUI::btnEmptyPrefab
	NormalEditLobbyPlayerBtnEmptyUI_t4289746797 * ___btnEmptyPrefab_8;
	// UnityEngine.Transform GameManager.Match.NormalEditLobbyPlayerUI::btnEmptyContainer
	Transform_t3275118058 * ___btnEmptyContainer_9;

public:
	inline static int32_t get_offset_of_btnSetPrefab_6() { return static_cast<int32_t>(offsetof(NormalEditLobbyPlayerUI_t1765868628, ___btnSetPrefab_6)); }
	inline NormalEditLobbyPlayerBtnSetUI_t1651374228 * get_btnSetPrefab_6() const { return ___btnSetPrefab_6; }
	inline NormalEditLobbyPlayerBtnSetUI_t1651374228 ** get_address_of_btnSetPrefab_6() { return &___btnSetPrefab_6; }
	inline void set_btnSetPrefab_6(NormalEditLobbyPlayerBtnSetUI_t1651374228 * value)
	{
		___btnSetPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnSetPrefab_6, value);
	}

	inline static int32_t get_offset_of_btnSetContainer_7() { return static_cast<int32_t>(offsetof(NormalEditLobbyPlayerUI_t1765868628, ___btnSetContainer_7)); }
	inline Transform_t3275118058 * get_btnSetContainer_7() const { return ___btnSetContainer_7; }
	inline Transform_t3275118058 ** get_address_of_btnSetContainer_7() { return &___btnSetContainer_7; }
	inline void set_btnSetContainer_7(Transform_t3275118058 * value)
	{
		___btnSetContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnSetContainer_7, value);
	}

	inline static int32_t get_offset_of_btnEmptyPrefab_8() { return static_cast<int32_t>(offsetof(NormalEditLobbyPlayerUI_t1765868628, ___btnEmptyPrefab_8)); }
	inline NormalEditLobbyPlayerBtnEmptyUI_t4289746797 * get_btnEmptyPrefab_8() const { return ___btnEmptyPrefab_8; }
	inline NormalEditLobbyPlayerBtnEmptyUI_t4289746797 ** get_address_of_btnEmptyPrefab_8() { return &___btnEmptyPrefab_8; }
	inline void set_btnEmptyPrefab_8(NormalEditLobbyPlayerBtnEmptyUI_t4289746797 * value)
	{
		___btnEmptyPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnEmptyPrefab_8, value);
	}

	inline static int32_t get_offset_of_btnEmptyContainer_9() { return static_cast<int32_t>(offsetof(NormalEditLobbyPlayerUI_t1765868628, ___btnEmptyContainer_9)); }
	inline Transform_t3275118058 * get_btnEmptyContainer_9() const { return ___btnEmptyContainer_9; }
	inline Transform_t3275118058 ** get_address_of_btnEmptyContainer_9() { return &___btnEmptyContainer_9; }
	inline void set_btnEmptyContainer_9(Transform_t3275118058 * value)
	{
		___btnEmptyContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___btnEmptyContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
