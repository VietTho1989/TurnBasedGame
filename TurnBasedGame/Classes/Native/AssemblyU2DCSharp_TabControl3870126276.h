#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Collections.Generic.List`1<TabControlEntry>
struct List_1_t3039065820;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TabControl
struct  TabControl_t3870126276  : public MonoBehaviour_t1158329972
{
public:
	// System.Collections.Generic.List`1<TabControlEntry> TabControl::entries
	List_1_t3039065820 * ___entries_2;
	// UnityEngine.GameObject TabControl::panelContainer
	GameObject_t1756533147 * ___panelContainer_3;
	// UnityEngine.GameObject TabControl::tabContainer
	GameObject_t1756533147 * ___tabContainer_4;
	// UnityEngine.GameObject TabControl::tabPrefab
	GameObject_t1756533147 * ___tabPrefab_5;
	// UnityEngine.GameObject TabControl::panelPrefab
	GameObject_t1756533147 * ___panelPrefab_6;

public:
	inline static int32_t get_offset_of_entries_2() { return static_cast<int32_t>(offsetof(TabControl_t3870126276, ___entries_2)); }
	inline List_1_t3039065820 * get_entries_2() const { return ___entries_2; }
	inline List_1_t3039065820 ** get_address_of_entries_2() { return &___entries_2; }
	inline void set_entries_2(List_1_t3039065820 * value)
	{
		___entries_2 = value;
		Il2CppCodeGenWriteBarrier(&___entries_2, value);
	}

	inline static int32_t get_offset_of_panelContainer_3() { return static_cast<int32_t>(offsetof(TabControl_t3870126276, ___panelContainer_3)); }
	inline GameObject_t1756533147 * get_panelContainer_3() const { return ___panelContainer_3; }
	inline GameObject_t1756533147 ** get_address_of_panelContainer_3() { return &___panelContainer_3; }
	inline void set_panelContainer_3(GameObject_t1756533147 * value)
	{
		___panelContainer_3 = value;
		Il2CppCodeGenWriteBarrier(&___panelContainer_3, value);
	}

	inline static int32_t get_offset_of_tabContainer_4() { return static_cast<int32_t>(offsetof(TabControl_t3870126276, ___tabContainer_4)); }
	inline GameObject_t1756533147 * get_tabContainer_4() const { return ___tabContainer_4; }
	inline GameObject_t1756533147 ** get_address_of_tabContainer_4() { return &___tabContainer_4; }
	inline void set_tabContainer_4(GameObject_t1756533147 * value)
	{
		___tabContainer_4 = value;
		Il2CppCodeGenWriteBarrier(&___tabContainer_4, value);
	}

	inline static int32_t get_offset_of_tabPrefab_5() { return static_cast<int32_t>(offsetof(TabControl_t3870126276, ___tabPrefab_5)); }
	inline GameObject_t1756533147 * get_tabPrefab_5() const { return ___tabPrefab_5; }
	inline GameObject_t1756533147 ** get_address_of_tabPrefab_5() { return &___tabPrefab_5; }
	inline void set_tabPrefab_5(GameObject_t1756533147 * value)
	{
		___tabPrefab_5 = value;
		Il2CppCodeGenWriteBarrier(&___tabPrefab_5, value);
	}

	inline static int32_t get_offset_of_panelPrefab_6() { return static_cast<int32_t>(offsetof(TabControl_t3870126276, ___panelPrefab_6)); }
	inline GameObject_t1756533147 * get_panelPrefab_6() const { return ___panelPrefab_6; }
	inline GameObject_t1756533147 ** get_address_of_panelPrefab_6() { return &___panelPrefab_6; }
	inline void set_panelPrefab_6(GameObject_t1756533147 * value)
	{
		___panelPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___panelPrefab_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
