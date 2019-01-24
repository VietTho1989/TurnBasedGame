#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_Naviga1772877217.h"

// UnityEngine.EventSystems.EventSystem
struct EventSystem_t3466835263;
// UnityEngine.UI.Selectable[]
struct SelectableU5BU5D_t3083107861;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.TabNavigationHelper
struct  TabNavigationHelper_t538601999  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.EventSystems.EventSystem UnityEngine.UI.Extensions.TabNavigationHelper::_system
	EventSystem_t3466835263 * ____system_2;
	// UnityEngine.UI.Selectable[] UnityEngine.UI.Extensions.TabNavigationHelper::NavigationPath
	SelectableU5BU5D_t3083107861* ___NavigationPath_3;
	// UnityEngine.UI.Extensions.NavigationMode UnityEngine.UI.Extensions.TabNavigationHelper::NavigationMode
	int32_t ___NavigationMode_4;

public:
	inline static int32_t get_offset_of__system_2() { return static_cast<int32_t>(offsetof(TabNavigationHelper_t538601999, ____system_2)); }
	inline EventSystem_t3466835263 * get__system_2() const { return ____system_2; }
	inline EventSystem_t3466835263 ** get_address_of__system_2() { return &____system_2; }
	inline void set__system_2(EventSystem_t3466835263 * value)
	{
		____system_2 = value;
		Il2CppCodeGenWriteBarrier(&____system_2, value);
	}

	inline static int32_t get_offset_of_NavigationPath_3() { return static_cast<int32_t>(offsetof(TabNavigationHelper_t538601999, ___NavigationPath_3)); }
	inline SelectableU5BU5D_t3083107861* get_NavigationPath_3() const { return ___NavigationPath_3; }
	inline SelectableU5BU5D_t3083107861** get_address_of_NavigationPath_3() { return &___NavigationPath_3; }
	inline void set_NavigationPath_3(SelectableU5BU5D_t3083107861* value)
	{
		___NavigationPath_3 = value;
		Il2CppCodeGenWriteBarrier(&___NavigationPath_3, value);
	}

	inline static int32_t get_offset_of_NavigationMode_4() { return static_cast<int32_t>(offsetof(TabNavigationHelper_t538601999, ___NavigationMode_4)); }
	inline int32_t get_NavigationMode_4() const { return ___NavigationMode_4; }
	inline int32_t* get_address_of_NavigationMode_4() { return &___NavigationMode_4; }
	inline void set_NavigationMode_4(int32_t value)
	{
		___NavigationMode_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
