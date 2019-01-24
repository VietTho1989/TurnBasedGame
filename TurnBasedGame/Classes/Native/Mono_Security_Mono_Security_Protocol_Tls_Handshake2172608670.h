﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Mono_Security_Mono_Security_Protocol_Tls_Handshake3938752374.h"
#include "mscorlib_System_Security_Cryptography_RSAParameter1462703416.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Protocol.Tls.Handshake.Client.TlsServerKeyExchange
struct  TlsServerKeyExchange_t2172608670  : public HandshakeMessage_t3938752374
{
public:
	// System.Security.Cryptography.RSAParameters Mono.Security.Protocol.Tls.Handshake.Client.TlsServerKeyExchange::rsaParams
	RSAParameters_t1462703416  ___rsaParams_10;
	// System.Byte[] Mono.Security.Protocol.Tls.Handshake.Client.TlsServerKeyExchange::signedParams
	ByteU5BU5D_t3397334013* ___signedParams_11;

public:
	inline static int32_t get_offset_of_rsaParams_10() { return static_cast<int32_t>(offsetof(TlsServerKeyExchange_t2172608670, ___rsaParams_10)); }
	inline RSAParameters_t1462703416  get_rsaParams_10() const { return ___rsaParams_10; }
	inline RSAParameters_t1462703416 * get_address_of_rsaParams_10() { return &___rsaParams_10; }
	inline void set_rsaParams_10(RSAParameters_t1462703416  value)
	{
		___rsaParams_10 = value;
	}

	inline static int32_t get_offset_of_signedParams_11() { return static_cast<int32_t>(offsetof(TlsServerKeyExchange_t2172608670, ___signedParams_11)); }
	inline ByteU5BU5D_t3397334013* get_signedParams_11() const { return ___signedParams_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_signedParams_11() { return &___signedParams_11; }
	inline void set_signedParams_11(ByteU5BU5D_t3397334013* value)
	{
		___signedParams_11 = value;
		Il2CppCodeGenWriteBarrier(&___signedParams_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
