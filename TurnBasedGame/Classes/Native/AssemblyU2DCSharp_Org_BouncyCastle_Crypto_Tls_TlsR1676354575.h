#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_Abst3351798479.h"

// Org.BouncyCastle.Crypto.AsymmetricKeyParameter
struct AsymmetricKeyParameter_t1663727050;
// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
struct RsaKeyParameters_t3425534311;
// Org.BouncyCastle.Crypto.Tls.TlsEncryptionCredentials
struct TlsEncryptionCredentials_t801580;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsRsaKeyExchange
struct  TlsRsaKeyExchange_t1676354575  : public AbstractTlsKeyExchange_t3351798479
{
public:
	// Org.BouncyCastle.Crypto.AsymmetricKeyParameter Org.BouncyCastle.Crypto.Tls.TlsRsaKeyExchange::mServerPublicKey
	AsymmetricKeyParameter_t1663727050 * ___mServerPublicKey_3;
	// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters Org.BouncyCastle.Crypto.Tls.TlsRsaKeyExchange::mRsaServerPublicKey
	RsaKeyParameters_t3425534311 * ___mRsaServerPublicKey_4;
	// Org.BouncyCastle.Crypto.Tls.TlsEncryptionCredentials Org.BouncyCastle.Crypto.Tls.TlsRsaKeyExchange::mServerCredentials
	Il2CppObject * ___mServerCredentials_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsRsaKeyExchange::mPremasterSecret
	ByteU5BU5D_t3397334013* ___mPremasterSecret_6;

public:
	inline static int32_t get_offset_of_mServerPublicKey_3() { return static_cast<int32_t>(offsetof(TlsRsaKeyExchange_t1676354575, ___mServerPublicKey_3)); }
	inline AsymmetricKeyParameter_t1663727050 * get_mServerPublicKey_3() const { return ___mServerPublicKey_3; }
	inline AsymmetricKeyParameter_t1663727050 ** get_address_of_mServerPublicKey_3() { return &___mServerPublicKey_3; }
	inline void set_mServerPublicKey_3(AsymmetricKeyParameter_t1663727050 * value)
	{
		___mServerPublicKey_3 = value;
		Il2CppCodeGenWriteBarrier(&___mServerPublicKey_3, value);
	}

	inline static int32_t get_offset_of_mRsaServerPublicKey_4() { return static_cast<int32_t>(offsetof(TlsRsaKeyExchange_t1676354575, ___mRsaServerPublicKey_4)); }
	inline RsaKeyParameters_t3425534311 * get_mRsaServerPublicKey_4() const { return ___mRsaServerPublicKey_4; }
	inline RsaKeyParameters_t3425534311 ** get_address_of_mRsaServerPublicKey_4() { return &___mRsaServerPublicKey_4; }
	inline void set_mRsaServerPublicKey_4(RsaKeyParameters_t3425534311 * value)
	{
		___mRsaServerPublicKey_4 = value;
		Il2CppCodeGenWriteBarrier(&___mRsaServerPublicKey_4, value);
	}

	inline static int32_t get_offset_of_mServerCredentials_5() { return static_cast<int32_t>(offsetof(TlsRsaKeyExchange_t1676354575, ___mServerCredentials_5)); }
	inline Il2CppObject * get_mServerCredentials_5() const { return ___mServerCredentials_5; }
	inline Il2CppObject ** get_address_of_mServerCredentials_5() { return &___mServerCredentials_5; }
	inline void set_mServerCredentials_5(Il2CppObject * value)
	{
		___mServerCredentials_5 = value;
		Il2CppCodeGenWriteBarrier(&___mServerCredentials_5, value);
	}

	inline static int32_t get_offset_of_mPremasterSecret_6() { return static_cast<int32_t>(offsetof(TlsRsaKeyExchange_t1676354575, ___mPremasterSecret_6)); }
	inline ByteU5BU5D_t3397334013* get_mPremasterSecret_6() const { return ___mPremasterSecret_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_mPremasterSecret_6() { return &___mPremasterSecret_6; }
	inline void set_mPremasterSecret_6(ByteU5BU5D_t3397334013* value)
	{
		___mPremasterSecret_6 = value;
		Il2CppCodeGenWriteBarrier(&___mPremasterSecret_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
