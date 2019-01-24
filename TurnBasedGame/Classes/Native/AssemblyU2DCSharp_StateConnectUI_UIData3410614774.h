#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GlobalStateUI_UIData_Sub1416586640.h"

// VP`1<ReferenceData`1<Server/State/Connect>>
struct VP_1_t4000337245;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StateConnectUI/UIData
struct  UIData_t3410614774  : public Sub_t1416586640
{
public:
	// VP`1<ReferenceData`1<Server/State/Connect>> StateConnectUI/UIData::connect
	VP_1_t4000337245 * ___connect_5;
	// VP`1<RequestChangeStringUI/UIData> StateConnectUI/UIData::txtConnect
	VP_1_t1525575381 * ___txtConnect_6;

public:
	inline static int32_t get_offset_of_connect_5() { return static_cast<int32_t>(offsetof(UIData_t3410614774, ___connect_5)); }
	inline VP_1_t4000337245 * get_connect_5() const { return ___connect_5; }
	inline VP_1_t4000337245 ** get_address_of_connect_5() { return &___connect_5; }
	inline void set_connect_5(VP_1_t4000337245 * value)
	{
		___connect_5 = value;
		Il2CppCodeGenWriteBarrier(&___connect_5, value);
	}

	inline static int32_t get_offset_of_txtConnect_6() { return static_cast<int32_t>(offsetof(UIData_t3410614774, ___txtConnect_6)); }
	inline VP_1_t1525575381 * get_txtConnect_6() const { return ___txtConnect_6; }
	inline VP_1_t1525575381 ** get_address_of_txtConnect_6() { return &___txtConnect_6; }
	inline void set_txtConnect_6(VP_1_t1525575381 * value)
	{
		___txtConnect_6 = value;
		Il2CppCodeGenWriteBarrier(&___txtConnect_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
