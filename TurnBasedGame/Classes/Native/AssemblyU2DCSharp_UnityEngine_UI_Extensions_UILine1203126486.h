#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UIPrim2118950086.h"
#include "UnityEngine_UnityEngine_Rect3681755626.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.Vector2[]
struct Vector2U5BU5D_t686124026;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UILineTextureRenderer
struct  UILineTextureRenderer_t1203126486  : public UIPrimitiveBase_t2118950086
{
public:
	// UnityEngine.Rect UnityEngine.UI.Extensions.UILineTextureRenderer::m_UVRect
	Rect_t3681755626  ___m_UVRect_31;
	// UnityEngine.Vector2[] UnityEngine.UI.Extensions.UILineTextureRenderer::m_points
	Vector2U5BU5D_t686124026* ___m_points_32;
	// System.Single UnityEngine.UI.Extensions.UILineTextureRenderer::LineThickness
	float ___LineThickness_33;
	// System.Boolean UnityEngine.UI.Extensions.UILineTextureRenderer::UseMargins
	bool ___UseMargins_34;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineTextureRenderer::Margin
	Vector2_t2243707579  ___Margin_35;
	// System.Boolean UnityEngine.UI.Extensions.UILineTextureRenderer::relativeSize
	bool ___relativeSize_36;

public:
	inline static int32_t get_offset_of_m_UVRect_31() { return static_cast<int32_t>(offsetof(UILineTextureRenderer_t1203126486, ___m_UVRect_31)); }
	inline Rect_t3681755626  get_m_UVRect_31() const { return ___m_UVRect_31; }
	inline Rect_t3681755626 * get_address_of_m_UVRect_31() { return &___m_UVRect_31; }
	inline void set_m_UVRect_31(Rect_t3681755626  value)
	{
		___m_UVRect_31 = value;
	}

	inline static int32_t get_offset_of_m_points_32() { return static_cast<int32_t>(offsetof(UILineTextureRenderer_t1203126486, ___m_points_32)); }
	inline Vector2U5BU5D_t686124026* get_m_points_32() const { return ___m_points_32; }
	inline Vector2U5BU5D_t686124026** get_address_of_m_points_32() { return &___m_points_32; }
	inline void set_m_points_32(Vector2U5BU5D_t686124026* value)
	{
		___m_points_32 = value;
		Il2CppCodeGenWriteBarrier(&___m_points_32, value);
	}

	inline static int32_t get_offset_of_LineThickness_33() { return static_cast<int32_t>(offsetof(UILineTextureRenderer_t1203126486, ___LineThickness_33)); }
	inline float get_LineThickness_33() const { return ___LineThickness_33; }
	inline float* get_address_of_LineThickness_33() { return &___LineThickness_33; }
	inline void set_LineThickness_33(float value)
	{
		___LineThickness_33 = value;
	}

	inline static int32_t get_offset_of_UseMargins_34() { return static_cast<int32_t>(offsetof(UILineTextureRenderer_t1203126486, ___UseMargins_34)); }
	inline bool get_UseMargins_34() const { return ___UseMargins_34; }
	inline bool* get_address_of_UseMargins_34() { return &___UseMargins_34; }
	inline void set_UseMargins_34(bool value)
	{
		___UseMargins_34 = value;
	}

	inline static int32_t get_offset_of_Margin_35() { return static_cast<int32_t>(offsetof(UILineTextureRenderer_t1203126486, ___Margin_35)); }
	inline Vector2_t2243707579  get_Margin_35() const { return ___Margin_35; }
	inline Vector2_t2243707579 * get_address_of_Margin_35() { return &___Margin_35; }
	inline void set_Margin_35(Vector2_t2243707579  value)
	{
		___Margin_35 = value;
	}

	inline static int32_t get_offset_of_relativeSize_36() { return static_cast<int32_t>(offsetof(UILineTextureRenderer_t1203126486, ___relativeSize_36)); }
	inline bool get_relativeSize_36() const { return ___relativeSize_36; }
	inline bool* get_address_of_relativeSize_36() { return &___relativeSize_36; }
	inline void set_relativeSize_36(bool value)
	{
		___relativeSize_36 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
