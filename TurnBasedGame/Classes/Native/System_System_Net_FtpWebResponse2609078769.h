#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Net_WebResponse1895226051.h"
#include "System_System_Net_FtpStatusCode1448112771.h"
#include "mscorlib_System_DateTime693205669.h"

// System.IO.Stream
struct Stream_t3255436806;
// System.Uri
struct Uri_t19570940;
// System.String
struct String_t;
// System.Net.FtpWebRequest
struct FtpWebRequest_t3120721823;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.FtpWebResponse
struct  FtpWebResponse_t2609078769  : public WebResponse_t1895226051
{
public:
	// System.IO.Stream System.Net.FtpWebResponse::stream
	Stream_t3255436806 * ___stream_1;
	// System.Uri System.Net.FtpWebResponse::uri
	Uri_t19570940 * ___uri_2;
	// System.Net.FtpStatusCode System.Net.FtpWebResponse::statusCode
	int32_t ___statusCode_3;
	// System.DateTime System.Net.FtpWebResponse::lastModified
	DateTime_t693205669  ___lastModified_4;
	// System.String System.Net.FtpWebResponse::bannerMessage
	String_t* ___bannerMessage_5;
	// System.String System.Net.FtpWebResponse::welcomeMessage
	String_t* ___welcomeMessage_6;
	// System.String System.Net.FtpWebResponse::exitMessage
	String_t* ___exitMessage_7;
	// System.String System.Net.FtpWebResponse::statusDescription
	String_t* ___statusDescription_8;
	// System.String System.Net.FtpWebResponse::method
	String_t* ___method_9;
	// System.Boolean System.Net.FtpWebResponse::disposed
	bool ___disposed_10;
	// System.Net.FtpWebRequest System.Net.FtpWebResponse::request
	FtpWebRequest_t3120721823 * ___request_11;
	// System.Int64 System.Net.FtpWebResponse::contentLength
	int64_t ___contentLength_12;

public:
	inline static int32_t get_offset_of_stream_1() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___stream_1)); }
	inline Stream_t3255436806 * get_stream_1() const { return ___stream_1; }
	inline Stream_t3255436806 ** get_address_of_stream_1() { return &___stream_1; }
	inline void set_stream_1(Stream_t3255436806 * value)
	{
		___stream_1 = value;
		Il2CppCodeGenWriteBarrier(&___stream_1, value);
	}

	inline static int32_t get_offset_of_uri_2() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___uri_2)); }
	inline Uri_t19570940 * get_uri_2() const { return ___uri_2; }
	inline Uri_t19570940 ** get_address_of_uri_2() { return &___uri_2; }
	inline void set_uri_2(Uri_t19570940 * value)
	{
		___uri_2 = value;
		Il2CppCodeGenWriteBarrier(&___uri_2, value);
	}

	inline static int32_t get_offset_of_statusCode_3() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___statusCode_3)); }
	inline int32_t get_statusCode_3() const { return ___statusCode_3; }
	inline int32_t* get_address_of_statusCode_3() { return &___statusCode_3; }
	inline void set_statusCode_3(int32_t value)
	{
		___statusCode_3 = value;
	}

	inline static int32_t get_offset_of_lastModified_4() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___lastModified_4)); }
	inline DateTime_t693205669  get_lastModified_4() const { return ___lastModified_4; }
	inline DateTime_t693205669 * get_address_of_lastModified_4() { return &___lastModified_4; }
	inline void set_lastModified_4(DateTime_t693205669  value)
	{
		___lastModified_4 = value;
	}

	inline static int32_t get_offset_of_bannerMessage_5() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___bannerMessage_5)); }
	inline String_t* get_bannerMessage_5() const { return ___bannerMessage_5; }
	inline String_t** get_address_of_bannerMessage_5() { return &___bannerMessage_5; }
	inline void set_bannerMessage_5(String_t* value)
	{
		___bannerMessage_5 = value;
		Il2CppCodeGenWriteBarrier(&___bannerMessage_5, value);
	}

	inline static int32_t get_offset_of_welcomeMessage_6() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___welcomeMessage_6)); }
	inline String_t* get_welcomeMessage_6() const { return ___welcomeMessage_6; }
	inline String_t** get_address_of_welcomeMessage_6() { return &___welcomeMessage_6; }
	inline void set_welcomeMessage_6(String_t* value)
	{
		___welcomeMessage_6 = value;
		Il2CppCodeGenWriteBarrier(&___welcomeMessage_6, value);
	}

	inline static int32_t get_offset_of_exitMessage_7() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___exitMessage_7)); }
	inline String_t* get_exitMessage_7() const { return ___exitMessage_7; }
	inline String_t** get_address_of_exitMessage_7() { return &___exitMessage_7; }
	inline void set_exitMessage_7(String_t* value)
	{
		___exitMessage_7 = value;
		Il2CppCodeGenWriteBarrier(&___exitMessage_7, value);
	}

	inline static int32_t get_offset_of_statusDescription_8() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___statusDescription_8)); }
	inline String_t* get_statusDescription_8() const { return ___statusDescription_8; }
	inline String_t** get_address_of_statusDescription_8() { return &___statusDescription_8; }
	inline void set_statusDescription_8(String_t* value)
	{
		___statusDescription_8 = value;
		Il2CppCodeGenWriteBarrier(&___statusDescription_8, value);
	}

	inline static int32_t get_offset_of_method_9() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___method_9)); }
	inline String_t* get_method_9() const { return ___method_9; }
	inline String_t** get_address_of_method_9() { return &___method_9; }
	inline void set_method_9(String_t* value)
	{
		___method_9 = value;
		Il2CppCodeGenWriteBarrier(&___method_9, value);
	}

	inline static int32_t get_offset_of_disposed_10() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___disposed_10)); }
	inline bool get_disposed_10() const { return ___disposed_10; }
	inline bool* get_address_of_disposed_10() { return &___disposed_10; }
	inline void set_disposed_10(bool value)
	{
		___disposed_10 = value;
	}

	inline static int32_t get_offset_of_request_11() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___request_11)); }
	inline FtpWebRequest_t3120721823 * get_request_11() const { return ___request_11; }
	inline FtpWebRequest_t3120721823 ** get_address_of_request_11() { return &___request_11; }
	inline void set_request_11(FtpWebRequest_t3120721823 * value)
	{
		___request_11 = value;
		Il2CppCodeGenWriteBarrier(&___request_11, value);
	}

	inline static int32_t get_offset_of_contentLength_12() { return static_cast<int32_t>(offsetof(FtpWebResponse_t2609078769, ___contentLength_12)); }
	inline int64_t get_contentLength_12() const { return ___contentLength_12; }
	inline int64_t* get_address_of_contentLength_12() { return &___contentLength_12; }
	inline void set_contentLength_12(int64_t value)
	{
		___contentLength_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
