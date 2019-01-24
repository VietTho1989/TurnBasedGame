#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<InternationalDraught.InternationalDraughtMoveAnimation>
struct NetData_1_t3695735439;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.InternationalDraughtMoveAnimationIdentity
struct  InternationalDraughtMoveAnimationIdentity_t4048673868  : public DataIdentity_t543951486
{
public:
	// System.UInt64 InternationalDraught.InternationalDraughtMoveAnimationIdentity::move
	uint64_t ___move_17;
	// NetData`1<InternationalDraught.InternationalDraughtMoveAnimation> InternationalDraught.InternationalDraughtMoveAnimationIdentity::netData
	NetData_1_t3695735439 * ___netData_18;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(InternationalDraughtMoveAnimationIdentity_t4048673868, ___move_17)); }
	inline uint64_t get_move_17() const { return ___move_17; }
	inline uint64_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(uint64_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(InternationalDraughtMoveAnimationIdentity_t4048673868, ___netData_18)); }
	inline NetData_1_t3695735439 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3695735439 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3695735439 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
