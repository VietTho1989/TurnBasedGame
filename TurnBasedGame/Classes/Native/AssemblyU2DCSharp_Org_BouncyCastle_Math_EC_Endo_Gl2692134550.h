#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.ECCurve
struct ECCurve_t140895757;
// Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters
struct GlvTypeBParameters_t500309695;
// Org.BouncyCastle.Math.EC.ECPointMap
struct ECPointMap_t4206089746;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Endo.GlvTypeBEndomorphism
struct  GlvTypeBEndomorphism_t2692134550  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Math.EC.Endo.GlvTypeBEndomorphism::m_curve
	ECCurve_t140895757 * ___m_curve_0;
	// Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters Org.BouncyCastle.Math.EC.Endo.GlvTypeBEndomorphism::m_parameters
	GlvTypeBParameters_t500309695 * ___m_parameters_1;
	// Org.BouncyCastle.Math.EC.ECPointMap Org.BouncyCastle.Math.EC.Endo.GlvTypeBEndomorphism::m_pointMap
	Il2CppObject * ___m_pointMap_2;

public:
	inline static int32_t get_offset_of_m_curve_0() { return static_cast<int32_t>(offsetof(GlvTypeBEndomorphism_t2692134550, ___m_curve_0)); }
	inline ECCurve_t140895757 * get_m_curve_0() const { return ___m_curve_0; }
	inline ECCurve_t140895757 ** get_address_of_m_curve_0() { return &___m_curve_0; }
	inline void set_m_curve_0(ECCurve_t140895757 * value)
	{
		___m_curve_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_curve_0, value);
	}

	inline static int32_t get_offset_of_m_parameters_1() { return static_cast<int32_t>(offsetof(GlvTypeBEndomorphism_t2692134550, ___m_parameters_1)); }
	inline GlvTypeBParameters_t500309695 * get_m_parameters_1() const { return ___m_parameters_1; }
	inline GlvTypeBParameters_t500309695 ** get_address_of_m_parameters_1() { return &___m_parameters_1; }
	inline void set_m_parameters_1(GlvTypeBParameters_t500309695 * value)
	{
		___m_parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_parameters_1, value);
	}

	inline static int32_t get_offset_of_m_pointMap_2() { return static_cast<int32_t>(offsetof(GlvTypeBEndomorphism_t2692134550, ___m_pointMap_2)); }
	inline Il2CppObject * get_m_pointMap_2() const { return ___m_pointMap_2; }
	inline Il2CppObject ** get_address_of_m_pointMap_2() { return &___m_pointMap_2; }
	inline void set_m_pointMap_2(Il2CppObject * value)
	{
		___m_pointMap_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_pointMap_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
