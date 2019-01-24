#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// System.String
struct String_t;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TestClass
struct  TestClass_t1183229268  : public Il2CppObject
{
public:
	// System.String TestClass::myString
	String_t* ___myString_0;
	// UnityEngine.GameObject TestClass::go
	GameObject_t1756533147 * ___go_1;
	// System.String TestClass::go_id
	String_t* ___go_id_2;
	// UnityEngine.Vector3 TestClass::somePosition
	Vector3_t2243707580  ___somePosition_3;
	// UnityEngine.Color TestClass::color
	Color_t2020392075  ___color_4;
	// System.Int32[] TestClass::myArray
	Int32U5BU5D_t3030399641* ___myArray_5;

public:
	inline static int32_t get_offset_of_myString_0() { return static_cast<int32_t>(offsetof(TestClass_t1183229268, ___myString_0)); }
	inline String_t* get_myString_0() const { return ___myString_0; }
	inline String_t** get_address_of_myString_0() { return &___myString_0; }
	inline void set_myString_0(String_t* value)
	{
		___myString_0 = value;
		Il2CppCodeGenWriteBarrier(&___myString_0, value);
	}

	inline static int32_t get_offset_of_go_1() { return static_cast<int32_t>(offsetof(TestClass_t1183229268, ___go_1)); }
	inline GameObject_t1756533147 * get_go_1() const { return ___go_1; }
	inline GameObject_t1756533147 ** get_address_of_go_1() { return &___go_1; }
	inline void set_go_1(GameObject_t1756533147 * value)
	{
		___go_1 = value;
		Il2CppCodeGenWriteBarrier(&___go_1, value);
	}

	inline static int32_t get_offset_of_go_id_2() { return static_cast<int32_t>(offsetof(TestClass_t1183229268, ___go_id_2)); }
	inline String_t* get_go_id_2() const { return ___go_id_2; }
	inline String_t** get_address_of_go_id_2() { return &___go_id_2; }
	inline void set_go_id_2(String_t* value)
	{
		___go_id_2 = value;
		Il2CppCodeGenWriteBarrier(&___go_id_2, value);
	}

	inline static int32_t get_offset_of_somePosition_3() { return static_cast<int32_t>(offsetof(TestClass_t1183229268, ___somePosition_3)); }
	inline Vector3_t2243707580  get_somePosition_3() const { return ___somePosition_3; }
	inline Vector3_t2243707580 * get_address_of_somePosition_3() { return &___somePosition_3; }
	inline void set_somePosition_3(Vector3_t2243707580  value)
	{
		___somePosition_3 = value;
	}

	inline static int32_t get_offset_of_color_4() { return static_cast<int32_t>(offsetof(TestClass_t1183229268, ___color_4)); }
	inline Color_t2020392075  get_color_4() const { return ___color_4; }
	inline Color_t2020392075 * get_address_of_color_4() { return &___color_4; }
	inline void set_color_4(Color_t2020392075  value)
	{
		___color_4 = value;
	}

	inline static int32_t get_offset_of_myArray_5() { return static_cast<int32_t>(offsetof(TestClass_t1183229268, ___myArray_5)); }
	inline Int32U5BU5D_t3030399641* get_myArray_5() const { return ___myArray_5; }
	inline Int32U5BU5D_t3030399641** get_address_of_myArray_5() { return &___myArray_5; }
	inline void set_myArray_5(Int32U5BU5D_t3030399641* value)
	{
		___myArray_5 = value;
		Il2CppCodeGenWriteBarrier(&___myArray_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
