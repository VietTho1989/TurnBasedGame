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
// VP`1<UserAdapter/UIData>
struct VP_1_t3433036045;
// VP`1<UserUI/UIData>
struct VP_1_t1073517286;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalProfileUI/UIData
struct  UIData_t3625496025  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Server>> GlobalProfileUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<UserAdapter/UIData> GlobalProfileUI/UIData::userAdapter
	VP_1_t3433036045 * ___userAdapter_6;
	// VP`1<UserUI/UIData> GlobalProfileUI/UIData::userUI
	VP_1_t1073517286 * ___userUI_7;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t3625496025, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_userAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t3625496025, ___userAdapter_6)); }
	inline VP_1_t3433036045 * get_userAdapter_6() const { return ___userAdapter_6; }
	inline VP_1_t3433036045 ** get_address_of_userAdapter_6() { return &___userAdapter_6; }
	inline void set_userAdapter_6(VP_1_t3433036045 * value)
	{
		___userAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___userAdapter_6, value);
	}

	inline static int32_t get_offset_of_userUI_7() { return static_cast<int32_t>(offsetof(UIData_t3625496025, ___userUI_7)); }
	inline VP_1_t1073517286 * get_userUI_7() const { return ___userUI_7; }
	inline VP_1_t1073517286 ** get_address_of_userUI_7() { return &___userUI_7; }
	inline void set_userUI_7(VP_1_t1073517286 * value)
	{
		___userUI_7 = value;
		Il2CppCodeGenWriteBarrier(&___userUI_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
