﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// Peregrine.Engine.Swiss.SwissTournamentContext
struct SwissTournamentContext_t2823021641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.CommandResult`1<Peregrine.Engine.Swiss.SwissTournamentContext>
struct  CommandResult_1_t663975487  : public Il2CppObject
{
public:
	// System.Boolean Peregrine.Engine.CommandResult`1::Rejected
	bool ___Rejected_0;
	// System.String Peregrine.Engine.CommandResult`1::RejectionReason
	String_t* ___RejectionReason_1;
	// TContext Peregrine.Engine.CommandResult`1::Context
	SwissTournamentContext_t2823021641 * ___Context_2;

public:
	inline static int32_t get_offset_of_Rejected_0() { return static_cast<int32_t>(offsetof(CommandResult_1_t663975487, ___Rejected_0)); }
	inline bool get_Rejected_0() const { return ___Rejected_0; }
	inline bool* get_address_of_Rejected_0() { return &___Rejected_0; }
	inline void set_Rejected_0(bool value)
	{
		___Rejected_0 = value;
	}

	inline static int32_t get_offset_of_RejectionReason_1() { return static_cast<int32_t>(offsetof(CommandResult_1_t663975487, ___RejectionReason_1)); }
	inline String_t* get_RejectionReason_1() const { return ___RejectionReason_1; }
	inline String_t** get_address_of_RejectionReason_1() { return &___RejectionReason_1; }
	inline void set_RejectionReason_1(String_t* value)
	{
		___RejectionReason_1 = value;
		Il2CppCodeGenWriteBarrier(&___RejectionReason_1, value);
	}

	inline static int32_t get_offset_of_Context_2() { return static_cast<int32_t>(offsetof(CommandResult_1_t663975487, ___Context_2)); }
	inline SwissTournamentContext_t2823021641 * get_Context_2() const { return ___Context_2; }
	inline SwissTournamentContext_t2823021641 ** get_address_of_Context_2() { return &___Context_2; }
	inline void set_Context_2(SwissTournamentContext_t2823021641 * value)
	{
		___Context_2 = value;
		Il2CppCodeGenWriteBarrier(&___Context_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
