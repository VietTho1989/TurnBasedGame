#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameActionsUI_UIData_Sub2280453533.h"

// VP`1<ReferenceData`1<UndoRedoAction>>
struct VP_1_t1208745785;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedoActionUI/UIData
struct  UIData_t2410014227  : public Sub_t2280453533
{
public:
	// VP`1<ReferenceData`1<UndoRedoAction>> UndoRedoActionUI/UIData::undoRedoAction
	VP_1_t1208745785 * ___undoRedoAction_5;

public:
	inline static int32_t get_offset_of_undoRedoAction_5() { return static_cast<int32_t>(offsetof(UIData_t2410014227, ___undoRedoAction_5)); }
	inline VP_1_t1208745785 * get_undoRedoAction_5() const { return ___undoRedoAction_5; }
	inline VP_1_t1208745785 ** get_address_of_undoRedoAction_5() { return &___undoRedoAction_5; }
	inline void set_undoRedoAction_5(VP_1_t1208745785 * value)
	{
		___undoRedoAction_5 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoAction_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
