#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Security.Policy.PolicyStatement
struct PolicyStatement_t1594053347;
// System.Security.Policy.IMembershipCondition
struct IMembershipCondition_t373187562;
// System.String
struct String_t;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Policy.CodeGroup
struct  CodeGroup_t1856851900  : public Il2CppObject
{
public:
	// System.Security.Policy.PolicyStatement System.Security.Policy.CodeGroup::m_policy
	PolicyStatement_t1594053347 * ___m_policy_0;
	// System.Security.Policy.IMembershipCondition System.Security.Policy.CodeGroup::m_membershipCondition
	Il2CppObject * ___m_membershipCondition_1;
	// System.String System.Security.Policy.CodeGroup::m_description
	String_t* ___m_description_2;
	// System.String System.Security.Policy.CodeGroup::m_name
	String_t* ___m_name_3;
	// System.Collections.ArrayList System.Security.Policy.CodeGroup::m_children
	ArrayList_t4252133567 * ___m_children_4;

public:
	inline static int32_t get_offset_of_m_policy_0() { return static_cast<int32_t>(offsetof(CodeGroup_t1856851900, ___m_policy_0)); }
	inline PolicyStatement_t1594053347 * get_m_policy_0() const { return ___m_policy_0; }
	inline PolicyStatement_t1594053347 ** get_address_of_m_policy_0() { return &___m_policy_0; }
	inline void set_m_policy_0(PolicyStatement_t1594053347 * value)
	{
		___m_policy_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_policy_0, value);
	}

	inline static int32_t get_offset_of_m_membershipCondition_1() { return static_cast<int32_t>(offsetof(CodeGroup_t1856851900, ___m_membershipCondition_1)); }
	inline Il2CppObject * get_m_membershipCondition_1() const { return ___m_membershipCondition_1; }
	inline Il2CppObject ** get_address_of_m_membershipCondition_1() { return &___m_membershipCondition_1; }
	inline void set_m_membershipCondition_1(Il2CppObject * value)
	{
		___m_membershipCondition_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_membershipCondition_1, value);
	}

	inline static int32_t get_offset_of_m_description_2() { return static_cast<int32_t>(offsetof(CodeGroup_t1856851900, ___m_description_2)); }
	inline String_t* get_m_description_2() const { return ___m_description_2; }
	inline String_t** get_address_of_m_description_2() { return &___m_description_2; }
	inline void set_m_description_2(String_t* value)
	{
		___m_description_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_description_2, value);
	}

	inline static int32_t get_offset_of_m_name_3() { return static_cast<int32_t>(offsetof(CodeGroup_t1856851900, ___m_name_3)); }
	inline String_t* get_m_name_3() const { return ___m_name_3; }
	inline String_t** get_address_of_m_name_3() { return &___m_name_3; }
	inline void set_m_name_3(String_t* value)
	{
		___m_name_3 = value;
		Il2CppCodeGenWriteBarrier(&___m_name_3, value);
	}

	inline static int32_t get_offset_of_m_children_4() { return static_cast<int32_t>(offsetof(CodeGroup_t1856851900, ___m_children_4)); }
	inline ArrayList_t4252133567 * get_m_children_4() const { return ___m_children_4; }
	inline ArrayList_t4252133567 ** get_address_of_m_children_4() { return &___m_children_4; }
	inline void set_m_children_4(ArrayList_t4252133567 * value)
	{
		___m_children_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_children_4, value);
	}
};

struct CodeGroup_t1856851900_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Security.Policy.CodeGroup::<>f__switch$map2E
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map2E_5;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map2E_5() { return static_cast<int32_t>(offsetof(CodeGroup_t1856851900_StaticFields, ___U3CU3Ef__switchU24map2E_5)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map2E_5() const { return ___U3CU3Ef__switchU24map2E_5; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map2E_5() { return &___U3CU3Ef__switchU24map2E_5; }
	inline void set_U3CU3Ef__switchU24map2E_5(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map2E_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map2E_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
