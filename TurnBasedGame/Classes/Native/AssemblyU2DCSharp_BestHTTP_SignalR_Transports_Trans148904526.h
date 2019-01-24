#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_SignalR_TransportStates2802087367.h"

// System.String
struct String_t;
// BestHTTP.SignalR.IConnection
struct IConnection_t313572887;
// BestHTTP.SignalR.Transports.OnTransportStateChangedDelegate
struct OnTransportStateChangedDelegate_t1888872800;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Transports.TransportBase
struct  TransportBase_t148904526  : public Il2CppObject
{
public:
	// System.String BestHTTP.SignalR.Transports.TransportBase::<Name>k__BackingField
	String_t* ___U3CNameU3Ek__BackingField_1;
	// BestHTTP.SignalR.IConnection BestHTTP.SignalR.Transports.TransportBase::<Connection>k__BackingField
	Il2CppObject * ___U3CConnectionU3Ek__BackingField_2;
	// BestHTTP.SignalR.TransportStates BestHTTP.SignalR.Transports.TransportBase::_state
	int32_t ____state_3;
	// BestHTTP.SignalR.Transports.OnTransportStateChangedDelegate BestHTTP.SignalR.Transports.TransportBase::OnStateChanged
	OnTransportStateChangedDelegate_t1888872800 * ___OnStateChanged_4;

public:
	inline static int32_t get_offset_of_U3CNameU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(TransportBase_t148904526, ___U3CNameU3Ek__BackingField_1)); }
	inline String_t* get_U3CNameU3Ek__BackingField_1() const { return ___U3CNameU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CNameU3Ek__BackingField_1() { return &___U3CNameU3Ek__BackingField_1; }
	inline void set_U3CNameU3Ek__BackingField_1(String_t* value)
	{
		___U3CNameU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNameU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CConnectionU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(TransportBase_t148904526, ___U3CConnectionU3Ek__BackingField_2)); }
	inline Il2CppObject * get_U3CConnectionU3Ek__BackingField_2() const { return ___U3CConnectionU3Ek__BackingField_2; }
	inline Il2CppObject ** get_address_of_U3CConnectionU3Ek__BackingField_2() { return &___U3CConnectionU3Ek__BackingField_2; }
	inline void set_U3CConnectionU3Ek__BackingField_2(Il2CppObject * value)
	{
		___U3CConnectionU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CConnectionU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of__state_3() { return static_cast<int32_t>(offsetof(TransportBase_t148904526, ____state_3)); }
	inline int32_t get__state_3() const { return ____state_3; }
	inline int32_t* get_address_of__state_3() { return &____state_3; }
	inline void set__state_3(int32_t value)
	{
		____state_3 = value;
	}

	inline static int32_t get_offset_of_OnStateChanged_4() { return static_cast<int32_t>(offsetof(TransportBase_t148904526, ___OnStateChanged_4)); }
	inline OnTransportStateChangedDelegate_t1888872800 * get_OnStateChanged_4() const { return ___OnStateChanged_4; }
	inline OnTransportStateChangedDelegate_t1888872800 ** get_address_of_OnStateChanged_4() { return &___OnStateChanged_4; }
	inline void set_OnStateChanged_4(OnTransportStateChangedDelegate_t1888872800 * value)
	{
		___OnStateChanged_4 = value;
		Il2CppCodeGenWriteBarrier(&___OnStateChanged_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
