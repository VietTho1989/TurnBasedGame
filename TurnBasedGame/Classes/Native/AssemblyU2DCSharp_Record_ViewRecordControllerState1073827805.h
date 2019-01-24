#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Record_ViewRecordControllerUI_UID658819208.h"

// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<Record.ViewRecordControllerStatePlay/State>
struct VP_1_t160967836;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ViewRecordControllerStatePlay
struct  ViewRecordControllerStatePlay_t1073827805  : public State_t658819208
{
public:
	// VP`1<System.Single> Record.ViewRecordControllerStatePlay::time
	VP_1_t2454786938 * ___time_5;
	// VP`1<Record.ViewRecordControllerStatePlay/State> Record.ViewRecordControllerStatePlay::state
	VP_1_t160967836 * ___state_6;

public:
	inline static int32_t get_offset_of_time_5() { return static_cast<int32_t>(offsetof(ViewRecordControllerStatePlay_t1073827805, ___time_5)); }
	inline VP_1_t2454786938 * get_time_5() const { return ___time_5; }
	inline VP_1_t2454786938 ** get_address_of_time_5() { return &___time_5; }
	inline void set_time_5(VP_1_t2454786938 * value)
	{
		___time_5 = value;
		Il2CppCodeGenWriteBarrier(&___time_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(ViewRecordControllerStatePlay_t1073827805, ___state_6)); }
	inline VP_1_t160967836 * get_state_6() const { return ___state_6; }
	inline VP_1_t160967836 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t160967836 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
