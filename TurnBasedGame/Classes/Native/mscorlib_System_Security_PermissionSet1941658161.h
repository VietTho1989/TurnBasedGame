#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Security_Permissions_PermissionSta3557289502.h"

// System.String
struct String_t;
// System.Object[]
struct ObjectU5BU5D_t3614634134;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Security.Policy.PolicyLevel
struct PolicyLevel_t43919632;
// System.Boolean[]
struct BooleanU5BU5D_t3568034315;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.PermissionSet
struct  PermissionSet_t1941658161  : public Il2CppObject
{
public:
	// System.Security.Permissions.PermissionState System.Security.PermissionSet::state
	int32_t ___state_3;
	// System.Collections.ArrayList System.Security.PermissionSet::list
	ArrayList_t4252133567 * ___list_4;
	// System.Security.Policy.PolicyLevel System.Security.PermissionSet::_policyLevel
	PolicyLevel_t43919632 * ____policyLevel_5;
	// System.Boolean System.Security.PermissionSet::_declsec
	bool ____declsec_6;
	// System.Boolean System.Security.PermissionSet::_readOnly
	bool ____readOnly_7;
	// System.Boolean[] System.Security.PermissionSet::_ignored
	BooleanU5BU5D_t3568034315* ____ignored_8;

public:
	inline static int32_t get_offset_of_state_3() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161, ___state_3)); }
	inline int32_t get_state_3() const { return ___state_3; }
	inline int32_t* get_address_of_state_3() { return &___state_3; }
	inline void set_state_3(int32_t value)
	{
		___state_3 = value;
	}

	inline static int32_t get_offset_of_list_4() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161, ___list_4)); }
	inline ArrayList_t4252133567 * get_list_4() const { return ___list_4; }
	inline ArrayList_t4252133567 ** get_address_of_list_4() { return &___list_4; }
	inline void set_list_4(ArrayList_t4252133567 * value)
	{
		___list_4 = value;
		Il2CppCodeGenWriteBarrier(&___list_4, value);
	}

	inline static int32_t get_offset_of__policyLevel_5() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161, ____policyLevel_5)); }
	inline PolicyLevel_t43919632 * get__policyLevel_5() const { return ____policyLevel_5; }
	inline PolicyLevel_t43919632 ** get_address_of__policyLevel_5() { return &____policyLevel_5; }
	inline void set__policyLevel_5(PolicyLevel_t43919632 * value)
	{
		____policyLevel_5 = value;
		Il2CppCodeGenWriteBarrier(&____policyLevel_5, value);
	}

	inline static int32_t get_offset_of__declsec_6() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161, ____declsec_6)); }
	inline bool get__declsec_6() const { return ____declsec_6; }
	inline bool* get_address_of__declsec_6() { return &____declsec_6; }
	inline void set__declsec_6(bool value)
	{
		____declsec_6 = value;
	}

	inline static int32_t get_offset_of__readOnly_7() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161, ____readOnly_7)); }
	inline bool get__readOnly_7() const { return ____readOnly_7; }
	inline bool* get_address_of__readOnly_7() { return &____readOnly_7; }
	inline void set__readOnly_7(bool value)
	{
		____readOnly_7 = value;
	}

	inline static int32_t get_offset_of__ignored_8() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161, ____ignored_8)); }
	inline BooleanU5BU5D_t3568034315* get__ignored_8() const { return ____ignored_8; }
	inline BooleanU5BU5D_t3568034315** get_address_of__ignored_8() { return &____ignored_8; }
	inline void set__ignored_8(BooleanU5BU5D_t3568034315* value)
	{
		____ignored_8 = value;
		Il2CppCodeGenWriteBarrier(&____ignored_8, value);
	}
};

struct PermissionSet_t1941658161_StaticFields
{
public:
	// System.Object[] System.Security.PermissionSet::psUnrestricted
	ObjectU5BU5D_t3614634134* ___psUnrestricted_2;
	// System.Object[] System.Security.PermissionSet::action
	ObjectU5BU5D_t3614634134* ___action_9;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Security.PermissionSet::<>f__switch$map2B
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map2B_10;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Security.PermissionSet::<>f__switch$map2C
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map2C_11;

public:
	inline static int32_t get_offset_of_psUnrestricted_2() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161_StaticFields, ___psUnrestricted_2)); }
	inline ObjectU5BU5D_t3614634134* get_psUnrestricted_2() const { return ___psUnrestricted_2; }
	inline ObjectU5BU5D_t3614634134** get_address_of_psUnrestricted_2() { return &___psUnrestricted_2; }
	inline void set_psUnrestricted_2(ObjectU5BU5D_t3614634134* value)
	{
		___psUnrestricted_2 = value;
		Il2CppCodeGenWriteBarrier(&___psUnrestricted_2, value);
	}

	inline static int32_t get_offset_of_action_9() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161_StaticFields, ___action_9)); }
	inline ObjectU5BU5D_t3614634134* get_action_9() const { return ___action_9; }
	inline ObjectU5BU5D_t3614634134** get_address_of_action_9() { return &___action_9; }
	inline void set_action_9(ObjectU5BU5D_t3614634134* value)
	{
		___action_9 = value;
		Il2CppCodeGenWriteBarrier(&___action_9, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map2B_10() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161_StaticFields, ___U3CU3Ef__switchU24map2B_10)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map2B_10() const { return ___U3CU3Ef__switchU24map2B_10; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map2B_10() { return &___U3CU3Ef__switchU24map2B_10; }
	inline void set_U3CU3Ef__switchU24map2B_10(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map2B_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map2B_10, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map2C_11() { return static_cast<int32_t>(offsetof(PermissionSet_t1941658161_StaticFields, ___U3CU3Ef__switchU24map2C_11)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map2C_11() const { return ___U3CU3Ef__switchU24map2C_11; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map2C_11() { return &___U3CU3Ef__switchU24map2C_11; }
	inline void set_U3CU3Ef__switchU24map2C_11(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map2C_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map2C_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
