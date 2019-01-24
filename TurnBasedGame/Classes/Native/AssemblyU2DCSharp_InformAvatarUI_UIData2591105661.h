#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GamePlayer/Inform>>
struct VP_1_t3458722478;
// VP`1<InformAvatarUI/UIData/Sub>
struct VP_1_t1630345630;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InformAvatarUI/UIData
struct  UIData_t2591105661  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GamePlayer/Inform>> InformAvatarUI/UIData::inform
	VP_1_t3458722478 * ___inform_5;
	// VP`1<InformAvatarUI/UIData/Sub> InformAvatarUI/UIData::sub
	VP_1_t1630345630 * ___sub_6;

public:
	inline static int32_t get_offset_of_inform_5() { return static_cast<int32_t>(offsetof(UIData_t2591105661, ___inform_5)); }
	inline VP_1_t3458722478 * get_inform_5() const { return ___inform_5; }
	inline VP_1_t3458722478 ** get_address_of_inform_5() { return &___inform_5; }
	inline void set_inform_5(VP_1_t3458722478 * value)
	{
		___inform_5 = value;
		Il2CppCodeGenWriteBarrier(&___inform_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2591105661, ___sub_6)); }
	inline VP_1_t1630345630 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1630345630 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1630345630 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
