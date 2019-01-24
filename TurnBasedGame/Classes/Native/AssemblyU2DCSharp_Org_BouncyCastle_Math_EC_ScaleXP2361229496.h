#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.ECFieldElement
struct ECFieldElement_t1092946118;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.ScaleXPointMap
struct  ScaleXPointMap_t2361229496  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECFieldElement Org.BouncyCastle.Math.EC.ScaleXPointMap::scale
	ECFieldElement_t1092946118 * ___scale_0;

public:
	inline static int32_t get_offset_of_scale_0() { return static_cast<int32_t>(offsetof(ScaleXPointMap_t2361229496, ___scale_0)); }
	inline ECFieldElement_t1092946118 * get_scale_0() const { return ___scale_0; }
	inline ECFieldElement_t1092946118 ** get_address_of_scale_0() { return &___scale_0; }
	inline void set_scale_0(ECFieldElement_t1092946118 * value)
	{
		___scale_0 = value;
		Il2CppCodeGenWriteBarrier(&___scale_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
