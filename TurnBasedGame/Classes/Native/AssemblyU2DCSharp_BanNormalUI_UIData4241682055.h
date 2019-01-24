#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BanUI_UIData_Sub1312557735.h"

// VP`1<ReferenceData`1<BanNormal>>
struct VP_1_t371202899;
// VP`1<BanNormalUI/UIData/State>
struct VP_1_t430781165;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BanNormalUI/UIData
struct  UIData_t4241682055  : public Sub_t1312557735
{
public:
	// VP`1<ReferenceData`1<BanNormal>> BanNormalUI/UIData::banNormal
	VP_1_t371202899 * ___banNormal_5;
	// VP`1<BanNormalUI/UIData/State> BanNormalUI/UIData::state
	VP_1_t430781165 * ___state_6;

public:
	inline static int32_t get_offset_of_banNormal_5() { return static_cast<int32_t>(offsetof(UIData_t4241682055, ___banNormal_5)); }
	inline VP_1_t371202899 * get_banNormal_5() const { return ___banNormal_5; }
	inline VP_1_t371202899 ** get_address_of_banNormal_5() { return &___banNormal_5; }
	inline void set_banNormal_5(VP_1_t371202899 * value)
	{
		___banNormal_5 = value;
		Il2CppCodeGenWriteBarrier(&___banNormal_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t4241682055, ___state_6)); }
	inline VP_1_t430781165 * get_state_6() const { return ___state_6; }
	inline VP_1_t430781165 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t430781165 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
