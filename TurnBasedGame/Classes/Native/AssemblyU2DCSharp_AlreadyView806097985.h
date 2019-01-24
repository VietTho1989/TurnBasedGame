#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// LP`1<ViewPlayer>
struct LP_1_t923536684;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AlreadyView
struct  AlreadyView_t806097985  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> AlreadyView::isEnable
	VP_1_t4203851724 * ___isEnable_5;
	// LP`1<ViewPlayer> AlreadyView::viewPlayers
	LP_1_t923536684 * ___viewPlayers_6;

public:
	inline static int32_t get_offset_of_isEnable_5() { return static_cast<int32_t>(offsetof(AlreadyView_t806097985, ___isEnable_5)); }
	inline VP_1_t4203851724 * get_isEnable_5() const { return ___isEnable_5; }
	inline VP_1_t4203851724 ** get_address_of_isEnable_5() { return &___isEnable_5; }
	inline void set_isEnable_5(VP_1_t4203851724 * value)
	{
		___isEnable_5 = value;
		Il2CppCodeGenWriteBarrier(&___isEnable_5, value);
	}

	inline static int32_t get_offset_of_viewPlayers_6() { return static_cast<int32_t>(offsetof(AlreadyView_t806097985, ___viewPlayers_6)); }
	inline LP_1_t923536684 * get_viewPlayers_6() const { return ___viewPlayers_6; }
	inline LP_1_t923536684 ** get_address_of_viewPlayers_6() { return &___viewPlayers_6; }
	inline void set_viewPlayers_6(LP_1_t923536684 * value)
	{
		___viewPlayers_6 = value;
		Il2CppCodeGenWriteBarrier(&___viewPlayers_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
