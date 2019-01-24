#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameAction3938216248.h"

// VP`1<UndoRedoAction/State>
struct VP_1_t3809812320;
// VP`1<UndoRedo.RequestInform>
struct VP_1_t3389450696;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedoAction
struct  UndoRedoAction_t1759685716  : public GameAction_t3938216248
{
public:
	// VP`1<UndoRedoAction/State> UndoRedoAction::state
	VP_1_t3809812320 * ___state_5;
	// VP`1<UndoRedo.RequestInform> UndoRedoAction::requestInform
	VP_1_t3389450696 * ___requestInform_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UndoRedoAction_t1759685716, ___state_5)); }
	inline VP_1_t3809812320 * get_state_5() const { return ___state_5; }
	inline VP_1_t3809812320 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3809812320 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_requestInform_6() { return static_cast<int32_t>(offsetof(UndoRedoAction_t1759685716, ___requestInform_6)); }
	inline VP_1_t3389450696 * get_requestInform_6() const { return ___requestInform_6; }
	inline VP_1_t3389450696 ** get_address_of_requestInform_6() { return &___requestInform_6; }
	inline void set_requestInform_6(VP_1_t3389450696 * value)
	{
		___requestInform_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestInform_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
