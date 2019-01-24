#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Asn1StreamParser
struct Asn1StreamParser_t3208800844;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerExternalParser
struct  DerExternalParser_t2840903253  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1StreamParser Org.BouncyCastle.Asn1.DerExternalParser::_parser
	Asn1StreamParser_t3208800844 * ____parser_2;

public:
	inline static int32_t get_offset_of__parser_2() { return static_cast<int32_t>(offsetof(DerExternalParser_t2840903253, ____parser_2)); }
	inline Asn1StreamParser_t3208800844 * get__parser_2() const { return ____parser_2; }
	inline Asn1StreamParser_t3208800844 ** get_address_of__parser_2() { return &____parser_2; }
	inline void set__parser_2(Asn1StreamParser_t3208800844 * value)
	{
		____parser_2 = value;
		Il2CppCodeGenWriteBarrier(&____parser_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
