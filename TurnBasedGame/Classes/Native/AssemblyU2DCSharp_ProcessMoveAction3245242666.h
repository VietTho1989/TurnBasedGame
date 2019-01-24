#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameAction3938216248.h"

// VP`1<ProcessMoveAction/State>
struct VP_1_t232116794;
// VP`1<InputData>
struct VP_1_t991645318;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ProcessMoveAction
struct  ProcessMoveAction_t3245242666  : public GameAction_t3938216248
{
public:
	// VP`1<ProcessMoveAction/State> ProcessMoveAction::state
	VP_1_t232116794 * ___state_5;
	// VP`1<InputData> ProcessMoveAction::inputData
	VP_1_t991645318 * ___inputData_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(ProcessMoveAction_t3245242666, ___state_5)); }
	inline VP_1_t232116794 * get_state_5() const { return ___state_5; }
	inline VP_1_t232116794 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t232116794 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_inputData_6() { return static_cast<int32_t>(offsetof(ProcessMoveAction_t3245242666, ___inputData_6)); }
	inline VP_1_t991645318 * get_inputData_6() const { return ___inputData_6; }
	inline VP_1_t991645318 ** get_address_of_inputData_6() { return &___inputData_6; }
	inline void set_inputData_6(VP_1_t991645318 * value)
	{
		___inputData_6 = value;
		Il2CppCodeGenWriteBarrier(&___inputData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
