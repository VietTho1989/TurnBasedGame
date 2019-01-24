#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RequestNewContestManagerStateNone>
struct NetData_1_t2320926754;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewContestManagerStateNoneIdentity
struct  RequestNewContestManagerStateNoneIdentity_t2309197239  : public DataIdentity_t543951486
{
public:
	// NetData`1<GameManager.Match.RequestNewContestManagerStateNone> GameManager.Match.RequestNewContestManagerStateNoneIdentity::netData
	NetData_1_t2320926754 * ___netData_17;

public:
	inline static int32_t get_offset_of_netData_17() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateNoneIdentity_t2309197239, ___netData_17)); }
	inline NetData_1_t2320926754 * get_netData_17() const { return ___netData_17; }
	inline NetData_1_t2320926754 ** get_address_of_netData_17() { return &___netData_17; }
	inline void set_netData_17(NetData_1_t2320926754 * value)
	{
		___netData_17 = value;
		Il2CppCodeGenWriteBarrier(&___netData_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
