#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<FairyChess.FairyChessAI>
struct NetData_1_t2718500142;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessAIIdentity
struct  FairyChessAIIdentity_t4028585903  : public DataIdentity_t543951486
{
public:
	// System.Int32 FairyChess.FairyChessAIIdentity::depth
	int32_t ___depth_17;
	// System.Int32 FairyChess.FairyChessAIIdentity::skillLevel
	int32_t ___skillLevel_18;
	// System.Int64 FairyChess.FairyChessAIIdentity::duration
	int64_t ___duration_19;
	// NetData`1<FairyChess.FairyChessAI> FairyChess.FairyChessAIIdentity::netData
	NetData_1_t2718500142 * ___netData_20;

public:
	inline static int32_t get_offset_of_depth_17() { return static_cast<int32_t>(offsetof(FairyChessAIIdentity_t4028585903, ___depth_17)); }
	inline int32_t get_depth_17() const { return ___depth_17; }
	inline int32_t* get_address_of_depth_17() { return &___depth_17; }
	inline void set_depth_17(int32_t value)
	{
		___depth_17 = value;
	}

	inline static int32_t get_offset_of_skillLevel_18() { return static_cast<int32_t>(offsetof(FairyChessAIIdentity_t4028585903, ___skillLevel_18)); }
	inline int32_t get_skillLevel_18() const { return ___skillLevel_18; }
	inline int32_t* get_address_of_skillLevel_18() { return &___skillLevel_18; }
	inline void set_skillLevel_18(int32_t value)
	{
		___skillLevel_18 = value;
	}

	inline static int32_t get_offset_of_duration_19() { return static_cast<int32_t>(offsetof(FairyChessAIIdentity_t4028585903, ___duration_19)); }
	inline int64_t get_duration_19() const { return ___duration_19; }
	inline int64_t* get_address_of_duration_19() { return &___duration_19; }
	inline void set_duration_19(int64_t value)
	{
		___duration_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(FairyChessAIIdentity_t4028585903, ___netData_20)); }
	inline NetData_1_t2718500142 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t2718500142 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t2718500142 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
