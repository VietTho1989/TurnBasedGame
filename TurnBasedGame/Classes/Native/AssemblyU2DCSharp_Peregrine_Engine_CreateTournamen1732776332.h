#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTimeOffset1362988906.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.CreateTournamentCommand
struct  CreateTournamentCommand_t1732776332  : public Il2CppObject
{
public:
	// System.DateTimeOffset Peregrine.Engine.CreateTournamentCommand::Timestamp
	DateTimeOffset_t1362988906  ___Timestamp_0;

public:
	inline static int32_t get_offset_of_Timestamp_0() { return static_cast<int32_t>(offsetof(CreateTournamentCommand_t1732776332, ___Timestamp_0)); }
	inline DateTimeOffset_t1362988906  get_Timestamp_0() const { return ___Timestamp_0; }
	inline DateTimeOffset_t1362988906 * get_address_of_Timestamp_0() { return &___Timestamp_0; }
	inline void set_Timestamp_0(DateTimeOffset_t1362988906  value)
	{
		___Timestamp_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
