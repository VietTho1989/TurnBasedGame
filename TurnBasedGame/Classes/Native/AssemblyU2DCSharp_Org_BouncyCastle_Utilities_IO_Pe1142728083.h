#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Collections.IList
struct IList_t3321498491;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.IO.Pem.PemObject
struct  PemObject_t1142728083  : public Il2CppObject
{
public:
	// System.String Org.BouncyCastle.Utilities.IO.Pem.PemObject::type
	String_t* ___type_0;
	// System.Collections.IList Org.BouncyCastle.Utilities.IO.Pem.PemObject::headers
	Il2CppObject * ___headers_1;
	// System.Byte[] Org.BouncyCastle.Utilities.IO.Pem.PemObject::content
	ByteU5BU5D_t3397334013* ___content_2;

public:
	inline static int32_t get_offset_of_type_0() { return static_cast<int32_t>(offsetof(PemObject_t1142728083, ___type_0)); }
	inline String_t* get_type_0() const { return ___type_0; }
	inline String_t** get_address_of_type_0() { return &___type_0; }
	inline void set_type_0(String_t* value)
	{
		___type_0 = value;
		Il2CppCodeGenWriteBarrier(&___type_0, value);
	}

	inline static int32_t get_offset_of_headers_1() { return static_cast<int32_t>(offsetof(PemObject_t1142728083, ___headers_1)); }
	inline Il2CppObject * get_headers_1() const { return ___headers_1; }
	inline Il2CppObject ** get_address_of_headers_1() { return &___headers_1; }
	inline void set_headers_1(Il2CppObject * value)
	{
		___headers_1 = value;
		Il2CppCodeGenWriteBarrier(&___headers_1, value);
	}

	inline static int32_t get_offset_of_content_2() { return static_cast<int32_t>(offsetof(PemObject_t1142728083, ___content_2)); }
	inline ByteU5BU5D_t3397334013* get_content_2() const { return ___content_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_content_2() { return &___content_2; }
	inline void set_content_2(ByteU5BU5D_t3397334013* value)
	{
		___content_2 = value;
		Il2CppCodeGenWriteBarrier(&___content_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
