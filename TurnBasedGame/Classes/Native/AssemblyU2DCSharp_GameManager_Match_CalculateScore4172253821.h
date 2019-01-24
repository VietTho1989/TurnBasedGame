#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.CalculateScoreWinLoseDraw>
struct NetData_1_t1790535932;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.CalculateScoreWinLoseDrawIdentity
struct  CalculateScoreWinLoseDrawIdentity_t4172253821  : public DataIdentity_t543951486
{
public:
	// System.Single GameManager.Match.CalculateScoreWinLoseDrawIdentity::winScore
	float ___winScore_17;
	// System.Single GameManager.Match.CalculateScoreWinLoseDrawIdentity::loseScore
	float ___loseScore_18;
	// System.Single GameManager.Match.CalculateScoreWinLoseDrawIdentity::drawScore
	float ___drawScore_19;
	// NetData`1<GameManager.Match.CalculateScoreWinLoseDraw> GameManager.Match.CalculateScoreWinLoseDrawIdentity::netData
	NetData_1_t1790535932 * ___netData_20;

public:
	inline static int32_t get_offset_of_winScore_17() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawIdentity_t4172253821, ___winScore_17)); }
	inline float get_winScore_17() const { return ___winScore_17; }
	inline float* get_address_of_winScore_17() { return &___winScore_17; }
	inline void set_winScore_17(float value)
	{
		___winScore_17 = value;
	}

	inline static int32_t get_offset_of_loseScore_18() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawIdentity_t4172253821, ___loseScore_18)); }
	inline float get_loseScore_18() const { return ___loseScore_18; }
	inline float* get_address_of_loseScore_18() { return &___loseScore_18; }
	inline void set_loseScore_18(float value)
	{
		___loseScore_18 = value;
	}

	inline static int32_t get_offset_of_drawScore_19() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawIdentity_t4172253821, ___drawScore_19)); }
	inline float get_drawScore_19() const { return ___drawScore_19; }
	inline float* get_address_of_drawScore_19() { return &___drawScore_19; }
	inline void set_drawScore_19(float value)
	{
		___drawScore_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawIdentity_t4172253821, ___netData_20)); }
	inline NetData_1_t1790535932 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t1790535932 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t1790535932 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
