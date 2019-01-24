#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_HTTPConnectionStates1509261476.h"
#include "mscorlib_System_DateTime693205669.h"

// System.String
struct String_t;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// BestHTTP.HTTPProxy
struct HTTPProxy_t2644053826;
// System.Uri
struct Uri_t19570940;
// BestHTTP.HTTPConnectionRecycledDelegate
struct HTTPConnectionRecycledDelegate_t3354195806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.ConnectionBase
struct  ConnectionBase_t2782190729  : public Il2CppObject
{
public:
	// System.String BestHTTP.ConnectionBase::<ServerAddress>k__BackingField
	String_t* ___U3CServerAddressU3Ek__BackingField_0;
	// BestHTTP.HTTPConnectionStates BestHTTP.ConnectionBase::<State>k__BackingField
	int32_t ___U3CStateU3Ek__BackingField_1;
	// BestHTTP.HTTPRequest BestHTTP.ConnectionBase::<CurrentRequest>k__BackingField
	HTTPRequest_t138485887 * ___U3CCurrentRequestU3Ek__BackingField_2;
	// System.DateTime BestHTTP.ConnectionBase::<StartTime>k__BackingField
	DateTime_t693205669  ___U3CStartTimeU3Ek__BackingField_3;
	// System.DateTime BestHTTP.ConnectionBase::<TimedOutStart>k__BackingField
	DateTime_t693205669  ___U3CTimedOutStartU3Ek__BackingField_4;
	// BestHTTP.HTTPProxy BestHTTP.ConnectionBase::<Proxy>k__BackingField
	HTTPProxy_t2644053826 * ___U3CProxyU3Ek__BackingField_5;
	// System.Uri BestHTTP.ConnectionBase::<LastProcessedUri>k__BackingField
	Uri_t19570940 * ___U3CLastProcessedUriU3Ek__BackingField_6;
	// System.DateTime BestHTTP.ConnectionBase::LastProcessTime
	DateTime_t693205669  ___LastProcessTime_7;
	// BestHTTP.HTTPConnectionRecycledDelegate BestHTTP.ConnectionBase::OnConnectionRecycled
	HTTPConnectionRecycledDelegate_t3354195806 * ___OnConnectionRecycled_8;
	// System.Boolean BestHTTP.ConnectionBase::IsThreaded
	bool ___IsThreaded_9;
	// System.Boolean BestHTTP.ConnectionBase::<IsDisposed>k__BackingField
	bool ___U3CIsDisposedU3Ek__BackingField_10;

public:
	inline static int32_t get_offset_of_U3CServerAddressU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CServerAddressU3Ek__BackingField_0)); }
	inline String_t* get_U3CServerAddressU3Ek__BackingField_0() const { return ___U3CServerAddressU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CServerAddressU3Ek__BackingField_0() { return &___U3CServerAddressU3Ek__BackingField_0; }
	inline void set_U3CServerAddressU3Ek__BackingField_0(String_t* value)
	{
		___U3CServerAddressU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CServerAddressU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CStateU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CStateU3Ek__BackingField_1)); }
	inline int32_t get_U3CStateU3Ek__BackingField_1() const { return ___U3CStateU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CStateU3Ek__BackingField_1() { return &___U3CStateU3Ek__BackingField_1; }
	inline void set_U3CStateU3Ek__BackingField_1(int32_t value)
	{
		___U3CStateU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CCurrentRequestU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CCurrentRequestU3Ek__BackingField_2)); }
	inline HTTPRequest_t138485887 * get_U3CCurrentRequestU3Ek__BackingField_2() const { return ___U3CCurrentRequestU3Ek__BackingField_2; }
	inline HTTPRequest_t138485887 ** get_address_of_U3CCurrentRequestU3Ek__BackingField_2() { return &___U3CCurrentRequestU3Ek__BackingField_2; }
	inline void set_U3CCurrentRequestU3Ek__BackingField_2(HTTPRequest_t138485887 * value)
	{
		___U3CCurrentRequestU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCurrentRequestU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CStartTimeU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CStartTimeU3Ek__BackingField_3)); }
	inline DateTime_t693205669  get_U3CStartTimeU3Ek__BackingField_3() const { return ___U3CStartTimeU3Ek__BackingField_3; }
	inline DateTime_t693205669 * get_address_of_U3CStartTimeU3Ek__BackingField_3() { return &___U3CStartTimeU3Ek__BackingField_3; }
	inline void set_U3CStartTimeU3Ek__BackingField_3(DateTime_t693205669  value)
	{
		___U3CStartTimeU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CTimedOutStartU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CTimedOutStartU3Ek__BackingField_4)); }
	inline DateTime_t693205669  get_U3CTimedOutStartU3Ek__BackingField_4() const { return ___U3CTimedOutStartU3Ek__BackingField_4; }
	inline DateTime_t693205669 * get_address_of_U3CTimedOutStartU3Ek__BackingField_4() { return &___U3CTimedOutStartU3Ek__BackingField_4; }
	inline void set_U3CTimedOutStartU3Ek__BackingField_4(DateTime_t693205669  value)
	{
		___U3CTimedOutStartU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CProxyU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CProxyU3Ek__BackingField_5)); }
	inline HTTPProxy_t2644053826 * get_U3CProxyU3Ek__BackingField_5() const { return ___U3CProxyU3Ek__BackingField_5; }
	inline HTTPProxy_t2644053826 ** get_address_of_U3CProxyU3Ek__BackingField_5() { return &___U3CProxyU3Ek__BackingField_5; }
	inline void set_U3CProxyU3Ek__BackingField_5(HTTPProxy_t2644053826 * value)
	{
		___U3CProxyU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CProxyU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CLastProcessedUriU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CLastProcessedUriU3Ek__BackingField_6)); }
	inline Uri_t19570940 * get_U3CLastProcessedUriU3Ek__BackingField_6() const { return ___U3CLastProcessedUriU3Ek__BackingField_6; }
	inline Uri_t19570940 ** get_address_of_U3CLastProcessedUriU3Ek__BackingField_6() { return &___U3CLastProcessedUriU3Ek__BackingField_6; }
	inline void set_U3CLastProcessedUriU3Ek__BackingField_6(Uri_t19570940 * value)
	{
		___U3CLastProcessedUriU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CLastProcessedUriU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_LastProcessTime_7() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___LastProcessTime_7)); }
	inline DateTime_t693205669  get_LastProcessTime_7() const { return ___LastProcessTime_7; }
	inline DateTime_t693205669 * get_address_of_LastProcessTime_7() { return &___LastProcessTime_7; }
	inline void set_LastProcessTime_7(DateTime_t693205669  value)
	{
		___LastProcessTime_7 = value;
	}

	inline static int32_t get_offset_of_OnConnectionRecycled_8() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___OnConnectionRecycled_8)); }
	inline HTTPConnectionRecycledDelegate_t3354195806 * get_OnConnectionRecycled_8() const { return ___OnConnectionRecycled_8; }
	inline HTTPConnectionRecycledDelegate_t3354195806 ** get_address_of_OnConnectionRecycled_8() { return &___OnConnectionRecycled_8; }
	inline void set_OnConnectionRecycled_8(HTTPConnectionRecycledDelegate_t3354195806 * value)
	{
		___OnConnectionRecycled_8 = value;
		Il2CppCodeGenWriteBarrier(&___OnConnectionRecycled_8, value);
	}

	inline static int32_t get_offset_of_IsThreaded_9() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___IsThreaded_9)); }
	inline bool get_IsThreaded_9() const { return ___IsThreaded_9; }
	inline bool* get_address_of_IsThreaded_9() { return &___IsThreaded_9; }
	inline void set_IsThreaded_9(bool value)
	{
		___IsThreaded_9 = value;
	}

	inline static int32_t get_offset_of_U3CIsDisposedU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(ConnectionBase_t2782190729, ___U3CIsDisposedU3Ek__BackingField_10)); }
	inline bool get_U3CIsDisposedU3Ek__BackingField_10() const { return ___U3CIsDisposedU3Ek__BackingField_10; }
	inline bool* get_address_of_U3CIsDisposedU3Ek__BackingField_10() { return &___U3CIsDisposedU3Ek__BackingField_10; }
	inline void set_U3CIsDisposedU3Ek__BackingField_10(bool value)
	{
		___U3CIsDisposedU3Ek__BackingField_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
