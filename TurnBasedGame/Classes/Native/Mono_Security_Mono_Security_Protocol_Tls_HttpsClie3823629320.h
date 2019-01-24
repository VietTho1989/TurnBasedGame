#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Mono_Security_Mono_Security_Protocol_Tls_SslClient3918817353.h"

// System.Net.HttpWebRequest
struct HttpWebRequest_t1951404513;
// Mono.Security.Protocol.Tls.CertificateSelectionCallback
struct CertificateSelectionCallback_t3721235490;
// Mono.Security.Protocol.Tls.PrivateKeySelectionCallback
struct PrivateKeySelectionCallback_t1663566523;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Protocol.Tls.HttpsClientStream
struct  HttpsClientStream_t3823629320  : public SslClientStream_t3918817353
{
public:
	// System.Net.HttpWebRequest Mono.Security.Protocol.Tls.HttpsClientStream::_request
	HttpWebRequest_t1951404513 * ____request_21;
	// System.Int32 Mono.Security.Protocol.Tls.HttpsClientStream::_status
	int32_t ____status_22;

public:
	inline static int32_t get_offset_of__request_21() { return static_cast<int32_t>(offsetof(HttpsClientStream_t3823629320, ____request_21)); }
	inline HttpWebRequest_t1951404513 * get__request_21() const { return ____request_21; }
	inline HttpWebRequest_t1951404513 ** get_address_of__request_21() { return &____request_21; }
	inline void set__request_21(HttpWebRequest_t1951404513 * value)
	{
		____request_21 = value;
		Il2CppCodeGenWriteBarrier(&____request_21, value);
	}

	inline static int32_t get_offset_of__status_22() { return static_cast<int32_t>(offsetof(HttpsClientStream_t3823629320, ____status_22)); }
	inline int32_t get__status_22() const { return ____status_22; }
	inline int32_t* get_address_of__status_22() { return &____status_22; }
	inline void set__status_22(int32_t value)
	{
		____status_22 = value;
	}
};

struct HttpsClientStream_t3823629320_StaticFields
{
public:
	// Mono.Security.Protocol.Tls.CertificateSelectionCallback Mono.Security.Protocol.Tls.HttpsClientStream::<>f__am$cache2
	CertificateSelectionCallback_t3721235490 * ___U3CU3Ef__amU24cache2_23;
	// Mono.Security.Protocol.Tls.PrivateKeySelectionCallback Mono.Security.Protocol.Tls.HttpsClientStream::<>f__am$cache3
	PrivateKeySelectionCallback_t1663566523 * ___U3CU3Ef__amU24cache3_24;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache2_23() { return static_cast<int32_t>(offsetof(HttpsClientStream_t3823629320_StaticFields, ___U3CU3Ef__amU24cache2_23)); }
	inline CertificateSelectionCallback_t3721235490 * get_U3CU3Ef__amU24cache2_23() const { return ___U3CU3Ef__amU24cache2_23; }
	inline CertificateSelectionCallback_t3721235490 ** get_address_of_U3CU3Ef__amU24cache2_23() { return &___U3CU3Ef__amU24cache2_23; }
	inline void set_U3CU3Ef__amU24cache2_23(CertificateSelectionCallback_t3721235490 * value)
	{
		___U3CU3Ef__amU24cache2_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache2_23, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache3_24() { return static_cast<int32_t>(offsetof(HttpsClientStream_t3823629320_StaticFields, ___U3CU3Ef__amU24cache3_24)); }
	inline PrivateKeySelectionCallback_t1663566523 * get_U3CU3Ef__amU24cache3_24() const { return ___U3CU3Ef__amU24cache3_24; }
	inline PrivateKeySelectionCallback_t1663566523 ** get_address_of_U3CU3Ef__amU24cache3_24() { return &___U3CU3Ef__amU24cache3_24; }
	inline void set_U3CU3Ef__amU24cache3_24(PrivateKeySelectionCallback_t1663566523 * value)
	{
		___U3CU3Ef__amU24cache3_24 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache3_24, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
