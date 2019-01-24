#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.Material
struct Material_t193706927;
// UnityEngine.Canvas
struct Canvas_t209405766;
// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t1172311765;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.Texture
struct Texture_t2243626319;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.SoftMaskScript
struct  SoftMaskScript_t947627439  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Material UnityEngine.UI.Extensions.SoftMaskScript::mat
	Material_t193706927 * ___mat_2;
	// UnityEngine.Canvas UnityEngine.UI.Extensions.SoftMaskScript::cachedCanvas
	Canvas_t209405766 * ___cachedCanvas_3;
	// UnityEngine.Transform UnityEngine.UI.Extensions.SoftMaskScript::cachedCanvasTransform
	Transform_t3275118058 * ___cachedCanvasTransform_4;
	// UnityEngine.Vector3[] UnityEngine.UI.Extensions.SoftMaskScript::m_WorldCorners
	Vector3U5BU5D_t1172311765* ___m_WorldCorners_5;
	// UnityEngine.Vector3[] UnityEngine.UI.Extensions.SoftMaskScript::m_CanvasCorners
	Vector3U5BU5D_t1172311765* ___m_CanvasCorners_6;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.SoftMaskScript::MaskArea
	RectTransform_t3349966182 * ___MaskArea_7;
	// UnityEngine.Texture UnityEngine.UI.Extensions.SoftMaskScript::AlphaMask
	Texture_t2243626319 * ___AlphaMask_8;
	// System.Single UnityEngine.UI.Extensions.SoftMaskScript::CutOff
	float ___CutOff_9;
	// System.Boolean UnityEngine.UI.Extensions.SoftMaskScript::HardBlend
	bool ___HardBlend_10;
	// System.Boolean UnityEngine.UI.Extensions.SoftMaskScript::FlipAlphaMask
	bool ___FlipAlphaMask_11;
	// System.Boolean UnityEngine.UI.Extensions.SoftMaskScript::DontClipMaskScalingRect
	bool ___DontClipMaskScalingRect_12;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.SoftMaskScript::maskOffset
	Vector2_t2243707579  ___maskOffset_13;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.SoftMaskScript::maskScale
	Vector2_t2243707579  ___maskScale_14;

public:
	inline static int32_t get_offset_of_mat_2() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___mat_2)); }
	inline Material_t193706927 * get_mat_2() const { return ___mat_2; }
	inline Material_t193706927 ** get_address_of_mat_2() { return &___mat_2; }
	inline void set_mat_2(Material_t193706927 * value)
	{
		___mat_2 = value;
		Il2CppCodeGenWriteBarrier(&___mat_2, value);
	}

	inline static int32_t get_offset_of_cachedCanvas_3() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___cachedCanvas_3)); }
	inline Canvas_t209405766 * get_cachedCanvas_3() const { return ___cachedCanvas_3; }
	inline Canvas_t209405766 ** get_address_of_cachedCanvas_3() { return &___cachedCanvas_3; }
	inline void set_cachedCanvas_3(Canvas_t209405766 * value)
	{
		___cachedCanvas_3 = value;
		Il2CppCodeGenWriteBarrier(&___cachedCanvas_3, value);
	}

	inline static int32_t get_offset_of_cachedCanvasTransform_4() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___cachedCanvasTransform_4)); }
	inline Transform_t3275118058 * get_cachedCanvasTransform_4() const { return ___cachedCanvasTransform_4; }
	inline Transform_t3275118058 ** get_address_of_cachedCanvasTransform_4() { return &___cachedCanvasTransform_4; }
	inline void set_cachedCanvasTransform_4(Transform_t3275118058 * value)
	{
		___cachedCanvasTransform_4 = value;
		Il2CppCodeGenWriteBarrier(&___cachedCanvasTransform_4, value);
	}

	inline static int32_t get_offset_of_m_WorldCorners_5() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___m_WorldCorners_5)); }
	inline Vector3U5BU5D_t1172311765* get_m_WorldCorners_5() const { return ___m_WorldCorners_5; }
	inline Vector3U5BU5D_t1172311765** get_address_of_m_WorldCorners_5() { return &___m_WorldCorners_5; }
	inline void set_m_WorldCorners_5(Vector3U5BU5D_t1172311765* value)
	{
		___m_WorldCorners_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_WorldCorners_5, value);
	}

	inline static int32_t get_offset_of_m_CanvasCorners_6() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___m_CanvasCorners_6)); }
	inline Vector3U5BU5D_t1172311765* get_m_CanvasCorners_6() const { return ___m_CanvasCorners_6; }
	inline Vector3U5BU5D_t1172311765** get_address_of_m_CanvasCorners_6() { return &___m_CanvasCorners_6; }
	inline void set_m_CanvasCorners_6(Vector3U5BU5D_t1172311765* value)
	{
		___m_CanvasCorners_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_CanvasCorners_6, value);
	}

	inline static int32_t get_offset_of_MaskArea_7() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___MaskArea_7)); }
	inline RectTransform_t3349966182 * get_MaskArea_7() const { return ___MaskArea_7; }
	inline RectTransform_t3349966182 ** get_address_of_MaskArea_7() { return &___MaskArea_7; }
	inline void set_MaskArea_7(RectTransform_t3349966182 * value)
	{
		___MaskArea_7 = value;
		Il2CppCodeGenWriteBarrier(&___MaskArea_7, value);
	}

	inline static int32_t get_offset_of_AlphaMask_8() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___AlphaMask_8)); }
	inline Texture_t2243626319 * get_AlphaMask_8() const { return ___AlphaMask_8; }
	inline Texture_t2243626319 ** get_address_of_AlphaMask_8() { return &___AlphaMask_8; }
	inline void set_AlphaMask_8(Texture_t2243626319 * value)
	{
		___AlphaMask_8 = value;
		Il2CppCodeGenWriteBarrier(&___AlphaMask_8, value);
	}

	inline static int32_t get_offset_of_CutOff_9() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___CutOff_9)); }
	inline float get_CutOff_9() const { return ___CutOff_9; }
	inline float* get_address_of_CutOff_9() { return &___CutOff_9; }
	inline void set_CutOff_9(float value)
	{
		___CutOff_9 = value;
	}

	inline static int32_t get_offset_of_HardBlend_10() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___HardBlend_10)); }
	inline bool get_HardBlend_10() const { return ___HardBlend_10; }
	inline bool* get_address_of_HardBlend_10() { return &___HardBlend_10; }
	inline void set_HardBlend_10(bool value)
	{
		___HardBlend_10 = value;
	}

	inline static int32_t get_offset_of_FlipAlphaMask_11() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___FlipAlphaMask_11)); }
	inline bool get_FlipAlphaMask_11() const { return ___FlipAlphaMask_11; }
	inline bool* get_address_of_FlipAlphaMask_11() { return &___FlipAlphaMask_11; }
	inline void set_FlipAlphaMask_11(bool value)
	{
		___FlipAlphaMask_11 = value;
	}

	inline static int32_t get_offset_of_DontClipMaskScalingRect_12() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___DontClipMaskScalingRect_12)); }
	inline bool get_DontClipMaskScalingRect_12() const { return ___DontClipMaskScalingRect_12; }
	inline bool* get_address_of_DontClipMaskScalingRect_12() { return &___DontClipMaskScalingRect_12; }
	inline void set_DontClipMaskScalingRect_12(bool value)
	{
		___DontClipMaskScalingRect_12 = value;
	}

	inline static int32_t get_offset_of_maskOffset_13() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___maskOffset_13)); }
	inline Vector2_t2243707579  get_maskOffset_13() const { return ___maskOffset_13; }
	inline Vector2_t2243707579 * get_address_of_maskOffset_13() { return &___maskOffset_13; }
	inline void set_maskOffset_13(Vector2_t2243707579  value)
	{
		___maskOffset_13 = value;
	}

	inline static int32_t get_offset_of_maskScale_14() { return static_cast<int32_t>(offsetof(SoftMaskScript_t947627439, ___maskScale_14)); }
	inline Vector2_t2243707579  get_maskScale_14() const { return ___maskScale_14; }
	inline Vector2_t2243707579 * get_address_of_maskScale_14() { return &___maskScale_14; }
	inline void set_maskScale_14(Vector2_t2243707579  value)
	{
		___maskScale_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
