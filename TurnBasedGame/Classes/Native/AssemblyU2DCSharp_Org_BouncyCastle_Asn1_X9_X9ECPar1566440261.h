#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Asn1.X9.X9ECParameters
struct X9ECParameters_t1959966001;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.X9ECParametersHolder
struct  X9ECParametersHolder_t1566440261  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Asn1.X9.X9ECParameters Org.BouncyCastle.Asn1.X9.X9ECParametersHolder::parameters
	X9ECParameters_t1959966001 * ___parameters_0;

public:
	inline static int32_t get_offset_of_parameters_0() { return static_cast<int32_t>(offsetof(X9ECParametersHolder_t1566440261, ___parameters_0)); }
	inline X9ECParameters_t1959966001 * get_parameters_0() const { return ___parameters_0; }
	inline X9ECParameters_t1959966001 ** get_address_of_parameters_0() { return &___parameters_0; }
	inline void set_parameters_0(X9ECParameters_t1959966001 * value)
	{
		___parameters_0 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
