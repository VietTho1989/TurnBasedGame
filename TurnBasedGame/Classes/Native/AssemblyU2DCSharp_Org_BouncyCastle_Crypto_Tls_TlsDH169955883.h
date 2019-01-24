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
// Org.BouncyCastle.Crypto.Parameters.DHParameters
struct DHParameters_t431035336;
// Org.BouncyCastle.Crypto.AsymmetricKeyParameter
struct AsymmetricKeyParameter_t1663727050;
// Org.BouncyCastle.Crypto.Tls.TlsAgreementCredentials
struct TlsAgreementCredentials_t403536161;
// Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters
struct DHPrivateKeyParameters_t3120746414;
// Org.BouncyCastle.Crypto.Parameters.DHPublicKeyParameters
struct DHPublicKeyParameters_t1544976430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange
struct  TlsDHKeyExchange_t169955883  : public AbstractTlsKeyExchange_t3351798479
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsSigner Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange::mTlsSigner
	Il2CppObject * ___mTlsSigner_3;
	// Org.BouncyCastle.Crypto.Parameters.DHParameters Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange::mDHParameters
	DHParameters_t431035336 * ___mDHParameters_4;
	// Org.BouncyCastle.Crypto.AsymmetricKeyParameter Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange::mServerPublicKey
	AsymmetricKeyParameter_t1663727050 * ___mServerPublicKey_5;
	// Org.BouncyCastle.Crypto.Tls.TlsAgreementCredentials Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange::mAgreementCredentials
	Il2CppObject * ___mAgreementCredentials_6;
	// Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange::mDHAgreePrivateKey
	DHPrivateKeyParameters_t3120746414 * ___mDHAgreePrivateKey_7;
	// Org.BouncyCastle.Crypto.Parameters.DHPublicKeyParameters Org.BouncyCastle.Crypto.Tls.TlsDHKeyExchange::mDHAgreePublicKey
	DHPublicKeyParameters_t1544976430 * ___mDHAgreePublicKey_8;

public:
	inline static int32_t get_offset_of_mTlsSigner_3() { return static_cast<int32_t>(offsetof(TlsDHKeyExchange_t169955883, ___mTlsSigner_3)); }
	inline Il2CppObject * get_mTlsSigner_3() const { return ___mTlsSigner_3; }
	inline Il2CppObject ** get_address_of_mTlsSigner_3() { return &___mTlsSigner_3; }
	inline void set_mTlsSigner_3(Il2CppObject * value)
	{
		___mTlsSigner_3 = value;
		Il2CppCodeGenWriteBarrier(&___mTlsSigner_3, value);
	}

	inline static int32_t get_offset_of_mDHParameters_4() { return static_cast<int32_t>(offsetof(TlsDHKeyExchange_t169955883, ___mDHParameters_4)); }
	inline DHParameters_t431035336 * get_mDHParameters_4() const { return ___mDHParameters_4; }
	inline DHParameters_t431035336 ** get_address_of_mDHParameters_4() { return &___mDHParameters_4; }
	inline void set_mDHParameters_4(DHParameters_t431035336 * value)
	{
		___mDHParameters_4 = value;
		Il2CppCodeGenWriteBarrier(&___mDHParameters_4, value);
	}

	inline static int32_t get_offset_of_mServerPublicKey_5() { return static_cast<int32_t>(offsetof(TlsDHKeyExchange_t169955883, ___mServerPublicKey_5)); }
	inline AsymmetricKeyParameter_t1663727050 * get_mServerPublicKey_5() const { return ___mServerPublicKey_5; }
	inline AsymmetricKeyParameter_t1663727050 ** get_address_of_mServerPublicKey_5() { return &___mServerPublicKey_5; }
	inline void set_mServerPublicKey_5(AsymmetricKeyParameter_t1663727050 * value)
	{
		___mServerPublicKey_5 = value;
		Il2CppCodeGenWriteBarrier(&___mServerPublicKey_5, value);
	}

	inline static int32_t get_offset_of_mAgreementCredentials_6() { return static_cast<int32_t>(offsetof(TlsDHKeyExchange_t169955883, ___mAgreementCredentials_6)); }
	inline Il2CppObject * get_mAgreementCredentials_6() const { return ___mAgreementCredentials_6; }
	inline Il2CppObject ** get_address_of_mAgreementCredentials_6() { return &___mAgreementCredentials_6; }
	inline void set_mAgreementCredentials_6(Il2CppObject * value)
	{
		___mAgreementCredentials_6 = value;
		Il2CppCodeGenWriteBarrier(&___mAgreementCredentials_6, value);
	}

	inline static int32_t get_offset_of_mDHAgreePrivateKey_7() { return static_cast<int32_t>(offsetof(TlsDHKeyExchange_t169955883, ___mDHAgreePrivateKey_7)); }
	inline DHPrivateKeyParameters_t3120746414 * get_mDHAgreePrivateKey_7() const { return ___mDHAgreePrivateKey_7; }
	inline DHPrivateKeyParameters_t3120746414 ** get_address_of_mDHAgreePrivateKey_7() { return &___mDHAgreePrivateKey_7; }
	inline void set_mDHAgreePrivateKey_7(DHPrivateKeyParameters_t3120746414 * value)
	{
		___mDHAgreePrivateKey_7 = value;
		Il2CppCodeGenWriteBarrier(&___mDHAgreePrivateKey_7, value);
	}

	inline static int32_t get_offset_of_mDHAgreePublicKey_8() { return static_cast<int32_t>(offsetof(TlsDHKeyExchange_t169955883, ___mDHAgreePublicKey_8)); }
	inline DHPublicKeyParameters_t1544976430 * get_mDHAgreePublicKey_8() const { return ___mDHAgreePublicKey_8; }
	inline DHPublicKeyParameters_t1544976430 ** get_address_of_mDHAgreePublicKey_8() { return &___mDHAgreePublicKey_8; }
	inline void set_mDHAgreePublicKey_8(DHPublicKeyParameters_t1544976430 * value)
	{
		___mDHAgreePublicKey_8 = value;
		Il2CppCodeGenWriteBarrier(&___mDHAgreePublicKey_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
