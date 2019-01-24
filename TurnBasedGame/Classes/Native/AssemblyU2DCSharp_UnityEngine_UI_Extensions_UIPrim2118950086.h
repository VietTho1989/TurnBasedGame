#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_MaskableGraphic540192618.h"

// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIPrimitiveBase
struct  UIPrimitiveBase_t2118950086  : public MaskableGraphic_t540192618
{
public:
	// UnityEngine.Sprite UnityEngine.UI.Extensions.UIPrimitiveBase::m_Sprite
	Sprite_t309593783 * ___m_Sprite_28;
	// UnityEngine.Sprite UnityEngine.UI.Extensions.UIPrimitiveBase::m_OverrideSprite
	Sprite_t309593783 * ___m_OverrideSprite_29;
	// System.Single UnityEngine.UI.Extensions.UIPrimitiveBase::m_EventAlphaThreshold
	float ___m_EventAlphaThreshold_30;

public:
	inline static int32_t get_offset_of_m_Sprite_28() { return static_cast<int32_t>(offsetof(UIPrimitiveBase_t2118950086, ___m_Sprite_28)); }
	inline Sprite_t309593783 * get_m_Sprite_28() const { return ___m_Sprite_28; }
	inline Sprite_t309593783 ** get_address_of_m_Sprite_28() { return &___m_Sprite_28; }
	inline void set_m_Sprite_28(Sprite_t309593783 * value)
	{
		___m_Sprite_28 = value;
		Il2CppCodeGenWriteBarrier(&___m_Sprite_28, value);
	}

	inline static int32_t get_offset_of_m_OverrideSprite_29() { return static_cast<int32_t>(offsetof(UIPrimitiveBase_t2118950086, ___m_OverrideSprite_29)); }
	inline Sprite_t309593783 * get_m_OverrideSprite_29() const { return ___m_OverrideSprite_29; }
	inline Sprite_t309593783 ** get_address_of_m_OverrideSprite_29() { return &___m_OverrideSprite_29; }
	inline void set_m_OverrideSprite_29(Sprite_t309593783 * value)
	{
		___m_OverrideSprite_29 = value;
		Il2CppCodeGenWriteBarrier(&___m_OverrideSprite_29, value);
	}

	inline static int32_t get_offset_of_m_EventAlphaThreshold_30() { return static_cast<int32_t>(offsetof(UIPrimitiveBase_t2118950086, ___m_EventAlphaThreshold_30)); }
	inline float get_m_EventAlphaThreshold_30() const { return ___m_EventAlphaThreshold_30; }
	inline float* get_address_of_m_EventAlphaThreshold_30() { return &___m_EventAlphaThreshold_30; }
	inline void set_m_EventAlphaThreshold_30(float value)
	{
		___m_EventAlphaThreshold_30 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
