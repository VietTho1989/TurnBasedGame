#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer
struct ICertificateVerifyer_t565084154;
// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider
struct IClientCredentialsProvider_t3199932449;
// System.Uri
struct Uri_t19570940;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.LegacyTlsAuthentication
struct  LegacyTlsAuthentication_t3599698926  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer Org.BouncyCastle.Crypto.Tls.LegacyTlsAuthentication::verifyer
	Il2CppObject * ___verifyer_0;
	// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider Org.BouncyCastle.Crypto.Tls.LegacyTlsAuthentication::credProvider
	Il2CppObject * ___credProvider_1;
	// System.Uri Org.BouncyCastle.Crypto.Tls.LegacyTlsAuthentication::TargetUri
	Uri_t19570940 * ___TargetUri_2;

public:
	inline static int32_t get_offset_of_verifyer_0() { return static_cast<int32_t>(offsetof(LegacyTlsAuthentication_t3599698926, ___verifyer_0)); }
	inline Il2CppObject * get_verifyer_0() const { return ___verifyer_0; }
	inline Il2CppObject ** get_address_of_verifyer_0() { return &___verifyer_0; }
	inline void set_verifyer_0(Il2CppObject * value)
	{
		___verifyer_0 = value;
		Il2CppCodeGenWriteBarrier(&___verifyer_0, value);
	}

	inline static int32_t get_offset_of_credProvider_1() { return static_cast<int32_t>(offsetof(LegacyTlsAuthentication_t3599698926, ___credProvider_1)); }
	inline Il2CppObject * get_credProvider_1() const { return ___credProvider_1; }
	inline Il2CppObject ** get_address_of_credProvider_1() { return &___credProvider_1; }
	inline void set_credProvider_1(Il2CppObject * value)
	{
		___credProvider_1 = value;
		Il2CppCodeGenWriteBarrier(&___credProvider_1, value);
	}

	inline static int32_t get_offset_of_TargetUri_2() { return static_cast<int32_t>(offsetof(LegacyTlsAuthentication_t3599698926, ___TargetUri_2)); }
	inline Uri_t19570940 * get_TargetUri_2() const { return ___TargetUri_2; }
	inline Uri_t19570940 ** get_address_of_TargetUri_2() { return &___TargetUri_2; }
	inline void set_TargetUri_2(Uri_t19570940 * value)
	{
		___TargetUri_2 = value;
		Il2CppCodeGenWriteBarrier(&___TargetUri_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
