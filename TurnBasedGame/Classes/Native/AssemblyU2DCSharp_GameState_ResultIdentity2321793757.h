#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_GameState_Result_Reason1558683199.h"

// NetData`1<GameState.Result>
struct NetData_1_t2498976648;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.ResultIdentity
struct  ResultIdentity_t2321793757  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameState.ResultIdentity::playerIndex
	int32_t ___playerIndex_17;
	// System.Single GameState.ResultIdentity::score
	float ___score_18;
	// GameState.Result/Reason GameState.ResultIdentity::reason
	int32_t ___reason_19;
	// NetData`1<GameState.Result> GameState.ResultIdentity::netData
	NetData_1_t2498976648 * ___netData_20;

public:
	inline static int32_t get_offset_of_playerIndex_17() { return static_cast<int32_t>(offsetof(ResultIdentity_t2321793757, ___playerIndex_17)); }
	inline int32_t get_playerIndex_17() const { return ___playerIndex_17; }
	inline int32_t* get_address_of_playerIndex_17() { return &___playerIndex_17; }
	inline void set_playerIndex_17(int32_t value)
	{
		___playerIndex_17 = value;
	}

	inline static int32_t get_offset_of_score_18() { return static_cast<int32_t>(offsetof(ResultIdentity_t2321793757, ___score_18)); }
	inline float get_score_18() const { return ___score_18; }
	inline float* get_address_of_score_18() { return &___score_18; }
	inline void set_score_18(float value)
	{
		___score_18 = value;
	}

	inline static int32_t get_offset_of_reason_19() { return static_cast<int32_t>(offsetof(ResultIdentity_t2321793757, ___reason_19)); }
	inline int32_t get_reason_19() const { return ___reason_19; }
	inline int32_t* get_address_of_reason_19() { return &___reason_19; }
	inline void set_reason_19(int32_t value)
	{
		___reason_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(ResultIdentity_t2321793757, ___netData_20)); }
	inline NetData_1_t2498976648 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t2498976648 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t2498976648 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
