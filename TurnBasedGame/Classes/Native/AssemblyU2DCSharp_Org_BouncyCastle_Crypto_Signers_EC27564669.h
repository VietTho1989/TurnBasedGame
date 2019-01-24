#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.ECKeyParameters
struct ECKeyParameters_t1064568751;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.ECGost3410Signer
struct  ECGost3410Signer_t27564669  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ECKeyParameters Org.BouncyCastle.Crypto.Signers.ECGost3410Signer::key
	ECKeyParameters_t1064568751 * ___key_0;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Signers.ECGost3410Signer::random
	SecureRandom_t3117234712 * ___random_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(ECGost3410Signer_t27564669, ___key_0)); }
	inline ECKeyParameters_t1064568751 * get_key_0() const { return ___key_0; }
	inline ECKeyParameters_t1064568751 ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(ECKeyParameters_t1064568751 * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_random_1() { return static_cast<int32_t>(offsetof(ECGost3410Signer_t27564669, ___random_1)); }
	inline SecureRandom_t3117234712 * get_random_1() const { return ___random_1; }
	inline SecureRandom_t3117234712 ** get_address_of_random_1() { return &___random_1; }
	inline void set_random_1(SecureRandom_t3117234712 * value)
	{
		___random_1 = value;
		Il2CppCodeGenWriteBarrier(&___random_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
