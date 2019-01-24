#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Tasks_UnityTask_1_gen323446203.h"
#include "System_System_Net_HttpStatusCode1898409641.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.HttpTask`1<System.Object>
struct  HttpTask_1_t213883536  : public UnityTask_1_t323446203
{
public:
	// System.String Foundation.Server.HttpTask`1::<Content>k__BackingField
	String_t* ___U3CContentU3Ek__BackingField_14;
	// System.String Foundation.Server.HttpTask`1::<Session>k__BackingField
	String_t* ___U3CSessionU3Ek__BackingField_15;
	// System.Boolean Foundation.Server.HttpTask`1::<IsWebException>k__BackingField
	bool ___U3CIsWebExceptionU3Ek__BackingField_16;
	// System.Net.HttpStatusCode Foundation.Server.HttpTask`1::<StatusCode>k__BackingField
	int32_t ___U3CStatusCodeU3Ek__BackingField_17;

public:
	inline static int32_t get_offset_of_U3CContentU3Ek__BackingField_14() { return static_cast<int32_t>(offsetof(HttpTask_1_t213883536, ___U3CContentU3Ek__BackingField_14)); }
	inline String_t* get_U3CContentU3Ek__BackingField_14() const { return ___U3CContentU3Ek__BackingField_14; }
	inline String_t** get_address_of_U3CContentU3Ek__BackingField_14() { return &___U3CContentU3Ek__BackingField_14; }
	inline void set_U3CContentU3Ek__BackingField_14(String_t* value)
	{
		___U3CContentU3Ek__BackingField_14 = value;
		Il2CppCodeGenWriteBarrier(&___U3CContentU3Ek__BackingField_14, value);
	}

	inline static int32_t get_offset_of_U3CSessionU3Ek__BackingField_15() { return static_cast<int32_t>(offsetof(HttpTask_1_t213883536, ___U3CSessionU3Ek__BackingField_15)); }
	inline String_t* get_U3CSessionU3Ek__BackingField_15() const { return ___U3CSessionU3Ek__BackingField_15; }
	inline String_t** get_address_of_U3CSessionU3Ek__BackingField_15() { return &___U3CSessionU3Ek__BackingField_15; }
	inline void set_U3CSessionU3Ek__BackingField_15(String_t* value)
	{
		___U3CSessionU3Ek__BackingField_15 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSessionU3Ek__BackingField_15, value);
	}

	inline static int32_t get_offset_of_U3CIsWebExceptionU3Ek__BackingField_16() { return static_cast<int32_t>(offsetof(HttpTask_1_t213883536, ___U3CIsWebExceptionU3Ek__BackingField_16)); }
	inline bool get_U3CIsWebExceptionU3Ek__BackingField_16() const { return ___U3CIsWebExceptionU3Ek__BackingField_16; }
	inline bool* get_address_of_U3CIsWebExceptionU3Ek__BackingField_16() { return &___U3CIsWebExceptionU3Ek__BackingField_16; }
	inline void set_U3CIsWebExceptionU3Ek__BackingField_16(bool value)
	{
		___U3CIsWebExceptionU3Ek__BackingField_16 = value;
	}

	inline static int32_t get_offset_of_U3CStatusCodeU3Ek__BackingField_17() { return static_cast<int32_t>(offsetof(HttpTask_1_t213883536, ___U3CStatusCodeU3Ek__BackingField_17)); }
	inline int32_t get_U3CStatusCodeU3Ek__BackingField_17() const { return ___U3CStatusCodeU3Ek__BackingField_17; }
	inline int32_t* get_address_of_U3CStatusCodeU3Ek__BackingField_17() { return &___U3CStatusCodeU3Ek__BackingField_17; }
	inline void set_U3CStatusCodeU3Ek__BackingField_17(int32_t value)
	{
		___U3CStatusCodeU3Ek__BackingField_17 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
