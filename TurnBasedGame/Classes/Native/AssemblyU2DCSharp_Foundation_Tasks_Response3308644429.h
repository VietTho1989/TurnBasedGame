#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Foundation.Tasks.HttpMetadata
struct HttpMetadata_t2935150347;
// System.Exception
struct Exception_t1927440687;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.Response
struct  Response_t3308644429  : public Il2CppObject
{
public:
	// Foundation.Tasks.HttpMetadata Foundation.Tasks.Response::Metadata
	HttpMetadata_t2935150347 * ___Metadata_0;
	// System.Exception Foundation.Tasks.Response::Exception
	Exception_t1927440687 * ___Exception_1;

public:
	inline static int32_t get_offset_of_Metadata_0() { return static_cast<int32_t>(offsetof(Response_t3308644429, ___Metadata_0)); }
	inline HttpMetadata_t2935150347 * get_Metadata_0() const { return ___Metadata_0; }
	inline HttpMetadata_t2935150347 ** get_address_of_Metadata_0() { return &___Metadata_0; }
	inline void set_Metadata_0(HttpMetadata_t2935150347 * value)
	{
		___Metadata_0 = value;
		Il2CppCodeGenWriteBarrier(&___Metadata_0, value);
	}

	inline static int32_t get_offset_of_Exception_1() { return static_cast<int32_t>(offsetof(Response_t3308644429, ___Exception_1)); }
	inline Exception_t1927440687 * get_Exception_1() const { return ___Exception_1; }
	inline Exception_t1927440687 ** get_address_of_Exception_1() { return &___Exception_1; }
	inline void set_Exception_1(Exception_t1927440687 * value)
	{
		___Exception_1 = value;
		Il2CppCodeGenWriteBarrier(&___Exception_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
