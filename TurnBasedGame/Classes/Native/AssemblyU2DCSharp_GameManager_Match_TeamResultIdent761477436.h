#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.TeamResult>
struct NetData_1_t3676286879;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.TeamResultIdentity
struct  TeamResultIdentity_t761477436  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.TeamResultIdentity::teamIndex
	int32_t ___teamIndex_17;
	// System.Single GameManager.Match.TeamResultIdentity::score
	float ___score_18;
	// NetData`1<GameManager.Match.TeamResult> GameManager.Match.TeamResultIdentity::netData
	NetData_1_t3676286879 * ___netData_19;

public:
	inline static int32_t get_offset_of_teamIndex_17() { return static_cast<int32_t>(offsetof(TeamResultIdentity_t761477436, ___teamIndex_17)); }
	inline int32_t get_teamIndex_17() const { return ___teamIndex_17; }
	inline int32_t* get_address_of_teamIndex_17() { return &___teamIndex_17; }
	inline void set_teamIndex_17(int32_t value)
	{
		___teamIndex_17 = value;
	}

	inline static int32_t get_offset_of_score_18() { return static_cast<int32_t>(offsetof(TeamResultIdentity_t761477436, ___score_18)); }
	inline float get_score_18() const { return ___score_18; }
	inline float* get_address_of_score_18() { return &___score_18; }
	inline void set_score_18(float value)
	{
		___score_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(TeamResultIdentity_t761477436, ___netData_19)); }
	inline NetData_1_t3676286879 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3676286879 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3676286879 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
