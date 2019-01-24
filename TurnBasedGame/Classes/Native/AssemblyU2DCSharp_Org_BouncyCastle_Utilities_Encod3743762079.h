#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Utilities.Encoders.IEncoder
struct IEncoder_t3392806881;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Encoders.Hex
struct  Hex_t3743762079  : public Il2CppObject
{
public:

public:
};

struct Hex_t3743762079_StaticFields
{
public:
	// Org.BouncyCastle.Utilities.Encoders.IEncoder Org.BouncyCastle.Utilities.Encoders.Hex::encoder
	Il2CppObject * ___encoder_0;

public:
	inline static int32_t get_offset_of_encoder_0() { return static_cast<int32_t>(offsetof(Hex_t3743762079_StaticFields, ___encoder_0)); }
	inline Il2CppObject * get_encoder_0() const { return ___encoder_0; }
	inline Il2CppObject ** get_address_of_encoder_0() { return &___encoder_0; }
	inline void set_encoder_0(Il2CppObject * value)
	{
		___encoder_0 = value;
		Il2CppCodeGenWriteBarrier(&___encoder_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
