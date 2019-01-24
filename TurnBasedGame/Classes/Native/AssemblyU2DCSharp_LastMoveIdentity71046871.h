#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<LastMove>
struct NetData_1_t3749406042;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LastMoveIdentity
struct  LastMoveIdentity_t71046871  : public DataIdentity_t543951486
{
public:
	// System.Int32 LastMoveIdentity::turn
	int32_t ___turn_17;
	// NetData`1<LastMove> LastMoveIdentity::netData
	NetData_1_t3749406042 * ___netData_18;

public:
	inline static int32_t get_offset_of_turn_17() { return static_cast<int32_t>(offsetof(LastMoveIdentity_t71046871, ___turn_17)); }
	inline int32_t get_turn_17() const { return ___turn_17; }
	inline int32_t* get_address_of_turn_17() { return &___turn_17; }
	inline void set_turn_17(int32_t value)
	{
		___turn_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(LastMoveIdentity_t71046871, ___netData_18)); }
	inline NetData_1_t3749406042 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3749406042 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3749406042 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
