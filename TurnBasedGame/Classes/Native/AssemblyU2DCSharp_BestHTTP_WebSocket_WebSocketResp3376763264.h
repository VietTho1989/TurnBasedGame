#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_HTTPResponse62748825.h"
#include "mscorlib_System_TimeSpan3430258949.h"
#include "mscorlib_System_DateTime693205669.h"

// System.Action`2<BestHTTP.WebSocket.WebSocketResponse,System.String>
struct Action_2_t1029759410;
// System.Action`2<BestHTTP.WebSocket.WebSocketResponse,System.Byte[]>
struct Action_2_t2397873190;
// System.Action`2<BestHTTP.WebSocket.WebSocketResponse,BestHTTP.WebSocket.Frames.WebSocketFrameReader>
struct Action_2_t3844780342;
// System.Action`3<BestHTTP.WebSocket.WebSocketResponse,System.UInt16,System.String>
struct Action_3_t2791643950;
// System.Collections.Generic.List`1<BestHTTP.WebSocket.Frames.WebSocketFrameReader>
struct List_1_t4213362297;
// BestHTTP.WebSocket.Frames.WebSocketFrameReader
struct WebSocketFrameReader_t549273869;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.WebSocket.WebSocketResponse
struct  WebSocketResponse_t3376763264  : public HTTPResponse_t62748825
{
public:
	// System.Action`2<BestHTTP.WebSocket.WebSocketResponse,System.String> BestHTTP.WebSocket.WebSocketResponse::OnText
	Action_2_t1029759410 * ___OnText_25;
	// System.Action`2<BestHTTP.WebSocket.WebSocketResponse,System.Byte[]> BestHTTP.WebSocket.WebSocketResponse::OnBinary
	Action_2_t2397873190 * ___OnBinary_26;
	// System.Action`2<BestHTTP.WebSocket.WebSocketResponse,BestHTTP.WebSocket.Frames.WebSocketFrameReader> BestHTTP.WebSocket.WebSocketResponse::OnIncompleteFrame
	Action_2_t3844780342 * ___OnIncompleteFrame_27;
	// System.Action`3<BestHTTP.WebSocket.WebSocketResponse,System.UInt16,System.String> BestHTTP.WebSocket.WebSocketResponse::OnClosed
	Action_3_t2791643950 * ___OnClosed_28;
	// System.TimeSpan BestHTTP.WebSocket.WebSocketResponse::<PingFrequnecy>k__BackingField
	TimeSpan_t3430258949  ___U3CPingFrequnecyU3Ek__BackingField_29;
	// System.UInt16 BestHTTP.WebSocket.WebSocketResponse::<MaxFragmentSize>k__BackingField
	uint16_t ___U3CMaxFragmentSizeU3Ek__BackingField_30;
	// System.Collections.Generic.List`1<BestHTTP.WebSocket.Frames.WebSocketFrameReader> BestHTTP.WebSocket.WebSocketResponse::IncompleteFrames
	List_1_t4213362297 * ___IncompleteFrames_31;
	// System.Collections.Generic.List`1<BestHTTP.WebSocket.Frames.WebSocketFrameReader> BestHTTP.WebSocket.WebSocketResponse::CompletedFrames
	List_1_t4213362297 * ___CompletedFrames_32;
	// BestHTTP.WebSocket.Frames.WebSocketFrameReader BestHTTP.WebSocket.WebSocketResponse::CloseFrame
	WebSocketFrameReader_t549273869 * ___CloseFrame_33;
	// System.Object BestHTTP.WebSocket.WebSocketResponse::FrameLock
	Il2CppObject * ___FrameLock_34;
	// System.Object BestHTTP.WebSocket.WebSocketResponse::SendLock
	Il2CppObject * ___SendLock_35;
	// System.Boolean BestHTTP.WebSocket.WebSocketResponse::closeSent
	bool ___closeSent_36;
	// System.Boolean BestHTTP.WebSocket.WebSocketResponse::closed
	bool ___closed_37;
	// System.DateTime BestHTTP.WebSocket.WebSocketResponse::lastPing
	DateTime_t693205669  ___lastPing_38;

public:
	inline static int32_t get_offset_of_OnText_25() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___OnText_25)); }
	inline Action_2_t1029759410 * get_OnText_25() const { return ___OnText_25; }
	inline Action_2_t1029759410 ** get_address_of_OnText_25() { return &___OnText_25; }
	inline void set_OnText_25(Action_2_t1029759410 * value)
	{
		___OnText_25 = value;
		Il2CppCodeGenWriteBarrier(&___OnText_25, value);
	}

	inline static int32_t get_offset_of_OnBinary_26() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___OnBinary_26)); }
	inline Action_2_t2397873190 * get_OnBinary_26() const { return ___OnBinary_26; }
	inline Action_2_t2397873190 ** get_address_of_OnBinary_26() { return &___OnBinary_26; }
	inline void set_OnBinary_26(Action_2_t2397873190 * value)
	{
		___OnBinary_26 = value;
		Il2CppCodeGenWriteBarrier(&___OnBinary_26, value);
	}

	inline static int32_t get_offset_of_OnIncompleteFrame_27() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___OnIncompleteFrame_27)); }
	inline Action_2_t3844780342 * get_OnIncompleteFrame_27() const { return ___OnIncompleteFrame_27; }
	inline Action_2_t3844780342 ** get_address_of_OnIncompleteFrame_27() { return &___OnIncompleteFrame_27; }
	inline void set_OnIncompleteFrame_27(Action_2_t3844780342 * value)
	{
		___OnIncompleteFrame_27 = value;
		Il2CppCodeGenWriteBarrier(&___OnIncompleteFrame_27, value);
	}

	inline static int32_t get_offset_of_OnClosed_28() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___OnClosed_28)); }
	inline Action_3_t2791643950 * get_OnClosed_28() const { return ___OnClosed_28; }
	inline Action_3_t2791643950 ** get_address_of_OnClosed_28() { return &___OnClosed_28; }
	inline void set_OnClosed_28(Action_3_t2791643950 * value)
	{
		___OnClosed_28 = value;
		Il2CppCodeGenWriteBarrier(&___OnClosed_28, value);
	}

	inline static int32_t get_offset_of_U3CPingFrequnecyU3Ek__BackingField_29() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___U3CPingFrequnecyU3Ek__BackingField_29)); }
	inline TimeSpan_t3430258949  get_U3CPingFrequnecyU3Ek__BackingField_29() const { return ___U3CPingFrequnecyU3Ek__BackingField_29; }
	inline TimeSpan_t3430258949 * get_address_of_U3CPingFrequnecyU3Ek__BackingField_29() { return &___U3CPingFrequnecyU3Ek__BackingField_29; }
	inline void set_U3CPingFrequnecyU3Ek__BackingField_29(TimeSpan_t3430258949  value)
	{
		___U3CPingFrequnecyU3Ek__BackingField_29 = value;
	}

	inline static int32_t get_offset_of_U3CMaxFragmentSizeU3Ek__BackingField_30() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___U3CMaxFragmentSizeU3Ek__BackingField_30)); }
	inline uint16_t get_U3CMaxFragmentSizeU3Ek__BackingField_30() const { return ___U3CMaxFragmentSizeU3Ek__BackingField_30; }
	inline uint16_t* get_address_of_U3CMaxFragmentSizeU3Ek__BackingField_30() { return &___U3CMaxFragmentSizeU3Ek__BackingField_30; }
	inline void set_U3CMaxFragmentSizeU3Ek__BackingField_30(uint16_t value)
	{
		___U3CMaxFragmentSizeU3Ek__BackingField_30 = value;
	}

	inline static int32_t get_offset_of_IncompleteFrames_31() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___IncompleteFrames_31)); }
	inline List_1_t4213362297 * get_IncompleteFrames_31() const { return ___IncompleteFrames_31; }
	inline List_1_t4213362297 ** get_address_of_IncompleteFrames_31() { return &___IncompleteFrames_31; }
	inline void set_IncompleteFrames_31(List_1_t4213362297 * value)
	{
		___IncompleteFrames_31 = value;
		Il2CppCodeGenWriteBarrier(&___IncompleteFrames_31, value);
	}

	inline static int32_t get_offset_of_CompletedFrames_32() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___CompletedFrames_32)); }
	inline List_1_t4213362297 * get_CompletedFrames_32() const { return ___CompletedFrames_32; }
	inline List_1_t4213362297 ** get_address_of_CompletedFrames_32() { return &___CompletedFrames_32; }
	inline void set_CompletedFrames_32(List_1_t4213362297 * value)
	{
		___CompletedFrames_32 = value;
		Il2CppCodeGenWriteBarrier(&___CompletedFrames_32, value);
	}

	inline static int32_t get_offset_of_CloseFrame_33() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___CloseFrame_33)); }
	inline WebSocketFrameReader_t549273869 * get_CloseFrame_33() const { return ___CloseFrame_33; }
	inline WebSocketFrameReader_t549273869 ** get_address_of_CloseFrame_33() { return &___CloseFrame_33; }
	inline void set_CloseFrame_33(WebSocketFrameReader_t549273869 * value)
	{
		___CloseFrame_33 = value;
		Il2CppCodeGenWriteBarrier(&___CloseFrame_33, value);
	}

	inline static int32_t get_offset_of_FrameLock_34() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___FrameLock_34)); }
	inline Il2CppObject * get_FrameLock_34() const { return ___FrameLock_34; }
	inline Il2CppObject ** get_address_of_FrameLock_34() { return &___FrameLock_34; }
	inline void set_FrameLock_34(Il2CppObject * value)
	{
		___FrameLock_34 = value;
		Il2CppCodeGenWriteBarrier(&___FrameLock_34, value);
	}

	inline static int32_t get_offset_of_SendLock_35() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___SendLock_35)); }
	inline Il2CppObject * get_SendLock_35() const { return ___SendLock_35; }
	inline Il2CppObject ** get_address_of_SendLock_35() { return &___SendLock_35; }
	inline void set_SendLock_35(Il2CppObject * value)
	{
		___SendLock_35 = value;
		Il2CppCodeGenWriteBarrier(&___SendLock_35, value);
	}

	inline static int32_t get_offset_of_closeSent_36() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___closeSent_36)); }
	inline bool get_closeSent_36() const { return ___closeSent_36; }
	inline bool* get_address_of_closeSent_36() { return &___closeSent_36; }
	inline void set_closeSent_36(bool value)
	{
		___closeSent_36 = value;
	}

	inline static int32_t get_offset_of_closed_37() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___closed_37)); }
	inline bool get_closed_37() const { return ___closed_37; }
	inline bool* get_address_of_closed_37() { return &___closed_37; }
	inline void set_closed_37(bool value)
	{
		___closed_37 = value;
	}

	inline static int32_t get_offset_of_lastPing_38() { return static_cast<int32_t>(offsetof(WebSocketResponse_t3376763264, ___lastPing_38)); }
	inline DateTime_t693205669  get_lastPing_38() const { return ___lastPing_38; }
	inline DateTime_t693205669 * get_address_of_lastPing_38() { return &___lastPing_38; }
	inline void set_lastPing_38(DateTime_t693205669  value)
	{
		___lastPing_38 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
