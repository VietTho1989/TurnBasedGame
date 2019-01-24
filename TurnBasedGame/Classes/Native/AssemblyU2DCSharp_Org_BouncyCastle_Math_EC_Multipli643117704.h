#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Multipl2477536561.h"

// Org.BouncyCastle.Math.EC.ECCurve
struct ECCurve_t140895757;
// Org.BouncyCastle.Math.EC.Endo.GlvEndomorphism
struct GlvEndomorphism_t1261885190;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Multiplier.GlvMultiplier
struct  GlvMultiplier_t643117704  : public AbstractECMultiplier_t2477536561
{
public:
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Math.EC.Multiplier.GlvMultiplier::curve
	ECCurve_t140895757 * ___curve_0;
	// Org.BouncyCastle.Math.EC.Endo.GlvEndomorphism Org.BouncyCastle.Math.EC.Multiplier.GlvMultiplier::glvEndomorphism
	Il2CppObject * ___glvEndomorphism_1;

public:
	inline static int32_t get_offset_of_curve_0() { return static_cast<int32_t>(offsetof(GlvMultiplier_t643117704, ___curve_0)); }
	inline ECCurve_t140895757 * get_curve_0() const { return ___curve_0; }
	inline ECCurve_t140895757 ** get_address_of_curve_0() { return &___curve_0; }
	inline void set_curve_0(ECCurve_t140895757 * value)
	{
		___curve_0 = value;
		Il2CppCodeGenWriteBarrier(&___curve_0, value);
	}

	inline static int32_t get_offset_of_glvEndomorphism_1() { return static_cast<int32_t>(offsetof(GlvMultiplier_t643117704, ___glvEndomorphism_1)); }
	inline Il2CppObject * get_glvEndomorphism_1() const { return ___glvEndomorphism_1; }
	inline Il2CppObject ** get_address_of_glvEndomorphism_1() { return &___glvEndomorphism_1; }
	inline void set_glvEndomorphism_1(Il2CppObject * value)
	{
		___glvEndomorphism_1 = value;
		Il2CppCodeGenWriteBarrier(&___glvEndomorphism_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
