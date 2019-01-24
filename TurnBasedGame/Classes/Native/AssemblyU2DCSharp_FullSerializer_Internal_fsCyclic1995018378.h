#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Object,System.Int32>
struct Dictionary_2_t1663937576;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Object>
struct Dictionary_2_t1697274930;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsCyclicReferenceManager
struct  fsCyclicReferenceManager_t1995018378  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.Object,System.Int32> FullSerializer.Internal.fsCyclicReferenceManager::_objectIds
	Dictionary_2_t1663937576 * ____objectIds_0;
	// System.Int32 FullSerializer.Internal.fsCyclicReferenceManager::_nextId
	int32_t ____nextId_1;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Object> FullSerializer.Internal.fsCyclicReferenceManager::_marked
	Dictionary_2_t1697274930 * ____marked_2;
	// System.Int32 FullSerializer.Internal.fsCyclicReferenceManager::_depth
	int32_t ____depth_3;

public:
	inline static int32_t get_offset_of__objectIds_0() { return static_cast<int32_t>(offsetof(fsCyclicReferenceManager_t1995018378, ____objectIds_0)); }
	inline Dictionary_2_t1663937576 * get__objectIds_0() const { return ____objectIds_0; }
	inline Dictionary_2_t1663937576 ** get_address_of__objectIds_0() { return &____objectIds_0; }
	inline void set__objectIds_0(Dictionary_2_t1663937576 * value)
	{
		____objectIds_0 = value;
		Il2CppCodeGenWriteBarrier(&____objectIds_0, value);
	}

	inline static int32_t get_offset_of__nextId_1() { return static_cast<int32_t>(offsetof(fsCyclicReferenceManager_t1995018378, ____nextId_1)); }
	inline int32_t get__nextId_1() const { return ____nextId_1; }
	inline int32_t* get_address_of__nextId_1() { return &____nextId_1; }
	inline void set__nextId_1(int32_t value)
	{
		____nextId_1 = value;
	}

	inline static int32_t get_offset_of__marked_2() { return static_cast<int32_t>(offsetof(fsCyclicReferenceManager_t1995018378, ____marked_2)); }
	inline Dictionary_2_t1697274930 * get__marked_2() const { return ____marked_2; }
	inline Dictionary_2_t1697274930 ** get_address_of__marked_2() { return &____marked_2; }
	inline void set__marked_2(Dictionary_2_t1697274930 * value)
	{
		____marked_2 = value;
		Il2CppCodeGenWriteBarrier(&____marked_2, value);
	}

	inline static int32_t get_offset_of__depth_3() { return static_cast<int32_t>(offsetof(fsCyclicReferenceManager_t1995018378, ____depth_3)); }
	inline int32_t get__depth_3() const { return ____depth_3; }
	inline int32_t* get_address_of__depth_3() { return &____depth_3; }
	inline void set__depth_3(int32_t value)
	{
		____depth_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
