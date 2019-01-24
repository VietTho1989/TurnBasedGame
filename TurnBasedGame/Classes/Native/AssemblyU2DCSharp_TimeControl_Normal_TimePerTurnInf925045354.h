#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_Normal_TimePerTurnIn1423504729.h"

// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimePerTurnInfo/Limit
struct  Limit_t925045354  : public TimePerTurnInfo_t1423504729
{
public:
	// VP`1<System.Single> TimeControl.Normal.TimePerTurnInfo/Limit::perTurn
	VP_1_t2454786938 * ___perTurn_6;

public:
	inline static int32_t get_offset_of_perTurn_6() { return static_cast<int32_t>(offsetof(Limit_t925045354, ___perTurn_6)); }
	inline VP_1_t2454786938 * get_perTurn_6() const { return ___perTurn_6; }
	inline VP_1_t2454786938 ** get_address_of_perTurn_6() { return &___perTurn_6; }
	inline void set_perTurn_6(VP_1_t2454786938 * value)
	{
		___perTurn_6 = value;
		Il2CppCodeGenWriteBarrier(&___perTurn_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
