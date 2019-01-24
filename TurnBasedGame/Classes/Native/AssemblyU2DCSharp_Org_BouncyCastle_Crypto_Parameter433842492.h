#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.ICipherParameters
struct ICipherParameters_t3082042576;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ParametersWithSalt
struct  ParametersWithSalt_t433842492  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.ParametersWithSalt::salt
	ByteU5BU5D_t3397334013* ___salt_0;
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Parameters.ParametersWithSalt::parameters
	Il2CppObject * ___parameters_1;

public:
	inline static int32_t get_offset_of_salt_0() { return static_cast<int32_t>(offsetof(ParametersWithSalt_t433842492, ___salt_0)); }
	inline ByteU5BU5D_t3397334013* get_salt_0() const { return ___salt_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_salt_0() { return &___salt_0; }
	inline void set_salt_0(ByteU5BU5D_t3397334013* value)
	{
		___salt_0 = value;
		Il2CppCodeGenWriteBarrier(&___salt_0, value);
	}

	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(ParametersWithSalt_t433842492, ___parameters_1)); }
	inline Il2CppObject * get_parameters_1() const { return ___parameters_1; }
	inline Il2CppObject ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(Il2CppObject * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
