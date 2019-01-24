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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AIController
struct  AIController_t1559706138  : public Il2CppObject
{
public:

public:
};

struct AIController_t1559706138_StaticFields
{
public:
	// System.Object AIController::lockThis
	Il2CppObject * ___lockThis_0;
	// System.Int32 AIController::thinkCount
	int32_t ___thinkCount_3;

public:
	inline static int32_t get_offset_of_lockThis_0() { return static_cast<int32_t>(offsetof(AIController_t1559706138_StaticFields, ___lockThis_0)); }
	inline Il2CppObject * get_lockThis_0() const { return ___lockThis_0; }
	inline Il2CppObject ** get_address_of_lockThis_0() { return &___lockThis_0; }
	inline void set_lockThis_0(Il2CppObject * value)
	{
		___lockThis_0 = value;
		Il2CppCodeGenWriteBarrier(&___lockThis_0, value);
	}

	inline static int32_t get_offset_of_thinkCount_3() { return static_cast<int32_t>(offsetof(AIController_t1559706138_StaticFields, ___thinkCount_3)); }
	inline int32_t get_thinkCount_3() const { return ___thinkCount_3; }
	inline int32_t* get_address_of_thinkCount_3() { return &___thinkCount_3; }
	inline void set_thinkCount_3(int32_t value)
	{
		___thinkCount_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
