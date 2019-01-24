#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Tasks_UnityTask1881051092.h"

// Foundation.Example.ServerTests/DemoObject[]
struct DemoObjectU5BU5D_t3348656117;
// System.Func`1<Foundation.Example.ServerTests/DemoObject[]>
struct Func_1_t1008081503;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.UnityTask`1<Foundation.Example.ServerTests/DemoObject[]>
struct  UnityTask_1_t982653025  : public UnityTask_t1881051092
{
public:
	// TResult Foundation.Tasks.UnityTask`1::Result
	DemoObjectU5BU5D_t3348656117* ___Result_12;
	// System.Func`1<TResult> Foundation.Tasks.UnityTask`1::_function
	Func_1_t1008081503 * ____function_13;

public:
	inline static int32_t get_offset_of_Result_12() { return static_cast<int32_t>(offsetof(UnityTask_1_t982653025, ___Result_12)); }
	inline DemoObjectU5BU5D_t3348656117* get_Result_12() const { return ___Result_12; }
	inline DemoObjectU5BU5D_t3348656117** get_address_of_Result_12() { return &___Result_12; }
	inline void set_Result_12(DemoObjectU5BU5D_t3348656117* value)
	{
		___Result_12 = value;
		Il2CppCodeGenWriteBarrier(&___Result_12, value);
	}

	inline static int32_t get_offset_of__function_13() { return static_cast<int32_t>(offsetof(UnityTask_1_t982653025, ____function_13)); }
	inline Func_1_t1008081503 * get__function_13() const { return ____function_13; }
	inline Func_1_t1008081503 ** get_address_of__function_13() { return &____function_13; }
	inline void set__function_13(Func_1_t1008081503 * value)
	{
		____function_13 = value;
		Il2CppCodeGenWriteBarrier(&____function_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
