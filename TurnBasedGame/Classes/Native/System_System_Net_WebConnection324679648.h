#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Net_WebExceptionStatus1169373531.h"
#include "System_System_Net_ReadState657568301.h"

// System.Net.ServicePoint
struct ServicePoint_t2765344313;
// System.IO.Stream
struct Stream_t3255436806;
// System.Net.Sockets.Socket
struct Socket_t3821512045;
// System.Object
struct Il2CppObject;
// System.Threading.WaitCallback
struct WaitCallback_t2798937288;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.AsyncCallback
struct AsyncCallback_t163412349;
// System.EventHandler
struct EventHandler_t277755526;
// System.Net.WebConnection/AbortHelper
struct AbortHelper_t2895113041;
// System.Net.WebConnectionData
struct WebConnectionData_t3550260432;
// System.Net.ChunkStream
struct ChunkStream_t91719323;
// System.Collections.Queue
struct Queue_t1288490777;
// System.Net.HttpWebRequest
struct HttpWebRequest_t1951404513;
// System.Net.NetworkCredential
struct NetworkCredential_t1714133953;
// System.Exception
struct Exception_t1927440687;
// System.Type
struct Type_t;
// System.Reflection.PropertyInfo
struct PropertyInfo_t;
// System.Reflection.MethodInfo
struct MethodInfo_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.WebConnection
struct  WebConnection_t324679648  : public Il2CppObject
{
public:
	// System.Net.ServicePoint System.Net.WebConnection::sPoint
	ServicePoint_t2765344313 * ___sPoint_0;
	// System.IO.Stream System.Net.WebConnection::nstream
	Stream_t3255436806 * ___nstream_1;
	// System.Net.Sockets.Socket System.Net.WebConnection::socket
	Socket_t3821512045 * ___socket_2;
	// System.Object System.Net.WebConnection::socketLock
	Il2CppObject * ___socketLock_3;
	// System.Net.WebExceptionStatus System.Net.WebConnection::status
	int32_t ___status_4;
	// System.Threading.WaitCallback System.Net.WebConnection::initConn
	WaitCallback_t2798937288 * ___initConn_5;
	// System.Boolean System.Net.WebConnection::keepAlive
	bool ___keepAlive_6;
	// System.Byte[] System.Net.WebConnection::buffer
	ByteU5BU5D_t3397334013* ___buffer_7;
	// System.EventHandler System.Net.WebConnection::abortHandler
	EventHandler_t277755526 * ___abortHandler_9;
	// System.Net.WebConnection/AbortHelper System.Net.WebConnection::abortHelper
	AbortHelper_t2895113041 * ___abortHelper_10;
	// System.Net.ReadState System.Net.WebConnection::readState
	int32_t ___readState_11;
	// System.Net.WebConnectionData System.Net.WebConnection::Data
	WebConnectionData_t3550260432 * ___Data_12;
	// System.Boolean System.Net.WebConnection::chunkedRead
	bool ___chunkedRead_13;
	// System.Net.ChunkStream System.Net.WebConnection::chunkStream
	ChunkStream_t91719323 * ___chunkStream_14;
	// System.Collections.Queue System.Net.WebConnection::queue
	Queue_t1288490777 * ___queue_15;
	// System.Boolean System.Net.WebConnection::reused
	bool ___reused_16;
	// System.Int32 System.Net.WebConnection::position
	int32_t ___position_17;
	// System.Boolean System.Net.WebConnection::busy
	bool ___busy_18;
	// System.Net.HttpWebRequest System.Net.WebConnection::priority_request
	HttpWebRequest_t1951404513 * ___priority_request_19;
	// System.Net.NetworkCredential System.Net.WebConnection::ntlm_credentials
	NetworkCredential_t1714133953 * ___ntlm_credentials_20;
	// System.Boolean System.Net.WebConnection::ntlm_authenticated
	bool ___ntlm_authenticated_21;
	// System.Boolean System.Net.WebConnection::unsafe_sharing
	bool ___unsafe_sharing_22;
	// System.Boolean System.Net.WebConnection::ssl
	bool ___ssl_23;
	// System.Boolean System.Net.WebConnection::certsAvailable
	bool ___certsAvailable_24;
	// System.Exception System.Net.WebConnection::connect_exception
	Exception_t1927440687 * ___connect_exception_25;

public:
	inline static int32_t get_offset_of_sPoint_0() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___sPoint_0)); }
	inline ServicePoint_t2765344313 * get_sPoint_0() const { return ___sPoint_0; }
	inline ServicePoint_t2765344313 ** get_address_of_sPoint_0() { return &___sPoint_0; }
	inline void set_sPoint_0(ServicePoint_t2765344313 * value)
	{
		___sPoint_0 = value;
		Il2CppCodeGenWriteBarrier(&___sPoint_0, value);
	}

	inline static int32_t get_offset_of_nstream_1() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___nstream_1)); }
	inline Stream_t3255436806 * get_nstream_1() const { return ___nstream_1; }
	inline Stream_t3255436806 ** get_address_of_nstream_1() { return &___nstream_1; }
	inline void set_nstream_1(Stream_t3255436806 * value)
	{
		___nstream_1 = value;
		Il2CppCodeGenWriteBarrier(&___nstream_1, value);
	}

	inline static int32_t get_offset_of_socket_2() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___socket_2)); }
	inline Socket_t3821512045 * get_socket_2() const { return ___socket_2; }
	inline Socket_t3821512045 ** get_address_of_socket_2() { return &___socket_2; }
	inline void set_socket_2(Socket_t3821512045 * value)
	{
		___socket_2 = value;
		Il2CppCodeGenWriteBarrier(&___socket_2, value);
	}

	inline static int32_t get_offset_of_socketLock_3() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___socketLock_3)); }
	inline Il2CppObject * get_socketLock_3() const { return ___socketLock_3; }
	inline Il2CppObject ** get_address_of_socketLock_3() { return &___socketLock_3; }
	inline void set_socketLock_3(Il2CppObject * value)
	{
		___socketLock_3 = value;
		Il2CppCodeGenWriteBarrier(&___socketLock_3, value);
	}

	inline static int32_t get_offset_of_status_4() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___status_4)); }
	inline int32_t get_status_4() const { return ___status_4; }
	inline int32_t* get_address_of_status_4() { return &___status_4; }
	inline void set_status_4(int32_t value)
	{
		___status_4 = value;
	}

	inline static int32_t get_offset_of_initConn_5() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___initConn_5)); }
	inline WaitCallback_t2798937288 * get_initConn_5() const { return ___initConn_5; }
	inline WaitCallback_t2798937288 ** get_address_of_initConn_5() { return &___initConn_5; }
	inline void set_initConn_5(WaitCallback_t2798937288 * value)
	{
		___initConn_5 = value;
		Il2CppCodeGenWriteBarrier(&___initConn_5, value);
	}

	inline static int32_t get_offset_of_keepAlive_6() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___keepAlive_6)); }
	inline bool get_keepAlive_6() const { return ___keepAlive_6; }
	inline bool* get_address_of_keepAlive_6() { return &___keepAlive_6; }
	inline void set_keepAlive_6(bool value)
	{
		___keepAlive_6 = value;
	}

	inline static int32_t get_offset_of_buffer_7() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___buffer_7)); }
	inline ByteU5BU5D_t3397334013* get_buffer_7() const { return ___buffer_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_buffer_7() { return &___buffer_7; }
	inline void set_buffer_7(ByteU5BU5D_t3397334013* value)
	{
		___buffer_7 = value;
		Il2CppCodeGenWriteBarrier(&___buffer_7, value);
	}

	inline static int32_t get_offset_of_abortHandler_9() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___abortHandler_9)); }
	inline EventHandler_t277755526 * get_abortHandler_9() const { return ___abortHandler_9; }
	inline EventHandler_t277755526 ** get_address_of_abortHandler_9() { return &___abortHandler_9; }
	inline void set_abortHandler_9(EventHandler_t277755526 * value)
	{
		___abortHandler_9 = value;
		Il2CppCodeGenWriteBarrier(&___abortHandler_9, value);
	}

	inline static int32_t get_offset_of_abortHelper_10() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___abortHelper_10)); }
	inline AbortHelper_t2895113041 * get_abortHelper_10() const { return ___abortHelper_10; }
	inline AbortHelper_t2895113041 ** get_address_of_abortHelper_10() { return &___abortHelper_10; }
	inline void set_abortHelper_10(AbortHelper_t2895113041 * value)
	{
		___abortHelper_10 = value;
		Il2CppCodeGenWriteBarrier(&___abortHelper_10, value);
	}

	inline static int32_t get_offset_of_readState_11() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___readState_11)); }
	inline int32_t get_readState_11() const { return ___readState_11; }
	inline int32_t* get_address_of_readState_11() { return &___readState_11; }
	inline void set_readState_11(int32_t value)
	{
		___readState_11 = value;
	}

	inline static int32_t get_offset_of_Data_12() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___Data_12)); }
	inline WebConnectionData_t3550260432 * get_Data_12() const { return ___Data_12; }
	inline WebConnectionData_t3550260432 ** get_address_of_Data_12() { return &___Data_12; }
	inline void set_Data_12(WebConnectionData_t3550260432 * value)
	{
		___Data_12 = value;
		Il2CppCodeGenWriteBarrier(&___Data_12, value);
	}

	inline static int32_t get_offset_of_chunkedRead_13() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___chunkedRead_13)); }
	inline bool get_chunkedRead_13() const { return ___chunkedRead_13; }
	inline bool* get_address_of_chunkedRead_13() { return &___chunkedRead_13; }
	inline void set_chunkedRead_13(bool value)
	{
		___chunkedRead_13 = value;
	}

	inline static int32_t get_offset_of_chunkStream_14() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___chunkStream_14)); }
	inline ChunkStream_t91719323 * get_chunkStream_14() const { return ___chunkStream_14; }
	inline ChunkStream_t91719323 ** get_address_of_chunkStream_14() { return &___chunkStream_14; }
	inline void set_chunkStream_14(ChunkStream_t91719323 * value)
	{
		___chunkStream_14 = value;
		Il2CppCodeGenWriteBarrier(&___chunkStream_14, value);
	}

	inline static int32_t get_offset_of_queue_15() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___queue_15)); }
	inline Queue_t1288490777 * get_queue_15() const { return ___queue_15; }
	inline Queue_t1288490777 ** get_address_of_queue_15() { return &___queue_15; }
	inline void set_queue_15(Queue_t1288490777 * value)
	{
		___queue_15 = value;
		Il2CppCodeGenWriteBarrier(&___queue_15, value);
	}

	inline static int32_t get_offset_of_reused_16() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___reused_16)); }
	inline bool get_reused_16() const { return ___reused_16; }
	inline bool* get_address_of_reused_16() { return &___reused_16; }
	inline void set_reused_16(bool value)
	{
		___reused_16 = value;
	}

	inline static int32_t get_offset_of_position_17() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___position_17)); }
	inline int32_t get_position_17() const { return ___position_17; }
	inline int32_t* get_address_of_position_17() { return &___position_17; }
	inline void set_position_17(int32_t value)
	{
		___position_17 = value;
	}

	inline static int32_t get_offset_of_busy_18() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___busy_18)); }
	inline bool get_busy_18() const { return ___busy_18; }
	inline bool* get_address_of_busy_18() { return &___busy_18; }
	inline void set_busy_18(bool value)
	{
		___busy_18 = value;
	}

	inline static int32_t get_offset_of_priority_request_19() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___priority_request_19)); }
	inline HttpWebRequest_t1951404513 * get_priority_request_19() const { return ___priority_request_19; }
	inline HttpWebRequest_t1951404513 ** get_address_of_priority_request_19() { return &___priority_request_19; }
	inline void set_priority_request_19(HttpWebRequest_t1951404513 * value)
	{
		___priority_request_19 = value;
		Il2CppCodeGenWriteBarrier(&___priority_request_19, value);
	}

	inline static int32_t get_offset_of_ntlm_credentials_20() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___ntlm_credentials_20)); }
	inline NetworkCredential_t1714133953 * get_ntlm_credentials_20() const { return ___ntlm_credentials_20; }
	inline NetworkCredential_t1714133953 ** get_address_of_ntlm_credentials_20() { return &___ntlm_credentials_20; }
	inline void set_ntlm_credentials_20(NetworkCredential_t1714133953 * value)
	{
		___ntlm_credentials_20 = value;
		Il2CppCodeGenWriteBarrier(&___ntlm_credentials_20, value);
	}

	inline static int32_t get_offset_of_ntlm_authenticated_21() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___ntlm_authenticated_21)); }
	inline bool get_ntlm_authenticated_21() const { return ___ntlm_authenticated_21; }
	inline bool* get_address_of_ntlm_authenticated_21() { return &___ntlm_authenticated_21; }
	inline void set_ntlm_authenticated_21(bool value)
	{
		___ntlm_authenticated_21 = value;
	}

	inline static int32_t get_offset_of_unsafe_sharing_22() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___unsafe_sharing_22)); }
	inline bool get_unsafe_sharing_22() const { return ___unsafe_sharing_22; }
	inline bool* get_address_of_unsafe_sharing_22() { return &___unsafe_sharing_22; }
	inline void set_unsafe_sharing_22(bool value)
	{
		___unsafe_sharing_22 = value;
	}

	inline static int32_t get_offset_of_ssl_23() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___ssl_23)); }
	inline bool get_ssl_23() const { return ___ssl_23; }
	inline bool* get_address_of_ssl_23() { return &___ssl_23; }
	inline void set_ssl_23(bool value)
	{
		___ssl_23 = value;
	}

	inline static int32_t get_offset_of_certsAvailable_24() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___certsAvailable_24)); }
	inline bool get_certsAvailable_24() const { return ___certsAvailable_24; }
	inline bool* get_address_of_certsAvailable_24() { return &___certsAvailable_24; }
	inline void set_certsAvailable_24(bool value)
	{
		___certsAvailable_24 = value;
	}

	inline static int32_t get_offset_of_connect_exception_25() { return static_cast<int32_t>(offsetof(WebConnection_t324679648, ___connect_exception_25)); }
	inline Exception_t1927440687 * get_connect_exception_25() const { return ___connect_exception_25; }
	inline Exception_t1927440687 ** get_address_of_connect_exception_25() { return &___connect_exception_25; }
	inline void set_connect_exception_25(Exception_t1927440687 * value)
	{
		___connect_exception_25 = value;
		Il2CppCodeGenWriteBarrier(&___connect_exception_25, value);
	}
};

struct WebConnection_t324679648_StaticFields
{
public:
	// System.AsyncCallback System.Net.WebConnection::readDoneDelegate
	AsyncCallback_t163412349 * ___readDoneDelegate_8;
	// System.Object System.Net.WebConnection::classLock
	Il2CppObject * ___classLock_26;
	// System.Type System.Net.WebConnection::sslStream
	Type_t * ___sslStream_27;
	// System.Reflection.PropertyInfo System.Net.WebConnection::piClient
	PropertyInfo_t * ___piClient_28;
	// System.Reflection.PropertyInfo System.Net.WebConnection::piServer
	PropertyInfo_t * ___piServer_29;
	// System.Reflection.PropertyInfo System.Net.WebConnection::piTrustFailure
	PropertyInfo_t * ___piTrustFailure_30;
	// System.Reflection.MethodInfo System.Net.WebConnection::method_GetSecurityPolicyFromNonMainThread
	MethodInfo_t * ___method_GetSecurityPolicyFromNonMainThread_31;

public:
	inline static int32_t get_offset_of_readDoneDelegate_8() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___readDoneDelegate_8)); }
	inline AsyncCallback_t163412349 * get_readDoneDelegate_8() const { return ___readDoneDelegate_8; }
	inline AsyncCallback_t163412349 ** get_address_of_readDoneDelegate_8() { return &___readDoneDelegate_8; }
	inline void set_readDoneDelegate_8(AsyncCallback_t163412349 * value)
	{
		___readDoneDelegate_8 = value;
		Il2CppCodeGenWriteBarrier(&___readDoneDelegate_8, value);
	}

	inline static int32_t get_offset_of_classLock_26() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___classLock_26)); }
	inline Il2CppObject * get_classLock_26() const { return ___classLock_26; }
	inline Il2CppObject ** get_address_of_classLock_26() { return &___classLock_26; }
	inline void set_classLock_26(Il2CppObject * value)
	{
		___classLock_26 = value;
		Il2CppCodeGenWriteBarrier(&___classLock_26, value);
	}

	inline static int32_t get_offset_of_sslStream_27() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___sslStream_27)); }
	inline Type_t * get_sslStream_27() const { return ___sslStream_27; }
	inline Type_t ** get_address_of_sslStream_27() { return &___sslStream_27; }
	inline void set_sslStream_27(Type_t * value)
	{
		___sslStream_27 = value;
		Il2CppCodeGenWriteBarrier(&___sslStream_27, value);
	}

	inline static int32_t get_offset_of_piClient_28() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___piClient_28)); }
	inline PropertyInfo_t * get_piClient_28() const { return ___piClient_28; }
	inline PropertyInfo_t ** get_address_of_piClient_28() { return &___piClient_28; }
	inline void set_piClient_28(PropertyInfo_t * value)
	{
		___piClient_28 = value;
		Il2CppCodeGenWriteBarrier(&___piClient_28, value);
	}

	inline static int32_t get_offset_of_piServer_29() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___piServer_29)); }
	inline PropertyInfo_t * get_piServer_29() const { return ___piServer_29; }
	inline PropertyInfo_t ** get_address_of_piServer_29() { return &___piServer_29; }
	inline void set_piServer_29(PropertyInfo_t * value)
	{
		___piServer_29 = value;
		Il2CppCodeGenWriteBarrier(&___piServer_29, value);
	}

	inline static int32_t get_offset_of_piTrustFailure_30() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___piTrustFailure_30)); }
	inline PropertyInfo_t * get_piTrustFailure_30() const { return ___piTrustFailure_30; }
	inline PropertyInfo_t ** get_address_of_piTrustFailure_30() { return &___piTrustFailure_30; }
	inline void set_piTrustFailure_30(PropertyInfo_t * value)
	{
		___piTrustFailure_30 = value;
		Il2CppCodeGenWriteBarrier(&___piTrustFailure_30, value);
	}

	inline static int32_t get_offset_of_method_GetSecurityPolicyFromNonMainThread_31() { return static_cast<int32_t>(offsetof(WebConnection_t324679648_StaticFields, ___method_GetSecurityPolicyFromNonMainThread_31)); }
	inline MethodInfo_t * get_method_GetSecurityPolicyFromNonMainThread_31() const { return ___method_GetSecurityPolicyFromNonMainThread_31; }
	inline MethodInfo_t ** get_address_of_method_GetSecurityPolicyFromNonMainThread_31() { return &___method_GetSecurityPolicyFromNonMainThread_31; }
	inline void set_method_GetSecurityPolicyFromNonMainThread_31(MethodInfo_t * value)
	{
		___method_GetSecurityPolicyFromNonMainThread_31 = value;
		Il2CppCodeGenWriteBarrier(&___method_GetSecurityPolicyFromNonMainThread_31, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
