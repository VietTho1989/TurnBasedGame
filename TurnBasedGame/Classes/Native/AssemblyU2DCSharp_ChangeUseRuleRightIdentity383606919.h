#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<ChangeUseRuleRight>
struct NetData_1_t3704808362;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChangeUseRuleRightIdentity
struct  ChangeUseRuleRightIdentity_t383606919  : public DataIdentity_t543951486
{
public:
	// System.Boolean ChangeUseRuleRightIdentity::canChange
	bool ___canChange_17;
	// System.Boolean ChangeUseRuleRightIdentity::onlyAdmin
	bool ___onlyAdmin_18;
	// System.Boolean ChangeUseRuleRightIdentity::needAdmin
	bool ___needAdmin_19;
	// System.Boolean ChangeUseRuleRightIdentity::needAccept
	bool ___needAccept_20;
	// NetData`1<ChangeUseRuleRight> ChangeUseRuleRightIdentity::netData
	NetData_1_t3704808362 * ___netData_21;

public:
	inline static int32_t get_offset_of_canChange_17() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightIdentity_t383606919, ___canChange_17)); }
	inline bool get_canChange_17() const { return ___canChange_17; }
	inline bool* get_address_of_canChange_17() { return &___canChange_17; }
	inline void set_canChange_17(bool value)
	{
		___canChange_17 = value;
	}

	inline static int32_t get_offset_of_onlyAdmin_18() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightIdentity_t383606919, ___onlyAdmin_18)); }
	inline bool get_onlyAdmin_18() const { return ___onlyAdmin_18; }
	inline bool* get_address_of_onlyAdmin_18() { return &___onlyAdmin_18; }
	inline void set_onlyAdmin_18(bool value)
	{
		___onlyAdmin_18 = value;
	}

	inline static int32_t get_offset_of_needAdmin_19() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightIdentity_t383606919, ___needAdmin_19)); }
	inline bool get_needAdmin_19() const { return ___needAdmin_19; }
	inline bool* get_address_of_needAdmin_19() { return &___needAdmin_19; }
	inline void set_needAdmin_19(bool value)
	{
		___needAdmin_19 = value;
	}

	inline static int32_t get_offset_of_needAccept_20() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightIdentity_t383606919, ___needAccept_20)); }
	inline bool get_needAccept_20() const { return ___needAccept_20; }
	inline bool* get_address_of_needAccept_20() { return &___needAccept_20; }
	inline void set_needAccept_20(bool value)
	{
		___needAccept_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightIdentity_t383606919, ___netData_21)); }
	inline NetData_1_t3704808362 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t3704808362 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t3704808362 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
