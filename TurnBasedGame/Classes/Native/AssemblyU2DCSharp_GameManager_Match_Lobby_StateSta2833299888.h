#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen913979148.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameManager.Match.ContestManagerStateLobby
struct ContestManagerStateLobby_t3432289894;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Lobby.StateStartUpdate
struct  StateStartUpdate_t2833299888  : public UpdateBehavior_1_t913979148
{
public:
	// AdvancedCoroutines.Routine GameManager.Match.Lobby.StateStartUpdate::startTimeCoroutine
	Routine_t2502590640 * ___startTimeCoroutine_4;
	// GameManager.Match.ContestManagerStateLobby GameManager.Match.Lobby.StateStartUpdate::contestManagerStateLobby
	ContestManagerStateLobby_t3432289894 * ___contestManagerStateLobby_5;

public:
	inline static int32_t get_offset_of_startTimeCoroutine_4() { return static_cast<int32_t>(offsetof(StateStartUpdate_t2833299888, ___startTimeCoroutine_4)); }
	inline Routine_t2502590640 * get_startTimeCoroutine_4() const { return ___startTimeCoroutine_4; }
	inline Routine_t2502590640 ** get_address_of_startTimeCoroutine_4() { return &___startTimeCoroutine_4; }
	inline void set_startTimeCoroutine_4(Routine_t2502590640 * value)
	{
		___startTimeCoroutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___startTimeCoroutine_4, value);
	}

	inline static int32_t get_offset_of_contestManagerStateLobby_5() { return static_cast<int32_t>(offsetof(StateStartUpdate_t2833299888, ___contestManagerStateLobby_5)); }
	inline ContestManagerStateLobby_t3432289894 * get_contestManagerStateLobby_5() const { return ___contestManagerStateLobby_5; }
	inline ContestManagerStateLobby_t3432289894 ** get_address_of_contestManagerStateLobby_5() { return &___contestManagerStateLobby_5; }
	inline void set_contestManagerStateLobby_5(ContestManagerStateLobby_t3432289894 * value)
	{
		___contestManagerStateLobby_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStateLobby_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
