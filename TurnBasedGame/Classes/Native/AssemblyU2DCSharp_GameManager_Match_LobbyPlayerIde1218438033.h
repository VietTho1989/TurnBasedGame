#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.LobbyPlayer>
struct NetData_1_t1789201520;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyPlayerIdentity
struct  LobbyPlayerIdentity_t1218438033  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.LobbyPlayerIdentity::playerIndex
	int32_t ___playerIndex_17;
	// System.Boolean GameManager.Match.LobbyPlayerIdentity::isReady
	bool ___isReady_18;
	// NetData`1<GameManager.Match.LobbyPlayer> GameManager.Match.LobbyPlayerIdentity::netData
	NetData_1_t1789201520 * ___netData_19;

public:
	inline static int32_t get_offset_of_playerIndex_17() { return static_cast<int32_t>(offsetof(LobbyPlayerIdentity_t1218438033, ___playerIndex_17)); }
	inline int32_t get_playerIndex_17() const { return ___playerIndex_17; }
	inline int32_t* get_address_of_playerIndex_17() { return &___playerIndex_17; }
	inline void set_playerIndex_17(int32_t value)
	{
		___playerIndex_17 = value;
	}

	inline static int32_t get_offset_of_isReady_18() { return static_cast<int32_t>(offsetof(LobbyPlayerIdentity_t1218438033, ___isReady_18)); }
	inline bool get_isReady_18() const { return ___isReady_18; }
	inline bool* get_address_of_isReady_18() { return &___isReady_18; }
	inline void set_isReady_18(bool value)
	{
		___isReady_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(LobbyPlayerIdentity_t1218438033, ___netData_19)); }
	inline NetData_1_t1789201520 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1789201520 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1789201520 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
