#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEqualityComparer`1<System.Object>
struct IEqualityComparer_1_t1902082073;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsCyclicReferenceManager/ObjectReferenceEqualityComparator
struct  ObjectReferenceEqualityComparator_t3520131135  : public Il2CppObject
{
public:

public:
};

struct ObjectReferenceEqualityComparator_t3520131135_StaticFields
{
public:
	// System.Collections.Generic.IEqualityComparer`1<System.Object> FullSerializer.Internal.fsCyclicReferenceManager/ObjectReferenceEqualityComparator::Instance
	Il2CppObject* ___Instance_0;

public:
	inline static int32_t get_offset_of_Instance_0() { return static_cast<int32_t>(offsetof(ObjectReferenceEqualityComparator_t3520131135_StaticFields, ___Instance_0)); }
	inline Il2CppObject* get_Instance_0() const { return ___Instance_0; }
	inline Il2CppObject** get_address_of_Instance_0() { return &___Instance_0; }
	inline void set_Instance_0(Il2CppObject* value)
	{
		___Instance_0 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
