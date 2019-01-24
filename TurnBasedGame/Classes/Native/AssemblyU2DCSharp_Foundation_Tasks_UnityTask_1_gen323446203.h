#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Tasks_UnityTask1881051092.h"

// System.Object
struct Il2CppObject;
// System.Func`1<System.Object>
struct Func_1_t348874681;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.UnityTask`1<System.Object>
struct  UnityTask_1_t323446203  : public UnityTask_t1881051092
{
public:
	// TResult Foundation.Tasks.UnityTask`1::Result
	Il2CppObject * ___Result_12;
	// System.Func`1<TResult> Foundation.Tasks.UnityTask`1::_function
	Func_1_t348874681 * ____function_13;

public:
	inline static int32_t get_offset_of_Result_12() { return static_cast<int32_t>(offsetof(UnityTask_1_t323446203, ___Result_12)); }
	inline Il2CppObject * get_Result_12() const { return ___Result_12; }
	inline Il2CppObject ** get_address_of_Result_12() { return &___Result_12; }
	inline void set_Result_12(Il2CppObject * value)
	{
		___Result_12 = value;
		Il2CppCodeGenWriteBarrier(&___Result_12, value);
	}

	inline static int32_t get_offset_of__function_13() { return static_cast<int32_t>(offsetof(UnityTask_1_t323446203, ____function_13)); }
	inline Func_1_t348874681 * get__function_13() const { return ____function_13; }
	inline Func_1_t348874681 ** get_address_of__function_13() { return &____function_13; }
	inline void set__function_13(Func_1_t348874681 * value)
	{
		____function_13 = value;
		Il2CppCodeGenWriteBarrier(&____function_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
