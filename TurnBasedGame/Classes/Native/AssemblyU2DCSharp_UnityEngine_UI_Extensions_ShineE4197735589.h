#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Extensions.ShineEffect
struct ShineEffect_t1749864756;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ShineEffector
struct  ShineEffector_t4197735589  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ShineEffect UnityEngine.UI.Extensions.ShineEffector::effector
	ShineEffect_t1749864756 * ___effector_2;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.ShineEffector::effectRoot
	GameObject_t1756533147 * ___effectRoot_3;
	// System.Single UnityEngine.UI.Extensions.ShineEffector::yOffset
	float ___yOffset_4;
	// System.Single UnityEngine.UI.Extensions.ShineEffector::width
	float ___width_5;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ShineEffector::effectorRect
	RectTransform_t3349966182 * ___effectorRect_6;

public:
	inline static int32_t get_offset_of_effector_2() { return static_cast<int32_t>(offsetof(ShineEffector_t4197735589, ___effector_2)); }
	inline ShineEffect_t1749864756 * get_effector_2() const { return ___effector_2; }
	inline ShineEffect_t1749864756 ** get_address_of_effector_2() { return &___effector_2; }
	inline void set_effector_2(ShineEffect_t1749864756 * value)
	{
		___effector_2 = value;
		Il2CppCodeGenWriteBarrier(&___effector_2, value);
	}

	inline static int32_t get_offset_of_effectRoot_3() { return static_cast<int32_t>(offsetof(ShineEffector_t4197735589, ___effectRoot_3)); }
	inline GameObject_t1756533147 * get_effectRoot_3() const { return ___effectRoot_3; }
	inline GameObject_t1756533147 ** get_address_of_effectRoot_3() { return &___effectRoot_3; }
	inline void set_effectRoot_3(GameObject_t1756533147 * value)
	{
		___effectRoot_3 = value;
		Il2CppCodeGenWriteBarrier(&___effectRoot_3, value);
	}

	inline static int32_t get_offset_of_yOffset_4() { return static_cast<int32_t>(offsetof(ShineEffector_t4197735589, ___yOffset_4)); }
	inline float get_yOffset_4() const { return ___yOffset_4; }
	inline float* get_address_of_yOffset_4() { return &___yOffset_4; }
	inline void set_yOffset_4(float value)
	{
		___yOffset_4 = value;
	}

	inline static int32_t get_offset_of_width_5() { return static_cast<int32_t>(offsetof(ShineEffector_t4197735589, ___width_5)); }
	inline float get_width_5() const { return ___width_5; }
	inline float* get_address_of_width_5() { return &___width_5; }
	inline void set_width_5(float value)
	{
		___width_5 = value;
	}

	inline static int32_t get_offset_of_effectorRect_6() { return static_cast<int32_t>(offsetof(ShineEffector_t4197735589, ___effectorRect_6)); }
	inline RectTransform_t3349966182 * get_effectorRect_6() const { return ___effectorRect_6; }
	inline RectTransform_t3349966182 ** get_address_of_effectorRect_6() { return &___effectorRect_6; }
	inline void set_effectorRect_6(RectTransform_t3349966182 * value)
	{
		___effectorRect_6 = value;
		Il2CppCodeGenWriteBarrier(&___effectorRect_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
