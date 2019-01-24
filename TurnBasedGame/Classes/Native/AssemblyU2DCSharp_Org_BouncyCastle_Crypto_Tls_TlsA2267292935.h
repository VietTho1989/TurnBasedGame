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
// Org.BouncyCastle.Crypto.Modes.IAeadBlockCipher
struct IAeadBlockCipher_t2629578910;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsAeadCipher
struct  TlsAeadCipher_t2267292935  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::context
	Il2CppObject * ___context_0;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::macSize
	int32_t ___macSize_1;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::nonce_explicit_length
	int32_t ___nonce_explicit_length_2;
	// Org.BouncyCastle.Crypto.Modes.IAeadBlockCipher Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::encryptCipher
	Il2CppObject * ___encryptCipher_3;
	// Org.BouncyCastle.Crypto.Modes.IAeadBlockCipher Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::decryptCipher
	Il2CppObject * ___decryptCipher_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::encryptImplicitNonce
	ByteU5BU5D_t3397334013* ___encryptImplicitNonce_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsAeadCipher::decryptImplicitNonce
	ByteU5BU5D_t3397334013* ___decryptImplicitNonce_6;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_macSize_1() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___macSize_1)); }
	inline int32_t get_macSize_1() const { return ___macSize_1; }
	inline int32_t* get_address_of_macSize_1() { return &___macSize_1; }
	inline void set_macSize_1(int32_t value)
	{
		___macSize_1 = value;
	}

	inline static int32_t get_offset_of_nonce_explicit_length_2() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___nonce_explicit_length_2)); }
	inline int32_t get_nonce_explicit_length_2() const { return ___nonce_explicit_length_2; }
	inline int32_t* get_address_of_nonce_explicit_length_2() { return &___nonce_explicit_length_2; }
	inline void set_nonce_explicit_length_2(int32_t value)
	{
		___nonce_explicit_length_2 = value;
	}

	inline static int32_t get_offset_of_encryptCipher_3() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___encryptCipher_3)); }
	inline Il2CppObject * get_encryptCipher_3() const { return ___encryptCipher_3; }
	inline Il2CppObject ** get_address_of_encryptCipher_3() { return &___encryptCipher_3; }
	inline void set_encryptCipher_3(Il2CppObject * value)
	{
		___encryptCipher_3 = value;
		Il2CppCodeGenWriteBarrier(&___encryptCipher_3, value);
	}

	inline static int32_t get_offset_of_decryptCipher_4() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___decryptCipher_4)); }
	inline Il2CppObject * get_decryptCipher_4() const { return ___decryptCipher_4; }
	inline Il2CppObject ** get_address_of_decryptCipher_4() { return &___decryptCipher_4; }
	inline void set_decryptCipher_4(Il2CppObject * value)
	{
		___decryptCipher_4 = value;
		Il2CppCodeGenWriteBarrier(&___decryptCipher_4, value);
	}

	inline static int32_t get_offset_of_encryptImplicitNonce_5() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___encryptImplicitNonce_5)); }
	inline ByteU5BU5D_t3397334013* get_encryptImplicitNonce_5() const { return ___encryptImplicitNonce_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_encryptImplicitNonce_5() { return &___encryptImplicitNonce_5; }
	inline void set_encryptImplicitNonce_5(ByteU5BU5D_t3397334013* value)
	{
		___encryptImplicitNonce_5 = value;
		Il2CppCodeGenWriteBarrier(&___encryptImplicitNonce_5, value);
	}

	inline static int32_t get_offset_of_decryptImplicitNonce_6() { return static_cast<int32_t>(offsetof(TlsAeadCipher_t2267292935, ___decryptImplicitNonce_6)); }
	inline ByteU5BU5D_t3397334013* get_decryptImplicitNonce_6() const { return ___decryptImplicitNonce_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_decryptImplicitNonce_6() { return &___decryptImplicitNonce_6; }
	inline void set_decryptImplicitNonce_6(ByteU5BU5D_t3397334013* value)
	{
		___decryptImplicitNonce_6 = value;
		Il2CppCodeGenWriteBarrier(&___decryptImplicitNonce_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
