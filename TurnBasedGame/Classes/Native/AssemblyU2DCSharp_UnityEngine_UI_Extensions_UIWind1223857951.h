#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.Canvas
struct Canvas_t209405766;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIWindowBase
struct  UIWindowBase_t1223857951  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIWindowBase::m_transform
	RectTransform_t3349966182 * ___m_transform_2;
	// System.Boolean UnityEngine.UI.Extensions.UIWindowBase::_isDragging
	bool ____isDragging_3;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.UIWindowBase::m_originalCoods
	Vector3_t2243707580  ___m_originalCoods_5;
	// UnityEngine.Canvas UnityEngine.UI.Extensions.UIWindowBase::m_canvas
	Canvas_t209405766 * ___m_canvas_6;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIWindowBase::m_canvasRectTransform
	RectTransform_t3349966182 * ___m_canvasRectTransform_7;
	// System.Int32 UnityEngine.UI.Extensions.UIWindowBase::KeepWindowInCanvas
	int32_t ___KeepWindowInCanvas_8;

public:
	inline static int32_t get_offset_of_m_transform_2() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951, ___m_transform_2)); }
	inline RectTransform_t3349966182 * get_m_transform_2() const { return ___m_transform_2; }
	inline RectTransform_t3349966182 ** get_address_of_m_transform_2() { return &___m_transform_2; }
	inline void set_m_transform_2(RectTransform_t3349966182 * value)
	{
		___m_transform_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_transform_2, value);
	}

	inline static int32_t get_offset_of__isDragging_3() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951, ____isDragging_3)); }
	inline bool get__isDragging_3() const { return ____isDragging_3; }
	inline bool* get_address_of__isDragging_3() { return &____isDragging_3; }
	inline void set__isDragging_3(bool value)
	{
		____isDragging_3 = value;
	}

	inline static int32_t get_offset_of_m_originalCoods_5() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951, ___m_originalCoods_5)); }
	inline Vector3_t2243707580  get_m_originalCoods_5() const { return ___m_originalCoods_5; }
	inline Vector3_t2243707580 * get_address_of_m_originalCoods_5() { return &___m_originalCoods_5; }
	inline void set_m_originalCoods_5(Vector3_t2243707580  value)
	{
		___m_originalCoods_5 = value;
	}

	inline static int32_t get_offset_of_m_canvas_6() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951, ___m_canvas_6)); }
	inline Canvas_t209405766 * get_m_canvas_6() const { return ___m_canvas_6; }
	inline Canvas_t209405766 ** get_address_of_m_canvas_6() { return &___m_canvas_6; }
	inline void set_m_canvas_6(Canvas_t209405766 * value)
	{
		___m_canvas_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_canvas_6, value);
	}

	inline static int32_t get_offset_of_m_canvasRectTransform_7() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951, ___m_canvasRectTransform_7)); }
	inline RectTransform_t3349966182 * get_m_canvasRectTransform_7() const { return ___m_canvasRectTransform_7; }
	inline RectTransform_t3349966182 ** get_address_of_m_canvasRectTransform_7() { return &___m_canvasRectTransform_7; }
	inline void set_m_canvasRectTransform_7(RectTransform_t3349966182 * value)
	{
		___m_canvasRectTransform_7 = value;
		Il2CppCodeGenWriteBarrier(&___m_canvasRectTransform_7, value);
	}

	inline static int32_t get_offset_of_KeepWindowInCanvas_8() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951, ___KeepWindowInCanvas_8)); }
	inline int32_t get_KeepWindowInCanvas_8() const { return ___KeepWindowInCanvas_8; }
	inline int32_t* get_address_of_KeepWindowInCanvas_8() { return &___KeepWindowInCanvas_8; }
	inline void set_KeepWindowInCanvas_8(int32_t value)
	{
		___KeepWindowInCanvas_8 = value;
	}
};

struct UIWindowBase_t1223857951_StaticFields
{
public:
	// System.Boolean UnityEngine.UI.Extensions.UIWindowBase::ResetCoords
	bool ___ResetCoords_4;

public:
	inline static int32_t get_offset_of_ResetCoords_4() { return static_cast<int32_t>(offsetof(UIWindowBase_t1223857951_StaticFields, ___ResetCoords_4)); }
	inline bool get_ResetCoords_4() const { return ___ResetCoords_4; }
	inline bool* get_address_of_ResetCoords_4() { return &___ResetCoords_4; }
	inline void set_ResetCoords_4(bool value)
	{
		___ResetCoords_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
