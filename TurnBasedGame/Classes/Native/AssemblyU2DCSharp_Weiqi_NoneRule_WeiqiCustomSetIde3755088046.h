#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Weiqi_Common_stone1643988418.h"

// NetData`1<Weiqi.NoneRule.WeiqiCustomSet>
struct NetData_1_t2021775369;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.NoneRule.WeiqiCustomSetIdentity
struct  WeiqiCustomSetIdentity_t3755088046  : public DataIdentity_t543951486
{
public:
	// System.Int32 Weiqi.NoneRule.WeiqiCustomSetIdentity::coord
	int32_t ___coord_17;
	// Weiqi.Common/stone Weiqi.NoneRule.WeiqiCustomSetIdentity::piece
	int32_t ___piece_18;
	// NetData`1<Weiqi.NoneRule.WeiqiCustomSet> Weiqi.NoneRule.WeiqiCustomSetIdentity::netData
	NetData_1_t2021775369 * ___netData_19;

public:
	inline static int32_t get_offset_of_coord_17() { return static_cast<int32_t>(offsetof(WeiqiCustomSetIdentity_t3755088046, ___coord_17)); }
	inline int32_t get_coord_17() const { return ___coord_17; }
	inline int32_t* get_address_of_coord_17() { return &___coord_17; }
	inline void set_coord_17(int32_t value)
	{
		___coord_17 = value;
	}

	inline static int32_t get_offset_of_piece_18() { return static_cast<int32_t>(offsetof(WeiqiCustomSetIdentity_t3755088046, ___piece_18)); }
	inline int32_t get_piece_18() const { return ___piece_18; }
	inline int32_t* get_address_of_piece_18() { return &___piece_18; }
	inline void set_piece_18(int32_t value)
	{
		___piece_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(WeiqiCustomSetIdentity_t3755088046, ___netData_19)); }
	inline NetData_1_t2021775369 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2021775369 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2021775369 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
