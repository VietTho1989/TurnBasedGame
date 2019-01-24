#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.UInt32,System.Collections.Generic.HashSet`1<Friend>>
struct Dictionary_2_t2220254468;
// System.Collections.Generic.List`1<FriendHashMap/Delegate>
struct List_1_t19421784;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendHashMap
struct  FriendHashMap_t2993852226  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.UInt32,System.Collections.Generic.HashSet`1<Friend>> FriendHashMap::friendDict
	Dictionary_2_t2220254468 * ___friendDict_0;
	// System.Collections.Generic.List`1<FriendHashMap/Delegate> FriendHashMap::delegates
	List_1_t19421784 * ___delegates_1;

public:
	inline static int32_t get_offset_of_friendDict_0() { return static_cast<int32_t>(offsetof(FriendHashMap_t2993852226, ___friendDict_0)); }
	inline Dictionary_2_t2220254468 * get_friendDict_0() const { return ___friendDict_0; }
	inline Dictionary_2_t2220254468 ** get_address_of_friendDict_0() { return &___friendDict_0; }
	inline void set_friendDict_0(Dictionary_2_t2220254468 * value)
	{
		___friendDict_0 = value;
		Il2CppCodeGenWriteBarrier(&___friendDict_0, value);
	}

	inline static int32_t get_offset_of_delegates_1() { return static_cast<int32_t>(offsetof(FriendHashMap_t2993852226, ___delegates_1)); }
	inline List_1_t19421784 * get_delegates_1() const { return ___delegates_1; }
	inline List_1_t19421784 ** get_address_of_delegates_1() { return &___delegates_1; }
	inline void set_delegates_1(List_1_t19421784 * value)
	{
		___delegates_1 = value;
		Il2CppCodeGenWriteBarrier(&___delegates_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
