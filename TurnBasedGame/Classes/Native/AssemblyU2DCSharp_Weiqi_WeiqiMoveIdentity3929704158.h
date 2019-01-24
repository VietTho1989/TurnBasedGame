#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Weiqi.WeiqiMove>
struct NetData_1_t296261609;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiMoveIdentity
struct  WeiqiMoveIdentity_t3929704158  : public DataIdentity_t543951486
{
public:
	// System.Int32 Weiqi.WeiqiMoveIdentity::coord
	int32_t ___coord_17;
	// System.Int32 Weiqi.WeiqiMoveIdentity::color
	int32_t ___color_18;
	// System.Int32 Weiqi.WeiqiMoveIdentity::boardSize
	int32_t ___boardSize_19;
	// NetData`1<Weiqi.WeiqiMove> Weiqi.WeiqiMoveIdentity::netData
	NetData_1_t296261609 * ___netData_20;

public:
	inline static int32_t get_offset_of_coord_17() { return static_cast<int32_t>(offsetof(WeiqiMoveIdentity_t3929704158, ___coord_17)); }
	inline int32_t get_coord_17() const { return ___coord_17; }
	inline int32_t* get_address_of_coord_17() { return &___coord_17; }
	inline void set_coord_17(int32_t value)
	{
		___coord_17 = value;
	}

	inline static int32_t get_offset_of_color_18() { return static_cast<int32_t>(offsetof(WeiqiMoveIdentity_t3929704158, ___color_18)); }
	inline int32_t get_color_18() const { return ___color_18; }
	inline int32_t* get_address_of_color_18() { return &___color_18; }
	inline void set_color_18(int32_t value)
	{
		___color_18 = value;
	}

	inline static int32_t get_offset_of_boardSize_19() { return static_cast<int32_t>(offsetof(WeiqiMoveIdentity_t3929704158, ___boardSize_19)); }
	inline int32_t get_boardSize_19() const { return ___boardSize_19; }
	inline int32_t* get_address_of_boardSize_19() { return &___boardSize_19; }
	inline void set_boardSize_19(int32_t value)
	{
		___boardSize_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(WeiqiMoveIdentity_t3929704158, ___netData_20)); }
	inline NetData_1_t296261609 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t296261609 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t296261609 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
