#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "Facebook_Unity_Facebook_Unity_HttpMethod3673888207.h"

// System.Uri
struct Uri_t19570940;
// System.Collections.Generic.IDictionary`2<System.String,System.String>
struct IDictionary_2_t1943082916;
// UnityEngine.WWWForm
struct WWWForm_t3950226929;
// Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>
struct FacebookDelegate_1_t3020292135;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.AsyncRequestString
struct  AsyncRequestString_t2888107224  : public MonoBehaviour_t1158329972
{
public:
	// System.Uri Facebook.Unity.AsyncRequestString::url
	Uri_t19570940 * ___url_2;
	// Facebook.Unity.HttpMethod Facebook.Unity.AsyncRequestString::method
	int32_t ___method_3;
	// System.Collections.Generic.IDictionary`2<System.String,System.String> Facebook.Unity.AsyncRequestString::formData
	Il2CppObject* ___formData_4;
	// UnityEngine.WWWForm Facebook.Unity.AsyncRequestString::query
	WWWForm_t3950226929 * ___query_5;
	// Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult> Facebook.Unity.AsyncRequestString::callback
	FacebookDelegate_1_t3020292135 * ___callback_6;

public:
	inline static int32_t get_offset_of_url_2() { return static_cast<int32_t>(offsetof(AsyncRequestString_t2888107224, ___url_2)); }
	inline Uri_t19570940 * get_url_2() const { return ___url_2; }
	inline Uri_t19570940 ** get_address_of_url_2() { return &___url_2; }
	inline void set_url_2(Uri_t19570940 * value)
	{
		___url_2 = value;
		Il2CppCodeGenWriteBarrier(&___url_2, value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(AsyncRequestString_t2888107224, ___method_3)); }
	inline int32_t get_method_3() const { return ___method_3; }
	inline int32_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(int32_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_formData_4() { return static_cast<int32_t>(offsetof(AsyncRequestString_t2888107224, ___formData_4)); }
	inline Il2CppObject* get_formData_4() const { return ___formData_4; }
	inline Il2CppObject** get_address_of_formData_4() { return &___formData_4; }
	inline void set_formData_4(Il2CppObject* value)
	{
		___formData_4 = value;
		Il2CppCodeGenWriteBarrier(&___formData_4, value);
	}

	inline static int32_t get_offset_of_query_5() { return static_cast<int32_t>(offsetof(AsyncRequestString_t2888107224, ___query_5)); }
	inline WWWForm_t3950226929 * get_query_5() const { return ___query_5; }
	inline WWWForm_t3950226929 ** get_address_of_query_5() { return &___query_5; }
	inline void set_query_5(WWWForm_t3950226929 * value)
	{
		___query_5 = value;
		Il2CppCodeGenWriteBarrier(&___query_5, value);
	}

	inline static int32_t get_offset_of_callback_6() { return static_cast<int32_t>(offsetof(AsyncRequestString_t2888107224, ___callback_6)); }
	inline FacebookDelegate_1_t3020292135 * get_callback_6() const { return ___callback_6; }
	inline FacebookDelegate_1_t3020292135 ** get_address_of_callback_6() { return &___callback_6; }
	inline void set_callback_6(FacebookDelegate_1_t3020292135 * value)
	{
		___callback_6 = value;
		Il2CppCodeGenWriteBarrier(&___callback_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
