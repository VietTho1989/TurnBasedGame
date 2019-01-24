#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3545689565.h"

// GameManager.Match.CheckContestTeamChange`1<GameManager.Match.RoundGame>
struct CheckContestTeamChange_1_t69223241;
// GameCheckPlayerChange`1<Game>
struct GameCheckPlayerChange_1_t631316331;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.MakeGamePlayerUpdate
struct  MakeGamePlayerUpdate_t1339350222  : public UpdateBehavior_1_t3545689565
{
public:
	// GameManager.Match.CheckContestTeamChange`1<GameManager.Match.RoundGame> GameManager.Match.MakeGamePlayerUpdate::checkContestTeamChange
	CheckContestTeamChange_1_t69223241 * ___checkContestTeamChange_4;
	// GameCheckPlayerChange`1<Game> GameManager.Match.MakeGamePlayerUpdate::checkGamePlayerChange
	GameCheckPlayerChange_1_t631316331 * ___checkGamePlayerChange_5;

public:
	inline static int32_t get_offset_of_checkContestTeamChange_4() { return static_cast<int32_t>(offsetof(MakeGamePlayerUpdate_t1339350222, ___checkContestTeamChange_4)); }
	inline CheckContestTeamChange_1_t69223241 * get_checkContestTeamChange_4() const { return ___checkContestTeamChange_4; }
	inline CheckContestTeamChange_1_t69223241 ** get_address_of_checkContestTeamChange_4() { return &___checkContestTeamChange_4; }
	inline void set_checkContestTeamChange_4(CheckContestTeamChange_1_t69223241 * value)
	{
		___checkContestTeamChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___checkContestTeamChange_4, value);
	}

	inline static int32_t get_offset_of_checkGamePlayerChange_5() { return static_cast<int32_t>(offsetof(MakeGamePlayerUpdate_t1339350222, ___checkGamePlayerChange_5)); }
	inline GameCheckPlayerChange_1_t631316331 * get_checkGamePlayerChange_5() const { return ___checkGamePlayerChange_5; }
	inline GameCheckPlayerChange_1_t631316331 ** get_address_of_checkGamePlayerChange_5() { return &___checkGamePlayerChange_5; }
	inline void set_checkGamePlayerChange_5(GameCheckPlayerChange_1_t631316331 * value)
	{
		___checkGamePlayerChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___checkGamePlayerChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
