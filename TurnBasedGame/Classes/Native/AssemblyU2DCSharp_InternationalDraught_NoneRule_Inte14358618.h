#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_InternationalDraught_Common_Piec3628697115.h"

// NetData`1<InternationalDraught.NoneRule.InternationalDraughtCustomSet>
struct NetData_1_t2252230169;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.NoneRule.InternationalDraughtCustomSetIdentity
struct  InternationalDraughtCustomSetIdentity_t14358618  : public DataIdentity_t543951486
{
public:
	// System.Int32 InternationalDraught.NoneRule.InternationalDraughtCustomSetIdentity::square
	int32_t ___square_17;
	// InternationalDraught.Common/Piece_Side InternationalDraught.NoneRule.InternationalDraughtCustomSetIdentity::pieceSide
	int32_t ___pieceSide_18;
	// NetData`1<InternationalDraught.NoneRule.InternationalDraughtCustomSet> InternationalDraught.NoneRule.InternationalDraughtCustomSetIdentity::netData
	NetData_1_t2252230169 * ___netData_19;

public:
	inline static int32_t get_offset_of_square_17() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomSetIdentity_t14358618, ___square_17)); }
	inline int32_t get_square_17() const { return ___square_17; }
	inline int32_t* get_address_of_square_17() { return &___square_17; }
	inline void set_square_17(int32_t value)
	{
		___square_17 = value;
	}

	inline static int32_t get_offset_of_pieceSide_18() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomSetIdentity_t14358618, ___pieceSide_18)); }
	inline int32_t get_pieceSide_18() const { return ___pieceSide_18; }
	inline int32_t* get_address_of_pieceSide_18() { return &___pieceSide_18; }
	inline void set_pieceSide_18(int32_t value)
	{
		___pieceSide_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomSetIdentity_t14358618, ___netData_19)); }
	inline NetData_1_t2252230169 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2252230169 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2252230169 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
