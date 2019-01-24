#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen2654807123.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.LobbyPlayerAdapter
struct LobbyPlayerAdapter_t1090902582;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyTeamHolder
struct  LobbyTeamHolder_t233716569  : public SriaHolderBehavior_1_t2654807123
{
public:
	// UnityEngine.UI.Text GameManager.Match.LobbyTeamHolder::tvTeamIndex
	Text_t356221433 * ___tvTeamIndex_16;
	// GameManager.Match.LobbyPlayerAdapter GameManager.Match.LobbyTeamHolder::playerAdapterPrefab
	LobbyPlayerAdapter_t1090902582 * ___playerAdapterPrefab_17;
	// UnityEngine.Transform GameManager.Match.LobbyTeamHolder::playerAdapterContainer
	Transform_t3275118058 * ___playerAdapterContainer_18;

public:
	inline static int32_t get_offset_of_tvTeamIndex_16() { return static_cast<int32_t>(offsetof(LobbyTeamHolder_t233716569, ___tvTeamIndex_16)); }
	inline Text_t356221433 * get_tvTeamIndex_16() const { return ___tvTeamIndex_16; }
	inline Text_t356221433 ** get_address_of_tvTeamIndex_16() { return &___tvTeamIndex_16; }
	inline void set_tvTeamIndex_16(Text_t356221433 * value)
	{
		___tvTeamIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvTeamIndex_16, value);
	}

	inline static int32_t get_offset_of_playerAdapterPrefab_17() { return static_cast<int32_t>(offsetof(LobbyTeamHolder_t233716569, ___playerAdapterPrefab_17)); }
	inline LobbyPlayerAdapter_t1090902582 * get_playerAdapterPrefab_17() const { return ___playerAdapterPrefab_17; }
	inline LobbyPlayerAdapter_t1090902582 ** get_address_of_playerAdapterPrefab_17() { return &___playerAdapterPrefab_17; }
	inline void set_playerAdapterPrefab_17(LobbyPlayerAdapter_t1090902582 * value)
	{
		___playerAdapterPrefab_17 = value;
		Il2CppCodeGenWriteBarrier(&___playerAdapterPrefab_17, value);
	}

	inline static int32_t get_offset_of_playerAdapterContainer_18() { return static_cast<int32_t>(offsetof(LobbyTeamHolder_t233716569, ___playerAdapterContainer_18)); }
	inline Transform_t3275118058 * get_playerAdapterContainer_18() const { return ___playerAdapterContainer_18; }
	inline Transform_t3275118058 ** get_address_of_playerAdapterContainer_18() { return &___playerAdapterContainer_18; }
	inline void set_playerAdapterContainer_18(Transform_t3275118058 * value)
	{
		___playerAdapterContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___playerAdapterContainer_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
