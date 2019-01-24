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
// UnityEngine.UI.Button
struct Button_t2872111280;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.InputFieldInScrollRectFixer
struct  InputFieldInScrollRectFixer_t3497308592  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.InputField frame8.ScrollRectItemsAdapter.Util.InputFieldInScrollRectFixer::_InputField
	InputField_t1631627530 * ____InputField_2;
	// UnityEngine.UI.Button frame8.ScrollRectItemsAdapter.Util.InputFieldInScrollRectFixer::_Button
	Button_t2872111280 * ____Button_3;

public:
	inline static int32_t get_offset_of__InputField_2() { return static_cast<int32_t>(offsetof(InputFieldInScrollRectFixer_t3497308592, ____InputField_2)); }
	inline InputField_t1631627530 * get__InputField_2() const { return ____InputField_2; }
	inline InputField_t1631627530 ** get_address_of__InputField_2() { return &____InputField_2; }
	inline void set__InputField_2(InputField_t1631627530 * value)
	{
		____InputField_2 = value;
		Il2CppCodeGenWriteBarrier(&____InputField_2, value);
	}

	inline static int32_t get_offset_of__Button_3() { return static_cast<int32_t>(offsetof(InputFieldInScrollRectFixer_t3497308592, ____Button_3)); }
	inline Button_t2872111280 * get__Button_3() const { return ____Button_3; }
	inline Button_t2872111280 ** get_address_of__Button_3() { return &____Button_3; }
	inline void set__Button_3(Button_t2872111280 * value)
	{
		____Button_3 = value;
		Il2CppCodeGenWriteBarrier(&____Button_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
