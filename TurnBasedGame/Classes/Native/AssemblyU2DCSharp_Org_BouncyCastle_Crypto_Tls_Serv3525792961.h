#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.DHPublicKeyParameters
struct DHPublicKeyParameters_t1544976430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.ServerDHParams
struct  ServerDHParams_t3525792961  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DHPublicKeyParameters Org.BouncyCastle.Crypto.Tls.ServerDHParams::mPublicKey
	DHPublicKeyParameters_t1544976430 * ___mPublicKey_0;

public:
	inline static int32_t get_offset_of_mPublicKey_0() { return static_cast<int32_t>(offsetof(ServerDHParams_t3525792961, ___mPublicKey_0)); }
	inline DHPublicKeyParameters_t1544976430 * get_mPublicKey_0() const { return ___mPublicKey_0; }
	inline DHPublicKeyParameters_t1544976430 ** get_address_of_mPublicKey_0() { return &___mPublicKey_0; }
	inline void set_mPublicKey_0(DHPublicKeyParameters_t1544976430 * value)
	{
		___mPublicKey_0 = value;
		Il2CppCodeGenWriteBarrier(&___mPublicKey_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
