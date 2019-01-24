#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<CoTuongUp.NoneRule.CoTuongUpCustomSet>
struct NetData_1_t3308969802;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.NoneRule.CoTuongUpCustomSetIdentity
struct  CoTuongUpCustomSetIdentity_t4066786791  : public DataIdentity_t543951486
{
public:
	// System.Byte CoTuongUp.NoneRule.CoTuongUpCustomSetIdentity::coord
	uint8_t ___coord_17;
	// System.Byte CoTuongUp.NoneRule.CoTuongUpCustomSetIdentity::piece
	uint8_t ___piece_18;
	// NetData`1<CoTuongUp.NoneRule.CoTuongUpCustomSet> CoTuongUp.NoneRule.CoTuongUpCustomSetIdentity::netData
	NetData_1_t3308969802 * ___netData_19;

public:
	inline static int32_t get_offset_of_coord_17() { return static_cast<int32_t>(offsetof(CoTuongUpCustomSetIdentity_t4066786791, ___coord_17)); }
	inline uint8_t get_coord_17() const { return ___coord_17; }
	inline uint8_t* get_address_of_coord_17() { return &___coord_17; }
	inline void set_coord_17(uint8_t value)
	{
		___coord_17 = value;
	}

	inline static int32_t get_offset_of_piece_18() { return static_cast<int32_t>(offsetof(CoTuongUpCustomSetIdentity_t4066786791, ___piece_18)); }
	inline uint8_t get_piece_18() const { return ___piece_18; }
	inline uint8_t* get_address_of_piece_18() { return &___piece_18; }
	inline void set_piece_18(uint8_t value)
	{
		___piece_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(CoTuongUpCustomSetIdentity_t4066786791, ___netData_19)); }
	inline NetData_1_t3308969802 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3308969802 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3308969802 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
