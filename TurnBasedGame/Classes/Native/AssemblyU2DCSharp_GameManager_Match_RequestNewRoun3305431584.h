#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RequestNewRoundHaveLimit>
struct NetData_1_t3700354787;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundHaveLimitIdentity
struct  RequestNewRoundHaveLimitIdentity_t3305431584  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.RequestNewRoundHaveLimitIdentity::maxRound
	int32_t ___maxRound_17;
	// System.Boolean GameManager.Match.RequestNewRoundHaveLimitIdentity::enoughScoreStop
	bool ___enoughScoreStop_18;
	// NetData`1<GameManager.Match.RequestNewRoundHaveLimit> GameManager.Match.RequestNewRoundHaveLimitIdentity::netData
	NetData_1_t3700354787 * ___netData_19;

public:
	inline static int32_t get_offset_of_maxRound_17() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitIdentity_t3305431584, ___maxRound_17)); }
	inline int32_t get_maxRound_17() const { return ___maxRound_17; }
	inline int32_t* get_address_of_maxRound_17() { return &___maxRound_17; }
	inline void set_maxRound_17(int32_t value)
	{
		___maxRound_17 = value;
	}

	inline static int32_t get_offset_of_enoughScoreStop_18() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitIdentity_t3305431584, ___enoughScoreStop_18)); }
	inline bool get_enoughScoreStop_18() const { return ___enoughScoreStop_18; }
	inline bool* get_address_of_enoughScoreStop_18() { return &___enoughScoreStop_18; }
	inline void set_enoughScoreStop_18(bool value)
	{
		___enoughScoreStop_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitIdentity_t3305431584, ___netData_19)); }
	inline NetData_1_t3700354787 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3700354787 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3700354787 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
