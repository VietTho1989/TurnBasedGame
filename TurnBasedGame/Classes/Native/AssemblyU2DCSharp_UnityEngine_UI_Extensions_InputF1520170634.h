#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Extensions.InputFieldEnterSubmit/EnterSubmitEvent
struct EnterSubmitEvent_t3688949694;
// UnityEngine.UI.InputField
struct InputField_t1631627530;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.InputFieldEnterSubmit
struct  InputFieldEnterSubmit_t1520170634  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.InputFieldEnterSubmit/EnterSubmitEvent UnityEngine.UI.Extensions.InputFieldEnterSubmit::EnterSubmit
	EnterSubmitEvent_t3688949694 * ___EnterSubmit_2;
	// UnityEngine.UI.InputField UnityEngine.UI.Extensions.InputFieldEnterSubmit::_input
	InputField_t1631627530 * ____input_3;

public:
	inline static int32_t get_offset_of_EnterSubmit_2() { return static_cast<int32_t>(offsetof(InputFieldEnterSubmit_t1520170634, ___EnterSubmit_2)); }
	inline EnterSubmitEvent_t3688949694 * get_EnterSubmit_2() const { return ___EnterSubmit_2; }
	inline EnterSubmitEvent_t3688949694 ** get_address_of_EnterSubmit_2() { return &___EnterSubmit_2; }
	inline void set_EnterSubmit_2(EnterSubmitEvent_t3688949694 * value)
	{
		___EnterSubmit_2 = value;
		Il2CppCodeGenWriteBarrier(&___EnterSubmit_2, value);
	}

	inline static int32_t get_offset_of__input_3() { return static_cast<int32_t>(offsetof(InputFieldEnterSubmit_t1520170634, ____input_3)); }
	inline InputField_t1631627530 * get__input_3() const { return ____input_3; }
	inline InputField_t1631627530 ** get_address_of__input_3() { return &____input_3; }
	inline void set__input_3(InputField_t1631627530 * value)
	{
		____input_3 = value;
		Il2CppCodeGenWriteBarrier(&____input_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
