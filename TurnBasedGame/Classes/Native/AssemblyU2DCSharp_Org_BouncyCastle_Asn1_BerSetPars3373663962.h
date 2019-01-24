#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Asn1.Asn1StreamParser
struct Asn1StreamParser_t3208800844;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.BerSetParser
struct  BerSetParser_t3373663962  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Asn1.Asn1StreamParser Org.BouncyCastle.Asn1.BerSetParser::_parser
	Asn1StreamParser_t3208800844 * ____parser_0;

public:
	inline static int32_t get_offset_of__parser_0() { return static_cast<int32_t>(offsetof(BerSetParser_t3373663962, ____parser_0)); }
	inline Asn1StreamParser_t3208800844 * get__parser_0() const { return ____parser_0; }
	inline Asn1StreamParser_t3208800844 ** get_address_of__parser_0() { return &____parser_0; }
	inline void set__parser_0(Asn1StreamParser_t3208800844 * value)
	{
		____parser_0 = value;
		Il2CppCodeGenWriteBarrier(&____parser_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
