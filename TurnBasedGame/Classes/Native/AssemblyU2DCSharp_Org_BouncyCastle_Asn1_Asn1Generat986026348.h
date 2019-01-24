#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Asn1Generator
struct  Asn1Generator_t986026348  : public Il2CppObject
{
public:
	// System.IO.Stream Org.BouncyCastle.Asn1.Asn1Generator::_out
	Stream_t3255436806 * ____out_0;

public:
	inline static int32_t get_offset_of__out_0() { return static_cast<int32_t>(offsetof(Asn1Generator_t986026348, ____out_0)); }
	inline Stream_t3255436806 * get__out_0() const { return ____out_0; }
	inline Stream_t3255436806 ** get_address_of__out_0() { return &____out_0; }
	inline void set__out_0(Stream_t3255436806 * value)
	{
		____out_0 = value;
		Il2CppCodeGenWriteBarrier(&____out_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
