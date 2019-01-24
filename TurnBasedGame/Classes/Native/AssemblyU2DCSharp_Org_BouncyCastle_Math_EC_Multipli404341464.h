#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.ECPoint[]
struct ECPointU5BU5D_t1061550629;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Multiplier.FixedPointPreCompInfo
struct  FixedPointPreCompInfo_t404341464  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECPoint[] Org.BouncyCastle.Math.EC.Multiplier.FixedPointPreCompInfo::m_preComp
	ECPointU5BU5D_t1061550629* ___m_preComp_0;
	// System.Int32 Org.BouncyCastle.Math.EC.Multiplier.FixedPointPreCompInfo::m_width
	int32_t ___m_width_1;

public:
	inline static int32_t get_offset_of_m_preComp_0() { return static_cast<int32_t>(offsetof(FixedPointPreCompInfo_t404341464, ___m_preComp_0)); }
	inline ECPointU5BU5D_t1061550629* get_m_preComp_0() const { return ___m_preComp_0; }
	inline ECPointU5BU5D_t1061550629** get_address_of_m_preComp_0() { return &___m_preComp_0; }
	inline void set_m_preComp_0(ECPointU5BU5D_t1061550629* value)
	{
		___m_preComp_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_preComp_0, value);
	}

	inline static int32_t get_offset_of_m_width_1() { return static_cast<int32_t>(offsetof(FixedPointPreCompInfo_t404341464, ___m_width_1)); }
	inline int32_t get_m_width_1() const { return ___m_width_1; }
	inline int32_t* get_address_of_m_width_1() { return &___m_width_1; }
	inline void set_m_width_1(int32_t value)
	{
		___m_width_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
