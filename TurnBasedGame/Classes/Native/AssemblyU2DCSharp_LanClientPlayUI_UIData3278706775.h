#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LanClientUI_UIData_Sub2365718208.h"

// VP`1<ServerManager/UIData>
struct VP_1_t3294045517;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LanClientPlayUI/UIData
struct  UIData_t3278706775  : public Sub_t2365718208
{
public:
	// VP`1<ServerManager/UIData> LanClientPlayUI/UIData::serverManager
	VP_1_t3294045517 * ___serverManager_5;

public:
	inline static int32_t get_offset_of_serverManager_5() { return static_cast<int32_t>(offsetof(UIData_t3278706775, ___serverManager_5)); }
	inline VP_1_t3294045517 * get_serverManager_5() const { return ___serverManager_5; }
	inline VP_1_t3294045517 ** get_address_of_serverManager_5() { return &___serverManager_5; }
	inline void set_serverManager_5(VP_1_t3294045517 * value)
	{
		___serverManager_5 = value;
		Il2CppCodeGenWriteBarrier(&___serverManager_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
