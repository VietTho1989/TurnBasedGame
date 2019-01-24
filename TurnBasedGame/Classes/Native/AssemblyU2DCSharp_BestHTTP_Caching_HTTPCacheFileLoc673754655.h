#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Uri,System.Object>
struct Dictionary_2_t1878610222;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Caching.HTTPCacheFileLock
struct  HTTPCacheFileLock_t673754655  : public Il2CppObject
{
public:

public:
};

struct HTTPCacheFileLock_t673754655_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.Uri,System.Object> BestHTTP.Caching.HTTPCacheFileLock::FileLocks
	Dictionary_2_t1878610222 * ___FileLocks_0;
	// System.Object BestHTTP.Caching.HTTPCacheFileLock::SyncRoot
	Il2CppObject * ___SyncRoot_1;

public:
	inline static int32_t get_offset_of_FileLocks_0() { return static_cast<int32_t>(offsetof(HTTPCacheFileLock_t673754655_StaticFields, ___FileLocks_0)); }
	inline Dictionary_2_t1878610222 * get_FileLocks_0() const { return ___FileLocks_0; }
	inline Dictionary_2_t1878610222 ** get_address_of_FileLocks_0() { return &___FileLocks_0; }
	inline void set_FileLocks_0(Dictionary_2_t1878610222 * value)
	{
		___FileLocks_0 = value;
		Il2CppCodeGenWriteBarrier(&___FileLocks_0, value);
	}

	inline static int32_t get_offset_of_SyncRoot_1() { return static_cast<int32_t>(offsetof(HTTPCacheFileLock_t673754655_StaticFields, ___SyncRoot_1)); }
	inline Il2CppObject * get_SyncRoot_1() const { return ___SyncRoot_1; }
	inline Il2CppObject ** get_address_of_SyncRoot_1() { return &___SyncRoot_1; }
	inline void set_SyncRoot_1(Il2CppObject * value)
	{
		___SyncRoot_1 = value;
		Il2CppCodeGenWriteBarrier(&___SyncRoot_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
