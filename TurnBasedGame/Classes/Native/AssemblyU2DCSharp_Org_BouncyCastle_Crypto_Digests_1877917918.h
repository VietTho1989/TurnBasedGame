#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Digests.GeneralDigest
struct  GeneralDigest_t1877917918  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.GeneralDigest::xBuf
	ByteU5BU5D_t3397334013* ___xBuf_1;
	// System.Int32 Org.BouncyCastle.Crypto.Digests.GeneralDigest::xBufOff
	int32_t ___xBufOff_2;
	// System.Int64 Org.BouncyCastle.Crypto.Digests.GeneralDigest::byteCount
	int64_t ___byteCount_3;

public:
	inline static int32_t get_offset_of_xBuf_1() { return static_cast<int32_t>(offsetof(GeneralDigest_t1877917918, ___xBuf_1)); }
	inline ByteU5BU5D_t3397334013* get_xBuf_1() const { return ___xBuf_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_xBuf_1() { return &___xBuf_1; }
	inline void set_xBuf_1(ByteU5BU5D_t3397334013* value)
	{
		___xBuf_1 = value;
		Il2CppCodeGenWriteBarrier(&___xBuf_1, value);
	}

	inline static int32_t get_offset_of_xBufOff_2() { return static_cast<int32_t>(offsetof(GeneralDigest_t1877917918, ___xBufOff_2)); }
	inline int32_t get_xBufOff_2() const { return ___xBufOff_2; }
	inline int32_t* get_address_of_xBufOff_2() { return &___xBufOff_2; }
	inline void set_xBufOff_2(int32_t value)
	{
		___xBufOff_2 = value;
	}

	inline static int32_t get_offset_of_byteCount_3() { return static_cast<int32_t>(offsetof(GeneralDigest_t1877917918, ___byteCount_3)); }
	inline int64_t get_byteCount_3() const { return ___byteCount_3; }
	inline int64_t* get_address_of_byteCount_3() { return &___byteCount_3; }
	inline void set_byteCount_3(int64_t value)
	{
		___byteCount_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
