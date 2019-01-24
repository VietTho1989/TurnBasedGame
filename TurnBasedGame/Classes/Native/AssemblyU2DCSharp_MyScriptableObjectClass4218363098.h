#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// System.String
struct String_t;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t1172311765;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MyScriptableObjectClass
struct  MyScriptableObjectClass_t4218363098  : public ScriptableObject_t1975622470
{
public:
	// System.String MyScriptableObjectClass::objectName
	String_t* ___objectName_2;
	// System.Boolean MyScriptableObjectClass::colorIsRandom
	bool ___colorIsRandom_3;
	// UnityEngine.Color MyScriptableObjectClass::thisColor
	Color_t2020392075  ___thisColor_4;
	// UnityEngine.Vector3[] MyScriptableObjectClass::spawnPoints
	Vector3U5BU5D_t1172311765* ___spawnPoints_5;

public:
	inline static int32_t get_offset_of_objectName_2() { return static_cast<int32_t>(offsetof(MyScriptableObjectClass_t4218363098, ___objectName_2)); }
	inline String_t* get_objectName_2() const { return ___objectName_2; }
	inline String_t** get_address_of_objectName_2() { return &___objectName_2; }
	inline void set_objectName_2(String_t* value)
	{
		___objectName_2 = value;
		Il2CppCodeGenWriteBarrier(&___objectName_2, value);
	}

	inline static int32_t get_offset_of_colorIsRandom_3() { return static_cast<int32_t>(offsetof(MyScriptableObjectClass_t4218363098, ___colorIsRandom_3)); }
	inline bool get_colorIsRandom_3() const { return ___colorIsRandom_3; }
	inline bool* get_address_of_colorIsRandom_3() { return &___colorIsRandom_3; }
	inline void set_colorIsRandom_3(bool value)
	{
		___colorIsRandom_3 = value;
	}

	inline static int32_t get_offset_of_thisColor_4() { return static_cast<int32_t>(offsetof(MyScriptableObjectClass_t4218363098, ___thisColor_4)); }
	inline Color_t2020392075  get_thisColor_4() const { return ___thisColor_4; }
	inline Color_t2020392075 * get_address_of_thisColor_4() { return &___thisColor_4; }
	inline void set_thisColor_4(Color_t2020392075  value)
	{
		___thisColor_4 = value;
	}

	inline static int32_t get_offset_of_spawnPoints_5() { return static_cast<int32_t>(offsetof(MyScriptableObjectClass_t4218363098, ___spawnPoints_5)); }
	inline Vector3U5BU5D_t1172311765* get_spawnPoints_5() const { return ___spawnPoints_5; }
	inline Vector3U5BU5D_t1172311765** get_address_of_spawnPoints_5() { return &___spawnPoints_5; }
	inline void set_spawnPoints_5(Vector3U5BU5D_t1172311765* value)
	{
		___spawnPoints_5 = value;
		Il2CppCodeGenWriteBarrier(&___spawnPoints_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
