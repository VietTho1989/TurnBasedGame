#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<InternationalDraught.NoneRule.InternationalDraughtCustomMove>
struct NetData_1_t1214097592;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.NoneRule.InternationalDraughtCustomMoveIdentity
struct  InternationalDraughtCustomMoveIdentity_t687496829  : public DataIdentity_t543951486
{
public:
	// System.Int32 InternationalDraught.NoneRule.InternationalDraughtCustomMoveIdentity::fromSquare
	int32_t ___fromSquare_17;
	// System.Int32 InternationalDraught.NoneRule.InternationalDraughtCustomMoveIdentity::destSquare
	int32_t ___destSquare_18;
	// NetData`1<InternationalDraught.NoneRule.InternationalDraughtCustomMove> InternationalDraught.NoneRule.InternationalDraughtCustomMoveIdentity::netData
	NetData_1_t1214097592 * ___netData_19;

public:
	inline static int32_t get_offset_of_fromSquare_17() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomMoveIdentity_t687496829, ___fromSquare_17)); }
	inline int32_t get_fromSquare_17() const { return ___fromSquare_17; }
	inline int32_t* get_address_of_fromSquare_17() { return &___fromSquare_17; }
	inline void set_fromSquare_17(int32_t value)
	{
		___fromSquare_17 = value;
	}

	inline static int32_t get_offset_of_destSquare_18() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomMoveIdentity_t687496829, ___destSquare_18)); }
	inline int32_t get_destSquare_18() const { return ___destSquare_18; }
	inline int32_t* get_address_of_destSquare_18() { return &___destSquare_18; }
	inline void set_destSquare_18(int32_t value)
	{
		___destSquare_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomMoveIdentity_t687496829, ___netData_19)); }
	inline NetData_1_t1214097592 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1214097592 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1214097592 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
