#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"

// System.Collections.Generic.List`1<FullSerializer.fsAotConfiguration/Entry>
struct List_1_t2474875971;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsAotConfiguration
struct  fsAotConfiguration_t3786898179  : public ScriptableObject_t1975622470
{
public:
	// System.Collections.Generic.List`1<FullSerializer.fsAotConfiguration/Entry> FullSerializer.fsAotConfiguration::aotTypes
	List_1_t2474875971 * ___aotTypes_2;
	// System.String FullSerializer.fsAotConfiguration::outputDirectory
	String_t* ___outputDirectory_3;

public:
	inline static int32_t get_offset_of_aotTypes_2() { return static_cast<int32_t>(offsetof(fsAotConfiguration_t3786898179, ___aotTypes_2)); }
	inline List_1_t2474875971 * get_aotTypes_2() const { return ___aotTypes_2; }
	inline List_1_t2474875971 ** get_address_of_aotTypes_2() { return &___aotTypes_2; }
	inline void set_aotTypes_2(List_1_t2474875971 * value)
	{
		___aotTypes_2 = value;
		Il2CppCodeGenWriteBarrier(&___aotTypes_2, value);
	}

	inline static int32_t get_offset_of_outputDirectory_3() { return static_cast<int32_t>(offsetof(fsAotConfiguration_t3786898179, ___outputDirectory_3)); }
	inline String_t* get_outputDirectory_3() const { return ___outputDirectory_3; }
	inline String_t** get_address_of_outputDirectory_3() { return &___outputDirectory_3; }
	inline void set_outputDirectory_3(String_t* value)
	{
		___outputDirectory_3 = value;
		Il2CppCodeGenWriteBarrier(&___outputDirectory_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
