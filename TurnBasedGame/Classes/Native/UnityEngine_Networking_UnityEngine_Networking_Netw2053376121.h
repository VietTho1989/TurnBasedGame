#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Networ33998832.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo
struct  PendingPlayerInfo_t2053376121 
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo::netId
	NetworkInstanceId_t33998832  ___netId_0;
	// System.Int16 UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo::playerControllerId
	int16_t ___playerControllerId_1;
	// UnityEngine.GameObject UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo::obj
	GameObject_t1756533147 * ___obj_2;

public:
	inline static int32_t get_offset_of_netId_0() { return static_cast<int32_t>(offsetof(PendingPlayerInfo_t2053376121, ___netId_0)); }
	inline NetworkInstanceId_t33998832  get_netId_0() const { return ___netId_0; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_0() { return &___netId_0; }
	inline void set_netId_0(NetworkInstanceId_t33998832  value)
	{
		___netId_0 = value;
	}

	inline static int32_t get_offset_of_playerControllerId_1() { return static_cast<int32_t>(offsetof(PendingPlayerInfo_t2053376121, ___playerControllerId_1)); }
	inline int16_t get_playerControllerId_1() const { return ___playerControllerId_1; }
	inline int16_t* get_address_of_playerControllerId_1() { return &___playerControllerId_1; }
	inline void set_playerControllerId_1(int16_t value)
	{
		___playerControllerId_1 = value;
	}

	inline static int32_t get_offset_of_obj_2() { return static_cast<int32_t>(offsetof(PendingPlayerInfo_t2053376121, ___obj_2)); }
	inline GameObject_t1756533147 * get_obj_2() const { return ___obj_2; }
	inline GameObject_t1756533147 ** get_address_of_obj_2() { return &___obj_2; }
	inline void set_obj_2(GameObject_t1756533147 * value)
	{
		___obj_2 = value;
		Il2CppCodeGenWriteBarrier(&___obj_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo
struct PendingPlayerInfo_t2053376121_marshaled_pinvoke
{
	NetworkInstanceId_t33998832  ___netId_0;
	int16_t ___playerControllerId_1;
	GameObject_t1756533147 * ___obj_2;
};
// Native definition for COM marshalling of UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo
struct PendingPlayerInfo_t2053376121_marshaled_com
{
	NetworkInstanceId_t33998832  ___netId_0;
	int16_t ___playerControllerId_1;
	GameObject_t1756533147 * ___obj_2;
};
