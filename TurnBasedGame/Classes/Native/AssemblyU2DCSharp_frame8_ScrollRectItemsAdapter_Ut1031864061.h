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
// System.Action`1<frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Result>
struct Action_1_t2672671055;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request
struct  Request_t1031864061  : public Il2CppObject
{
public:
	// System.String frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request::url
	String_t* ___url_0;
	// System.Action`1<frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Result> frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request::onDone
	Action_1_t2672671055 * ___onDone_1;
	// System.Action frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request::onError
	Action_t3226471752 * ___onError_2;

public:
	inline static int32_t get_offset_of_url_0() { return static_cast<int32_t>(offsetof(Request_t1031864061, ___url_0)); }
	inline String_t* get_url_0() const { return ___url_0; }
	inline String_t** get_address_of_url_0() { return &___url_0; }
	inline void set_url_0(String_t* value)
	{
		___url_0 = value;
		Il2CppCodeGenWriteBarrier(&___url_0, value);
	}

	inline static int32_t get_offset_of_onDone_1() { return static_cast<int32_t>(offsetof(Request_t1031864061, ___onDone_1)); }
	inline Action_1_t2672671055 * get_onDone_1() const { return ___onDone_1; }
	inline Action_1_t2672671055 ** get_address_of_onDone_1() { return &___onDone_1; }
	inline void set_onDone_1(Action_1_t2672671055 * value)
	{
		___onDone_1 = value;
		Il2CppCodeGenWriteBarrier(&___onDone_1, value);
	}

	inline static int32_t get_offset_of_onError_2() { return static_cast<int32_t>(offsetof(Request_t1031864061, ___onError_2)); }
	inline Action_t3226471752 * get_onError_2() const { return ___onError_2; }
	inline Action_t3226471752 ** get_address_of_onError_2() { return &___onError_2; }
	inline void set_onError_2(Action_t3226471752 * value)
	{
		___onError_2 = value;
		Il2CppCodeGenWriteBarrier(&___onError_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
