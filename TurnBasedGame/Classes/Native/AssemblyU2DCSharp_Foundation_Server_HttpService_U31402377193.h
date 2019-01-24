#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.WWW
struct WWW_t2919945039;
// System.Action`1<Foundation.Tasks.Response`1<System.String>>
struct Action_1_t232766016;
// Foundation.Tasks.HttpMetadata
struct HttpMetadata_t2935150347;
// Foundation.Server.HttpService
struct HttpService_t1528482479;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3
struct  U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193  : public Il2CppObject
{
public:
	// UnityEngine.WWW Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::www
	WWW_t2919945039 * ___www_0;
	// System.Action`1<Foundation.Tasks.Response`1<System.String>> Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::task
	Action_1_t232766016 * ___task_1;
	// Foundation.Tasks.HttpMetadata Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::<meta>__1
	HttpMetadata_t2935150347 * ___U3CmetaU3E__1_2;
	// Foundation.Server.HttpService Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::$this
	HttpService_t1528482479 * ___U24this_3;
	// System.Object Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::$current
	Il2CppObject * ___U24current_4;
	// System.Boolean Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::$disposing
	bool ___U24disposing_5;
	// System.Int32 Foundation.Server.HttpService/<HandleWWWAsync>c__Iterator3::$PC
	int32_t ___U24PC_6;

public:
	inline static int32_t get_offset_of_www_0() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___www_0)); }
	inline WWW_t2919945039 * get_www_0() const { return ___www_0; }
	inline WWW_t2919945039 ** get_address_of_www_0() { return &___www_0; }
	inline void set_www_0(WWW_t2919945039 * value)
	{
		___www_0 = value;
		Il2CppCodeGenWriteBarrier(&___www_0, value);
	}

	inline static int32_t get_offset_of_task_1() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___task_1)); }
	inline Action_1_t232766016 * get_task_1() const { return ___task_1; }
	inline Action_1_t232766016 ** get_address_of_task_1() { return &___task_1; }
	inline void set_task_1(Action_1_t232766016 * value)
	{
		___task_1 = value;
		Il2CppCodeGenWriteBarrier(&___task_1, value);
	}

	inline static int32_t get_offset_of_U3CmetaU3E__1_2() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___U3CmetaU3E__1_2)); }
	inline HttpMetadata_t2935150347 * get_U3CmetaU3E__1_2() const { return ___U3CmetaU3E__1_2; }
	inline HttpMetadata_t2935150347 ** get_address_of_U3CmetaU3E__1_2() { return &___U3CmetaU3E__1_2; }
	inline void set_U3CmetaU3E__1_2(HttpMetadata_t2935150347 * value)
	{
		___U3CmetaU3E__1_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CmetaU3E__1_2, value);
	}

	inline static int32_t get_offset_of_U24this_3() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___U24this_3)); }
	inline HttpService_t1528482479 * get_U24this_3() const { return ___U24this_3; }
	inline HttpService_t1528482479 ** get_address_of_U24this_3() { return &___U24this_3; }
	inline void set_U24this_3(HttpService_t1528482479 * value)
	{
		___U24this_3 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_3, value);
	}

	inline static int32_t get_offset_of_U24current_4() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___U24current_4)); }
	inline Il2CppObject * get_U24current_4() const { return ___U24current_4; }
	inline Il2CppObject ** get_address_of_U24current_4() { return &___U24current_4; }
	inline void set_U24current_4(Il2CppObject * value)
	{
		___U24current_4 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_4, value);
	}

	inline static int32_t get_offset_of_U24disposing_5() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___U24disposing_5)); }
	inline bool get_U24disposing_5() const { return ___U24disposing_5; }
	inline bool* get_address_of_U24disposing_5() { return &___U24disposing_5; }
	inline void set_U24disposing_5(bool value)
	{
		___U24disposing_5 = value;
	}

	inline static int32_t get_offset_of_U24PC_6() { return static_cast<int32_t>(offsetof(U3CHandleWWWAsyncU3Ec__Iterator3_t1402377193, ___U24PC_6)); }
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
