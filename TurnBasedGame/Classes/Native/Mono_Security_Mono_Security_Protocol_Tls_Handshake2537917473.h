#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Mono_Security_Mono_Security_Protocol_Tls_Handshake3938752374.h"

// System.Security.Cryptography.X509Certificates.X509Certificate
struct X509Certificate_t283079845;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Protocol.Tls.Handshake.Client.TlsClientCertificate
struct  TlsClientCertificate_t2537917473  : public HandshakeMessage_t3938752374
{
public:
	// System.Boolean Mono.Security.Protocol.Tls.Handshake.Client.TlsClientCertificate::clientCertSelected
	bool ___clientCertSelected_10;
	// System.Security.Cryptography.X509Certificates.X509Certificate Mono.Security.Protocol.Tls.Handshake.Client.TlsClientCertificate::clientCert
	X509Certificate_t283079845 * ___clientCert_11;

public:
	inline static int32_t get_offset_of_clientCertSelected_10() { return static_cast<int32_t>(offsetof(TlsClientCertificate_t2537917473, ___clientCertSelected_10)); }
	inline bool get_clientCertSelected_10() const { return ___clientCertSelected_10; }
	inline bool* get_address_of_clientCertSelected_10() { return &___clientCertSelected_10; }
	inline void set_clientCertSelected_10(bool value)
	{
		___clientCertSelected_10 = value;
	}

	inline static int32_t get_offset_of_clientCert_11() { return static_cast<int32_t>(offsetof(TlsClientCertificate_t2537917473, ___clientCert_11)); }
	inline X509Certificate_t283079845 * get_clientCert_11() const { return ___clientCert_11; }
	inline X509Certificate_t283079845 ** get_address_of_clientCert_11() { return &___clientCert_11; }
	inline void set_clientCert_11(X509Certificate_t283079845 * value)
	{
		___clientCert_11 = value;
		Il2CppCodeGenWriteBarrier(&___clientCert_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
