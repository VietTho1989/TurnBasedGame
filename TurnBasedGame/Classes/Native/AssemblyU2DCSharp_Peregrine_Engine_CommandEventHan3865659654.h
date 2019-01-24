#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;
// Peregrine.Engine.CreateTournamentCommand
struct CreateTournamentCommand_t1732776332;
// Peregrine.Engine.CommandEventHandler`1<System.Object>
struct CommandEventHandler_1_t3703827400;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.CommandEventHandler`1/<CreateTournament>c__AnonStorey0<System.Object>
struct  U3CCreateTournamentU3Ec__AnonStorey0_t3865659654  : public Il2CppObject
{
public:
	// TContext Peregrine.Engine.CommandEventHandler`1/<CreateTournament>c__AnonStorey0::context
	Il2CppObject * ___context_0;
	// Peregrine.Engine.CreateTournamentCommand Peregrine.Engine.CommandEventHandler`1/<CreateTournament>c__AnonStorey0::command
	CreateTournamentCommand_t1732776332 * ___command_1;
	// Peregrine.Engine.CommandEventHandler`1<TContext> Peregrine.Engine.CommandEventHandler`1/<CreateTournament>c__AnonStorey0::$this
	CommandEventHandler_1_t3703827400 * ___U24this_2;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(U3CCreateTournamentU3Ec__AnonStorey0_t3865659654, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_command_1() { return static_cast<int32_t>(offsetof(U3CCreateTournamentU3Ec__AnonStorey0_t3865659654, ___command_1)); }
	inline CreateTournamentCommand_t1732776332 * get_command_1() const { return ___command_1; }
	inline CreateTournamentCommand_t1732776332 ** get_address_of_command_1() { return &___command_1; }
	inline void set_command_1(CreateTournamentCommand_t1732776332 * value)
	{
		___command_1 = value;
		Il2CppCodeGenWriteBarrier(&___command_1, value);
	}

	inline static int32_t get_offset_of_U24this_2() { return static_cast<int32_t>(offsetof(U3CCreateTournamentU3Ec__AnonStorey0_t3865659654, ___U24this_2)); }
	inline CommandEventHandler_1_t3703827400 * get_U24this_2() const { return ___U24this_2; }
	inline CommandEventHandler_1_t3703827400 ** get_address_of_U24this_2() { return &___U24this_2; }
	inline void set_U24this_2(CommandEventHandler_1_t3703827400 * value)
	{
		___U24this_2 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
