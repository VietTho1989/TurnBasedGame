#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_Forms_HTTPFormBase1912072923.h"

// System.String
struct String_t;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Forms.HTTPMultiPartForm
struct  HTTPMultiPartForm_t2201706314  : public HTTPFormBase_t1912072923
{
public:
	// System.String BestHTTP.Forms.HTTPMultiPartForm::Boundary
	String_t* ___Boundary_5;
	// System.Byte[] BestHTTP.Forms.HTTPMultiPartForm::CachedData
	ByteU5BU5D_t3397334013* ___CachedData_6;

public:
	inline static int32_t get_offset_of_Boundary_5() { return static_cast<int32_t>(offsetof(HTTPMultiPartForm_t2201706314, ___Boundary_5)); }
	inline String_t* get_Boundary_5() const { return ___Boundary_5; }
	inline String_t** get_address_of_Boundary_5() { return &___Boundary_5; }
	inline void set_Boundary_5(String_t* value)
	{
		___Boundary_5 = value;
		Il2CppCodeGenWriteBarrier(&___Boundary_5, value);
	}

	inline static int32_t get_offset_of_CachedData_6() { return static_cast<int32_t>(offsetof(HTTPMultiPartForm_t2201706314, ___CachedData_6)); }
	inline ByteU5BU5D_t3397334013* get_CachedData_6() const { return ___CachedData_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_CachedData_6() { return &___CachedData_6; }
	inline void set_CachedData_6(ByteU5BU5D_t3397334013* value)
	{
		___CachedData_6 = value;
		Il2CppCodeGenWriteBarrier(&___CachedData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
