#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.Field.IFiniteField
struct IFiniteField_t3190882390;
// Org.BouncyCastle.Math.Field.IPolynomial
struct IPolynomial_t3525073035;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.Field.GenericPolynomialExtensionField
struct  GenericPolynomialExtensionField_t3677945350  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.Field.IFiniteField Org.BouncyCastle.Math.Field.GenericPolynomialExtensionField::subfield
	Il2CppObject * ___subfield_0;
	// Org.BouncyCastle.Math.Field.IPolynomial Org.BouncyCastle.Math.Field.GenericPolynomialExtensionField::minimalPolynomial
	Il2CppObject * ___minimalPolynomial_1;

public:
	inline static int32_t get_offset_of_subfield_0() { return static_cast<int32_t>(offsetof(GenericPolynomialExtensionField_t3677945350, ___subfield_0)); }
	inline Il2CppObject * get_subfield_0() const { return ___subfield_0; }
	inline Il2CppObject ** get_address_of_subfield_0() { return &___subfield_0; }
	inline void set_subfield_0(Il2CppObject * value)
	{
		___subfield_0 = value;
		Il2CppCodeGenWriteBarrier(&___subfield_0, value);
	}

	inline static int32_t get_offset_of_minimalPolynomial_1() { return static_cast<int32_t>(offsetof(GenericPolynomialExtensionField_t3677945350, ___minimalPolynomial_1)); }
	inline Il2CppObject * get_minimalPolynomial_1() const { return ___minimalPolynomial_1; }
	inline Il2CppObject ** get_address_of_minimalPolynomial_1() { return &___minimalPolynomial_1; }
	inline void set_minimalPolynomial_1(Il2CppObject * value)
	{
		___minimalPolynomial_1 = value;
		Il2CppCodeGenWriteBarrier(&___minimalPolynomial_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
