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

// NetData`1<HEX.NoneRule.HexCustomSet>
struct NetData_1_t2060090587;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.NoneRule.HexCustomSetIdentity
struct  HexCustomSetIdentity_t1805566268  : public DataIdentity_t543951486
{
public:
	// System.UInt16 HEX.NoneRule.HexCustomSetIdentity::square
	uint16_t ___square_17;
	// HEX.Common/Color HEX.NoneRule.HexCustomSetIdentity::piece
	int32_t ___piece_18;
	// NetData`1<HEX.NoneRule.HexCustomSet> HEX.NoneRule.HexCustomSetIdentity::netData
	NetData_1_t2060090587 * ___netData_19;

public:
	inline static int32_t get_offset_of_square_17() { return static_cast<int32_t>(offsetof(HexCustomSetIdentity_t1805566268, ___square_17)); }
	inline uint16_t get_square_17() const { return ___square_17; }
	inline uint16_t* get_address_of_square_17() { return &___square_17; }
	inline void set_square_17(uint16_t value)
	{
		___square_17 = value;
	}

	inline static int32_t get_offset_of_piece_18() { return static_cast<int32_t>(offsetof(HexCustomSetIdentity_t1805566268, ___piece_18)); }
	inline int32_t get_piece_18() const { return ___piece_18; }
	inline int32_t* get_address_of_piece_18() { return &___piece_18; }
	inline void set_piece_18(int32_t value)
	{
		___piece_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(HexCustomSetIdentity_t1805566268, ___netData_19)); }
	inline NetData_1_t2060090587 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2060090587 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2060090587 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
