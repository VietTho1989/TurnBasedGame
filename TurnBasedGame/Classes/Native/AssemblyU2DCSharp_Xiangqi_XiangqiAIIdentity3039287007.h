#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Xiangqi.XiangqiAI>
struct NetData_1_t3181605046;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.XiangqiAIIdentity
struct  XiangqiAIIdentity_t3039287007  : public DataIdentity_t543951486
{
public:
	// System.Int32 Xiangqi.XiangqiAIIdentity::depth
	int32_t ___depth_17;
	// System.Int32 Xiangqi.XiangqiAIIdentity::thinkTime
	int32_t ___thinkTime_18;
	// System.Boolean Xiangqi.XiangqiAIIdentity::useBook
	bool ___useBook_19;
	// System.Int32 Xiangqi.XiangqiAIIdentity::pickBestMove
	int32_t ___pickBestMove_20;
	// NetData`1<Xiangqi.XiangqiAI> Xiangqi.XiangqiAIIdentity::netData
	NetData_1_t3181605046 * ___netData_21;

public:
	inline static int32_t get_offset_of_depth_17() { return static_cast<int32_t>(offsetof(XiangqiAIIdentity_t3039287007, ___depth_17)); }
	inline int32_t get_depth_17() const { return ___depth_17; }
	inline int32_t* get_address_of_depth_17() { return &___depth_17; }
	inline void set_depth_17(int32_t value)
	{
		___depth_17 = value;
	}

	inline static int32_t get_offset_of_thinkTime_18() { return static_cast<int32_t>(offsetof(XiangqiAIIdentity_t3039287007, ___thinkTime_18)); }
	inline int32_t get_thinkTime_18() const { return ___thinkTime_18; }
	inline int32_t* get_address_of_thinkTime_18() { return &___thinkTime_18; }
	inline void set_thinkTime_18(int32_t value)
	{
		___thinkTime_18 = value;
	}

	inline static int32_t get_offset_of_useBook_19() { return static_cast<int32_t>(offsetof(XiangqiAIIdentity_t3039287007, ___useBook_19)); }
	inline bool get_useBook_19() const { return ___useBook_19; }
	inline bool* get_address_of_useBook_19() { return &___useBook_19; }
	inline void set_useBook_19(bool value)
	{
		___useBook_19 = value;
	}

	inline static int32_t get_offset_of_pickBestMove_20() { return static_cast<int32_t>(offsetof(XiangqiAIIdentity_t3039287007, ___pickBestMove_20)); }
	inline int32_t get_pickBestMove_20() const { return ___pickBestMove_20; }
	inline int32_t* get_address_of_pickBestMove_20() { return &___pickBestMove_20; }
	inline void set_pickBestMove_20(int32_t value)
	{
		___pickBestMove_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(XiangqiAIIdentity_t3039287007, ___netData_21)); }
	inline NetData_1_t3181605046 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t3181605046 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t3181605046 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
