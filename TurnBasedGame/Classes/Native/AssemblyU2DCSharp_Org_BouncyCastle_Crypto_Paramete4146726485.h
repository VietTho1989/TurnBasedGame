#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters
struct ECPublicKeyParameters_t572706344;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.MqvPublicParameters
struct  MqvPublicParameters_t4146726485  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters Org.BouncyCastle.Crypto.Parameters.MqvPublicParameters::staticPublicKey
	ECPublicKeyParameters_t572706344 * ___staticPublicKey_0;
	// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters Org.BouncyCastle.Crypto.Parameters.MqvPublicParameters::ephemeralPublicKey
	ECPublicKeyParameters_t572706344 * ___ephemeralPublicKey_1;

public:
	inline static int32_t get_offset_of_staticPublicKey_0() { return static_cast<int32_t>(offsetof(MqvPublicParameters_t4146726485, ___staticPublicKey_0)); }
	inline ECPublicKeyParameters_t572706344 * get_staticPublicKey_0() const { return ___staticPublicKey_0; }
	inline ECPublicKeyParameters_t572706344 ** get_address_of_staticPublicKey_0() { return &___staticPublicKey_0; }
	inline void set_staticPublicKey_0(ECPublicKeyParameters_t572706344 * value)
	{
		___staticPublicKey_0 = value;
		Il2CppCodeGenWriteBarrier(&___staticPublicKey_0, value);
	}

	inline static int32_t get_offset_of_ephemeralPublicKey_1() { return static_cast<int32_t>(offsetof(MqvPublicParameters_t4146726485, ___ephemeralPublicKey_1)); }
	inline ECPublicKeyParameters_t572706344 * get_ephemeralPublicKey_1() const { return ___ephemeralPublicKey_1; }
	inline ECPublicKeyParameters_t572706344 ** get_address_of_ephemeralPublicKey_1() { return &___ephemeralPublicKey_1; }
	inline void set_ephemeralPublicKey_1(ECPublicKeyParameters_t572706344 * value)
	{
		___ephemeralPublicKey_1 = value;
		Il2CppCodeGenWriteBarrier(&___ephemeralPublicKey_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
