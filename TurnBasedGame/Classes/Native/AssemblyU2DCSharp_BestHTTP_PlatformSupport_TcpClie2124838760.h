#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Threading.ManualResetEvent
struct ManualResetEvent_t926074657;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.PlatformSupport.TcpClient.General.TcpClient/<Connect>c__AnonStorey0
struct  U3CConnectU3Ec__AnonStorey0_t2124838760  : public Il2CppObject
{
public:
	// System.Threading.ManualResetEvent BestHTTP.PlatformSupport.TcpClient.General.TcpClient/<Connect>c__AnonStorey0::mre
	ManualResetEvent_t926074657 * ___mre_0;

public:
	inline static int32_t get_offset_of_mre_0() { return static_cast<int32_t>(offsetof(U3CConnectU3Ec__AnonStorey0_t2124838760, ___mre_0)); }
	inline ManualResetEvent_t926074657 * get_mre_0() const { return ___mre_0; }
	inline ManualResetEvent_t926074657 ** get_address_of_mre_0() { return &___mre_0; }
	inline void set_mre_0(ManualResetEvent_t926074657 * value)
	{
		___mre_0 = value;
		Il2CppCodeGenWriteBarrier(&___mre_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
