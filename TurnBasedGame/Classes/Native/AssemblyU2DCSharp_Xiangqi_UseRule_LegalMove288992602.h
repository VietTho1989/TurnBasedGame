#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UseRule.LegalMove
struct  LegalMove_t288992602  : public Data_t3569509720
{
public:
	// VP`1<System.UInt32> Xiangqi.UseRule.LegalMove::move
	VP_1_t2527959027 * ___move_5;
	// VP`1<System.Int32> Xiangqi.UseRule.LegalMove::repStatus
	VP_1_t2450154454 * ___repStatus_6;

public:
	inline static int32_t get_offset_of_move_5() { return static_cast<int32_t>(offsetof(LegalMove_t288992602, ___move_5)); }
	inline VP_1_t2527959027 * get_move_5() const { return ___move_5; }
	inline VP_1_t2527959027 ** get_address_of_move_5() { return &___move_5; }
	inline void set_move_5(VP_1_t2527959027 * value)
	{
		___move_5 = value;
		Il2CppCodeGenWriteBarrier(&___move_5, value);
	}

	inline static int32_t get_offset_of_repStatus_6() { return static_cast<int32_t>(offsetof(LegalMove_t288992602, ___repStatus_6)); }
	inline VP_1_t2450154454 * get_repStatus_6() const { return ___repStatus_6; }
	inline VP_1_t2450154454 ** get_address_of_repStatus_6() { return &___repStatus_6; }
	inline void set_repStatus_6(VP_1_t2450154454 * value)
	{
		___repStatus_6 = value;
		Il2CppCodeGenWriteBarrier(&___repStatus_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
