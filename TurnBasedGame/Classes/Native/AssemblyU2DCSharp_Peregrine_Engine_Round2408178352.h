#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match>
struct IEnumerable_1_t3614089848;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Round
struct  Round_t2408178352  : public Il2CppObject
{
public:
	// System.Int32 Peregrine.Engine.Round::Number
	int32_t ___Number_0;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match> Peregrine.Engine.Round::Matches
	Il2CppObject* ___Matches_1;

public:
	inline static int32_t get_offset_of_Number_0() { return static_cast<int32_t>(offsetof(Round_t2408178352, ___Number_0)); }
	inline int32_t get_Number_0() const { return ___Number_0; }
	inline int32_t* get_address_of_Number_0() { return &___Number_0; }
	inline void set_Number_0(int32_t value)
	{
		___Number_0 = value;
	}

	inline static int32_t get_offset_of_Matches_1() { return static_cast<int32_t>(offsetof(Round_t2408178352, ___Matches_1)); }
	inline Il2CppObject* get_Matches_1() const { return ___Matches_1; }
	inline Il2CppObject** get_address_of_Matches_1() { return &___Matches_1; }
	inline void set_Matches_1(Il2CppObject* value)
	{
		___Matches_1 = value;
		Il2CppCodeGenWriteBarrier(&___Matches_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
