#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// BestHTTP.SignalR.Hubs.Hub
struct Hub_t272719679;
// System.String
struct String_t;
// System.Object[]
struct ObjectU5BU5D_t3614634134;
// BestHTTP.SignalR.Hubs.OnMethodResultDelegate
struct OnMethodResultDelegate_t3666295392;
// BestHTTP.SignalR.Hubs.OnMethodFailedDelegate
struct OnMethodFailedDelegate_t3007711612;
// BestHTTP.SignalR.Hubs.OnMethodProgressDelegate
struct OnMethodProgressDelegate_t4205605290;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Messages.ClientMessage
struct  ClientMessage_t624279968 
{
public:
	// BestHTTP.SignalR.Hubs.Hub BestHTTP.SignalR.Messages.ClientMessage::Hub
	Hub_t272719679 * ___Hub_0;
	// System.String BestHTTP.SignalR.Messages.ClientMessage::Method
	String_t* ___Method_1;
	// System.Object[] BestHTTP.SignalR.Messages.ClientMessage::Args
	ObjectU5BU5D_t3614634134* ___Args_2;
	// System.UInt64 BestHTTP.SignalR.Messages.ClientMessage::CallIdx
	uint64_t ___CallIdx_3;
	// BestHTTP.SignalR.Hubs.OnMethodResultDelegate BestHTTP.SignalR.Messages.ClientMessage::ResultCallback
	OnMethodResultDelegate_t3666295392 * ___ResultCallback_4;
	// BestHTTP.SignalR.Hubs.OnMethodFailedDelegate BestHTTP.SignalR.Messages.ClientMessage::ResultErrorCallback
	OnMethodFailedDelegate_t3007711612 * ___ResultErrorCallback_5;
	// BestHTTP.SignalR.Hubs.OnMethodProgressDelegate BestHTTP.SignalR.Messages.ClientMessage::ProgressCallback
	OnMethodProgressDelegate_t4205605290 * ___ProgressCallback_6;

public:
	inline static int32_t get_offset_of_Hub_0() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___Hub_0)); }
	inline Hub_t272719679 * get_Hub_0() const { return ___Hub_0; }
	inline Hub_t272719679 ** get_address_of_Hub_0() { return &___Hub_0; }
	inline void set_Hub_0(Hub_t272719679 * value)
	{
		___Hub_0 = value;
		Il2CppCodeGenWriteBarrier(&___Hub_0, value);
	}

	inline static int32_t get_offset_of_Method_1() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___Method_1)); }
	inline String_t* get_Method_1() const { return ___Method_1; }
	inline String_t** get_address_of_Method_1() { return &___Method_1; }
	inline void set_Method_1(String_t* value)
	{
		___Method_1 = value;
		Il2CppCodeGenWriteBarrier(&___Method_1, value);
	}

	inline static int32_t get_offset_of_Args_2() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___Args_2)); }
	inline ObjectU5BU5D_t3614634134* get_Args_2() const { return ___Args_2; }
	inline ObjectU5BU5D_t3614634134** get_address_of_Args_2() { return &___Args_2; }
	inline void set_Args_2(ObjectU5BU5D_t3614634134* value)
	{
		___Args_2 = value;
		Il2CppCodeGenWriteBarrier(&___Args_2, value);
	}

	inline static int32_t get_offset_of_CallIdx_3() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___CallIdx_3)); }
	inline uint64_t get_CallIdx_3() const { return ___CallIdx_3; }
	inline uint64_t* get_address_of_CallIdx_3() { return &___CallIdx_3; }
	inline void set_CallIdx_3(uint64_t value)
	{
		___CallIdx_3 = value;
	}

	inline static int32_t get_offset_of_ResultCallback_4() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___ResultCallback_4)); }
	inline OnMethodResultDelegate_t3666295392 * get_ResultCallback_4() const { return ___ResultCallback_4; }
	inline OnMethodResultDelegate_t3666295392 ** get_address_of_ResultCallback_4() { return &___ResultCallback_4; }
	inline void set_ResultCallback_4(OnMethodResultDelegate_t3666295392 * value)
	{
		___ResultCallback_4 = value;
		Il2CppCodeGenWriteBarrier(&___ResultCallback_4, value);
	}

	inline static int32_t get_offset_of_ResultErrorCallback_5() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___ResultErrorCallback_5)); }
	inline OnMethodFailedDelegate_t3007711612 * get_ResultErrorCallback_5() const { return ___ResultErrorCallback_5; }
	inline OnMethodFailedDelegate_t3007711612 ** get_address_of_ResultErrorCallback_5() { return &___ResultErrorCallback_5; }
	inline void set_ResultErrorCallback_5(OnMethodFailedDelegate_t3007711612 * value)
	{
		___ResultErrorCallback_5 = value;
		Il2CppCodeGenWriteBarrier(&___ResultErrorCallback_5, value);
	}

	inline static int32_t get_offset_of_ProgressCallback_6() { return static_cast<int32_t>(offsetof(ClientMessage_t624279968, ___ProgressCallback_6)); }
	inline OnMethodProgressDelegate_t4205605290 * get_ProgressCallback_6() const { return ___ProgressCallback_6; }
	inline OnMethodProgressDelegate_t4205605290 ** get_address_of_ProgressCallback_6() { return &___ProgressCallback_6; }
	inline void set_ProgressCallback_6(OnMethodProgressDelegate_t4205605290 * value)
	{
		___ProgressCallback_6 = value;
		Il2CppCodeGenWriteBarrier(&___ProgressCallback_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of BestHTTP.SignalR.Messages.ClientMessage
struct ClientMessage_t624279968_marshaled_pinvoke
{
	Hub_t272719679 * ___Hub_0;
	char* ___Method_1;
	ObjectU5BU5D_t3614634134* ___Args_2;
	uint64_t ___CallIdx_3;
	Il2CppMethodPointer ___ResultCallback_4;
	Il2CppMethodPointer ___ResultErrorCallback_5;
	Il2CppMethodPointer ___ProgressCallback_6;
};
// Native definition for COM marshalling of BestHTTP.SignalR.Messages.ClientMessage
struct ClientMessage_t624279968_marshaled_com
{
	Hub_t272719679 * ___Hub_0;
	Il2CppChar* ___Method_1;
	ObjectU5BU5D_t3614634134* ___Args_2;
	uint64_t ___CallIdx_3;
	Il2CppMethodPointer ___ResultCallback_4;
	Il2CppMethodPointer ___ResultErrorCallback_5;
	Il2CppMethodPointer ___ProgressCallback_6;
};
