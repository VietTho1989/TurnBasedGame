#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Tls_Abst1629639237.h"

// Org.BouncyCastle.Crypto.Tls.TlsCipherFactory
struct TlsCipherFactory_t3073296058;
// Org.BouncyCastle.Crypto.Tls.TlsServerContext
struct TlsServerContext_t1771883469;
// Org.BouncyCastle.Crypto.Tls.ProtocolVersion
struct ProtocolVersion_t3273908466;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Collections.IDictionary
struct IDictionary_t596158605;
// System.Collections.IList
struct IList_t3321498491;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.AbstractTlsServer
struct  AbstractTlsServer_t3501337442  : public AbstractTlsPeer_t1629639237
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsCipherFactory Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mCipherFactory
	Il2CppObject * ___mCipherFactory_0;
	// Org.BouncyCastle.Crypto.Tls.TlsServerContext Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mContext
	Il2CppObject * ___mContext_1;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mClientVersion
	ProtocolVersion_t3273908466 * ___mClientVersion_2;
	// System.Int32[] Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mOfferedCipherSuites
	Int32U5BU5D_t3030399641* ___mOfferedCipherSuites_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mOfferedCompressionMethods
	ByteU5BU5D_t3397334013* ___mOfferedCompressionMethods_4;
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mClientExtensions
	Il2CppObject * ___mClientExtensions_5;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mEncryptThenMacOffered
	bool ___mEncryptThenMacOffered_6;
	// System.Int16 Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mMaxFragmentLengthOffered
	int16_t ___mMaxFragmentLengthOffered_7;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mTruncatedHMacOffered
	bool ___mTruncatedHMacOffered_8;
	// System.Collections.IList Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mSupportedSignatureAlgorithms
	Il2CppObject * ___mSupportedSignatureAlgorithms_9;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mEccCipherSuitesOffered
	bool ___mEccCipherSuitesOffered_10;
	// System.Int32[] Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mNamedCurves
	Int32U5BU5D_t3030399641* ___mNamedCurves_11;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mClientECPointFormats
	ByteU5BU5D_t3397334013* ___mClientECPointFormats_12;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mServerECPointFormats
	ByteU5BU5D_t3397334013* ___mServerECPointFormats_13;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mServerVersion
	ProtocolVersion_t3273908466 * ___mServerVersion_14;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mSelectedCipherSuite
	int32_t ___mSelectedCipherSuite_15;
	// System.Byte Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mSelectedCompressionMethod
	uint8_t ___mSelectedCompressionMethod_16;
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Tls.AbstractTlsServer::mServerExtensions
	Il2CppObject * ___mServerExtensions_17;

public:
	inline static int32_t get_offset_of_mCipherFactory_0() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mCipherFactory_0)); }
	inline Il2CppObject * get_mCipherFactory_0() const { return ___mCipherFactory_0; }
	inline Il2CppObject ** get_address_of_mCipherFactory_0() { return &___mCipherFactory_0; }
	inline void set_mCipherFactory_0(Il2CppObject * value)
	{
		___mCipherFactory_0 = value;
		Il2CppCodeGenWriteBarrier(&___mCipherFactory_0, value);
	}

	inline static int32_t get_offset_of_mContext_1() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mContext_1)); }
	inline Il2CppObject * get_mContext_1() const { return ___mContext_1; }
	inline Il2CppObject ** get_address_of_mContext_1() { return &___mContext_1; }
	inline void set_mContext_1(Il2CppObject * value)
	{
		___mContext_1 = value;
		Il2CppCodeGenWriteBarrier(&___mContext_1, value);
	}

	inline static int32_t get_offset_of_mClientVersion_2() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mClientVersion_2)); }
	inline ProtocolVersion_t3273908466 * get_mClientVersion_2() const { return ___mClientVersion_2; }
	inline ProtocolVersion_t3273908466 ** get_address_of_mClientVersion_2() { return &___mClientVersion_2; }
	inline void set_mClientVersion_2(ProtocolVersion_t3273908466 * value)
	{
		___mClientVersion_2 = value;
		Il2CppCodeGenWriteBarrier(&___mClientVersion_2, value);
	}

	inline static int32_t get_offset_of_mOfferedCipherSuites_3() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mOfferedCipherSuites_3)); }
	inline Int32U5BU5D_t3030399641* get_mOfferedCipherSuites_3() const { return ___mOfferedCipherSuites_3; }
	inline Int32U5BU5D_t3030399641** get_address_of_mOfferedCipherSuites_3() { return &___mOfferedCipherSuites_3; }
	inline void set_mOfferedCipherSuites_3(Int32U5BU5D_t3030399641* value)
	{
		___mOfferedCipherSuites_3 = value;
		Il2CppCodeGenWriteBarrier(&___mOfferedCipherSuites_3, value);
	}

	inline static int32_t get_offset_of_mOfferedCompressionMethods_4() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mOfferedCompressionMethods_4)); }
	inline ByteU5BU5D_t3397334013* get_mOfferedCompressionMethods_4() const { return ___mOfferedCompressionMethods_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_mOfferedCompressionMethods_4() { return &___mOfferedCompressionMethods_4; }
	inline void set_mOfferedCompressionMethods_4(ByteU5BU5D_t3397334013* value)
	{
		___mOfferedCompressionMethods_4 = value;
		Il2CppCodeGenWriteBarrier(&___mOfferedCompressionMethods_4, value);
	}

	inline static int32_t get_offset_of_mClientExtensions_5() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mClientExtensions_5)); }
	inline Il2CppObject * get_mClientExtensions_5() const { return ___mClientExtensions_5; }
	inline Il2CppObject ** get_address_of_mClientExtensions_5() { return &___mClientExtensions_5; }
	inline void set_mClientExtensions_5(Il2CppObject * value)
	{
		___mClientExtensions_5 = value;
		Il2CppCodeGenWriteBarrier(&___mClientExtensions_5, value);
	}

	inline static int32_t get_offset_of_mEncryptThenMacOffered_6() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mEncryptThenMacOffered_6)); }
	inline bool get_mEncryptThenMacOffered_6() const { return ___mEncryptThenMacOffered_6; }
	inline bool* get_address_of_mEncryptThenMacOffered_6() { return &___mEncryptThenMacOffered_6; }
	inline void set_mEncryptThenMacOffered_6(bool value)
	{
		___mEncryptThenMacOffered_6 = value;
	}

	inline static int32_t get_offset_of_mMaxFragmentLengthOffered_7() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mMaxFragmentLengthOffered_7)); }
	inline int16_t get_mMaxFragmentLengthOffered_7() const { return ___mMaxFragmentLengthOffered_7; }
	inline int16_t* get_address_of_mMaxFragmentLengthOffered_7() { return &___mMaxFragmentLengthOffered_7; }
	inline void set_mMaxFragmentLengthOffered_7(int16_t value)
	{
		___mMaxFragmentLengthOffered_7 = value;
	}

	inline static int32_t get_offset_of_mTruncatedHMacOffered_8() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mTruncatedHMacOffered_8)); }
	inline bool get_mTruncatedHMacOffered_8() const { return ___mTruncatedHMacOffered_8; }
	inline bool* get_address_of_mTruncatedHMacOffered_8() { return &___mTruncatedHMacOffered_8; }
	inline void set_mTruncatedHMacOffered_8(bool value)
	{
		___mTruncatedHMacOffered_8 = value;
	}

	inline static int32_t get_offset_of_mSupportedSignatureAlgorithms_9() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mSupportedSignatureAlgorithms_9)); }
	inline Il2CppObject * get_mSupportedSignatureAlgorithms_9() const { return ___mSupportedSignatureAlgorithms_9; }
	inline Il2CppObject ** get_address_of_mSupportedSignatureAlgorithms_9() { return &___mSupportedSignatureAlgorithms_9; }
	inline void set_mSupportedSignatureAlgorithms_9(Il2CppObject * value)
	{
		___mSupportedSignatureAlgorithms_9 = value;
		Il2CppCodeGenWriteBarrier(&___mSupportedSignatureAlgorithms_9, value);
	}

	inline static int32_t get_offset_of_mEccCipherSuitesOffered_10() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mEccCipherSuitesOffered_10)); }
	inline bool get_mEccCipherSuitesOffered_10() const { return ___mEccCipherSuitesOffered_10; }
	inline bool* get_address_of_mEccCipherSuitesOffered_10() { return &___mEccCipherSuitesOffered_10; }
	inline void set_mEccCipherSuitesOffered_10(bool value)
	{
		___mEccCipherSuitesOffered_10 = value;
	}

	inline static int32_t get_offset_of_mNamedCurves_11() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mNamedCurves_11)); }
	inline Int32U5BU5D_t3030399641* get_mNamedCurves_11() const { return ___mNamedCurves_11; }
	inline Int32U5BU5D_t3030399641** get_address_of_mNamedCurves_11() { return &___mNamedCurves_11; }
	inline void set_mNamedCurves_11(Int32U5BU5D_t3030399641* value)
	{
		___mNamedCurves_11 = value;
		Il2CppCodeGenWriteBarrier(&___mNamedCurves_11, value);
	}

	inline static int32_t get_offset_of_mClientECPointFormats_12() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mClientECPointFormats_12)); }
	inline ByteU5BU5D_t3397334013* get_mClientECPointFormats_12() const { return ___mClientECPointFormats_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_mClientECPointFormats_12() { return &___mClientECPointFormats_12; }
	inline void set_mClientECPointFormats_12(ByteU5BU5D_t3397334013* value)
	{
		___mClientECPointFormats_12 = value;
		Il2CppCodeGenWriteBarrier(&___mClientECPointFormats_12, value);
	}

	inline static int32_t get_offset_of_mServerECPointFormats_13() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mServerECPointFormats_13)); }
	inline ByteU5BU5D_t3397334013* get_mServerECPointFormats_13() const { return ___mServerECPointFormats_13; }
	inline ByteU5BU5D_t3397334013** get_address_of_mServerECPointFormats_13() { return &___mServerECPointFormats_13; }
	inline void set_mServerECPointFormats_13(ByteU5BU5D_t3397334013* value)
	{
		___mServerECPointFormats_13 = value;
		Il2CppCodeGenWriteBarrier(&___mServerECPointFormats_13, value);
	}

	inline static int32_t get_offset_of_mServerVersion_14() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mServerVersion_14)); }
	inline ProtocolVersion_t3273908466 * get_mServerVersion_14() const { return ___mServerVersion_14; }
	inline ProtocolVersion_t3273908466 ** get_address_of_mServerVersion_14() { return &___mServerVersion_14; }
	inline void set_mServerVersion_14(ProtocolVersion_t3273908466 * value)
	{
		___mServerVersion_14 = value;
		Il2CppCodeGenWriteBarrier(&___mServerVersion_14, value);
	}

	inline static int32_t get_offset_of_mSelectedCipherSuite_15() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mSelectedCipherSuite_15)); }
	inline int32_t get_mSelectedCipherSuite_15() const { return ___mSelectedCipherSuite_15; }
	inline int32_t* get_address_of_mSelectedCipherSuite_15() { return &___mSelectedCipherSuite_15; }
	inline void set_mSelectedCipherSuite_15(int32_t value)
	{
		___mSelectedCipherSuite_15 = value;
	}

	inline static int32_t get_offset_of_mSelectedCompressionMethod_16() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mSelectedCompressionMethod_16)); }
	inline uint8_t get_mSelectedCompressionMethod_16() const { return ___mSelectedCompressionMethod_16; }
	inline uint8_t* get_address_of_mSelectedCompressionMethod_16() { return &___mSelectedCompressionMethod_16; }
	inline void set_mSelectedCompressionMethod_16(uint8_t value)
	{
		___mSelectedCompressionMethod_16 = value;
	}

	inline static int32_t get_offset_of_mServerExtensions_17() { return static_cast<int32_t>(offsetof(AbstractTlsServer_t3501337442, ___mServerExtensions_17)); }
	inline Il2CppObject * get_mServerExtensions_17() const { return ___mServerExtensions_17; }
	inline Il2CppObject ** get_address_of_mServerExtensions_17() { return &___mServerExtensions_17; }
	inline void set_mServerExtensions_17(Il2CppObject * value)
	{
		___mServerExtensions_17 = value;
		Il2CppCodeGenWriteBarrier(&___mServerExtensions_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
