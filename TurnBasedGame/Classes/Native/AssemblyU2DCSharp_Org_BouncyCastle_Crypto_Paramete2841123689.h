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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DHValidationParameters
struct  DHValidationParameters_t2841123689  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.DHValidationParameters::seed
	ByteU5BU5D_t3397334013* ___seed_0;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.DHValidationParameters::counter
	int32_t ___counter_1;

public:
	inline static int32_t get_offset_of_seed_0() { return static_cast<int32_t>(offsetof(DHValidationParameters_t2841123689, ___seed_0)); }
	inline ByteU5BU5D_t3397334013* get_seed_0() const { return ___seed_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_seed_0() { return &___seed_0; }
	inline void set_seed_0(ByteU5BU5D_t3397334013* value)
	{
		___seed_0 = value;
		Il2CppCodeGenWriteBarrier(&___seed_0, value);
	}

	inline static int32_t get_offset_of_counter_1() { return static_cast<int32_t>(offsetof(DHValidationParameters_t2841123689, ___counter_1)); }
	inline int32_t get_counter_1() const { return ___counter_1; }
	inline int32_t* get_address_of_counter_1() { return &___counter_1; }
	inline void set_counter_1(int32_t value)
	{
		___counter_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
