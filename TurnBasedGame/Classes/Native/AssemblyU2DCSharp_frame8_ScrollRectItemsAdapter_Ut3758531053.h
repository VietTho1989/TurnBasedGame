#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.ShowOnlyOnPortraitOrientation
struct  ShowOnlyOnPortraitOrientation_t3758531053  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.GameObject frame8.ScrollRectItemsAdapter.Util.ShowOnlyOnPortraitOrientation::target
	GameObject_t1756533147 * ___target_2;

public:
	inline static int32_t get_offset_of_target_2() { return static_cast<int32_t>(offsetof(ShowOnlyOnPortraitOrientation_t3758531053, ___target_2)); }
	inline GameObject_t1756533147 * get_target_2() const { return ___target_2; }
	inline GameObject_t1756533147 ** get_address_of_target_2() { return &___target_2; }
	inline void set_target_2(GameObject_t1756533147 * value)
	{
		___target_2 = value;
		Il2CppCodeGenWriteBarrier(&___target_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
