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

// NetData`1<Seirawan.NoneRule.SeirawanCustomSet>
struct NetData_1_t4003254270;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SeirawanCustomSetIdentity
struct  SeirawanCustomSetIdentity_t3489081215  : public DataIdentity_t543951486
{
public:
	// System.Int32 Seirawan.NoneRule.SeirawanCustomSetIdentity::x
	int32_t ___x_17;
	// System.Int32 Seirawan.NoneRule.SeirawanCustomSetIdentity::y
	int32_t ___y_18;
	// Seirawan.Common/Piece Seirawan.NoneRule.SeirawanCustomSetIdentity::piece
	int32_t ___piece_19;
	// NetData`1<Seirawan.NoneRule.SeirawanCustomSet> Seirawan.NoneRule.SeirawanCustomSetIdentity::netData
	NetData_1_t4003254270 * ___netData_20;

public:
	inline static int32_t get_offset_of_x_17() { return static_cast<int32_t>(offsetof(SeirawanCustomSetIdentity_t3489081215, ___x_17)); }
	inline int32_t get_x_17() const { return ___x_17; }
	inline int32_t* get_address_of_x_17() { return &___x_17; }
	inline void set_x_17(int32_t value)
	{
		___x_17 = value;
	}

	inline static int32_t get_offset_of_y_18() { return static_cast<int32_t>(offsetof(SeirawanCustomSetIdentity_t3489081215, ___y_18)); }
	inline int32_t get_y_18() const { return ___y_18; }
	inline int32_t* get_address_of_y_18() { return &___y_18; }
	inline void set_y_18(int32_t value)
	{
		___y_18 = value;
	}

	inline static int32_t get_offset_of_piece_19() { return static_cast<int32_t>(offsetof(SeirawanCustomSetIdentity_t3489081215, ___piece_19)); }
	inline int32_t get_piece_19() const { return ___piece_19; }
	inline int32_t* get_address_of_piece_19() { return &___piece_19; }
	inline void set_piece_19(int32_t value)
	{
		___piece_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(SeirawanCustomSetIdentity_t3489081215, ___netData_20)); }
	inline NetData_1_t4003254270 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t4003254270 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t4003254270 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
