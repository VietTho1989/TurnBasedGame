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
// Save/Content
struct Content_t2583047541;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Save
struct  Save_t1600141839  : public Il2CppObject
{
public:
	// System.Int32 Save::version
	int32_t ___version_2;
	// Save/Content Save::content
	Content_t2583047541 * ___content_3;

public:
	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Save_t1600141839, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_content_3() { return static_cast<int32_t>(offsetof(Save_t1600141839, ___content_3)); }
	inline Content_t2583047541 * get_content_3() const { return ___content_3; }
	inline Content_t2583047541 ** get_address_of_content_3() { return &___content_3; }
	inline void set_content_3(Content_t2583047541 * value)
	{
		___content_3 = value;
		Il2CppCodeGenWriteBarrier(&___content_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
