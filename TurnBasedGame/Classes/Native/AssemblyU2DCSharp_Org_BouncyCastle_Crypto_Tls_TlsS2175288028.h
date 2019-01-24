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
// Org.BouncyCastle.Crypto.IStreamCipher
struct IStreamCipher_t1073853310;
// Org.BouncyCastle.Crypto.Tls.TlsMac
struct TlsMac_t4072537602;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsStreamCipher
struct  TlsStreamCipher_t2175288028  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.TlsStreamCipher::context
	Il2CppObject * ___context_0;
	// Org.BouncyCastle.Crypto.IStreamCipher Org.BouncyCastle.Crypto.Tls.TlsStreamCipher::encryptCipher
	Il2CppObject * ___encryptCipher_1;
	// Org.BouncyCastle.Crypto.IStreamCipher Org.BouncyCastle.Crypto.Tls.TlsStreamCipher::decryptCipher
	Il2CppObject * ___decryptCipher_2;
	// Org.BouncyCastle.Crypto.Tls.TlsMac Org.BouncyCastle.Crypto.Tls.TlsStreamCipher::writeMac
	TlsMac_t4072537602 * ___writeMac_3;
	// Org.BouncyCastle.Crypto.Tls.TlsMac Org.BouncyCastle.Crypto.Tls.TlsStreamCipher::readMac
	TlsMac_t4072537602 * ___readMac_4;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsStreamCipher::usesNonce
	bool ___usesNonce_5;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(TlsStreamCipher_t2175288028, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_encryptCipher_1() { return static_cast<int32_t>(offsetof(TlsStreamCipher_t2175288028, ___encryptCipher_1)); }
	inline Il2CppObject * get_encryptCipher_1() const { return ___encryptCipher_1; }
	inline Il2CppObject ** get_address_of_encryptCipher_1() { return &___encryptCipher_1; }
	inline void set_encryptCipher_1(Il2CppObject * value)
	{
		___encryptCipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___encryptCipher_1, value);
	}

	inline static int32_t get_offset_of_decryptCipher_2() { return static_cast<int32_t>(offsetof(TlsStreamCipher_t2175288028, ___decryptCipher_2)); }
	inline Il2CppObject * get_decryptCipher_2() const { return ___decryptCipher_2; }
	inline Il2CppObject ** get_address_of_decryptCipher_2() { return &___decryptCipher_2; }
	inline void set_decryptCipher_2(Il2CppObject * value)
	{
		___decryptCipher_2 = value;
		Il2CppCodeGenWriteBarrier(&___decryptCipher_2, value);
	}

	inline static int32_t get_offset_of_writeMac_3() { return static_cast<int32_t>(offsetof(TlsStreamCipher_t2175288028, ___writeMac_3)); }
	inline TlsMac_t4072537602 * get_writeMac_3() const { return ___writeMac_3; }
	inline TlsMac_t4072537602 ** get_address_of_writeMac_3() { return &___writeMac_3; }
	inline void set_writeMac_3(TlsMac_t4072537602 * value)
	{
		___writeMac_3 = value;
		Il2CppCodeGenWriteBarrier(&___writeMac_3, value);
	}

	inline static int32_t get_offset_of_readMac_4() { return static_cast<int32_t>(offsetof(TlsStreamCipher_t2175288028, ___readMac_4)); }
	inline TlsMac_t4072537602 * get_readMac_4() const { return ___readMac_4; }
	inline TlsMac_t4072537602 ** get_address_of_readMac_4() { return &___readMac_4; }
	inline void set_readMac_4(TlsMac_t4072537602 * value)
	{
		___readMac_4 = value;
		Il2CppCodeGenWriteBarrier(&___readMac_4, value);
	}

	inline static int32_t get_offset_of_usesNonce_5() { return static_cast<int32_t>(offsetof(TlsStreamCipher_t2175288028, ___usesNonce_5)); }
	inline bool get_usesNonce_5() const { return ___usesNonce_5; }
	inline bool* get_address_of_usesNonce_5() { return &___usesNonce_5; }
	inline void set_usesNonce_5(bool value)
	{
		___usesNonce_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
