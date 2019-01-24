#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_Peregrine_Engine_TournamentState1212310076.h"
#include "mscorlib_System_Nullable_1_gen334943763.h"

// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Player>
struct IEnumerable_1_t1054771206;
// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.MatchResult>
struct IEnumerable_1_t2507142393;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissTournamentContext
struct  SwissTournamentContext_t2823021641  : public Il2CppObject
{
public:
	// System.Int32 Peregrine.Engine.Swiss.SwissTournamentContext::TournamentSeed
	int32_t ___TournamentSeed_0;
	// Peregrine.Engine.TournamentState Peregrine.Engine.Swiss.SwissTournamentContext::State
	int32_t ___State_1;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Player> Peregrine.Engine.Swiss.SwissTournamentContext::Players
	Il2CppObject* ___Players_2;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.MatchResult> Peregrine.Engine.Swiss.SwissTournamentContext::MatchResults
	Il2CppObject* ___MatchResults_3;
	// System.Nullable`1<System.Int32> Peregrine.Engine.Swiss.SwissTournamentContext::ActiveRound
	Nullable_1_t334943763  ___ActiveRound_4;

public:
	inline static int32_t get_offset_of_TournamentSeed_0() { return static_cast<int32_t>(offsetof(SwissTournamentContext_t2823021641, ___TournamentSeed_0)); }
	inline int32_t get_TournamentSeed_0() const { return ___TournamentSeed_0; }
	inline int32_t* get_address_of_TournamentSeed_0() { return &___TournamentSeed_0; }
	inline void set_TournamentSeed_0(int32_t value)
	{
		___TournamentSeed_0 = value;
	}

	inline static int32_t get_offset_of_State_1() { return static_cast<int32_t>(offsetof(SwissTournamentContext_t2823021641, ___State_1)); }
	inline int32_t get_State_1() const { return ___State_1; }
	inline int32_t* get_address_of_State_1() { return &___State_1; }
	inline void set_State_1(int32_t value)
	{
		___State_1 = value;
	}

	inline static int32_t get_offset_of_Players_2() { return static_cast<int32_t>(offsetof(SwissTournamentContext_t2823021641, ___Players_2)); }
	inline Il2CppObject* get_Players_2() const { return ___Players_2; }
	inline Il2CppObject** get_address_of_Players_2() { return &___Players_2; }
	inline void set_Players_2(Il2CppObject* value)
	{
		___Players_2 = value;
		Il2CppCodeGenWriteBarrier(&___Players_2, value);
	}

	inline static int32_t get_offset_of_MatchResults_3() { return static_cast<int32_t>(offsetof(SwissTournamentContext_t2823021641, ___MatchResults_3)); }
	inline Il2CppObject* get_MatchResults_3() const { return ___MatchResults_3; }
	inline Il2CppObject** get_address_of_MatchResults_3() { return &___MatchResults_3; }
	inline void set_MatchResults_3(Il2CppObject* value)
	{
		___MatchResults_3 = value;
		Il2CppCodeGenWriteBarrier(&___MatchResults_3, value);
	}

	inline static int32_t get_offset_of_ActiveRound_4() { return static_cast<int32_t>(offsetof(SwissTournamentContext_t2823021641, ___ActiveRound_4)); }
	inline Nullable_1_t334943763  get_ActiveRound_4() const { return ___ActiveRound_4; }
	inline Nullable_1_t334943763 * get_address_of_ActiveRound_4() { return &___ActiveRound_4; }
	inline void set_ActiveRound_4(Nullable_1_t334943763  value)
	{
		___ActiveRound_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
