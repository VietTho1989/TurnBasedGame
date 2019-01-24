#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UIPrim2118950086.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_Rect3681755626.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UILine3583171457.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UILineR670022450.h"

// UnityEngine.Vector2[]
struct Vector2U5BU5D_t686124026;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UILineRenderer
struct  UILineRenderer_t3031355003  : public UIPrimitiveBase_t2118950086
{
public:
	// UnityEngine.Rect UnityEngine.UI.Extensions.UILineRenderer::m_UVRect
	Rect_t3681755626  ___m_UVRect_42;
	// UnityEngine.Vector2[] UnityEngine.UI.Extensions.UILineRenderer::m_points
	Vector2U5BU5D_t686124026* ___m_points_43;
	// System.Single UnityEngine.UI.Extensions.UILineRenderer::LineThickness
	float ___LineThickness_44;
	// System.Boolean UnityEngine.UI.Extensions.UILineRenderer::UseMargins
	bool ___UseMargins_45;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::Margin
	Vector2_t2243707579  ___Margin_46;
	// System.Boolean UnityEngine.UI.Extensions.UILineRenderer::relativeSize
	bool ___relativeSize_47;
	// System.Boolean UnityEngine.UI.Extensions.UILineRenderer::LineList
	bool ___LineList_48;
	// System.Boolean UnityEngine.UI.Extensions.UILineRenderer::LineCaps
	bool ___LineCaps_49;
	// UnityEngine.UI.Extensions.UILineRenderer/JoinType UnityEngine.UI.Extensions.UILineRenderer::LineJoins
	int32_t ___LineJoins_50;
	// UnityEngine.UI.Extensions.UILineRenderer/BezierType UnityEngine.UI.Extensions.UILineRenderer::BezierMode
	int32_t ___BezierMode_51;
	// System.Int32 UnityEngine.UI.Extensions.UILineRenderer::BezierSegmentsPerCurve
	int32_t ___BezierSegmentsPerCurve_52;

public:
	inline static int32_t get_offset_of_m_UVRect_42() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___m_UVRect_42)); }
	inline Rect_t3681755626  get_m_UVRect_42() const { return ___m_UVRect_42; }
	inline Rect_t3681755626 * get_address_of_m_UVRect_42() { return &___m_UVRect_42; }
	inline void set_m_UVRect_42(Rect_t3681755626  value)
	{
		___m_UVRect_42 = value;
	}

	inline static int32_t get_offset_of_m_points_43() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___m_points_43)); }
	inline Vector2U5BU5D_t686124026* get_m_points_43() const { return ___m_points_43; }
	inline Vector2U5BU5D_t686124026** get_address_of_m_points_43() { return &___m_points_43; }
	inline void set_m_points_43(Vector2U5BU5D_t686124026* value)
	{
		___m_points_43 = value;
		Il2CppCodeGenWriteBarrier(&___m_points_43, value);
	}

	inline static int32_t get_offset_of_LineThickness_44() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___LineThickness_44)); }
	inline float get_LineThickness_44() const { return ___LineThickness_44; }
	inline float* get_address_of_LineThickness_44() { return &___LineThickness_44; }
	inline void set_LineThickness_44(float value)
	{
		___LineThickness_44 = value;
	}

	inline static int32_t get_offset_of_UseMargins_45() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___UseMargins_45)); }
	inline bool get_UseMargins_45() const { return ___UseMargins_45; }
	inline bool* get_address_of_UseMargins_45() { return &___UseMargins_45; }
	inline void set_UseMargins_45(bool value)
	{
		___UseMargins_45 = value;
	}

	inline static int32_t get_offset_of_Margin_46() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___Margin_46)); }
	inline Vector2_t2243707579  get_Margin_46() const { return ___Margin_46; }
	inline Vector2_t2243707579 * get_address_of_Margin_46() { return &___Margin_46; }
	inline void set_Margin_46(Vector2_t2243707579  value)
	{
		___Margin_46 = value;
	}

	inline static int32_t get_offset_of_relativeSize_47() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___relativeSize_47)); }
	inline bool get_relativeSize_47() const { return ___relativeSize_47; }
	inline bool* get_address_of_relativeSize_47() { return &___relativeSize_47; }
	inline void set_relativeSize_47(bool value)
	{
		___relativeSize_47 = value;
	}

	inline static int32_t get_offset_of_LineList_48() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___LineList_48)); }
	inline bool get_LineList_48() const { return ___LineList_48; }
	inline bool* get_address_of_LineList_48() { return &___LineList_48; }
	inline void set_LineList_48(bool value)
	{
		___LineList_48 = value;
	}

	inline static int32_t get_offset_of_LineCaps_49() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___LineCaps_49)); }
	inline bool get_LineCaps_49() const { return ___LineCaps_49; }
	inline bool* get_address_of_LineCaps_49() { return &___LineCaps_49; }
	inline void set_LineCaps_49(bool value)
	{
		___LineCaps_49 = value;
	}

	inline static int32_t get_offset_of_LineJoins_50() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___LineJoins_50)); }
	inline int32_t get_LineJoins_50() const { return ___LineJoins_50; }
	inline int32_t* get_address_of_LineJoins_50() { return &___LineJoins_50; }
	inline void set_LineJoins_50(int32_t value)
	{
		___LineJoins_50 = value;
	}

	inline static int32_t get_offset_of_BezierMode_51() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___BezierMode_51)); }
	inline int32_t get_BezierMode_51() const { return ___BezierMode_51; }
	inline int32_t* get_address_of_BezierMode_51() { return &___BezierMode_51; }
	inline void set_BezierMode_51(int32_t value)
	{
		___BezierMode_51 = value;
	}

	inline static int32_t get_offset_of_BezierSegmentsPerCurve_52() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003, ___BezierSegmentsPerCurve_52)); }
	inline int32_t get_BezierSegmentsPerCurve_52() const { return ___BezierSegmentsPerCurve_52; }
	inline int32_t* get_address_of_BezierSegmentsPerCurve_52() { return &___BezierSegmentsPerCurve_52; }
	inline void set_BezierSegmentsPerCurve_52(int32_t value)
	{
		___BezierSegmentsPerCurve_52 = value;
	}
};

struct UILineRenderer_t3031355003_StaticFields
{
public:
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::UV_TOP_LEFT
	Vector2_t2243707579  ___UV_TOP_LEFT_33;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::UV_BOTTOM_LEFT
	Vector2_t2243707579  ___UV_BOTTOM_LEFT_34;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::UV_TOP_CENTER
	Vector2_t2243707579  ___UV_TOP_CENTER_35;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::UV_BOTTOM_CENTER
	Vector2_t2243707579  ___UV_BOTTOM_CENTER_36;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::UV_TOP_RIGHT
	Vector2_t2243707579  ___UV_TOP_RIGHT_37;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UILineRenderer::UV_BOTTOM_RIGHT
	Vector2_t2243707579  ___UV_BOTTOM_RIGHT_38;
	// UnityEngine.Vector2[] UnityEngine.UI.Extensions.UILineRenderer::startUvs
	Vector2U5BU5D_t686124026* ___startUvs_39;
	// UnityEngine.Vector2[] UnityEngine.UI.Extensions.UILineRenderer::middleUvs
	Vector2U5BU5D_t686124026* ___middleUvs_40;
	// UnityEngine.Vector2[] UnityEngine.UI.Extensions.UILineRenderer::endUvs
	Vector2U5BU5D_t686124026* ___endUvs_41;

public:
	inline static int32_t get_offset_of_UV_TOP_LEFT_33() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___UV_TOP_LEFT_33)); }
	inline Vector2_t2243707579  get_UV_TOP_LEFT_33() const { return ___UV_TOP_LEFT_33; }
	inline Vector2_t2243707579 * get_address_of_UV_TOP_LEFT_33() { return &___UV_TOP_LEFT_33; }
	inline void set_UV_TOP_LEFT_33(Vector2_t2243707579  value)
	{
		___UV_TOP_LEFT_33 = value;
	}

	inline static int32_t get_offset_of_UV_BOTTOM_LEFT_34() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___UV_BOTTOM_LEFT_34)); }
	inline Vector2_t2243707579  get_UV_BOTTOM_LEFT_34() const { return ___UV_BOTTOM_LEFT_34; }
	inline Vector2_t2243707579 * get_address_of_UV_BOTTOM_LEFT_34() { return &___UV_BOTTOM_LEFT_34; }
	inline void set_UV_BOTTOM_LEFT_34(Vector2_t2243707579  value)
	{
		___UV_BOTTOM_LEFT_34 = value;
	}

	inline static int32_t get_offset_of_UV_TOP_CENTER_35() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___UV_TOP_CENTER_35)); }
	inline Vector2_t2243707579  get_UV_TOP_CENTER_35() const { return ___UV_TOP_CENTER_35; }
	inline Vector2_t2243707579 * get_address_of_UV_TOP_CENTER_35() { return &___UV_TOP_CENTER_35; }
	inline void set_UV_TOP_CENTER_35(Vector2_t2243707579  value)
	{
		___UV_TOP_CENTER_35 = value;
	}

	inline static int32_t get_offset_of_UV_BOTTOM_CENTER_36() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___UV_BOTTOM_CENTER_36)); }
	inline Vector2_t2243707579  get_UV_BOTTOM_CENTER_36() const { return ___UV_BOTTOM_CENTER_36; }
	inline Vector2_t2243707579 * get_address_of_UV_BOTTOM_CENTER_36() { return &___UV_BOTTOM_CENTER_36; }
	inline void set_UV_BOTTOM_CENTER_36(Vector2_t2243707579  value)
	{
		___UV_BOTTOM_CENTER_36 = value;
	}

	inline static int32_t get_offset_of_UV_TOP_RIGHT_37() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___UV_TOP_RIGHT_37)); }
	inline Vector2_t2243707579  get_UV_TOP_RIGHT_37() const { return ___UV_TOP_RIGHT_37; }
	inline Vector2_t2243707579 * get_address_of_UV_TOP_RIGHT_37() { return &___UV_TOP_RIGHT_37; }
	inline void set_UV_TOP_RIGHT_37(Vector2_t2243707579  value)
	{
		___UV_TOP_RIGHT_37 = value;
	}

	inline static int32_t get_offset_of_UV_BOTTOM_RIGHT_38() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___UV_BOTTOM_RIGHT_38)); }
	inline Vector2_t2243707579  get_UV_BOTTOM_RIGHT_38() const { return ___UV_BOTTOM_RIGHT_38; }
	inline Vector2_t2243707579 * get_address_of_UV_BOTTOM_RIGHT_38() { return &___UV_BOTTOM_RIGHT_38; }
	inline void set_UV_BOTTOM_RIGHT_38(Vector2_t2243707579  value)
	{
		___UV_BOTTOM_RIGHT_38 = value;
	}

	inline static int32_t get_offset_of_startUvs_39() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___startUvs_39)); }
	inline Vector2U5BU5D_t686124026* get_startUvs_39() const { return ___startUvs_39; }
	inline Vector2U5BU5D_t686124026** get_address_of_startUvs_39() { return &___startUvs_39; }
	inline void set_startUvs_39(Vector2U5BU5D_t686124026* value)
	{
		___startUvs_39 = value;
		Il2CppCodeGenWriteBarrier(&___startUvs_39, value);
	}

	inline static int32_t get_offset_of_middleUvs_40() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___middleUvs_40)); }
	inline Vector2U5BU5D_t686124026* get_middleUvs_40() const { return ___middleUvs_40; }
	inline Vector2U5BU5D_t686124026** get_address_of_middleUvs_40() { return &___middleUvs_40; }
	inline void set_middleUvs_40(Vector2U5BU5D_t686124026* value)
	{
		___middleUvs_40 = value;
		Il2CppCodeGenWriteBarrier(&___middleUvs_40, value);
	}

	inline static int32_t get_offset_of_endUvs_41() { return static_cast<int32_t>(offsetof(UILineRenderer_t3031355003_StaticFields, ___endUvs_41)); }
	inline Vector2U5BU5D_t686124026* get_endUvs_41() const { return ___endUvs_41; }
	inline Vector2U5BU5D_t686124026** get_address_of_endUvs_41() { return &___endUvs_41; }
	inline void set_endUvs_41(Vector2U5BU5D_t686124026* value)
	{
		___endUvs_41 = value;
		Il2CppCodeGenWriteBarrier(&___endUvs_41, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
