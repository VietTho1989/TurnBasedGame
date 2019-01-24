#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Gomoku.GomokuAI>
struct NetData_1_t905780591;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuAIIdentity
struct  GomokuAIIdentity_t2691706324  : public DataIdentity_t543951486
{
public:
	// System.Int32 Gomoku.GomokuAIIdentity::searchDepth
	int32_t ___searchDepth_17;
	// System.Int32 Gomoku.GomokuAIIdentity::timeLimit
	int32_t ___timeLimit_18;
	// System.Int32 Gomoku.GomokuAIIdentity::level
	int32_t ___level_19;
	// NetData`1<Gomoku.GomokuAI> Gomoku.GomokuAIIdentity::netData
	NetData_1_t905780591 * ___netData_20;

public:
	inline static int32_t get_offset_of_searchDepth_17() { return static_cast<int32_t>(offsetof(GomokuAIIdentity_t2691706324, ___searchDepth_17)); }
	inline int32_t get_searchDepth_17() const { return ___searchDepth_17; }
	inline int32_t* get_address_of_searchDepth_17() { return &___searchDepth_17; }
	inline void set_searchDepth_17(int32_t value)
	{
		___searchDepth_17 = value;
	}

	inline static int32_t get_offset_of_timeLimit_18() { return static_cast<int32_t>(offsetof(GomokuAIIdentity_t2691706324, ___timeLimit_18)); }
	inline int32_t get_timeLimit_18() const { return ___timeLimit_18; }
	inline int32_t* get_address_of_timeLimit_18() { return &___timeLimit_18; }
	inline void set_timeLimit_18(int32_t value)
	{
		___timeLimit_18 = value;
	}

	inline static int32_t get_offset_of_level_19() { return static_cast<int32_t>(offsetof(GomokuAIIdentity_t2691706324, ___level_19)); }
	inline int32_t get_level_19() const { return ___level_19; }
	inline int32_t* get_address_of_level_19() { return &___level_19; }
	inline void set_level_19(int32_t value)
	{
		___level_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(GomokuAIIdentity_t2691706324, ___netData_20)); }
	inline NetData_1_t905780591 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t905780591 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t905780591 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
