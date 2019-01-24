#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Signers.IDsaKCalculator
struct IDsaKCalculator_t1961041132;
// Org.BouncyCastle.Crypto.Parameters.DsaKeyParameters
struct DsaKeyParameters_t2298980877;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.DsaSigner
struct  DsaSigner_t1646699940  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Signers.IDsaKCalculator Org.BouncyCastle.Crypto.Signers.DsaSigner::kCalculator
	Il2CppObject * ___kCalculator_0;
	// Org.BouncyCastle.Crypto.Parameters.DsaKeyParameters Org.BouncyCastle.Crypto.Signers.DsaSigner::key
	DsaKeyParameters_t2298980877 * ___key_1;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Signers.DsaSigner::random
	SecureRandom_t3117234712 * ___random_2;

public:
	inline static int32_t get_offset_of_kCalculator_0() { return static_cast<int32_t>(offsetof(DsaSigner_t1646699940, ___kCalculator_0)); }
	inline Il2CppObject * get_kCalculator_0() const { return ___kCalculator_0; }
	inline Il2CppObject ** get_address_of_kCalculator_0() { return &___kCalculator_0; }
	inline void set_kCalculator_0(Il2CppObject * value)
	{
		___kCalculator_0 = value;
		Il2CppCodeGenWriteBarrier(&___kCalculator_0, value);
	}

	inline static int32_t get_offset_of_key_1() { return static_cast<int32_t>(offsetof(DsaSigner_t1646699940, ___key_1)); }
	inline DsaKeyParameters_t2298980877 * get_key_1() const { return ___key_1; }
	inline DsaKeyParameters_t2298980877 ** get_address_of_key_1() { return &___key_1; }
	inline void set_key_1(DsaKeyParameters_t2298980877 * value)
	{
		___key_1 = value;
		Il2CppCodeGenWriteBarrier(&___key_1, value);
	}

	inline static int32_t get_offset_of_random_2() { return static_cast<int32_t>(offsetof(DsaSigner_t1646699940, ___random_2)); }
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
