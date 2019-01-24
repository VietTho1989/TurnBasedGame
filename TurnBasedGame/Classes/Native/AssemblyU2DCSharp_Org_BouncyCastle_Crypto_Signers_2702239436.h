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

// Org.BouncyCastle.Crypto.Signers.ECNRSigner
struct  ECNRSigner_t2702239436  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.Crypto.Signers.ECNRSigner::forSigning
	bool ___forSigning_0;
	// Org.BouncyCastle.Crypto.Parameters.ECKeyParameters Org.BouncyCastle.Crypto.Signers.ECNRSigner::key
	ECKeyParameters_t1064568751 * ___key_1;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Signers.ECNRSigner::random
	SecureRandom_t3117234712 * ___random_2;

public:
	inline static int32_t get_offset_of_forSigning_0() { return static_cast<int32_t>(offsetof(ECNRSigner_t2702239436, ___forSigning_0)); }
	inline bool get_forSigning_0() const { return ___forSigning_0; }
	inline bool* get_address_of_forSigning_0() { return &___forSigning_0; }
	inline void set_forSigning_0(bool value)
	{
		___forSigning_0 = value;
	}

	inline static int32_t get_offset_of_key_1() { return static_cast<int32_t>(offsetof(ECNRSigner_t2702239436, ___key_1)); }
	inline ECKeyParameters_t1064568751 * get_key_1() const { return ___key_1; }
	inline ECKeyParameters_t1064568751 ** get_address_of_key_1() { return &___key_1; }
	inline void set_key_1(ECKeyParameters_t1064568751 * value)
	{
		___key_1 = value;
		Il2CppCodeGenWriteBarrier(&___key_1, value);
	}

	inline static int32_t get_offset_of_random_2() { return static_cast<int32_t>(offsetof(ECNRSigner_t2702239436, ___random_2)); }
	inline SecureRandom_t3117234712 * get_random_2() const { return ___random_2; }
	inline SecureRandom_t3117234712 ** get_address_of_random_2() { return &___random_2; }
	inline void set_random_2(SecureRandom_t3117234712 * value)
	{
		___random_2 = value;
		Il2CppCodeGenWriteBarrier(&___random_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
