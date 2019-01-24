#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Peregrine.Engine.Swiss.SwissTournamentContext
struct SwissTournamentContext_t2823021641;
// Peregrine.Engine.AddPlayerCommand
struct AddPlayerCommand_t2278624335;
// Peregrine.Engine.CommandEventHandler`1<Peregrine.Engine.Swiss.SwissTournamentContext>
struct CommandEventHandler_1_t3837399746;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.CommandEventHandler`1/<AddPlayer>c__AnonStorey1<Peregrine.Engine.Swiss.SwissTournamentContext>
struct  U3CAddPlayerU3Ec__AnonStorey1_t3102060148  : public Il2CppObject
{
public:
	// TContext Peregrine.Engine.CommandEventHandler`1/<AddPlayer>c__AnonStorey1::context
	SwissTournamentContext_t2823021641 * ___context_0;
	// Peregrine.Engine.AddPlayerCommand Peregrine.Engine.CommandEventHandler`1/<AddPlayer>c__AnonStorey1::command
	AddPlayerCommand_t2278624335 * ___command_1;
	// Peregrine.Engine.CommandEventHandler`1<TContext> Peregrine.Engine.CommandEventHandler`1/<AddPlayer>c__AnonStorey1::$this
	CommandEventHandler_1_t3837399746 * ___U24this_2;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(U3CAddPlayerU3Ec__AnonStorey1_t3102060148, ___context_0)); }
	inline SwissTournamentContext_t2823021641 * get_context_0() const { return ___context_0; }
	inline SwissTournamentContext_t2823021641 ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(SwissTournamentContext_t2823021641 * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_command_1() { return static_cast<int32_t>(offsetof(U3CAddPlayerU3Ec__AnonStorey1_t3102060148, ___command_1)); }
	inline AddPlayerCommand_t2278624335 * get_command_1() const { return ___command_1; }
	inline AddPlayerCommand_t2278624335 ** get_address_of_command_1() { return &___command_1; }
	inline void set_command_1(AddPlayerCommand_t2278624335 * value)
	{
		___command_1 = value;
		Il2CppCodeGenWriteBarrier(&___command_1, value);
	}

	inline static int32_t get_offset_of_U24this_2() { return static_cast<int32_t>(offsetof(U3CAddPlayerU3Ec__AnonStorey1_t3102060148, ___U24this_2)); }
	inline CommandEventHandler_1_t3837399746 * get_U24this_2() const { return ___U24this_2; }
	inline CommandEventHandler_1_t3837399746 ** get_address_of_U24this_2() { return &___U24this_2; }
	inline void set_U24this_2(CommandEventHandler_1_t3837399746 * value)
	{
		___U24this_2 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
