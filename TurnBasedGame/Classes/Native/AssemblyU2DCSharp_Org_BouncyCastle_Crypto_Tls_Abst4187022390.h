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
// Org.BouncyCastle.Crypto.Tls.TlsClientContext
struct TlsClientContext_t2883849761;
// System.Collections.IList
struct IList_t3321498491;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.AbstractTlsClient
struct  AbstractTlsClient_t4187022390  : public AbstractTlsPeer_t1629639237
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsCipherFactory Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mCipherFactory
	Il2CppObject * ___mCipherFactory_0;
	// Org.BouncyCastle.Crypto.Tls.TlsClientContext Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mContext
	Il2CppObject * ___mContext_1;
	// System.Collections.IList Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mSupportedSignatureAlgorithms
	Il2CppObject * ___mSupportedSignatureAlgorithms_2;
	// System.Int32[] Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mNamedCurves
	Int32U5BU5D_t3030399641* ___mNamedCurves_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mClientECPointFormats
	ByteU5BU5D_t3397334013* ___mClientECPointFormats_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mServerECPointFormats
	ByteU5BU5D_t3397334013* ___mServerECPointFormats_5;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mSelectedCipherSuite
	int32_t ___mSelectedCipherSuite_6;
	// System.Int16 Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::mSelectedCompressionMethod
	int16_t ___mSelectedCompressionMethod_7;
	// System.Collections.Generic.List`1<System.String> Org.BouncyCastle.Crypto.Tls.AbstractTlsClient::<HostNames>k__BackingField
	List_1_t1398341365 * ___U3CHostNamesU3Ek__BackingField_8;

public:
	inline static int32_t get_offset_of_mCipherFactory_0() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mCipherFactory_0)); }
	inline Il2CppObject * get_mCipherFactory_0() const { return ___mCipherFactory_0; }
	inline Il2CppObject ** get_address_of_mCipherFactory_0() { return &___mCipherFactory_0; }
	inline void set_mCipherFactory_0(Il2CppObject * value)
	{
		___mCipherFactory_0 = value;
		Il2CppCodeGenWriteBarrier(&___mCipherFactory_0, value);
	}

	inline static int32_t get_offset_of_mContext_1() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mContext_1)); }
	inline Il2CppObject * get_mContext_1() const { return ___mContext_1; }
	inline Il2CppObject ** get_address_of_mContext_1() { return &___mContext_1; }
	inline void set_mContext_1(Il2CppObject * value)
	{
		___mContext_1 = value;
		Il2CppCodeGenWriteBarrier(&___mContext_1, value);
	}

	inline static int32_t get_offset_of_mSupportedSignatureAlgorithms_2() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mSupportedSignatureAlgorithms_2)); }
	inline Il2CppObject * get_mSupportedSignatureAlgorithms_2() const { return ___mSupportedSignatureAlgorithms_2; }
	inline Il2CppObject ** get_address_of_mSupportedSignatureAlgorithms_2() { return &___mSupportedSignatureAlgorithms_2; }
	inline void set_mSupportedSignatureAlgorithms_2(Il2CppObject * value)
	{
		___mSupportedSignatureAlgorithms_2 = value;
		Il2CppCodeGenWriteBarrier(&___mSupportedSignatureAlgorithms_2, value);
	}

	inline static int32_t get_offset_of_mNamedCurves_3() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mNamedCurves_3)); }
	inline Int32U5BU5D_t3030399641* get_mNamedCurves_3() const { return ___mNamedCurves_3; }
	inline Int32U5BU5D_t3030399641** get_address_of_mNamedCurves_3() { return &___mNamedCurves_3; }
	inline void set_mNamedCurves_3(Int32U5BU5D_t3030399641* value)
	{
		___mNamedCurves_3 = value;
		Il2CppCodeGenWriteBarrier(&___mNamedCurves_3, value);
	}

	inline static int32_t get_offset_of_mClientECPointFormats_4() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mClientECPointFormats_4)); }
	inline ByteU5BU5D_t3397334013* get_mClientECPointFormats_4() const { return ___mClientECPointFormats_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_mClientECPointFormats_4() { return &___mClientECPointFormats_4; }
	inline void set_mClientECPointFormats_4(ByteU5BU5D_t3397334013* value)
	{
		___mClientECPointFormats_4 = value;
		Il2CppCodeGenWriteBarrier(&___mClientECPointFormats_4, value);
	}

	inline static int32_t get_offset_of_mServerECPointFormats_5() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mServerECPointFormats_5)); }
	inline ByteU5BU5D_t3397334013* get_mServerECPointFormats_5() const { return ___mServerECPointFormats_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_mServerECPointFormats_5() { return &___mServerECPointFormats_5; }
	inline void set_mServerECPointFormats_5(ByteU5BU5D_t3397334013* value)
	{
		___mServerECPointFormats_5 = value;
		Il2CppCodeGenWriteBarrier(&___mServerECPointFormats_5, value);
	}

	inline static int32_t get_offset_of_mSelectedCipherSuite_6() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mSelectedCipherSuite_6)); }
	inline int32_t get_mSelectedCipherSuite_6() const { return ___mSelectedCipherSuite_6; }
	inline int32_t* get_address_of_mSelectedCipherSuite_6() { return &___mSelectedCipherSuite_6; }
	inline void set_mSelectedCipherSuite_6(int32_t value)
	{
		___mSelectedCipherSuite_6 = value;
	}

	inline static int32_t get_offset_of_mSelectedCompressionMethod_7() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___mSelectedCompressionMethod_7)); }
	inline int16_t get_mSelectedCompressionMethod_7() const { return ___mSelectedCompressionMethod_7; }
	inline int16_t* get_address_of_mSelectedCompressionMethod_7() { return &___mSelectedCompressionMethod_7; }
	inline void set_mSelectedCompressionMethod_7(int16_t value)
	{
		___mSelectedCompressionMethod_7 = value;
	}

	inline static int32_t get_offset_of_U3CHostNamesU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(AbstractTlsClient_t4187022390, ___U3CHostNamesU3Ek__BackingField_8)); }
	inline List_1_t1398341365 * get_U3CHostNamesU3Ek__BackingField_8() const { return ___U3CHostNamesU3Ek__BackingField_8; }
	inline List_1_t1398341365 ** get_address_of_U3CHostNamesU3Ek__BackingField_8() { return &___U3CHostNamesU3Ek__BackingField_8; }
	inline void set_U3CHostNamesU3Ek__BackingField_8(List_1_t1398341365 * value)
	{
		___U3CHostNamesU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHostNamesU3Ek__BackingField_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
