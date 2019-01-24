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
// VP`1<GlobalStateUI/UIData/Sub>
struct VP_1_t1794863646;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalStateUI/UIData
struct  UIData_t1760100389  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Server>> GlobalStateUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<GlobalStateUI/UIData/Sub> GlobalStateUI/UIData::sub
	VP_1_t1794863646 * ___sub_6;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t1760100389, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1760100389, ___sub_6)); }
	inline VP_1_t1794863646 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1794863646 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1794863646 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
