#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TabControlEntry
struct  TabControlEntry_t3669944688  : public Il2CppObject
{
public:
	// UnityEngine.GameObject TabControlEntry::panel
	GameObject_t1756533147 * ___panel_0;
	// UnityEngine.UI.Button TabControlEntry::tab
	Button_t2872111280 * ___tab_1;

public:
	inline static int32_t get_offset_of_panel_0() { return static_cast<int32_t>(offsetof(TabControlEntry_t3669944688, ___panel_0)); }
	inline GameObject_t1756533147 * get_panel_0() const { return ___panel_0; }
	inline GameObject_t1756533147 ** get_address_of_panel_0() { return &___panel_0; }
	inline void set_panel_0(GameObject_t1756533147 * value)
	{
		___panel_0 = value;
		Il2CppCodeGenWriteBarrier(&___panel_0, value);
	}

	inline static int32_t get_offset_of_tab_1() { return static_cast<int32_t>(offsetof(TabControlEntry_t3669944688, ___tab_1)); }
	inline Button_t2872111280 * get_tab_1() const { return ___tab_1; }
	inline Button_t2872111280 ** get_address_of_tab_1() { return &___tab_1; }
	inline void set_tab_1(Button_t2872111280 * value)
	{
		___tab_1 = value;
		Il2CppCodeGenWriteBarrier(&___tab_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
