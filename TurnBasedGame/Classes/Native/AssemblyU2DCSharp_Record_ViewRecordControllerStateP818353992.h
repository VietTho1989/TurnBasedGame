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

// Record.ViewRecordControllerStatePick
struct  ViewRecordControllerStatePick_t818353992  : public State_t658819208
{
public:
	// VP`1<System.Single> Record.ViewRecordControllerStatePick::startTime
	VP_1_t2454786938 * ___startTime_5;
	// VP`1<System.Single> Record.ViewRecordControllerStatePick::pickTime
	VP_1_t2454786938 * ___pickTime_6;
	// VP`1<Record.ViewRecordControllerStatePlay/State> Record.ViewRecordControllerStatePick::playState
	VP_1_t160967836 * ___playState_7;

public:
	inline static int32_t get_offset_of_startTime_5() { return static_cast<int32_t>(offsetof(ViewRecordControllerStatePick_t818353992, ___startTime_5)); }
	inline VP_1_t2454786938 * get_startTime_5() const { return ___startTime_5; }
	inline VP_1_t2454786938 ** get_address_of_startTime_5() { return &___startTime_5; }
	inline void set_startTime_5(VP_1_t2454786938 * value)
	{
		___startTime_5 = value;
		Il2CppCodeGenWriteBarrier(&___startTime_5, value);
	}

	inline static int32_t get_offset_of_pickTime_6() { return static_cast<int32_t>(offsetof(ViewRecordControllerStatePick_t818353992, ___pickTime_6)); }
	inline VP_1_t2454786938 * get_pickTime_6() const { return ___pickTime_6; }
	inline VP_1_t2454786938 ** get_address_of_pickTime_6() { return &___pickTime_6; }
	inline void set_pickTime_6(VP_1_t2454786938 * value)
	{
		___pickTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___pickTime_6, value);
	}

	inline static int32_t get_offset_of_playState_7() { return static_cast<int32_t>(offsetof(ViewRecordControllerStatePick_t818353992, ___playState_7)); }
	inline VP_1_t160967836 * get_playState_7() const { return ___playState_7; }
	inline VP_1_t160967836 ** get_address_of_playState_7() { return &___playState_7; }
	inline void set_playState_7(VP_1_t160967836 * value)
	{
		___playState_7 = value;
		Il2CppCodeGenWriteBarrier(&___playState_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
