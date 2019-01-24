#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<MineSweeper.Point>
struct NetData_1_t3290516121;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.PointIdentity
struct  PointIdentity_t3367780718  : public DataIdentity_t543951486
{
public:
	// System.SByte MineSweeper.PointIdentity::x
	int8_t ___x_17;
	// System.SByte MineSweeper.PointIdentity::y
	int8_t ___y_18;
	// NetData`1<MineSweeper.Point> MineSweeper.PointIdentity::netData
	NetData_1_t3290516121 * ___netData_19;

public:
	inline static int32_t get_offset_of_x_17() { return static_cast<int32_t>(offsetof(PointIdentity_t3367780718, ___x_17)); }
	inline int8_t get_x_17() const { return ___x_17; }
	inline int8_t* get_address_of_x_17() { return &___x_17; }
	inline void set_x_17(int8_t value)
	{
		___x_17 = value;
	}

	inline static int32_t get_offset_of_y_18() { return static_cast<int32_t>(offsetof(PointIdentity_t3367780718, ___y_18)); }
	inline int8_t get_y_18() const { return ___y_18; }
	inline int8_t* get_address_of_y_18() { return &___y_18; }
	inline void set_y_18(int8_t value)
	{
		___y_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(PointIdentity_t3367780718, ___netData_19)); }
	inline NetData_1_t3290516121 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3290516121 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3290516121 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
