#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<CoTuongUp.CoTuongUpMoveAnimation>
struct NetData_1_t211274820;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.CoTuongUpMoveAnimationIdentity
struct  CoTuongUpMoveAnimationIdentity_t2410782329  : public DataIdentity_t543951486
{
public:
	// System.Int32 CoTuongUp.CoTuongUpMoveAnimationIdentity::move
	int32_t ___move_17;
	// NetData`1<CoTuongUp.CoTuongUpMoveAnimation> CoTuongUp.CoTuongUpMoveAnimationIdentity::netData
	NetData_1_t211274820 * ___netData_18;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(CoTuongUpMoveAnimationIdentity_t2410782329, ___move_17)); }
	inline int32_t get_move_17() const { return ___move_17; }
	inline int32_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(int32_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(CoTuongUpMoveAnimationIdentity_t2410782329, ___netData_18)); }
	inline NetData_1_t211274820 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t211274820 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t211274820 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
