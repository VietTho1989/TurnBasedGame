#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader
struct SimpleImageDownloader_t2498157696;
// System.Collections.Generic.List`1<frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request>
struct List_1_t400985193;
// UnityEngine.WaitForSeconds
struct WaitForSeconds_t3839502067;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader
struct  SimpleImageDownloader_t2498157696  : public MonoBehaviour_t1158329972
{
public:
	// System.Int32 frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader::<MaxConcurrentRequests>k__BackingField
	int32_t ___U3CMaxConcurrentRequestsU3Ek__BackingField_3;
	// System.Collections.Generic.List`1<frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request> frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader::_QueuedRequests
	List_1_t400985193 * ____QueuedRequests_5;
	// System.Collections.Generic.List`1<frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader/Request> frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader::_ExecutingRequests
	List_1_t400985193 * ____ExecutingRequests_6;
	// UnityEngine.WaitForSeconds frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader::_Wait1Sec
	WaitForSeconds_t3839502067 * ____Wait1Sec_7;

public:
	inline static int32_t get_offset_of_U3CMaxConcurrentRequestsU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(SimpleImageDownloader_t2498157696, ___U3CMaxConcurrentRequestsU3Ek__BackingField_3)); }
	inline int32_t get_U3CMaxConcurrentRequestsU3Ek__BackingField_3() const { return ___U3CMaxConcurrentRequestsU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CMaxConcurrentRequestsU3Ek__BackingField_3() { return &___U3CMaxConcurrentRequestsU3Ek__BackingField_3; }
	inline void set_U3CMaxConcurrentRequestsU3Ek__BackingField_3(int32_t value)
	{
		___U3CMaxConcurrentRequestsU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of__QueuedRequests_5() { return static_cast<int32_t>(offsetof(SimpleImageDownloader_t2498157696, ____QueuedRequests_5)); }
	inline List_1_t400985193 * get__QueuedRequests_5() const { return ____QueuedRequests_5; }
	inline List_1_t400985193 ** get_address_of__QueuedRequests_5() { return &____QueuedRequests_5; }
	inline void set__QueuedRequests_5(List_1_t400985193 * value)
	{
		____QueuedRequests_5 = value;
		Il2CppCodeGenWriteBarrier(&____QueuedRequests_5, value);
	}

	inline static int32_t get_offset_of__ExecutingRequests_6() { return static_cast<int32_t>(offsetof(SimpleImageDownloader_t2498157696, ____ExecutingRequests_6)); }
	inline List_1_t400985193 * get__ExecutingRequests_6() const { return ____ExecutingRequests_6; }
	inline List_1_t400985193 ** get_address_of__ExecutingRequests_6() { return &____ExecutingRequests_6; }
	inline void set__ExecutingRequests_6(List_1_t400985193 * value)
	{
		____ExecutingRequests_6 = value;
		Il2CppCodeGenWriteBarrier(&____ExecutingRequests_6, value);
	}

	inline static int32_t get_offset_of__Wait1Sec_7() { return static_cast<int32_t>(offsetof(SimpleImageDownloader_t2498157696, ____Wait1Sec_7)); }
	inline WaitForSeconds_t3839502067 * get__Wait1Sec_7() const { return ____Wait1Sec_7; }
	inline WaitForSeconds_t3839502067 ** get_address_of__Wait1Sec_7() { return &____Wait1Sec_7; }
	inline void set__Wait1Sec_7(WaitForSeconds_t3839502067 * value)
	{
		____Wait1Sec_7 = value;
		Il2CppCodeGenWriteBarrier(&____Wait1Sec_7, value);
	}
};

struct SimpleImageDownloader_t2498157696_StaticFields
{
public:
	// frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader frame8.ScrollRectItemsAdapter.Util.SimpleImageDownloader::_Instance
	SimpleImageDownloader_t2498157696 * ____Instance_2;

public:
	inline static int32_t get_offset_of__Instance_2() { return static_cast<int32_t>(offsetof(SimpleImageDownloader_t2498157696_StaticFields, ____Instance_2)); }
	inline SimpleImageDownloader_t2498157696 * get__Instance_2() const { return ____Instance_2; }
	inline SimpleImageDownloader_t2498157696 ** get_address_of__Instance_2() { return &____Instance_2; }
	inline void set__Instance_2(SimpleImageDownloader_t2498157696 * value)
	{
		____Instance_2 = value;
		Il2CppCodeGenWriteBarrier(&____Instance_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
