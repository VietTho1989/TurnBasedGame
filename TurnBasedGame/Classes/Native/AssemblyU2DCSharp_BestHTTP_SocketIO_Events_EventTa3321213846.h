#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// BestHTTP.SocketIO.Socket
struct Socket_t2716624701;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<BestHTTP.SocketIO.Events.EventDescriptor>>
struct Dictionary_2_t1045973933;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.Events.EventTable
struct  EventTable_t3321213846  : public Il2CppObject
{
public:
	// BestHTTP.SocketIO.Socket BestHTTP.SocketIO.Events.EventTable::<Socket>k__BackingField
	Socket_t2716624701 * ___U3CSocketU3Ek__BackingField_0;
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<BestHTTP.SocketIO.Events.EventDescriptor>> BestHTTP.SocketIO.Events.EventTable::Table
	Dictionary_2_t1045973933 * ___Table_1;

public:
	inline static int32_t get_offset_of_U3CSocketU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(EventTable_t3321213846, ___U3CSocketU3Ek__BackingField_0)); }
	inline Socket_t2716624701 * get_U3CSocketU3Ek__BackingField_0() const { return ___U3CSocketU3Ek__BackingField_0; }
	inline Socket_t2716624701 ** get_address_of_U3CSocketU3Ek__BackingField_0() { return &___U3CSocketU3Ek__BackingField_0; }
	inline void set_U3CSocketU3Ek__BackingField_0(Socket_t2716624701 * value)
	{
		___U3CSocketU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSocketU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_Table_1() { return static_cast<int32_t>(offsetof(EventTable_t3321213846, ___Table_1)); }
	inline Dictionary_2_t1045973933 * get_Table_1() const { return ___Table_1; }
	inline Dictionary_2_t1045973933 ** get_address_of_Table_1() { return &___Table_1; }
	inline void set_Table_1(Dictionary_2_t1045973933 * value)
	{
		___Table_1 = value;
		Il2CppCodeGenWriteBarrier(&___Table_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
