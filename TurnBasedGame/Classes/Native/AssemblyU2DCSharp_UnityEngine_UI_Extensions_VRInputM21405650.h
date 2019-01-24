#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_EventSystems_BaseInputM1295781545.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Extensions.VRInputModule
struct VRInputModule_t21405650;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.VRInputModule
struct  VRInputModule_t21405650  : public BaseInputModule_t1295781545
{
public:
	// System.Int32 UnityEngine.UI.Extensions.VRInputModule::counter
	int32_t ___counter_10;

public:
	inline static int32_t get_offset_of_counter_10() { return static_cast<int32_t>(offsetof(VRInputModule_t21405650, ___counter_10)); }
	inline int32_t get_counter_10() const { return ___counter_10; }
	inline int32_t* get_address_of_counter_10() { return &___counter_10; }
	inline void set_counter_10(int32_t value)
	{
		___counter_10 = value;
	}
};

struct VRInputModule_t21405650_StaticFields
{
public:
	// UnityEngine.GameObject UnityEngine.UI.Extensions.VRInputModule::targetObject
	GameObject_t1756533147 * ___targetObject_8;
	// UnityEngine.UI.Extensions.VRInputModule UnityEngine.UI.Extensions.VRInputModule::_singleton
	VRInputModule_t21405650 * ____singleton_9;
	// System.Boolean UnityEngine.UI.Extensions.VRInputModule::mouseClicked
	bool ___mouseClicked_11;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.VRInputModule::cursorPosition
	Vector3_t2243707580  ___cursorPosition_12;

public:
	inline static int32_t get_offset_of_targetObject_8() { return static_cast<int32_t>(offsetof(VRInputModule_t21405650_StaticFields, ___targetObject_8)); }
	inline GameObject_t1756533147 * get_targetObject_8() const { return ___targetObject_8; }
	inline GameObject_t1756533147 ** get_address_of_targetObject_8() { return &___targetObject_8; }
	inline void set_targetObject_8(GameObject_t1756533147 * value)
	{
		___targetObject_8 = value;
		Il2CppCodeGenWriteBarrier(&___targetObject_8, value);
	}

	inline static int32_t get_offset_of__singleton_9() { return static_cast<int32_t>(offsetof(VRInputModule_t21405650_StaticFields, ____singleton_9)); }
	inline VRInputModule_t21405650 * get__singleton_9() const { return ____singleton_9; }
	inline VRInputModule_t21405650 ** get_address_of__singleton_9() { return &____singleton_9; }
	inline void set__singleton_9(VRInputModule_t21405650 * value)
	{
		____singleton_9 = value;
		Il2CppCodeGenWriteBarrier(&____singleton_9, value);
	}

	inline static int32_t get_offset_of_mouseClicked_11() { return static_cast<int32_t>(offsetof(VRInputModule_t21405650_StaticFields, ___mouseClicked_11)); }
	inline bool get_mouseClicked_11() const { return ___mouseClicked_11; }
	inline bool* get_address_of_mouseClicked_11() { return &___mouseClicked_11; }
	inline void set_mouseClicked_11(bool value)
	{
		___mouseClicked_11 = value;
	}

	inline static int32_t get_offset_of_cursorPosition_12() { return static_cast<int32_t>(offsetof(VRInputModule_t21405650_StaticFields, ___cursorPosition_12)); }
	inline Vector3_t2243707580  get_cursorPosition_12() const { return ___cursorPosition_12; }
	inline Vector3_t2243707580 * get_address_of_cursorPosition_12() { return &___cursorPosition_12; }
	inline void set_cursorPosition_12(Vector3_t2243707580  value)
	{
		___cursorPosition_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
