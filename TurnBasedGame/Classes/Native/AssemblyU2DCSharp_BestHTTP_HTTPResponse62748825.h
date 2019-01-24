#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>
struct Dictionary_2_t3313120627;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Collections.Generic.List`1<BestHTTP.Cookies.Cookie>
struct List_1_t3531925514;
// UnityEngine.Texture2D
struct Texture2D_t3542995729;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// System.IO.Stream
struct Stream_t3255436806;
// System.Collections.Generic.List`1<System.Byte[]>
struct List_1_t2766455145;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPResponse
struct  HTTPResponse_t62748825  : public Il2CppObject
{
public:
	// System.Int32 BestHTTP.HTTPResponse::<VersionMajor>k__BackingField
	int32_t ___U3CVersionMajorU3Ek__BackingField_3;
	// System.Int32 BestHTTP.HTTPResponse::<VersionMinor>k__BackingField
	int32_t ___U3CVersionMinorU3Ek__BackingField_4;
	// System.Int32 BestHTTP.HTTPResponse::<StatusCode>k__BackingField
	int32_t ___U3CStatusCodeU3Ek__BackingField_5;
	// System.String BestHTTP.HTTPResponse::<Message>k__BackingField
	String_t* ___U3CMessageU3Ek__BackingField_6;
	// System.Boolean BestHTTP.HTTPResponse::<IsStreamed>k__BackingField
	bool ___U3CIsStreamedU3Ek__BackingField_7;
	// System.Boolean BestHTTP.HTTPResponse::<IsStreamingFinished>k__BackingField
	bool ___U3CIsStreamingFinishedU3Ek__BackingField_8;
	// System.Boolean BestHTTP.HTTPResponse::<IsFromCache>k__BackingField
	bool ___U3CIsFromCacheU3Ek__BackingField_9;
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>> BestHTTP.HTTPResponse::<Headers>k__BackingField
	Dictionary_2_t3313120627 * ___U3CHeadersU3Ek__BackingField_10;
	// System.Byte[] BestHTTP.HTTPResponse::<Data>k__BackingField
	ByteU5BU5D_t3397334013* ___U3CDataU3Ek__BackingField_11;
	// System.Boolean BestHTTP.HTTPResponse::<IsUpgraded>k__BackingField
	bool ___U3CIsUpgradedU3Ek__BackingField_12;
	// System.Collections.Generic.List`1<BestHTTP.Cookies.Cookie> BestHTTP.HTTPResponse::<Cookies>k__BackingField
	List_1_t3531925514 * ___U3CCookiesU3Ek__BackingField_13;
	// System.String BestHTTP.HTTPResponse::dataAsText
	String_t* ___dataAsText_14;
	// UnityEngine.Texture2D BestHTTP.HTTPResponse::texture
	Texture2D_t3542995729 * ___texture_15;
	// System.Boolean BestHTTP.HTTPResponse::<IsClosedManually>k__BackingField
	bool ___U3CIsClosedManuallyU3Ek__BackingField_16;
	// BestHTTP.HTTPRequest BestHTTP.HTTPResponse::baseRequest
	HTTPRequest_t138485887 * ___baseRequest_17;
	// System.IO.Stream BestHTTP.HTTPResponse::Stream
	Stream_t3255436806 * ___Stream_18;
	// System.Collections.Generic.List`1<System.Byte[]> BestHTTP.HTTPResponse::streamedFragments
	List_1_t2766455145 * ___streamedFragments_19;
	// System.Object BestHTTP.HTTPResponse::SyncRoot
	Il2CppObject * ___SyncRoot_20;
	// System.Byte[] BestHTTP.HTTPResponse::fragmentBuffer
	ByteU5BU5D_t3397334013* ___fragmentBuffer_21;
	// System.Int32 BestHTTP.HTTPResponse::fragmentBufferDataLength
	int32_t ___fragmentBufferDataLength_22;
	// System.IO.Stream BestHTTP.HTTPResponse::cacheStream
	Stream_t3255436806 * ___cacheStream_23;
	// System.Int32 BestHTTP.HTTPResponse::allFragmentSize
	int32_t ___allFragmentSize_24;

public:
	inline static int32_t get_offset_of_U3CVersionMajorU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CVersionMajorU3Ek__BackingField_3)); }
	inline int32_t get_U3CVersionMajorU3Ek__BackingField_3() const { return ___U3CVersionMajorU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CVersionMajorU3Ek__BackingField_3() { return &___U3CVersionMajorU3Ek__BackingField_3; }
	inline void set_U3CVersionMajorU3Ek__BackingField_3(int32_t value)
	{
		___U3CVersionMajorU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CVersionMinorU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CVersionMinorU3Ek__BackingField_4)); }
	inline int32_t get_U3CVersionMinorU3Ek__BackingField_4() const { return ___U3CVersionMinorU3Ek__BackingField_4; }
	inline int32_t* get_address_of_U3CVersionMinorU3Ek__BackingField_4() { return &___U3CVersionMinorU3Ek__BackingField_4; }
	inline void set_U3CVersionMinorU3Ek__BackingField_4(int32_t value)
	{
		___U3CVersionMinorU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CStatusCodeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CStatusCodeU3Ek__BackingField_5)); }
	inline int32_t get_U3CStatusCodeU3Ek__BackingField_5() const { return ___U3CStatusCodeU3Ek__BackingField_5; }
	inline int32_t* get_address_of_U3CStatusCodeU3Ek__BackingField_5() { return &___U3CStatusCodeU3Ek__BackingField_5; }
	inline void set_U3CStatusCodeU3Ek__BackingField_5(int32_t value)
	{
		___U3CStatusCodeU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CMessageU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CMessageU3Ek__BackingField_6)); }
	inline String_t* get_U3CMessageU3Ek__BackingField_6() const { return ___U3CMessageU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CMessageU3Ek__BackingField_6() { return &___U3CMessageU3Ek__BackingField_6; }
	inline void set_U3CMessageU3Ek__BackingField_6(String_t* value)
	{
		___U3CMessageU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMessageU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CIsStreamedU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CIsStreamedU3Ek__BackingField_7)); }
	inline bool get_U3CIsStreamedU3Ek__BackingField_7() const { return ___U3CIsStreamedU3Ek__BackingField_7; }
	inline bool* get_address_of_U3CIsStreamedU3Ek__BackingField_7() { return &___U3CIsStreamedU3Ek__BackingField_7; }
	inline void set_U3CIsStreamedU3Ek__BackingField_7(bool value)
	{
		___U3CIsStreamedU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CIsStreamingFinishedU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CIsStreamingFinishedU3Ek__BackingField_8)); }
	inline bool get_U3CIsStreamingFinishedU3Ek__BackingField_8() const { return ___U3CIsStreamingFinishedU3Ek__BackingField_8; }
	inline bool* get_address_of_U3CIsStreamingFinishedU3Ek__BackingField_8() { return &___U3CIsStreamingFinishedU3Ek__BackingField_8; }
	inline void set_U3CIsStreamingFinishedU3Ek__BackingField_8(bool value)
	{
		___U3CIsStreamingFinishedU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CIsFromCacheU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CIsFromCacheU3Ek__BackingField_9)); }
	inline bool get_U3CIsFromCacheU3Ek__BackingField_9() const { return ___U3CIsFromCacheU3Ek__BackingField_9; }
	inline bool* get_address_of_U3CIsFromCacheU3Ek__BackingField_9() { return &___U3CIsFromCacheU3Ek__BackingField_9; }
	inline void set_U3CIsFromCacheU3Ek__BackingField_9(bool value)
	{
		___U3CIsFromCacheU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of_U3CHeadersU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CHeadersU3Ek__BackingField_10)); }
	inline Dictionary_2_t3313120627 * get_U3CHeadersU3Ek__BackingField_10() const { return ___U3CHeadersU3Ek__BackingField_10; }
	inline Dictionary_2_t3313120627 ** get_address_of_U3CHeadersU3Ek__BackingField_10() { return &___U3CHeadersU3Ek__BackingField_10; }
	inline void set_U3CHeadersU3Ek__BackingField_10(Dictionary_2_t3313120627 * value)
	{
		___U3CHeadersU3Ek__BackingField_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHeadersU3Ek__BackingField_10, value);
	}

	inline static int32_t get_offset_of_U3CDataU3Ek__BackingField_11() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CDataU3Ek__BackingField_11)); }
	inline ByteU5BU5D_t3397334013* get_U3CDataU3Ek__BackingField_11() const { return ___U3CDataU3Ek__BackingField_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_U3CDataU3Ek__BackingField_11() { return &___U3CDataU3Ek__BackingField_11; }
	inline void set_U3CDataU3Ek__BackingField_11(ByteU5BU5D_t3397334013* value)
	{
		___U3CDataU3Ek__BackingField_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDataU3Ek__BackingField_11, value);
	}

	inline static int32_t get_offset_of_U3CIsUpgradedU3Ek__BackingField_12() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CIsUpgradedU3Ek__BackingField_12)); }
	inline bool get_U3CIsUpgradedU3Ek__BackingField_12() const { return ___U3CIsUpgradedU3Ek__BackingField_12; }
	inline bool* get_address_of_U3CIsUpgradedU3Ek__BackingField_12() { return &___U3CIsUpgradedU3Ek__BackingField_12; }
	inline void set_U3CIsUpgradedU3Ek__BackingField_12(bool value)
	{
		___U3CIsUpgradedU3Ek__BackingField_12 = value;
	}

	inline static int32_t get_offset_of_U3CCookiesU3Ek__BackingField_13() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CCookiesU3Ek__BackingField_13)); }
	inline List_1_t3531925514 * get_U3CCookiesU3Ek__BackingField_13() const { return ___U3CCookiesU3Ek__BackingField_13; }
	inline List_1_t3531925514 ** get_address_of_U3CCookiesU3Ek__BackingField_13() { return &___U3CCookiesU3Ek__BackingField_13; }
	inline void set_U3CCookiesU3Ek__BackingField_13(List_1_t3531925514 * value)
	{
		___U3CCookiesU3Ek__BackingField_13 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCookiesU3Ek__BackingField_13, value);
	}

	inline static int32_t get_offset_of_dataAsText_14() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___dataAsText_14)); }
	inline String_t* get_dataAsText_14() const { return ___dataAsText_14; }
	inline String_t** get_address_of_dataAsText_14() { return &___dataAsText_14; }
	inline void set_dataAsText_14(String_t* value)
	{
		___dataAsText_14 = value;
		Il2CppCodeGenWriteBarrier(&___dataAsText_14, value);
	}

	inline static int32_t get_offset_of_texture_15() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___texture_15)); }
	inline Texture2D_t3542995729 * get_texture_15() const { return ___texture_15; }
	inline Texture2D_t3542995729 ** get_address_of_texture_15() { return &___texture_15; }
	inline void set_texture_15(Texture2D_t3542995729 * value)
	{
		___texture_15 = value;
		Il2CppCodeGenWriteBarrier(&___texture_15, value);
	}

	inline static int32_t get_offset_of_U3CIsClosedManuallyU3Ek__BackingField_16() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___U3CIsClosedManuallyU3Ek__BackingField_16)); }
	inline bool get_U3CIsClosedManuallyU3Ek__BackingField_16() const { return ___U3CIsClosedManuallyU3Ek__BackingField_16; }
	inline bool* get_address_of_U3CIsClosedManuallyU3Ek__BackingField_16() { return &___U3CIsClosedManuallyU3Ek__BackingField_16; }
	inline void set_U3CIsClosedManuallyU3Ek__BackingField_16(bool value)
	{
		___U3CIsClosedManuallyU3Ek__BackingField_16 = value;
	}

	inline static int32_t get_offset_of_baseRequest_17() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___baseRequest_17)); }
	inline HTTPRequest_t138485887 * get_baseRequest_17() const { return ___baseRequest_17; }
	inline HTTPRequest_t138485887 ** get_address_of_baseRequest_17() { return &___baseRequest_17; }
	inline void set_baseRequest_17(HTTPRequest_t138485887 * value)
	{
		___baseRequest_17 = value;
		Il2CppCodeGenWriteBarrier(&___baseRequest_17, value);
	}

	inline static int32_t get_offset_of_Stream_18() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___Stream_18)); }
	inline Stream_t3255436806 * get_Stream_18() const { return ___Stream_18; }
	inline Stream_t3255436806 ** get_address_of_Stream_18() { return &___Stream_18; }
	inline void set_Stream_18(Stream_t3255436806 * value)
	{
		___Stream_18 = value;
		Il2CppCodeGenWriteBarrier(&___Stream_18, value);
	}

	inline static int32_t get_offset_of_streamedFragments_19() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___streamedFragments_19)); }
	inline List_1_t2766455145 * get_streamedFragments_19() const { return ___streamedFragments_19; }
	inline List_1_t2766455145 ** get_address_of_streamedFragments_19() { return &___streamedFragments_19; }
	inline void set_streamedFragments_19(List_1_t2766455145 * value)
	{
		___streamedFragments_19 = value;
		Il2CppCodeGenWriteBarrier(&___streamedFragments_19, value);
	}

	inline static int32_t get_offset_of_SyncRoot_20() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___SyncRoot_20)); }
	inline Il2CppObject * get_SyncRoot_20() const { return ___SyncRoot_20; }
	inline Il2CppObject ** get_address_of_SyncRoot_20() { return &___SyncRoot_20; }
	inline void set_SyncRoot_20(Il2CppObject * value)
	{
		___SyncRoot_20 = value;
		Il2CppCodeGenWriteBarrier(&___SyncRoot_20, value);
	}

	inline static int32_t get_offset_of_fragmentBuffer_21() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___fragmentBuffer_21)); }
	inline ByteU5BU5D_t3397334013* get_fragmentBuffer_21() const { return ___fragmentBuffer_21; }
	inline ByteU5BU5D_t3397334013** get_address_of_fragmentBuffer_21() { return &___fragmentBuffer_21; }
	inline void set_fragmentBuffer_21(ByteU5BU5D_t3397334013* value)
	{
		___fragmentBuffer_21 = value;
		Il2CppCodeGenWriteBarrier(&___fragmentBuffer_21, value);
	}

	inline static int32_t get_offset_of_fragmentBufferDataLength_22() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___fragmentBufferDataLength_22)); }
	inline int32_t get_fragmentBufferDataLength_22() const { return ___fragmentBufferDataLength_22; }
	inline int32_t* get_address_of_fragmentBufferDataLength_22() { return &___fragmentBufferDataLength_22; }
	inline void set_fragmentBufferDataLength_22(int32_t value)
	{
		___fragmentBufferDataLength_22 = value;
	}

	inline static int32_t get_offset_of_cacheStream_23() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___cacheStream_23)); }
	inline Stream_t3255436806 * get_cacheStream_23() const { return ___cacheStream_23; }
	inline Stream_t3255436806 ** get_address_of_cacheStream_23() { return &___cacheStream_23; }
	inline void set_cacheStream_23(Stream_t3255436806 * value)
	{
		___cacheStream_23 = value;
		Il2CppCodeGenWriteBarrier(&___cacheStream_23, value);
	}

	inline static int32_t get_offset_of_allFragmentSize_24() { return static_cast<int32_t>(offsetof(HTTPResponse_t62748825, ___allFragmentSize_24)); }
	inline int32_t get_allFragmentSize_24() const { return ___allFragmentSize_24; }
	inline int32_t* get_address_of_allFragmentSize_24() { return &___allFragmentSize_24; }
	inline void set_allFragmentSize_24(int32_t value)
	{
		___allFragmentSize_24 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
