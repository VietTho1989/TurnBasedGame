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

// Shogi.Core
struct  Core_t654886525  : public Il2CppObject
{
public:

public:
};

struct Core_t654886525_StaticFields
{
public:
	// System.Boolean Shogi.Core::isAlreadyInit
	bool ___isAlreadyInit_1;
	// System.Object Shogi.Core::lockThis
	Il2CppObject * ___lockThis_2;
	// System.Boolean Shogi.Core::isAlreadyInitEvaluator
	bool ___isAlreadyInitEvaluator_3;
	// System.Object Shogi.Core::lockEvaluator
	Il2CppObject * ___lockEvaluator_4;

public:
	inline static int32_t get_offset_of_isAlreadyInit_1() { return static_cast<int32_t>(offsetof(Core_t654886525_StaticFields, ___isAlreadyInit_1)); }
	inline bool get_isAlreadyInit_1() const { return ___isAlreadyInit_1; }
	inline bool* get_address_of_isAlreadyInit_1() { return &___isAlreadyInit_1; }
	inline void set_isAlreadyInit_1(bool value)
	{
		___isAlreadyInit_1 = value;
	}

	inline static int32_t get_offset_of_lockThis_2() { return static_cast<int32_t>(offsetof(Core_t654886525_StaticFields, ___lockThis_2)); }
	inline Il2CppObject * get_lockThis_2() const { return ___lockThis_2; }
	inline Il2CppObject ** get_address_of_lockThis_2() { return &___lockThis_2; }
	inline void set_lockThis_2(Il2CppObject * value)
	{
		___lockThis_2 = value;
		Il2CppCodeGenWriteBarrier(&___lockThis_2, value);
	}

	inline static int32_t get_offset_of_isAlreadyInitEvaluator_3() { return static_cast<int32_t>(offsetof(Core_t654886525_StaticFields, ___isAlreadyInitEvaluator_3)); }
	inline bool get_isAlreadyInitEvaluator_3() const { return ___isAlreadyInitEvaluator_3; }
	inline bool* get_address_of_isAlreadyInitEvaluator_3() { return &___isAlreadyInitEvaluator_3; }
	inline void set_isAlreadyInitEvaluator_3(bool value)
	{
		___isAlreadyInitEvaluator_3 = value;
	}

	inline static int32_t get_offset_of_lockEvaluator_4() { return static_cast<int32_t>(offsetof(Core_t654886525_StaticFields, ___lockEvaluator_4)); }
	inline Il2CppObject * get_lockEvaluator_4() const { return ___lockEvaluator_4; }
	inline Il2CppObject ** get_address_of_lockEvaluator_4() { return &___lockEvaluator_4; }
	inline void set_lockEvaluator_4(Il2CppObject * value)
	{
		___lockEvaluator_4 = value;
		Il2CppCodeGenWriteBarrier(&___lockEvaluator_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
