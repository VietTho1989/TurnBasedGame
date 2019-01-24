#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_ECField1092946118.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// System.UInt32[]
struct UInt32U5BU5D_t59386216;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Custom.Sec.SecP256R1FieldElement
struct  SecP256R1FieldElement_t1196028363  : public ECFieldElement_t1092946118
{
public:
	// System.UInt32[] Org.BouncyCastle.Math.EC.Custom.Sec.SecP256R1FieldElement::x
	UInt32U5BU5D_t59386216* ___x_1;

public:
	inline static int32_t get_offset_of_x_1() { return static_cast<int32_t>(offsetof(SecP256R1FieldElement_t1196028363, ___x_1)); }
	inline UInt32U5BU5D_t59386216* get_x_1() const { return ___x_1; }
	inline UInt32U5BU5D_t59386216** get_address_of_x_1() { return &___x_1; }
	inline void set_x_1(UInt32U5BU5D_t59386216* value)
	{
		___x_1 = value;
		Il2CppCodeGenWriteBarrier(&___x_1, value);
	}
};

struct SecP256R1FieldElement_t1196028363_StaticFields
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Custom.Sec.SecP256R1FieldElement::Q
	BigInteger_t4268922522 * ___Q_0;

public:
	inline static int32_t get_offset_of_Q_0() { return static_cast<int32_t>(offsetof(SecP256R1FieldElement_t1196028363_StaticFields, ___Q_0)); }
	inline BigInteger_t4268922522 * get_Q_0() const { return ___Q_0; }
	inline BigInteger_t4268922522 ** get_address_of_Q_0() { return &___Q_0; }
	inline void set_Q_0(BigInteger_t4268922522 * value)
	{
		___Q_0 = value;
		Il2CppCodeGenWriteBarrier(&___Q_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
