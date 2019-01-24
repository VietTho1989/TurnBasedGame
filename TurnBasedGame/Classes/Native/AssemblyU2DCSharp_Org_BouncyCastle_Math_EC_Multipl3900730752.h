#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.AbstractF2mPoint[]
struct AbstractF2mPointU5BU5D_t1514048876;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Multiplier.WTauNafPreCompInfo
struct  WTauNafPreCompInfo_t3900730752  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.AbstractF2mPoint[] Org.BouncyCastle.Math.EC.Multiplier.WTauNafPreCompInfo::m_preComp
	AbstractF2mPointU5BU5D_t1514048876* ___m_preComp_0;

public:
	inline static int32_t get_offset_of_m_preComp_0() { return static_cast<int32_t>(offsetof(WTauNafPreCompInfo_t3900730752, ___m_preComp_0)); }
	inline AbstractF2mPointU5BU5D_t1514048876* get_m_preComp_0() const { return ___m_preComp_0; }
	inline AbstractF2mPointU5BU5D_t1514048876** get_address_of_m_preComp_0() { return &___m_preComp_0; }
	inline void set_m_preComp_0(AbstractF2mPointU5BU5D_t1514048876* value)
	{
		___m_preComp_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_preComp_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
