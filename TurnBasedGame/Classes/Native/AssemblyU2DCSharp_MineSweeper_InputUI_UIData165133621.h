#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<MineSweeper.MineSweeper>>
struct VP_1_t1780692665;
// VP`1<MineSweeper.InputUI/UIData/Sub>
struct VP_1_t599032558;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.InputUI/UIData
struct  UIData_t165133621  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<MineSweeper.MineSweeper>> MineSweeper.InputUI/UIData::mineSweeper
	VP_1_t1780692665 * ___mineSweeper_5;
	// VP`1<MineSweeper.InputUI/UIData/Sub> MineSweeper.InputUI/UIData::sub
	VP_1_t599032558 * ___sub_6;

public:
	inline static int32_t get_offset_of_mineSweeper_5() { return static_cast<int32_t>(offsetof(UIData_t165133621, ___mineSweeper_5)); }
	inline VP_1_t1780692665 * get_mineSweeper_5() const { return ___mineSweeper_5; }
	inline VP_1_t1780692665 ** get_address_of_mineSweeper_5() { return &___mineSweeper_5; }
	inline void set_mineSweeper_5(VP_1_t1780692665 * value)
	{
		___mineSweeper_5 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeper_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t165133621, ___sub_6)); }
	inline VP_1_t599032558 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t599032558 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t599032558 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
