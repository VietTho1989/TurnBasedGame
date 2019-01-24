#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.IdeaEngine
struct  IdeaEngine_t2343780579  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.IdeaEngine::workingKey
	Int32U5BU5D_t3030399641* ___workingKey_1;

public:
	inline static int32_t get_offset_of_workingKey_1() { return static_cast<int32_t>(offsetof(IdeaEngine_t2343780579, ___workingKey_1)); }
	inline Int32U5BU5D_t3030399641* get_workingKey_1() const { return ___workingKey_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey_1() { return &___workingKey_1; }
	inline void set_workingKey_1(Int32U5BU5D_t3030399641* value)
	{
		___workingKey_1 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_1, value);
	}
};

struct IdeaEngine_t2343780579_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.IdeaEngine::MASK
	int32_t ___MASK_2;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.IdeaEngine::BASE
	int32_t ___BASE_3;

public:
	inline static int32_t get_offset_of_MASK_2() { return static_cast<int32_t>(offsetof(IdeaEngine_t2343780579_StaticFields, ___MASK_2)); }
	inline int32_t get_MASK_2() const { return ___MASK_2; }
	inline int32_t* get_address_of_MASK_2() { return &___MASK_2; }
	inline void set_MASK_2(int32_t value)
	{
		___MASK_2 = value;
	}

	inline static int32_t get_offset_of_BASE_3() { return static_cast<int32_t>(offsetof(IdeaEngine_t2343780579_StaticFields, ___BASE_3)); }
	inline int32_t get_BASE_3() const { return ___BASE_3; }
	inline int32_t* get_address_of_BASE_3() { return &___BASE_3; }
	inline void set_BASE_3(int32_t value)
	{
		___BASE_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
