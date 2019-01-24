#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Asn1.DefiniteLengthInputStream
struct DefiniteLengthInputStream_t1065419872;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerOctetStringParser
struct  DerOctetStringParser_t3154381398  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Asn1.DefiniteLengthInputStream Org.BouncyCastle.Asn1.DerOctetStringParser::stream
	DefiniteLengthInputStream_t1065419872 * ___stream_0;

public:
	inline static int32_t get_offset_of_stream_0() { return static_cast<int32_t>(offsetof(DerOctetStringParser_t3154381398, ___stream_0)); }
	inline DefiniteLengthInputStream_t1065419872 * get_stream_0() const { return ___stream_0; }
	inline DefiniteLengthInputStream_t1065419872 ** get_address_of_stream_0() { return &___stream_0; }
	inline void set_stream_0(DefiniteLengthInputStream_t1065419872 * value)
	{
		___stream_0 = value;
		Il2CppCodeGenWriteBarrier(&___stream_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
