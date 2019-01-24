#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Diagnostics.TraceListenerCollection
struct TraceListenerCollection_t2289511703;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Diagnostics.TraceImplSettings
struct  TraceImplSettings_t1186465586  : public Il2CppObject
{
public:
	// System.Boolean System.Diagnostics.TraceImplSettings::AutoFlush
	bool ___AutoFlush_0;
	// System.Int32 System.Diagnostics.TraceImplSettings::IndentLevel
	int32_t ___IndentLevel_1;
	// System.Int32 System.Diagnostics.TraceImplSettings::IndentSize
	int32_t ___IndentSize_2;
	// System.Diagnostics.TraceListenerCollection System.Diagnostics.TraceImplSettings::Listeners
	TraceListenerCollection_t2289511703 * ___Listeners_3;

public:
	inline static int32_t get_offset_of_AutoFlush_0() { return static_cast<int32_t>(offsetof(TraceImplSettings_t1186465586, ___AutoFlush_0)); }
	inline bool get_AutoFlush_0() const { return ___AutoFlush_0; }
	inline bool* get_address_of_AutoFlush_0() { return &___AutoFlush_0; }
	inline void set_AutoFlush_0(bool value)
	{
		___AutoFlush_0 = value;
	}

	inline static int32_t get_offset_of_IndentLevel_1() { return static_cast<int32_t>(offsetof(TraceImplSettings_t1186465586, ___IndentLevel_1)); }
	inline int32_t get_IndentLevel_1() const { return ___IndentLevel_1; }
	inline int32_t* get_address_of_IndentLevel_1() { return &___IndentLevel_1; }
	inline void set_IndentLevel_1(int32_t value)
	{
		___IndentLevel_1 = value;
	}

	inline static int32_t get_offset_of_IndentSize_2() { return static_cast<int32_t>(offsetof(TraceImplSettings_t1186465586, ___IndentSize_2)); }
	inline int32_t get_IndentSize_2() const { return ___IndentSize_2; }
	inline int32_t* get_address_of_IndentSize_2() { return &___IndentSize_2; }
	inline void set_IndentSize_2(int32_t value)
	{
		___IndentSize_2 = value;
	}

	inline static int32_t get_offset_of_Listeners_3() { return static_cast<int32_t>(offsetof(TraceImplSettings_t1186465586, ___Listeners_3)); }
	inline TraceListenerCollection_t2289511703 * get_Listeners_3() const { return ___Listeners_3; }
	inline TraceListenerCollection_t2289511703 ** get_address_of_Listeners_3() { return &___Listeners_3; }
	inline void set_Listeners_3(TraceListenerCollection_t2289511703 * value)
	{
		___Listeners_3 = value;
		Il2CppCodeGenWriteBarrier(&___Listeners_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
