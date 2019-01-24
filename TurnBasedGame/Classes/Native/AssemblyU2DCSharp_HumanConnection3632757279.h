#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<UnityEngine.Networking.NetworkConnection>
struct VP_1_t485544912;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanConnection
struct  HumanConnection_t3632757279  : public Data_t3569509720
{
public:
	// VP`1<System.UInt32> HumanConnection::playerId
	VP_1_t2527959027 * ___playerId_5;
	// VP`1<UnityEngine.Networking.NetworkConnection> HumanConnection::connection
	VP_1_t485544912 * ___connection_6;

public:
	inline static int32_t get_offset_of_playerId_5() { return static_cast<int32_t>(offsetof(HumanConnection_t3632757279, ___playerId_5)); }
	inline VP_1_t2527959027 * get_playerId_5() const { return ___playerId_5; }
	inline VP_1_t2527959027 ** get_address_of_playerId_5() { return &___playerId_5; }
	inline void set_playerId_5(VP_1_t2527959027 * value)
	{
		___playerId_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerId_5, value);
	}

	inline static int32_t get_offset_of_connection_6() { return static_cast<int32_t>(offsetof(HumanConnection_t3632757279, ___connection_6)); }
	inline VP_1_t485544912 * get_connection_6() const { return ___connection_6; }
	inline VP_1_t485544912 ** get_address_of_connection_6() { return &___connection_6; }
	inline void set_connection_6(VP_1_t485544912 * value)
	{
		___connection_6 = value;
		Il2CppCodeGenWriteBarrier(&___connection_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
