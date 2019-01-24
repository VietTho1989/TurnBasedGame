#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.HashSet`1<System.Type>
struct HashSet_1_t3932231376;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsAotCompilationManager
struct  fsAotCompilationManager_t3563908143  : public Il2CppObject
{
public:

public:
};

struct fsAotCompilationManager_t3563908143_StaticFields
{
public:
	// System.Collections.Generic.HashSet`1<System.Type> FullSerializer.fsAotCompilationManager::AotCandidateTypes
	HashSet_1_t3932231376 * ___AotCandidateTypes_0;

public:
	inline static int32_t get_offset_of_AotCandidateTypes_0() { return static_cast<int32_t>(offsetof(fsAotCompilationManager_t3563908143_StaticFields, ___AotCandidateTypes_0)); }
	inline HashSet_1_t3932231376 * get_AotCandidateTypes_0() const { return ___AotCandidateTypes_0; }
	inline HashSet_1_t3932231376 ** get_address_of_AotCandidateTypes_0() { return &___AotCandidateTypes_0; }
	inline void set_AotCandidateTypes_0(HashSet_1_t3932231376 * value)
	{
		___AotCandidateTypes_0 = value;
		Il2CppCodeGenWriteBarrier(&___AotCandidateTypes_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
