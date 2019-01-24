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
// Org.BouncyCastle.Math.EC.Endo.ECEndomorphism
struct ECEndomorphism_t1643381691;
// Org.BouncyCastle.Math.EC.Multiplier.ECMultiplier
struct ECMultiplier_t768735235;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.ECCurve/Config
struct  Config_t72665314  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Math.EC.ECCurve/Config::outer
	ECCurve_t140895757 * ___outer_0;
	// System.Int32 Org.BouncyCastle.Math.EC.ECCurve/Config::coord
	int32_t ___coord_1;
	// Org.BouncyCastle.Math.EC.Endo.ECEndomorphism Org.BouncyCastle.Math.EC.ECCurve/Config::endomorphism
	Il2CppObject * ___endomorphism_2;
	// Org.BouncyCastle.Math.EC.Multiplier.ECMultiplier Org.BouncyCastle.Math.EC.ECCurve/Config::multiplier
	Il2CppObject * ___multiplier_3;

public:
	inline static int32_t get_offset_of_outer_0() { return static_cast<int32_t>(offsetof(Config_t72665314, ___outer_0)); }
	inline ECCurve_t140895757 * get_outer_0() const { return ___outer_0; }
	inline ECCurve_t140895757 ** get_address_of_outer_0() { return &___outer_0; }
	inline void set_outer_0(ECCurve_t140895757 * value)
	{
		___outer_0 = value;
		Il2CppCodeGenWriteBarrier(&___outer_0, value);
	}

	inline static int32_t get_offset_of_coord_1() { return static_cast<int32_t>(offsetof(Config_t72665314, ___coord_1)); }
	inline int32_t get_coord_1() const { return ___coord_1; }
	inline int32_t* get_address_of_coord_1() { return &___coord_1; }
	inline void set_coord_1(int32_t value)
	{
		___coord_1 = value;
	}

	inline static int32_t get_offset_of_endomorphism_2() { return static_cast<int32_t>(offsetof(Config_t72665314, ___endomorphism_2)); }
	inline Il2CppObject * get_endomorphism_2() const { return ___endomorphism_2; }
	inline Il2CppObject ** get_address_of_endomorphism_2() { return &___endomorphism_2; }
	inline void set_endomorphism_2(Il2CppObject * value)
	{
		___endomorphism_2 = value;
		Il2CppCodeGenWriteBarrier(&___endomorphism_2, value);
	}

	inline static int32_t get_offset_of_multiplier_3() { return static_cast<int32_t>(offsetof(Config_t72665314, ___multiplier_3)); }
	inline Il2CppObject * get_multiplier_3() const { return ___multiplier_3; }
	inline Il2CppObject ** get_address_of_multiplier_3() { return &___multiplier_3; }
	inline void set_multiplier_3(Il2CppObject * value)
	{
		___multiplier_3 = value;
		Il2CppCodeGenWriteBarrier(&___multiplier_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
