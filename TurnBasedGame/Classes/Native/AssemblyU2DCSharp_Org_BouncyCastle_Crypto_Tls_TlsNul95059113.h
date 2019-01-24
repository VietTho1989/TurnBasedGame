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
// Org.BouncyCastle.Crypto.Tls.TlsMac
struct TlsMac_t4072537602;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsNullCipher
struct  TlsNullCipher_t95059113  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.TlsNullCipher::context
	Il2CppObject * ___context_0;
	// Org.BouncyCastle.Crypto.Tls.TlsMac Org.BouncyCastle.Crypto.Tls.TlsNullCipher::writeMac
	TlsMac_t4072537602 * ___writeMac_1;
	// Org.BouncyCastle.Crypto.Tls.TlsMac Org.BouncyCastle.Crypto.Tls.TlsNullCipher::readMac
	TlsMac_t4072537602 * ___readMac_2;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(TlsNullCipher_t95059113, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_writeMac_1() { return static_cast<int32_t>(offsetof(TlsNullCipher_t95059113, ___writeMac_1)); }
	inline TlsMac_t4072537602 * get_writeMac_1() const { return ___writeMac_1; }
	inline TlsMac_t4072537602 ** get_address_of_writeMac_1() { return &___writeMac_1; }
	inline void set_writeMac_1(TlsMac_t4072537602 * value)
	{
		___writeMac_1 = value;
		Il2CppCodeGenWriteBarrier(&___writeMac_1, value);
	}

	inline static int32_t get_offset_of_readMac_2() { return static_cast<int32_t>(offsetof(TlsNullCipher_t95059113, ___readMac_2)); }
	inline TlsMac_t4072537602 * get_readMac_2() const { return ___readMac_2; }
	inline TlsMac_t4072537602 ** get_address_of_readMac_2() { return &___readMac_2; }
	inline void set_readMac_2(TlsMac_t4072537602 * value)
	{
		___readMac_2 = value;
		Il2CppCodeGenWriteBarrier(&___readMac_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
