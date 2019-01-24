#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.InputField
struct InputField_t1631627530;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.InputFocus
struct  InputFocus_t2433219748  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.InputField UnityEngine.UI.Extensions.InputFocus::_inputField
	InputField_t1631627530 * ____inputField_2;
	// System.Boolean UnityEngine.UI.Extensions.InputFocus::_ignoreNextActivation
	bool ____ignoreNextActivation_3;

public:
	inline static int32_t get_offset_of__inputField_2() { return static_cast<int32_t>(offsetof(InputFocus_t2433219748, ____inputField_2)); }
	inline InputField_t1631627530 * get__inputField_2() const { return ____inputField_2; }
	inline InputField_t1631627530 ** get_address_of__inputField_2() { return &____inputField_2; }
	inline void set__inputField_2(InputField_t1631627530 * value)
	{
		____inputField_2 = value;
		Il2CppCodeGenWriteBarrier(&____inputField_2, value);
	}

	inline static int32_t get_offset_of__ignoreNextActivation_3() { return static_cast<int32_t>(offsetof(InputFocus_t2433219748, ____ignoreNextActivation_3)); }
	inline bool get__ignoreNextActivation_3() const { return ____ignoreNextActivation_3; }
	inline bool* get_address_of__ignoreNextActivation_3() { return &____ignoreNextActivation_3; }
	inline void set__ignoreNextActivation_3(bool value)
	{
		____ignoreNextActivation_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
