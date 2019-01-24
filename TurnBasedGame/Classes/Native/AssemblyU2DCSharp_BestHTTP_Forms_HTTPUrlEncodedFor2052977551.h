#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_Forms_HTTPFormBase1912072923.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Forms.HTTPUrlEncodedForm
struct  HTTPUrlEncodedForm_t2052977551  : public HTTPFormBase_t1912072923
{
public:
	// System.Byte[] BestHTTP.Forms.HTTPUrlEncodedForm::CachedData
	ByteU5BU5D_t3397334013* ___CachedData_5;

public:
	inline static int32_t get_offset_of_CachedData_5() { return static_cast<int32_t>(offsetof(HTTPUrlEncodedForm_t2052977551, ___CachedData_5)); }
	inline ByteU5BU5D_t3397334013* get_CachedData_5() const { return ___CachedData_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_CachedData_5() { return &___CachedData_5; }
	inline void set_CachedData_5(ByteU5BU5D_t3397334013* value)
	{
		___CachedData_5 = value;
		Il2CppCodeGenWriteBarrier(&___CachedData_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
