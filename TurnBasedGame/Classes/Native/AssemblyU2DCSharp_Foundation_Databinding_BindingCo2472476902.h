#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_Foundation_Databinding_BindingCo3891619614.h"

// System.Reflection.Assembly[]
struct AssemblyU5BU5D_t1984278467;
// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.String
struct String_t;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t1158329972;
// System.Type
struct Type_t;
// System.Object
struct Il2CppObject;
// Foundation.Databinding.IObservableModel
struct IObservableModel_t1055181153;
// System.Collections.Generic.List`1<Foundation.Databinding.IBindingElement>
struct List_1_t913061222;
// Foundation.Databinding.BindingContext
struct BindingContext_t2472476902;
// System.Func`2<System.Reflection.Assembly,System.Boolean>
struct Func_2_t2331273937;
// System.Func`2<System.Reflection.Assembly,System.String>
struct Func_2_t534919452;
// System.Func`2<System.Reflection.Assembly,System.Collections.Generic.IEnumerable`1<System.Type>>
struct Func_2_t101629490;
// System.Func`2<System.Type,System.Boolean>
struct Func_2_t2011960077;
// System.Func`2<System.Type,System.String>
struct Func_2_t215605592;
// System.Func`2<System.String,System.String>
struct Func_2_t193026957;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.BindingContext
struct  BindingContext_t2472476902  : public MonoBehaviour_t1158329972
{
public:
	// Foundation.Databinding.BindingContext/BindingContextMode Foundation.Databinding.BindingContext::ContextMode
	int32_t ___ContextMode_5;
	// System.Boolean Foundation.Databinding.BindingContext::ModelIsMock
	bool ___ModelIsMock_6;
	// System.String Foundation.Databinding.BindingContext::ModelAssembly
	String_t* ___ModelAssembly_7;
	// System.String Foundation.Databinding.BindingContext::ModelNamespace
	String_t* ___ModelNamespace_8;
	// System.String Foundation.Databinding.BindingContext::ModelFullName
	String_t* ___ModelFullName_9;
	// System.String Foundation.Databinding.BindingContext::ModelType
	String_t* ___ModelType_10;
	// UnityEngine.MonoBehaviour Foundation.Databinding.BindingContext::ViewModel
	MonoBehaviour_t1158329972 * ___ViewModel_11;
	// System.Type Foundation.Databinding.BindingContext::_dataType
	Type_t * ____dataType_12;
	// System.Object Foundation.Databinding.BindingContext::_dataInstance
	Il2CppObject * ____dataInstance_13;
	// System.Boolean Foundation.Databinding.BindingContext::IsWrappedBinder
	bool ___IsWrappedBinder_14;
	// Foundation.Databinding.IObservableModel Foundation.Databinding.BindingContext::<BindableContext>k__BackingField
	Il2CppObject * ___U3CBindableContextU3Ek__BackingField_15;
	// System.Collections.Generic.List`1<Foundation.Databinding.IBindingElement> Foundation.Databinding.BindingContext::Binders
	List_1_t913061222 * ___Binders_16;
	// System.Boolean Foundation.Databinding.BindingContext::DebugMode
	bool ___DebugMode_17;
	// Foundation.Databinding.BindingContext Foundation.Databinding.BindingContext::_parentContext
	BindingContext_t2472476902 * ____parentContext_18;
	// Foundation.Databinding.IObservableModel Foundation.Databinding.BindingContext::_model
	Il2CppObject * ____model_19;
	// System.String Foundation.Databinding.BindingContext::_propertyName
	String_t* ____propertyName_20;

public:
	inline static int32_t get_offset_of_ContextMode_5() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ContextMode_5)); }
	inline int32_t get_ContextMode_5() const { return ___ContextMode_5; }
	inline int32_t* get_address_of_ContextMode_5() { return &___ContextMode_5; }
	inline void set_ContextMode_5(int32_t value)
	{
		___ContextMode_5 = value;
	}

	inline static int32_t get_offset_of_ModelIsMock_6() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ModelIsMock_6)); }
	inline bool get_ModelIsMock_6() const { return ___ModelIsMock_6; }
	inline bool* get_address_of_ModelIsMock_6() { return &___ModelIsMock_6; }
	inline void set_ModelIsMock_6(bool value)
	{
		___ModelIsMock_6 = value;
	}

	inline static int32_t get_offset_of_ModelAssembly_7() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ModelAssembly_7)); }
	inline String_t* get_ModelAssembly_7() const { return ___ModelAssembly_7; }
	inline String_t** get_address_of_ModelAssembly_7() { return &___ModelAssembly_7; }
	inline void set_ModelAssembly_7(String_t* value)
	{
		___ModelAssembly_7 = value;
		Il2CppCodeGenWriteBarrier(&___ModelAssembly_7, value);
	}

	inline static int32_t get_offset_of_ModelNamespace_8() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ModelNamespace_8)); }
	inline String_t* get_ModelNamespace_8() const { return ___ModelNamespace_8; }
	inline String_t** get_address_of_ModelNamespace_8() { return &___ModelNamespace_8; }
	inline void set_ModelNamespace_8(String_t* value)
	{
		___ModelNamespace_8 = value;
		Il2CppCodeGenWriteBarrier(&___ModelNamespace_8, value);
	}

	inline static int32_t get_offset_of_ModelFullName_9() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ModelFullName_9)); }
	inline String_t* get_ModelFullName_9() const { return ___ModelFullName_9; }
	inline String_t** get_address_of_ModelFullName_9() { return &___ModelFullName_9; }
	inline void set_ModelFullName_9(String_t* value)
	{
		___ModelFullName_9 = value;
		Il2CppCodeGenWriteBarrier(&___ModelFullName_9, value);
	}

	inline static int32_t get_offset_of_ModelType_10() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ModelType_10)); }
	inline String_t* get_ModelType_10() const { return ___ModelType_10; }
	inline String_t** get_address_of_ModelType_10() { return &___ModelType_10; }
	inline void set_ModelType_10(String_t* value)
	{
		___ModelType_10 = value;
		Il2CppCodeGenWriteBarrier(&___ModelType_10, value);
	}

	inline static int32_t get_offset_of_ViewModel_11() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___ViewModel_11)); }
	inline MonoBehaviour_t1158329972 * get_ViewModel_11() const { return ___ViewModel_11; }
	inline MonoBehaviour_t1158329972 ** get_address_of_ViewModel_11() { return &___ViewModel_11; }
	inline void set_ViewModel_11(MonoBehaviour_t1158329972 * value)
	{
		___ViewModel_11 = value;
		Il2CppCodeGenWriteBarrier(&___ViewModel_11, value);
	}

	inline static int32_t get_offset_of__dataType_12() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ____dataType_12)); }
	inline Type_t * get__dataType_12() const { return ____dataType_12; }
	inline Type_t ** get_address_of__dataType_12() { return &____dataType_12; }
	inline void set__dataType_12(Type_t * value)
	{
		____dataType_12 = value;
		Il2CppCodeGenWriteBarrier(&____dataType_12, value);
	}

	inline static int32_t get_offset_of__dataInstance_13() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ____dataInstance_13)); }
	inline Il2CppObject * get__dataInstance_13() const { return ____dataInstance_13; }
	inline Il2CppObject ** get_address_of__dataInstance_13() { return &____dataInstance_13; }
	inline void set__dataInstance_13(Il2CppObject * value)
	{
		____dataInstance_13 = value;
		Il2CppCodeGenWriteBarrier(&____dataInstance_13, value);
	}

	inline static int32_t get_offset_of_IsWrappedBinder_14() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___IsWrappedBinder_14)); }
	inline bool get_IsWrappedBinder_14() const { return ___IsWrappedBinder_14; }
	inline bool* get_address_of_IsWrappedBinder_14() { return &___IsWrappedBinder_14; }
	inline void set_IsWrappedBinder_14(bool value)
	{
		___IsWrappedBinder_14 = value;
	}

	inline static int32_t get_offset_of_U3CBindableContextU3Ek__BackingField_15() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___U3CBindableContextU3Ek__BackingField_15)); }
	inline Il2CppObject * get_U3CBindableContextU3Ek__BackingField_15() const { return ___U3CBindableContextU3Ek__BackingField_15; }
	inline Il2CppObject ** get_address_of_U3CBindableContextU3Ek__BackingField_15() { return &___U3CBindableContextU3Ek__BackingField_15; }
	inline void set_U3CBindableContextU3Ek__BackingField_15(Il2CppObject * value)
	{
		___U3CBindableContextU3Ek__BackingField_15 = value;
		Il2CppCodeGenWriteBarrier(&___U3CBindableContextU3Ek__BackingField_15, value);
	}

	inline static int32_t get_offset_of_Binders_16() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___Binders_16)); }
	inline List_1_t913061222 * get_Binders_16() const { return ___Binders_16; }
	inline List_1_t913061222 ** get_address_of_Binders_16() { return &___Binders_16; }
	inline void set_Binders_16(List_1_t913061222 * value)
	{
		___Binders_16 = value;
		Il2CppCodeGenWriteBarrier(&___Binders_16, value);
	}

	inline static int32_t get_offset_of_DebugMode_17() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ___DebugMode_17)); }
	inline bool get_DebugMode_17() const { return ___DebugMode_17; }
	inline bool* get_address_of_DebugMode_17() { return &___DebugMode_17; }
	inline void set_DebugMode_17(bool value)
	{
		___DebugMode_17 = value;
	}

	inline static int32_t get_offset_of__parentContext_18() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ____parentContext_18)); }
	inline BindingContext_t2472476902 * get__parentContext_18() const { return ____parentContext_18; }
	inline BindingContext_t2472476902 ** get_address_of__parentContext_18() { return &____parentContext_18; }
	inline void set__parentContext_18(BindingContext_t2472476902 * value)
	{
		____parentContext_18 = value;
		Il2CppCodeGenWriteBarrier(&____parentContext_18, value);
	}

	inline static int32_t get_offset_of__model_19() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ____model_19)); }
	inline Il2CppObject * get__model_19() const { return ____model_19; }
	inline Il2CppObject ** get_address_of__model_19() { return &____model_19; }
	inline void set__model_19(Il2CppObject * value)
	{
		____model_19 = value;
		Il2CppCodeGenWriteBarrier(&____model_19, value);
	}

	inline static int32_t get_offset_of__propertyName_20() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902, ____propertyName_20)); }
	inline String_t* get__propertyName_20() const { return ____propertyName_20; }
	inline String_t** get_address_of__propertyName_20() { return &____propertyName_20; }
	inline void set__propertyName_20(String_t* value)
	{
		____propertyName_20 = value;
		Il2CppCodeGenWriteBarrier(&____propertyName_20, value);
	}
};

struct BindingContext_t2472476902_StaticFields
{
public:
	// System.Reflection.Assembly[] Foundation.Databinding.BindingContext::_assemblies
	AssemblyU5BU5D_t1984278467* ____assemblies_2;
	// System.Type[] Foundation.Databinding.BindingContext::_modelTypes
	TypeU5BU5D_t1664964607* ____modelTypes_3;
	// System.String[] Foundation.Databinding.BindingContext::_namespaces
	StringU5BU5D_t1642385972* ____namespaces_4;
	// System.Func`2<System.Reflection.Assembly,System.Boolean> Foundation.Databinding.BindingContext::<>f__am$cache0
	Func_2_t2331273937 * ___U3CU3Ef__amU24cache0_21;
	// System.Func`2<System.Reflection.Assembly,System.String> Foundation.Databinding.BindingContext::<>f__am$cache1
	Func_2_t534919452 * ___U3CU3Ef__amU24cache1_22;
	// System.Func`2<System.Reflection.Assembly,System.Collections.Generic.IEnumerable`1<System.Type>> Foundation.Databinding.BindingContext::<>f__am$cache2
	Func_2_t101629490 * ___U3CU3Ef__amU24cache2_23;
	// System.Func`2<System.Type,System.Boolean> Foundation.Databinding.BindingContext::<>f__am$cache3
	Func_2_t2011960077 * ___U3CU3Ef__amU24cache3_24;
	// System.Func`2<System.Type,System.String> Foundation.Databinding.BindingContext::<>f__am$cache4
	Func_2_t215605592 * ___U3CU3Ef__amU24cache4_25;
	// System.Func`2<System.Type,System.String> Foundation.Databinding.BindingContext::<>f__am$cache5
	Func_2_t215605592 * ___U3CU3Ef__amU24cache5_26;
	// System.Func`2<System.String,System.String> Foundation.Databinding.BindingContext::<>f__am$cache6
	Func_2_t193026957 * ___U3CU3Ef__amU24cache6_27;

public:
	inline static int32_t get_offset_of__assemblies_2() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ____assemblies_2)); }
	inline AssemblyU5BU5D_t1984278467* get__assemblies_2() const { return ____assemblies_2; }
	inline AssemblyU5BU5D_t1984278467** get_address_of__assemblies_2() { return &____assemblies_2; }
	inline void set__assemblies_2(AssemblyU5BU5D_t1984278467* value)
	{
		____assemblies_2 = value;
		Il2CppCodeGenWriteBarrier(&____assemblies_2, value);
	}

	inline static int32_t get_offset_of__modelTypes_3() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ____modelTypes_3)); }
	inline TypeU5BU5D_t1664964607* get__modelTypes_3() const { return ____modelTypes_3; }
	inline TypeU5BU5D_t1664964607** get_address_of__modelTypes_3() { return &____modelTypes_3; }
	inline void set__modelTypes_3(TypeU5BU5D_t1664964607* value)
	{
		____modelTypes_3 = value;
		Il2CppCodeGenWriteBarrier(&____modelTypes_3, value);
	}

	inline static int32_t get_offset_of__namespaces_4() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ____namespaces_4)); }
	inline StringU5BU5D_t1642385972* get__namespaces_4() const { return ____namespaces_4; }
	inline StringU5BU5D_t1642385972** get_address_of__namespaces_4() { return &____namespaces_4; }
	inline void set__namespaces_4(StringU5BU5D_t1642385972* value)
	{
		____namespaces_4 = value;
		Il2CppCodeGenWriteBarrier(&____namespaces_4, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_21() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache0_21)); }
	inline Func_2_t2331273937 * get_U3CU3Ef__amU24cache0_21() const { return ___U3CU3Ef__amU24cache0_21; }
	inline Func_2_t2331273937 ** get_address_of_U3CU3Ef__amU24cache0_21() { return &___U3CU3Ef__amU24cache0_21; }
	inline void set_U3CU3Ef__amU24cache0_21(Func_2_t2331273937 * value)
	{
		___U3CU3Ef__amU24cache0_21 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_21, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_22() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache1_22)); }
	inline Func_2_t534919452 * get_U3CU3Ef__amU24cache1_22() const { return ___U3CU3Ef__amU24cache1_22; }
	inline Func_2_t534919452 ** get_address_of_U3CU3Ef__amU24cache1_22() { return &___U3CU3Ef__amU24cache1_22; }
	inline void set_U3CU3Ef__amU24cache1_22(Func_2_t534919452 * value)
	{
		___U3CU3Ef__amU24cache1_22 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_22, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache2_23() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache2_23)); }
	inline Func_2_t101629490 * get_U3CU3Ef__amU24cache2_23() const { return ___U3CU3Ef__amU24cache2_23; }
	inline Func_2_t101629490 ** get_address_of_U3CU3Ef__amU24cache2_23() { return &___U3CU3Ef__amU24cache2_23; }
	inline void set_U3CU3Ef__amU24cache2_23(Func_2_t101629490 * value)
	{
		___U3CU3Ef__amU24cache2_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache2_23, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache3_24() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache3_24)); }
	inline Func_2_t2011960077 * get_U3CU3Ef__amU24cache3_24() const { return ___U3CU3Ef__amU24cache3_24; }
	inline Func_2_t2011960077 ** get_address_of_U3CU3Ef__amU24cache3_24() { return &___U3CU3Ef__amU24cache3_24; }
	inline void set_U3CU3Ef__amU24cache3_24(Func_2_t2011960077 * value)
	{
		___U3CU3Ef__amU24cache3_24 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache3_24, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache4_25() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache4_25)); }
	inline Func_2_t215605592 * get_U3CU3Ef__amU24cache4_25() const { return ___U3CU3Ef__amU24cache4_25; }
	inline Func_2_t215605592 ** get_address_of_U3CU3Ef__amU24cache4_25() { return &___U3CU3Ef__amU24cache4_25; }
	inline void set_U3CU3Ef__amU24cache4_25(Func_2_t215605592 * value)
	{
		___U3CU3Ef__amU24cache4_25 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache4_25, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache5_26() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache5_26)); }
	inline Func_2_t215605592 * get_U3CU3Ef__amU24cache5_26() const { return ___U3CU3Ef__amU24cache5_26; }
	inline Func_2_t215605592 ** get_address_of_U3CU3Ef__amU24cache5_26() { return &___U3CU3Ef__amU24cache5_26; }
	inline void set_U3CU3Ef__amU24cache5_26(Func_2_t215605592 * value)
	{
		___U3CU3Ef__amU24cache5_26 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache5_26, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache6_27() { return static_cast<int32_t>(offsetof(BindingContext_t2472476902_StaticFields, ___U3CU3Ef__amU24cache6_27)); }
	inline Func_2_t193026957 * get_U3CU3Ef__amU24cache6_27() const { return ___U3CU3Ef__amU24cache6_27; }
	inline Func_2_t193026957 ** get_address_of_U3CU3Ef__amU24cache6_27() { return &___U3CU3Ef__amU24cache6_27; }
	inline void set_U3CU3Ef__amU24cache6_27(Func_2_t193026957 * value)
	{
		___U3CU3Ef__amU24cache6_27 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache6_27, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
