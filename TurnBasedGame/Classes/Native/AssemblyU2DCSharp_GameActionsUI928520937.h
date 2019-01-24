#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2063873094.h"

// ProcessMoveActionUI
struct ProcessMoveActionUI_t3276599380;
// StartTurnActionUI
struct StartTurnActionUI_t130229265;
// NonActionUI
struct NonActionUI_t3703920299;
// UndoRedoActionUI
struct UndoRedoActionUI_t240952390;
// WaitInputActionUI
struct WaitInputActionUI_t2098345273;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameActionsUI
struct  GameActionsUI_t928520937  : public UIBehavior_1_t2063873094
{
public:
	// ProcessMoveActionUI GameActionsUI::processMoveActionPrefab
	ProcessMoveActionUI_t3276599380 * ___processMoveActionPrefab_6;
	// StartTurnActionUI GameActionsUI::startTurnActionPrefab
	StartTurnActionUI_t130229265 * ___startTurnActionPrefab_7;
	// NonActionUI GameActionsUI::nonActionPrefab
	NonActionUI_t3703920299 * ___nonActionPrefab_8;
	// UndoRedoActionUI GameActionsUI::undoRedoActionPrefab
	UndoRedoActionUI_t240952390 * ___undoRedoActionPrefab_9;
	// WaitInputActionUI GameActionsUI::waitInputActionPrefab
	WaitInputActionUI_t2098345273 * ___waitInputActionPrefab_10;

public:
	inline static int32_t get_offset_of_processMoveActionPrefab_6() { return static_cast<int32_t>(offsetof(GameActionsUI_t928520937, ___processMoveActionPrefab_6)); }
	inline ProcessMoveActionUI_t3276599380 * get_processMoveActionPrefab_6() const { return ___processMoveActionPrefab_6; }
	inline ProcessMoveActionUI_t3276599380 ** get_address_of_processMoveActionPrefab_6() { return &___processMoveActionPrefab_6; }
	inline void set_processMoveActionPrefab_6(ProcessMoveActionUI_t3276599380 * value)
	{
		___processMoveActionPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___processMoveActionPrefab_6, value);
	}

	inline static int32_t get_offset_of_startTurnActionPrefab_7() { return static_cast<int32_t>(offsetof(GameActionsUI_t928520937, ___startTurnActionPrefab_7)); }
	inline StartTurnActionUI_t130229265 * get_startTurnActionPrefab_7() const { return ___startTurnActionPrefab_7; }
	inline StartTurnActionUI_t130229265 ** get_address_of_startTurnActionPrefab_7() { return &___startTurnActionPrefab_7; }
	inline void set_startTurnActionPrefab_7(StartTurnActionUI_t130229265 * value)
	{
		___startTurnActionPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___startTurnActionPrefab_7, value);
	}

	inline static int32_t get_offset_of_nonActionPrefab_8() { return static_cast<int32_t>(offsetof(GameActionsUI_t928520937, ___nonActionPrefab_8)); }
	inline NonActionUI_t3703920299 * get_nonActionPrefab_8() const { return ___nonActionPrefab_8; }
	inline NonActionUI_t3703920299 ** get_address_of_nonActionPrefab_8() { return &___nonActionPrefab_8; }
	inline void set_nonActionPrefab_8(NonActionUI_t3703920299 * value)
	{
		___nonActionPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___nonActionPrefab_8, value);
	}

	inline static int32_t get_offset_of_undoRedoActionPrefab_9() { return static_cast<int32_t>(offsetof(GameActionsUI_t928520937, ___undoRedoActionPrefab_9)); }
	inline UndoRedoActionUI_t240952390 * get_undoRedoActionPrefab_9() const { return ___undoRedoActionPrefab_9; }
	inline UndoRedoActionUI_t240952390 ** get_address_of_undoRedoActionPrefab_9() { return &___undoRedoActionPrefab_9; }
	inline void set_undoRedoActionPrefab_9(UndoRedoActionUI_t240952390 * value)
	{
		___undoRedoActionPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoActionPrefab_9, value);
	}

	inline static int32_t get_offset_of_waitInputActionPrefab_10() { return static_cast<int32_t>(offsetof(GameActionsUI_t928520937, ___waitInputActionPrefab_10)); }
	inline WaitInputActionUI_t2098345273 * get_waitInputActionPrefab_10() const { return ___waitInputActionPrefab_10; }
	inline WaitInputActionUI_t2098345273 ** get_address_of_waitInputActionPrefab_10() { return &___waitInputActionPrefab_10; }
	inline void set_waitInputActionPrefab_10(WaitInputActionUI_t2098345273 * value)
	{
		___waitInputActionPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___waitInputActionPrefab_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
