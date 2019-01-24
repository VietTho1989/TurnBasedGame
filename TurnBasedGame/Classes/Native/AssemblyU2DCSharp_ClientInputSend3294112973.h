#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_ClientInput_Sub2386272548.h"

// VP`1<ClientInputSend/State>
struct VP_1_t971172263;
// VP`1<GameMove>
struct VP_1_t2240176003;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientInputSend
struct  ClientInputSend_t3294112973  : public Sub_t2386272548
{
public:
	// VP`1<ClientInputSend/State> ClientInputSend::state
	VP_1_t971172263 * ___state_5;
	// VP`1<GameMove> ClientInputSend::gameMove
	VP_1_t2240176003 * ___gameMove_6;
	// VP`1<System.Single> ClientInputSend::clientTimeSend
	VP_1_t2454786938 * ___clientTimeSend_7;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(ClientInputSend_t3294112973, ___state_5)); }
	inline VP_1_t971172263 * get_state_5() const { return ___state_5; }
	inline VP_1_t971172263 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t971172263 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_gameMove_6() { return static_cast<int32_t>(offsetof(ClientInputSend_t3294112973, ___gameMove_6)); }
	inline VP_1_t2240176003 * get_gameMove_6() const { return ___gameMove_6; }
	inline VP_1_t2240176003 ** get_address_of_gameMove_6() { return &___gameMove_6; }
	inline void set_gameMove_6(VP_1_t2240176003 * value)
	{
		___gameMove_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameMove_6, value);
	}

	inline static int32_t get_offset_of_clientTimeSend_7() { return static_cast<int32_t>(offsetof(ClientInputSend_t3294112973, ___clientTimeSend_7)); }
	inline VP_1_t2454786938 * get_clientTimeSend_7() const { return ___clientTimeSend_7; }
	inline VP_1_t2454786938 ** get_address_of_clientTimeSend_7() { return &___clientTimeSend_7; }
	inline void set_clientTimeSend_7(VP_1_t2454786938 * value)
	{
		___clientTimeSend_7 = value;
		Il2CppCodeGenWriteBarrier(&___clientTimeSend_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
