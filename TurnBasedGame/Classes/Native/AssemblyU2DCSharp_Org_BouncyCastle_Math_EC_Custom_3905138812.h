#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Abstrac4137102866.h"

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Point
struct SecT571R1Point_t3366117437;
// Org.BouncyCastle.Math.EC.Custom.Sec.SecT571FieldElement
struct SecT571FieldElement_t3353873688;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Curve
struct  SecT571R1Curve_t3905138812  : public AbstractF2mCurve_t4137102866
{
public:
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Point Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Curve::m_infinity
	SecT571R1Point_t3366117437 * ___m_infinity_18;

public:
	inline static int32_t get_offset_of_m_infinity_18() { return static_cast<int32_t>(offsetof(SecT571R1Curve_t3905138812, ___m_infinity_18)); }
	inline SecT571R1Point_t3366117437 * get_m_infinity_18() const { return ___m_infinity_18; }
	inline SecT571R1Point_t3366117437 ** get_address_of_m_infinity_18() { return &___m_infinity_18; }
	inline void set_m_infinity_18(SecT571R1Point_t3366117437 * value)
	{
		___m_infinity_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_18, value);
	}
};

struct SecT571R1Curve_t3905138812_StaticFields
{
public:
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecT571FieldElement Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Curve::SecT571R1_B
	SecT571FieldElement_t3353873688 * ___SecT571R1_B_19;
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecT571FieldElement Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Curve::SecT571R1_B_SQRT
	SecT571FieldElement_t3353873688 * ___SecT571R1_B_SQRT_20;

public:
	inline static int32_t get_offset_of_SecT571R1_B_19() { return static_cast<int32_t>(offsetof(SecT571R1Curve_t3905138812_StaticFields, ___SecT571R1_B_19)); }
	inline SecT571FieldElement_t3353873688 * get_SecT571R1_B_19() const { return ___SecT571R1_B_19; }
	inline SecT571FieldElement_t3353873688 ** get_address_of_SecT571R1_B_19() { return &___SecT571R1_B_19; }
	inline void set_SecT571R1_B_19(SecT571FieldElement_t3353873688 * value)
	{
		___SecT571R1_B_19 = value;
		Il2CppCodeGenWriteBarrier(&___SecT571R1_B_19, value);
	}

	inline static int32_t get_offset_of_SecT571R1_B_SQRT_20() { return static_cast<int32_t>(offsetof(SecT571R1Curve_t3905138812_StaticFields, ___SecT571R1_B_SQRT_20)); }
	inline SecT571FieldElement_t3353873688 * get_SecT571R1_B_SQRT_20() const { return ___SecT571R1_B_SQRT_20; }
	inline SecT571FieldElement_t3353873688 ** get_address_of_SecT571R1_B_SQRT_20() { return &___SecT571R1_B_SQRT_20; }
	inline void set_SecT571R1_B_SQRT_20(SecT571FieldElement_t3353873688 * value)
	{
		___SecT571R1_B_SQRT_20 = value;
		Il2CppCodeGenWriteBarrier(&___SecT571R1_B_SQRT_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
