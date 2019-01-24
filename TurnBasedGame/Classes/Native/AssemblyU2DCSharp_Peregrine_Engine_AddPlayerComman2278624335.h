#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Peregrine.Engine.Player
struct Player_t762644161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.AddPlayerCommand
struct  AddPlayerCommand_t2278624335  : public Il2CppObject
{
public:
	// Peregrine.Engine.Player Peregrine.Engine.AddPlayerCommand::Player
	Player_t762644161 * ___Player_0;

public:
	inline static int32_t get_offset_of_Player_0() { return static_cast<int32_t>(offsetof(AddPlayerCommand_t2278624335, ___Player_0)); }
	inline Player_t762644161 * get_Player_0() const { return ___Player_0; }
	inline Player_t762644161 ** get_address_of_Player_0() { return &___Player_0; }
	inline void set_Player_0(Player_t762644161 * value)
	{
		___Player_0 = value;
		Il2CppCodeGenWriteBarrier(&___Player_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
