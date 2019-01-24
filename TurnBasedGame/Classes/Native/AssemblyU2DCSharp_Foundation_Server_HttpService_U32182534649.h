#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// UnityEngine.WWW
struct WWW_t2919945039;
// System.Action`1<Foundation.Tasks.Response`1<System.String>>
struct Action_1_t232766016;
// Foundation.Server.HttpService
struct HttpService_t1528482479;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.HttpService/<GetAsync>c__Iterator0
struct  U3CGetAsyncU3Ec__Iterator0_t2182534649  : public Il2CppObject
{
public:
	// System.String Foundation.Server.HttpService/<GetAsync>c__Iterator0::url
	String_t* ___url_0;
	// UnityEngine.WWW Foundation.Server.HttpService/<GetAsync>c__Iterator0::<www>__1
	WWW_t2919945039 * ___U3CwwwU3E__1_1;
	// System.Action`1<Foundation.Tasks.Response`1<System.String>> Foundation.Server.HttpService/<GetAsync>c__Iterator0::task
	Action_1_t232766016 * ___task_2;
	// Foundation.Server.HttpService Foundation.Server.HttpService/<GetAsync>c__Iterator0::$this
	HttpService_t1528482479 * ___U24this_3;
	// System.Object Foundation.Server.HttpService/<GetAsync>c__Iterator0::$current
	Il2CppObject * ___U24current_4;
	// System.Boolean Foundation.Server.HttpService/<GetAsync>c__Iterator0::$disposing
	bool ___U24disposing_5;
	// System.Int32 Foundation.Server.HttpService/<GetAsync>c__Iterator0::$PC
	int32_t ___U24PC_6;

public:
	inline static int32_t get_offset_of_url_0() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___url_0)); }
	inline String_t* get_url_0() const { return ___url_0; }
	inline String_t** get_address_of_url_0() { return &___url_0; }
	inline void set_url_0(String_t* value)
	{
		___url_0 = value;
		Il2CppCodeGenWriteBarrier(&___url_0, value);
	}

	inline static int32_t get_offset_of_U3CwwwU3E__1_1() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___U3CwwwU3E__1_1)); }
	inline WWW_t2919945039 * get_U3CwwwU3E__1_1() const { return ___U3CwwwU3E__1_1; }
	inline WWW_t2919945039 ** get_address_of_U3CwwwU3E__1_1() { return &___U3CwwwU3E__1_1; }
	inline void set_U3CwwwU3E__1_1(WWW_t2919945039 * value)
	{
		___U3CwwwU3E__1_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CwwwU3E__1_1, value);
	}

	inline static int32_t get_offset_of_task_2() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___task_2)); }
	inline Action_1_t232766016 * get_task_2() const { return ___task_2; }
	inline Action_1_t232766016 ** get_address_of_task_2() { return &___task_2; }
	inline void set_task_2(Action_1_t232766016 * value)
	{
		___task_2 = value;
		Il2CppCodeGenWriteBarrier(&___task_2, value);
	}

	inline static int32_t get_offset_of_U24this_3() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___U24this_3)); }
	inline HttpService_t1528482479 * get_U24this_3() const { return ___U24this_3; }
	inline HttpService_t1528482479 ** get_address_of_U24this_3() { return &___U24this_3; }
	inline void set_U24this_3(HttpService_t1528482479 * value)
	{
		___U24this_3 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_3, value);
	}

	inline static int32_t get_offset_of_U24current_4() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___U24current_4)); }
	inline Il2CppObject * get_U24current_4() const { return ___U24current_4; }
	inline Il2CppObject ** get_address_of_U24current_4() { return &___U24current_4; }
	inline void set_U24current_4(Il2CppObject * value)
	{
		___U24current_4 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_4, value);
	}

	inline static int32_t get_offset_of_U24disposing_5() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___U24disposing_5)); }
	inline bool get_U24disposing_5() const { return ___U24disposing_5; }
	inline bool* get_address_of_U24disposing_5() { return &___U24disposing_5; }
	inline void set_U24disposing_5(bool value)
	{
		___U24disposing_5 = value;
	}

	inline static int32_t get_offset_of_U24PC_6() { return static_cast<int32_t>(offsetof(U3CGetAsyncU3Ec__Iterator0_t2182534649, ___U24PC_6)); }
	inline int32_t get_U24PC_6() const { return ___U24PC_6; }
	inline int32_t* get_address_of_U24PC_6() { return &___U24PC_6; }
	inline void set_U24PC_6(int32_t value)
	{
		___U24PC_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
