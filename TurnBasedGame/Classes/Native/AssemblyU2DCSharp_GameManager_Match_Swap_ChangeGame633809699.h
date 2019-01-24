#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.Swap.ChangeGamePlayerRight>
struct NetData_1_t121242478;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.ChangeGamePlayerRightIdentity
struct  ChangeGamePlayerRightIdentity_t633809699  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.Swap.ChangeGamePlayerRightIdentity::canChange
	bool ___canChange_17;
	// System.Boolean GameManager.Match.Swap.ChangeGamePlayerRightIdentity::canChangePlayerLeft
	bool ___canChangePlayerLeft_18;
	// System.Boolean GameManager.Match.Swap.ChangeGamePlayerRightIdentity::needAdminAccept
	bool ___needAdminAccept_19;
	// System.Boolean GameManager.Match.Swap.ChangeGamePlayerRightIdentity::onlyAdminNeed
	bool ___onlyAdminNeed_20;
	// NetData`1<GameManager.Match.Swap.ChangeGamePlayerRight> GameManager.Match.Swap.ChangeGamePlayerRightIdentity::netData
	NetData_1_t121242478 * ___netData_21;

public:
	inline static int32_t get_offset_of_canChange_17() { return static_cast<int32_t>(offsetof(ChangeGamePlayerRightIdentity_t633809699, ___canChange_17)); }
	inline bool get_canChange_17() const { return ___canChange_17; }
	inline bool* get_address_of_canChange_17() { return &___canChange_17; }
	inline void set_canChange_17(bool value)
	{
		___canChange_17 = value;
	}

	inline static int32_t get_offset_of_canChangePlayerLeft_18() { return static_cast<int32_t>(offsetof(ChangeGamePlayerRightIdentity_t633809699, ___canChangePlayerLeft_18)); }
	inline bool get_canChangePlayerLeft_18() const { return ___canChangePlayerLeft_18; }
	inline bool* get_address_of_canChangePlayerLeft_18() { return &___canChangePlayerLeft_18; }
	inline void set_canChangePlayerLeft_18(bool value)
	{
		___canChangePlayerLeft_18 = value;
	}

	inline static int32_t get_offset_of_needAdminAccept_19() { return static_cast<int32_t>(offsetof(ChangeGamePlayerRightIdentity_t633809699, ___needAdminAccept_19)); }
	inline bool get_needAdminAccept_19() const { return ___needAdminAccept_19; }
	inline bool* get_address_of_needAdminAccept_19() { return &___needAdminAccept_19; }
	inline void set_needAdminAccept_19(bool value)
	{
		___needAdminAccept_19 = value;
	}

	inline static int32_t get_offset_of_onlyAdminNeed_20() { return static_cast<int32_t>(offsetof(ChangeGamePlayerRightIdentity_t633809699, ___onlyAdminNeed_20)); }
	inline bool get_onlyAdminNeed_20() const { return ___onlyAdminNeed_20; }
	inline bool* get_address_of_onlyAdminNeed_20() { return &___onlyAdminNeed_20; }
	inline void set_onlyAdminNeed_20(bool value)
	{
		___onlyAdminNeed_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(ChangeGamePlayerRightIdentity_t633809699, ___netData_21)); }
	inline NetData_1_t121242478 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t121242478 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t121242478 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
