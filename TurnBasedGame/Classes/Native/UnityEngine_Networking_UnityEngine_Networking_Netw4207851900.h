#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo>
struct List_1_t1422497253;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers
struct  ConnectionPendingPlayers_t4207851900 
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo> UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers::players
	List_1_t1422497253 * ___players_0;

public:
	inline static int32_t get_offset_of_players_0() { return static_cast<int32_t>(offsetof(ConnectionPendingPlayers_t4207851900, ___players_0)); }
	inline List_1_t1422497253 * get_players_0() const { return ___players_0; }
	inline List_1_t1422497253 ** get_address_of_players_0() { return &___players_0; }
	inline void set_players_0(List_1_t1422497253 * value)
	{
		___players_0 = value;
		Il2CppCodeGenWriteBarrier(&___players_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers
struct ConnectionPendingPlayers_t4207851900_marshaled_pinvoke
{
	List_1_t1422497253 * ___players_0;
};
// Native definition for COM marshalling of UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers
struct ConnectionPendingPlayers_t4207851900_marshaled_com
{
	List_1_t1422497253 * ___players_0;
};
