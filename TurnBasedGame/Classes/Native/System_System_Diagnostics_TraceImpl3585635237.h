#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;
// System.Diagnostics.TraceListenerCollection
struct TraceListenerCollection_t2289511703;
// System.Diagnostics.CorrelationManager
struct CorrelationManager_t4016999475;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Diagnostics.TraceImpl
struct  TraceImpl_t3585635237  : public Il2CppObject
{
public:

public:
};

struct TraceImpl_t3585635237_StaticFields
{
public:
	// System.Object System.Diagnostics.TraceImpl::initLock
	Il2CppObject * ___initLock_0;
	// System.Boolean System.Diagnostics.TraceImpl::autoFlush
	bool ___autoFlush_1;
	// System.Diagnostics.TraceListenerCollection System.Diagnostics.TraceImpl::listeners
	TraceListenerCollection_t2289511703 * ___listeners_4;
	// System.Diagnostics.CorrelationManager System.Diagnostics.TraceImpl::correlation_manager
	CorrelationManager_t4016999475 * ___correlation_manager_5;

public:
	inline static int32_t get_offset_of_initLock_0() { return static_cast<int32_t>(offsetof(TraceImpl_t3585635237_StaticFields, ___initLock_0)); }
	inline Il2CppObject * get_initLock_0() const { return ___initLock_0; }
	inline Il2CppObject ** get_address_of_initLock_0() { return &___initLock_0; }
	inline void set_initLock_0(Il2CppObject * value)
	{
		___initLock_0 = value;
		Il2CppCodeGenWriteBarrier(&___initLock_0, value);
	}

	inline static int32_t get_offset_of_autoFlush_1() { return static_cast<int32_t>(offsetof(TraceImpl_t3585635237_StaticFields, ___autoFlush_1)); }
	inline bool get_autoFlush_1() const { return ___autoFlush_1; }
	inline bool* get_address_of_autoFlush_1() { return &___autoFlush_1; }
	inline void set_autoFlush_1(bool value)
	{
		___autoFlush_1 = value;
	}

	inline static int32_t get_offset_of_listeners_4() { return static_cast<int32_t>(offsetof(TraceImpl_t3585635237_StaticFields, ___listeners_4)); }
	inline TraceListenerCollection_t2289511703 * get_listeners_4() const { return ___listeners_4; }
	inline TraceListenerCollection_t2289511703 ** get_address_of_listeners_4() { return &___listeners_4; }
	inline void set_listeners_4(TraceListenerCollection_t2289511703 * value)
	{
		___listeners_4 = value;
		Il2CppCodeGenWriteBarrier(&___listeners_4, value);
	}

	inline static int32_t get_offset_of_correlation_manager_5() { return static_cast<int32_t>(offsetof(TraceImpl_t3585635237_StaticFields, ___correlation_manager_5)); }
	inline CorrelationManager_t4016999475 * get_correlation_manager_5() const { return ___correlation_manager_5; }
	inline CorrelationManager_t4016999475 ** get_address_of_correlation_manager_5() { return &___correlation_manager_5; }
	inline void set_correlation_manager_5(CorrelationManager_t4016999475 * value)
	{
		___correlation_manager_5 = value;
		Il2CppCodeGenWriteBarrier(&___correlation_manager_5, value);
	}
};

struct TraceImpl_t3585635237_ThreadStaticFields
{
public:
	// System.Int32 System.Diagnostics.TraceImpl::indentLevel
	int32_t ___indentLevel_2;
	// System.Int32 System.Diagnostics.TraceImpl::indentSize
	int32_t ___indentSize_3;

public:
	inline static int32_t get_offset_of_indentLevel_2() { return static_cast<int32_t>(offsetof(TraceImpl_t3585635237_ThreadStaticFields, ___indentLevel_2)); }
	inline int32_t get_indentLevel_2() const { return ___indentLevel_2; }
	inline int32_t* get_address_of_indentLevel_2() { return &___indentLevel_2; }
	inline void set_indentLevel_2(int32_t value)
	{
		___indentLevel_2 = value;
	}

	inline static int32_t get_offset_of_indentSize_3() { return static_cast<int32_t>(offsetof(TraceImpl_t3585635237_ThreadStaticFields, ___indentSize_3)); }
	inline int32_t get_indentSize_3() const { return ___indentSize_3; }
	inline int32_t* get_address_of_indentSize_3() { return &___indentSize_3; }
	inline void set_indentSize_3(int32_t value)
	{
		___indentSize_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
