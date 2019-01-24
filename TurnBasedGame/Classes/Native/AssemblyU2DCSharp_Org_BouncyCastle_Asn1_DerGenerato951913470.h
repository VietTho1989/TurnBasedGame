#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Generat986026348.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerGenerator
struct  DerGenerator_t951913470  : public Asn1Generator_t986026348
{
public:
	// System.Boolean Org.BouncyCastle.Asn1.DerGenerator::_tagged
	bool ____tagged_1;
	// System.Boolean Org.BouncyCastle.Asn1.DerGenerator::_isExplicit
	bool ____isExplicit_2;
	// System.Int32 Org.BouncyCastle.Asn1.DerGenerator::_tagNo
	int32_t ____tagNo_3;

public:
	inline static int32_t get_offset_of__tagged_1() { return static_cast<int32_t>(offsetof(DerGenerator_t951913470, ____tagged_1)); }
	inline bool get__tagged_1() const { return ____tagged_1; }
	inline bool* get_address_of__tagged_1() { return &____tagged_1; }
	inline void set__tagged_1(bool value)
	{
		____tagged_1 = value;
	}

	inline static int32_t get_offset_of__isExplicit_2() { return static_cast<int32_t>(offsetof(DerGenerator_t951913470, ____isExplicit_2)); }
	inline bool get__isExplicit_2() const { return ____isExplicit_2; }
	inline bool* get_address_of__isExplicit_2() { return &____isExplicit_2; }
	inline void set__isExplicit_2(bool value)
	{
		____isExplicit_2 = value;
	}

	inline static int32_t get_offset_of__tagNo_3() { return static_cast<int32_t>(offsetof(DerGenerator_t951913470, ____tagNo_3)); }
	inline int32_t get__tagNo_3() const { return ____tagNo_3; }
	inline int32_t* get_address_of__tagNo_3() { return &____tagNo_3; }
	inline void set__tagNo_3(int32_t value)
	{
		____tagNo_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
