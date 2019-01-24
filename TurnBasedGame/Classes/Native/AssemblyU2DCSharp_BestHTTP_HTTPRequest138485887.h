#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_HTTPMethods178420096.h"
#include "AssemblyU2DCSharp_BestHTTP_Forms_HTTPFormUsage2139743243.h"
#include "AssemblyU2DCSharp_BestHTTP_HTTPRequestStates63938943.h"
#include "mscorlib_System_TimeSpan3430258949.h"
#include "AssemblyU2DCSharp_BestHTTP_SupportedProtocols1503488249.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.Uri
struct Uri_t19570940;
// BestHTTP.Caching.HttpCacheUriBuilder
struct HttpCacheUriBuilder_t330529591;
// System.IO.Stream
struct Stream_t3255436806;
// BestHTTP.OnUploadProgressDelegate
struct OnUploadProgressDelegate_t3063766470;
// BestHTTP.OnRequestFinishedDelegate
struct OnRequestFinishedDelegate_t3180754735;
// BestHTTP.OnDownloadProgressDelegate
struct OnDownloadProgressDelegate_t447146369;
// BestHTTP.HTTPResponse
struct HTTPResponse_t62748825;
// System.Exception
struct Exception_t1927440687;
// System.Object
struct Il2CppObject;
// BestHTTP.Authentication.Credentials
struct Credentials_t3762395084;
// BestHTTP.HTTPProxy
struct HTTPProxy_t2644053826;
// System.Collections.Generic.List`1<BestHTTP.Cookies.Cookie>
struct List_1_t3531925514;
// System.Func`4<BestHTTP.HTTPRequest,System.Security.Cryptography.X509Certificates.X509Certificate,System.Security.Cryptography.X509Certificates.X509Chain,System.Boolean>
struct Func_4_t3321346088;
// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer
struct ICertificateVerifyer_t565084154;
// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider
struct IClientCredentialsProvider_t3199932449;
// BestHTTP.OnBeforeRedirectionDelegate
struct OnBeforeRedirectionDelegate_t290558967;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>
struct Dictionary_2_t3313120627;
// BestHTTP.Forms.HTTPFormBase
struct HTTPFormBase_t1912072923;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPRequest
struct  HTTPRequest_t138485887  : public Il2CppObject
{
public:
	// System.Uri BestHTTP.HTTPRequest::<Uri>k__BackingField
	Uri_t19570940 * ___U3CUriU3Ek__BackingField_3;
	// BestHTTP.Caching.HttpCacheUriBuilder BestHTTP.HTTPRequest::<CacheUriBuilder>k__BackingField
	Il2CppObject * ___U3CCacheUriBuilderU3Ek__BackingField_4;
	// BestHTTP.HTTPMethods BestHTTP.HTTPRequest::<MethodType>k__BackingField
	uint8_t ___U3CMethodTypeU3Ek__BackingField_5;
	// System.Byte[] BestHTTP.HTTPRequest::<RawData>k__BackingField
	ByteU5BU5D_t3397334013* ___U3CRawDataU3Ek__BackingField_6;
	// System.IO.Stream BestHTTP.HTTPRequest::<UploadStream>k__BackingField
	Stream_t3255436806 * ___U3CUploadStreamU3Ek__BackingField_7;
	// System.Boolean BestHTTP.HTTPRequest::<DisposeUploadStream>k__BackingField
	bool ___U3CDisposeUploadStreamU3Ek__BackingField_8;
	// System.Boolean BestHTTP.HTTPRequest::<UseUploadStreamLength>k__BackingField
	bool ___U3CUseUploadStreamLengthU3Ek__BackingField_9;
	// BestHTTP.OnUploadProgressDelegate BestHTTP.HTTPRequest::OnUploadProgress
	OnUploadProgressDelegate_t3063766470 * ___OnUploadProgress_10;
	// BestHTTP.OnRequestFinishedDelegate BestHTTP.HTTPRequest::<Callback>k__BackingField
	OnRequestFinishedDelegate_t3180754735 * ___U3CCallbackU3Ek__BackingField_11;
	// BestHTTP.OnDownloadProgressDelegate BestHTTP.HTTPRequest::OnProgress
	OnDownloadProgressDelegate_t447146369 * ___OnProgress_12;
	// BestHTTP.OnRequestFinishedDelegate BestHTTP.HTTPRequest::OnUpgraded
	OnRequestFinishedDelegate_t3180754735 * ___OnUpgraded_13;
	// System.Boolean BestHTTP.HTTPRequest::<DisableRetry>k__BackingField
	bool ___U3CDisableRetryU3Ek__BackingField_14;
	// System.Boolean BestHTTP.HTTPRequest::<IsRedirected>k__BackingField
	bool ___U3CIsRedirectedU3Ek__BackingField_15;
	// System.Uri BestHTTP.HTTPRequest::<RedirectUri>k__BackingField
	Uri_t19570940 * ___U3CRedirectUriU3Ek__BackingField_16;
	// BestHTTP.HTTPResponse BestHTTP.HTTPRequest::<Response>k__BackingField
	HTTPResponse_t62748825 * ___U3CResponseU3Ek__BackingField_17;
	// BestHTTP.HTTPResponse BestHTTP.HTTPRequest::<ProxyResponse>k__BackingField
	HTTPResponse_t62748825 * ___U3CProxyResponseU3Ek__BackingField_18;
	// System.Exception BestHTTP.HTTPRequest::<Exception>k__BackingField
	Exception_t1927440687 * ___U3CExceptionU3Ek__BackingField_19;
	// System.Object BestHTTP.HTTPRequest::<Tag>k__BackingField
	Il2CppObject * ___U3CTagU3Ek__BackingField_20;
	// BestHTTP.Authentication.Credentials BestHTTP.HTTPRequest::<Credentials>k__BackingField
	Credentials_t3762395084 * ___U3CCredentialsU3Ek__BackingField_21;
	// BestHTTP.HTTPProxy BestHTTP.HTTPRequest::<Proxy>k__BackingField
	HTTPProxy_t2644053826 * ___U3CProxyU3Ek__BackingField_22;
	// System.Int32 BestHTTP.HTTPRequest::<MaxRedirects>k__BackingField
	int32_t ___U3CMaxRedirectsU3Ek__BackingField_23;
	// System.Boolean BestHTTP.HTTPRequest::<UseAlternateSSL>k__BackingField
	bool ___U3CUseAlternateSSLU3Ek__BackingField_24;
	// System.Boolean BestHTTP.HTTPRequest::<IsCookiesEnabled>k__BackingField
	bool ___U3CIsCookiesEnabledU3Ek__BackingField_25;
	// System.Collections.Generic.List`1<BestHTTP.Cookies.Cookie> BestHTTP.HTTPRequest::customCookies
	List_1_t3531925514 * ___customCookies_26;
	// BestHTTP.Forms.HTTPFormUsage BestHTTP.HTTPRequest::<FormUsage>k__BackingField
	int32_t ___U3CFormUsageU3Ek__BackingField_27;
	// BestHTTP.HTTPRequestStates BestHTTP.HTTPRequest::<State>k__BackingField
	int32_t ___U3CStateU3Ek__BackingField_28;
	// System.Int32 BestHTTP.HTTPRequest::<RedirectCount>k__BackingField
	int32_t ___U3CRedirectCountU3Ek__BackingField_29;
	// System.Func`4<BestHTTP.HTTPRequest,System.Security.Cryptography.X509Certificates.X509Certificate,System.Security.Cryptography.X509Certificates.X509Chain,System.Boolean> BestHTTP.HTTPRequest::CustomCertificationValidator
	Func_4_t3321346088 * ___CustomCertificationValidator_30;
	// System.TimeSpan BestHTTP.HTTPRequest::<ConnectTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CConnectTimeoutU3Ek__BackingField_31;
	// System.TimeSpan BestHTTP.HTTPRequest::<Timeout>k__BackingField
	TimeSpan_t3430258949  ___U3CTimeoutU3Ek__BackingField_32;
	// System.Boolean BestHTTP.HTTPRequest::<EnableTimoutForStreaming>k__BackingField
	bool ___U3CEnableTimoutForStreamingU3Ek__BackingField_33;
	// System.Int32 BestHTTP.HTTPRequest::<Priority>k__BackingField
	int32_t ___U3CPriorityU3Ek__BackingField_34;
	// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer BestHTTP.HTTPRequest::<CustomCertificateVerifyer>k__BackingField
	Il2CppObject * ___U3CCustomCertificateVerifyerU3Ek__BackingField_35;
	// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider BestHTTP.HTTPRequest::<CustomClientCredentialsProvider>k__BackingField
	Il2CppObject * ___U3CCustomClientCredentialsProviderU3Ek__BackingField_36;
	// BestHTTP.SupportedProtocols BestHTTP.HTTPRequest::<ProtocolHandler>k__BackingField
	int32_t ___U3CProtocolHandlerU3Ek__BackingField_37;
	// BestHTTP.OnBeforeRedirectionDelegate BestHTTP.HTTPRequest::onBeforeRedirection
	OnBeforeRedirectionDelegate_t290558967 * ___onBeforeRedirection_38;
	// System.Int32 BestHTTP.HTTPRequest::<Downloaded>k__BackingField
	int32_t ___U3CDownloadedU3Ek__BackingField_39;
	// System.Int32 BestHTTP.HTTPRequest::<DownloadLength>k__BackingField
	int32_t ___U3CDownloadLengthU3Ek__BackingField_40;
	// System.Boolean BestHTTP.HTTPRequest::<DownloadProgressChanged>k__BackingField
	bool ___U3CDownloadProgressChangedU3Ek__BackingField_41;
	// System.Int64 BestHTTP.HTTPRequest::<Uploaded>k__BackingField
	int64_t ___U3CUploadedU3Ek__BackingField_42;
	// System.Int64 BestHTTP.HTTPRequest::<UploadLength>k__BackingField
	int64_t ___U3CUploadLengthU3Ek__BackingField_43;
	// System.Boolean BestHTTP.HTTPRequest::<UploadProgressChanged>k__BackingField
	bool ___U3CUploadProgressChangedU3Ek__BackingField_44;
	// System.Boolean BestHTTP.HTTPRequest::isKeepAlive
	bool ___isKeepAlive_45;
	// System.Boolean BestHTTP.HTTPRequest::disableCache
	bool ___disableCache_46;
	// System.Int32 BestHTTP.HTTPRequest::cacheTime
	int32_t ___cacheTime_47;
	// System.Int32 BestHTTP.HTTPRequest::streamFragmentSize
	int32_t ___streamFragmentSize_48;
	// System.Boolean BestHTTP.HTTPRequest::useStreaming
	bool ___useStreaming_49;
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>> BestHTTP.HTTPRequest::<Headers>k__BackingField
	Dictionary_2_t3313120627 * ___U3CHeadersU3Ek__BackingField_50;
	// BestHTTP.Forms.HTTPFormBase BestHTTP.HTTPRequest::FieldCollector
	HTTPFormBase_t1912072923 * ___FieldCollector_51;
	// BestHTTP.Forms.HTTPFormBase BestHTTP.HTTPRequest::FormImpl
	HTTPFormBase_t1912072923 * ___FormImpl_52;

public:
	inline static int32_t get_offset_of_U3CUriU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUriU3Ek__BackingField_3)); }
	inline Uri_t19570940 * get_U3CUriU3Ek__BackingField_3() const { return ___U3CUriU3Ek__BackingField_3; }
	inline Uri_t19570940 ** get_address_of_U3CUriU3Ek__BackingField_3() { return &___U3CUriU3Ek__BackingField_3; }
	inline void set_U3CUriU3Ek__BackingField_3(Uri_t19570940 * value)
	{
		___U3CUriU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUriU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CCacheUriBuilderU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CCacheUriBuilderU3Ek__BackingField_4)); }
	inline Il2CppObject * get_U3CCacheUriBuilderU3Ek__BackingField_4() const { return ___U3CCacheUriBuilderU3Ek__BackingField_4; }
	inline Il2CppObject ** get_address_of_U3CCacheUriBuilderU3Ek__BackingField_4() { return &___U3CCacheUriBuilderU3Ek__BackingField_4; }
	inline void set_U3CCacheUriBuilderU3Ek__BackingField_4(Il2CppObject * value)
	{
		___U3CCacheUriBuilderU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCacheUriBuilderU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CMethodTypeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CMethodTypeU3Ek__BackingField_5)); }
	inline uint8_t get_U3CMethodTypeU3Ek__BackingField_5() const { return ___U3CMethodTypeU3Ek__BackingField_5; }
	inline uint8_t* get_address_of_U3CMethodTypeU3Ek__BackingField_5() { return &___U3CMethodTypeU3Ek__BackingField_5; }
	inline void set_U3CMethodTypeU3Ek__BackingField_5(uint8_t value)
	{
		___U3CMethodTypeU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CRawDataU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CRawDataU3Ek__BackingField_6)); }
	inline ByteU5BU5D_t3397334013* get_U3CRawDataU3Ek__BackingField_6() const { return ___U3CRawDataU3Ek__BackingField_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_U3CRawDataU3Ek__BackingField_6() { return &___U3CRawDataU3Ek__BackingField_6; }
	inline void set_U3CRawDataU3Ek__BackingField_6(ByteU5BU5D_t3397334013* value)
	{
		___U3CRawDataU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRawDataU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CUploadStreamU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUploadStreamU3Ek__BackingField_7)); }
	inline Stream_t3255436806 * get_U3CUploadStreamU3Ek__BackingField_7() const { return ___U3CUploadStreamU3Ek__BackingField_7; }
	inline Stream_t3255436806 ** get_address_of_U3CUploadStreamU3Ek__BackingField_7() { return &___U3CUploadStreamU3Ek__BackingField_7; }
	inline void set_U3CUploadStreamU3Ek__BackingField_7(Stream_t3255436806 * value)
	{
		___U3CUploadStreamU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUploadStreamU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CDisposeUploadStreamU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CDisposeUploadStreamU3Ek__BackingField_8)); }
	inline bool get_U3CDisposeUploadStreamU3Ek__BackingField_8() const { return ___U3CDisposeUploadStreamU3Ek__BackingField_8; }
	inline bool* get_address_of_U3CDisposeUploadStreamU3Ek__BackingField_8() { return &___U3CDisposeUploadStreamU3Ek__BackingField_8; }
	inline void set_U3CDisposeUploadStreamU3Ek__BackingField_8(bool value)
	{
		___U3CDisposeUploadStreamU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CUseUploadStreamLengthU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUseUploadStreamLengthU3Ek__BackingField_9)); }
	inline bool get_U3CUseUploadStreamLengthU3Ek__BackingField_9() const { return ___U3CUseUploadStreamLengthU3Ek__BackingField_9; }
	inline bool* get_address_of_U3CUseUploadStreamLengthU3Ek__BackingField_9() { return &___U3CUseUploadStreamLengthU3Ek__BackingField_9; }
	inline void set_U3CUseUploadStreamLengthU3Ek__BackingField_9(bool value)
	{
		___U3CUseUploadStreamLengthU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of_OnUploadProgress_10() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___OnUploadProgress_10)); }
	inline OnUploadProgressDelegate_t3063766470 * get_OnUploadProgress_10() const { return ___OnUploadProgress_10; }
	inline OnUploadProgressDelegate_t3063766470 ** get_address_of_OnUploadProgress_10() { return &___OnUploadProgress_10; }
	inline void set_OnUploadProgress_10(OnUploadProgressDelegate_t3063766470 * value)
	{
		___OnUploadProgress_10 = value;
		Il2CppCodeGenWriteBarrier(&___OnUploadProgress_10, value);
	}

	inline static int32_t get_offset_of_U3CCallbackU3Ek__BackingField_11() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CCallbackU3Ek__BackingField_11)); }
	inline OnRequestFinishedDelegate_t3180754735 * get_U3CCallbackU3Ek__BackingField_11() const { return ___U3CCallbackU3Ek__BackingField_11; }
	inline OnRequestFinishedDelegate_t3180754735 ** get_address_of_U3CCallbackU3Ek__BackingField_11() { return &___U3CCallbackU3Ek__BackingField_11; }
	inline void set_U3CCallbackU3Ek__BackingField_11(OnRequestFinishedDelegate_t3180754735 * value)
	{
		___U3CCallbackU3Ek__BackingField_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCallbackU3Ek__BackingField_11, value);
	}

	inline static int32_t get_offset_of_OnProgress_12() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___OnProgress_12)); }
	inline OnDownloadProgressDelegate_t447146369 * get_OnProgress_12() const { return ___OnProgress_12; }
	inline OnDownloadProgressDelegate_t447146369 ** get_address_of_OnProgress_12() { return &___OnProgress_12; }
	inline void set_OnProgress_12(OnDownloadProgressDelegate_t447146369 * value)
	{
		___OnProgress_12 = value;
		Il2CppCodeGenWriteBarrier(&___OnProgress_12, value);
	}

	inline static int32_t get_offset_of_OnUpgraded_13() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___OnUpgraded_13)); }
	inline OnRequestFinishedDelegate_t3180754735 * get_OnUpgraded_13() const { return ___OnUpgraded_13; }
	inline OnRequestFinishedDelegate_t3180754735 ** get_address_of_OnUpgraded_13() { return &___OnUpgraded_13; }
	inline void set_OnUpgraded_13(OnRequestFinishedDelegate_t3180754735 * value)
	{
		___OnUpgraded_13 = value;
		Il2CppCodeGenWriteBarrier(&___OnUpgraded_13, value);
	}

	inline static int32_t get_offset_of_U3CDisableRetryU3Ek__BackingField_14() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CDisableRetryU3Ek__BackingField_14)); }
	inline bool get_U3CDisableRetryU3Ek__BackingField_14() const { return ___U3CDisableRetryU3Ek__BackingField_14; }
	inline bool* get_address_of_U3CDisableRetryU3Ek__BackingField_14() { return &___U3CDisableRetryU3Ek__BackingField_14; }
	inline void set_U3CDisableRetryU3Ek__BackingField_14(bool value)
	{
		___U3CDisableRetryU3Ek__BackingField_14 = value;
	}

	inline static int32_t get_offset_of_U3CIsRedirectedU3Ek__BackingField_15() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CIsRedirectedU3Ek__BackingField_15)); }
	inline bool get_U3CIsRedirectedU3Ek__BackingField_15() const { return ___U3CIsRedirectedU3Ek__BackingField_15; }
	inline bool* get_address_of_U3CIsRedirectedU3Ek__BackingField_15() { return &___U3CIsRedirectedU3Ek__BackingField_15; }
	inline void set_U3CIsRedirectedU3Ek__BackingField_15(bool value)
	{
		___U3CIsRedirectedU3Ek__BackingField_15 = value;
	}

	inline static int32_t get_offset_of_U3CRedirectUriU3Ek__BackingField_16() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CRedirectUriU3Ek__BackingField_16)); }
	inline Uri_t19570940 * get_U3CRedirectUriU3Ek__BackingField_16() const { return ___U3CRedirectUriU3Ek__BackingField_16; }
	inline Uri_t19570940 ** get_address_of_U3CRedirectUriU3Ek__BackingField_16() { return &___U3CRedirectUriU3Ek__BackingField_16; }
	inline void set_U3CRedirectUriU3Ek__BackingField_16(Uri_t19570940 * value)
	{
		___U3CRedirectUriU3Ek__BackingField_16 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRedirectUriU3Ek__BackingField_16, value);
	}

	inline static int32_t get_offset_of_U3CResponseU3Ek__BackingField_17() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CResponseU3Ek__BackingField_17)); }
	inline HTTPResponse_t62748825 * get_U3CResponseU3Ek__BackingField_17() const { return ___U3CResponseU3Ek__BackingField_17; }
	inline HTTPResponse_t62748825 ** get_address_of_U3CResponseU3Ek__BackingField_17() { return &___U3CResponseU3Ek__BackingField_17; }
	inline void set_U3CResponseU3Ek__BackingField_17(HTTPResponse_t62748825 * value)
	{
		___U3CResponseU3Ek__BackingField_17 = value;
		Il2CppCodeGenWriteBarrier(&___U3CResponseU3Ek__BackingField_17, value);
	}

	inline static int32_t get_offset_of_U3CProxyResponseU3Ek__BackingField_18() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CProxyResponseU3Ek__BackingField_18)); }
	inline HTTPResponse_t62748825 * get_U3CProxyResponseU3Ek__BackingField_18() const { return ___U3CProxyResponseU3Ek__BackingField_18; }
	inline HTTPResponse_t62748825 ** get_address_of_U3CProxyResponseU3Ek__BackingField_18() { return &___U3CProxyResponseU3Ek__BackingField_18; }
	inline void set_U3CProxyResponseU3Ek__BackingField_18(HTTPResponse_t62748825 * value)
	{
		___U3CProxyResponseU3Ek__BackingField_18 = value;
		Il2CppCodeGenWriteBarrier(&___U3CProxyResponseU3Ek__BackingField_18, value);
	}

	inline static int32_t get_offset_of_U3CExceptionU3Ek__BackingField_19() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CExceptionU3Ek__BackingField_19)); }
	inline Exception_t1927440687 * get_U3CExceptionU3Ek__BackingField_19() const { return ___U3CExceptionU3Ek__BackingField_19; }
	inline Exception_t1927440687 ** get_address_of_U3CExceptionU3Ek__BackingField_19() { return &___U3CExceptionU3Ek__BackingField_19; }
	inline void set_U3CExceptionU3Ek__BackingField_19(Exception_t1927440687 * value)
	{
		___U3CExceptionU3Ek__BackingField_19 = value;
		Il2CppCodeGenWriteBarrier(&___U3CExceptionU3Ek__BackingField_19, value);
	}

	inline static int32_t get_offset_of_U3CTagU3Ek__BackingField_20() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CTagU3Ek__BackingField_20)); }
	inline Il2CppObject * get_U3CTagU3Ek__BackingField_20() const { return ___U3CTagU3Ek__BackingField_20; }
	inline Il2CppObject ** get_address_of_U3CTagU3Ek__BackingField_20() { return &___U3CTagU3Ek__BackingField_20; }
	inline void set_U3CTagU3Ek__BackingField_20(Il2CppObject * value)
	{
		___U3CTagU3Ek__BackingField_20 = value;
		Il2CppCodeGenWriteBarrier(&___U3CTagU3Ek__BackingField_20, value);
	}

	inline static int32_t get_offset_of_U3CCredentialsU3Ek__BackingField_21() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CCredentialsU3Ek__BackingField_21)); }
	inline Credentials_t3762395084 * get_U3CCredentialsU3Ek__BackingField_21() const { return ___U3CCredentialsU3Ek__BackingField_21; }
	inline Credentials_t3762395084 ** get_address_of_U3CCredentialsU3Ek__BackingField_21() { return &___U3CCredentialsU3Ek__BackingField_21; }
	inline void set_U3CCredentialsU3Ek__BackingField_21(Credentials_t3762395084 * value)
	{
		___U3CCredentialsU3Ek__BackingField_21 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCredentialsU3Ek__BackingField_21, value);
	}

	inline static int32_t get_offset_of_U3CProxyU3Ek__BackingField_22() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CProxyU3Ek__BackingField_22)); }
	inline HTTPProxy_t2644053826 * get_U3CProxyU3Ek__BackingField_22() const { return ___U3CProxyU3Ek__BackingField_22; }
	inline HTTPProxy_t2644053826 ** get_address_of_U3CProxyU3Ek__BackingField_22() { return &___U3CProxyU3Ek__BackingField_22; }
	inline void set_U3CProxyU3Ek__BackingField_22(HTTPProxy_t2644053826 * value)
	{
		___U3CProxyU3Ek__BackingField_22 = value;
		Il2CppCodeGenWriteBarrier(&___U3CProxyU3Ek__BackingField_22, value);
	}

	inline static int32_t get_offset_of_U3CMaxRedirectsU3Ek__BackingField_23() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CMaxRedirectsU3Ek__BackingField_23)); }
	inline int32_t get_U3CMaxRedirectsU3Ek__BackingField_23() const { return ___U3CMaxRedirectsU3Ek__BackingField_23; }
	inline int32_t* get_address_of_U3CMaxRedirectsU3Ek__BackingField_23() { return &___U3CMaxRedirectsU3Ek__BackingField_23; }
	inline void set_U3CMaxRedirectsU3Ek__BackingField_23(int32_t value)
	{
		___U3CMaxRedirectsU3Ek__BackingField_23 = value;
	}

	inline static int32_t get_offset_of_U3CUseAlternateSSLU3Ek__BackingField_24() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUseAlternateSSLU3Ek__BackingField_24)); }
	inline bool get_U3CUseAlternateSSLU3Ek__BackingField_24() const { return ___U3CUseAlternateSSLU3Ek__BackingField_24; }
	inline bool* get_address_of_U3CUseAlternateSSLU3Ek__BackingField_24() { return &___U3CUseAlternateSSLU3Ek__BackingField_24; }
	inline void set_U3CUseAlternateSSLU3Ek__BackingField_24(bool value)
	{
		___U3CUseAlternateSSLU3Ek__BackingField_24 = value;
	}

	inline static int32_t get_offset_of_U3CIsCookiesEnabledU3Ek__BackingField_25() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CIsCookiesEnabledU3Ek__BackingField_25)); }
	inline bool get_U3CIsCookiesEnabledU3Ek__BackingField_25() const { return ___U3CIsCookiesEnabledU3Ek__BackingField_25; }
	inline bool* get_address_of_U3CIsCookiesEnabledU3Ek__BackingField_25() { return &___U3CIsCookiesEnabledU3Ek__BackingField_25; }
	inline void set_U3CIsCookiesEnabledU3Ek__BackingField_25(bool value)
	{
		___U3CIsCookiesEnabledU3Ek__BackingField_25 = value;
	}

	inline static int32_t get_offset_of_customCookies_26() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___customCookies_26)); }
	inline List_1_t3531925514 * get_customCookies_26() const { return ___customCookies_26; }
	inline List_1_t3531925514 ** get_address_of_customCookies_26() { return &___customCookies_26; }
	inline void set_customCookies_26(List_1_t3531925514 * value)
	{
		___customCookies_26 = value;
		Il2CppCodeGenWriteBarrier(&___customCookies_26, value);
	}

	inline static int32_t get_offset_of_U3CFormUsageU3Ek__BackingField_27() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CFormUsageU3Ek__BackingField_27)); }
	inline int32_t get_U3CFormUsageU3Ek__BackingField_27() const { return ___U3CFormUsageU3Ek__BackingField_27; }
	inline int32_t* get_address_of_U3CFormUsageU3Ek__BackingField_27() { return &___U3CFormUsageU3Ek__BackingField_27; }
	inline void set_U3CFormUsageU3Ek__BackingField_27(int32_t value)
	{
		___U3CFormUsageU3Ek__BackingField_27 = value;
	}

	inline static int32_t get_offset_of_U3CStateU3Ek__BackingField_28() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CStateU3Ek__BackingField_28)); }
	inline int32_t get_U3CStateU3Ek__BackingField_28() const { return ___U3CStateU3Ek__BackingField_28; }
	inline int32_t* get_address_of_U3CStateU3Ek__BackingField_28() { return &___U3CStateU3Ek__BackingField_28; }
	inline void set_U3CStateU3Ek__BackingField_28(int32_t value)
	{
		___U3CStateU3Ek__BackingField_28 = value;
	}

	inline static int32_t get_offset_of_U3CRedirectCountU3Ek__BackingField_29() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CRedirectCountU3Ek__BackingField_29)); }
	inline int32_t get_U3CRedirectCountU3Ek__BackingField_29() const { return ___U3CRedirectCountU3Ek__BackingField_29; }
	inline int32_t* get_address_of_U3CRedirectCountU3Ek__BackingField_29() { return &___U3CRedirectCountU3Ek__BackingField_29; }
	inline void set_U3CRedirectCountU3Ek__BackingField_29(int32_t value)
	{
		___U3CRedirectCountU3Ek__BackingField_29 = value;
	}

	inline static int32_t get_offset_of_CustomCertificationValidator_30() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___CustomCertificationValidator_30)); }
	inline Func_4_t3321346088 * get_CustomCertificationValidator_30() const { return ___CustomCertificationValidator_30; }
	inline Func_4_t3321346088 ** get_address_of_CustomCertificationValidator_30() { return &___CustomCertificationValidator_30; }
	inline void set_CustomCertificationValidator_30(Func_4_t3321346088 * value)
	{
		___CustomCertificationValidator_30 = value;
		Il2CppCodeGenWriteBarrier(&___CustomCertificationValidator_30, value);
	}

	inline static int32_t get_offset_of_U3CConnectTimeoutU3Ek__BackingField_31() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CConnectTimeoutU3Ek__BackingField_31)); }
	inline TimeSpan_t3430258949  get_U3CConnectTimeoutU3Ek__BackingField_31() const { return ___U3CConnectTimeoutU3Ek__BackingField_31; }
	inline TimeSpan_t3430258949 * get_address_of_U3CConnectTimeoutU3Ek__BackingField_31() { return &___U3CConnectTimeoutU3Ek__BackingField_31; }
	inline void set_U3CConnectTimeoutU3Ek__BackingField_31(TimeSpan_t3430258949  value)
	{
		___U3CConnectTimeoutU3Ek__BackingField_31 = value;
	}

	inline static int32_t get_offset_of_U3CTimeoutU3Ek__BackingField_32() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CTimeoutU3Ek__BackingField_32)); }
	inline TimeSpan_t3430258949  get_U3CTimeoutU3Ek__BackingField_32() const { return ___U3CTimeoutU3Ek__BackingField_32; }
	inline TimeSpan_t3430258949 * get_address_of_U3CTimeoutU3Ek__BackingField_32() { return &___U3CTimeoutU3Ek__BackingField_32; }
	inline void set_U3CTimeoutU3Ek__BackingField_32(TimeSpan_t3430258949  value)
	{
		___U3CTimeoutU3Ek__BackingField_32 = value;
	}

	inline static int32_t get_offset_of_U3CEnableTimoutForStreamingU3Ek__BackingField_33() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CEnableTimoutForStreamingU3Ek__BackingField_33)); }
	inline bool get_U3CEnableTimoutForStreamingU3Ek__BackingField_33() const { return ___U3CEnableTimoutForStreamingU3Ek__BackingField_33; }
	inline bool* get_address_of_U3CEnableTimoutForStreamingU3Ek__BackingField_33() { return &___U3CEnableTimoutForStreamingU3Ek__BackingField_33; }
	inline void set_U3CEnableTimoutForStreamingU3Ek__BackingField_33(bool value)
	{
		___U3CEnableTimoutForStreamingU3Ek__BackingField_33 = value;
	}

	inline static int32_t get_offset_of_U3CPriorityU3Ek__BackingField_34() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CPriorityU3Ek__BackingField_34)); }
	inline int32_t get_U3CPriorityU3Ek__BackingField_34() const { return ___U3CPriorityU3Ek__BackingField_34; }
	inline int32_t* get_address_of_U3CPriorityU3Ek__BackingField_34() { return &___U3CPriorityU3Ek__BackingField_34; }
	inline void set_U3CPriorityU3Ek__BackingField_34(int32_t value)
	{
		___U3CPriorityU3Ek__BackingField_34 = value;
	}

	inline static int32_t get_offset_of_U3CCustomCertificateVerifyerU3Ek__BackingField_35() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CCustomCertificateVerifyerU3Ek__BackingField_35)); }
	inline Il2CppObject * get_U3CCustomCertificateVerifyerU3Ek__BackingField_35() const { return ___U3CCustomCertificateVerifyerU3Ek__BackingField_35; }
	inline Il2CppObject ** get_address_of_U3CCustomCertificateVerifyerU3Ek__BackingField_35() { return &___U3CCustomCertificateVerifyerU3Ek__BackingField_35; }
	inline void set_U3CCustomCertificateVerifyerU3Ek__BackingField_35(Il2CppObject * value)
	{
		___U3CCustomCertificateVerifyerU3Ek__BackingField_35 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCustomCertificateVerifyerU3Ek__BackingField_35, value);
	}

	inline static int32_t get_offset_of_U3CCustomClientCredentialsProviderU3Ek__BackingField_36() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CCustomClientCredentialsProviderU3Ek__BackingField_36)); }
	inline Il2CppObject * get_U3CCustomClientCredentialsProviderU3Ek__BackingField_36() const { return ___U3CCustomClientCredentialsProviderU3Ek__BackingField_36; }
	inline Il2CppObject ** get_address_of_U3CCustomClientCredentialsProviderU3Ek__BackingField_36() { return &___U3CCustomClientCredentialsProviderU3Ek__BackingField_36; }
	inline void set_U3CCustomClientCredentialsProviderU3Ek__BackingField_36(Il2CppObject * value)
	{
		___U3CCustomClientCredentialsProviderU3Ek__BackingField_36 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCustomClientCredentialsProviderU3Ek__BackingField_36, value);
	}

	inline static int32_t get_offset_of_U3CProtocolHandlerU3Ek__BackingField_37() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CProtocolHandlerU3Ek__BackingField_37)); }
	inline int32_t get_U3CProtocolHandlerU3Ek__BackingField_37() const { return ___U3CProtocolHandlerU3Ek__BackingField_37; }
	inline int32_t* get_address_of_U3CProtocolHandlerU3Ek__BackingField_37() { return &___U3CProtocolHandlerU3Ek__BackingField_37; }
	inline void set_U3CProtocolHandlerU3Ek__BackingField_37(int32_t value)
	{
		___U3CProtocolHandlerU3Ek__BackingField_37 = value;
	}

	inline static int32_t get_offset_of_onBeforeRedirection_38() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___onBeforeRedirection_38)); }
	inline OnBeforeRedirectionDelegate_t290558967 * get_onBeforeRedirection_38() const { return ___onBeforeRedirection_38; }
	inline OnBeforeRedirectionDelegate_t290558967 ** get_address_of_onBeforeRedirection_38() { return &___onBeforeRedirection_38; }
	inline void set_onBeforeRedirection_38(OnBeforeRedirectionDelegate_t290558967 * value)
	{
		___onBeforeRedirection_38 = value;
		Il2CppCodeGenWriteBarrier(&___onBeforeRedirection_38, value);
	}

	inline static int32_t get_offset_of_U3CDownloadedU3Ek__BackingField_39() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CDownloadedU3Ek__BackingField_39)); }
	inline int32_t get_U3CDownloadedU3Ek__BackingField_39() const { return ___U3CDownloadedU3Ek__BackingField_39; }
	inline int32_t* get_address_of_U3CDownloadedU3Ek__BackingField_39() { return &___U3CDownloadedU3Ek__BackingField_39; }
	inline void set_U3CDownloadedU3Ek__BackingField_39(int32_t value)
	{
		___U3CDownloadedU3Ek__BackingField_39 = value;
	}

	inline static int32_t get_offset_of_U3CDownloadLengthU3Ek__BackingField_40() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CDownloadLengthU3Ek__BackingField_40)); }
	inline int32_t get_U3CDownloadLengthU3Ek__BackingField_40() const { return ___U3CDownloadLengthU3Ek__BackingField_40; }
	inline int32_t* get_address_of_U3CDownloadLengthU3Ek__BackingField_40() { return &___U3CDownloadLengthU3Ek__BackingField_40; }
	inline void set_U3CDownloadLengthU3Ek__BackingField_40(int32_t value)
	{
		___U3CDownloadLengthU3Ek__BackingField_40 = value;
	}

	inline static int32_t get_offset_of_U3CDownloadProgressChangedU3Ek__BackingField_41() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CDownloadProgressChangedU3Ek__BackingField_41)); }
	inline bool get_U3CDownloadProgressChangedU3Ek__BackingField_41() const { return ___U3CDownloadProgressChangedU3Ek__BackingField_41; }
	inline bool* get_address_of_U3CDownloadProgressChangedU3Ek__BackingField_41() { return &___U3CDownloadProgressChangedU3Ek__BackingField_41; }
	inline void set_U3CDownloadProgressChangedU3Ek__BackingField_41(bool value)
	{
		___U3CDownloadProgressChangedU3Ek__BackingField_41 = value;
	}

	inline static int32_t get_offset_of_U3CUploadedU3Ek__BackingField_42() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUploadedU3Ek__BackingField_42)); }
	inline int64_t get_U3CUploadedU3Ek__BackingField_42() const { return ___U3CUploadedU3Ek__BackingField_42; }
	inline int64_t* get_address_of_U3CUploadedU3Ek__BackingField_42() { return &___U3CUploadedU3Ek__BackingField_42; }
	inline void set_U3CUploadedU3Ek__BackingField_42(int64_t value)
	{
		___U3CUploadedU3Ek__BackingField_42 = value;
	}

	inline static int32_t get_offset_of_U3CUploadLengthU3Ek__BackingField_43() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUploadLengthU3Ek__BackingField_43)); }
	inline int64_t get_U3CUploadLengthU3Ek__BackingField_43() const { return ___U3CUploadLengthU3Ek__BackingField_43; }
	inline int64_t* get_address_of_U3CUploadLengthU3Ek__BackingField_43() { return &___U3CUploadLengthU3Ek__BackingField_43; }
	inline void set_U3CUploadLengthU3Ek__BackingField_43(int64_t value)
	{
		___U3CUploadLengthU3Ek__BackingField_43 = value;
	}

	inline static int32_t get_offset_of_U3CUploadProgressChangedU3Ek__BackingField_44() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CUploadProgressChangedU3Ek__BackingField_44)); }
	inline bool get_U3CUploadProgressChangedU3Ek__BackingField_44() const { return ___U3CUploadProgressChangedU3Ek__BackingField_44; }
	inline bool* get_address_of_U3CUploadProgressChangedU3Ek__BackingField_44() { return &___U3CUploadProgressChangedU3Ek__BackingField_44; }
	inline void set_U3CUploadProgressChangedU3Ek__BackingField_44(bool value)
	{
		___U3CUploadProgressChangedU3Ek__BackingField_44 = value;
	}

	inline static int32_t get_offset_of_isKeepAlive_45() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___isKeepAlive_45)); }
	inline bool get_isKeepAlive_45() const { return ___isKeepAlive_45; }
	inline bool* get_address_of_isKeepAlive_45() { return &___isKeepAlive_45; }
	inline void set_isKeepAlive_45(bool value)
	{
		___isKeepAlive_45 = value;
	}

	inline static int32_t get_offset_of_disableCache_46() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___disableCache_46)); }
	inline bool get_disableCache_46() const { return ___disableCache_46; }
	inline bool* get_address_of_disableCache_46() { return &___disableCache_46; }
	inline void set_disableCache_46(bool value)
	{
		___disableCache_46 = value;
	}

	inline static int32_t get_offset_of_cacheTime_47() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___cacheTime_47)); }
	inline int32_t get_cacheTime_47() const { return ___cacheTime_47; }
	inline int32_t* get_address_of_cacheTime_47() { return &___cacheTime_47; }
	inline void set_cacheTime_47(int32_t value)
	{
		___cacheTime_47 = value;
	}

	inline static int32_t get_offset_of_streamFragmentSize_48() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___streamFragmentSize_48)); }
	inline int32_t get_streamFragmentSize_48() const { return ___streamFragmentSize_48; }
	inline int32_t* get_address_of_streamFragmentSize_48() { return &___streamFragmentSize_48; }
	inline void set_streamFragmentSize_48(int32_t value)
	{
		___streamFragmentSize_48 = value;
	}

	inline static int32_t get_offset_of_useStreaming_49() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___useStreaming_49)); }
	inline bool get_useStreaming_49() const { return ___useStreaming_49; }
	inline bool* get_address_of_useStreaming_49() { return &___useStreaming_49; }
	inline void set_useStreaming_49(bool value)
	{
		___useStreaming_49 = value;
	}

	inline static int32_t get_offset_of_U3CHeadersU3Ek__BackingField_50() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___U3CHeadersU3Ek__BackingField_50)); }
	inline Dictionary_2_t3313120627 * get_U3CHeadersU3Ek__BackingField_50() const { return ___U3CHeadersU3Ek__BackingField_50; }
	inline Dictionary_2_t3313120627 ** get_address_of_U3CHeadersU3Ek__BackingField_50() { return &___U3CHeadersU3Ek__BackingField_50; }
	inline void set_U3CHeadersU3Ek__BackingField_50(Dictionary_2_t3313120627 * value)
	{
		___U3CHeadersU3Ek__BackingField_50 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHeadersU3Ek__BackingField_50, value);
	}

	inline static int32_t get_offset_of_FieldCollector_51() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___FieldCollector_51)); }
	inline HTTPFormBase_t1912072923 * get_FieldCollector_51() const { return ___FieldCollector_51; }
	inline HTTPFormBase_t1912072923 ** get_address_of_FieldCollector_51() { return &___FieldCollector_51; }
	inline void set_FieldCollector_51(HTTPFormBase_t1912072923 * value)
	{
		___FieldCollector_51 = value;
		Il2CppCodeGenWriteBarrier(&___FieldCollector_51, value);
	}

	inline static int32_t get_offset_of_FormImpl_52() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887, ___FormImpl_52)); }
	inline HTTPFormBase_t1912072923 * get_FormImpl_52() const { return ___FormImpl_52; }
	inline HTTPFormBase_t1912072923 ** get_address_of_FormImpl_52() { return &___FormImpl_52; }
	inline void set_FormImpl_52(HTTPFormBase_t1912072923 * value)
	{
		___FormImpl_52 = value;
		Il2CppCodeGenWriteBarrier(&___FormImpl_52, value);
	}
};

struct HTTPRequest_t138485887_StaticFields
{
public:
	// System.Byte[] BestHTTP.HTTPRequest::EOL
	ByteU5BU5D_t3397334013* ___EOL_0;
	// System.String[] BestHTTP.HTTPRequest::MethodNames
	StringU5BU5D_t1642385972* ___MethodNames_1;
	// System.Int32 BestHTTP.HTTPRequest::UploadChunkSize
	int32_t ___UploadChunkSize_2;

public:
	inline static int32_t get_offset_of_EOL_0() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887_StaticFields, ___EOL_0)); }
	inline ByteU5BU5D_t3397334013* get_EOL_0() const { return ___EOL_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_EOL_0() { return &___EOL_0; }
	inline void set_EOL_0(ByteU5BU5D_t3397334013* value)
	{
		___EOL_0 = value;
		Il2CppCodeGenWriteBarrier(&___EOL_0, value);
	}

	inline static int32_t get_offset_of_MethodNames_1() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887_StaticFields, ___MethodNames_1)); }
	inline StringU5BU5D_t1642385972* get_MethodNames_1() const { return ___MethodNames_1; }
	inline StringU5BU5D_t1642385972** get_address_of_MethodNames_1() { return &___MethodNames_1; }
	inline void set_MethodNames_1(StringU5BU5D_t1642385972* value)
	{
		___MethodNames_1 = value;
		Il2CppCodeGenWriteBarrier(&___MethodNames_1, value);
	}

	inline static int32_t get_offset_of_UploadChunkSize_2() { return static_cast<int32_t>(offsetof(HTTPRequest_t138485887_StaticFields, ___UploadChunkSize_2)); }
	inline int32_t get_UploadChunkSize_2() const { return ___UploadChunkSize_2; }
	inline int32_t* get_address_of_UploadChunkSize_2() { return &___UploadChunkSize_2; }
	inline void set_UploadChunkSize_2(int32_t value)
	{
		___UploadChunkSize_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
