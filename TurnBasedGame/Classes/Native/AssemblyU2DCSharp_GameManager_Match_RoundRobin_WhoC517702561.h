#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen2403801547.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// AccountAvatarUI
struct AccountAvatarUI_t3584502088;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk
struct RequestNewRoundRobinStateAsk_t569526181;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.WhoCanAskHolder
struct  WhoCanAskHolder_t517702561  : public SriaHolderBehavior_1_t2403801547
{
public:
	// UnityEngine.UI.Text GameManager.Match.RoundRobin.WhoCanAskHolder::tvName
	Text_t356221433 * ___tvName_16;
	// UnityEngine.UI.Text GameManager.Match.RoundRobin.WhoCanAskHolder::tvAnswer
	Text_t356221433 * ___tvAnswer_17;
	// AccountAvatarUI GameManager.Match.RoundRobin.WhoCanAskHolder::avatarPrefab
	AccountAvatarUI_t3584502088 * ___avatarPrefab_18;
	// UnityEngine.Transform GameManager.Match.RoundRobin.WhoCanAskHolder::avatarContainer
	Transform_t3275118058 * ___avatarContainer_19;
	// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk GameManager.Match.RoundRobin.WhoCanAskHolder::requestNewRoundRobinStateAsk
	RequestNewRoundRobinStateAsk_t569526181 * ___requestNewRoundRobinStateAsk_20;

public:
	inline static int32_t get_offset_of_tvName_16() { return static_cast<int32_t>(offsetof(WhoCanAskHolder_t517702561, ___tvName_16)); }
	inline Text_t356221433 * get_tvName_16() const { return ___tvName_16; }
	inline Text_t356221433 ** get_address_of_tvName_16() { return &___tvName_16; }
	inline void set_tvName_16(Text_t356221433 * value)
	{
		___tvName_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_16, value);
	}

	inline static int32_t get_offset_of_tvAnswer_17() { return static_cast<int32_t>(offsetof(WhoCanAskHolder_t517702561, ___tvAnswer_17)); }
	inline Text_t356221433 * get_tvAnswer_17() const { return ___tvAnswer_17; }
	inline Text_t356221433 ** get_address_of_tvAnswer_17() { return &___tvAnswer_17; }
	inline void set_tvAnswer_17(Text_t356221433 * value)
	{
		___tvAnswer_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvAnswer_17, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_18() { return static_cast<int32_t>(offsetof(WhoCanAskHolder_t517702561, ___avatarPrefab_18)); }
	inline AccountAvatarUI_t3584502088 * get_avatarPrefab_18() const { return ___avatarPrefab_18; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_avatarPrefab_18() { return &___avatarPrefab_18; }
	inline void set_avatarPrefab_18(AccountAvatarUI_t3584502088 * value)
	{
		___avatarPrefab_18 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_18, value);
	}

	inline static int32_t get_offset_of_avatarContainer_19() { return static_cast<int32_t>(offsetof(WhoCanAskHolder_t517702561, ___avatarContainer_19)); }
	inline Transform_t3275118058 * get_avatarContainer_19() const { return ___avatarContainer_19; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_19() { return &___avatarContainer_19; }
	inline void set_avatarContainer_19(Transform_t3275118058 * value)
	{
		___avatarContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_19, value);
	}

	inline static int32_t get_offset_of_requestNewRoundRobinStateAsk_20() { return static_cast<int32_t>(offsetof(WhoCanAskHolder_t517702561, ___requestNewRoundRobinStateAsk_20)); }
	inline RequestNewRoundRobinStateAsk_t569526181 * get_requestNewRoundRobinStateAsk_20() const { return ___requestNewRoundRobinStateAsk_20; }
	inline RequestNewRoundRobinStateAsk_t569526181 ** get_address_of_requestNewRoundRobinStateAsk_20() { return &___requestNewRoundRobinStateAsk_20; }
	inline void set_requestNewRoundRobinStateAsk_20(RequestNewRoundRobinStateAsk_t569526181 * value)
	{
		___requestNewRoundRobinStateAsk_20 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundRobinStateAsk_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
