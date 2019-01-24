#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_EventSystems_UIBehaviou3960014691.h"

// System.Collections.Generic.List`1<UnityEngine.UI.ExtensionsToggle>
struct List_1_t2009014410;
// UnityEngine.UI.ExtensionsToggleGroup/ToggleGroupEvent
struct ToggleGroupEvent_t1021581118;
// UnityEngine.UI.ExtensionsToggle
struct ExtensionsToggle_t2639893278;
// System.Predicate`1<UnityEngine.UI.ExtensionsToggle>
struct Predicate_1_t1082863393;
// System.Func`2<UnityEngine.UI.ExtensionsToggle,System.Boolean>
struct Func_2_t1387565497;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.ExtensionsToggleGroup
struct  ExtensionsToggleGroup_t1289496689  : public UIBehaviour_t3960014691
{
public:
	// System.Boolean UnityEngine.UI.ExtensionsToggleGroup::m_AllowSwitchOff
	bool ___m_AllowSwitchOff_2;
	// System.Collections.Generic.List`1<UnityEngine.UI.ExtensionsToggle> UnityEngine.UI.ExtensionsToggleGroup::m_Toggles
	List_1_t2009014410 * ___m_Toggles_3;
	// UnityEngine.UI.ExtensionsToggleGroup/ToggleGroupEvent UnityEngine.UI.ExtensionsToggleGroup::onToggleGroupChanged
	ToggleGroupEvent_t1021581118 * ___onToggleGroupChanged_4;
	// UnityEngine.UI.ExtensionsToggleGroup/ToggleGroupEvent UnityEngine.UI.ExtensionsToggleGroup::onToggleGroupToggleChanged
	ToggleGroupEvent_t1021581118 * ___onToggleGroupToggleChanged_5;
	// UnityEngine.UI.ExtensionsToggle UnityEngine.UI.ExtensionsToggleGroup::<SelectedToggle>k__BackingField
	ExtensionsToggle_t2639893278 * ___U3CSelectedToggleU3Ek__BackingField_6;

public:
	inline static int32_t get_offset_of_m_AllowSwitchOff_2() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689, ___m_AllowSwitchOff_2)); }
	inline bool get_m_AllowSwitchOff_2() const { return ___m_AllowSwitchOff_2; }
	inline bool* get_address_of_m_AllowSwitchOff_2() { return &___m_AllowSwitchOff_2; }
	inline void set_m_AllowSwitchOff_2(bool value)
	{
		___m_AllowSwitchOff_2 = value;
	}

	inline static int32_t get_offset_of_m_Toggles_3() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689, ___m_Toggles_3)); }
	inline List_1_t2009014410 * get_m_Toggles_3() const { return ___m_Toggles_3; }
	inline List_1_t2009014410 ** get_address_of_m_Toggles_3() { return &___m_Toggles_3; }
	inline void set_m_Toggles_3(List_1_t2009014410 * value)
	{
		___m_Toggles_3 = value;
		Il2CppCodeGenWriteBarrier(&___m_Toggles_3, value);
	}

	inline static int32_t get_offset_of_onToggleGroupChanged_4() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689, ___onToggleGroupChanged_4)); }
	inline ToggleGroupEvent_t1021581118 * get_onToggleGroupChanged_4() const { return ___onToggleGroupChanged_4; }
	inline ToggleGroupEvent_t1021581118 ** get_address_of_onToggleGroupChanged_4() { return &___onToggleGroupChanged_4; }
	inline void set_onToggleGroupChanged_4(ToggleGroupEvent_t1021581118 * value)
	{
		___onToggleGroupChanged_4 = value;
		Il2CppCodeGenWriteBarrier(&___onToggleGroupChanged_4, value);
	}

	inline static int32_t get_offset_of_onToggleGroupToggleChanged_5() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689, ___onToggleGroupToggleChanged_5)); }
	inline ToggleGroupEvent_t1021581118 * get_onToggleGroupToggleChanged_5() const { return ___onToggleGroupToggleChanged_5; }
	inline ToggleGroupEvent_t1021581118 ** get_address_of_onToggleGroupToggleChanged_5() { return &___onToggleGroupToggleChanged_5; }
	inline void set_onToggleGroupToggleChanged_5(ToggleGroupEvent_t1021581118 * value)
	{
		___onToggleGroupToggleChanged_5 = value;
		Il2CppCodeGenWriteBarrier(&___onToggleGroupToggleChanged_5, value);
	}

	inline static int32_t get_offset_of_U3CSelectedToggleU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689, ___U3CSelectedToggleU3Ek__BackingField_6)); }
	inline ExtensionsToggle_t2639893278 * get_U3CSelectedToggleU3Ek__BackingField_6() const { return ___U3CSelectedToggleU3Ek__BackingField_6; }
	inline ExtensionsToggle_t2639893278 ** get_address_of_U3CSelectedToggleU3Ek__BackingField_6() { return &___U3CSelectedToggleU3Ek__BackingField_6; }
	inline void set_U3CSelectedToggleU3Ek__BackingField_6(ExtensionsToggle_t2639893278 * value)
	{
		___U3CSelectedToggleU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSelectedToggleU3Ek__BackingField_6, value);
	}
};

struct ExtensionsToggleGroup_t1289496689_StaticFields
{
public:
	// System.Predicate`1<UnityEngine.UI.ExtensionsToggle> UnityEngine.UI.ExtensionsToggleGroup::<>f__am$cache0
	Predicate_1_t1082863393 * ___U3CU3Ef__amU24cache0_7;
	// System.Func`2<UnityEngine.UI.ExtensionsToggle,System.Boolean> UnityEngine.UI.ExtensionsToggleGroup::<>f__am$cache1
	Func_2_t1387565497 * ___U3CU3Ef__amU24cache1_8;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_7() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689_StaticFields, ___U3CU3Ef__amU24cache0_7)); }
	inline Predicate_1_t1082863393 * get_U3CU3Ef__amU24cache0_7() const { return ___U3CU3Ef__amU24cache0_7; }
	inline Predicate_1_t1082863393 ** get_address_of_U3CU3Ef__amU24cache0_7() { return &___U3CU3Ef__amU24cache0_7; }
	inline void set_U3CU3Ef__amU24cache0_7(Predicate_1_t1082863393 * value)
	{
		___U3CU3Ef__amU24cache0_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_7, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_8() { return static_cast<int32_t>(offsetof(ExtensionsToggleGroup_t1289496689_StaticFields, ___U3CU3Ef__amU24cache1_8)); }
	inline Func_2_t1387565497 * get_U3CU3Ef__amU24cache1_8() const { return ___U3CU3Ef__amU24cache1_8; }
	inline Func_2_t1387565497 ** get_address_of_U3CU3Ef__amU24cache1_8() { return &___U3CU3Ef__amU24cache1_8; }
	inline void set_U3CU3Ef__amU24cache1_8(Func_2_t1387565497 * value)
	{
		___U3CU3Ef__amU24cache1_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
