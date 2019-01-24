#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;
// UnityEngine.AndroidJavaObject
struct AndroidJavaObject_t4251328308;
// UnityEngine.AndroidJavaClass
struct AndroidJavaClass_t2973420583;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ShowToast
struct  ShowToast_t1881697696  : public MonoBehaviour_t1158329972
{
public:
	// System.String ShowToast::toastString
	String_t* ___toastString_2;
	// System.String ShowToast::input
	String_t* ___input_3;
	// UnityEngine.AndroidJavaObject ShowToast::currentActivity
	AndroidJavaObject_t4251328308 * ___currentActivity_4;
	// UnityEngine.AndroidJavaClass ShowToast::UnityPlayer
	AndroidJavaClass_t2973420583 * ___UnityPlayer_5;
	// UnityEngine.AndroidJavaObject ShowToast::context
	AndroidJavaObject_t4251328308 * ___context_6;

public:
	inline static int32_t get_offset_of_toastString_2() { return static_cast<int32_t>(offsetof(ShowToast_t1881697696, ___toastString_2)); }
	inline String_t* get_toastString_2() const { return ___toastString_2; }
	inline String_t** get_address_of_toastString_2() { return &___toastString_2; }
	inline void set_toastString_2(String_t* value)
	{
		___toastString_2 = value;
		Il2CppCodeGenWriteBarrier(&___toastString_2, value);
	}

	inline static int32_t get_offset_of_input_3() { return static_cast<int32_t>(offsetof(ShowToast_t1881697696, ___input_3)); }
	inline String_t* get_input_3() const { return ___input_3; }
	inline String_t** get_address_of_input_3() { return &___input_3; }
	inline void set_input_3(String_t* value)
	{
		___input_3 = value;
		Il2CppCodeGenWriteBarrier(&___input_3, value);
	}

	inline static int32_t get_offset_of_currentActivity_4() { return static_cast<int32_t>(offsetof(ShowToast_t1881697696, ___currentActivity_4)); }
	inline AndroidJavaObject_t4251328308 * get_currentActivity_4() const { return ___currentActivity_4; }
	inline AndroidJavaObject_t4251328308 ** get_address_of_currentActivity_4() { return &___currentActivity_4; }
	inline void set_currentActivity_4(AndroidJavaObject_t4251328308 * value)
	{
		___currentActivity_4 = value;
		Il2CppCodeGenWriteBarrier(&___currentActivity_4, value);
	}

	inline static int32_t get_offset_of_UnityPlayer_5() { return static_cast<int32_t>(offsetof(ShowToast_t1881697696, ___UnityPlayer_5)); }
	inline AndroidJavaClass_t2973420583 * get_UnityPlayer_5() const { return ___UnityPlayer_5; }
	inline AndroidJavaClass_t2973420583 ** get_address_of_UnityPlayer_5() { return &___UnityPlayer_5; }
	inline void set_UnityPlayer_5(AndroidJavaClass_t2973420583 * value)
	{
		___UnityPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___UnityPlayer_5, value);
	}

	inline static int32_t get_offset_of_context_6() { return static_cast<int32_t>(offsetof(ShowToast_t1881697696, ___context_6)); }
	inline AndroidJavaObject_t4251328308 * get_context_6() const { return ___context_6; }
	inline AndroidJavaObject_t4251328308 ** get_address_of_context_6() { return &___context_6; }
	inline void set_context_6(AndroidJavaObject_t4251328308 * value)
	{
		___context_6 = value;
		Il2CppCodeGenWriteBarrier(&___context_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
