#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Xiangqi_Common_Piece1086955557.h"

// NetData`1<Xiangqi.NoneRule.XiangqiCustomSet>
struct NetData_1_t3704416715;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.NoneRule.XiangqiCustomSetIdentity
struct  XiangqiCustomSetIdentity_t2609061940  : public DataIdentity_t543951486
{
public:
	// System.Int32 Xiangqi.NoneRule.XiangqiCustomSetIdentity::x
	int32_t ___x_17;
	// System.Int32 Xiangqi.NoneRule.XiangqiCustomSetIdentity::y
	int32_t ___y_18;
	// Xiangqi.Common/Piece Xiangqi.NoneRule.XiangqiCustomSetIdentity::piece
	int32_t ___piece_19;
	// NetData`1<Xiangqi.NoneRule.XiangqiCustomSet> Xiangqi.NoneRule.XiangqiCustomSetIdentity::netData
	NetData_1_t3704416715 * ___netData_20;

public:
	inline static int32_t get_offset_of_x_17() { return static_cast<int32_t>(offsetof(XiangqiCustomSetIdentity_t2609061940, ___x_17)); }
	inline int32_t get_x_17() const { return ___x_17; }
	inline int32_t* get_address_of_x_17() { return &___x_17; }
	inline void set_x_17(int32_t value)
	{
		___x_17 = value;
	}

	inline static int32_t get_offset_of_y_18() { return static_cast<int32_t>(offsetof(XiangqiCustomSetIdentity_t2609061940, ___y_18)); }
	inline int32_t get_y_18() const { return ___y_18; }
	inline int32_t* get_address_of_y_18() { return &___y_18; }
	inline void set_y_18(int32_t value)
	{
		___y_18 = value;
	}

	inline static int32_t get_offset_of_piece_19() { return static_cast<int32_t>(offsetof(XiangqiCustomSetIdentity_t2609061940, ___piece_19)); }
	inline int32_t get_piece_19() const { return ___piece_19; }
	inline int32_t* get_address_of_piece_19() { return &___piece_19; }
	inline void set_piece_19(int32_t value)
	{
		___piece_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(XiangqiCustomSetIdentity_t2609061940, ___netData_20)); }
	inline NetData_1_t3704416715 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3704416715 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3704416715 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
