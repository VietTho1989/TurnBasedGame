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

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Player
struct  Player_t762644161  : public Il2CppObject
{
public:
	// System.String Peregrine.Engine.Player::Identifier
	String_t* ___Identifier_0;
	// System.Nullable`1<System.Int32> Peregrine.Engine.Player::RoundDropped
	Nullable_1_t334943763  ___RoundDropped_1;

public:
	inline static int32_t get_offset_of_Identifier_0() { return static_cast<int32_t>(offsetof(Player_t762644161, ___Identifier_0)); }
	inline String_t* get_Identifier_0() const { return ___Identifier_0; }
	inline String_t** get_address_of_Identifier_0() { return &___Identifier_0; }
	inline void set_Identifier_0(String_t* value)
	{
		___Identifier_0 = value;
		Il2CppCodeGenWriteBarrier(&___Identifier_0, value);
	}

	inline static int32_t get_offset_of_RoundDropped_1() { return static_cast<int32_t>(offsetof(Player_t762644161, ___RoundDropped_1)); }
	inline Nullable_1_t334943763  get_RoundDropped_1() const { return ___RoundDropped_1; }
	inline Nullable_1_t334943763 * get_address_of_RoundDropped_1() { return &___RoundDropped_1; }
	inline void set_RoundDropped_1(Nullable_1_t334943763  value)
	{
		___RoundDropped_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
