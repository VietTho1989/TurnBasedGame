#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Net_WebRequest1365124353.h"
#include "System_System_Net_FtpWebRequest_RequestState4256633122.h"

// System.Uri
struct Uri_t19570940;
// System.String
struct String_t;
// System.Net.ServicePoint
struct ServicePoint_t2765344313;
// System.IO.Stream
struct Stream_t3255436806;
// System.IO.StreamReader
struct StreamReader_t2360341767;
// System.Net.NetworkCredential
struct NetworkCredential_t1714133953;
// System.Net.IPHostEntry
struct IPHostEntry_t994738509;
// System.Net.IPEndPoint
struct IPEndPoint_t2615413766;
// System.Net.IWebProxy
struct IWebProxy_t3916853445;
// System.Object
struct Il2CppObject;
// System.Net.FtpAsyncResult
struct FtpAsyncResult_t770082413;
// System.Net.FtpWebResponse
struct FtpWebResponse_t2609078769;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.Net.Security.RemoteCertificateValidationCallback
struct RemoteCertificateValidationCallback_t2756269959;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.FtpWebRequest
struct  FtpWebRequest_t3120721823  : public WebRequest_t1365124353
{
public:
	// System.Uri System.Net.FtpWebRequest::requestUri
	Uri_t19570940 * ___requestUri_6;
	// System.String System.Net.FtpWebRequest::file_name
	String_t* ___file_name_7;
	// System.Net.ServicePoint System.Net.FtpWebRequest::servicePoint
	ServicePoint_t2765344313 * ___servicePoint_8;
	// System.IO.Stream System.Net.FtpWebRequest::origDataStream
	Stream_t3255436806 * ___origDataStream_9;
	// System.IO.Stream System.Net.FtpWebRequest::dataStream
	Stream_t3255436806 * ___dataStream_10;
	// System.IO.Stream System.Net.FtpWebRequest::controlStream
	Stream_t3255436806 * ___controlStream_11;
	// System.IO.StreamReader System.Net.FtpWebRequest::controlReader
	StreamReader_t2360341767 * ___controlReader_12;
	// System.Net.NetworkCredential System.Net.FtpWebRequest::credentials
	NetworkCredential_t1714133953 * ___credentials_13;
	// System.Net.IPHostEntry System.Net.FtpWebRequest::hostEntry
	IPHostEntry_t994738509 * ___hostEntry_14;
	// System.Net.IPEndPoint System.Net.FtpWebRequest::localEndPoint
	IPEndPoint_t2615413766 * ___localEndPoint_15;
	// System.Net.IWebProxy System.Net.FtpWebRequest::proxy
	Il2CppObject * ___proxy_16;
	// System.Int32 System.Net.FtpWebRequest::timeout
	int32_t ___timeout_17;
	// System.Int32 System.Net.FtpWebRequest::rwTimeout
	int32_t ___rwTimeout_18;
	// System.Int64 System.Net.FtpWebRequest::offset
	int64_t ___offset_19;
	// System.Boolean System.Net.FtpWebRequest::binary
	bool ___binary_20;
	// System.Boolean System.Net.FtpWebRequest::enableSsl
	bool ___enableSsl_21;
	// System.Boolean System.Net.FtpWebRequest::usePassive
	bool ___usePassive_22;
	// System.Boolean System.Net.FtpWebRequest::keepAlive
	bool ___keepAlive_23;
	// System.String System.Net.FtpWebRequest::method
	String_t* ___method_24;
	// System.String System.Net.FtpWebRequest::renameTo
	String_t* ___renameTo_25;
	// System.Object System.Net.FtpWebRequest::locker
	Il2CppObject * ___locker_26;
	// System.Net.FtpWebRequest/RequestState System.Net.FtpWebRequest::requestState
	int32_t ___requestState_27;
	// System.Net.FtpAsyncResult System.Net.FtpWebRequest::asyncResult
	FtpAsyncResult_t770082413 * ___asyncResult_28;
	// System.Net.FtpWebResponse System.Net.FtpWebRequest::ftpResponse
	FtpWebResponse_t2609078769 * ___ftpResponse_29;
	// System.IO.Stream System.Net.FtpWebRequest::requestStream
	Stream_t3255436806 * ___requestStream_30;
	// System.String System.Net.FtpWebRequest::initial_path
	String_t* ___initial_path_31;
	// System.Net.Security.RemoteCertificateValidationCallback System.Net.FtpWebRequest::callback
	RemoteCertificateValidationCallback_t2756269959 * ___callback_33;

public:
	inline static int32_t get_offset_of_requestUri_6() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___requestUri_6)); }
	inline Uri_t19570940 * get_requestUri_6() const { return ___requestUri_6; }
	inline Uri_t19570940 ** get_address_of_requestUri_6() { return &___requestUri_6; }
	inline void set_requestUri_6(Uri_t19570940 * value)
	{
		___requestUri_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestUri_6, value);
	}

	inline static int32_t get_offset_of_file_name_7() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___file_name_7)); }
	inline String_t* get_file_name_7() const { return ___file_name_7; }
	inline String_t** get_address_of_file_name_7() { return &___file_name_7; }
	inline void set_file_name_7(String_t* value)
	{
		___file_name_7 = value;
		Il2CppCodeGenWriteBarrier(&___file_name_7, value);
	}

	inline static int32_t get_offset_of_servicePoint_8() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___servicePoint_8)); }
	inline ServicePoint_t2765344313 * get_servicePoint_8() const { return ___servicePoint_8; }
	inline ServicePoint_t2765344313 ** get_address_of_servicePoint_8() { return &___servicePoint_8; }
	inline void set_servicePoint_8(ServicePoint_t2765344313 * value)
	{
		___servicePoint_8 = value;
		Il2CppCodeGenWriteBarrier(&___servicePoint_8, value);
	}

	inline static int32_t get_offset_of_origDataStream_9() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___origDataStream_9)); }
	inline Stream_t3255436806 * get_origDataStream_9() const { return ___origDataStream_9; }
	inline Stream_t3255436806 ** get_address_of_origDataStream_9() { return &___origDataStream_9; }
	inline void set_origDataStream_9(Stream_t3255436806 * value)
	{
		___origDataStream_9 = value;
		Il2CppCodeGenWriteBarrier(&___origDataStream_9, value);
	}

	inline static int32_t get_offset_of_dataStream_10() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___dataStream_10)); }
	inline Stream_t3255436806 * get_dataStream_10() const { return ___dataStream_10; }
	inline Stream_t3255436806 ** get_address_of_dataStream_10() { return &___dataStream_10; }
	inline void set_dataStream_10(Stream_t3255436806 * value)
	{
		___dataStream_10 = value;
		Il2CppCodeGenWriteBarrier(&___dataStream_10, value);
	}

	inline static int32_t get_offset_of_controlStream_11() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___controlStream_11)); }
	inline Stream_t3255436806 * get_controlStream_11() const { return ___controlStream_11; }
	inline Stream_t3255436806 ** get_address_of_controlStream_11() { return &___controlStream_11; }
	inline void set_controlStream_11(Stream_t3255436806 * value)
	{
		___controlStream_11 = value;
		Il2CppCodeGenWriteBarrier(&___controlStream_11, value);
	}

	inline static int32_t get_offset_of_controlReader_12() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___controlReader_12)); }
	inline StreamReader_t2360341767 * get_controlReader_12() const { return ___controlReader_12; }
	inline StreamReader_t2360341767 ** get_address_of_controlReader_12() { return &___controlReader_12; }
	inline void set_controlReader_12(StreamReader_t2360341767 * value)
	{
		___controlReader_12 = value;
		Il2CppCodeGenWriteBarrier(&___controlReader_12, value);
	}

	inline static int32_t get_offset_of_credentials_13() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___credentials_13)); }
	inline NetworkCredential_t1714133953 * get_credentials_13() const { return ___credentials_13; }
	inline NetworkCredential_t1714133953 ** get_address_of_credentials_13() { return &___credentials_13; }
	inline void set_credentials_13(NetworkCredential_t1714133953 * value)
	{
		___credentials_13 = value;
		Il2CppCodeGenWriteBarrier(&___credentials_13, value);
	}

	inline static int32_t get_offset_of_hostEntry_14() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___hostEntry_14)); }
	inline IPHostEntry_t994738509 * get_hostEntry_14() const { return ___hostEntry_14; }
	inline IPHostEntry_t994738509 ** get_address_of_hostEntry_14() { return &___hostEntry_14; }
	inline void set_hostEntry_14(IPHostEntry_t994738509 * value)
	{
		___hostEntry_14 = value;
		Il2CppCodeGenWriteBarrier(&___hostEntry_14, value);
	}

	inline static int32_t get_offset_of_localEndPoint_15() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___localEndPoint_15)); }
	inline IPEndPoint_t2615413766 * get_localEndPoint_15() const { return ___localEndPoint_15; }
	inline IPEndPoint_t2615413766 ** get_address_of_localEndPoint_15() { return &___localEndPoint_15; }
	inline void set_localEndPoint_15(IPEndPoint_t2615413766 * value)
	{
		___localEndPoint_15 = value;
		Il2CppCodeGenWriteBarrier(&___localEndPoint_15, value);
	}

	inline static int32_t get_offset_of_proxy_16() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___proxy_16)); }
	inline Il2CppObject * get_proxy_16() const { return ___proxy_16; }
	inline Il2CppObject ** get_address_of_proxy_16() { return &___proxy_16; }
	inline void set_proxy_16(Il2CppObject * value)
	{
		___proxy_16 = value;
		Il2CppCodeGenWriteBarrier(&___proxy_16, value);
	}

	inline static int32_t get_offset_of_timeout_17() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___timeout_17)); }
	inline int32_t get_timeout_17() const { return ___timeout_17; }
	inline int32_t* get_address_of_timeout_17() { return &___timeout_17; }
	inline void set_timeout_17(int32_t value)
	{
		___timeout_17 = value;
	}

	inline static int32_t get_offset_of_rwTimeout_18() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___rwTimeout_18)); }
	inline int32_t get_rwTimeout_18() const { return ___rwTimeout_18; }
	inline int32_t* get_address_of_rwTimeout_18() { return &___rwTimeout_18; }
	inline void set_rwTimeout_18(int32_t value)
	{
		___rwTimeout_18 = value;
	}

	inline static int32_t get_offset_of_offset_19() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___offset_19)); }
	inline int64_t get_offset_19() const { return ___offset_19; }
	inline int64_t* get_address_of_offset_19() { return &___offset_19; }
	inline void set_offset_19(int64_t value)
	{
		___offset_19 = value;
	}

	inline static int32_t get_offset_of_binary_20() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___binary_20)); }
	inline bool get_binary_20() const { return ___binary_20; }
	inline bool* get_address_of_binary_20() { return &___binary_20; }
	inline void set_binary_20(bool value)
	{
		___binary_20 = value;
	}

	inline static int32_t get_offset_of_enableSsl_21() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___enableSsl_21)); }
	inline bool get_enableSsl_21() const { return ___enableSsl_21; }
	inline bool* get_address_of_enableSsl_21() { return &___enableSsl_21; }
	inline void set_enableSsl_21(bool value)
	{
		___enableSsl_21 = value;
	}

	inline static int32_t get_offset_of_usePassive_22() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___usePassive_22)); }
	inline bool get_usePassive_22() const { return ___usePassive_22; }
	inline bool* get_address_of_usePassive_22() { return &___usePassive_22; }
	inline void set_usePassive_22(bool value)
	{
		___usePassive_22 = value;
	}

	inline static int32_t get_offset_of_keepAlive_23() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___keepAlive_23)); }
	inline bool get_keepAlive_23() const { return ___keepAlive_23; }
	inline bool* get_address_of_keepAlive_23() { return &___keepAlive_23; }
	inline void set_keepAlive_23(bool value)
	{
		___keepAlive_23 = value;
	}

	inline static int32_t get_offset_of_method_24() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___method_24)); }
	inline String_t* get_method_24() const { return ___method_24; }
	inline String_t** get_address_of_method_24() { return &___method_24; }
	inline void set_method_24(String_t* value)
	{
		___method_24 = value;
		Il2CppCodeGenWriteBarrier(&___method_24, value);
	}

	inline static int32_t get_offset_of_renameTo_25() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___renameTo_25)); }
	inline String_t* get_renameTo_25() const { return ___renameTo_25; }
	inline String_t** get_address_of_renameTo_25() { return &___renameTo_25; }
	inline void set_renameTo_25(String_t* value)
	{
		___renameTo_25 = value;
		Il2CppCodeGenWriteBarrier(&___renameTo_25, value);
	}

	inline static int32_t get_offset_of_locker_26() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___locker_26)); }
	inline Il2CppObject * get_locker_26() const { return ___locker_26; }
	inline Il2CppObject ** get_address_of_locker_26() { return &___locker_26; }
	inline void set_locker_26(Il2CppObject * value)
	{
		___locker_26 = value;
		Il2CppCodeGenWriteBarrier(&___locker_26, value);
	}

	inline static int32_t get_offset_of_requestState_27() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___requestState_27)); }
	inline int32_t get_requestState_27() const { return ___requestState_27; }
	inline int32_t* get_address_of_requestState_27() { return &___requestState_27; }
	inline void set_requestState_27(int32_t value)
	{
		___requestState_27 = value;
	}

	inline static int32_t get_offset_of_asyncResult_28() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___asyncResult_28)); }
	inline FtpAsyncResult_t770082413 * get_asyncResult_28() const { return ___asyncResult_28; }
	inline FtpAsyncResult_t770082413 ** get_address_of_asyncResult_28() { return &___asyncResult_28; }
	inline void set_asyncResult_28(FtpAsyncResult_t770082413 * value)
	{
		___asyncResult_28 = value;
		Il2CppCodeGenWriteBarrier(&___asyncResult_28, value);
	}

	inline static int32_t get_offset_of_ftpResponse_29() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___ftpResponse_29)); }
	inline FtpWebResponse_t2609078769 * get_ftpResponse_29() const { return ___ftpResponse_29; }
	inline FtpWebResponse_t2609078769 ** get_address_of_ftpResponse_29() { return &___ftpResponse_29; }
	inline void set_ftpResponse_29(FtpWebResponse_t2609078769 * value)
	{
		___ftpResponse_29 = value;
		Il2CppCodeGenWriteBarrier(&___ftpResponse_29, value);
	}

	inline static int32_t get_offset_of_requestStream_30() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___requestStream_30)); }
	inline Stream_t3255436806 * get_requestStream_30() const { return ___requestStream_30; }
	inline Stream_t3255436806 ** get_address_of_requestStream_30() { return &___requestStream_30; }
	inline void set_requestStream_30(Stream_t3255436806 * value)
	{
		___requestStream_30 = value;
		Il2CppCodeGenWriteBarrier(&___requestStream_30, value);
	}

	inline static int32_t get_offset_of_initial_path_31() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___initial_path_31)); }
	inline String_t* get_initial_path_31() const { return ___initial_path_31; }
	inline String_t** get_address_of_initial_path_31() { return &___initial_path_31; }
	inline void set_initial_path_31(String_t* value)
	{
		___initial_path_31 = value;
		Il2CppCodeGenWriteBarrier(&___initial_path_31, value);
	}

	inline static int32_t get_offset_of_callback_33() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823, ___callback_33)); }
	inline RemoteCertificateValidationCallback_t2756269959 * get_callback_33() const { return ___callback_33; }
	inline RemoteCertificateValidationCallback_t2756269959 ** get_address_of_callback_33() { return &___callback_33; }
	inline void set_callback_33(RemoteCertificateValidationCallback_t2756269959 * value)
	{
		___callback_33 = value;
		Il2CppCodeGenWriteBarrier(&___callback_33, value);
	}
};

struct FtpWebRequest_t3120721823_StaticFields
{
public:
	// System.String[] System.Net.FtpWebRequest::supportedCommands
	StringU5BU5D_t1642385972* ___supportedCommands_32;
	// System.Net.Security.RemoteCertificateValidationCallback System.Net.FtpWebRequest::<>f__am$cache1C
	RemoteCertificateValidationCallback_t2756269959 * ___U3CU3Ef__amU24cache1C_34;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Net.FtpWebRequest::<>f__switch$mapA
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24mapA_35;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Net.FtpWebRequest::<>f__switch$mapB
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24mapB_36;

public:
	inline static int32_t get_offset_of_supportedCommands_32() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823_StaticFields, ___supportedCommands_32)); }
	inline StringU5BU5D_t1642385972* get_supportedCommands_32() const { return ___supportedCommands_32; }
	inline StringU5BU5D_t1642385972** get_address_of_supportedCommands_32() { return &___supportedCommands_32; }
	inline void set_supportedCommands_32(StringU5BU5D_t1642385972* value)
	{
		___supportedCommands_32 = value;
		Il2CppCodeGenWriteBarrier(&___supportedCommands_32, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1C_34() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823_StaticFields, ___U3CU3Ef__amU24cache1C_34)); }
	inline RemoteCertificateValidationCallback_t2756269959 * get_U3CU3Ef__amU24cache1C_34() const { return ___U3CU3Ef__amU24cache1C_34; }
	inline RemoteCertificateValidationCallback_t2756269959 ** get_address_of_U3CU3Ef__amU24cache1C_34() { return &___U3CU3Ef__amU24cache1C_34; }
	inline void set_U3CU3Ef__amU24cache1C_34(RemoteCertificateValidationCallback_t2756269959 * value)
	{
		___U3CU3Ef__amU24cache1C_34 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1C_34, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24mapA_35() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823_StaticFields, ___U3CU3Ef__switchU24mapA_35)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24mapA_35() const { return ___U3CU3Ef__switchU24mapA_35; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24mapA_35() { return &___U3CU3Ef__switchU24mapA_35; }
	inline void set_U3CU3Ef__switchU24mapA_35(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24mapA_35 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24mapA_35, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24mapB_36() { return static_cast<int32_t>(offsetof(FtpWebRequest_t3120721823_StaticFields, ___U3CU3Ef__switchU24mapB_36)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24mapB_36() const { return ___U3CU3Ef__switchU24mapB_36; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24mapB_36() { return &___U3CU3Ef__switchU24mapB_36; }
	inline void set_U3CU3Ef__switchU24mapB_36(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24mapB_36 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24mapB_36, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
