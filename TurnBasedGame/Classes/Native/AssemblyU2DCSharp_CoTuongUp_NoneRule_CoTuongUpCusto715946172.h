#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<CoTuongUp.NoneRule.CoTuongUpCustomFlip>
struct NetData_1_t2093973103;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.NoneRule.CoTuongUpCustomFlipIdentity
struct  CoTuongUpCustomFlipIdentity_t715946172  : public DataIdentity_t543951486
{
public:
	// System.Byte CoTuongUp.NoneRule.CoTuongUpCustomFlipIdentity::coord
	uint8_t ___coord_17;
	// NetData`1<CoTuongUp.NoneRule.CoTuongUpCustomFlip> CoTuongUp.NoneRule.CoTuongUpCustomFlipIdentity::netData
	NetData_1_t2093973103 * ___netData_18;

public:
	inline static int32_t get_offset_of_coord_17() { return static_cast<int32_t>(offsetof(CoTuongUpCustomFlipIdentity_t715946172, ___coord_17)); }
	inline uint8_t get_coord_17() const { return ___coord_17; }
	inline uint8_t* get_address_of_coord_17() { return &___coord_17; }
	inline void set_coord_17(uint8_t value)
	{
		___coord_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(CoTuongUpCustomFlipIdentity_t715946172, ___netData_18)); }
	inline NetData_1_t2093973103 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t2093973103 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t2093973103 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
