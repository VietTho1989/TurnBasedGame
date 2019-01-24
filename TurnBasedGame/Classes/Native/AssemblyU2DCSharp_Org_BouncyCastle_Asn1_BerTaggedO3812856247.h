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

// Org.BouncyCastle.Asn1.BerTaggedObjectParser
struct  BerTaggedObjectParser_t3812856247  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.Asn1.BerTaggedObjectParser::_constructed
	bool ____constructed_0;
	// System.Int32 Org.BouncyCastle.Asn1.BerTaggedObjectParser::_tagNumber
	int32_t ____tagNumber_1;
	// Org.BouncyCastle.Asn1.Asn1StreamParser Org.BouncyCastle.Asn1.BerTaggedObjectParser::_parser
	Asn1StreamParser_t3208800844 * ____parser_2;

public:
	inline static int32_t get_offset_of__constructed_0() { return static_cast<int32_t>(offsetof(BerTaggedObjectParser_t3812856247, ____constructed_0)); }
	inline bool get__constructed_0() const { return ____constructed_0; }
	inline bool* get_address_of__constructed_0() { return &____constructed_0; }
	inline void set__constructed_0(bool value)
	{
		____constructed_0 = value;
	}

	inline static int32_t get_offset_of__tagNumber_1() { return static_cast<int32_t>(offsetof(BerTaggedObjectParser_t3812856247, ____tagNumber_1)); }
	inline int32_t get__tagNumber_1() const { return ____tagNumber_1; }
	inline int32_t* get_address_of__tagNumber_1() { return &____tagNumber_1; }
	inline void set__tagNumber_1(int32_t value)
	{
		____tagNumber_1 = value;
	}

	inline static int32_t get_offset_of__parser_2() { return static_cast<int32_t>(offsetof(BerTaggedObjectParser_t3812856247, ____parser_2)); }
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
