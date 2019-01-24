#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.ECFieldElement[]
struct ECFieldElementU5BU5D_t1670892899;
// Org.BouncyCastle.Math.EC.ECCurve
struct ECCurve_t140895757;
// Org.BouncyCastle.Math.EC.ECFieldElement
struct ECFieldElement_t1092946118;
// System.Collections.IDictionary
struct IDictionary_t596158605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.ECPoint
struct  ECPoint_t626351532  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Math.EC.ECPoint::m_curve
	ECCurve_t140895757 * ___m_curve_1;
	// Org.BouncyCastle.Math.EC.ECFieldElement Org.BouncyCastle.Math.EC.ECPoint::m_x
	ECFieldElement_t1092946118 * ___m_x_2;
	// Org.BouncyCastle.Math.EC.ECFieldElement Org.BouncyCastle.Math.EC.ECPoint::m_y
	ECFieldElement_t1092946118 * ___m_y_3;
	// Org.BouncyCastle.Math.EC.ECFieldElement[] Org.BouncyCastle.Math.EC.ECPoint::m_zs
	ECFieldElementU5BU5D_t1670892899* ___m_zs_4;
	// System.Boolean Org.BouncyCastle.Math.EC.ECPoint::m_withCompression
	bool ___m_withCompression_5;
	// System.Collections.IDictionary Org.BouncyCastle.Math.EC.ECPoint::m_preCompTable
	Il2CppObject * ___m_preCompTable_6;

public:
	inline static int32_t get_offset_of_m_curve_1() { return static_cast<int32_t>(offsetof(ECPoint_t626351532, ___m_curve_1)); }
	inline ECCurve_t140895757 * get_m_curve_1() const { return ___m_curve_1; }
	inline ECCurve_t140895757 ** get_address_of_m_curve_1() { return &___m_curve_1; }
	inline void set_m_curve_1(ECCurve_t140895757 * value)
	{
		___m_curve_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_curve_1, value);
	}

	inline static int32_t get_offset_of_m_x_2() { return static_cast<int32_t>(offsetof(ECPoint_t626351532, ___m_x_2)); }
	inline ECFieldElement_t1092946118 * get_m_x_2() const { return ___m_x_2; }
	inline ECFieldElement_t1092946118 ** get_address_of_m_x_2() { return &___m_x_2; }
	inline void set_m_x_2(ECFieldElement_t1092946118 * value)
	{
		___m_x_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_x_2, value);
	}

	inline static int32_t get_offset_of_m_y_3() { return static_cast<int32_t>(offsetof(ECPoint_t626351532, ___m_y_3)); }
	inline ECFieldElement_t1092946118 * get_m_y_3() const { return ___m_y_3; }
	inline ECFieldElement_t1092946118 ** get_address_of_m_y_3() { return &___m_y_3; }
	inline void set_m_y_3(ECFieldElement_t1092946118 * value)
	{
		___m_y_3 = value;
		Il2CppCodeGenWriteBarrier(&___m_y_3, value);
	}

	inline static int32_t get_offset_of_m_zs_4() { return static_cast<int32_t>(offsetof(ECPoint_t626351532, ___m_zs_4)); }
	inline ECFieldElementU5BU5D_t1670892899* get_m_zs_4() const { return ___m_zs_4; }
	inline ECFieldElementU5BU5D_t1670892899** get_address_of_m_zs_4() { return &___m_zs_4; }
	inline void set_m_zs_4(ECFieldElementU5BU5D_t1670892899* value)
	{
		___m_zs_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_zs_4, value);
	}

	inline static int32_t get_offset_of_m_withCompression_5() { return static_cast<int32_t>(offsetof(ECPoint_t626351532, ___m_withCompression_5)); }
	inline bool get_m_withCompression_5() const { return ___m_withCompression_5; }
	inline bool* get_address_of_m_withCompression_5() { return &___m_withCompression_5; }
	inline void set_m_withCompression_5(bool value)
	{
		___m_withCompression_5 = value;
	}

	inline static int32_t get_offset_of_m_preCompTable_6() { return static_cast<int32_t>(offsetof(ECPoint_t626351532, ___m_preCompTable_6)); }
	inline Il2CppObject * get_m_preCompTable_6() const { return ___m_preCompTable_6; }
	inline Il2CppObject ** get_address_of_m_preCompTable_6() { return &___m_preCompTable_6; }
	inline void set_m_preCompTable_6(Il2CppObject * value)
	{
		___m_preCompTable_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_preCompTable_6, value);
	}
};

struct ECPoint_t626351532_StaticFields
{
public:
	// Org.BouncyCastle.Math.EC.ECFieldElement[] Org.BouncyCastle.Math.EC.ECPoint::EMPTY_ZS
	ECFieldElementU5BU5D_t1670892899* ___EMPTY_ZS_0;

public:
	inline static int32_t get_offset_of_EMPTY_ZS_0() { return static_cast<int32_t>(offsetof(ECPoint_t626351532_StaticFields, ___EMPTY_ZS_0)); }
	inline ECFieldElementU5BU5D_t1670892899* get_EMPTY_ZS_0() const { return ___EMPTY_ZS_0; }
	inline ECFieldElementU5BU5D_t1670892899** get_address_of_EMPTY_ZS_0() { return &___EMPTY_ZS_0; }
	inline void set_EMPTY_ZS_0(ECFieldElementU5BU5D_t1670892899* value)
	{
		___EMPTY_ZS_0 = value;
		Il2CppCodeGenWriteBarrier(&___EMPTY_ZS_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
