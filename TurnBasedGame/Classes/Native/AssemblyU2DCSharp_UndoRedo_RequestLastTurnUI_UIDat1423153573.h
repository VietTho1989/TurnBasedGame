#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UndoRedo_NoneUI_UIData_Sub1871023542.h"

// VP`1<ReferenceData`1<UndoRedo.RequestLastTurn>>
struct VP_1_t3556135693;
// VP`1<UndoRedo.RequestLastTurnUI/UIData/State>
struct VP_1_t2016235391;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.RequestLastTurnUI/UIData
struct  UIData_t1423153573  : public Sub_t1871023542
{
public:
	// VP`1<ReferenceData`1<UndoRedo.RequestLastTurn>> UndoRedo.RequestLastTurnUI/UIData::requestLastTurn
	VP_1_t3556135693 * ___requestLastTurn_5;
	// VP`1<UndoRedo.RequestLastTurnUI/UIData/State> UndoRedo.RequestLastTurnUI/UIData::state
	VP_1_t2016235391 * ___state_6;

public:
	inline static int32_t get_offset_of_requestLastTurn_5() { return static_cast<int32_t>(offsetof(UIData_t1423153573, ___requestLastTurn_5)); }
	inline VP_1_t3556135693 * get_requestLastTurn_5() const { return ___requestLastTurn_5; }
	inline VP_1_t3556135693 ** get_address_of_requestLastTurn_5() { return &___requestLastTurn_5; }
	inline void set_requestLastTurn_5(VP_1_t3556135693 * value)
	{
		___requestLastTurn_5 = value;
		Il2CppCodeGenWriteBarrier(&___requestLastTurn_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t1423153573, ___state_6)); }
	inline VP_1_t2016235391 * get_state_6() const { return ___state_6; }
	inline VP_1_t2016235391 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2016235391 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
