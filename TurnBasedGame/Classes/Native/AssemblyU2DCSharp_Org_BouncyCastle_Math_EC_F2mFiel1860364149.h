#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_ECField1092946118.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// Org.BouncyCastle.Math.EC.LongArray
struct LongArray_t194261203;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.F2mFieldElement
struct  F2mFieldElement_t1860364149  : public ECFieldElement_t1092946118
{
public:
	// System.Int32 Org.BouncyCastle.Math.EC.F2mFieldElement::representation
	int32_t ___representation_3;
	// System.Int32 Org.BouncyCastle.Math.EC.F2mFieldElement::m
	int32_t ___m_4;
	// System.Int32[] Org.BouncyCastle.Math.EC.F2mFieldElement::ks
	Int32U5BU5D_t3030399641* ___ks_5;
	// Org.BouncyCastle.Math.EC.LongArray Org.BouncyCastle.Math.EC.F2mFieldElement::x
	LongArray_t194261203 * ___x_6;

public:
	inline static int32_t get_offset_of_representation_3() { return static_cast<int32_t>(offsetof(F2mFieldElement_t1860364149, ___representation_3)); }
	inline int32_t get_representation_3() const { return ___representation_3; }
	inline int32_t* get_address_of_representation_3() { return &___representation_3; }
	inline void set_representation_3(int32_t value)
	{
		___representation_3 = value;
	}

	inline static int32_t get_offset_of_m_4() { return static_cast<int32_t>(offsetof(F2mFieldElement_t1860364149, ___m_4)); }
	inline int32_t get_m_4() const { return ___m_4; }
	inline int32_t* get_address_of_m_4() { return &___m_4; }
	inline void set_m_4(int32_t value)
	{
		___m_4 = value;
	}

	inline static int32_t get_offset_of_ks_5() { return static_cast<int32_t>(offsetof(F2mFieldElement_t1860364149, ___ks_5)); }
	inline Int32U5BU5D_t3030399641* get_ks_5() const { return ___ks_5; }
	inline Int32U5BU5D_t3030399641** get_address_of_ks_5() { return &___ks_5; }
	inline void set_ks_5(Int32U5BU5D_t3030399641* value)
	{
		___ks_5 = value;
		Il2CppCodeGenWriteBarrier(&___ks_5, value);
	}

	inline static int32_t get_offset_of_x_6() { return static_cast<int32_t>(offsetof(F2mFieldElement_t1860364149, ___x_6)); }
	inline LongArray_t194261203 * get_x_6() const { return ___x_6; }
	inline LongArray_t194261203 ** get_address_of_x_6() { return &___x_6; }
	inline void set_x_6(LongArray_t194261203 * value)
	{
		___x_6 = value;
		Il2CppCodeGenWriteBarrier(&___x_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
