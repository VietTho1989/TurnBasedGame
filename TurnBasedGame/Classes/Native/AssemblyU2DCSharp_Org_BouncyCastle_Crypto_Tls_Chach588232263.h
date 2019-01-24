#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.TlsContext
struct TlsContext_t4077776538;
// Org.BouncyCastle.Crypto.Engines.ChaChaEngine
struct ChaChaEngine_t2060435280;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.Chacha20Poly1305
struct  Chacha20Poly1305_t588232263  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.Chacha20Poly1305::context
	Il2CppObject * ___context_0;
	// Org.BouncyCastle.Crypto.Engines.ChaChaEngine Org.BouncyCastle.Crypto.Tls.Chacha20Poly1305::encryptCipher
	ChaChaEngine_t2060435280 * ___encryptCipher_1;
	// Org.BouncyCastle.Crypto.Engines.ChaChaEngine Org.BouncyCastle.Crypto.Tls.Chacha20Poly1305::decryptCipher
	ChaChaEngine_t2060435280 * ___decryptCipher_2;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(Chacha20Poly1305_t588232263, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_encryptCipher_1() { return static_cast<int32_t>(offsetof(Chacha20Poly1305_t588232263, ___encryptCipher_1)); }
	inline ChaChaEngine_t2060435280 * get_encryptCipher_1() const { return ___encryptCipher_1; }
	inline ChaChaEngine_t2060435280 ** get_address_of_encryptCipher_1() { return &___encryptCipher_1; }
	inline void set_encryptCipher_1(ChaChaEngine_t2060435280 * value)
	{
		___encryptCipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___encryptCipher_1, value);
	}

	inline static int32_t get_offset_of_decryptCipher_2() { return static_cast<int32_t>(offsetof(Chacha20Poly1305_t588232263, ___decryptCipher_2)); }
	inline ChaChaEngine_t2060435280 * get_decryptCipher_2() const { return ___decryptCipher_2; }
	inline ChaChaEngine_t2060435280 ** get_address_of_decryptCipher_2() { return &___decryptCipher_2; }
	inline void set_decryptCipher_2(ChaChaEngine_t2060435280 * value)
	{
		___decryptCipher_2 = value;
		Il2CppCodeGenWriteBarrier(&___decryptCipher_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
