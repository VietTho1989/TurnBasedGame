#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Collider
struct Collider_t3497673348;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.VRCursor
struct  VRCursor_t4007861940  : public MonoBehaviour_t1158329972
{
public:
	// System.Single UnityEngine.UI.Extensions.VRCursor::xSens
	float ___xSens_2;
	// System.Single UnityEngine.UI.Extensions.VRCursor::ySens
	float ___ySens_3;
	// UnityEngine.Collider UnityEngine.UI.Extensions.VRCursor::currentCollider
	Collider_t3497673348 * ___currentCollider_4;

public:
	inline static int32_t get_offset_of_xSens_2() { return static_cast<int32_t>(offsetof(VRCursor_t4007861940, ___xSens_2)); }
	inline float get_xSens_2() const { return ___xSens_2; }
	inline float* get_address_of_xSens_2() { return &___xSens_2; }
	inline void set_xSens_2(float value)
	{
		___xSens_2 = value;
	}

	inline static int32_t get_offset_of_ySens_3() { return static_cast<int32_t>(offsetof(VRCursor_t4007861940, ___ySens_3)); }
	inline float get_ySens_3() const { return ___ySens_3; }
	inline float* get_address_of_ySens_3() { return &___ySens_3; }
	inline void set_ySens_3(float value)
	{
		___ySens_3 = value;
	}

	inline static int32_t get_offset_of_currentCollider_4() { return static_cast<int32_t>(offsetof(VRCursor_t4007861940, ___currentCollider_4)); }
	inline Collider_t3497673348 * get_currentCollider_4() const { return ___currentCollider_4; }
	inline Collider_t3497673348 ** get_address_of_currentCollider_4() { return &___currentCollider_4; }
	inline void set_currentCollider_4(Collider_t3497673348 * value)
	{
		___currentCollider_4 = value;
		Il2CppCodeGenWriteBarrier(&___currentCollider_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
