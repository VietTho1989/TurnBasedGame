#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Int32,FullSerializer.fsData>
struct Dictionary_2_t1591631240;
// System.Collections.Generic.HashSet`1<System.Int32>
struct HashSet_1_t405338302;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsSerializer/fsLazyCycleDefinitionWriter
struct  fsLazyCycleDefinitionWriter_t2327014926  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.Int32,FullSerializer.fsData> FullSerializer.fsSerializer/fsLazyCycleDefinitionWriter::_pendingDefinitions
	Dictionary_2_t1591631240 * ____pendingDefinitions_0;
	// System.Collections.Generic.HashSet`1<System.Int32> FullSerializer.fsSerializer/fsLazyCycleDefinitionWriter::_references
	HashSet_1_t405338302 * ____references_1;

public:
	inline static int32_t get_offset_of__pendingDefinitions_0() { return static_cast<int32_t>(offsetof(fsLazyCycleDefinitionWriter_t2327014926, ____pendingDefinitions_0)); }
	inline Dictionary_2_t1591631240 * get__pendingDefinitions_0() const { return ____pendingDefinitions_0; }
	inline Dictionary_2_t1591631240 ** get_address_of__pendingDefinitions_0() { return &____pendingDefinitions_0; }
	inline void set__pendingDefinitions_0(Dictionary_2_t1591631240 * value)
	{
		____pendingDefinitions_0 = value;
		Il2CppCodeGenWriteBarrier(&____pendingDefinitions_0, value);
	}

	inline static int32_t get_offset_of__references_1() { return static_cast<int32_t>(offsetof(fsLazyCycleDefinitionWriter_t2327014926, ____references_1)); }
	inline HashSet_1_t405338302 * get__references_1() const { return ____references_1; }
	inline HashSet_1_t405338302 ** get_address_of__references_1() { return &____references_1; }
	inline void set__references_1(HashSet_1_t405338302 * value)
	{
		____references_1 = value;
		Il2CppCodeGenWriteBarrier(&____references_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
