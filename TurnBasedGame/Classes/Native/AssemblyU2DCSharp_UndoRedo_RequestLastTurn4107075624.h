#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UndoRedo_RequestInform3011173690.h"

// VP`1<UndoRedoRequest/Operation>
struct VP_1_t3067655195;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.RequestLastTurn
struct  RequestLastTurn_t4107075624  : public RequestInform_t3011173690
{
public:
	// VP`1<UndoRedoRequest/Operation> UndoRedo.RequestLastTurn::operation
	VP_1_t3067655195 * ___operation_5;

public:
	inline static int32_t get_offset_of_operation_5() { return static_cast<int32_t>(offsetof(RequestLastTurn_t4107075624, ___operation_5)); }
	inline VP_1_t3067655195 * get_operation_5() const { return ___operation_5; }
	inline VP_1_t3067655195 ** get_address_of_operation_5() { return &___operation_5; }
	inline void set_operation_5(VP_1_t3067655195 * value)
	{
		___operation_5 = value;
		Il2CppCodeGenWriteBarrier(&___operation_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
