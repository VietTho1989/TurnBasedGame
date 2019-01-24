#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Mono_Security_Mono_Security_Protocol_Tls_SslStreamB934199321.h"

// Mono.Security.Protocol.Tls.CertificateValidationCallback
struct CertificateValidationCallback_t989458295;
// Mono.Security.Protocol.Tls.CertificateSelectionCallback
struct CertificateSelectionCallback_t3721235490;
// Mono.Security.Protocol.Tls.PrivateKeySelectionCallback
struct PrivateKeySelectionCallback_t1663566523;
// Mono.Security.Protocol.Tls.CertificateValidationCallback2
struct CertificateValidationCallback2_t3318447433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Protocol.Tls.SslClientStream
struct  SslClientStream_t3918817353  : public SslStreamBase_t934199321
{
public:
	// Mono.Security.Protocol.Tls.CertificateValidationCallback Mono.Security.Protocol.Tls.SslClientStream::ServerCertValidation
	CertificateValidationCallback_t989458295 * ___ServerCertValidation_17;
	// Mono.Security.Protocol.Tls.CertificateSelectionCallback Mono.Security.Protocol.Tls.SslClientStream::ClientCertSelection
	CertificateSelectionCallback_t3721235490 * ___ClientCertSelection_18;
	// Mono.Security.Protocol.Tls.PrivateKeySelectionCallback Mono.Security.Protocol.Tls.SslClientStream::PrivateKeySelection
	PrivateKeySelectionCallback_t1663566523 * ___PrivateKeySelection_19;
	// Mono.Security.Protocol.Tls.CertificateValidationCallback2 Mono.Security.Protocol.Tls.SslClientStream::ServerCertValidation2
	CertificateValidationCallback2_t3318447433 * ___ServerCertValidation2_20;

public:
	inline static int32_t get_offset_of_ServerCertValidation_17() { return static_cast<int32_t>(offsetof(SslClientStream_t3918817353, ___ServerCertValidation_17)); }
	inline CertificateValidationCallback_t989458295 * get_ServerCertValidation_17() const { return ___ServerCertValidation_17; }
	inline CertificateValidationCallback_t989458295 ** get_address_of_ServerCertValidation_17() { return &___ServerCertValidation_17; }
	inline void set_ServerCertValidation_17(CertificateValidationCallback_t989458295 * value)
	{
		___ServerCertValidation_17 = value;
		Il2CppCodeGenWriteBarrier(&___ServerCertValidation_17, value);
	}

	inline static int32_t get_offset_of_ClientCertSelection_18() { return static_cast<int32_t>(offsetof(SslClientStream_t3918817353, ___ClientCertSelection_18)); }
	inline CertificateSelectionCallback_t3721235490 * get_ClientCertSelection_18() const { return ___ClientCertSelection_18; }
	inline CertificateSelectionCallback_t3721235490 ** get_address_of_ClientCertSelection_18() { return &___ClientCertSelection_18; }
	inline void set_ClientCertSelection_18(CertificateSelectionCallback_t3721235490 * value)
	{
		___ClientCertSelection_18 = value;
		Il2CppCodeGenWriteBarrier(&___ClientCertSelection_18, value);
	}

	inline static int32_t get_offset_of_PrivateKeySelection_19() { return static_cast<int32_t>(offsetof(SslClientStream_t3918817353, ___PrivateKeySelection_19)); }
	inline PrivateKeySelectionCallback_t1663566523 * get_PrivateKeySelection_19() const { return ___PrivateKeySelection_19; }
	inline PrivateKeySelectionCallback_t1663566523 ** get_address_of_PrivateKeySelection_19() { return &___PrivateKeySelection_19; }
	inline void set_PrivateKeySelection_19(PrivateKeySelectionCallback_t1663566523 * value)
	{
		___PrivateKeySelection_19 = value;
		Il2CppCodeGenWriteBarrier(&___PrivateKeySelection_19, value);
	}

	inline static int32_t get_offset_of_ServerCertValidation2_20() { return static_cast<int32_t>(offsetof(SslClientStream_t3918817353, ___ServerCertValidation2_20)); }
	inline CertificateValidationCallback2_t3318447433 * get_ServerCertValidation2_20() const { return ___ServerCertValidation2_20; }
	inline CertificateValidationCallback2_t3318447433 ** get_address_of_ServerCertValidation2_20() { return &___ServerCertValidation2_20; }
	inline void set_ServerCertValidation2_20(CertificateValidationCallback2_t3318447433 * value)
	{
		___ServerCertValidation2_20 = value;
		Il2CppCodeGenWriteBarrier(&___ServerCertValidation2_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
