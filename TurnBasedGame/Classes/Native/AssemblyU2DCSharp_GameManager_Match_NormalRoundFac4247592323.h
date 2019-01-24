#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_RoundFactory1835073248.h"

// VP`1<GameFactory>
struct VP_1_t1609533170;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<CalculateScore>
struct VP_1_t3414263936;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.NormalRoundFactory
struct  NormalRoundFactory_t4247592323  : public RoundFactory_t1835073248
{
public:
	// VP`1<GameFactory> GameManager.Match.NormalRoundFactory::gameFactory
	VP_1_t1609533170 * ___gameFactory_5;
	// VP`1<System.Boolean> GameManager.Match.NormalRoundFactory::isChangeSideBetweenRound
	VP_1_t4203851724 * ___isChangeSideBetweenRound_6;
	// VP`1<System.Boolean> GameManager.Match.NormalRoundFactory::isSwitchPlayer
	VP_1_t4203851724 * ___isSwitchPlayer_7;
	// VP`1<System.Boolean> GameManager.Match.NormalRoundFactory::isDifferentInTeam
	VP_1_t4203851724 * ___isDifferentInTeam_8;
	// VP`1<CalculateScore> GameManager.Match.NormalRoundFactory::calculateScore
	VP_1_t3414263936 * ___calculateScore_9;

public:
	inline static int32_t get_offset_of_gameFactory_5() { return static_cast<int32_t>(offsetof(NormalRoundFactory_t4247592323, ___gameFactory_5)); }
	inline VP_1_t1609533170 * get_gameFactory_5() const { return ___gameFactory_5; }
	inline VP_1_t1609533170 ** get_address_of_gameFactory_5() { return &___gameFactory_5; }
	inline void set_gameFactory_5(VP_1_t1609533170 * value)
	{
		___gameFactory_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameFactory_5, value);
	}

	inline static int32_t get_offset_of_isChangeSideBetweenRound_6() { return static_cast<int32_t>(offsetof(NormalRoundFactory_t4247592323, ___isChangeSideBetweenRound_6)); }
	inline VP_1_t4203851724 * get_isChangeSideBetweenRound_6() const { return ___isChangeSideBetweenRound_6; }
	inline VP_1_t4203851724 ** get_address_of_isChangeSideBetweenRound_6() { return &___isChangeSideBetweenRound_6; }
	inline void set_isChangeSideBetweenRound_6(VP_1_t4203851724 * value)
	{
		___isChangeSideBetweenRound_6 = value;
		Il2CppCodeGenWriteBarrier(&___isChangeSideBetweenRound_6, value);
	}

	inline static int32_t get_offset_of_isSwitchPlayer_7() { return static_cast<int32_t>(offsetof(NormalRoundFactory_t4247592323, ___isSwitchPlayer_7)); }
	inline VP_1_t4203851724 * get_isSwitchPlayer_7() const { return ___isSwitchPlayer_7; }
	inline VP_1_t4203851724 ** get_address_of_isSwitchPlayer_7() { return &___isSwitchPlayer_7; }
	inline void set_isSwitchPlayer_7(VP_1_t4203851724 * value)
	{
		___isSwitchPlayer_7 = value;
		Il2CppCodeGenWriteBarrier(&___isSwitchPlayer_7, value);
	}

	inline static int32_t get_offset_of_isDifferentInTeam_8() { return static_cast<int32_t>(offsetof(NormalRoundFactory_t4247592323, ___isDifferentInTeam_8)); }
	inline VP_1_t4203851724 * get_isDifferentInTeam_8() const { return ___isDifferentInTeam_8; }
	inline VP_1_t4203851724 ** get_address_of_isDifferentInTeam_8() { return &___isDifferentInTeam_8; }
	inline void set_isDifferentInTeam_8(VP_1_t4203851724 * value)
	{
		___isDifferentInTeam_8 = value;
		Il2CppCodeGenWriteBarrier(&___isDifferentInTeam_8, value);
	}

	inline static int32_t get_offset_of_calculateScore_9() { return static_cast<int32_t>(offsetof(NormalRoundFactory_t4247592323, ___calculateScore_9)); }
	inline VP_1_t3414263936 * get_calculateScore_9() const { return ___calculateScore_9; }
	inline VP_1_t3414263936 ** get_address_of_calculateScore_9() { return &___calculateScore_9; }
	inline void set_calculateScore_9(VP_1_t3414263936 * value)
	{
		___calculateScore_9 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScore_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
