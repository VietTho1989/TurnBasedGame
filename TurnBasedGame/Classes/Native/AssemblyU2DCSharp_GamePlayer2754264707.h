#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<GamePlayer/Inform>
struct VP_1_t92972119;
// VP`1<GamePlayer/State>
struct VP_1_t3904005313;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayer
struct  GamePlayer_t2754264707  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GamePlayer::playerIndex
	VP_1_t2450154454 * ___playerIndex_5;
	// VP`1<GamePlayer/Inform> GamePlayer::inform
	VP_1_t92972119 * ___inform_6;
	// VP`1<GamePlayer/State> GamePlayer::state
	VP_1_t3904005313 * ___state_7;

public:
	inline static int32_t get_offset_of_playerIndex_5() { return static_cast<int32_t>(offsetof(GamePlayer_t2754264707, ___playerIndex_5)); }
	inline VP_1_t2450154454 * get_playerIndex_5() const { return ___playerIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_5() { return &___playerIndex_5; }
	inline void set_playerIndex_5(VP_1_t2450154454 * value)
	{
		___playerIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_5, value);
	}

	inline static int32_t get_offset_of_inform_6() { return static_cast<int32_t>(offsetof(GamePlayer_t2754264707, ___inform_6)); }
	inline VP_1_t92972119 * get_inform_6() const { return ___inform_6; }
	inline VP_1_t92972119 ** get_address_of_inform_6() { return &___inform_6; }
	inline void set_inform_6(VP_1_t92972119 * value)
	{
		___inform_6 = value;
		Il2CppCodeGenWriteBarrier(&___inform_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(GamePlayer_t2754264707, ___state_7)); }
	inline VP_1_t3904005313 * get_state_7() const { return ___state_7; }
	inline VP_1_t3904005313 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t3904005313 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
