#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Exception1927440687.h"
#include "System_System_Net_HttpStatusCode1898409641.h"

// System.Collections.Generic.Dictionary`2<System.String,System.String[]>
struct Dictionary_2_t3557165234;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.HttpException
struct  HttpException_t3853520137  : public Exception_t1927440687
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.String[]> Foundation.Server.HttpException::<ModelState>k__BackingField
	Dictionary_2_t3557165234 * ___U3CModelStateU3Ek__BackingField_11;
	// System.Net.HttpStatusCode Foundation.Server.HttpException::<Status>k__BackingField
	int32_t ___U3CStatusU3Ek__BackingField_12;

public:
	inline static int32_t get_offset_of_U3CModelStateU3Ek__BackingField_11() { return static_cast<int32_t>(offsetof(HttpException_t3853520137, ___U3CModelStateU3Ek__BackingField_11)); }
	inline Dictionary_2_t3557165234 * get_U3CModelStateU3Ek__BackingField_11() const { return ___U3CModelStateU3Ek__BackingField_11; }
	inline Dictionary_2_t3557165234 ** get_address_of_U3CModelStateU3Ek__BackingField_11() { return &___U3CModelStateU3Ek__BackingField_11; }
	inline void set_U3CModelStateU3Ek__BackingField_11(Dictionary_2_t3557165234 * value)
	{
		___U3CModelStateU3Ek__BackingField_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CModelStateU3Ek__BackingField_11, value);
	}

	inline static int32_t get_offset_of_U3CStatusU3Ek__BackingField_12() { return static_cast<int32_t>(offsetof(HttpException_t3853520137, ___U3CStatusU3Ek__BackingField_12)); }
	inline int32_t get_U3CStatusU3Ek__BackingField_12() const { return ___U3CStatusU3Ek__BackingField_12; }
	inline int32_t* get_address_of_U3CStatusU3Ek__BackingField_12() { return &___U3CStatusU3Ek__BackingField_12; }
	inline void set_U3CStatusU3Ek__BackingField_12(int32_t value)
	{
		___U3CStatusU3Ek__BackingField_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
