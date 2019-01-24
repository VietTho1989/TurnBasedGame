#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters
struct DHPrivateKeyParameters_t3120746414;
// Org.BouncyCastle.Crypto.Parameters.DHParameters
struct DHParameters_t431035336;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Agreement.DHBasicAgreement
struct  DHBasicAgreement_t3319300478  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters Org.BouncyCastle.Crypto.Agreement.DHBasicAgreement::key
	DHPrivateKeyParameters_t3120746414 * ___key_0;
	// Org.BouncyCastle.Crypto.Parameters.DHParameters Org.BouncyCastle.Crypto.Agreement.DHBasicAgreement::dhParams
	DHParameters_t431035336 * ___dhParams_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(DHBasicAgreement_t3319300478, ___key_0)); }
	inline DHPrivateKeyParameters_t3120746414 * get_key_0() const { return ___key_0; }
	inline DHPrivateKeyParameters_t3120746414 ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(DHPrivateKeyParameters_t3120746414 * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_dhParams_1() { return static_cast<int32_t>(offsetof(DHBasicAgreement_t3319300478, ___dhParams_1)); }
	inline DHParameters_t431035336 * get_dhParams_1() const { return ___dhParams_1; }
	inline DHParameters_t431035336 ** get_address_of_dhParams_1() { return &___dhParams_1; }
	inline void set_dhParams_1(DHParameters_t431035336 * value)
	{
		___dhParams_1 = value;
		Il2CppCodeGenWriteBarrier(&___dhParams_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
