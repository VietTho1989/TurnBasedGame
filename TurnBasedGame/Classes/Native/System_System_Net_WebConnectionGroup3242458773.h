#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Net.ServicePoint
struct ServicePoint_t2765344313;
// System.String
struct String_t;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Random
struct Random_t1044426839;
// System.Collections.Queue
struct Queue_t1288490777;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.WebConnectionGroup
struct  WebConnectionGroup_t3242458773  : public Il2CppObject
{
public:
	// System.Net.ServicePoint System.Net.WebConnectionGroup::sPoint
	ServicePoint_t2765344313 * ___sPoint_0;
	// System.String System.Net.WebConnectionGroup::name
	String_t* ___name_1;
	// System.Collections.ArrayList System.Net.WebConnectionGroup::connections
	ArrayList_t4252133567 * ___connections_2;
	// System.Random System.Net.WebConnectionGroup::rnd
	Random_t1044426839 * ___rnd_3;
	// System.Collections.Queue System.Net.WebConnectionGroup::queue
	Queue_t1288490777 * ___queue_4;

public:
	inline static int32_t get_offset_of_sPoint_0() { return static_cast<int32_t>(offsetof(WebConnectionGroup_t3242458773, ___sPoint_0)); }
	inline ServicePoint_t2765344313 * get_sPoint_0() const { return ___sPoint_0; }
	inline ServicePoint_t2765344313 ** get_address_of_sPoint_0() { return &___sPoint_0; }
	inline void set_sPoint_0(ServicePoint_t2765344313 * value)
	{
		___sPoint_0 = value;
		Il2CppCodeGenWriteBarrier(&___sPoint_0, value);
	}

	inline static int32_t get_offset_of_name_1() { return static_cast<int32_t>(offsetof(WebConnectionGroup_t3242458773, ___name_1)); }
	inline String_t* get_name_1() const { return ___name_1; }
	inline String_t** get_address_of_name_1() { return &___name_1; }
	inline void set_name_1(String_t* value)
	{
		___name_1 = value;
		Il2CppCodeGenWriteBarrier(&___name_1, value);
	}

	inline static int32_t get_offset_of_connections_2() { return static_cast<int32_t>(offsetof(WebConnectionGroup_t3242458773, ___connections_2)); }
	inline ArrayList_t4252133567 * get_connections_2() const { return ___connections_2; }
	inline ArrayList_t4252133567 ** get_address_of_connections_2() { return &___connections_2; }
	inline void set_connections_2(ArrayList_t4252133567 * value)
	{
		___connections_2 = value;
		Il2CppCodeGenWriteBarrier(&___connections_2, value);
	}

	inline static int32_t get_offset_of_rnd_3() { return static_cast<int32_t>(offsetof(WebConnectionGroup_t3242458773, ___rnd_3)); }
	inline Random_t1044426839 * get_rnd_3() const { return ___rnd_3; }
	inline Random_t1044426839 ** get_address_of_rnd_3() { return &___rnd_3; }
	inline void set_rnd_3(Random_t1044426839 * value)
	{
		___rnd_3 = value;
		Il2CppCodeGenWriteBarrier(&___rnd_3, value);
	}

	inline static int32_t get_offset_of_queue_4() { return static_cast<int32_t>(offsetof(WebConnectionGroup_t3242458773, ___queue_4)); }
	inline Queue_t1288490777 * get_queue_4() const { return ___queue_4; }
	inline Queue_t1288490777 ** get_address_of_queue_4() { return &___queue_4; }
	inline void set_queue_4(Queue_t1288490777 * value)
	{
		___queue_4 = value;
		Il2CppCodeGenWriteBarrier(&___queue_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
