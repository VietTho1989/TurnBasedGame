#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.WeakReference
struct WeakReference_t1077405567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.WeakObjectWrapper
struct  WeakObjectWrapper_t2012978780  : public Il2CppObject
{
public:
	// System.Int32 System.ComponentModel.WeakObjectWrapper::<TargetHashCode>k__BackingField
	int32_t ___U3CTargetHashCodeU3Ek__BackingField_0;
	// System.WeakReference System.ComponentModel.WeakObjectWrapper::<Weak>k__BackingField
	WeakReference_t1077405567 * ___U3CWeakU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CTargetHashCodeU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(WeakObjectWrapper_t2012978780, ___U3CTargetHashCodeU3Ek__BackingField_0)); }
	inline int32_t get_U3CTargetHashCodeU3Ek__BackingField_0() const { return ___U3CTargetHashCodeU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CTargetHashCodeU3Ek__BackingField_0() { return &___U3CTargetHashCodeU3Ek__BackingField_0; }
	inline void set_U3CTargetHashCodeU3Ek__BackingField_0(int32_t value)
	{
		___U3CTargetHashCodeU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CWeakU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(WeakObjectWrapper_t2012978780, ___U3CWeakU3Ek__BackingField_1)); }
	inline WeakReference_t1077405567 * get_U3CWeakU3Ek__BackingField_1() const { return ___U3CWeakU3Ek__BackingField_1; }
	inline WeakReference_t1077405567 ** get_address_of_U3CWeakU3Ek__BackingField_1() { return &___U3CWeakU3Ek__BackingField_1; }
	inline void set_U3CWeakU3Ek__BackingField_1(WeakReference_t1077405567 * value)
	{
		___U3CWeakU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CWeakU3Ek__BackingField_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
