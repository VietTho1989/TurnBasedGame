#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Boolean3825574718.h"

// System.String
struct String_t;
// Org.BouncyCastle.Crypto.Tls.ByteQueue
struct ByteQueue_t1600245655;
// Org.BouncyCastle.Crypto.Tls.RecordStream
struct RecordStream_t911577901;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;
// Org.BouncyCastle.Crypto.Tls.TlsStream
struct TlsStream_t477156699;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.Tls.TlsSession
struct TlsSession_t3695793821;
// Org.BouncyCastle.Crypto.Tls.SessionParameters
struct SessionParameters_t833892266;
// Org.BouncyCastle.Crypto.Tls.SecurityParameters
struct SecurityParameters_t3985528004;
// Org.BouncyCastle.Crypto.Tls.Certificate
struct Certificate_t2775016569;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Collections.IDictionary
struct IDictionary_t596158605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsProtocol
struct  TlsProtocol_t2348540693  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.ByteQueue Org.BouncyCastle.Crypto.Tls.TlsProtocol::mApplicationDataQueue
	ByteQueue_t1600245655 * ___mApplicationDataQueue_18;
	// Org.BouncyCastle.Crypto.Tls.ByteQueue Org.BouncyCastle.Crypto.Tls.TlsProtocol::mAlertQueue
	ByteQueue_t1600245655 * ___mAlertQueue_19;
	// Org.BouncyCastle.Crypto.Tls.ByteQueue Org.BouncyCastle.Crypto.Tls.TlsProtocol::mHandshakeQueue
	ByteQueue_t1600245655 * ___mHandshakeQueue_20;
	// Org.BouncyCastle.Crypto.Tls.RecordStream Org.BouncyCastle.Crypto.Tls.TlsProtocol::mRecordStream
	RecordStream_t911577901 * ___mRecordStream_21;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Tls.TlsProtocol::mSecureRandom
	SecureRandom_t3117234712 * ___mSecureRandom_22;
	// Org.BouncyCastle.Crypto.Tls.TlsStream Org.BouncyCastle.Crypto.Tls.TlsProtocol::mTlsStream
	TlsStream_t477156699 * ___mTlsStream_23;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Org.BouncyCastle.Crypto.Tls.TlsProtocol::mClosed
	bool ___mClosed_24;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Org.BouncyCastle.Crypto.Tls.TlsProtocol::mFailedWithError
	bool ___mFailedWithError_25;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Org.BouncyCastle.Crypto.Tls.TlsProtocol::mAppDataReady
	bool ___mAppDataReady_26;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Org.BouncyCastle.Crypto.Tls.TlsProtocol::mSplitApplicationDataRecords
	bool ___mSplitApplicationDataRecords_27;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsProtocol::mExpectedVerifyData
	ByteU5BU5D_t3397334013* ___mExpectedVerifyData_28;
	// Org.BouncyCastle.Crypto.Tls.TlsSession Org.BouncyCastle.Crypto.Tls.TlsProtocol::mTlsSession
	Il2CppObject * ___mTlsSession_29;
	// Org.BouncyCastle.Crypto.Tls.SessionParameters Org.BouncyCastle.Crypto.Tls.TlsProtocol::mSessionParameters
	SessionParameters_t833892266 * ___mSessionParameters_30;
	// Org.BouncyCastle.Crypto.Tls.SecurityParameters Org.BouncyCastle.Crypto.Tls.TlsProtocol::mSecurityParameters
	SecurityParameters_t3985528004 * ___mSecurityParameters_31;
	// Org.BouncyCastle.Crypto.Tls.Certificate Org.BouncyCastle.Crypto.Tls.TlsProtocol::mPeerCertificate
	Certificate_t2775016569 * ___mPeerCertificate_32;
	// System.Int32[] Org.BouncyCastle.Crypto.Tls.TlsProtocol::mOfferedCipherSuites
	Int32U5BU5D_t3030399641* ___mOfferedCipherSuites_33;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsProtocol::mOfferedCompressionMethods
	ByteU5BU5D_t3397334013* ___mOfferedCompressionMethods_34;
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Tls.TlsProtocol::mClientExtensions
	Il2CppObject * ___mClientExtensions_35;
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Tls.TlsProtocol::mServerExtensions
	Il2CppObject * ___mServerExtensions_36;
	// System.Int16 Org.BouncyCastle.Crypto.Tls.TlsProtocol::mConnectionState
	int16_t ___mConnectionState_37;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsProtocol::mResumedSession
	bool ___mResumedSession_38;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsProtocol::mReceivedChangeCipherSpec
	bool ___mReceivedChangeCipherSpec_39;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsProtocol::mSecureRenegotiation
	bool ___mSecureRenegotiation_40;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsProtocol::mAllowCertificateStatus
	bool ___mAllowCertificateStatus_41;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsProtocol::mExpectSessionTicket
	bool ___mExpectSessionTicket_42;

public:
	inline static int32_t get_offset_of_mApplicationDataQueue_18() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mApplicationDataQueue_18)); }
	inline ByteQueue_t1600245655 * get_mApplicationDataQueue_18() const { return ___mApplicationDataQueue_18; }
	inline ByteQueue_t1600245655 ** get_address_of_mApplicationDataQueue_18() { return &___mApplicationDataQueue_18; }
	inline void set_mApplicationDataQueue_18(ByteQueue_t1600245655 * value)
	{
		___mApplicationDataQueue_18 = value;
		Il2CppCodeGenWriteBarrier(&___mApplicationDataQueue_18, value);
	}

	inline static int32_t get_offset_of_mAlertQueue_19() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mAlertQueue_19)); }
	inline ByteQueue_t1600245655 * get_mAlertQueue_19() const { return ___mAlertQueue_19; }
	inline ByteQueue_t1600245655 ** get_address_of_mAlertQueue_19() { return &___mAlertQueue_19; }
	inline void set_mAlertQueue_19(ByteQueue_t1600245655 * value)
	{
		___mAlertQueue_19 = value;
		Il2CppCodeGenWriteBarrier(&___mAlertQueue_19, value);
	}

	inline static int32_t get_offset_of_mHandshakeQueue_20() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mHandshakeQueue_20)); }
	inline ByteQueue_t1600245655 * get_mHandshakeQueue_20() const { return ___mHandshakeQueue_20; }
	inline ByteQueue_t1600245655 ** get_address_of_mHandshakeQueue_20() { return &___mHandshakeQueue_20; }
	inline void set_mHandshakeQueue_20(ByteQueue_t1600245655 * value)
	{
		___mHandshakeQueue_20 = value;
		Il2CppCodeGenWriteBarrier(&___mHandshakeQueue_20, value);
	}

	inline static int32_t get_offset_of_mRecordStream_21() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mRecordStream_21)); }
	inline RecordStream_t911577901 * get_mRecordStream_21() const { return ___mRecordStream_21; }
	inline RecordStream_t911577901 ** get_address_of_mRecordStream_21() { return &___mRecordStream_21; }
	inline void set_mRecordStream_21(RecordStream_t911577901 * value)
	{
		___mRecordStream_21 = value;
		Il2CppCodeGenWriteBarrier(&___mRecordStream_21, value);
	}

	inline static int32_t get_offset_of_mSecureRandom_22() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mSecureRandom_22)); }
	inline SecureRandom_t3117234712 * get_mSecureRandom_22() const { return ___mSecureRandom_22; }
	inline SecureRandom_t3117234712 ** get_address_of_mSecureRandom_22() { return &___mSecureRandom_22; }
	inline void set_mSecureRandom_22(SecureRandom_t3117234712 * value)
	{
		___mSecureRandom_22 = value;
		Il2CppCodeGenWriteBarrier(&___mSecureRandom_22, value);
	}

	inline static int32_t get_offset_of_mTlsStream_23() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mTlsStream_23)); }
	inline TlsStream_t477156699 * get_mTlsStream_23() const { return ___mTlsStream_23; }
	inline TlsStream_t477156699 ** get_address_of_mTlsStream_23() { return &___mTlsStream_23; }
	inline void set_mTlsStream_23(TlsStream_t477156699 * value)
	{
		___mTlsStream_23 = value;
		Il2CppCodeGenWriteBarrier(&___mTlsStream_23, value);
	}

	inline static int32_t get_offset_of_mClosed_24() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mClosed_24)); }
	inline bool get_mClosed_24() const { return ___mClosed_24; }
	inline bool* get_address_of_mClosed_24() { return &___mClosed_24; }
	inline void set_mClosed_24(bool value)
	{
		___mClosed_24 = value;
	}

	inline static int32_t get_offset_of_mFailedWithError_25() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mFailedWithError_25)); }
	inline bool get_mFailedWithError_25() const { return ___mFailedWithError_25; }
	inline bool* get_address_of_mFailedWithError_25() { return &___mFailedWithError_25; }
	inline void set_mFailedWithError_25(bool value)
	{
		___mFailedWithError_25 = value;
	}

	inline static int32_t get_offset_of_mAppDataReady_26() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mAppDataReady_26)); }
	inline bool get_mAppDataReady_26() const { return ___mAppDataReady_26; }
	inline bool* get_address_of_mAppDataReady_26() { return &___mAppDataReady_26; }
	inline void set_mAppDataReady_26(bool value)
	{
		___mAppDataReady_26 = value;
	}

	inline static int32_t get_offset_of_mSplitApplicationDataRecords_27() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mSplitApplicationDataRecords_27)); }
	inline bool get_mSplitApplicationDataRecords_27() const { return ___mSplitApplicationDataRecords_27; }
	inline bool* get_address_of_mSplitApplicationDataRecords_27() { return &___mSplitApplicationDataRecords_27; }
	inline void set_mSplitApplicationDataRecords_27(bool value)
	{
		___mSplitApplicationDataRecords_27 = value;
	}

	inline static int32_t get_offset_of_mExpectedVerifyData_28() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mExpectedVerifyData_28)); }
	inline ByteU5BU5D_t3397334013* get_mExpectedVerifyData_28() const { return ___mExpectedVerifyData_28; }
	inline ByteU5BU5D_t3397334013** get_address_of_mExpectedVerifyData_28() { return &___mExpectedVerifyData_28; }
	inline void set_mExpectedVerifyData_28(ByteU5BU5D_t3397334013* value)
	{
		___mExpectedVerifyData_28 = value;
		Il2CppCodeGenWriteBarrier(&___mExpectedVerifyData_28, value);
	}

	inline static int32_t get_offset_of_mTlsSession_29() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mTlsSession_29)); }
	inline Il2CppObject * get_mTlsSession_29() const { return ___mTlsSession_29; }
	inline Il2CppObject ** get_address_of_mTlsSession_29() { return &___mTlsSession_29; }
	inline void set_mTlsSession_29(Il2CppObject * value)
	{
		___mTlsSession_29 = value;
		Il2CppCodeGenWriteBarrier(&___mTlsSession_29, value);
	}

	inline static int32_t get_offset_of_mSessionParameters_30() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mSessionParameters_30)); }
	inline SessionParameters_t833892266 * get_mSessionParameters_30() const { return ___mSessionParameters_30; }
	inline SessionParameters_t833892266 ** get_address_of_mSessionParameters_30() { return &___mSessionParameters_30; }
	inline void set_mSessionParameters_30(SessionParameters_t833892266 * value)
	{
		___mSessionParameters_30 = value;
		Il2CppCodeGenWriteBarrier(&___mSessionParameters_30, value);
	}

	inline static int32_t get_offset_of_mSecurityParameters_31() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mSecurityParameters_31)); }
	inline SecurityParameters_t3985528004 * get_mSecurityParameters_31() const { return ___mSecurityParameters_31; }
	inline SecurityParameters_t3985528004 ** get_address_of_mSecurityParameters_31() { return &___mSecurityParameters_31; }
	inline void set_mSecurityParameters_31(SecurityParameters_t3985528004 * value)
	{
		___mSecurityParameters_31 = value;
		Il2CppCodeGenWriteBarrier(&___mSecurityParameters_31, value);
	}

	inline static int32_t get_offset_of_mPeerCertificate_32() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mPeerCertificate_32)); }
	inline Certificate_t2775016569 * get_mPeerCertificate_32() const { return ___mPeerCertificate_32; }
	inline Certificate_t2775016569 ** get_address_of_mPeerCertificate_32() { return &___mPeerCertificate_32; }
	inline void set_mPeerCertificate_32(Certificate_t2775016569 * value)
	{
		___mPeerCertificate_32 = value;
		Il2CppCodeGenWriteBarrier(&___mPeerCertificate_32, value);
	}

	inline static int32_t get_offset_of_mOfferedCipherSuites_33() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mOfferedCipherSuites_33)); }
	inline Int32U5BU5D_t3030399641* get_mOfferedCipherSuites_33() const { return ___mOfferedCipherSuites_33; }
	inline Int32U5BU5D_t3030399641** get_address_of_mOfferedCipherSuites_33() { return &___mOfferedCipherSuites_33; }
	inline void set_mOfferedCipherSuites_33(Int32U5BU5D_t3030399641* value)
	{
		___mOfferedCipherSuites_33 = value;
		Il2CppCodeGenWriteBarrier(&___mOfferedCipherSuites_33, value);
	}

	inline static int32_t get_offset_of_mOfferedCompressionMethods_34() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mOfferedCompressionMethods_34)); }
	inline ByteU5BU5D_t3397334013* get_mOfferedCompressionMethods_34() const { return ___mOfferedCompressionMethods_34; }
	inline ByteU5BU5D_t3397334013** get_address_of_mOfferedCompressionMethods_34() { return &___mOfferedCompressionMethods_34; }
	inline void set_mOfferedCompressionMethods_34(ByteU5BU5D_t3397334013* value)
	{
		___mOfferedCompressionMethods_34 = value;
		Il2CppCodeGenWriteBarrier(&___mOfferedCompressionMethods_34, value);
	}

	inline static int32_t get_offset_of_mClientExtensions_35() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mClientExtensions_35)); }
	inline Il2CppObject * get_mClientExtensions_35() const { return ___mClientExtensions_35; }
	inline Il2CppObject ** get_address_of_mClientExtensions_35() { return &___mClientExtensions_35; }
	inline void set_mClientExtensions_35(Il2CppObject * value)
	{
		___mClientExtensions_35 = value;
		Il2CppCodeGenWriteBarrier(&___mClientExtensions_35, value);
	}

	inline static int32_t get_offset_of_mServerExtensions_36() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mServerExtensions_36)); }
	inline Il2CppObject * get_mServerExtensions_36() const { return ___mServerExtensions_36; }
	inline Il2CppObject ** get_address_of_mServerExtensions_36() { return &___mServerExtensions_36; }
	inline void set_mServerExtensions_36(Il2CppObject * value)
	{
		___mServerExtensions_36 = value;
		Il2CppCodeGenWriteBarrier(&___mServerExtensions_36, value);
	}

	inline static int32_t get_offset_of_mConnectionState_37() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mConnectionState_37)); }
	inline int16_t get_mConnectionState_37() const { return ___mConnectionState_37; }
	inline int16_t* get_address_of_mConnectionState_37() { return &___mConnectionState_37; }
	inline void set_mConnectionState_37(int16_t value)
	{
		___mConnectionState_37 = value;
	}

	inline static int32_t get_offset_of_mResumedSession_38() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mResumedSession_38)); }
	inline bool get_mResumedSession_38() const { return ___mResumedSession_38; }
	inline bool* get_address_of_mResumedSession_38() { return &___mResumedSession_38; }
	inline void set_mResumedSession_38(bool value)
	{
		___mResumedSession_38 = value;
	}

	inline static int32_t get_offset_of_mReceivedChangeCipherSpec_39() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mReceivedChangeCipherSpec_39)); }
	inline bool get_mReceivedChangeCipherSpec_39() const { return ___mReceivedChangeCipherSpec_39; }
	inline bool* get_address_of_mReceivedChangeCipherSpec_39() { return &___mReceivedChangeCipherSpec_39; }
	inline void set_mReceivedChangeCipherSpec_39(bool value)
	{
		___mReceivedChangeCipherSpec_39 = value;
	}

	inline static int32_t get_offset_of_mSecureRenegotiation_40() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mSecureRenegotiation_40)); }
	inline bool get_mSecureRenegotiation_40() const { return ___mSecureRenegotiation_40; }
	inline bool* get_address_of_mSecureRenegotiation_40() { return &___mSecureRenegotiation_40; }
	inline void set_mSecureRenegotiation_40(bool value)
	{
		___mSecureRenegotiation_40 = value;
	}

	inline static int32_t get_offset_of_mAllowCertificateStatus_41() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mAllowCertificateStatus_41)); }
	inline bool get_mAllowCertificateStatus_41() const { return ___mAllowCertificateStatus_41; }
	inline bool* get_address_of_mAllowCertificateStatus_41() { return &___mAllowCertificateStatus_41; }
	inline void set_mAllowCertificateStatus_41(bool value)
	{
		___mAllowCertificateStatus_41 = value;
	}

	inline static int32_t get_offset_of_mExpectSessionTicket_42() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693, ___mExpectSessionTicket_42)); }
	inline bool get_mExpectSessionTicket_42() const { return ___mExpectSessionTicket_42; }
	inline bool* get_address_of_mExpectSessionTicket_42() { return &___mExpectSessionTicket_42; }
	inline void set_mExpectSessionTicket_42(bool value)
	{
		___mExpectSessionTicket_42 = value;
	}
};

struct TlsProtocol_t2348540693_StaticFields
{
public:
	// System.String Org.BouncyCastle.Crypto.Tls.TlsProtocol::TLS_ERROR_MESSAGE
	String_t* ___TLS_ERROR_MESSAGE_0;

public:
	inline static int32_t get_offset_of_TLS_ERROR_MESSAGE_0() { return static_cast<int32_t>(offsetof(TlsProtocol_t2348540693_StaticFields, ___TLS_ERROR_MESSAGE_0)); }
	inline String_t* get_TLS_ERROR_MESSAGE_0() const { return ___TLS_ERROR_MESSAGE_0; }
	inline String_t** get_address_of_TLS_ERROR_MESSAGE_0() { return &___TLS_ERROR_MESSAGE_0; }
	inline void set_TLS_ERROR_MESSAGE_0(String_t* value)
	{
		___TLS_ERROR_MESSAGE_0 = value;
		Il2CppCodeGenWriteBarrier(&___TLS_ERROR_MESSAGE_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
