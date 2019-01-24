#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_Foundation_Databinding_TabNaviga3687699342.h"

// UnityEngine.UI.Selectable
struct Selectable_t1490392188;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.TabNavigation
struct  TabNavigation_t4267504179  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Selectable Foundation.Databinding.TabNavigation::Default
	Selectable_t1490392188 * ___Default_2;
	// Foundation.Databinding.TabNavigation/DirectionEnum Foundation.Databinding.TabNavigation::Direction
	int32_t ___Direction_3;

public:
	inline static int32_t get_offset_of_Default_2() { return static_cast<int32_t>(offsetof(TabNavigation_t4267504179, ___Default_2)); }
	inline Selectable_t1490392188 * get_Default_2() const { return ___Default_2; }
	inline Selectable_t1490392188 ** get_address_of_Default_2() { return &___Default_2; }
	inline void set_Default_2(Selectable_t1490392188 * value)
	{
		___Default_2 = value;
		Il2CppCodeGenWriteBarrier(&___Default_2, value);
	}

	inline static int32_t get_offset_of_Direction_3() { return static_cast<int32_t>(offsetof(TabNavigation_t4267504179, ___Direction_3)); }
	inline int32_t get_Direction_3() const { return ___Direction_3; }
	inline int32_t* get_address_of_Direction_3() { return &___Direction_3; }
	inline void set_Direction_3(int32_t value)
	{
		___Direction_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
