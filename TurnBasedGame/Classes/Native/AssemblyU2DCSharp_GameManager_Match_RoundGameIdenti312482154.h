#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<GameManager.Match.RoundGame>
struct NetData_1_t3276412397;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGameIdentity
struct  RoundGameIdentity_t312482154  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.RoundGameIdentity::index
	int32_t ___index_17;
	// UnityEngine.Networking.SyncListInt GameManager.Match.RoundGameIdentity::playerInTeam
	SyncListInt_t3316705628 * ___playerInTeam_18;
	// UnityEngine.Networking.SyncListInt GameManager.Match.RoundGameIdentity::playerInGame
	SyncListInt_t3316705628 * ___playerInGame_19;
	// NetData`1<GameManager.Match.RoundGame> GameManager.Match.RoundGameIdentity::netData
	NetData_1_t3276412397 * ___netData_20;

public:
	inline static int32_t get_offset_of_index_17() { return static_cast<int32_t>(offsetof(RoundGameIdentity_t312482154, ___index_17)); }
	inline int32_t get_index_17() const { return ___index_17; }
	inline int32_t* get_address_of_index_17() { return &___index_17; }
	inline void set_index_17(int32_t value)
	{
		___index_17 = value;
	}

	inline static int32_t get_offset_of_playerInTeam_18() { return static_cast<int32_t>(offsetof(RoundGameIdentity_t312482154, ___playerInTeam_18)); }
	inline SyncListInt_t3316705628 * get_playerInTeam_18() const { return ___playerInTeam_18; }
	inline SyncListInt_t3316705628 ** get_address_of_playerInTeam_18() { return &___playerInTeam_18; }
	inline void set_playerInTeam_18(SyncListInt_t3316705628 * value)
	{
		___playerInTeam_18 = value;
		Il2CppCodeGenWriteBarrier(&___playerInTeam_18, value);
	}

	inline static int32_t get_offset_of_playerInGame_19() { return static_cast<int32_t>(offsetof(RoundGameIdentity_t312482154, ___playerInGame_19)); }
	inline SyncListInt_t3316705628 * get_playerInGame_19() const { return ___playerInGame_19; }
	inline SyncListInt_t3316705628 ** get_address_of_playerInGame_19() { return &___playerInGame_19; }
	inline void set_playerInGame_19(SyncListInt_t3316705628 * value)
	{
		___playerInGame_19 = value;
		Il2CppCodeGenWriteBarrier(&___playerInGame_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(RoundGameIdentity_t312482154, ___netData_20)); }
	inline NetData_1_t3276412397 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3276412397 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3276412397 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct RoundGameIdentity_t312482154_StaticFields
{
public:
	// System.Int32 GameManager.Match.RoundGameIdentity::kListplayerInTeam
	int32_t ___kListplayerInTeam_21;
	// System.Int32 GameManager.Match.RoundGameIdentity::kListplayerInGame
	int32_t ___kListplayerInGame_22;

public:
	inline static int32_t get_offset_of_kListplayerInTeam_21() { return static_cast<int32_t>(offsetof(RoundGameIdentity_t312482154_StaticFields, ___kListplayerInTeam_21)); }
	inline int32_t get_kListplayerInTeam_21() const { return ___kListplayerInTeam_21; }
	inline int32_t* get_address_of_kListplayerInTeam_21() { return &___kListplayerInTeam_21; }
	inline void set_kListplayerInTeam_21(int32_t value)
	{
		___kListplayerInTeam_21 = value;
	}

	inline static int32_t get_offset_of_kListplayerInGame_22() { return static_cast<int32_t>(offsetof(RoundGameIdentity_t312482154_StaticFields, ___kListplayerInGame_22)); }
	inline int32_t get_kListplayerInGame_22() const { return ___kListplayerInGame_22; }
	inline int32_t* get_address_of_kListplayerInGame_22() { return &___kListplayerInGame_22; }
	inline void set_kListplayerInGame_22(int32_t value)
	{
		___kListplayerInGame_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
