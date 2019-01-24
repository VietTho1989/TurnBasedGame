#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameType1641020183.h"

// VP`1<FairyChess.Common/VariantType>
struct VP_1_t3949171818;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.DefaultFairyChess
struct  DefaultFairyChess_t2130932174  : public DefaultGameType_t1641020183
{
public:
	// VP`1<FairyChess.Common/VariantType> FairyChess.DefaultFairyChess::variantType
	VP_1_t3949171818 * ___variantType_5;
	// VP`1<System.Boolean> FairyChess.DefaultFairyChess::chess960
	VP_1_t4203851724 * ___chess960_6;

public:
	inline static int32_t get_offset_of_variantType_5() { return static_cast<int32_t>(offsetof(DefaultFairyChess_t2130932174, ___variantType_5)); }
	inline VP_1_t3949171818 * get_variantType_5() const { return ___variantType_5; }
	inline VP_1_t3949171818 ** get_address_of_variantType_5() { return &___variantType_5; }
	inline void set_variantType_5(VP_1_t3949171818 * value)
	{
		___variantType_5 = value;
		Il2CppCodeGenWriteBarrier(&___variantType_5, value);
	}

	inline static int32_t get_offset_of_chess960_6() { return static_cast<int32_t>(offsetof(DefaultFairyChess_t2130932174, ___chess960_6)); }
	inline VP_1_t4203851724 * get_chess960_6() const { return ___chess960_6; }
	inline VP_1_t4203851724 ** get_address_of_chess960_6() { return &___chess960_6; }
	inline void set_chess960_6(VP_1_t4203851724 * value)
	{
		___chess960_6 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
