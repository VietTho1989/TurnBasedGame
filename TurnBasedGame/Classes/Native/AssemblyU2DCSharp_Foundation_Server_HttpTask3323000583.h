#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Tasks_UnityTask1881051092.h"
#include "System_System_Net_HttpStatusCode1898409641.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.HttpTask
struct  HttpTask_t3323000583  : public UnityTask_t1881051092
{
public:
	// System.String Foundation.Server.HttpTask::<Content>k__BackingField
	String_t* ___U3CContentU3Ek__BackingField_12;
	// System.String Foundation.Server.HttpTask::<Session>k__BackingField
	String_t* ___U3CSessionU3Ek__BackingField_13;
	// System.Boolean Foundation.Server.HttpTask::<IsWebException>k__BackingField
	bool ___U3CIsWebExceptionU3Ek__BackingField_14;
	// System.Net.HttpStatusCode Foundation.Server.HttpTask::<StatusCode>k__BackingField
	int32_t ___U3CStatusCodeU3Ek__BackingField_15;

public:
	inline static int32_t get_offset_of_U3CContentU3Ek__BackingField_12() { return static_cast<int32_t>(offsetof(HttpTask_t3323000583, ___U3CContentU3Ek__BackingField_12)); }
	inline String_t* get_U3CContentU3Ek__BackingField_12() const { return ___U3CContentU3Ek__BackingField_12; }
	inline String_t** get_address_of_U3CContentU3Ek__BackingField_12() { return &___U3CContentU3Ek__BackingField_12; }
	inline void set_U3CContentU3Ek__BackingField_12(String_t* value)
	{
		___U3CContentU3Ek__BackingField_12 = value;
		Il2CppCodeGenWriteBarrier(&___U3CContentU3Ek__BackingField_12, value);
	}

	inline static int32_t get_offset_of_U3CSessionU3Ek__BackingField_13() { return static_cast<int32_t>(offsetof(HttpTask_t3323000583, ___U3CSessionU3Ek__BackingField_13)); }
	inline String_t* get_U3CSessionU3Ek__BackingField_13() const { return ___U3CSessionU3Ek__BackingField_13; }
	inline String_t** get_address_of_U3CSessionU3Ek__BackingField_13() { return &___U3CSessionU3Ek__BackingField_13; }
	inline void set_U3CSessionU3Ek__BackingField_13(String_t* value)
	{
		___U3CSessionU3Ek__BackingField_13 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSessionU3Ek__BackingField_13, value);
	}

	inline static int32_t get_offset_of_U3CIsWebExceptionU3Ek__BackingField_14() { return static_cast<int32_t>(offsetof(HttpTask_t3323000583, ___U3CIsWebExceptionU3Ek__BackingField_14)); }
	inline bool get_U3CIsWebExceptionU3Ek__BackingField_14() const { return ___U3CIsWebExceptionU3Ek__BackingField_14; }
	inline bool* get_address_of_U3CIsWebExceptionU3Ek__BackingField_14() { return &___U3CIsWebExceptionU3Ek__BackingField_14; }
	inline void set_U3CIsWebExceptionU3Ek__BackingField_14(bool value)
	{
		___U3CIsWebExceptionU3Ek__BackingField_14 = value;
	}

	inline static int32_t get_offset_of_U3CStatusCodeU3Ek__BackingField_15() { return static_cast<int32_t>(offsetof(HttpTask_t3323000583, ___U3CStatusCodeU3Ek__BackingField_15)); }
	inline int32_t get_U3CStatusCodeU3Ek__BackingField_15() const { return ___U3CStatusCodeU3Ek__BackingField_15; }
	inline int32_t* get_address_of_U3CStatusCodeU3Ek__BackingField_15() { return &___U3CStatusCodeU3Ek__BackingField_15; }
	inline void set_U3CStatusCodeU3Ek__BackingField_15(int32_t value)
	{
		___U3CStatusCodeU3Ek__BackingField_15 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
