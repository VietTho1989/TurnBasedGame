#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_Defa1499842933.h"

// System.Uri
struct Uri_t19570940;
// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer
struct ICertificateVerifyer_t565084154;
// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider
struct IClientCredentialsProvider_t3199932449;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.LegacyTlsClient
struct  LegacyTlsClient_t1589283767  : public DefaultTlsClient_t1499842933
{
public:
	// System.Uri Org.BouncyCastle.Crypto.Tls.LegacyTlsClient::TargetUri
	Uri_t19570940 * ___TargetUri_9;
	// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer Org.BouncyCastle.Crypto.Tls.LegacyTlsClient::verifyer
	Il2CppObject * ___verifyer_10;
	// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider Org.BouncyCastle.Crypto.Tls.LegacyTlsClient::credProvider
	Il2CppObject * ___credProvider_11;

public:
	inline static int32_t get_offset_of_TargetUri_9() { return static_cast<int32_t>(offsetof(LegacyTlsClient_t1589283767, ___TargetUri_9)); }
	inline Uri_t19570940 * get_TargetUri_9() const { return ___TargetUri_9; }
	inline Uri_t19570940 ** get_address_of_TargetUri_9() { return &___TargetUri_9; }
	inline void set_TargetUri_9(Uri_t19570940 * value)
	{
		___TargetUri_9 = value;
		Il2CppCodeGenWriteBarrier(&___TargetUri_9, value);
	}

	inline static int32_t get_offset_of_verifyer_10() { return static_cast<int32_t>(offsetof(LegacyTlsClient_t1589283767, ___verifyer_10)); }
	inline Il2CppObject * get_verifyer_10() const { return ___verifyer_10; }
	inline Il2CppObject ** get_address_of_verifyer_10() { return &___verifyer_10; }
	inline void set_verifyer_10(Il2CppObject * value)
	{
		___verifyer_10 = value;
		Il2CppCodeGenWriteBarrier(&___verifyer_10, value);
	}

	inline static int32_t get_offset_of_credProvider_11() { return static_cast<int32_t>(offsetof(LegacyTlsClient_t1589283767, ___credProvider_11)); }
	inline Il2CppObject * get_credProvider_11() const { return ___credProvider_11; }
	inline Il2CppObject ** get_address_of_credProvider_11() { return &___credProvider_11; }
	inline void set_credProvider_11(Il2CppObject * value)
	{
		___credProvider_11 = value;
		Il2CppCodeGenWriteBarrier(&___credProvider_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
