#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Seirawan_Common_Piece2762858434.h"

// NetData`1<Seirawan.NoneRule.SeirawanCustomHand>
struct NetData_1_t1271869885;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SeirawanCustomHandIdentity
struct  SeirawanCustomHandIdentity_t1190617918  : public DataIdentity_t543951486
{
public:
	// Seirawan.Common/Piece Seirawan.NoneRule.SeirawanCustomHandIdentity::piece
	int32_t ___piece_17;
	// NetData`1<Seirawan.NoneRule.SeirawanCustomHand> Seirawan.NoneRule.SeirawanCustomHandIdentity::netData
	NetData_1_t1271869885 * ___netData_18;

public:
	inline static int32_t get_offset_of_piece_17() { return static_cast<int32_t>(offsetof(SeirawanCustomHandIdentity_t1190617918, ___piece_17)); }
	inline int32_t get_piece_17() const { return ___piece_17; }
	inline int32_t* get_address_of_piece_17() { return &___piece_17; }
	inline void set_piece_17(int32_t value)
	{
		___piece_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(SeirawanCustomHandIdentity_t1190617918, ___netData_18)); }
	inline NetData_1_t1271869885 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1271869885 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1271869885 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
