#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<RoomBtnBackUI/UIData>
struct VP_1_t3707938895;
// LP`1<GameManager.Match.RoomBtnUI/UIData/Sub>
struct LP_1_t2816268839;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoomBtnUI/UIData
struct  UIData_t1180258702  : public Data_t3569509720
{
public:
	// VP`1<RoomBtnBackUI/UIData> GameManager.Match.RoomBtnUI/UIData::btnBack
	VP_1_t3707938895 * ___btnBack_5;
	// LP`1<GameManager.Match.RoomBtnUI/UIData/Sub> GameManager.Match.RoomBtnUI/UIData::subs
	LP_1_t2816268839 * ___subs_6;

public:
	inline static int32_t get_offset_of_btnBack_5() { return static_cast<int32_t>(offsetof(UIData_t1180258702, ___btnBack_5)); }
	inline VP_1_t3707938895 * get_btnBack_5() const { return ___btnBack_5; }
	inline VP_1_t3707938895 ** get_address_of_btnBack_5() { return &___btnBack_5; }
	inline void set_btnBack_5(VP_1_t3707938895 * value)
	{
		___btnBack_5 = value;
		Il2CppCodeGenWriteBarrier(&___btnBack_5, value);
	}

	inline static int32_t get_offset_of_subs_6() { return static_cast<int32_t>(offsetof(UIData_t1180258702, ___subs_6)); }
	inline LP_1_t2816268839 * get_subs_6() const { return ___subs_6; }
	inline LP_1_t2816268839 ** get_address_of_subs_6() { return &___subs_6; }
	inline void set_subs_6(LP_1_t2816268839 * value)
	{
		___subs_6 = value;
		Il2CppCodeGenWriteBarrier(&___subs_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
