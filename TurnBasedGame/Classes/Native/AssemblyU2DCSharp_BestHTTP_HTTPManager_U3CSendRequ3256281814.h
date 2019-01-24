#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// BestHTTP.ConnectionBase
struct ConnectionBase_t2782190729;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPManager/<SendRequestImpl>c__AnonStorey0
struct  U3CSendRequestImplU3Ec__AnonStorey0_t3256281814  : public Il2CppObject
{
public:
	// BestHTTP.ConnectionBase BestHTTP.HTTPManager/<SendRequestImpl>c__AnonStorey0::conn
	ConnectionBase_t2782190729 * ___conn_0;

public:
	inline static int32_t get_offset_of_conn_0() { return static_cast<int32_t>(offsetof(U3CSendRequestImplU3Ec__AnonStorey0_t3256281814, ___conn_0)); }
	inline ConnectionBase_t2782190729 * get_conn_0() const { return ___conn_0; }
	inline ConnectionBase_t2782190729 ** get_address_of_conn_0() { return &___conn_0; }
	inline void set_conn_0(ConnectionBase_t2782190729 * value)
	{
		___conn_0 = value;
		Il2CppCodeGenWriteBarrier(&___conn_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
