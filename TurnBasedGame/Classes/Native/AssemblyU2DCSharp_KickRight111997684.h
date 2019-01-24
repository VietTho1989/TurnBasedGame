#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// KickRight
struct  KickRight_t111997684  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> KickRight::canKick
	VP_1_t4203851724 * ___canKick_5;
	// VP`1<System.Boolean> KickRight::canKickPlayer
	VP_1_t4203851724 * ___canKickPlayer_6;

public:
	inline static int32_t get_offset_of_canKick_5() { return static_cast<int32_t>(offsetof(KickRight_t111997684, ___canKick_5)); }
	inline VP_1_t4203851724 * get_canKick_5() const { return ___canKick_5; }
	inline VP_1_t4203851724 ** get_address_of_canKick_5() { return &___canKick_5; }
	inline void set_canKick_5(VP_1_t4203851724 * value)
	{
		___canKick_5 = value;
		Il2CppCodeGenWriteBarrier(&___canKick_5, value);
	}

	inline static int32_t get_offset_of_canKickPlayer_6() { return static_cast<int32_t>(offsetof(KickRight_t111997684, ___canKickPlayer_6)); }
	inline VP_1_t4203851724 * get_canKickPlayer_6() const { return ___canKickPlayer_6; }
	inline VP_1_t4203851724 ** get_address_of_canKickPlayer_6() { return &___canKickPlayer_6; }
	inline void set_canKickPlayer_6(VP_1_t4203851724 * value)
	{
		___canKickPlayer_6 = value;
		Il2CppCodeGenWriteBarrier(&___canKickPlayer_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
