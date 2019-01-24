#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<FairyChess.FairyChess>>
struct VP_1_t3341857400;
// VP`1<FairyChess.InputUI/UIData/Sub>
struct VP_1_t2765013327;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.InputUI/UIData
struct  UIData_t1474262306  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<FairyChess.FairyChess>> FairyChess.InputUI/UIData::fairyChess
	VP_1_t3341857400 * ___fairyChess_5;
	// VP`1<FairyChess.InputUI/UIData/Sub> FairyChess.InputUI/UIData::sub
	VP_1_t2765013327 * ___sub_6;

public:
	inline static int32_t get_offset_of_fairyChess_5() { return static_cast<int32_t>(offsetof(UIData_t1474262306, ___fairyChess_5)); }
	inline VP_1_t3341857400 * get_fairyChess_5() const { return ___fairyChess_5; }
	inline VP_1_t3341857400 ** get_address_of_fairyChess_5() { return &___fairyChess_5; }
	inline void set_fairyChess_5(VP_1_t3341857400 * value)
	{
		___fairyChess_5 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChess_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1474262306, ___sub_6)); }
	inline VP_1_t2765013327 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2765013327 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2765013327 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
