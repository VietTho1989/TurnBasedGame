#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameAction3938216248.h"

// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<WaitInputAction/Sub>
struct VP_1_t3170526770;
// LP`1<InputData>
struct LP_1_t3646079564;
// VP`1<ClientInput>
struct VP_1_t1472184019;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitInputAction
struct  WaitInputAction_t1882979057  : public GameAction_t3938216248
{
public:
	// VP`1<System.Single> WaitInputAction::serverTime
	VP_1_t2454786938 * ___serverTime_5;
	// VP`1<System.Single> WaitInputAction::clientTime
	VP_1_t2454786938 * ___clientTime_6;
	// VP`1<WaitInputAction/Sub> WaitInputAction::sub
	VP_1_t3170526770 * ___sub_7;
	// LP`1<InputData> WaitInputAction::inputs
	LP_1_t3646079564 * ___inputs_8;
	// VP`1<ClientInput> WaitInputAction::clientInput
	VP_1_t1472184019 * ___clientInput_9;

public:
	inline static int32_t get_offset_of_serverTime_5() { return static_cast<int32_t>(offsetof(WaitInputAction_t1882979057, ___serverTime_5)); }
	inline VP_1_t2454786938 * get_serverTime_5() const { return ___serverTime_5; }
	inline VP_1_t2454786938 ** get_address_of_serverTime_5() { return &___serverTime_5; }
	inline void set_serverTime_5(VP_1_t2454786938 * value)
	{
		___serverTime_5 = value;
		Il2CppCodeGenWriteBarrier(&___serverTime_5, value);
	}

	inline static int32_t get_offset_of_clientTime_6() { return static_cast<int32_t>(offsetof(WaitInputAction_t1882979057, ___clientTime_6)); }
	inline VP_1_t2454786938 * get_clientTime_6() const { return ___clientTime_6; }
	inline VP_1_t2454786938 ** get_address_of_clientTime_6() { return &___clientTime_6; }
	inline void set_clientTime_6(VP_1_t2454786938 * value)
	{
		___clientTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___clientTime_6, value);
	}

	inline static int32_t get_offset_of_sub_7() { return static_cast<int32_t>(offsetof(WaitInputAction_t1882979057, ___sub_7)); }
	inline VP_1_t3170526770 * get_sub_7() const { return ___sub_7; }
	inline VP_1_t3170526770 ** get_address_of_sub_7() { return &___sub_7; }
	inline void set_sub_7(VP_1_t3170526770 * value)
	{
		___sub_7 = value;
		Il2CppCodeGenWriteBarrier(&___sub_7, value);
	}

	inline static int32_t get_offset_of_inputs_8() { return static_cast<int32_t>(offsetof(WaitInputAction_t1882979057, ___inputs_8)); }
	inline LP_1_t3646079564 * get_inputs_8() const { return ___inputs_8; }
	inline LP_1_t3646079564 ** get_address_of_inputs_8() { return &___inputs_8; }
	inline void set_inputs_8(LP_1_t3646079564 * value)
	{
		___inputs_8 = value;
		Il2CppCodeGenWriteBarrier(&___inputs_8, value);
	}

	inline static int32_t get_offset_of_clientInput_9() { return static_cast<int32_t>(offsetof(WaitInputAction_t1882979057, ___clientInput_9)); }
	inline VP_1_t1472184019 * get_clientInput_9() const { return ___clientInput_9; }
	inline VP_1_t1472184019 ** get_address_of_clientInput_9() { return &___clientInput_9; }
	inline void set_clientInput_9(VP_1_t1472184019 * value)
	{
		___clientInput_9 = value;
		Il2CppCodeGenWriteBarrier(&___clientInput_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
