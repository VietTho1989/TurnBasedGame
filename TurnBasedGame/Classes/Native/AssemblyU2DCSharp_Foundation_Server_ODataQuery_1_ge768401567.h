#pragma once

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
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.ODataQuery`1<Foundation.Example.ServerTests/DemoObject>
struct  ODataQuery_1_t768401567  : public Il2CppObject
{
public:
	// System.Int32 Foundation.Server.ODataQuery`1::skip
	int32_t ___skip_0;
	// System.Int32 Foundation.Server.ODataQuery`1::take
	int32_t ___take_1;
	// System.String Foundation.Server.ODataQuery`1::orderBy
	String_t* ___orderBy_2;
	// System.Collections.Generic.List`1<System.String> Foundation.Server.ODataQuery`1::filters
	List_1_t1398341365 * ___filters_3;

public:
	inline static int32_t get_offset_of_skip_0() { return static_cast<int32_t>(offsetof(ODataQuery_1_t768401567, ___skip_0)); }
	inline int32_t get_skip_0() const { return ___skip_0; }
	inline int32_t* get_address_of_skip_0() { return &___skip_0; }
	inline void set_skip_0(int32_t value)
	{
		___skip_0 = value;
	}

	inline static int32_t get_offset_of_take_1() { return static_cast<int32_t>(offsetof(ODataQuery_1_t768401567, ___take_1)); }
	inline int32_t get_take_1() const { return ___take_1; }
	inline int32_t* get_address_of_take_1() { return &___take_1; }
	inline void set_take_1(int32_t value)
	{
		___take_1 = value;
	}

	inline static int32_t get_offset_of_orderBy_2() { return static_cast<int32_t>(offsetof(ODataQuery_1_t768401567, ___orderBy_2)); }
	inline String_t* get_orderBy_2() const { return ___orderBy_2; }
	inline String_t** get_address_of_orderBy_2() { return &___orderBy_2; }
	inline void set_orderBy_2(String_t* value)
	{
		___orderBy_2 = value;
		Il2CppCodeGenWriteBarrier(&___orderBy_2, value);
	}

	inline static int32_t get_offset_of_filters_3() { return static_cast<int32_t>(offsetof(ODataQuery_1_t768401567, ___filters_3)); }
	inline List_1_t1398341365 * get_filters_3() const { return ___filters_3; }
	inline List_1_t1398341365 ** get_address_of_filters_3() { return &___filters_3; }
	inline void set_filters_3(List_1_t1398341365 * value)
	{
		___filters_3 = value;
		Il2CppCodeGenWriteBarrier(&___filters_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
