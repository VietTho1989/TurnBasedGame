#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Diagnostics_SourceLevels1530190938.h"

// System.String
struct String_t;
// System.Diagnostics.TraceListenerCollection
struct TraceListenerCollection_t2289511703;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Diagnostics.TraceSourceInfo
struct  TraceSourceInfo_t8795084  : public Il2CppObject
{
public:
	// System.String System.Diagnostics.TraceSourceInfo::name
	String_t* ___name_0;
	// System.Diagnostics.SourceLevels System.Diagnostics.TraceSourceInfo::levels
	int32_t ___levels_1;
	// System.Diagnostics.TraceListenerCollection System.Diagnostics.TraceSourceInfo::listeners
	TraceListenerCollection_t2289511703 * ___listeners_2;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(TraceSourceInfo_t8795084, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_levels_1() { return static_cast<int32_t>(offsetof(TraceSourceInfo_t8795084, ___levels_1)); }
	inline int32_t get_levels_1() const { return ___levels_1; }
	inline int32_t* get_address_of_levels_1() { return &___levels_1; }
	inline void set_levels_1(int32_t value)
	{
		___levels_1 = value;
	}

	inline static int32_t get_offset_of_listeners_2() { return static_cast<int32_t>(offsetof(TraceSourceInfo_t8795084, ___listeners_2)); }
	inline TraceListenerCollection_t2289511703 * get_listeners_2() const { return ___listeners_2; }
	inline TraceListenerCollection_t2289511703 ** get_address_of_listeners_2() { return &___listeners_2; }
	inline void set_listeners_2(TraceListenerCollection_t2289511703 * value)
	{
		___listeners_2 = value;
		Il2CppCodeGenWriteBarrier(&___listeners_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
