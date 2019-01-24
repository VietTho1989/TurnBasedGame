#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UIPrim2118950086.h"

// System.Single[]
struct SingleU5BU5D_t577127397;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIPolygon
struct  UIPolygon_t4199244354  : public UIPrimitiveBase_t2118950086
{
public:
	// System.Boolean UnityEngine.UI.Extensions.UIPolygon::fill
	bool ___fill_31;
	// System.Single UnityEngine.UI.Extensions.UIPolygon::thickness
	float ___thickness_32;
	// System.Int32 UnityEngine.UI.Extensions.UIPolygon::sides
	int32_t ___sides_33;
	// System.Single UnityEngine.UI.Extensions.UIPolygon::rotation
	float ___rotation_34;
	// System.Single[] UnityEngine.UI.Extensions.UIPolygon::VerticesDistances
	SingleU5BU5D_t577127397* ___VerticesDistances_35;
	// System.Single UnityEngine.UI.Extensions.UIPolygon::size
	float ___size_36;

public:
	inline static int32_t get_offset_of_fill_31() { return static_cast<int32_t>(offsetof(UIPolygon_t4199244354, ___fill_31)); }
	inline bool get_fill_31() const { return ___fill_31; }
	inline bool* get_address_of_fill_31() { return &___fill_31; }
	inline void set_fill_31(bool value)
	{
		___fill_31 = value;
	}

	inline static int32_t get_offset_of_thickness_32() { return static_cast<int32_t>(offsetof(UIPolygon_t4199244354, ___thickness_32)); }
	inline float get_thickness_32() const { return ___thickness_32; }
	inline float* get_address_of_thickness_32() { return &___thickness_32; }
	inline void set_thickness_32(float value)
	{
		___thickness_32 = value;
	}

	inline static int32_t get_offset_of_sides_33() { return static_cast<int32_t>(offsetof(UIPolygon_t4199244354, ___sides_33)); }
	inline int32_t get_sides_33() const { return ___sides_33; }
	inline int32_t* get_address_of_sides_33() { return &___sides_33; }
	inline void set_sides_33(int32_t value)
	{
		___sides_33 = value;
	}

	inline static int32_t get_offset_of_rotation_34() { return static_cast<int32_t>(offsetof(UIPolygon_t4199244354, ___rotation_34)); }
	inline float get_rotation_34() const { return ___rotation_34; }
	inline float* get_address_of_rotation_34() { return &___rotation_34; }
	inline void set_rotation_34(float value)
	{
		___rotation_34 = value;
	}

	inline static int32_t get_offset_of_VerticesDistances_35() { return static_cast<int32_t>(offsetof(UIPolygon_t4199244354, ___VerticesDistances_35)); }
	inline SingleU5BU5D_t577127397* get_VerticesDistances_35() const { return ___VerticesDistances_35; }
	inline SingleU5BU5D_t577127397** get_address_of_VerticesDistances_35() { return &___VerticesDistances_35; }
	inline void set_VerticesDistances_35(SingleU5BU5D_t577127397* value)
	{
		___VerticesDistances_35 = value;
		Il2CppCodeGenWriteBarrier(&___VerticesDistances_35, value);
	}

	inline static int32_t get_offset_of_size_36() { return static_cast<int32_t>(offsetof(UIPolygon_t4199244354, ___size_36)); }
	inline float get_size_36() const { return ___size_36; }
	inline float* get_address_of_size_36() { return &___size_36; }
	inline void set_size_36(float value)
	{
		___size_36 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
