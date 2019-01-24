#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.ICipherParameters
struct ICipherParameters_t3082042576;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV
struct  ParametersWithIV_t2760900877  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Parameters.ParametersWithIV::parameters
	Il2CppObject * ___parameters_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.ParametersWithIV::iv
	ByteU5BU5D_t3397334013* ___iv_1;

public:
	inline static int32_t get_offset_of_parameters_0() { return static_cast<int32_t>(offsetof(ParametersWithIV_t2760900877, ___parameters_0)); }
	inline Il2CppObject * get_parameters_0() const { return ___parameters_0; }
	inline Il2CppObject ** get_address_of_parameters_0() { return &___parameters_0; }
	inline void set_parameters_0(Il2CppObject * value)
	{
		___parameters_0 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_0, value);
	}

	inline static int32_t get_offset_of_iv_1() { return static_cast<int32_t>(offsetof(ParametersWithIV_t2760900877, ___iv_1)); }
	inline ByteU5BU5D_t3397334013* get_iv_1() const { return ___iv_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_iv_1() { return &___iv_1; }
	inline void set_iv_1(ByteU5BU5D_t3397334013* value)
	{
		___iv_1 = value;
		Il2CppCodeGenWriteBarrier(&___iv_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
