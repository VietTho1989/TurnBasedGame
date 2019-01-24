#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_Toggle3976754468.h"

// UnityEngine.UI.Extensions.Accordion
struct Accordion_t2257195762;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.LayoutElement
struct LayoutElement_t2808691390;
// UnityEngine.UI.Extensions.Tweens.TweenRunner`1<UnityEngine.UI.Extensions.Tweens.FloatTween>
struct TweenRunner_1_t161549504;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.AccordionElement
struct  AccordionElement_t287868148  : public Toggle_t3976754468
{
public:
	// System.Single UnityEngine.UI.Extensions.AccordionElement::m_MinHeight
	float ___m_MinHeight_21;
	// UnityEngine.UI.Extensions.Accordion UnityEngine.UI.Extensions.AccordionElement::m_Accordion
	Accordion_t2257195762 * ___m_Accordion_22;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AccordionElement::m_RectTransform
	RectTransform_t3349966182 * ___m_RectTransform_23;
	// UnityEngine.UI.LayoutElement UnityEngine.UI.Extensions.AccordionElement::m_LayoutElement
	LayoutElement_t2808691390 * ___m_LayoutElement_24;
	// UnityEngine.UI.Extensions.Tweens.TweenRunner`1<UnityEngine.UI.Extensions.Tweens.FloatTween> UnityEngine.UI.Extensions.AccordionElement::m_FloatTweenRunner
	TweenRunner_1_t161549504 * ___m_FloatTweenRunner_25;

public:
	inline static int32_t get_offset_of_m_MinHeight_21() { return static_cast<int32_t>(offsetof(AccordionElement_t287868148, ___m_MinHeight_21)); }
	inline float get_m_MinHeight_21() const { return ___m_MinHeight_21; }
	inline float* get_address_of_m_MinHeight_21() { return &___m_MinHeight_21; }
	inline void set_m_MinHeight_21(float value)
	{
		___m_MinHeight_21 = value;
	}

	inline static int32_t get_offset_of_m_Accordion_22() { return static_cast<int32_t>(offsetof(AccordionElement_t287868148, ___m_Accordion_22)); }
	inline Accordion_t2257195762 * get_m_Accordion_22() const { return ___m_Accordion_22; }
	inline Accordion_t2257195762 ** get_address_of_m_Accordion_22() { return &___m_Accordion_22; }
	inline void set_m_Accordion_22(Accordion_t2257195762 * value)
	{
		___m_Accordion_22 = value;
		Il2CppCodeGenWriteBarrier(&___m_Accordion_22, value);
	}

	inline static int32_t get_offset_of_m_RectTransform_23() { return static_cast<int32_t>(offsetof(AccordionElement_t287868148, ___m_RectTransform_23)); }
	inline RectTransform_t3349966182 * get_m_RectTransform_23() const { return ___m_RectTransform_23; }
	inline RectTransform_t3349966182 ** get_address_of_m_RectTransform_23() { return &___m_RectTransform_23; }
	inline void set_m_RectTransform_23(RectTransform_t3349966182 * value)
	{
		___m_RectTransform_23 = value;
		Il2CppCodeGenWriteBarrier(&___m_RectTransform_23, value);
	}

	inline static int32_t get_offset_of_m_LayoutElement_24() { return static_cast<int32_t>(offsetof(AccordionElement_t287868148, ___m_LayoutElement_24)); }
	inline LayoutElement_t2808691390 * get_m_LayoutElement_24() const { return ___m_LayoutElement_24; }
	inline LayoutElement_t2808691390 ** get_address_of_m_LayoutElement_24() { return &___m_LayoutElement_24; }
	inline void set_m_LayoutElement_24(LayoutElement_t2808691390 * value)
	{
		___m_LayoutElement_24 = value;
		Il2CppCodeGenWriteBarrier(&___m_LayoutElement_24, value);
	}

	inline static int32_t get_offset_of_m_FloatTweenRunner_25() { return static_cast<int32_t>(offsetof(AccordionElement_t287868148, ___m_FloatTweenRunner_25)); }
	inline TweenRunner_1_t161549504 * get_m_FloatTweenRunner_25() const { return ___m_FloatTweenRunner_25; }
	inline TweenRunner_1_t161549504 ** get_address_of_m_FloatTweenRunner_25() { return &___m_FloatTweenRunner_25; }
	inline void set_m_FloatTweenRunner_25(TweenRunner_1_t161549504 * value)
	{
		___m_FloatTweenRunner_25 = value;
		Il2CppCodeGenWriteBarrier(&___m_FloatTweenRunner_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
