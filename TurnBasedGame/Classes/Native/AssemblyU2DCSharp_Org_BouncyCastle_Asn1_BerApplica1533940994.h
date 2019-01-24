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

// Org.BouncyCastle.Asn1.BerApplicationSpecificParser
struct  BerApplicationSpecificParser_t1533940994  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Asn1.BerApplicationSpecificParser::tag
	int32_t ___tag_0;
	// Org.BouncyCastle.Asn1.Asn1StreamParser Org.BouncyCastle.Asn1.BerApplicationSpecificParser::parser
	Asn1StreamParser_t3208800844 * ___parser_1;

public:
	inline static int32_t get_offset_of_tag_0() { return static_cast<int32_t>(offsetof(BerApplicationSpecificParser_t1533940994, ___tag_0)); }
	inline int32_t get_tag_0() const { return ___tag_0; }
	inline int32_t* get_address_of_tag_0() { return &___tag_0; }
	inline void set_tag_0(int32_t value)
	{
		___tag_0 = value;
	}

	inline static int32_t get_offset_of_parser_1() { return static_cast<int32_t>(offsetof(BerApplicationSpecificParser_t1533940994, ___parser_1)); }
	inline Asn1StreamParser_t3208800844 * get_parser_1() const { return ___parser_1; }
	inline Asn1StreamParser_t3208800844 ** get_address_of_parser_1() { return &___parser_1; }
	inline void set_parser_1(Asn1StreamParser_t3208800844 * value)
	{
		___parser_1 = value;
		Il2CppCodeGenWriteBarrier(&___parser_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
