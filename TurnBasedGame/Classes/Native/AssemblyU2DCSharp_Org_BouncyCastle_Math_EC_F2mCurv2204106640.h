#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Abstrac4137102866.h"

// Org.BouncyCastle.Math.EC.F2mPoint
struct F2mPoint_t2324796161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.F2mCurve
struct  F2mCurve_t2204106640  : public AbstractF2mCurve_t4137102866
{
public:
	// System.Int32 Org.BouncyCastle.Math.EC.F2mCurve::m
	int32_t ___m_18;
	// System.Int32 Org.BouncyCastle.Math.EC.F2mCurve::k1
	int32_t ___k1_19;
	// System.Int32 Org.BouncyCastle.Math.EC.F2mCurve::k2
	int32_t ___k2_20;
	// System.Int32 Org.BouncyCastle.Math.EC.F2mCurve::k3
	int32_t ___k3_21;
	// Org.BouncyCastle.Math.EC.F2mPoint Org.BouncyCastle.Math.EC.F2mCurve::m_infinity
	F2mPoint_t2324796161 * ___m_infinity_22;

public:
	inline static int32_t get_offset_of_m_18() { return static_cast<int32_t>(offsetof(F2mCurve_t2204106640, ___m_18)); }
	inline int32_t get_m_18() const { return ___m_18; }
	inline int32_t* get_address_of_m_18() { return &___m_18; }
	inline void set_m_18(int32_t value)
	{
		___m_18 = value;
	}

	inline static int32_t get_offset_of_k1_19() { return static_cast<int32_t>(offsetof(F2mCurve_t2204106640, ___k1_19)); }
	inline int32_t get_k1_19() const { return ___k1_19; }
	inline int32_t* get_address_of_k1_19() { return &___k1_19; }
	inline void set_k1_19(int32_t value)
	{
		___k1_19 = value;
	}

	inline static int32_t get_offset_of_k2_20() { return static_cast<int32_t>(offsetof(F2mCurve_t2204106640, ___k2_20)); }
	inline int32_t get_k2_20() const { return ___k2_20; }
	inline int32_t* get_address_of_k2_20() { return &___k2_20; }
	inline void set_k2_20(int32_t value)
	{
		___k2_20 = value;
	}

	inline static int32_t get_offset_of_k3_21() { return static_cast<int32_t>(offsetof(F2mCurve_t2204106640, ___k3_21)); }
	inline int32_t get_k3_21() const { return ___k3_21; }
	inline int32_t* get_address_of_k3_21() { return &___k3_21; }
	inline void set_k3_21(int32_t value)
	{
		___k3_21 = value;
	}

	inline static int32_t get_offset_of_m_infinity_22() { return static_cast<int32_t>(offsetof(F2mCurve_t2204106640, ___m_infinity_22)); }
	inline F2mPoint_t2324796161 * get_m_infinity_22() const { return ___m_infinity_22; }
	inline F2mPoint_t2324796161 ** get_address_of_m_infinity_22() { return &___m_infinity_22; }
	inline void set_m_infinity_22(F2mPoint_t2324796161 * value)
	{
		___m_infinity_22 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
