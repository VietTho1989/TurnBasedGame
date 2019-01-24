#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UpdateTransform/UpdateData
struct UpdateData_t2488869861;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TransformChange
struct  TransformChange_t3916124372  : public Il2CppObject
{
public:
	// UpdateTransform/UpdateData TransformChange::updateTransform
	UpdateData_t2488869861 * ___updateTransform_0;
	// System.Boolean TransformChange::dirty
	bool ___dirty_1;

public:
	inline static int32_t get_offset_of_updateTransform_0() { return static_cast<int32_t>(offsetof(TransformChange_t3916124372, ___updateTransform_0)); }
	inline UpdateData_t2488869861 * get_updateTransform_0() const { return ___updateTransform_0; }
	inline UpdateData_t2488869861 ** get_address_of_updateTransform_0() { return &___updateTransform_0; }
	inline void set_updateTransform_0(UpdateData_t2488869861 * value)
	{
		___updateTransform_0 = value;
		Il2CppCodeGenWriteBarrier(&___updateTransform_0, value);
	}

	inline static int32_t get_offset_of_dirty_1() { return static_cast<int32_t>(offsetof(TransformChange_t3916124372, ___dirty_1)); }
	inline bool get_dirty_1() const { return ___dirty_1; }
	inline bool* get_address_of_dirty_1() { return &___dirty_1; }
	inline void set_dirty_1(bool value)
	{
		___dirty_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
