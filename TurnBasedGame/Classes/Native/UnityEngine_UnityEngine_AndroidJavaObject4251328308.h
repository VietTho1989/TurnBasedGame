#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_IntPtr2504060609.h"

// UnityEngine.AndroidJavaClass
struct AndroidJavaClass_t2973420583;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.AndroidJavaObject
struct  AndroidJavaObject_t4251328308  : public Il2CppObject
{
public:
	// System.Boolean UnityEngine.AndroidJavaObject::m_disposed
	bool ___m_disposed_1;
	// System.IntPtr UnityEngine.AndroidJavaObject::m_jobject
	IntPtr_t ___m_jobject_2;
	// System.IntPtr UnityEngine.AndroidJavaObject::m_jclass
	IntPtr_t ___m_jclass_3;

public:
	inline static int32_t get_offset_of_m_disposed_1() { return static_cast<int32_t>(offsetof(AndroidJavaObject_t4251328308, ___m_disposed_1)); }
	inline bool get_m_disposed_1() const { return ___m_disposed_1; }
	inline bool* get_address_of_m_disposed_1() { return &___m_disposed_1; }
	inline void set_m_disposed_1(bool value)
	{
		___m_disposed_1 = value;
	}

	inline static int32_t get_offset_of_m_jobject_2() { return static_cast<int32_t>(offsetof(AndroidJavaObject_t4251328308, ___m_jobject_2)); }
	inline IntPtr_t get_m_jobject_2() const { return ___m_jobject_2; }
	inline IntPtr_t* get_address_of_m_jobject_2() { return &___m_jobject_2; }
	inline void set_m_jobject_2(IntPtr_t value)
	{
		___m_jobject_2 = value;
	}

	inline static int32_t get_offset_of_m_jclass_3() { return static_cast<int32_t>(offsetof(AndroidJavaObject_t4251328308, ___m_jclass_3)); }
	inline IntPtr_t get_m_jclass_3() const { return ___m_jclass_3; }
	inline IntPtr_t* get_address_of_m_jclass_3() { return &___m_jclass_3; }
	inline void set_m_jclass_3(IntPtr_t value)
	{
		___m_jclass_3 = value;
	}
};

struct AndroidJavaObject_t4251328308_StaticFields
{
public:
	// System.Boolean UnityEngine.AndroidJavaObject::enableDebugPrints
	bool ___enableDebugPrints_0;
	// UnityEngine.AndroidJavaClass UnityEngine.AndroidJavaObject::s_JavaLangClass
	AndroidJavaClass_t2973420583 * ___s_JavaLangClass_4;

public:
	inline static int32_t get_offset_of_enableDebugPrints_0() { return static_cast<int32_t>(offsetof(AndroidJavaObject_t4251328308_StaticFields, ___enableDebugPrints_0)); }
	inline bool get_enableDebugPrints_0() const { return ___enableDebugPrints_0; }
	inline bool* get_address_of_enableDebugPrints_0() { return &___enableDebugPrints_0; }
	inline void set_enableDebugPrints_0(bool value)
	{
		___enableDebugPrints_0 = value;
	}

	inline static int32_t get_offset_of_s_JavaLangClass_4() { return static_cast<int32_t>(offsetof(AndroidJavaObject_t4251328308_StaticFields, ___s_JavaLangClass_4)); }
	inline AndroidJavaClass_t2973420583 * get_s_JavaLangClass_4() const { return ___s_JavaLangClass_4; }
	inline AndroidJavaClass_t2973420583 ** get_address_of_s_JavaLangClass_4() { return &___s_JavaLangClass_4; }
	inline void set_s_JavaLangClass_4(AndroidJavaClass_t2973420583 * value)
	{
		___s_JavaLangClass_4 = value;
		Il2CppCodeGenWriteBarrier(&___s_JavaLangClass_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
