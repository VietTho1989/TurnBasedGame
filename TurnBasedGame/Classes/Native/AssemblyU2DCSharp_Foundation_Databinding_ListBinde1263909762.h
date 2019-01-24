#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// System.Collections.Generic.List`1<Foundation.Databinding.BindingContext>
struct List_1_t1841598034;
// Foundation.Databinding.IObservableCollection
struct IObservableCollection_t1717198044;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ListBinder
struct  ListBinder_t1263909762  : public BindingBase_t2590300386
{
public:
	// System.Collections.Generic.List`1<Foundation.Databinding.BindingContext> Foundation.Databinding.ListBinder::Children
	List_1_t1841598034 * ___Children_9;
	// Foundation.Databinding.IObservableCollection Foundation.Databinding.ListBinder::DataList
	Il2CppObject * ___DataList_10;
	// System.Boolean Foundation.Databinding.ListBinder::DelayLoad
	bool ___DelayLoad_11;
	// System.Int32 Foundation.Databinding.ListBinder::Index
	int32_t ___Index_12;
	// System.Boolean Foundation.Databinding.ListBinder::IsInit
	bool ___IsInit_13;
	// System.Boolean Foundation.Databinding.ListBinder::IsLoaded
	bool ___IsLoaded_14;
	// UnityEngine.GameObject Foundation.Databinding.ListBinder::LoadingMask
	GameObject_t1756533147 * ___LoadingMask_15;
	// System.Boolean Foundation.Databinding.ListBinder::OneTime
	bool ___OneTime_16;
	// UnityEngine.GameObject Foundation.Databinding.ListBinder::Prefab
	GameObject_t1756533147 * ___Prefab_17;
	// UnityEngine.RectTransform Foundation.Databinding.ListBinder::RectTransform
	RectTransform_t3349966182 * ___RectTransform_18;
	// UnityEngine.RectTransform Foundation.Databinding.ListBinder::RectTransform2
	RectTransform_t3349966182 * ___RectTransform2_19;
	// System.Boolean Foundation.Databinding.ListBinder::SetAsFirstSibling
	bool ___SetAsFirstSibling_20;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ListBinder::SourceBinding
	BindingInfo_t2210172430 * ___SourceBinding_21;

public:
	inline static int32_t get_offset_of_Children_9() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___Children_9)); }
	inline List_1_t1841598034 * get_Children_9() const { return ___Children_9; }
	inline List_1_t1841598034 ** get_address_of_Children_9() { return &___Children_9; }
	inline void set_Children_9(List_1_t1841598034 * value)
	{
		___Children_9 = value;
		Il2CppCodeGenWriteBarrier(&___Children_9, value);
	}

	inline static int32_t get_offset_of_DataList_10() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___DataList_10)); }
	inline Il2CppObject * get_DataList_10() const { return ___DataList_10; }
	inline Il2CppObject ** get_address_of_DataList_10() { return &___DataList_10; }
	inline void set_DataList_10(Il2CppObject * value)
	{
		___DataList_10 = value;
		Il2CppCodeGenWriteBarrier(&___DataList_10, value);
	}

	inline static int32_t get_offset_of_DelayLoad_11() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___DelayLoad_11)); }
	inline bool get_DelayLoad_11() const { return ___DelayLoad_11; }
	inline bool* get_address_of_DelayLoad_11() { return &___DelayLoad_11; }
	inline void set_DelayLoad_11(bool value)
	{
		___DelayLoad_11 = value;
	}

	inline static int32_t get_offset_of_Index_12() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___Index_12)); }
	inline int32_t get_Index_12() const { return ___Index_12; }
	inline int32_t* get_address_of_Index_12() { return &___Index_12; }
	inline void set_Index_12(int32_t value)
	{
		___Index_12 = value;
	}

	inline static int32_t get_offset_of_IsInit_13() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___IsInit_13)); }
	inline bool get_IsInit_13() const { return ___IsInit_13; }
	inline bool* get_address_of_IsInit_13() { return &___IsInit_13; }
	inline void set_IsInit_13(bool value)
	{
		___IsInit_13 = value;
	}

	inline static int32_t get_offset_of_IsLoaded_14() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___IsLoaded_14)); }
	inline bool get_IsLoaded_14() const { return ___IsLoaded_14; }
	inline bool* get_address_of_IsLoaded_14() { return &___IsLoaded_14; }
	inline void set_IsLoaded_14(bool value)
	{
		___IsLoaded_14 = value;
	}

	inline static int32_t get_offset_of_LoadingMask_15() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___LoadingMask_15)); }
	inline GameObject_t1756533147 * get_LoadingMask_15() const { return ___LoadingMask_15; }
	inline GameObject_t1756533147 ** get_address_of_LoadingMask_15() { return &___LoadingMask_15; }
	inline void set_LoadingMask_15(GameObject_t1756533147 * value)
	{
		___LoadingMask_15 = value;
		Il2CppCodeGenWriteBarrier(&___LoadingMask_15, value);
	}

	inline static int32_t get_offset_of_OneTime_16() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___OneTime_16)); }
	inline bool get_OneTime_16() const { return ___OneTime_16; }
	inline bool* get_address_of_OneTime_16() { return &___OneTime_16; }
	inline void set_OneTime_16(bool value)
	{
		___OneTime_16 = value;
	}

	inline static int32_t get_offset_of_Prefab_17() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___Prefab_17)); }
	inline GameObject_t1756533147 * get_Prefab_17() const { return ___Prefab_17; }
	inline GameObject_t1756533147 ** get_address_of_Prefab_17() { return &___Prefab_17; }
	inline void set_Prefab_17(GameObject_t1756533147 * value)
	{
		___Prefab_17 = value;
		Il2CppCodeGenWriteBarrier(&___Prefab_17, value);
	}

	inline static int32_t get_offset_of_RectTransform_18() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___RectTransform_18)); }
	inline RectTransform_t3349966182 * get_RectTransform_18() const { return ___RectTransform_18; }
	inline RectTransform_t3349966182 ** get_address_of_RectTransform_18() { return &___RectTransform_18; }
	inline void set_RectTransform_18(RectTransform_t3349966182 * value)
	{
		___RectTransform_18 = value;
		Il2CppCodeGenWriteBarrier(&___RectTransform_18, value);
	}

	inline static int32_t get_offset_of_RectTransform2_19() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___RectTransform2_19)); }
	inline RectTransform_t3349966182 * get_RectTransform2_19() const { return ___RectTransform2_19; }
	inline RectTransform_t3349966182 ** get_address_of_RectTransform2_19() { return &___RectTransform2_19; }
	inline void set_RectTransform2_19(RectTransform_t3349966182 * value)
	{
		___RectTransform2_19 = value;
		Il2CppCodeGenWriteBarrier(&___RectTransform2_19, value);
	}

	inline static int32_t get_offset_of_SetAsFirstSibling_20() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___SetAsFirstSibling_20)); }
	inline bool get_SetAsFirstSibling_20() const { return ___SetAsFirstSibling_20; }
	inline bool* get_address_of_SetAsFirstSibling_20() { return &___SetAsFirstSibling_20; }
	inline void set_SetAsFirstSibling_20(bool value)
	{
		___SetAsFirstSibling_20 = value;
	}

	inline static int32_t get_offset_of_SourceBinding_21() { return static_cast<int32_t>(offsetof(ListBinder_t1263909762, ___SourceBinding_21)); }
	inline BindingInfo_t2210172430 * get_SourceBinding_21() const { return ___SourceBinding_21; }
	inline BindingInfo_t2210172430 ** get_address_of_SourceBinding_21() { return &___SourceBinding_21; }
	inline void set_SourceBinding_21(BindingInfo_t2210172430 * value)
	{
		___SourceBinding_21 = value;
		Il2CppCodeGenWriteBarrier(&___SourceBinding_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
