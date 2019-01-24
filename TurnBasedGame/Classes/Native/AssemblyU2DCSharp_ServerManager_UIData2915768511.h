#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<ManagerUI/UIData>
struct VP_1_t363904470;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ServerManager/UIData
struct  UIData_t2915768511  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Server>> ServerManager/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<ManagerUI/UIData> ServerManager/UIData::managerUI
	VP_1_t363904470 * ___managerUI_6;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t2915768511, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_managerUI_6() { return static_cast<int32_t>(offsetof(UIData_t2915768511, ___managerUI_6)); }
	inline VP_1_t363904470 * get_managerUI_6() const { return ___managerUI_6; }
	inline VP_1_t363904470 ** get_address_of_managerUI_6() { return &___managerUI_6; }
	inline void set_managerUI_6(VP_1_t363904470 * value)
	{
		___managerUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___managerUI_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
