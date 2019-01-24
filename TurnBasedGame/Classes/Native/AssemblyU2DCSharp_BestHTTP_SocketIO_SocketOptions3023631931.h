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

// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t3943999495;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.SocketOptions
struct  SocketOptions_t3023631931  : public Il2CppObject
{
public:
	// System.Boolean BestHTTP.SocketIO.SocketOptions::<Reconnection>k__BackingField
	bool ___U3CReconnectionU3Ek__BackingField_0;
	// System.Int32 BestHTTP.SocketIO.SocketOptions::<ReconnectionAttempts>k__BackingField
	int32_t ___U3CReconnectionAttemptsU3Ek__BackingField_1;
	// System.TimeSpan BestHTTP.SocketIO.SocketOptions::<ReconnectionDelay>k__BackingField
	TimeSpan_t3430258949  ___U3CReconnectionDelayU3Ek__BackingField_2;
	// System.TimeSpan BestHTTP.SocketIO.SocketOptions::<ReconnectionDelayMax>k__BackingField
	TimeSpan_t3430258949  ___U3CReconnectionDelayMaxU3Ek__BackingField_3;
	// System.Single BestHTTP.SocketIO.SocketOptions::randomizationFactor
	float ___randomizationFactor_4;
	// System.TimeSpan BestHTTP.SocketIO.SocketOptions::<Timeout>k__BackingField
	TimeSpan_t3430258949  ___U3CTimeoutU3Ek__BackingField_5;
	// System.Boolean BestHTTP.SocketIO.SocketOptions::<AutoConnect>k__BackingField
	bool ___U3CAutoConnectU3Ek__BackingField_6;
	// System.Collections.Generic.Dictionary`2<System.String,System.String> BestHTTP.SocketIO.SocketOptions::<AdditionalQueryParams>k__BackingField
	Dictionary_2_t3943999495 * ___U3CAdditionalQueryParamsU3Ek__BackingField_7;
	// System.Boolean BestHTTP.SocketIO.SocketOptions::<QueryParamsOnlyForHandshake>k__BackingField
	bool ___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8;
	// System.String BestHTTP.SocketIO.SocketOptions::BuiltQueryParams
	String_t* ___BuiltQueryParams_9;

public:
	inline static int32_t get_offset_of_U3CReconnectionU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CReconnectionU3Ek__BackingField_0)); }
	inline bool get_U3CReconnectionU3Ek__BackingField_0() const { return ___U3CReconnectionU3Ek__BackingField_0; }
	inline bool* get_address_of_U3CReconnectionU3Ek__BackingField_0() { return &___U3CReconnectionU3Ek__BackingField_0; }
	inline void set_U3CReconnectionU3Ek__BackingField_0(bool value)
	{
		___U3CReconnectionU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CReconnectionAttemptsU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CReconnectionAttemptsU3Ek__BackingField_1)); }
	inline int32_t get_U3CReconnectionAttemptsU3Ek__BackingField_1() const { return ___U3CReconnectionAttemptsU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CReconnectionAttemptsU3Ek__BackingField_1() { return &___U3CReconnectionAttemptsU3Ek__BackingField_1; }
	inline void set_U3CReconnectionAttemptsU3Ek__BackingField_1(int32_t value)
	{
		___U3CReconnectionAttemptsU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CReconnectionDelayU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CReconnectionDelayU3Ek__BackingField_2)); }
	inline TimeSpan_t3430258949  get_U3CReconnectionDelayU3Ek__BackingField_2() const { return ___U3CReconnectionDelayU3Ek__BackingField_2; }
	inline TimeSpan_t3430258949 * get_address_of_U3CReconnectionDelayU3Ek__BackingField_2() { return &___U3CReconnectionDelayU3Ek__BackingField_2; }
	inline void set_U3CReconnectionDelayU3Ek__BackingField_2(TimeSpan_t3430258949  value)
	{
		___U3CReconnectionDelayU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CReconnectionDelayMaxU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CReconnectionDelayMaxU3Ek__BackingField_3)); }
	inline TimeSpan_t3430258949  get_U3CReconnectionDelayMaxU3Ek__BackingField_3() const { return ___U3CReconnectionDelayMaxU3Ek__BackingField_3; }
	inline TimeSpan_t3430258949 * get_address_of_U3CReconnectionDelayMaxU3Ek__BackingField_3() { return &___U3CReconnectionDelayMaxU3Ek__BackingField_3; }
	inline void set_U3CReconnectionDelayMaxU3Ek__BackingField_3(TimeSpan_t3430258949  value)
	{
		___U3CReconnectionDelayMaxU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_randomizationFactor_4() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___randomizationFactor_4)); }
	inline float get_randomizationFactor_4() const { return ___randomizationFactor_4; }
	inline float* get_address_of_randomizationFactor_4() { return &___randomizationFactor_4; }
	inline void set_randomizationFactor_4(float value)
	{
		___randomizationFactor_4 = value;
	}

	inline static int32_t get_offset_of_U3CTimeoutU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CTimeoutU3Ek__BackingField_5)); }
	inline TimeSpan_t3430258949  get_U3CTimeoutU3Ek__BackingField_5() const { return ___U3CTimeoutU3Ek__BackingField_5; }
	inline TimeSpan_t3430258949 * get_address_of_U3CTimeoutU3Ek__BackingField_5() { return &___U3CTimeoutU3Ek__BackingField_5; }
	inline void set_U3CTimeoutU3Ek__BackingField_5(TimeSpan_t3430258949  value)
	{
		___U3CTimeoutU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CAutoConnectU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CAutoConnectU3Ek__BackingField_6)); }
	inline bool get_U3CAutoConnectU3Ek__BackingField_6() const { return ___U3CAutoConnectU3Ek__BackingField_6; }
	inline bool* get_address_of_U3CAutoConnectU3Ek__BackingField_6() { return &___U3CAutoConnectU3Ek__BackingField_6; }
	inline void set_U3CAutoConnectU3Ek__BackingField_6(bool value)
	{
		___U3CAutoConnectU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of_U3CAdditionalQueryParamsU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CAdditionalQueryParamsU3Ek__BackingField_7)); }
	inline Dictionary_2_t3943999495 * get_U3CAdditionalQueryParamsU3Ek__BackingField_7() const { return ___U3CAdditionalQueryParamsU3Ek__BackingField_7; }
	inline Dictionary_2_t3943999495 ** get_address_of_U3CAdditionalQueryParamsU3Ek__BackingField_7() { return &___U3CAdditionalQueryParamsU3Ek__BackingField_7; }
	inline void set_U3CAdditionalQueryParamsU3Ek__BackingField_7(Dictionary_2_t3943999495 * value)
	{
		___U3CAdditionalQueryParamsU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAdditionalQueryParamsU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8)); }
	inline bool get_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8() const { return ___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8; }
	inline bool* get_address_of_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8() { return &___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8; }
	inline void set_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8(bool value)
	{
		___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_BuiltQueryParams_9() { return static_cast<int32_t>(offsetof(SocketOptions_t3023631931, ___BuiltQueryParams_9)); }
	inline String_t* get_BuiltQueryParams_9() const { return ___BuiltQueryParams_9; }
	inline String_t** get_address_of_BuiltQueryParams_9() { return &___BuiltQueryParams_9; }
	inline void set_BuiltQueryParams_9(String_t* value)
	{
		___BuiltQueryParams_9 = value;
		Il2CppCodeGenWriteBarrier(&___BuiltQueryParams_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
