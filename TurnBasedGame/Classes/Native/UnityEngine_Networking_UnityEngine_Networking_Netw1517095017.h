#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkLobbyManager/PendingPlayer
struct  PendingPlayer_t1517095017 
{
public:
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkLobbyManager/PendingPlayer::conn
	NetworkConnection_t107267906 * ___conn_0;
	// UnityEngine.GameObject UnityEngine.Networking.NetworkLobbyManager/PendingPlayer::lobbyPlayer
	GameObject_t1756533147 * ___lobbyPlayer_1;

public:
	inline static int32_t get_offset_of_conn_0() { return static_cast<int32_t>(offsetof(PendingPlayer_t1517095017, ___conn_0)); }
	inline NetworkConnection_t107267906 * get_conn_0() const { return ___conn_0; }
	inline NetworkConnection_t107267906 ** get_address_of_conn_0() { return &___conn_0; }
	inline void set_conn_0(NetworkConnection_t107267906 * value)
	{
		___conn_0 = value;
		Il2CppCodeGenWriteBarrier(&___conn_0, value);
	}

	inline static int32_t get_offset_of_lobbyPlayer_1() { return static_cast<int32_t>(offsetof(PendingPlayer_t1517095017, ___lobbyPlayer_1)); }
	inline GameObject_t1756533147 * get_lobbyPlayer_1() const { return ___lobbyPlayer_1; }
	inline GameObject_t1756533147 ** get_address_of_lobbyPlayer_1() { return &___lobbyPlayer_1; }
	inline void set_lobbyPlayer_1(GameObject_t1756533147 * value)
	{
		___lobbyPlayer_1 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Networking.NetworkLobbyManager/PendingPlayer
struct PendingPlayer_t1517095017_marshaled_pinvoke
{
	NetworkConnection_t107267906 * ___conn_0;
	GameObject_t1756533147 * ___lobbyPlayer_1;
};
// Native definition for COM marshalling of UnityEngine.Networking.NetworkLobbyManager/PendingPlayer
struct PendingPlayer_t1517095017_marshaled_com
{
	NetworkConnection_t107267906 * ___conn_0;
	GameObject_t1756533147 * ___lobbyPlayer_1;
};
