#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_PlayUI_UIData_Sub47007089.h"

// VP`1<ReferenceData`1<GameState.PlayUnPause>>
struct VP_1_t1380444398;
// VP`1<AccountAvatarUI/UIData>
struct VP_1_t3547432187;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayUnPauseUI/UIData
struct  UIData_t2289674179  : public Sub_t47007089
{
public:
	// VP`1<ReferenceData`1<GameState.PlayUnPause>> GameState.PlayUnPauseUI/UIData::playUnPause
	VP_1_t1380444398 * ___playUnPause_5;
	// VP`1<AccountAvatarUI/UIData> GameState.PlayUnPauseUI/UIData::accountAvatar
	VP_1_t3547432187 * ___accountAvatar_6;

public:
	inline static int32_t get_offset_of_playUnPause_5() { return static_cast<int32_t>(offsetof(UIData_t2289674179, ___playUnPause_5)); }
	inline VP_1_t1380444398 * get_playUnPause_5() const { return ___playUnPause_5; }
	inline VP_1_t1380444398 ** get_address_of_playUnPause_5() { return &___playUnPause_5; }
	inline void set_playUnPause_5(VP_1_t1380444398 * value)
	{
		___playUnPause_5 = value;
		Il2CppCodeGenWriteBarrier(&___playUnPause_5, value);
	}

	inline static int32_t get_offset_of_accountAvatar_6() { return static_cast<int32_t>(offsetof(UIData_t2289674179, ___accountAvatar_6)); }
	inline VP_1_t3547432187 * get_accountAvatar_6() const { return ___accountAvatar_6; }
	inline VP_1_t3547432187 ** get_address_of_accountAvatar_6() { return &___accountAvatar_6; }
	inline void set_accountAvatar_6(VP_1_t3547432187 * value)
	{
		___accountAvatar_6 = value;
		Il2CppCodeGenWriteBarrier(&___accountAvatar_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
