﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Change_1_gen1530559754.h"

// System.Collections.Generic.List`1<Makruk.MakrukMove>
struct List_1_t388018844;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChangeAdd`1<Makruk.MakrukMove>
struct  ChangeAdd_1_t2305128797  : public Change_1_t1530559754
{
public:
	// System.Int32 ChangeAdd`1::index
	int32_t ___index_0;
	// System.Collections.Generic.List`1<T> ChangeAdd`1::values
	List_1_t388018844 * ___values_1;

public:
	inline static int32_t get_offset_of_index_0() { return static_cast<int32_t>(offsetof(ChangeAdd_1_t2305128797, ___index_0)); }
	inline int32_t get_index_0() const { return ___index_0; }
	inline int32_t* get_address_of_index_0() { return &___index_0; }
	inline void set_index_0(int32_t value)
	{
		___index_0 = value;
	}

	inline static int32_t get_offset_of_values_1() { return static_cast<int32_t>(offsetof(ChangeAdd_1_t2305128797, ___values_1)); }
	inline List_1_t388018844 * get_values_1() const { return ___values_1; }
	inline List_1_t388018844 ** get_address_of_values_1() { return &___values_1; }
	inline void set_values_1(List_1_t388018844 * value)
	{
		___values_1 = value;
		Il2CppCodeGenWriteBarrier(&___values_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif