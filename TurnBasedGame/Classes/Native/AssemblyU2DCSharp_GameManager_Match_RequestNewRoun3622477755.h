#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RequestNewRoundNoLimit>
struct NetData_1_t3242689614;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundNoLimitIdentity
struct  RequestNewRoundNoLimitIdentity_t3622477755  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.RequestNewRoundNoLimitIdentity::isStopMakeMoreRound
	bool ___isStopMakeMoreRound_17;
	// NetData`1<GameManager.Match.RequestNewRoundNoLimit> GameManager.Match.RequestNewRoundNoLimitIdentity::netData
	NetData_1_t3242689614 * ___netData_18;

public:
	inline static int32_t get_offset_of_isStopMakeMoreRound_17() { return static_cast<int32_t>(offsetof(RequestNewRoundNoLimitIdentity_t3622477755, ___isStopMakeMoreRound_17)); }
	inline bool get_isStopMakeMoreRound_17() const { return ___isStopMakeMoreRound_17; }
	inline bool* get_address_of_isStopMakeMoreRound_17() { return &___isStopMakeMoreRound_17; }
	inline void set_isStopMakeMoreRound_17(bool value)
	{
		___isStopMakeMoreRound_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RequestNewRoundNoLimitIdentity_t3622477755, ___netData_18)); }
	inline NetData_1_t3242689614 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3242689614 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3242689614 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
