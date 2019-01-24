#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_PlayUI_UIData_Sub47007089.h"

// VP`1<ReferenceData`1<GameState.PlayPause>>
struct VP_1_t1758679237;
// VP`1<AccountAvatarUI/UIData>
struct VP_1_t3547432187;
// VP`1<GameState.PlayPauseUI/UIData/State>
struct VP_1_t1292189278;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayPauseUI/UIData
struct  UIData_t2218912758  : public Sub_t47007089
{
public:
	// VP`1<ReferenceData`1<GameState.PlayPause>> GameState.PlayPauseUI/UIData::playPause
	VP_1_t1758679237 * ___playPause_5;
	// VP`1<AccountAvatarUI/UIData> GameState.PlayPauseUI/UIData::accountAvatar
	VP_1_t3547432187 * ___accountAvatar_6;
	// VP`1<GameState.PlayPauseUI/UIData/State> GameState.PlayPauseUI/UIData::state
	VP_1_t1292189278 * ___state_7;

public:
	inline static int32_t get_offset_of_playPause_5() { return static_cast<int32_t>(offsetof(UIData_t2218912758, ___playPause_5)); }
	inline VP_1_t1758679237 * get_playPause_5() const { return ___playPause_5; }
	inline VP_1_t1758679237 ** get_address_of_playPause_5() { return &___playPause_5; }
	inline void set_playPause_5(VP_1_t1758679237 * value)
	{
		___playPause_5 = value;
		Il2CppCodeGenWriteBarrier(&___playPause_5, value);
	}

	inline static int32_t get_offset_of_accountAvatar_6() { return static_cast<int32_t>(offsetof(UIData_t2218912758, ___accountAvatar_6)); }
	inline VP_1_t3547432187 * get_accountAvatar_6() const { return ___accountAvatar_6; }
	inline VP_1_t3547432187 ** get_address_of_accountAvatar_6() { return &___accountAvatar_6; }
	inline void set_accountAvatar_6(VP_1_t3547432187 * value)
	{
		___accountAvatar_6 = value;
		Il2CppCodeGenWriteBarrier(&___accountAvatar_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(UIData_t2218912758, ___state_7)); }
	inline VP_1_t1292189278 * get_state_7() const { return ___state_7; }
	inline VP_1_t1292189278 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t1292189278 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
