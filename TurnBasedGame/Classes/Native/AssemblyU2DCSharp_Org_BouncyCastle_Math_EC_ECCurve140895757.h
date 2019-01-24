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
// Org.BouncyCastle.Math.EC.ECFieldElement
struct ECFieldElement_t1092946118;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// Org.BouncyCastle.Math.EC.Endo.ECEndomorphism
struct ECEndomorphism_t1643381691;
// Org.BouncyCastle.Math.EC.Multiplier.ECMultiplier
struct ECMultiplier_t768735235;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.ECCurve
struct  ECCurve_t140895757  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.Field.IFiniteField Org.BouncyCastle.Math.EC.ECCurve::m_field
	Il2CppObject * ___m_field_8;
	// Org.BouncyCastle.Math.EC.ECFieldElement Org.BouncyCastle.Math.EC.ECCurve::m_a
	ECFieldElement_t1092946118 * ___m_a_9;
	// Org.BouncyCastle.Math.EC.ECFieldElement Org.BouncyCastle.Math.EC.ECCurve::m_b
	ECFieldElement_t1092946118 * ___m_b_10;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.ECCurve::m_order
	BigInteger_t4268922522 * ___m_order_11;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.ECCurve::m_cofactor
	BigInteger_t4268922522 * ___m_cofactor_12;
	// System.Int32 Org.BouncyCastle.Math.EC.ECCurve::m_coord
	int32_t ___m_coord_13;
	// Org.BouncyCastle.Math.EC.Endo.ECEndomorphism Org.BouncyCastle.Math.EC.ECCurve::m_endomorphism
	Il2CppObject * ___m_endomorphism_14;
	// Org.BouncyCastle.Math.EC.Multiplier.ECMultiplier Org.BouncyCastle.Math.EC.ECCurve::m_multiplier
	Il2CppObject * ___m_multiplier_15;

public:
	inline static int32_t get_offset_of_m_field_8() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_field_8)); }
	inline Il2CppObject * get_m_field_8() const { return ___m_field_8; }
	inline Il2CppObject ** get_address_of_m_field_8() { return &___m_field_8; }
	inline void set_m_field_8(Il2CppObject * value)
	{
		___m_field_8 = value;
		Il2CppCodeGenWriteBarrier(&___m_field_8, value);
	}

	inline static int32_t get_offset_of_m_a_9() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_a_9)); }
	inline ECFieldElement_t1092946118 * get_m_a_9() const { return ___m_a_9; }
	inline ECFieldElement_t1092946118 ** get_address_of_m_a_9() { return &___m_a_9; }
	inline void set_m_a_9(ECFieldElement_t1092946118 * value)
	{
		___m_a_9 = value;
		Il2CppCodeGenWriteBarrier(&___m_a_9, value);
	}

	inline static int32_t get_offset_of_m_b_10() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_b_10)); }
	inline ECFieldElement_t1092946118 * get_m_b_10() const { return ___m_b_10; }
	inline ECFieldElement_t1092946118 ** get_address_of_m_b_10() { return &___m_b_10; }
	inline void set_m_b_10(ECFieldElement_t1092946118 * value)
	{
		___m_b_10 = value;
		Il2CppCodeGenWriteBarrier(&___m_b_10, value);
	}

	inline static int32_t get_offset_of_m_order_11() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_order_11)); }
	inline BigInteger_t4268922522 * get_m_order_11() const { return ___m_order_11; }
	inline BigInteger_t4268922522 ** get_address_of_m_order_11() { return &___m_order_11; }
	inline void set_m_order_11(BigInteger_t4268922522 * value)
	{
		___m_order_11 = value;
		Il2CppCodeGenWriteBarrier(&___m_order_11, value);
	}

	inline static int32_t get_offset_of_m_cofactor_12() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_cofactor_12)); }
	inline BigInteger_t4268922522 * get_m_cofactor_12() const { return ___m_cofactor_12; }
	inline BigInteger_t4268922522 ** get_address_of_m_cofactor_12() { return &___m_cofactor_12; }
	inline void set_m_cofactor_12(BigInteger_t4268922522 * value)
	{
		___m_cofactor_12 = value;
		Il2CppCodeGenWriteBarrier(&___m_cofactor_12, value);
	}

	inline static int32_t get_offset_of_m_coord_13() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_coord_13)); }
	inline int32_t get_m_coord_13() const { return ___m_coord_13; }
	inline int32_t* get_address_of_m_coord_13() { return &___m_coord_13; }
	inline void set_m_coord_13(int32_t value)
	{
		___m_coord_13 = value;
	}

	inline static int32_t get_offset_of_m_endomorphism_14() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_endomorphism_14)); }
	inline Il2CppObject * get_m_endomorphism_14() const { return ___m_endomorphism_14; }
	inline Il2CppObject ** get_address_of_m_endomorphism_14() { return &___m_endomorphism_14; }
	inline void set_m_endomorphism_14(Il2CppObject * value)
	{
		___m_endomorphism_14 = value;
		Il2CppCodeGenWriteBarrier(&___m_endomorphism_14, value);
	}

	inline static int32_t get_offset_of_m_multiplier_15() { return static_cast<int32_t>(offsetof(ECCurve_t140895757, ___m_multiplier_15)); }
	inline Il2CppObject * get_m_multiplier_15() const { return ___m_multiplier_15; }
	inline Il2CppObject ** get_address_of_m_multiplier_15() { return &___m_multiplier_15; }
	inline void set_m_multiplier_15(Il2CppObject * value)
	{
		___m_multiplier_15 = value;
		Il2CppCodeGenWriteBarrier(&___m_multiplier_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
