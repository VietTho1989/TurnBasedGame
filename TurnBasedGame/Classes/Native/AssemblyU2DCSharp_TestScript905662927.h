#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// TestClass
struct TestClass_t1183229268;
// TestClass[]
struct TestClassU5BU5D_t769038045;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TestScript
struct  TestScript_t905662927  : public MonoBehaviour_t1158329972
{
public:
	// System.String TestScript::testString
	String_t* ___testString_2;
	// UnityEngine.GameObject TestScript::someGameObject
	GameObject_t1756533147 * ___someGameObject_3;
	// System.String TestScript::someGameObject_id
	String_t* ___someGameObject_id_4;
	// TestClass TestScript::testClass
	TestClass_t1183229268 * ___testClass_5;
	// TestClass[] TestScript::testClassArray
	TestClassU5BU5D_t769038045* ___testClassArray_6;
	// UnityEngine.Transform TestScript::TransformThatWontBeSaved
	Transform_t3275118058 * ___TransformThatWontBeSaved_7;

public:
	inline static int32_t get_offset_of_testString_2() { return static_cast<int32_t>(offsetof(TestScript_t905662927, ___testString_2)); }
	inline String_t* get_testString_2() const { return ___testString_2; }
	inline String_t** get_address_of_testString_2() { return &___testString_2; }
	inline void set_testString_2(String_t* value)
	{
		___testString_2 = value;
		Il2CppCodeGenWriteBarrier(&___testString_2, value);
	}

	inline static int32_t get_offset_of_someGameObject_3() { return static_cast<int32_t>(offsetof(TestScript_t905662927, ___someGameObject_3)); }
	inline GameObject_t1756533147 * get_someGameObject_3() const { return ___someGameObject_3; }
	inline GameObject_t1756533147 ** get_address_of_someGameObject_3() { return &___someGameObject_3; }
	inline void set_someGameObject_3(GameObject_t1756533147 * value)
	{
		___someGameObject_3 = value;
		Il2CppCodeGenWriteBarrier(&___someGameObject_3, value);
	}

	inline static int32_t get_offset_of_someGameObject_id_4() { return static_cast<int32_t>(offsetof(TestScript_t905662927, ___someGameObject_id_4)); }
	inline String_t* get_someGameObject_id_4() const { return ___someGameObject_id_4; }
	inline String_t** get_address_of_someGameObject_id_4() { return &___someGameObject_id_4; }
	inline void set_someGameObject_id_4(String_t* value)
	{
		___someGameObject_id_4 = value;
		Il2CppCodeGenWriteBarrier(&___someGameObject_id_4, value);
	}

	inline static int32_t get_offset_of_testClass_5() { return static_cast<int32_t>(offsetof(TestScript_t905662927, ___testClass_5)); }
	inline TestClass_t1183229268 * get_testClass_5() const { return ___testClass_5; }
	inline TestClass_t1183229268 ** get_address_of_testClass_5() { return &___testClass_5; }
	inline void set_testClass_5(TestClass_t1183229268 * value)
	{
		___testClass_5 = value;
		Il2CppCodeGenWriteBarrier(&___testClass_5, value);
	}

	inline static int32_t get_offset_of_testClassArray_6() { return static_cast<int32_t>(offsetof(TestScript_t905662927, ___testClassArray_6)); }
	inline TestClassU5BU5D_t769038045* get_testClassArray_6() const { return ___testClassArray_6; }
	inline TestClassU5BU5D_t769038045** get_address_of_testClassArray_6() { return &___testClassArray_6; }
	inline void set_testClassArray_6(TestClassU5BU5D_t769038045* value)
	{
		___testClassArray_6 = value;
		Il2CppCodeGenWriteBarrier(&___testClassArray_6, value);
	}

	inline static int32_t get_offset_of_TransformThatWontBeSaved_7() { return static_cast<int32_t>(offsetof(TestScript_t905662927, ___TransformThatWontBeSaved_7)); }
	inline Transform_t3275118058 * get_TransformThatWontBeSaved_7() const { return ___TransformThatWontBeSaved_7; }
	inline Transform_t3275118058 ** get_address_of_TransformThatWontBeSaved_7() { return &___TransformThatWontBeSaved_7; }
	inline void set_TransformThatWontBeSaved_7(Transform_t3275118058 * value)
	{
		___TransformThatWontBeSaved_7 = value;
		Il2CppCodeGenWriteBarrier(&___TransformThatWontBeSaved_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
