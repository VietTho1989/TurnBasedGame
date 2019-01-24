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
// Org.BouncyCastle.Crypto.Parameters.KeyParameter
struct KeyParameter_t215653120;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.AeadParameters
struct  AeadParameters_t2995549197  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.AeadParameters::associatedText
	ByteU5BU5D_t3397334013* ___associatedText_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.AeadParameters::nonce
	ByteU5BU5D_t3397334013* ___nonce_1;
	// Org.BouncyCastle.Crypto.Parameters.KeyParameter Org.BouncyCastle.Crypto.Parameters.AeadParameters::key
	KeyParameter_t215653120 * ___key_2;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.AeadParameters::macSize
	int32_t ___macSize_3;

public:
	inline static int32_t get_offset_of_associatedText_0() { return static_cast<int32_t>(offsetof(AeadParameters_t2995549197, ___associatedText_0)); }
	inline ByteU5BU5D_t3397334013* get_associatedText_0() const { return ___associatedText_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_associatedText_0() { return &___associatedText_0; }
	inline void set_associatedText_0(ByteU5BU5D_t3397334013* value)
	{
		___associatedText_0 = value;
		Il2CppCodeGenWriteBarrier(&___associatedText_0, value);
	}

	inline static int32_t get_offset_of_nonce_1() { return static_cast<int32_t>(offsetof(AeadParameters_t2995549197, ___nonce_1)); }
	inline ByteU5BU5D_t3397334013* get_nonce_1() const { return ___nonce_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_nonce_1() { return &___nonce_1; }
	inline void set_nonce_1(ByteU5BU5D_t3397334013* value)
	{
		___nonce_1 = value;
		Il2CppCodeGenWriteBarrier(&___nonce_1, value);
	}

	inline static int32_t get_offset_of_key_2() { return static_cast<int32_t>(offsetof(AeadParameters_t2995549197, ___key_2)); }
	inline KeyParameter_t215653120 * get_key_2() const { return ___key_2; }
	inline KeyParameter_t215653120 ** get_address_of_key_2() { return &___key_2; }
	inline void set_key_2(KeyParameter_t215653120 * value)
	{
		___key_2 = value;
		Il2CppCodeGenWriteBarrier(&___key_2, value);
	}

	inline static int32_t get_offset_of_macSize_3() { return static_cast<int32_t>(offsetof(AeadParameters_t2995549197, ___macSize_3)); }
	inline int32_t get_macSize_3() const { return ___macSize_3; }
	inline int32_t* get_address_of_macSize_3() { return &___macSize_3; }
	inline void set_macSize_3(int32_t value)
	{
		___macSize_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
