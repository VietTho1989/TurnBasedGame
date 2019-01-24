#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.Tls.Certificate
struct Certificate_t2775016569;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.SessionParameters
struct  SessionParameters_t833892266  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Tls.SessionParameters::mCipherSuite
	int32_t ___mCipherSuite_0;
	// System.Byte Org.BouncyCastle.Crypto.Tls.SessionParameters::mCompressionAlgorithm
	uint8_t ___mCompressionAlgorithm_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SessionParameters::mMasterSecret
	ByteU5BU5D_t3397334013* ___mMasterSecret_2;
	// Org.BouncyCastle.Crypto.Tls.Certificate Org.BouncyCastle.Crypto.Tls.SessionParameters::mPeerCertificate
	Certificate_t2775016569 * ___mPeerCertificate_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SessionParameters::mPskIdentity
	ByteU5BU5D_t3397334013* ___mPskIdentity_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SessionParameters::mSrpIdentity
	ByteU5BU5D_t3397334013* ___mSrpIdentity_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SessionParameters::mEncodedServerExtensions
	ByteU5BU5D_t3397334013* ___mEncodedServerExtensions_6;

public:
	inline static int32_t get_offset_of_mCipherSuite_0() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mCipherSuite_0)); }
	inline int32_t get_mCipherSuite_0() const { return ___mCipherSuite_0; }
	inline int32_t* get_address_of_mCipherSuite_0() { return &___mCipherSuite_0; }
	inline void set_mCipherSuite_0(int32_t value)
	{
		___mCipherSuite_0 = value;
	}

	inline static int32_t get_offset_of_mCompressionAlgorithm_1() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mCompressionAlgorithm_1)); }
	inline uint8_t get_mCompressionAlgorithm_1() const { return ___mCompressionAlgorithm_1; }
	inline uint8_t* get_address_of_mCompressionAlgorithm_1() { return &___mCompressionAlgorithm_1; }
	inline void set_mCompressionAlgorithm_1(uint8_t value)
	{
		___mCompressionAlgorithm_1 = value;
	}

	inline static int32_t get_offset_of_mMasterSecret_2() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mMasterSecret_2)); }
	inline ByteU5BU5D_t3397334013* get_mMasterSecret_2() const { return ___mMasterSecret_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_mMasterSecret_2() { return &___mMasterSecret_2; }
	inline void set_mMasterSecret_2(ByteU5BU5D_t3397334013* value)
	{
		___mMasterSecret_2 = value;
		Il2CppCodeGenWriteBarrier(&___mMasterSecret_2, value);
	}

	inline static int32_t get_offset_of_mPeerCertificate_3() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mPeerCertificate_3)); }
	inline Certificate_t2775016569 * get_mPeerCertificate_3() const { return ___mPeerCertificate_3; }
	inline Certificate_t2775016569 ** get_address_of_mPeerCertificate_3() { return &___mPeerCertificate_3; }
	inline void set_mPeerCertificate_3(Certificate_t2775016569 * value)
	{
		___mPeerCertificate_3 = value;
		Il2CppCodeGenWriteBarrier(&___mPeerCertificate_3, value);
	}

	inline static int32_t get_offset_of_mPskIdentity_4() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mPskIdentity_4)); }
	inline ByteU5BU5D_t3397334013* get_mPskIdentity_4() const { return ___mPskIdentity_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_mPskIdentity_4() { return &___mPskIdentity_4; }
	inline void set_mPskIdentity_4(ByteU5BU5D_t3397334013* value)
	{
		___mPskIdentity_4 = value;
		Il2CppCodeGenWriteBarrier(&___mPskIdentity_4, value);
	}

	inline static int32_t get_offset_of_mSrpIdentity_5() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mSrpIdentity_5)); }
	inline ByteU5BU5D_t3397334013* get_mSrpIdentity_5() const { return ___mSrpIdentity_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_mSrpIdentity_5() { return &___mSrpIdentity_5; }
	inline void set_mSrpIdentity_5(ByteU5BU5D_t3397334013* value)
	{
		___mSrpIdentity_5 = value;
		Il2CppCodeGenWriteBarrier(&___mSrpIdentity_5, value);
	}

	inline static int32_t get_offset_of_mEncodedServerExtensions_6() { return static_cast<int32_t>(offsetof(SessionParameters_t833892266, ___mEncodedServerExtensions_6)); }
	inline ByteU5BU5D_t3397334013* get_mEncodedServerExtensions_6() const { return ___mEncodedServerExtensions_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_mEncodedServerExtensions_6() { return &___mEncodedServerExtensions_6; }
	inline void set_mEncodedServerExtensions_6(ByteU5BU5D_t3397334013* value)
	{
		___mEncodedServerExtensions_6 = value;
		Il2CppCodeGenWriteBarrier(&___mEncodedServerExtensions_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
