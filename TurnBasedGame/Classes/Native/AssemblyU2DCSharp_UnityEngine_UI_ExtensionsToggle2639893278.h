#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_Selectable1490392188.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_ExtensionsToggle_2798030653.h"

// System.String
struct String_t;
// UnityEngine.UI.Graphic
struct Graphic_t2426225576;
// UnityEngine.UI.ExtensionsToggleGroup
struct ExtensionsToggleGroup_t1289496689;
// UnityEngine.UI.ExtensionsToggle/ToggleEvent
struct ToggleEvent_t2514518788;
// UnityEngine.UI.ExtensionsToggle/ToggleEventObject
struct ToggleEventObject_t2759065715;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.ExtensionsToggle
struct  ExtensionsToggle_t2639893278  : public Selectable_t1490392188
{
public:
	// System.String UnityEngine.UI.ExtensionsToggle::UniqueID
	String_t* ___UniqueID_16;
	// UnityEngine.UI.ExtensionsToggle/ToggleTransition UnityEngine.UI.ExtensionsToggle::toggleTransition
	int32_t ___toggleTransition_17;
	// UnityEngine.UI.Graphic UnityEngine.UI.ExtensionsToggle::graphic
	Graphic_t2426225576 * ___graphic_18;
	// UnityEngine.UI.ExtensionsToggleGroup UnityEngine.UI.ExtensionsToggle::m_Group
	ExtensionsToggleGroup_t1289496689 * ___m_Group_19;
	// UnityEngine.UI.ExtensionsToggle/ToggleEvent UnityEngine.UI.ExtensionsToggle::onValueChanged
	ToggleEvent_t2514518788 * ___onValueChanged_20;
	// UnityEngine.UI.ExtensionsToggle/ToggleEventObject UnityEngine.UI.ExtensionsToggle::onToggleChanged
	ToggleEventObject_t2759065715 * ___onToggleChanged_21;
	// System.Boolean UnityEngine.UI.ExtensionsToggle::m_IsOn
	bool ___m_IsOn_22;

public:
	inline static int32_t get_offset_of_UniqueID_16() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___UniqueID_16)); }
	inline String_t* get_UniqueID_16() const { return ___UniqueID_16; }
	inline String_t** get_address_of_UniqueID_16() { return &___UniqueID_16; }
	inline void set_UniqueID_16(String_t* value)
	{
		___UniqueID_16 = value;
		Il2CppCodeGenWriteBarrier(&___UniqueID_16, value);
	}

	inline static int32_t get_offset_of_toggleTransition_17() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___toggleTransition_17)); }
	inline int32_t get_toggleTransition_17() const { return ___toggleTransition_17; }
	inline int32_t* get_address_of_toggleTransition_17() { return &___toggleTransition_17; }
	inline void set_toggleTransition_17(int32_t value)
	{
		___toggleTransition_17 = value;
	}

	inline static int32_t get_offset_of_graphic_18() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___graphic_18)); }
	inline Graphic_t2426225576 * get_graphic_18() const { return ___graphic_18; }
	inline Graphic_t2426225576 ** get_address_of_graphic_18() { return &___graphic_18; }
	inline void set_graphic_18(Graphic_t2426225576 * value)
	{
		___graphic_18 = value;
		Il2CppCodeGenWriteBarrier(&___graphic_18, value);
	}

	inline static int32_t get_offset_of_m_Group_19() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___m_Group_19)); }
	inline ExtensionsToggleGroup_t1289496689 * get_m_Group_19() const { return ___m_Group_19; }
	inline ExtensionsToggleGroup_t1289496689 ** get_address_of_m_Group_19() { return &___m_Group_19; }
	inline void set_m_Group_19(ExtensionsToggleGroup_t1289496689 * value)
	{
		___m_Group_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_Group_19, value);
	}

	inline static int32_t get_offset_of_onValueChanged_20() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___onValueChanged_20)); }
	inline ToggleEvent_t2514518788 * get_onValueChanged_20() const { return ___onValueChanged_20; }
	inline ToggleEvent_t2514518788 ** get_address_of_onValueChanged_20() { return &___onValueChanged_20; }
	inline void set_onValueChanged_20(ToggleEvent_t2514518788 * value)
	{
		___onValueChanged_20 = value;
		Il2CppCodeGenWriteBarrier(&___onValueChanged_20, value);
	}

	inline static int32_t get_offset_of_onToggleChanged_21() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___onToggleChanged_21)); }
	inline ToggleEventObject_t2759065715 * get_onToggleChanged_21() const { return ___onToggleChanged_21; }
	inline ToggleEventObject_t2759065715 ** get_address_of_onToggleChanged_21() { return &___onToggleChanged_21; }
	inline void set_onToggleChanged_21(ToggleEventObject_t2759065715 * value)
	{
		___onToggleChanged_21 = value;
		Il2CppCodeGenWriteBarrier(&___onToggleChanged_21, value);
	}

	inline static int32_t get_offset_of_m_IsOn_22() { return static_cast<int32_t>(offsetof(ExtensionsToggle_t2639893278, ___m_IsOn_22)); }
	inline bool get_m_IsOn_22() const { return ___m_IsOn_22; }
	inline bool* get_address_of_m_IsOn_22() { return &___m_IsOn_22; }
	inline void set_m_IsOn_22(bool value)
	{
		___m_IsOn_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
