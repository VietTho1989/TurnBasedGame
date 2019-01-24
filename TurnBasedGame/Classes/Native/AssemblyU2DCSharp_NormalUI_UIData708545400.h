#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_ManagerUI_UIData_Sub4277966041.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<NormalUI/UIData/Sub>
struct VP_1_t2527017379;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NormalUI/UIData
struct  UIData_t708545400  : public Sub_t4277966041
{
public:
	// VP`1<ReferenceData`1<Server>> NormalUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<NormalUI/UIData/Sub> NormalUI/UIData::sub
	VP_1_t2527017379 * ___sub_6;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t708545400, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t708545400, ___sub_6)); }
	inline VP_1_t2527017379 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2527017379 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2527017379 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
