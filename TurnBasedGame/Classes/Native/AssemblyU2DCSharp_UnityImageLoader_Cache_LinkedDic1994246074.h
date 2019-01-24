#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Threading.ReaderWriterLockSlim
struct ReaderWriterLockSlim_t3961242320;
// System.Collections.Generic.IDictionary`2<System.Object,System.Object>
struct IDictionary_2_t280592844;
// System.Collections.Generic.LinkedList`1<System.Object>
struct LinkedList_1_t2994157524;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.Cache.LinkedDictionary`2<System.Object,System.Object>
struct  LinkedDictionary_2_t1994246074  : public Il2CppObject
{
public:
	// System.Threading.ReaderWriterLockSlim UnityImageLoader.Cache.LinkedDictionary`2::lockslim
	ReaderWriterLockSlim_t3961242320 * ___lockslim_0;
	// System.Collections.Generic.IDictionary`2<K,V> UnityImageLoader.Cache.LinkedDictionary`2::dictionary
	Il2CppObject* ___dictionary_1;
	// System.Collections.Generic.LinkedList`1<K> UnityImageLoader.Cache.LinkedDictionary`2::linkedList
	LinkedList_1_t2994157524 * ___linkedList_2;

public:
	inline static int32_t get_offset_of_lockslim_0() { return static_cast<int32_t>(offsetof(LinkedDictionary_2_t1994246074, ___lockslim_0)); }
	inline ReaderWriterLockSlim_t3961242320 * get_lockslim_0() const { return ___lockslim_0; }
	inline ReaderWriterLockSlim_t3961242320 ** get_address_of_lockslim_0() { return &___lockslim_0; }
	inline void set_lockslim_0(ReaderWriterLockSlim_t3961242320 * value)
	{
		___lockslim_0 = value;
		Il2CppCodeGenWriteBarrier(&___lockslim_0, value);
	}

	inline static int32_t get_offset_of_dictionary_1() { return static_cast<int32_t>(offsetof(LinkedDictionary_2_t1994246074, ___dictionary_1)); }
	inline Il2CppObject* get_dictionary_1() const { return ___dictionary_1; }
	inline Il2CppObject** get_address_of_dictionary_1() { return &___dictionary_1; }
	inline void set_dictionary_1(Il2CppObject* value)
	{
		___dictionary_1 = value;
		Il2CppCodeGenWriteBarrier(&___dictionary_1, value);
	}

	inline static int32_t get_offset_of_linkedList_2() { return static_cast<int32_t>(offsetof(LinkedDictionary_2_t1994246074, ___linkedList_2)); }
	inline LinkedList_1_t2994157524 * get_linkedList_2() const { return ___linkedList_2; }
	inline LinkedList_1_t2994157524 ** get_address_of_linkedList_2() { return &___linkedList_2; }
	inline void set_linkedList_2(LinkedList_1_t2994157524 * value)
	{
		___linkedList_2 = value;
		Il2CppCodeGenWriteBarrier(&___linkedList_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
