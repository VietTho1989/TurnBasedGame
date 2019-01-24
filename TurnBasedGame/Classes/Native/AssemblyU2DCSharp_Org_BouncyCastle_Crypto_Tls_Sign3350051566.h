#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.SignatureAndHashAlgorithm
struct  SignatureAndHashAlgorithm_t3350051566  : public Il2CppObject
{
public:
	// System.Byte Org.BouncyCastle.Crypto.Tls.SignatureAndHashAlgorithm::mHash
	uint8_t ___mHash_0;
	// System.Byte Org.BouncyCastle.Crypto.Tls.SignatureAndHashAlgorithm::mSignature
	uint8_t ___mSignature_1;

public:
	inline static int32_t get_offset_of_mHash_0() { return static_cast<int32_t>(offsetof(SignatureAndHashAlgorithm_t3350051566, ___mHash_0)); }
	inline uint8_t get_mHash_0() const { return ___mHash_0; }
	inline uint8_t* get_address_of_mHash_0() { return &___mHash_0; }
	inline void set_mHash_0(uint8_t value)
	{
		___mHash_0 = value;
	}

	inline static int32_t get_offset_of_mSignature_1() { return static_cast<int32_t>(offsetof(SignatureAndHashAlgorithm_t3350051566, ___mSignature_1)); }
	inline uint8_t get_mSignature_1() const { return ___mSignature_1; }
	inline uint8_t* get_address_of_mSignature_1() { return &___mSignature_1; }
	inline void set_mSignature_1(uint8_t value)
	{
		___mSignature_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
