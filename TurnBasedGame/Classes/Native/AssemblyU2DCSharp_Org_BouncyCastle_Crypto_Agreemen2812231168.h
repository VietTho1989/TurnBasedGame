#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters
struct ECPrivateKeyParameters_t3632960452;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Agreement.ECDHBasicAgreement
struct  ECDHBasicAgreement_t2812231168  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters Org.BouncyCastle.Crypto.Agreement.ECDHBasicAgreement::privKey
	ECPrivateKeyParameters_t3632960452 * ___privKey_0;

public:
	inline static int32_t get_offset_of_privKey_0() { return static_cast<int32_t>(offsetof(ECDHBasicAgreement_t2812231168, ___privKey_0)); }
	inline ECPrivateKeyParameters_t3632960452 * get_privKey_0() const { return ___privKey_0; }
	inline ECPrivateKeyParameters_t3632960452 ** get_address_of_privKey_0() { return &___privKey_0; }
	inline void set_privKey_0(ECPrivateKeyParameters_t3632960452 * value)
	{
		___privKey_0 = value;
		Il2CppCodeGenWriteBarrier(&___privKey_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
