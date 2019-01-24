#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2115766907.h"

// GameIsPlayingChange`1<Game>
struct GameIsPlayingChange_1_t2912235276;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameActionsPauseUpdate
struct  GameActionsPauseUpdate_t105749616  : public UpdateBehavior_1_t2115766907
{
public:
	// GameIsPlayingChange`1<Game> GameActionsPauseUpdate::gameIsPlayingChange
	GameIsPlayingChange_1_t2912235276 * ___gameIsPlayingChange_4;

public:
	inline static int32_t get_offset_of_gameIsPlayingChange_4() { return static_cast<int32_t>(offsetof(GameActionsPauseUpdate_t105749616, ___gameIsPlayingChange_4)); }
	inline GameIsPlayingChange_1_t2912235276 * get_gameIsPlayingChange_4() const { return ___gameIsPlayingChange_4; }
	inline GameIsPlayingChange_1_t2912235276 ** get_address_of_gameIsPlayingChange_4() { return &___gameIsPlayingChange_4; }
	inline void set_gameIsPlayingChange_4(GameIsPlayingChange_1_t2912235276 * value)
	{
		___gameIsPlayingChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
