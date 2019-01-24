#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.Core
struct  Core_t3999391311  : public MonoBehaviour_t1158329972
{
public:

public:
};

struct Core_t3999391311_StaticFields
{
public:
	// System.Boolean HEX.Core::isAlreadyInit
	bool ___isAlreadyInit_3;
	// System.Object HEX.Core::lockThis
	Il2CppObject * ___lockThis_4;

public:
	inline static int32_t get_offset_of_isAlreadyInit_3() { return static_cast<int32_t>(offsetof(Core_t3999391311_StaticFields, ___isAlreadyInit_3)); }
	inline bool get_isAlreadyInit_3() const { return ___isAlreadyInit_3; }
	inline bool* get_address_of_isAlreadyInit_3() { return &___isAlreadyInit_3; }
	inline void set_isAlreadyInit_3(bool value)
	{
		___isAlreadyInit_3 = value;
	}

	inline static int32_t get_offset_of_lockThis_4() { return static_cast<int32_t>(offsetof(Core_t3999391311_StaticFields, ___lockThis_4)); }
	inline Il2CppObject * get_lockThis_4() const { return ___lockThis_4; }
	inline Il2CppObject ** get_address_of_lockThis_4() { return &___lockThis_4; }
	inline void set_lockThis_4(Il2CppObject * value)
	{
		___lockThis_4 = value;
		Il2CppCodeGenWriteBarrier(&___lockThis_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
