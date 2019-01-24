#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<EnglishDraught.EnglishDraughtAI>
struct NetData_1_t665585506;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.EnglishDraughtAIIdentity
struct  EnglishDraughtAIIdentity_t2747245795  : public DataIdentity_t543951486
{
public:
	// System.Boolean EnglishDraught.EnglishDraughtAIIdentity::threeMoveRandom
	bool ___threeMoveRandom_17;
	// System.Single EnglishDraught.EnglishDraughtAIIdentity::fMaxSeconds
	float ___fMaxSeconds_18;
	// System.Int32 EnglishDraught.EnglishDraughtAIIdentity::g_MaxDepth
	int32_t ___g_MaxDepth_19;
	// System.Int32 EnglishDraught.EnglishDraughtAIIdentity::pickBestMove
	int32_t ___pickBestMove_20;
	// NetData`1<EnglishDraught.EnglishDraughtAI> EnglishDraught.EnglishDraughtAIIdentity::netData
	NetData_1_t665585506 * ___netData_21;

public:
	inline static int32_t get_offset_of_threeMoveRandom_17() { return static_cast<int32_t>(offsetof(EnglishDraughtAIIdentity_t2747245795, ___threeMoveRandom_17)); }
	inline bool get_threeMoveRandom_17() const { return ___threeMoveRandom_17; }
	inline bool* get_address_of_threeMoveRandom_17() { return &___threeMoveRandom_17; }
	inline void set_threeMoveRandom_17(bool value)
	{
		___threeMoveRandom_17 = value;
	}

	inline static int32_t get_offset_of_fMaxSeconds_18() { return static_cast<int32_t>(offsetof(EnglishDraughtAIIdentity_t2747245795, ___fMaxSeconds_18)); }
	inline float get_fMaxSeconds_18() const { return ___fMaxSeconds_18; }
	inline float* get_address_of_fMaxSeconds_18() { return &___fMaxSeconds_18; }
	inline void set_fMaxSeconds_18(float value)
	{
		___fMaxSeconds_18 = value;
	}

	inline static int32_t get_offset_of_g_MaxDepth_19() { return static_cast<int32_t>(offsetof(EnglishDraughtAIIdentity_t2747245795, ___g_MaxDepth_19)); }
	inline int32_t get_g_MaxDepth_19() const { return ___g_MaxDepth_19; }
	inline int32_t* get_address_of_g_MaxDepth_19() { return &___g_MaxDepth_19; }
	inline void set_g_MaxDepth_19(int32_t value)
	{
		___g_MaxDepth_19 = value;
	}

	inline static int32_t get_offset_of_pickBestMove_20() { return static_cast<int32_t>(offsetof(EnglishDraughtAIIdentity_t2747245795, ___pickBestMove_20)); }
	inline int32_t get_pickBestMove_20() const { return ___pickBestMove_20; }
	inline int32_t* get_address_of_pickBestMove_20() { return &___pickBestMove_20; }
	inline void set_pickBestMove_20(int32_t value)
	{
		___pickBestMove_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(EnglishDraughtAIIdentity_t2747245795, ___netData_21)); }
	inline NetData_1_t665585506 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t665585506 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t665585506 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
