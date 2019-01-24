#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_KeyCode2283395152.h"

// Foundation.Databinding.ButtonBinder
struct ButtonBinder_t1870671702;
// UnityEngine.UI.Button
struct Button_t2872111280;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ButtonKey
struct  ButtonKey_t1909471939  : public MonoBehaviour_t1158329972
{
public:
	// Foundation.Databinding.ButtonBinder Foundation.Databinding.ButtonKey::Binder
	ButtonBinder_t1870671702 * ___Binder_2;
	// UnityEngine.UI.Button Foundation.Databinding.ButtonKey::Button
	Button_t2872111280 * ___Button_3;
	// UnityEngine.KeyCode Foundation.Databinding.ButtonKey::Key
	int32_t ___Key_4;
	// System.Single Foundation.Databinding.ButtonKey::lastHit
	float ___lastHit_5;
	// System.Boolean Foundation.Databinding.ButtonKey::RequireDouble
	bool ___RequireDouble_6;

public:
	inline static int32_t get_offset_of_Binder_2() { return static_cast<int32_t>(offsetof(ButtonKey_t1909471939, ___Binder_2)); }
	inline ButtonBinder_t1870671702 * get_Binder_2() const { return ___Binder_2; }
	inline ButtonBinder_t1870671702 ** get_address_of_Binder_2() { return &___Binder_2; }
	inline void set_Binder_2(ButtonBinder_t1870671702 * value)
	{
		___Binder_2 = value;
		Il2CppCodeGenWriteBarrier(&___Binder_2, value);
	}

	inline static int32_t get_offset_of_Button_3() { return static_cast<int32_t>(offsetof(ButtonKey_t1909471939, ___Button_3)); }
	inline Button_t2872111280 * get_Button_3() const { return ___Button_3; }
	inline Button_t2872111280 ** get_address_of_Button_3() { return &___Button_3; }
	inline void set_Button_3(Button_t2872111280 * value)
	{
		___Button_3 = value;
		Il2CppCodeGenWriteBarrier(&___Button_3, value);
	}

	inline static int32_t get_offset_of_Key_4() { return static_cast<int32_t>(offsetof(ButtonKey_t1909471939, ___Key_4)); }
	inline int32_t get_Key_4() const { return ___Key_4; }
	inline int32_t* get_address_of_Key_4() { return &___Key_4; }
	inline void set_Key_4(int32_t value)
	{
		___Key_4 = value;
	}

	inline static int32_t get_offset_of_lastHit_5() { return static_cast<int32_t>(offsetof(ButtonKey_t1909471939, ___lastHit_5)); }
	inline float get_lastHit_5() const { return ___lastHit_5; }
	inline float* get_address_of_lastHit_5() { return &___lastHit_5; }
	inline void set_lastHit_5(float value)
	{
		___lastHit_5 = value;
	}

	inline static int32_t get_offset_of_RequireDouble_6() { return static_cast<int32_t>(offsetof(ButtonKey_t1909471939, ___RequireDouble_6)); }
	inline bool get_RequireDouble_6() const { return ___RequireDouble_6; }
	inline bool* get_address_of_RequireDouble_6() { return &___RequireDouble_6; }
	inline void set_RequireDouble_6(bool value)
	{
		___RequireDouble_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
