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

// Org.BouncyCastle.Crypto.PbeParametersGenerator
struct  PbeParametersGenerator_t148045164  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.PbeParametersGenerator::mPassword
	ByteU5BU5D_t3397334013* ___mPassword_0;
	// System.Byte[] Org.BouncyCastle.Crypto.PbeParametersGenerator::mSalt
	ByteU5BU5D_t3397334013* ___mSalt_1;
	// System.Int32 Org.BouncyCastle.Crypto.PbeParametersGenerator::mIterationCount
	int32_t ___mIterationCount_2;

public:
	inline static int32_t get_offset_of_mPassword_0() { return static_cast<int32_t>(offsetof(PbeParametersGenerator_t148045164, ___mPassword_0)); }
	inline ByteU5BU5D_t3397334013* get_mPassword_0() const { return ___mPassword_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_mPassword_0() { return &___mPassword_0; }
	inline void set_mPassword_0(ByteU5BU5D_t3397334013* value)
	{
		___mPassword_0 = value;
		Il2CppCodeGenWriteBarrier(&___mPassword_0, value);
	}

	inline static int32_t get_offset_of_mSalt_1() { return static_cast<int32_t>(offsetof(PbeParametersGenerator_t148045164, ___mSalt_1)); }
	inline ByteU5BU5D_t3397334013* get_mSalt_1() const { return ___mSalt_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_mSalt_1() { return &___mSalt_1; }
	inline void set_mSalt_1(ByteU5BU5D_t3397334013* value)
	{
		___mSalt_1 = value;
		Il2CppCodeGenWriteBarrier(&___mSalt_1, value);
	}

	inline static int32_t get_offset_of_mIterationCount_2() { return static_cast<int32_t>(offsetof(PbeParametersGenerator_t148045164, ___mIterationCount_2)); }
	inline int32_t get_mIterationCount_2() const { return ___mIterationCount_2; }
	inline int32_t* get_address_of_mIterationCount_2() { return &___mIterationCount_2; }
	inline void set_mIterationCount_2(int32_t value)
	{
		___mIterationCount_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
