#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UndoRedoRequestUI_UIData_Sub1265455387.h"

// VP`1<ReferenceData`1<UndoRedo.Ask>>
struct VP_1_t184833200;
// LP`1<UndoRedo.AskHumanUI/UIData>
struct LP_1_t2456784741;
// VP`1<UndoRedo.AskUI/UIData/State>
struct VP_1_t1428546998;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.AskUI/UIData
struct  UIData_t2363784894  : public Sub_t1265455387
{
public:
	// VP`1<ReferenceData`1<UndoRedo.Ask>> UndoRedo.AskUI/UIData::ask
	VP_1_t184833200 * ___ask_5;
	// LP`1<UndoRedo.AskHumanUI/UIData> UndoRedo.AskUI/UIData::whoCanAsks
	LP_1_t2456784741 * ___whoCanAsks_6;
	// VP`1<UndoRedo.AskUI/UIData/State> UndoRedo.AskUI/UIData::state
	VP_1_t1428546998 * ___state_7;

public:
	inline static int32_t get_offset_of_ask_5() { return static_cast<int32_t>(offsetof(UIData_t2363784894, ___ask_5)); }
	inline VP_1_t184833200 * get_ask_5() const { return ___ask_5; }
	inline VP_1_t184833200 ** get_address_of_ask_5() { return &___ask_5; }
	inline void set_ask_5(VP_1_t184833200 * value)
	{
		___ask_5 = value;
		Il2CppCodeGenWriteBarrier(&___ask_5, value);
	}

	inline static int32_t get_offset_of_whoCanAsks_6() { return static_cast<int32_t>(offsetof(UIData_t2363784894, ___whoCanAsks_6)); }
	inline LP_1_t2456784741 * get_whoCanAsks_6() const { return ___whoCanAsks_6; }
	inline LP_1_t2456784741 ** get_address_of_whoCanAsks_6() { return &___whoCanAsks_6; }
	inline void set_whoCanAsks_6(LP_1_t2456784741 * value)
	{
		___whoCanAsks_6 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAsks_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(UIData_t2363784894, ___state_7)); }
	inline VP_1_t1428546998 * get_state_7() const { return ___state_7; }
	inline VP_1_t1428546998 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t1428546998 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
