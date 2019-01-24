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
// Foundation.Databinding.IObservableModel
struct IObservableModel_t1055181153;
// Foundation.Databinding.BindingContext
struct BindingContext_t2472476902;
// Foundation.Databinding.BindingBase/BindingInfo[]
struct BindingInfoU5BU5D_t1172201979;
// System.Func`2<System.Reflection.FieldInfo,System.Boolean>
struct Func_2_t472048993;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.BindingBase
struct  BindingBase_t2590300386  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.GameObject Foundation.Databinding.BindingBase::BindingProxy
	GameObject_t1756533147 * ___BindingProxy_2;
	// System.Boolean Foundation.Databinding.BindingBase::DebugMode
	bool ___DebugMode_3;
	// Foundation.Databinding.IObservableModel Foundation.Databinding.BindingBase::_model
	Il2CppObject * ____model_4;
	// Foundation.Databinding.BindingContext Foundation.Databinding.BindingBase::_context
	BindingContext_t2472476902 * ____context_5;
	// System.Boolean Foundation.Databinding.BindingBase::<IsApplicationQuit>k__BackingField
	bool ___U3CIsApplicationQuitU3Ek__BackingField_6;
	// Foundation.Databinding.BindingBase/BindingInfo[] Foundation.Databinding.BindingBase::_infoCache
	BindingInfoU5BU5D_t1172201979* ____infoCache_7;

public:
	inline static int32_t get_offset_of_BindingProxy_2() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386, ___BindingProxy_2)); }
	inline GameObject_t1756533147 * get_BindingProxy_2() const { return ___BindingProxy_2; }
	inline GameObject_t1756533147 ** get_address_of_BindingProxy_2() { return &___BindingProxy_2; }
	inline void set_BindingProxy_2(GameObject_t1756533147 * value)
	{
		___BindingProxy_2 = value;
		Il2CppCodeGenWriteBarrier(&___BindingProxy_2, value);
	}

	inline static int32_t get_offset_of_DebugMode_3() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386, ___DebugMode_3)); }
	inline bool get_DebugMode_3() const { return ___DebugMode_3; }
	inline bool* get_address_of_DebugMode_3() { return &___DebugMode_3; }
	inline void set_DebugMode_3(bool value)
	{
		___DebugMode_3 = value;
	}

	inline static int32_t get_offset_of__model_4() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386, ____model_4)); }
	inline Il2CppObject * get__model_4() const { return ____model_4; }
	inline Il2CppObject ** get_address_of__model_4() { return &____model_4; }
	inline void set__model_4(Il2CppObject * value)
	{
		____model_4 = value;
		Il2CppCodeGenWriteBarrier(&____model_4, value);
	}

	inline static int32_t get_offset_of__context_5() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386, ____context_5)); }
	inline BindingContext_t2472476902 * get__context_5() const { return ____context_5; }
	inline BindingContext_t2472476902 ** get_address_of__context_5() { return &____context_5; }
	inline void set__context_5(BindingContext_t2472476902 * value)
	{
		____context_5 = value;
		Il2CppCodeGenWriteBarrier(&____context_5, value);
	}

	inline static int32_t get_offset_of_U3CIsApplicationQuitU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386, ___U3CIsApplicationQuitU3Ek__BackingField_6)); }
	inline bool get_U3CIsApplicationQuitU3Ek__BackingField_6() const { return ___U3CIsApplicationQuitU3Ek__BackingField_6; }
	inline bool* get_address_of_U3CIsApplicationQuitU3Ek__BackingField_6() { return &___U3CIsApplicationQuitU3Ek__BackingField_6; }
	inline void set_U3CIsApplicationQuitU3Ek__BackingField_6(bool value)
	{
		___U3CIsApplicationQuitU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of__infoCache_7() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386, ____infoCache_7)); }
	inline BindingInfoU5BU5D_t1172201979* get__infoCache_7() const { return ____infoCache_7; }
	inline BindingInfoU5BU5D_t1172201979** get_address_of__infoCache_7() { return &____infoCache_7; }
	inline void set__infoCache_7(BindingInfoU5BU5D_t1172201979* value)
	{
		____infoCache_7 = value;
		Il2CppCodeGenWriteBarrier(&____infoCache_7, value);
	}
};

struct BindingBase_t2590300386_StaticFields
{
public:
	// System.Func`2<System.Reflection.FieldInfo,System.Boolean> Foundation.Databinding.BindingBase::<>f__am$cache0
	Func_2_t472048993 * ___U3CU3Ef__amU24cache0_8;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_8() { return static_cast<int32_t>(offsetof(BindingBase_t2590300386_StaticFields, ___U3CU3Ef__amU24cache0_8)); }
	inline Func_2_t472048993 * get_U3CU3Ef__amU24cache0_8() const { return ___U3CU3Ef__amU24cache0_8; }
	inline Func_2_t472048993 ** get_address_of_U3CU3Ef__amU24cache0_8() { return &___U3CU3Ef__amU24cache0_8; }
	inline void set_U3CU3Ef__amU24cache0_8(Func_2_t472048993 * value)
	{
		___U3CU3Ef__amU24cache0_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
