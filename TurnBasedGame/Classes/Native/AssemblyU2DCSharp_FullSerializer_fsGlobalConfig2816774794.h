#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsGlobalConfig
struct  fsGlobalConfig_t2816774794  : public Il2CppObject
{
public:

public:
};

struct fsGlobalConfig_t2816774794_StaticFields
{
public:
	// System.Boolean FullSerializer.fsGlobalConfig::IsCaseSensitive
	bool ___IsCaseSensitive_0;
	// System.Boolean FullSerializer.fsGlobalConfig::AllowInternalExceptions
	bool ___AllowInternalExceptions_1;
	// System.String FullSerializer.fsGlobalConfig::InternalFieldPrefix
	String_t* ___InternalFieldPrefix_2;

public:
	inline static int32_t get_offset_of_IsCaseSensitive_0() { return static_cast<int32_t>(offsetof(fsGlobalConfig_t2816774794_StaticFields, ___IsCaseSensitive_0)); }
	inline bool get_IsCaseSensitive_0() const { return ___IsCaseSensitive_0; }
	inline bool* get_address_of_IsCaseSensitive_0() { return &___IsCaseSensitive_0; }
	inline void set_IsCaseSensitive_0(bool value)
	{
		___IsCaseSensitive_0 = value;
	}

	inline static int32_t get_offset_of_AllowInternalExceptions_1() { return static_cast<int32_t>(offsetof(fsGlobalConfig_t2816774794_StaticFields, ___AllowInternalExceptions_1)); }
	inline bool get_AllowInternalExceptions_1() const { return ___AllowInternalExceptions_1; }
	inline bool* get_address_of_AllowInternalExceptions_1() { return &___AllowInternalExceptions_1; }
	inline void set_AllowInternalExceptions_1(bool value)
	{
		___AllowInternalExceptions_1 = value;
	}

	inline static int32_t get_offset_of_InternalFieldPrefix_2() { return static_cast<int32_t>(offsetof(fsGlobalConfig_t2816774794_StaticFields, ___InternalFieldPrefix_2)); }
	inline String_t* get_InternalFieldPrefix_2() const { return ___InternalFieldPrefix_2; }
	inline String_t** get_address_of_InternalFieldPrefix_2() { return &___InternalFieldPrefix_2; }
	inline void set_InternalFieldPrefix_2(String_t* value)
	{
		___InternalFieldPrefix_2 = value;
		Il2CppCodeGenWriteBarrier(&___InternalFieldPrefix_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
