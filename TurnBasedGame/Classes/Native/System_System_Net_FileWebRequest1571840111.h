#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Net_WebRequest1365124353.h"
#include "mscorlib_System_IO_FileAccess4282042064.h"

// System.Uri
struct Uri_t19570940;
// System.Net.WebHeaderCollection
struct WebHeaderCollection_t3028142837;
// System.Net.ICredentials
struct ICredentials_t3855617113;
// System.String
struct String_t;
// System.Net.IWebProxy
struct IWebProxy_t3916853445;
// System.Net.FileWebResponse
struct FileWebResponse_t1934981865;
// System.Threading.AutoResetEvent
struct AutoResetEvent_t15112628;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.FileWebRequest
struct  FileWebRequest_t1571840111  : public WebRequest_t1365124353
{
public:
	// System.Uri System.Net.FileWebRequest::uri
	Uri_t19570940 * ___uri_6;
	// System.Net.WebHeaderCollection System.Net.FileWebRequest::webHeaders
	WebHeaderCollection_t3028142837 * ___webHeaders_7;
	// System.Net.ICredentials System.Net.FileWebRequest::credentials
	Il2CppObject * ___credentials_8;
	// System.String System.Net.FileWebRequest::connectionGroup
	String_t* ___connectionGroup_9;
	// System.Int64 System.Net.FileWebRequest::contentLength
	int64_t ___contentLength_10;
	// System.IO.FileAccess System.Net.FileWebRequest::fileAccess
	int32_t ___fileAccess_11;
	// System.String System.Net.FileWebRequest::method
	String_t* ___method_12;
	// System.Net.IWebProxy System.Net.FileWebRequest::proxy
	Il2CppObject * ___proxy_13;
	// System.Boolean System.Net.FileWebRequest::preAuthenticate
	bool ___preAuthenticate_14;
	// System.Int32 System.Net.FileWebRequest::timeout
	int32_t ___timeout_15;
	// System.Net.FileWebResponse System.Net.FileWebRequest::webResponse
	FileWebResponse_t1934981865 * ___webResponse_16;
	// System.Threading.AutoResetEvent System.Net.FileWebRequest::requestEndEvent
	AutoResetEvent_t15112628 * ___requestEndEvent_17;
	// System.Boolean System.Net.FileWebRequest::requesting
	bool ___requesting_18;
	// System.Boolean System.Net.FileWebRequest::asyncResponding
	bool ___asyncResponding_19;

public:
	inline static int32_t get_offset_of_uri_6() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___uri_6)); }
	inline Uri_t19570940 * get_uri_6() const { return ___uri_6; }
	inline Uri_t19570940 ** get_address_of_uri_6() { return &___uri_6; }
	inline void set_uri_6(Uri_t19570940 * value)
	{
		___uri_6 = value;
		Il2CppCodeGenWriteBarrier(&___uri_6, value);
	}

	inline static int32_t get_offset_of_webHeaders_7() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___webHeaders_7)); }
	inline WebHeaderCollection_t3028142837 * get_webHeaders_7() const { return ___webHeaders_7; }
	inline WebHeaderCollection_t3028142837 ** get_address_of_webHeaders_7() { return &___webHeaders_7; }
	inline void set_webHeaders_7(WebHeaderCollection_t3028142837 * value)
	{
		___webHeaders_7 = value;
		Il2CppCodeGenWriteBarrier(&___webHeaders_7, value);
	}

	inline static int32_t get_offset_of_credentials_8() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___credentials_8)); }
	inline Il2CppObject * get_credentials_8() const { return ___credentials_8; }
	inline Il2CppObject ** get_address_of_credentials_8() { return &___credentials_8; }
	inline void set_credentials_8(Il2CppObject * value)
	{
		___credentials_8 = value;
		Il2CppCodeGenWriteBarrier(&___credentials_8, value);
	}

	inline static int32_t get_offset_of_connectionGroup_9() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___connectionGroup_9)); }
	inline String_t* get_connectionGroup_9() const { return ___connectionGroup_9; }
	inline String_t** get_address_of_connectionGroup_9() { return &___connectionGroup_9; }
	inline void set_connectionGroup_9(String_t* value)
	{
		___connectionGroup_9 = value;
		Il2CppCodeGenWriteBarrier(&___connectionGroup_9, value);
	}

	inline static int32_t get_offset_of_contentLength_10() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___contentLength_10)); }
	inline int64_t get_contentLength_10() const { return ___contentLength_10; }
	inline int64_t* get_address_of_contentLength_10() { return &___contentLength_10; }
	inline void set_contentLength_10(int64_t value)
	{
		___contentLength_10 = value;
	}

	inline static int32_t get_offset_of_fileAccess_11() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___fileAccess_11)); }
	inline int32_t get_fileAccess_11() const { return ___fileAccess_11; }
	inline int32_t* get_address_of_fileAccess_11() { return &___fileAccess_11; }
	inline void set_fileAccess_11(int32_t value)
	{
		___fileAccess_11 = value;
	}

	inline static int32_t get_offset_of_method_12() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___method_12)); }
	inline String_t* get_method_12() const { return ___method_12; }
	inline String_t** get_address_of_method_12() { return &___method_12; }
	inline void set_method_12(String_t* value)
	{
		___method_12 = value;
		Il2CppCodeGenWriteBarrier(&___method_12, value);
	}

	inline static int32_t get_offset_of_proxy_13() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___proxy_13)); }
	inline Il2CppObject * get_proxy_13() const { return ___proxy_13; }
	inline Il2CppObject ** get_address_of_proxy_13() { return &___proxy_13; }
	inline void set_proxy_13(Il2CppObject * value)
	{
		___proxy_13 = value;
		Il2CppCodeGenWriteBarrier(&___proxy_13, value);
	}

	inline static int32_t get_offset_of_preAuthenticate_14() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___preAuthenticate_14)); }
	inline bool get_preAuthenticate_14() const { return ___preAuthenticate_14; }
	inline bool* get_address_of_preAuthenticate_14() { return &___preAuthenticate_14; }
	inline void set_preAuthenticate_14(bool value)
	{
		___preAuthenticate_14 = value;
	}

	inline static int32_t get_offset_of_timeout_15() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___timeout_15)); }
	inline int32_t get_timeout_15() const { return ___timeout_15; }
	inline int32_t* get_address_of_timeout_15() { return &___timeout_15; }
	inline void set_timeout_15(int32_t value)
	{
		___timeout_15 = value;
	}

	inline static int32_t get_offset_of_webResponse_16() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___webResponse_16)); }
	inline FileWebResponse_t1934981865 * get_webResponse_16() const { return ___webResponse_16; }
	inline FileWebResponse_t1934981865 ** get_address_of_webResponse_16() { return &___webResponse_16; }
	inline void set_webResponse_16(FileWebResponse_t1934981865 * value)
	{
		___webResponse_16 = value;
		Il2CppCodeGenWriteBarrier(&___webResponse_16, value);
	}

	inline static int32_t get_offset_of_requestEndEvent_17() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___requestEndEvent_17)); }
	inline AutoResetEvent_t15112628 * get_requestEndEvent_17() const { return ___requestEndEvent_17; }
	inline AutoResetEvent_t15112628 ** get_address_of_requestEndEvent_17() { return &___requestEndEvent_17; }
	inline void set_requestEndEvent_17(AutoResetEvent_t15112628 * value)
	{
		___requestEndEvent_17 = value;
		Il2CppCodeGenWriteBarrier(&___requestEndEvent_17, value);
	}

	inline static int32_t get_offset_of_requesting_18() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___requesting_18)); }
	inline bool get_requesting_18() const { return ___requesting_18; }
	inline bool* get_address_of_requesting_18() { return &___requesting_18; }
	inline void set_requesting_18(bool value)
	{
		___requesting_18 = value;
	}

	inline static int32_t get_offset_of_asyncResponding_19() { return static_cast<int32_t>(offsetof(FileWebRequest_t1571840111, ___asyncResponding_19)); }
	inline bool get_asyncResponding_19() const { return ___asyncResponding_19; }
	inline bool* get_address_of_asyncResponding_19() { return &___asyncResponding_19; }
	inline void set_asyncResponding_19(bool value)
	{
		___asyncResponding_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
