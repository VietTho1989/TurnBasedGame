#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LanClientUI_UIData_Sub2365718208.h"

// VP`1<DiscoveredServers>
struct VP_1_t3458191560;
// VP`1<LanClientMenuUI/UIData/State>
struct VP_1_t974974500;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LanClientMenuUI/UIData
struct  UIData_t3345341216  : public Sub_t2365718208
{
public:
	// VP`1<DiscoveredServers> LanClientMenuUI/UIData::discoveredServers
	VP_1_t3458191560 * ___discoveredServers_5;
	// VP`1<LanClientMenuUI/UIData/State> LanClientMenuUI/UIData::state
	VP_1_t974974500 * ___state_6;

public:
	inline static int32_t get_offset_of_discoveredServers_5() { return static_cast<int32_t>(offsetof(UIData_t3345341216, ___discoveredServers_5)); }
	inline VP_1_t3458191560 * get_discoveredServers_5() const { return ___discoveredServers_5; }
	inline VP_1_t3458191560 ** get_address_of_discoveredServers_5() { return &___discoveredServers_5; }
	inline void set_discoveredServers_5(VP_1_t3458191560 * value)
	{
		___discoveredServers_5 = value;
		Il2CppCodeGenWriteBarrier(&___discoveredServers_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t3345341216, ___state_6)); }
	inline VP_1_t974974500 * get_state_6() const { return ___state_6; }
	inline VP_1_t974974500 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t974974500 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
