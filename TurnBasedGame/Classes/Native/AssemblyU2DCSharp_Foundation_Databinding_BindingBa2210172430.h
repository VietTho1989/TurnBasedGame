#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBas711783692.h"

// System.String
struct String_t;
// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.Action`1<System.Object>
struct Action_1_t2491248677;
// System.Func`1<System.Boolean>
struct Func_1_t1485000104;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.BindingBase/BindingInfo
struct  BindingInfo_t2210172430  : public Il2CppObject
{
public:
	// System.String Foundation.Databinding.BindingBase/BindingInfo::BindingName
	String_t* ___BindingName_0;
	// Foundation.Databinding.BindingBase/BindingFilter Foundation.Databinding.BindingBase/BindingInfo::Filters
	int32_t ___Filters_1;
	// System.Type[] Foundation.Databinding.BindingBase/BindingInfo::FilterTypes
	TypeU5BU5D_t1664964607* ___FilterTypes_2;
	// System.String Foundation.Databinding.BindingBase/BindingInfo::MemberName
	String_t* ___MemberName_3;
	// System.Action`1<System.Object> Foundation.Databinding.BindingBase/BindingInfo::<Action>k__BackingField
	Action_1_t2491248677 * ___U3CActionU3Ek__BackingField_4;
	// System.Func`1<System.Boolean> Foundation.Databinding.BindingBase/BindingInfo::<ShouldShow>k__BackingField
	Func_1_t1485000104 * ___U3CShouldShowU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_BindingName_0() { return static_cast<int32_t>(offsetof(BindingInfo_t2210172430, ___BindingName_0)); }
	inline String_t* get_BindingName_0() const { return ___BindingName_0; }
	inline String_t** get_address_of_BindingName_0() { return &___BindingName_0; }
	inline void set_BindingName_0(String_t* value)
	{
		___BindingName_0 = value;
		Il2CppCodeGenWriteBarrier(&___BindingName_0, value);
	}

	inline static int32_t get_offset_of_Filters_1() { return static_cast<int32_t>(offsetof(BindingInfo_t2210172430, ___Filters_1)); }
	inline int32_t get_Filters_1() const { return ___Filters_1; }
	inline int32_t* get_address_of_Filters_1() { return &___Filters_1; }
	inline void set_Filters_1(int32_t value)
	{
		___Filters_1 = value;
	}

	inline static int32_t get_offset_of_FilterTypes_2() { return static_cast<int32_t>(offsetof(BindingInfo_t2210172430, ___FilterTypes_2)); }
	inline TypeU5BU5D_t1664964607* get_FilterTypes_2() const { return ___FilterTypes_2; }
	inline TypeU5BU5D_t1664964607** get_address_of_FilterTypes_2() { return &___FilterTypes_2; }
	inline void set_FilterTypes_2(TypeU5BU5D_t1664964607* value)
	{
		___FilterTypes_2 = value;
		Il2CppCodeGenWriteBarrier(&___FilterTypes_2, value);
	}

	inline static int32_t get_offset_of_MemberName_3() { return static_cast<int32_t>(offsetof(BindingInfo_t2210172430, ___MemberName_3)); }
	inline String_t* get_MemberName_3() const { return ___MemberName_3; }
	inline String_t** get_address_of_MemberName_3() { return &___MemberName_3; }
	inline void set_MemberName_3(String_t* value)
	{
		___MemberName_3 = value;
		Il2CppCodeGenWriteBarrier(&___MemberName_3, value);
	}

	inline static int32_t get_offset_of_U3CActionU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(BindingInfo_t2210172430, ___U3CActionU3Ek__BackingField_4)); }
	inline Action_1_t2491248677 * get_U3CActionU3Ek__BackingField_4() const { return ___U3CActionU3Ek__BackingField_4; }
	inline Action_1_t2491248677 ** get_address_of_U3CActionU3Ek__BackingField_4() { return &___U3CActionU3Ek__BackingField_4; }
	inline void set_U3CActionU3Ek__BackingField_4(Action_1_t2491248677 * value)
	{
		___U3CActionU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CActionU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CShouldShowU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(BindingInfo_t2210172430, ___U3CShouldShowU3Ek__BackingField_5)); }
	inline Func_1_t1485000104 * get_U3CShouldShowU3Ek__BackingField_5() const { return ___U3CShouldShowU3Ek__BackingField_5; }
	inline Func_1_t1485000104 ** get_address_of_U3CShouldShowU3Ek__BackingField_5() { return &___U3CShouldShowU3Ek__BackingField_5; }
	inline void set_U3CShouldShowU3Ek__BackingField_5(Func_1_t1485000104 * value)
	{
		___U3CShouldShowU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CShouldShowU3Ek__BackingField_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
