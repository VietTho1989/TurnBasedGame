#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.SignatureAndHashAlgorithm
struct SignatureAndHashAlgorithm_t3350051566;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.DigitallySigned
struct  DigitallySigned_t2312486481  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.SignatureAndHashAlgorithm Org.BouncyCastle.Crypto.Tls.DigitallySigned::mAlgorithm
	SignatureAndHashAlgorithm_t3350051566 * ___mAlgorithm_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.DigitallySigned::mSignature
	ByteU5BU5D_t3397334013* ___mSignature_1;

public:
	inline static int32_t get_offset_of_mAlgorithm_0() { return static_cast<int32_t>(offsetof(DigitallySigned_t2312486481, ___mAlgorithm_0)); }
	inline SignatureAndHashAlgorithm_t3350051566 * get_mAlgorithm_0() const { return ___mAlgorithm_0; }
	inline SignatureAndHashAlgorithm_t3350051566 ** get_address_of_mAlgorithm_0() { return &___mAlgorithm_0; }
	inline void set_mAlgorithm_0(SignatureAndHashAlgorithm_t3350051566 * value)
	{
		___mAlgorithm_0 = value;
		Il2CppCodeGenWriteBarrier(&___mAlgorithm_0, value);
	}

	inline static int32_t get_offset_of_mSignature_1() { return static_cast<int32_t>(offsetof(DigitallySigned_t2312486481, ___mSignature_1)); }
	inline ByteU5BU5D_t3397334013* get_mSignature_1() const { return ___mSignature_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_mSignature_1() { return &___mSignature_1; }
	inline void set_mSignature_1(ByteU5BU5D_t3397334013* value)
	{
		___mSignature_1 = value;
		Il2CppCodeGenWriteBarrier(&___mSignature_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
