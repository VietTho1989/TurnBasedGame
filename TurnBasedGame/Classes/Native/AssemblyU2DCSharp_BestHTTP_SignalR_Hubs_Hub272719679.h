#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// BestHTTP.SignalR.Connection
struct Connection_t2915781690;
// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct Dictionary_2_t309261261;
// BestHTTP.SignalR.Hubs.OnMethodCallDelegate
struct OnMethodCallDelegate_t1474974379;
// System.Collections.Generic.Dictionary`2<System.UInt64,BestHTTP.SignalR.Messages.ClientMessage>
struct Dictionary_2_t2565362033;
// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.SignalR.Hubs.OnMethodCallCallbackDelegate>
struct Dictionary_2_t1102929720;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Hubs.Hub
struct  Hub_t272719679  : public Il2CppObject
{
public:
	// BestHTTP.SignalR.Connection BestHTTP.SignalR.Hubs.Hub::<BestHTTP.SignalR.Hubs.IHub.Connection>k__BackingField
	Connection_t2915781690 * ___U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0;
	// System.String BestHTTP.SignalR.Hubs.Hub::<Name>k__BackingField
	String_t* ___U3CNameU3Ek__BackingField_1;
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> BestHTTP.SignalR.Hubs.Hub::state
	Dictionary_2_t309261261 * ___state_2;
	// BestHTTP.SignalR.Hubs.OnMethodCallDelegate BestHTTP.SignalR.Hubs.Hub::OnMethodCall
	OnMethodCallDelegate_t1474974379 * ___OnMethodCall_3;
	// System.Collections.Generic.Dictionary`2<System.UInt64,BestHTTP.SignalR.Messages.ClientMessage> BestHTTP.SignalR.Hubs.Hub::SentMessages
	Dictionary_2_t2565362033 * ___SentMessages_4;
	// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.SignalR.Hubs.OnMethodCallCallbackDelegate> BestHTTP.SignalR.Hubs.Hub::MethodTable
	Dictionary_2_t1102929720 * ___MethodTable_5;
	// System.Text.StringBuilder BestHTTP.SignalR.Hubs.Hub::builder
	StringBuilder_t1221177846 * ___builder_6;

public:
	inline static int32_t get_offset_of_U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0)); }
	inline Connection_t2915781690 * get_U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0() const { return ___U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0; }
	inline Connection_t2915781690 ** get_address_of_U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0() { return &___U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0; }
	inline void set_U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0(Connection_t2915781690 * value)
	{
		___U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CBestHTTP_SignalR_Hubs_IHub_ConnectionU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CNameU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___U3CNameU3Ek__BackingField_1)); }
	inline String_t* get_U3CNameU3Ek__BackingField_1() const { return ___U3CNameU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CNameU3Ek__BackingField_1() { return &___U3CNameU3Ek__BackingField_1; }
	inline void set_U3CNameU3Ek__BackingField_1(String_t* value)
	{
		___U3CNameU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNameU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_state_2() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___state_2)); }
	inline Dictionary_2_t309261261 * get_state_2() const { return ___state_2; }
	inline Dictionary_2_t309261261 ** get_address_of_state_2() { return &___state_2; }
	inline void set_state_2(Dictionary_2_t309261261 * value)
	{
		___state_2 = value;
		Il2CppCodeGenWriteBarrier(&___state_2, value);
	}

	inline static int32_t get_offset_of_OnMethodCall_3() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___OnMethodCall_3)); }
	inline OnMethodCallDelegate_t1474974379 * get_OnMethodCall_3() const { return ___OnMethodCall_3; }
	inline OnMethodCallDelegate_t1474974379 ** get_address_of_OnMethodCall_3() { return &___OnMethodCall_3; }
	inline void set_OnMethodCall_3(OnMethodCallDelegate_t1474974379 * value)
	{
		___OnMethodCall_3 = value;
		Il2CppCodeGenWriteBarrier(&___OnMethodCall_3, value);
	}

	inline static int32_t get_offset_of_SentMessages_4() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___SentMessages_4)); }
	inline Dictionary_2_t2565362033 * get_SentMessages_4() const { return ___SentMessages_4; }
	inline Dictionary_2_t2565362033 ** get_address_of_SentMessages_4() { return &___SentMessages_4; }
	inline void set_SentMessages_4(Dictionary_2_t2565362033 * value)
	{
		___SentMessages_4 = value;
		Il2CppCodeGenWriteBarrier(&___SentMessages_4, value);
	}

	inline static int32_t get_offset_of_MethodTable_5() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___MethodTable_5)); }
	inline Dictionary_2_t1102929720 * get_MethodTable_5() const { return ___MethodTable_5; }
	inline Dictionary_2_t1102929720 ** get_address_of_MethodTable_5() { return &___MethodTable_5; }
	inline void set_MethodTable_5(Dictionary_2_t1102929720 * value)
	{
		___MethodTable_5 = value;
		Il2CppCodeGenWriteBarrier(&___MethodTable_5, value);
	}

	inline static int32_t get_offset_of_builder_6() { return static_cast<int32_t>(offsetof(Hub_t272719679, ___builder_6)); }
	inline StringBuilder_t1221177846 * get_builder_6() const { return ___builder_6; }
	inline StringBuilder_t1221177846 ** get_address_of_builder_6() { return &___builder_6; }
	inline void set_builder_6(StringBuilder_t1221177846 * value)
	{
		___builder_6 = value;
		Il2CppCodeGenWriteBarrier(&___builder_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
