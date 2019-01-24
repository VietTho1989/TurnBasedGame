#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_Abst3351798479.h"

// Org.BouncyCastle.Crypto.Tls.TlsSigner
struct TlsSigner_t3777082591;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.AsymmetricKeyParameter
struct AsymmetricKeyParameter_t1663727050;
// Org.BouncyCastle.Crypto.Tls.TlsAgreementCredentials
struct TlsAgreementCredentials_t403536161;
// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters
struct ECPrivateKeyParameters_t3632960452;
// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters
struct ECPublicKeyParameters_t572706344;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange
struct  TlsECDHKeyExchange_t3594646817  : public AbstractTlsKeyExchange_t3351798479
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsSigner Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mTlsSigner
	Il2CppObject * ___mTlsSigner_3;
	// System.Int32[] Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mNamedCurves
	Int32U5BU5D_t3030399641* ___mNamedCurves_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mClientECPointFormats
	ByteU5BU5D_t3397334013* ___mClientECPointFormats_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mServerECPointFormats
	ByteU5BU5D_t3397334013* ___mServerECPointFormats_6;
	// Org.BouncyCastle.Crypto.AsymmetricKeyParameter Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mServerPublicKey
	AsymmetricKeyParameter_t1663727050 * ___mServerPublicKey_7;
	// Org.BouncyCastle.Crypto.Tls.TlsAgreementCredentials Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mAgreementCredentials
	Il2CppObject * ___mAgreementCredentials_8;
	// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mECAgreePrivateKey
	ECPrivateKeyParameters_t3632960452 * ___mECAgreePrivateKey_9;
	// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters Org.BouncyCastle.Crypto.Tls.TlsECDHKeyExchange::mECAgreePublicKey
	ECPublicKeyParameters_t572706344 * ___mECAgreePublicKey_10;

public:
	inline static int32_t get_offset_of_mTlsSigner_3() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mTlsSigner_3)); }
	inline Il2CppObject * get_mTlsSigner_3() const { return ___mTlsSigner_3; }
	inline Il2CppObject ** get_address_of_mTlsSigner_3() { return &___mTlsSigner_3; }
	inline void set_mTlsSigner_3(Il2CppObject * value)
	{
		___mTlsSigner_3 = value;
		Il2CppCodeGenWriteBarrier(&___mTlsSigner_3, value);
	}

	inline static int32_t get_offset_of_mNamedCurves_4() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mNamedCurves_4)); }
	inline Int32U5BU5D_t3030399641* get_mNamedCurves_4() const { return ___mNamedCurves_4; }
	inline Int32U5BU5D_t3030399641** get_address_of_mNamedCurves_4() { return &___mNamedCurves_4; }
	inline void set_mNamedCurves_4(Int32U5BU5D_t3030399641* value)
	{
		___mNamedCurves_4 = value;
		Il2CppCodeGenWriteBarrier(&___mNamedCurves_4, value);
	}

	inline static int32_t get_offset_of_mClientECPointFormats_5() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mClientECPointFormats_5)); }
	inline ByteU5BU5D_t3397334013* get_mClientECPointFormats_5() const { return ___mClientECPointFormats_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_mClientECPointFormats_5() { return &___mClientECPointFormats_5; }
	inline void set_mClientECPointFormats_5(ByteU5BU5D_t3397334013* value)
	{
		___mClientECPointFormats_5 = value;
		Il2CppCodeGenWriteBarrier(&___mClientECPointFormats_5, value);
	}

	inline static int32_t get_offset_of_mServerECPointFormats_6() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mServerECPointFormats_6)); }
	inline ByteU5BU5D_t3397334013* get_mServerECPointFormats_6() const { return ___mServerECPointFormats_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_mServerECPointFormats_6() { return &___mServerECPointFormats_6; }
	inline void set_mServerECPointFormats_6(ByteU5BU5D_t3397334013* value)
	{
		___mServerECPointFormats_6 = value;
		Il2CppCodeGenWriteBarrier(&___mServerECPointFormats_6, value);
	}

	inline static int32_t get_offset_of_mServerPublicKey_7() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mServerPublicKey_7)); }
	inline AsymmetricKeyParameter_t1663727050 * get_mServerPublicKey_7() const { return ___mServerPublicKey_7; }
	inline AsymmetricKeyParameter_t1663727050 ** get_address_of_mServerPublicKey_7() { return &___mServerPublicKey_7; }
	inline void set_mServerPublicKey_7(AsymmetricKeyParameter_t1663727050 * value)
	{
		___mServerPublicKey_7 = value;
		Il2CppCodeGenWriteBarrier(&___mServerPublicKey_7, value);
	}

	inline static int32_t get_offset_of_mAgreementCredentials_8() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mAgreementCredentials_8)); }
	inline Il2CppObject * get_mAgreementCredentials_8() const { return ___mAgreementCredentials_8; }
	inline Il2CppObject ** get_address_of_mAgreementCredentials_8() { return &___mAgreementCredentials_8; }
	inline void set_mAgreementCredentials_8(Il2CppObject * value)
	{
		___mAgreementCredentials_8 = value;
		Il2CppCodeGenWriteBarrier(&___mAgreementCredentials_8, value);
	}

	inline static int32_t get_offset_of_mECAgreePrivateKey_9() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mECAgreePrivateKey_9)); }
	inline ECPrivateKeyParameters_t3632960452 * get_mECAgreePrivateKey_9() const { return ___mECAgreePrivateKey_9; }
	inline ECPrivateKeyParameters_t3632960452 ** get_address_of_mECAgreePrivateKey_9() { return &___mECAgreePrivateKey_9; }
	inline void set_mECAgreePrivateKey_9(ECPrivateKeyParameters_t3632960452 * value)
	{
		___mECAgreePrivateKey_9 = value;
		Il2CppCodeGenWriteBarrier(&___mECAgreePrivateKey_9, value);
	}

	inline static int32_t get_offset_of_mECAgreePublicKey_10() { return static_cast<int32_t>(offsetof(TlsECDHKeyExchange_t3594646817, ___mECAgreePublicKey_10)); }
	inline ECPublicKeyParameters_t572706344 * get_mECAgreePublicKey_10() const { return ___mECAgreePublicKey_10; }
	inline ECPublicKeyParameters_t572706344 ** get_address_of_mECAgreePublicKey_10() { return &___mECAgreePublicKey_10; }
	inline void set_mECAgreePublicKey_10(ECPublicKeyParameters_t572706344 * value)
	{
		___mECAgreePublicKey_10 = value;
		Il2CppCodeGenWriteBarrier(&___mECAgreePublicKey_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
