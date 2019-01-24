#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GlobalStateUI_UIData_Sub1416586640.h"

// VP`1<ReferenceData`1<Server/State/Disconnect>>
struct VP_1_t2841203009;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;
// VP`1<LoginStateUI/UIData>
struct VP_1_t3708195235;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StateDisconnectUI/UIData
struct  UIData_t1759303556  : public Sub_t1416586640
{
public:
	// VP`1<ReferenceData`1<Server/State/Disconnect>> StateDisconnectUI/UIData::disconnect
	VP_1_t2841203009 * ___disconnect_5;
	// VP`1<RequestChangeStringUI/UIData> StateDisconnectUI/UIData::time
	VP_1_t1525575381 * ___time_6;
	// VP`1<LoginStateUI/UIData> StateDisconnectUI/UIData::loginState
	VP_1_t3708195235 * ___loginState_7;

public:
	inline static int32_t get_offset_of_disconnect_5() { return static_cast<int32_t>(offsetof(UIData_t1759303556, ___disconnect_5)); }
	inline VP_1_t2841203009 * get_disconnect_5() const { return ___disconnect_5; }
	inline VP_1_t2841203009 ** get_address_of_disconnect_5() { return &___disconnect_5; }
	inline void set_disconnect_5(VP_1_t2841203009 * value)
	{
		___disconnect_5 = value;
		Il2CppCodeGenWriteBarrier(&___disconnect_5, value);
	}

	inline static int32_t get_offset_of_time_6() { return static_cast<int32_t>(offsetof(UIData_t1759303556, ___time_6)); }
	inline VP_1_t1525575381 * get_time_6() const { return ___time_6; }
	inline VP_1_t1525575381 ** get_address_of_time_6() { return &___time_6; }
	inline void set_time_6(VP_1_t1525575381 * value)
	{
		___time_6 = value;
		Il2CppCodeGenWriteBarrier(&___time_6, value);
	}

	inline static int32_t get_offset_of_loginState_7() { return static_cast<int32_t>(offsetof(UIData_t1759303556, ___loginState_7)); }
	inline VP_1_t3708195235 * get_loginState_7() const { return ___loginState_7; }
	inline VP_1_t3708195235 ** get_address_of_loginState_7() { return &___loginState_7; }
	inline void set_loginState_7(VP_1_t3708195235 * value)
	{
		___loginState_7 = value;
		Il2CppCodeGenWriteBarrier(&___loginState_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
