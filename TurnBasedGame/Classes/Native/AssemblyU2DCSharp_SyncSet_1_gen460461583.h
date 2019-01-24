#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Sync_1_gen2176250221.h"

// System.Collections.Generic.List`1<GameManager.Match.TeamState>
struct List_1_t1850982508;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SyncSet`1<GameManager.Match.TeamState>
struct  SyncSet_1_t460461583  : public Sync_1_t2176250221
{
public:
	// System.Int32 SyncSet`1::index
	int32_t ___index_0;
	// System.Collections.Generic.List`1<T> SyncSet`1::olds
	List_1_t1850982508 * ___olds_1;
	// System.Collections.Generic.List`1<T> SyncSet`1::news
	List_1_t1850982508 * ___news_2;

public:
	inline static int32_t get_offset_of_index_0() { return static_cast<int32_t>(offsetof(SyncSet_1_t460461583, ___index_0)); }
	inline int32_t get_index_0() const { return ___index_0; }
	inline int32_t* get_address_of_index_0() { return &___index_0; }
	inline void set_index_0(int32_t value)
	{
		___index_0 = value;
	}

	inline static int32_t get_offset_of_olds_1() { return static_cast<int32_t>(offsetof(SyncSet_1_t460461583, ___olds_1)); }
	inline List_1_t1850982508 * get_olds_1() const { return ___olds_1; }
	inline List_1_t1850982508 ** get_address_of_olds_1() { return &___olds_1; }
	inline void set_olds_1(List_1_t1850982508 * value)
	{
		___olds_1 = value;
		Il2CppCodeGenWriteBarrier(&___olds_1, value);
	}

	inline static int32_t get_offset_of_news_2() { return static_cast<int32_t>(offsetof(SyncSet_1_t460461583, ___news_2)); }
	inline List_1_t1850982508 * get_news_2() const { return ___news_2; }
	inline List_1_t1850982508 ** get_address_of_news_2() { return &___news_2; }
	inline void set_news_2(List_1_t1850982508 * value)
	{
		___news_2 = value;
		Il2CppCodeGenWriteBarrier(&___news_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
