#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BanUI_UIData_Sub1312557735.h"

// VP`1<ReferenceData`1<BanBan>>
struct VP_1_t3283493407;
// VP`1<BanBanUI/UIData/State>
struct VP_1_t3296065083;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BanBanUI/UIData
struct  UIData_t4229100313  : public Sub_t1312557735
{
public:
	// VP`1<ReferenceData`1<BanBan>> BanBanUI/UIData::banBan
	VP_1_t3283493407 * ___banBan_5;
	// VP`1<BanBanUI/UIData/State> BanBanUI/UIData::state
	VP_1_t3296065083 * ___state_6;

public:
	inline static int32_t get_offset_of_banBan_5() { return static_cast<int32_t>(offsetof(UIData_t4229100313, ___banBan_5)); }
	inline VP_1_t3283493407 * get_banBan_5() const { return ___banBan_5; }
	inline VP_1_t3283493407 ** get_address_of_banBan_5() { return &___banBan_5; }
	inline void set_banBan_5(VP_1_t3283493407 * value)
	{
		___banBan_5 = value;
		Il2CppCodeGenWriteBarrier(&___banBan_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t4229100313, ___state_6)); }
	inline VP_1_t3296065083 * get_state_6() const { return ___state_6; }
	inline VP_1_t3296065083 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t3296065083 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
