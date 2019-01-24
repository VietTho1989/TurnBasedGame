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

// EnglishDraught.Core
struct  Core_t2213953261  : public Il2CppObject
{
public:

public:
};

struct Core_t2213953261_StaticFields
{
public:
	// System.Boolean EnglishDraught.Core::isAlreadyInit
	bool ___isAlreadyInit_1;
	// System.Object EnglishDraught.Core::lockThis
	Il2CppObject * ___lockThis_2;

public:
	inline static int32_t get_offset_of_isAlreadyInit_1() { return static_cast<int32_t>(offsetof(Core_t2213953261_StaticFields, ___isAlreadyInit_1)); }
	inline bool get_isAlreadyInit_1() const { return ___isAlreadyInit_1; }
	inline bool* get_address_of_isAlreadyInit_1() { return &___isAlreadyInit_1; }
	inline void set_isAlreadyInit_1(bool value)
	{
		___isAlreadyInit_1 = value;
	}

	inline static int32_t get_offset_of_lockThis_2() { return static_cast<int32_t>(offsetof(Core_t2213953261_StaticFields, ___lockThis_2)); }
	inline Il2CppObject * get_lockThis_2() const { return ___lockThis_2; }
	inline Il2CppObject ** get_address_of_lockThis_2() { return &___lockThis_2; }
	inline void set_lockThis_2(Il2CppObject * value)
	{
		___lockThis_2 = value;
		Il2CppCodeGenWriteBarrier(&___lockThis_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
