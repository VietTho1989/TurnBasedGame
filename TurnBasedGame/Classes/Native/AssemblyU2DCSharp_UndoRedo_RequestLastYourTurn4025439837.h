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
// VP`1<System.UInt32>
struct VP_1_t2527959027;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.RequestLastYourTurn
struct  RequestLastYourTurn_t4025439837  : public RequestInform_t3011173690
{
public:
	// VP`1<UndoRedoRequest/Operation> UndoRedo.RequestLastYourTurn::operation
	VP_1_t3067655195 * ___operation_5;
	// VP`1<System.UInt32> UndoRedo.RequestLastYourTurn::userId
	VP_1_t2527959027 * ___userId_6;

public:
	inline static int32_t get_offset_of_operation_5() { return static_cast<int32_t>(offsetof(RequestLastYourTurn_t4025439837, ___operation_5)); }
	inline VP_1_t3067655195 * get_operation_5() const { return ___operation_5; }
	inline VP_1_t3067655195 ** get_address_of_operation_5() { return &___operation_5; }
	inline void set_operation_5(VP_1_t3067655195 * value)
	{
		___operation_5 = value;
		Il2CppCodeGenWriteBarrier(&___operation_5, value);
	}

	inline static int32_t get_offset_of_userId_6() { return static_cast<int32_t>(offsetof(RequestLastYourTurn_t4025439837, ___userId_6)); }
	inline VP_1_t2527959027 * get_userId_6() const { return ___userId_6; }
	inline VP_1_t2527959027 ** get_address_of_userId_6() { return &___userId_6; }
	inline void set_userId_6(VP_1_t2527959027 * value)
	{
		___userId_6 = value;
		Il2CppCodeGenWriteBarrier(&___userId_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
