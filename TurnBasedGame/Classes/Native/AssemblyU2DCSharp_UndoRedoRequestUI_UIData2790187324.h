#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<UndoRedoRequest>>
struct VP_1_t915015840;
// VP`1<UndoRedoRequestUI/UIData/Sub>
struct VP_1_t1643732393;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedoRequestUI/UIData
struct  UIData_t2790187324  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<UndoRedoRequest>> UndoRedoRequestUI/UIData::undoRedoRequest
	VP_1_t915015840 * ___undoRedoRequest_5;
	// VP`1<UndoRedoRequestUI/UIData/Sub> UndoRedoRequestUI/UIData::sub
	VP_1_t1643732393 * ___sub_6;

public:
	inline static int32_t get_offset_of_undoRedoRequest_5() { return static_cast<int32_t>(offsetof(UIData_t2790187324, ___undoRedoRequest_5)); }
	inline VP_1_t915015840 * get_undoRedoRequest_5() const { return ___undoRedoRequest_5; }
	inline VP_1_t915015840 ** get_address_of_undoRedoRequest_5() { return &___undoRedoRequest_5; }
	inline void set_undoRedoRequest_5(VP_1_t915015840 * value)
	{
		___undoRedoRequest_5 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoRequest_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2790187324, ___sub_6)); }
	inline VP_1_t1643732393 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1643732393 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1643732393 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
