#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_TlsP2348540693.h"

// Org.BouncyCastle.Crypto.Tls.TlsClient
struct TlsClient_t1962488424;
// Org.BouncyCastle.Crypto.Tls.TlsClientContextImpl
struct TlsClientContextImpl_t2876508357;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.Tls.TlsKeyExchange
struct TlsKeyExchange_t520409047;
// Org.BouncyCastle.Crypto.Tls.TlsAuthentication
struct TlsAuthentication_t69036015;
// Org.BouncyCastle.Crypto.Tls.CertificateStatus
struct CertificateStatus_t1829945713;
// Org.BouncyCastle.Crypto.Tls.CertificateRequest
struct CertificateRequest_t4188827490;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsClientProtocol
struct  TlsClientProtocol_t400461164  : public TlsProtocol_t2348540693
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsClient Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mTlsClient
	Il2CppObject * ___mTlsClient_43;
	// Org.BouncyCastle.Crypto.Tls.TlsClientContextImpl Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mTlsClientContext
	TlsClientContextImpl_t2876508357 * ___mTlsClientContext_44;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mSelectedSessionID
	ByteU5BU5D_t3397334013* ___mSelectedSessionID_45;
	// Org.BouncyCastle.Crypto.Tls.TlsKeyExchange Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mKeyExchange
	Il2CppObject * ___mKeyExchange_46;
	// Org.BouncyCastle.Crypto.Tls.TlsAuthentication Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mAuthentication
	Il2CppObject * ___mAuthentication_47;
	// Org.BouncyCastle.Crypto.Tls.CertificateStatus Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mCertificateStatus
	CertificateStatus_t1829945713 * ___mCertificateStatus_48;
	// Org.BouncyCastle.Crypto.Tls.CertificateRequest Org.BouncyCastle.Crypto.Tls.TlsClientProtocol::mCertificateRequest
	CertificateRequest_t4188827490 * ___mCertificateRequest_49;

public:
	inline static int32_t get_offset_of_mTlsClient_43() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mTlsClient_43)); }
	inline Il2CppObject * get_mTlsClient_43() const { return ___mTlsClient_43; }
	inline Il2CppObject ** get_address_of_mTlsClient_43() { return &___mTlsClient_43; }
	inline void set_mTlsClient_43(Il2CppObject * value)
	{
		___mTlsClient_43 = value;
		Il2CppCodeGenWriteBarrier(&___mTlsClient_43, value);
	}

	inline static int32_t get_offset_of_mTlsClientContext_44() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mTlsClientContext_44)); }
	inline TlsClientContextImpl_t2876508357 * get_mTlsClientContext_44() const { return ___mTlsClientContext_44; }
	inline TlsClientContextImpl_t2876508357 ** get_address_of_mTlsClientContext_44() { return &___mTlsClientContext_44; }
	inline void set_mTlsClientContext_44(TlsClientContextImpl_t2876508357 * value)
	{
		___mTlsClientContext_44 = value;
		Il2CppCodeGenWriteBarrier(&___mTlsClientContext_44, value);
	}

	inline static int32_t get_offset_of_mSelectedSessionID_45() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mSelectedSessionID_45)); }
	inline ByteU5BU5D_t3397334013* get_mSelectedSessionID_45() const { return ___mSelectedSessionID_45; }
	inline ByteU5BU5D_t3397334013** get_address_of_mSelectedSessionID_45() { return &___mSelectedSessionID_45; }
	inline void set_mSelectedSessionID_45(ByteU5BU5D_t3397334013* value)
	{
		___mSelectedSessionID_45 = value;
		Il2CppCodeGenWriteBarrier(&___mSelectedSessionID_45, value);
	}

	inline static int32_t get_offset_of_mKeyExchange_46() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mKeyExchange_46)); }
	inline Il2CppObject * get_mKeyExchange_46() const { return ___mKeyExchange_46; }
	inline Il2CppObject ** get_address_of_mKeyExchange_46() { return &___mKeyExchange_46; }
	inline void set_mKeyExchange_46(Il2CppObject * value)
	{
		___mKeyExchange_46 = value;
		Il2CppCodeGenWriteBarrier(&___mKeyExchange_46, value);
	}

	inline static int32_t get_offset_of_mAuthentication_47() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mAuthentication_47)); }
	inline Il2CppObject * get_mAuthentication_47() const { return ___mAuthentication_47; }
	inline Il2CppObject ** get_address_of_mAuthentication_47() { return &___mAuthentication_47; }
	inline void set_mAuthentication_47(Il2CppObject * value)
	{
		___mAuthentication_47 = value;
		Il2CppCodeGenWriteBarrier(&___mAuthentication_47, value);
	}

	inline static int32_t get_offset_of_mCertificateStatus_48() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mCertificateStatus_48)); }
	inline CertificateStatus_t1829945713 * get_mCertificateStatus_48() const { return ___mCertificateStatus_48; }
	inline CertificateStatus_t1829945713 ** get_address_of_mCertificateStatus_48() { return &___mCertificateStatus_48; }
	inline void set_mCertificateStatus_48(CertificateStatus_t1829945713 * value)
	{
		___mCertificateStatus_48 = value;
		Il2CppCodeGenWriteBarrier(&___mCertificateStatus_48, value);
	}

	inline static int32_t get_offset_of_mCertificateRequest_49() { return static_cast<int32_t>(offsetof(TlsClientProtocol_t400461164, ___mCertificateRequest_49)); }
	inline CertificateRequest_t4188827490 * get_mCertificateRequest_49() const { return ___mCertificateRequest_49; }
	inline CertificateRequest_t4188827490 ** get_address_of_mCertificateRequest_49() { return &___mCertificateRequest_49; }
	inline void set_mCertificateRequest_49(CertificateRequest_t4188827490 * value)
	{
		___mCertificateRequest_49 = value;
		Il2CppCodeGenWriteBarrier(&___mCertificateRequest_49, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
