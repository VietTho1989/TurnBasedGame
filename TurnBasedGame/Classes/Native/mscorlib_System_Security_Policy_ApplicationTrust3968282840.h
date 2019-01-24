#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.ApplicationIdentity
struct ApplicationIdentity_t3292367950;
// System.Security.Policy.PolicyStatement
struct PolicyStatement_t1594053347;
// System.Object
struct Il2CppObject;
// System.Collections.Generic.IList`1<System.Security.Policy.StrongName>
struct IList_1_t3529687871;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Policy.ApplicationTrust
struct  ApplicationTrust_t3968282840  : public Il2CppObject
{
public:
	// System.ApplicationIdentity System.Security.Policy.ApplicationTrust::_appid
	ApplicationIdentity_t3292367950 * ____appid_0;
	// System.Security.Policy.PolicyStatement System.Security.Policy.ApplicationTrust::_defaultPolicy
	PolicyStatement_t1594053347 * ____defaultPolicy_1;
	// System.Object System.Security.Policy.ApplicationTrust::_xtranfo
	Il2CppObject * ____xtranfo_2;
	// System.Boolean System.Security.Policy.ApplicationTrust::_trustrun
	bool ____trustrun_3;
	// System.Boolean System.Security.Policy.ApplicationTrust::_persist
	bool ____persist_4;
	// System.Collections.Generic.IList`1<System.Security.Policy.StrongName> System.Security.Policy.ApplicationTrust::fullTrustAssemblies
	Il2CppObject* ___fullTrustAssemblies_5;

public:
	inline static int32_t get_offset_of__appid_0() { return static_cast<int32_t>(offsetof(ApplicationTrust_t3968282840, ____appid_0)); }
	inline ApplicationIdentity_t3292367950 * get__appid_0() const { return ____appid_0; }
	inline ApplicationIdentity_t3292367950 ** get_address_of__appid_0() { return &____appid_0; }
	inline void set__appid_0(ApplicationIdentity_t3292367950 * value)
	{
		____appid_0 = value;
		Il2CppCodeGenWriteBarrier(&____appid_0, value);
	}

	inline static int32_t get_offset_of__defaultPolicy_1() { return static_cast<int32_t>(offsetof(ApplicationTrust_t3968282840, ____defaultPolicy_1)); }
	inline PolicyStatement_t1594053347 * get__defaultPolicy_1() const { return ____defaultPolicy_1; }
	inline PolicyStatement_t1594053347 ** get_address_of__defaultPolicy_1() { return &____defaultPolicy_1; }
	inline void set__defaultPolicy_1(PolicyStatement_t1594053347 * value)
	{
		____defaultPolicy_1 = value;
		Il2CppCodeGenWriteBarrier(&____defaultPolicy_1, value);
	}

	inline static int32_t get_offset_of__xtranfo_2() { return static_cast<int32_t>(offsetof(ApplicationTrust_t3968282840, ____xtranfo_2)); }
	inline Il2CppObject * get__xtranfo_2() const { return ____xtranfo_2; }
	inline Il2CppObject ** get_address_of__xtranfo_2() { return &____xtranfo_2; }
	inline void set__xtranfo_2(Il2CppObject * value)
	{
		____xtranfo_2 = value;
		Il2CppCodeGenWriteBarrier(&____xtranfo_2, value);
	}

	inline static int32_t get_offset_of__trustrun_3() { return static_cast<int32_t>(offsetof(ApplicationTrust_t3968282840, ____trustrun_3)); }
	inline bool get__trustrun_3() const { return ____trustrun_3; }
	inline bool* get_address_of__trustrun_3() { return &____trustrun_3; }
	inline void set__trustrun_3(bool value)
	{
		____trustrun_3 = value;
	}

	inline static int32_t get_offset_of__persist_4() { return static_cast<int32_t>(offsetof(ApplicationTrust_t3968282840, ____persist_4)); }
	inline bool get__persist_4() const { return ____persist_4; }
	inline bool* get_address_of__persist_4() { return &____persist_4; }
	inline void set__persist_4(bool value)
	{
		____persist_4 = value;
	}

	inline static int32_t get_offset_of_fullTrustAssemblies_5() { return static_cast<int32_t>(offsetof(ApplicationTrust_t3968282840, ___fullTrustAssemblies_5)); }
	inline Il2CppObject* get_fullTrustAssemblies_5() const { return ___fullTrustAssemblies_5; }
	inline Il2CppObject** get_address_of_fullTrustAssemblies_5() { return &___fullTrustAssemblies_5; }
	inline void set_fullTrustAssemblies_5(Il2CppObject* value)
	{
		___fullTrustAssemblies_5 = value;
		Il2CppCodeGenWriteBarrier(&___fullTrustAssemblies_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
