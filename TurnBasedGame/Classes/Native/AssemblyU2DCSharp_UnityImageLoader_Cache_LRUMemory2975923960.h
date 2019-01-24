#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UnityImageLoader_Cache_AbstractM2717457341.h"

// System.Threading.ReaderWriterLockSlim
struct ReaderWriterLockSlim_t3961242320;
// UnityImageLoader.Cache.LinkedDictionary`2<System.String,UnityEngine.Sprite>
struct LinkedDictionary_2_t1937109696;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.Cache.LRUMemoryCache
struct  LRUMemoryCache_t2975923960  : public AbstractMemoryCache_t2717457341
{
public:
	// System.Threading.ReaderWriterLockSlim UnityImageLoader.Cache.LRUMemoryCache::lockslim
	ReaderWriterLockSlim_t3961242320 * ___lockslim_2;
	// System.Int64 UnityImageLoader.Cache.LRUMemoryCache::size
	int64_t ___size_3;
	// UnityImageLoader.Cache.LinkedDictionary`2<System.String,UnityEngine.Sprite> UnityImageLoader.Cache.LRUMemoryCache::linkedDictionary
	LinkedDictionary_2_t1937109696 * ___linkedDictionary_4;

public:
	inline static int32_t get_offset_of_lockslim_2() { return static_cast<int32_t>(offsetof(LRUMemoryCache_t2975923960, ___lockslim_2)); }
	inline ReaderWriterLockSlim_t3961242320 * get_lockslim_2() const { return ___lockslim_2; }
	inline ReaderWriterLockSlim_t3961242320 ** get_address_of_lockslim_2() { return &___lockslim_2; }
	inline void set_lockslim_2(ReaderWriterLockSlim_t3961242320 * value)
	{
		___lockslim_2 = value;
		Il2CppCodeGenWriteBarrier(&___lockslim_2, value);
	}

	inline static int32_t get_offset_of_size_3() { return static_cast<int32_t>(offsetof(LRUMemoryCache_t2975923960, ___size_3)); }
	inline int64_t get_size_3() const { return ___size_3; }
	inline int64_t* get_address_of_size_3() { return &___size_3; }
	inline void set_size_3(int64_t value)
	{
		___size_3 = value;
	}

	inline static int32_t get_offset_of_linkedDictionary_4() { return static_cast<int32_t>(offsetof(LRUMemoryCache_t2975923960, ___linkedDictionary_4)); }
	inline LinkedDictionary_2_t1937109696 * get_linkedDictionary_4() const { return ___linkedDictionary_4; }
	inline LinkedDictionary_2_t1937109696 ** get_address_of_linkedDictionary_4() { return &___linkedDictionary_4; }
	inline void set_linkedDictionary_4(LinkedDictionary_2_t1937109696 * value)
	{
		___linkedDictionary_4 = value;
		Il2CppCodeGenWriteBarrier(&___linkedDictionary_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
