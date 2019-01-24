#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2074262176.h"

// UndoRedo.NoneUI
struct NoneUI_t4124918766;
// UndoRedo.AskUI
struct AskUI_t2605288739;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedoRequestUI
struct  UndoRedoRequestUI_t1557506107  : public UIBehavior_1_t2074262176
{
public:
	// UndoRedo.NoneUI UndoRedoRequestUI::nonePrefab
	NoneUI_t4124918766 * ___nonePrefab_6;
	// UndoRedo.AskUI UndoRedoRequestUI::askPrefab
	AskUI_t2605288739 * ___askPrefab_7;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(UndoRedoRequestUI_t1557506107, ___nonePrefab_6)); }
	inline NoneUI_t4124918766 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline NoneUI_t4124918766 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(NoneUI_t4124918766 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_askPrefab_7() { return static_cast<int32_t>(offsetof(UndoRedoRequestUI_t1557506107, ___askPrefab_7)); }
	inline AskUI_t2605288739 * get_askPrefab_7() const { return ___askPrefab_7; }
	inline AskUI_t2605288739 ** get_address_of_askPrefab_7() { return &___askPrefab_7; }
	inline void set_askPrefab_7(AskUI_t2605288739 * value)
	{
		___askPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
