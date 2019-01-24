#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Sync_1_gen1389502306.h"

// System.Collections.Generic.List`1<GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData>
struct List_1_t1064234593;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SyncAdd`1<GameManager.Match.Elimination.ChooseEliminationRoundAdapter/UIData>
struct  SyncAdd_1_t2292688079  : public Sync_1_t1389502306
{
public:
	// System.Int32 SyncAdd`1::index
	int32_t ___index_0;
	// System.Collections.Generic.List`1<T> SyncAdd`1::values
	List_1_t1064234593 * ___values_1;

public:
	inline static int32_t get_offset_of_index_0() { return static_cast<int32_t>(offsetof(SyncAdd_1_t2292688079, ___index_0)); }
	inline int32_t get_index_0() const { return ___index_0; }
	inline int32_t* get_address_of_index_0() { return &___index_0; }
	inline void set_index_0(int32_t value)
	{
		___index_0 = value;
	}

	inline static int32_t get_offset_of_values_1() { return static_cast<int32_t>(offsetof(SyncAdd_1_t2292688079, ___values_1)); }
	inline List_1_t1064234593 * get_values_1() const { return ___values_1; }
	inline List_1_t1064234593 ** get_address_of_values_1() { return &___values_1; }
	inline void set_values_1(List_1_t1064234593 * value)
	{
		___values_1 = value;
		Il2CppCodeGenWriteBarrier(&___values_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
