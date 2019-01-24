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

// Org.BouncyCastle.Crypto.Parameters.IesParameters
struct  IesParameters_t4148998567  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.IesParameters::derivation
	ByteU5BU5D_t3397334013* ___derivation_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.IesParameters::encoding
	ByteU5BU5D_t3397334013* ___encoding_1;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.IesParameters::macKeySize
	int32_t ___macKeySize_2;

public:
	inline static int32_t get_offset_of_derivation_0() { return static_cast<int32_t>(offsetof(IesParameters_t4148998567, ___derivation_0)); }
	inline ByteU5BU5D_t3397334013* get_derivation_0() const { return ___derivation_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_derivation_0() { return &___derivation_0; }
	inline void set_derivation_0(ByteU5BU5D_t3397334013* value)
	{
		___derivation_0 = value;
		Il2CppCodeGenWriteBarrier(&___derivation_0, value);
	}

	inline static int32_t get_offset_of_encoding_1() { return static_cast<int32_t>(offsetof(IesParameters_t4148998567, ___encoding_1)); }
	inline ByteU5BU5D_t3397334013* get_encoding_1() const { return ___encoding_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_encoding_1() { return &___encoding_1; }
	inline void set_encoding_1(ByteU5BU5D_t3397334013* value)
	{
		___encoding_1 = value;
		Il2CppCodeGenWriteBarrier(&___encoding_1, value);
	}

	inline static int32_t get_offset_of_macKeySize_2() { return static_cast<int32_t>(offsetof(IesParameters_t4148998567, ___macKeySize_2)); }
	inline int32_t get_macKeySize_2() const { return ___macKeySize_2; }
	inline int32_t* get_address_of_macKeySize_2() { return &___macKeySize_2; }
	inline void set_macKeySize_2(int32_t value)
	{
		___macKeySize_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
