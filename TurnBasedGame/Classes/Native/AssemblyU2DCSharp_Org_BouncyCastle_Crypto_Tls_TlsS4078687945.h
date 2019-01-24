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
// Org.BouncyCastle.Crypto.Tls.SessionParameters
struct SessionParameters_t833892266;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsSessionImpl
struct  TlsSessionImpl_t4078687945  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsSessionImpl::mSessionID
	ByteU5BU5D_t3397334013* ___mSessionID_0;
	// Org.BouncyCastle.Crypto.Tls.SessionParameters Org.BouncyCastle.Crypto.Tls.TlsSessionImpl::mSessionParameters
	SessionParameters_t833892266 * ___mSessionParameters_1;

public:
	inline static int32_t get_offset_of_mSessionID_0() { return static_cast<int32_t>(offsetof(TlsSessionImpl_t4078687945, ___mSessionID_0)); }
	inline ByteU5BU5D_t3397334013* get_mSessionID_0() const { return ___mSessionID_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_mSessionID_0() { return &___mSessionID_0; }
	inline void set_mSessionID_0(ByteU5BU5D_t3397334013* value)
	{
		___mSessionID_0 = value;
		Il2CppCodeGenWriteBarrier(&___mSessionID_0, value);
	}

	inline static int32_t get_offset_of_mSessionParameters_1() { return static_cast<int32_t>(offsetof(TlsSessionImpl_t4078687945, ___mSessionParameters_1)); }
	inline SessionParameters_t833892266 * get_mSessionParameters_1() const { return ___mSessionParameters_1; }
	inline SessionParameters_t833892266 ** get_address_of_mSessionParameters_1() { return &___mSessionParameters_1; }
	inline void set_mSessionParameters_1(SessionParameters_t833892266 * value)
	{
		___mSessionParameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___mSessionParameters_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
