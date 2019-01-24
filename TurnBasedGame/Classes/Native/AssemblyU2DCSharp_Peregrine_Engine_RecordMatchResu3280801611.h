#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Nullable_1_gen334943763.h"

// Peregrine.Engine.Player
struct Player_t762644161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.RecordMatchResultsCommand
struct  RecordMatchResultsCommand_t3280801611  : public Il2CppObject
{
public:
	// Peregrine.Engine.Player Peregrine.Engine.RecordMatchResultsCommand::Player
	Player_t762644161 * ___Player_0;
	// System.Nullable`1<System.Int32> Peregrine.Engine.RecordMatchResultsCommand::Wins
	Nullable_1_t334943763  ___Wins_1;
	// System.Nullable`1<System.Int32> Peregrine.Engine.RecordMatchResultsCommand::Losses
	Nullable_1_t334943763  ___Losses_2;
	// System.Nullable`1<System.Int32> Peregrine.Engine.RecordMatchResultsCommand::Draws
	Nullable_1_t334943763  ___Draws_3;

public:
	inline static int32_t get_offset_of_Player_0() { return static_cast<int32_t>(offsetof(RecordMatchResultsCommand_t3280801611, ___Player_0)); }
	inline Player_t762644161 * get_Player_0() const { return ___Player_0; }
	inline Player_t762644161 ** get_address_of_Player_0() { return &___Player_0; }
	inline void set_Player_0(Player_t762644161 * value)
	{
		___Player_0 = value;
		Il2CppCodeGenWriteBarrier(&___Player_0, value);
	}

	inline static int32_t get_offset_of_Wins_1() { return static_cast<int32_t>(offsetof(RecordMatchResultsCommand_t3280801611, ___Wins_1)); }
	inline Nullable_1_t334943763  get_Wins_1() const { return ___Wins_1; }
	inline Nullable_1_t334943763 * get_address_of_Wins_1() { return &___Wins_1; }
	inline void set_Wins_1(Nullable_1_t334943763  value)
	{
		___Wins_1 = value;
	}

	inline static int32_t get_offset_of_Losses_2() { return static_cast<int32_t>(offsetof(RecordMatchResultsCommand_t3280801611, ___Losses_2)); }
	inline Nullable_1_t334943763  get_Losses_2() const { return ___Losses_2; }
	inline Nullable_1_t334943763 * get_address_of_Losses_2() { return &___Losses_2; }
	inline void set_Losses_2(Nullable_1_t334943763  value)
	{
		___Losses_2 = value;
	}

	inline static int32_t get_offset_of_Draws_3() { return static_cast<int32_t>(offsetof(RecordMatchResultsCommand_t3280801611, ___Draws_3)); }
	inline Nullable_1_t334943763  get_Draws_3() const { return ___Draws_3; }
	inline Nullable_1_t334943763 * get_address_of_Draws_3() { return &___Draws_3; }
	inline void set_Draws_3(Nullable_1_t334943763  value)
	{
		___Draws_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
