#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_TimeSpan3430258949.h"

// System.String
struct String_t;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;
// BestHTTP.SocketIO.SocketManager
struct SocketManager_t3470268644;
// System.Action`1<BestHTTP.SocketIO.HandshakeData>
struct Action_1_t1505764857;
// System.Action`2<BestHTTP.SocketIO.HandshakeData,System.String>
struct Action_2_t706596387;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.HandshakeData
struct  HandshakeData_t1703965475  : public Il2CppObject
{
public:
	// System.String BestHTTP.SocketIO.HandshakeData::<Sid>k__BackingField
	String_t* ___U3CSidU3Ek__BackingField_0;
	// System.Collections.Generic.List`1<System.String> BestHTTP.SocketIO.HandshakeData::<Upgrades>k__BackingField
	List_1_t1398341365 * ___U3CUpgradesU3Ek__BackingField_1;
	// System.TimeSpan BestHTTP.SocketIO.HandshakeData::<PingInterval>k__BackingField
	TimeSpan_t3430258949  ___U3CPingIntervalU3Ek__BackingField_2;
	// System.TimeSpan BestHTTP.SocketIO.HandshakeData::<PingTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CPingTimeoutU3Ek__BackingField_3;
	// BestHTTP.SocketIO.SocketManager BestHTTP.SocketIO.HandshakeData::<Manager>k__BackingField
	SocketManager_t3470268644 * ___U3CManagerU3Ek__BackingField_4;
	// System.Action`1<BestHTTP.SocketIO.HandshakeData> BestHTTP.SocketIO.HandshakeData::OnReceived
	Action_1_t1505764857 * ___OnReceived_5;
	// System.Action`2<BestHTTP.SocketIO.HandshakeData,System.String> BestHTTP.SocketIO.HandshakeData::OnError
	Action_2_t706596387 * ___OnError_6;
	// BestHTTP.HTTPRequest BestHTTP.SocketIO.HandshakeData::HandshakeRequest
	HTTPRequest_t138485887 * ___HandshakeRequest_7;

public:
	inline static int32_t get_offset_of_U3CSidU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___U3CSidU3Ek__BackingField_0)); }
	inline String_t* get_U3CSidU3Ek__BackingField_0() const { return ___U3CSidU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CSidU3Ek__BackingField_0() { return &___U3CSidU3Ek__BackingField_0; }
	inline void set_U3CSidU3Ek__BackingField_0(String_t* value)
	{
		___U3CSidU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSidU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CUpgradesU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___U3CUpgradesU3Ek__BackingField_1)); }
	inline List_1_t1398341365 * get_U3CUpgradesU3Ek__BackingField_1() const { return ___U3CUpgradesU3Ek__BackingField_1; }
	inline List_1_t1398341365 ** get_address_of_U3CUpgradesU3Ek__BackingField_1() { return &___U3CUpgradesU3Ek__BackingField_1; }
	inline void set_U3CUpgradesU3Ek__BackingField_1(List_1_t1398341365 * value)
	{
		___U3CUpgradesU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUpgradesU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CPingIntervalU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___U3CPingIntervalU3Ek__BackingField_2)); }
	inline TimeSpan_t3430258949  get_U3CPingIntervalU3Ek__BackingField_2() const { return ___U3CPingIntervalU3Ek__BackingField_2; }
	inline TimeSpan_t3430258949 * get_address_of_U3CPingIntervalU3Ek__BackingField_2() { return &___U3CPingIntervalU3Ek__BackingField_2; }
	inline void set_U3CPingIntervalU3Ek__BackingField_2(TimeSpan_t3430258949  value)
	{
		___U3CPingIntervalU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CPingTimeoutU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___U3CPingTimeoutU3Ek__BackingField_3)); }
	inline TimeSpan_t3430258949  get_U3CPingTimeoutU3Ek__BackingField_3() const { return ___U3CPingTimeoutU3Ek__BackingField_3; }
	inline TimeSpan_t3430258949 * get_address_of_U3CPingTimeoutU3Ek__BackingField_3() { return &___U3CPingTimeoutU3Ek__BackingField_3; }
	inline void set_U3CPingTimeoutU3Ek__BackingField_3(TimeSpan_t3430258949  value)
	{
		___U3CPingTimeoutU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CManagerU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___U3CManagerU3Ek__BackingField_4)); }
	inline SocketManager_t3470268644 * get_U3CManagerU3Ek__BackingField_4() const { return ___U3CManagerU3Ek__BackingField_4; }
	inline SocketManager_t3470268644 ** get_address_of_U3CManagerU3Ek__BackingField_4() { return &___U3CManagerU3Ek__BackingField_4; }
	inline void set_U3CManagerU3Ek__BackingField_4(SocketManager_t3470268644 * value)
	{
		___U3CManagerU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CManagerU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_OnReceived_5() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___OnReceived_5)); }
	inline Action_1_t1505764857 * get_OnReceived_5() const { return ___OnReceived_5; }
	inline Action_1_t1505764857 ** get_address_of_OnReceived_5() { return &___OnReceived_5; }
	inline void set_OnReceived_5(Action_1_t1505764857 * value)
	{
		___OnReceived_5 = value;
		Il2CppCodeGenWriteBarrier(&___OnReceived_5, value);
	}

	inline static int32_t get_offset_of_OnError_6() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___OnError_6)); }
	inline Action_2_t706596387 * get_OnError_6() const { return ___OnError_6; }
	inline Action_2_t706596387 ** get_address_of_OnError_6() { return &___OnError_6; }
	inline void set_OnError_6(Action_2_t706596387 * value)
	{
		___OnError_6 = value;
		Il2CppCodeGenWriteBarrier(&___OnError_6, value);
	}

	inline static int32_t get_offset_of_HandshakeRequest_7() { return static_cast<int32_t>(offsetof(HandshakeData_t1703965475, ___HandshakeRequest_7)); }
	inline HTTPRequest_t138485887 * get_HandshakeRequest_7() const { return ___HandshakeRequest_7; }
	inline HTTPRequest_t138485887 ** get_address_of_HandshakeRequest_7() { return &___HandshakeRequest_7; }
	inline void set_HandshakeRequest_7(HTTPRequest_t138485887 * value)
	{
		___HandshakeRequest_7 = value;
		Il2CppCodeGenWriteBarrier(&___HandshakeRequest_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
