#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_HEX_Common_Color3026989984.h"

// NetData`1<HEX.HexMove>
struct NetData_1_t2561620675;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexMoveIdentity
struct  HexMoveIdentity_t763436152  : public DataIdentity_t543951486
{
public:
	// System.UInt16 HEX.HexMoveIdentity::move
	uint16_t ___move_17;
	// System.UInt16 HEX.HexMoveIdentity::boardSize
	uint16_t ___boardSize_18;
	// HEX.Common/Color HEX.HexMoveIdentity::color
	int32_t ___color_19;
	// NetData`1<HEX.HexMove> HEX.HexMoveIdentity::netData
	NetData_1_t2561620675 * ___netData_20;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(HexMoveIdentity_t763436152, ___move_17)); }
	inline uint16_t get_move_17() const { return ___move_17; }
	inline uint16_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(uint16_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_boardSize_18() { return static_cast<int32_t>(offsetof(HexMoveIdentity_t763436152, ___boardSize_18)); }
	inline uint16_t get_boardSize_18() const { return ___boardSize_18; }
	inline uint16_t* get_address_of_boardSize_18() { return &___boardSize_18; }
	inline void set_boardSize_18(uint16_t value)
	{
		___boardSize_18 = value;
	}

	inline static int32_t get_offset_of_color_19() { return static_cast<int32_t>(offsetof(HexMoveIdentity_t763436152, ___color_19)); }
	inline int32_t get_color_19() const { return ___color_19; }
	inline int32_t* get_address_of_color_19() { return &___color_19; }
	inline void set_color_19(int32_t value)
	{
		___color_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(HexMoveIdentity_t763436152, ___netData_20)); }
	inline NetData_1_t2561620675 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t2561620675 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t2561620675 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
