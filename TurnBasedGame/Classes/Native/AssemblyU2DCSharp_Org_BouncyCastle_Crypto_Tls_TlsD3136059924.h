#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_TlsDH169955883.h"

// Org.BouncyCastle.Crypto.Tls.TlsSignerCredentials
struct TlsSignerCredentials_t4070987595;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsDheKeyExchange
struct  TlsDheKeyExchange_t3136059924  : public TlsDHKeyExchange_t169955883
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsSignerCredentials Org.BouncyCastle.Crypto.Tls.TlsDheKeyExchange::mServerCredentials
	Il2CppObject * ___mServerCredentials_9;

public:
	inline static int32_t get_offset_of_mServerCredentials_9() { return static_cast<int32_t>(offsetof(TlsDheKeyExchange_t3136059924, ___mServerCredentials_9)); }
	inline Il2CppObject * get_mServerCredentials_9() const { return ___mServerCredentials_9; }
	inline Il2CppObject ** get_address_of_mServerCredentials_9() { return &___mServerCredentials_9; }
	inline void set_mServerCredentials_9(Il2CppObject * value)
	{
		___mServerCredentials_9 = value;
		Il2CppCodeGenWriteBarrier(&___mServerCredentials_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
