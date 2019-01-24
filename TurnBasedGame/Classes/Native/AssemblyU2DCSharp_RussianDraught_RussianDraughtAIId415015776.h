#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<RussianDraught.RussianDraughtAI>
struct NetData_1_t340794691;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtAIIdentity
struct  RussianDraughtAIIdentity_t415015776  : public DataIdentity_t543951486
{
public:
	// System.Int32 RussianDraught.RussianDraughtAIIdentity::timeLimit
	int32_t ___timeLimit_17;
	// System.Int32 RussianDraught.RussianDraughtAIIdentity::pickBestMove
	int32_t ___pickBestMove_18;
	// NetData`1<RussianDraught.RussianDraughtAI> RussianDraught.RussianDraughtAIIdentity::netData
	NetData_1_t340794691 * ___netData_19;

public:
	inline static int32_t get_offset_of_timeLimit_17() { return static_cast<int32_t>(offsetof(RussianDraughtAIIdentity_t415015776, ___timeLimit_17)); }
	inline int32_t get_timeLimit_17() const { return ___timeLimit_17; }
	inline int32_t* get_address_of_timeLimit_17() { return &___timeLimit_17; }
	inline void set_timeLimit_17(int32_t value)
	{
		___timeLimit_17 = value;
	}

	inline static int32_t get_offset_of_pickBestMove_18() { return static_cast<int32_t>(offsetof(RussianDraughtAIIdentity_t415015776, ___pickBestMove_18)); }
	inline int32_t get_pickBestMove_18() const { return ___pickBestMove_18; }
	inline int32_t* get_address_of_pickBestMove_18() { return &___pickBestMove_18; }
	inline void set_pickBestMove_18(int32_t value)
	{
		___pickBestMove_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(RussianDraughtAIIdentity_t415015776, ___netData_19)); }
	inline NetData_1_t340794691 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t340794691 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t340794691 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
