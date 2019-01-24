#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_TlsE3594646817.h"

// Org.BouncyCastle.Crypto.Tls.TlsSignerCredentials
struct TlsSignerCredentials_t4070987595;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsECDheKeyExchange
struct  TlsECDheKeyExchange_t1244283552  : public TlsECDHKeyExchange_t3594646817
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsSignerCredentials Org.BouncyCastle.Crypto.Tls.TlsECDheKeyExchange::mServerCredentials
	Il2CppObject * ___mServerCredentials_11;

public:
	inline static int32_t get_offset_of_mServerCredentials_11() { return static_cast<int32_t>(offsetof(TlsECDheKeyExchange_t1244283552, ___mServerCredentials_11)); }
	inline Il2CppObject * get_mServerCredentials_11() const { return ___mServerCredentials_11; }
	inline Il2CppObject ** get_address_of_mServerCredentials_11() { return &___mServerCredentials_11; }
	inline void set_mServerCredentials_11(Il2CppObject * value)
	{
		___mServerCredentials_11 = value;
		Il2CppCodeGenWriteBarrier(&___mServerCredentials_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
