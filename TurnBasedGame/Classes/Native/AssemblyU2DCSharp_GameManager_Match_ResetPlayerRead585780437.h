#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3947915587.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ResetPlayerReadyWhenFactoryChange
struct  ResetPlayerReadyWhenFactoryChange_t585780437  : public UpdateBehavior_1_t3947915587
{
public:
	// System.Boolean GameManager.Match.ResetPlayerReadyWhenFactoryChange::needReset
	bool ___needReset_4;

public:
	inline static int32_t get_offset_of_needReset_4() { return static_cast<int32_t>(offsetof(ResetPlayerReadyWhenFactoryChange_t585780437, ___needReset_4)); }
	inline bool get_needReset_4() const { return ___needReset_4; }
	inline bool* get_address_of_needReset_4() { return &___needReset_4; }
	inline void set_needReset_4(bool value)
	{
		___needReset_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
