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

// FairyChess.Core
struct  Core_t1592578867  : public Il2CppObject
{
public:

public:
};

struct Core_t1592578867_StaticFields
{
public:
	// System.Boolean FairyChess.Core::isAlreadyInit
	bool ___isAlreadyInit_1;
	// System.Object FairyChess.Core::lockFairyChessInit
	Il2CppObject * ___lockFairyChessInit_2;

public:
	inline static int32_t get_offset_of_isAlreadyInit_1() { return static_cast<int32_t>(offsetof(Core_t1592578867_StaticFields, ___isAlreadyInit_1)); }
	inline bool get_isAlreadyInit_1() const { return ___isAlreadyInit_1; }
	inline bool* get_address_of_isAlreadyInit_1() { return &___isAlreadyInit_1; }
	inline void set_isAlreadyInit_1(bool value)
	{
		___isAlreadyInit_1 = value;
	}

	inline static int32_t get_offset_of_lockFairyChessInit_2() { return static_cast<int32_t>(offsetof(Core_t1592578867_StaticFields, ___lockFairyChessInit_2)); }
	inline Il2CppObject * get_lockFairyChessInit_2() const { return ___lockFairyChessInit_2; }
	inline Il2CppObject ** get_address_of_lockFairyChessInit_2() { return &___lockFairyChessInit_2; }
	inline void set_lockFairyChessInit_2(Il2CppObject * value)
	{
		___lockFairyChessInit_2 = value;
		Il2CppCodeGenWriteBarrier(&___lockFairyChessInit_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
