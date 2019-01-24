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
// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters
struct ECPublicKeyParameters_t572706344;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.MqvPrivateParameters
struct  MqvPrivateParameters_t2816354209  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters Org.BouncyCastle.Crypto.Parameters.MqvPrivateParameters::staticPrivateKey
	ECPrivateKeyParameters_t3632960452 * ___staticPrivateKey_0;
	// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters Org.BouncyCastle.Crypto.Parameters.MqvPrivateParameters::ephemeralPrivateKey
	ECPrivateKeyParameters_t3632960452 * ___ephemeralPrivateKey_1;
	// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters Org.BouncyCastle.Crypto.Parameters.MqvPrivateParameters::ephemeralPublicKey
	ECPublicKeyParameters_t572706344 * ___ephemeralPublicKey_2;

public:
	inline static int32_t get_offset_of_staticPrivateKey_0() { return static_cast<int32_t>(offsetof(MqvPrivateParameters_t2816354209, ___staticPrivateKey_0)); }
	inline ECPrivateKeyParameters_t3632960452 * get_staticPrivateKey_0() const { return ___staticPrivateKey_0; }
	inline ECPrivateKeyParameters_t3632960452 ** get_address_of_staticPrivateKey_0() { return &___staticPrivateKey_0; }
	inline void set_staticPrivateKey_0(ECPrivateKeyParameters_t3632960452 * value)
	{
		___staticPrivateKey_0 = value;
		Il2CppCodeGenWriteBarrier(&___staticPrivateKey_0, value);
	}

	inline static int32_t get_offset_of_ephemeralPrivateKey_1() { return static_cast<int32_t>(offsetof(MqvPrivateParameters_t2816354209, ___ephemeralPrivateKey_1)); }
	inline ECPrivateKeyParameters_t3632960452 * get_ephemeralPrivateKey_1() const { return ___ephemeralPrivateKey_1; }
	inline ECPrivateKeyParameters_t3632960452 ** get_address_of_ephemeralPrivateKey_1() { return &___ephemeralPrivateKey_1; }
	inline void set_ephemeralPrivateKey_1(ECPrivateKeyParameters_t3632960452 * value)
	{
		___ephemeralPrivateKey_1 = value;
		Il2CppCodeGenWriteBarrier(&___ephemeralPrivateKey_1, value);
	}

	inline static int32_t get_offset_of_ephemeralPublicKey_2() { return static_cast<int32_t>(offsetof(MqvPrivateParameters_t2816354209, ___ephemeralPublicKey_2)); }
	inline ECPublicKeyParameters_t572706344 * get_ephemeralPublicKey_2() const { return ___ephemeralPublicKey_2; }
	inline ECPublicKeyParameters_t572706344 ** get_address_of_ephemeralPublicKey_2() { return &___ephemeralPublicKey_2; }
	inline void set_ephemeralPublicKey_2(ECPublicKeyParameters_t572706344 * value)
	{
		___ephemeralPublicKey_2 = value;
		Il2CppCodeGenWriteBarrier(&___ephemeralPublicKey_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
