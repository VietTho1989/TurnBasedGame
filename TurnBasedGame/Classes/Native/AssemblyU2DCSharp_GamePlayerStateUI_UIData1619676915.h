#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GamePlayer/State>>
struct VP_1_t2974788376;
// VP`1<GamePlayerStateUI/UIData/Sub>
struct VP_1_t360355910;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerStateUI/UIData
struct  UIData_t1619676915  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GamePlayer/State>> GamePlayerStateUI/UIData::state
	VP_1_t2974788376 * ___state_5;
	// VP`1<GamePlayerStateUI/UIData/Sub> GamePlayerStateUI/UIData::sub
	VP_1_t360355910 * ___sub_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UIData_t1619676915, ___state_5)); }
	inline VP_1_t2974788376 * get_state_5() const { return ___state_5; }
	inline VP_1_t2974788376 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2974788376 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1619676915, ___sub_6)); }
	inline VP_1_t360355910 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t360355910 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t360355910 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
