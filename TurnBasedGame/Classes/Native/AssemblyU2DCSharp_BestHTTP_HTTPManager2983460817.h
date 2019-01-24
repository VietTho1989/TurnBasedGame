#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_TimeSpan3430258949.h"

// System.Func`1<System.String>
struct Func_1_t3983612915;
// BestHTTP.HTTPProxy
struct HTTPProxy_t2644053826;
// BestHTTP.Extensions.HeartbeatManager
struct HeartbeatManager_t895236645;
// BestHTTP.Logger.ILogger
struct ILogger_t2372156491;
// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer
struct ICertificateVerifyer_t565084154;
// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider
struct IClientCredentialsProvider_t3199932449;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<BestHTTP.ConnectionBase>>
struct Dictionary_2_t4066091123;
// System.Collections.Generic.List`1<BestHTTP.ConnectionBase>
struct List_1_t2151311861;
// System.Collections.Generic.List`1<BestHTTP.HTTPRequest>
struct List_1_t3802574315;
// System.Object
struct Il2CppObject;
// BestHTTP.HTTPConnectionRecycledDelegate
struct HTTPConnectionRecycledDelegate_t3354195806;
// System.Predicate`1<BestHTTP.HTTPRequest>
struct Predicate_1_t2876423298;
// System.Comparison`1<BestHTTP.HTTPRequest>
struct Comparison_1_t1400224738;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPManager
struct  HTTPManager_t2983460817  : public Il2CppObject
{
public:

public:
};

struct HTTPManager_t2983460817_StaticFields
{
public:
	// System.Byte BestHTTP.HTTPManager::maxConnectionPerServer
	uint8_t ___maxConnectionPerServer_0;
	// System.Boolean BestHTTP.HTTPManager::<KeepAliveDefaultValue>k__BackingField
	bool ___U3CKeepAliveDefaultValueU3Ek__BackingField_1;
	// System.Boolean BestHTTP.HTTPManager::<IsCachingDisabled>k__BackingField
	bool ___U3CIsCachingDisabledU3Ek__BackingField_2;
	// System.TimeSpan BestHTTP.HTTPManager::<MaxConnectionIdleTime>k__BackingField
	TimeSpan_t3430258949  ___U3CMaxConnectionIdleTimeU3Ek__BackingField_3;
	// System.Boolean BestHTTP.HTTPManager::<IsCookiesEnabled>k__BackingField
	bool ___U3CIsCookiesEnabledU3Ek__BackingField_4;
	// System.UInt32 BestHTTP.HTTPManager::<CookieJarSize>k__BackingField
	uint32_t ___U3CCookieJarSizeU3Ek__BackingField_5;
	// System.Boolean BestHTTP.HTTPManager::<EnablePrivateBrowsing>k__BackingField
	bool ___U3CEnablePrivateBrowsingU3Ek__BackingField_6;
	// System.TimeSpan BestHTTP.HTTPManager::<ConnectTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CConnectTimeoutU3Ek__BackingField_7;
	// System.TimeSpan BestHTTP.HTTPManager::<RequestTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CRequestTimeoutU3Ek__BackingField_8;
	// System.Func`1<System.String> BestHTTP.HTTPManager::<RootCacheFolderProvider>k__BackingField
	Func_1_t3983612915 * ___U3CRootCacheFolderProviderU3Ek__BackingField_9;
	// BestHTTP.HTTPProxy BestHTTP.HTTPManager::<Proxy>k__BackingField
	HTTPProxy_t2644053826 * ___U3CProxyU3Ek__BackingField_10;
	// BestHTTP.Extensions.HeartbeatManager BestHTTP.HTTPManager::heartbeats
	HeartbeatManager_t895236645 * ___heartbeats_11;
	// BestHTTP.Logger.ILogger BestHTTP.HTTPManager::logger
	Il2CppObject * ___logger_12;
	// Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer BestHTTP.HTTPManager::<DefaultCertificateVerifyer>k__BackingField
	Il2CppObject * ___U3CDefaultCertificateVerifyerU3Ek__BackingField_13;
	// Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider BestHTTP.HTTPManager::<DefaultClientCredentialsProvider>k__BackingField
	Il2CppObject * ___U3CDefaultClientCredentialsProviderU3Ek__BackingField_14;
	// System.Boolean BestHTTP.HTTPManager::<UseAlternateSSLDefaultValue>k__BackingField
	bool ___U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15;
	// System.Int32 BestHTTP.HTTPManager::<MaxPathLength>k__BackingField
	int32_t ___U3CMaxPathLengthU3Ek__BackingField_16;
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<BestHTTP.ConnectionBase>> BestHTTP.HTTPManager::Connections
	Dictionary_2_t4066091123 * ___Connections_17;
	// System.Collections.Generic.List`1<BestHTTP.ConnectionBase> BestHTTP.HTTPManager::ActiveConnections
	List_1_t2151311861 * ___ActiveConnections_18;
	// System.Collections.Generic.List`1<BestHTTP.ConnectionBase> BestHTTP.HTTPManager::FreeConnections
	List_1_t2151311861 * ___FreeConnections_19;
	// System.Collections.Generic.List`1<BestHTTP.ConnectionBase> BestHTTP.HTTPManager::RecycledConnections
	List_1_t2151311861 * ___RecycledConnections_20;
	// System.Collections.Generic.List`1<BestHTTP.HTTPRequest> BestHTTP.HTTPManager::RequestQueue
	List_1_t3802574315 * ___RequestQueue_21;
	// System.Boolean BestHTTP.HTTPManager::IsCallingCallbacks
	bool ___IsCallingCallbacks_22;
	// System.Object BestHTTP.HTTPManager::Locker
	Il2CppObject * ___Locker_23;
	// BestHTTP.HTTPConnectionRecycledDelegate BestHTTP.HTTPManager::<>f__mg$cache0
	HTTPConnectionRecycledDelegate_t3354195806 * ___U3CU3Ef__mgU24cache0_24;
	// System.Predicate`1<BestHTTP.HTTPRequest> BestHTTP.HTTPManager::<>f__am$cache0
	Predicate_1_t2876423298 * ___U3CU3Ef__amU24cache0_25;
	// System.Comparison`1<BestHTTP.HTTPRequest> BestHTTP.HTTPManager::<>f__am$cache1
	Comparison_1_t1400224738 * ___U3CU3Ef__amU24cache1_26;

public:
	inline static int32_t get_offset_of_maxConnectionPerServer_0() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___maxConnectionPerServer_0)); }
	inline uint8_t get_maxConnectionPerServer_0() const { return ___maxConnectionPerServer_0; }
	inline uint8_t* get_address_of_maxConnectionPerServer_0() { return &___maxConnectionPerServer_0; }
	inline void set_maxConnectionPerServer_0(uint8_t value)
	{
		___maxConnectionPerServer_0 = value;
	}

	inline static int32_t get_offset_of_U3CKeepAliveDefaultValueU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CKeepAliveDefaultValueU3Ek__BackingField_1)); }
	inline bool get_U3CKeepAliveDefaultValueU3Ek__BackingField_1() const { return ___U3CKeepAliveDefaultValueU3Ek__BackingField_1; }
	inline bool* get_address_of_U3CKeepAliveDefaultValueU3Ek__BackingField_1() { return &___U3CKeepAliveDefaultValueU3Ek__BackingField_1; }
	inline void set_U3CKeepAliveDefaultValueU3Ek__BackingField_1(bool value)
	{
		___U3CKeepAliveDefaultValueU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CIsCachingDisabledU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CIsCachingDisabledU3Ek__BackingField_2)); }
	inline bool get_U3CIsCachingDisabledU3Ek__BackingField_2() const { return ___U3CIsCachingDisabledU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CIsCachingDisabledU3Ek__BackingField_2() { return &___U3CIsCachingDisabledU3Ek__BackingField_2; }
	inline void set_U3CIsCachingDisabledU3Ek__BackingField_2(bool value)
	{
		___U3CIsCachingDisabledU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CMaxConnectionIdleTimeU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CMaxConnectionIdleTimeU3Ek__BackingField_3)); }
	inline TimeSpan_t3430258949  get_U3CMaxConnectionIdleTimeU3Ek__BackingField_3() const { return ___U3CMaxConnectionIdleTimeU3Ek__BackingField_3; }
	inline TimeSpan_t3430258949 * get_address_of_U3CMaxConnectionIdleTimeU3Ek__BackingField_3() { return &___U3CMaxConnectionIdleTimeU3Ek__BackingField_3; }
	inline void set_U3CMaxConnectionIdleTimeU3Ek__BackingField_3(TimeSpan_t3430258949  value)
	{
		___U3CMaxConnectionIdleTimeU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CIsCookiesEnabledU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CIsCookiesEnabledU3Ek__BackingField_4)); }
	inline bool get_U3CIsCookiesEnabledU3Ek__BackingField_4() const { return ___U3CIsCookiesEnabledU3Ek__BackingField_4; }
	inline bool* get_address_of_U3CIsCookiesEnabledU3Ek__BackingField_4() { return &___U3CIsCookiesEnabledU3Ek__BackingField_4; }
	inline void set_U3CIsCookiesEnabledU3Ek__BackingField_4(bool value)
	{
		___U3CIsCookiesEnabledU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CCookieJarSizeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CCookieJarSizeU3Ek__BackingField_5)); }
	inline uint32_t get_U3CCookieJarSizeU3Ek__BackingField_5() const { return ___U3CCookieJarSizeU3Ek__BackingField_5; }
	inline uint32_t* get_address_of_U3CCookieJarSizeU3Ek__BackingField_5() { return &___U3CCookieJarSizeU3Ek__BackingField_5; }
	inline void set_U3CCookieJarSizeU3Ek__BackingField_5(uint32_t value)
	{
		___U3CCookieJarSizeU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CEnablePrivateBrowsingU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CEnablePrivateBrowsingU3Ek__BackingField_6)); }
	inline bool get_U3CEnablePrivateBrowsingU3Ek__BackingField_6() const { return ___U3CEnablePrivateBrowsingU3Ek__BackingField_6; }
	inline bool* get_address_of_U3CEnablePrivateBrowsingU3Ek__BackingField_6() { return &___U3CEnablePrivateBrowsingU3Ek__BackingField_6; }
	inline void set_U3CEnablePrivateBrowsingU3Ek__BackingField_6(bool value)
	{
		___U3CEnablePrivateBrowsingU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of_U3CConnectTimeoutU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CConnectTimeoutU3Ek__BackingField_7)); }
	inline TimeSpan_t3430258949  get_U3CConnectTimeoutU3Ek__BackingField_7() const { return ___U3CConnectTimeoutU3Ek__BackingField_7; }
	inline TimeSpan_t3430258949 * get_address_of_U3CConnectTimeoutU3Ek__BackingField_7() { return &___U3CConnectTimeoutU3Ek__BackingField_7; }
	inline void set_U3CConnectTimeoutU3Ek__BackingField_7(TimeSpan_t3430258949  value)
	{
		___U3CConnectTimeoutU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CRequestTimeoutU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CRequestTimeoutU3Ek__BackingField_8)); }
	inline TimeSpan_t3430258949  get_U3CRequestTimeoutU3Ek__BackingField_8() const { return ___U3CRequestTimeoutU3Ek__BackingField_8; }
	inline TimeSpan_t3430258949 * get_address_of_U3CRequestTimeoutU3Ek__BackingField_8() { return &___U3CRequestTimeoutU3Ek__BackingField_8; }
	inline void set_U3CRequestTimeoutU3Ek__BackingField_8(TimeSpan_t3430258949  value)
	{
		___U3CRequestTimeoutU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CRootCacheFolderProviderU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CRootCacheFolderProviderU3Ek__BackingField_9)); }
	inline Func_1_t3983612915 * get_U3CRootCacheFolderProviderU3Ek__BackingField_9() const { return ___U3CRootCacheFolderProviderU3Ek__BackingField_9; }
	inline Func_1_t3983612915 ** get_address_of_U3CRootCacheFolderProviderU3Ek__BackingField_9() { return &___U3CRootCacheFolderProviderU3Ek__BackingField_9; }
	inline void set_U3CRootCacheFolderProviderU3Ek__BackingField_9(Func_1_t3983612915 * value)
	{
		___U3CRootCacheFolderProviderU3Ek__BackingField_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRootCacheFolderProviderU3Ek__BackingField_9, value);
	}

	inline static int32_t get_offset_of_U3CProxyU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CProxyU3Ek__BackingField_10)); }
	inline HTTPProxy_t2644053826 * get_U3CProxyU3Ek__BackingField_10() const { return ___U3CProxyU3Ek__BackingField_10; }
	inline HTTPProxy_t2644053826 ** get_address_of_U3CProxyU3Ek__BackingField_10() { return &___U3CProxyU3Ek__BackingField_10; }
	inline void set_U3CProxyU3Ek__BackingField_10(HTTPProxy_t2644053826 * value)
	{
		___U3CProxyU3Ek__BackingField_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CProxyU3Ek__BackingField_10, value);
	}

	inline static int32_t get_offset_of_heartbeats_11() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___heartbeats_11)); }
	inline HeartbeatManager_t895236645 * get_heartbeats_11() const { return ___heartbeats_11; }
	inline HeartbeatManager_t895236645 ** get_address_of_heartbeats_11() { return &___heartbeats_11; }
	inline void set_heartbeats_11(HeartbeatManager_t895236645 * value)
	{
		___heartbeats_11 = value;
		Il2CppCodeGenWriteBarrier(&___heartbeats_11, value);
	}

	inline static int32_t get_offset_of_logger_12() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___logger_12)); }
	inline Il2CppObject * get_logger_12() const { return ___logger_12; }
	inline Il2CppObject ** get_address_of_logger_12() { return &___logger_12; }
	inline void set_logger_12(Il2CppObject * value)
	{
		___logger_12 = value;
		Il2CppCodeGenWriteBarrier(&___logger_12, value);
	}

	inline static int32_t get_offset_of_U3CDefaultCertificateVerifyerU3Ek__BackingField_13() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CDefaultCertificateVerifyerU3Ek__BackingField_13)); }
	inline Il2CppObject * get_U3CDefaultCertificateVerifyerU3Ek__BackingField_13() const { return ___U3CDefaultCertificateVerifyerU3Ek__BackingField_13; }
	inline Il2CppObject ** get_address_of_U3CDefaultCertificateVerifyerU3Ek__BackingField_13() { return &___U3CDefaultCertificateVerifyerU3Ek__BackingField_13; }
	inline void set_U3CDefaultCertificateVerifyerU3Ek__BackingField_13(Il2CppObject * value)
	{
		___U3CDefaultCertificateVerifyerU3Ek__BackingField_13 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDefaultCertificateVerifyerU3Ek__BackingField_13, value);
	}

	inline static int32_t get_offset_of_U3CDefaultClientCredentialsProviderU3Ek__BackingField_14() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CDefaultClientCredentialsProviderU3Ek__BackingField_14)); }
	inline Il2CppObject * get_U3CDefaultClientCredentialsProviderU3Ek__BackingField_14() const { return ___U3CDefaultClientCredentialsProviderU3Ek__BackingField_14; }
	inline Il2CppObject ** get_address_of_U3CDefaultClientCredentialsProviderU3Ek__BackingField_14() { return &___U3CDefaultClientCredentialsProviderU3Ek__BackingField_14; }
	inline void set_U3CDefaultClientCredentialsProviderU3Ek__BackingField_14(Il2CppObject * value)
	{
		___U3CDefaultClientCredentialsProviderU3Ek__BackingField_14 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDefaultClientCredentialsProviderU3Ek__BackingField_14, value);
	}

	inline static int32_t get_offset_of_U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15)); }
	inline bool get_U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15() const { return ___U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15; }
	inline bool* get_address_of_U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15() { return &___U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15; }
	inline void set_U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15(bool value)
	{
		___U3CUseAlternateSSLDefaultValueU3Ek__BackingField_15 = value;
	}

	inline static int32_t get_offset_of_U3CMaxPathLengthU3Ek__BackingField_16() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CMaxPathLengthU3Ek__BackingField_16)); }
	inline int32_t get_U3CMaxPathLengthU3Ek__BackingField_16() const { return ___U3CMaxPathLengthU3Ek__BackingField_16; }
	inline int32_t* get_address_of_U3CMaxPathLengthU3Ek__BackingField_16() { return &___U3CMaxPathLengthU3Ek__BackingField_16; }
	inline void set_U3CMaxPathLengthU3Ek__BackingField_16(int32_t value)
	{
		___U3CMaxPathLengthU3Ek__BackingField_16 = value;
	}

	inline static int32_t get_offset_of_Connections_17() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___Connections_17)); }
	inline Dictionary_2_t4066091123 * get_Connections_17() const { return ___Connections_17; }
	inline Dictionary_2_t4066091123 ** get_address_of_Connections_17() { return &___Connections_17; }
	inline void set_Connections_17(Dictionary_2_t4066091123 * value)
	{
		___Connections_17 = value;
		Il2CppCodeGenWriteBarrier(&___Connections_17, value);
	}

	inline static int32_t get_offset_of_ActiveConnections_18() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___ActiveConnections_18)); }
	inline List_1_t2151311861 * get_ActiveConnections_18() const { return ___ActiveConnections_18; }
	inline List_1_t2151311861 ** get_address_of_ActiveConnections_18() { return &___ActiveConnections_18; }
	inline void set_ActiveConnections_18(List_1_t2151311861 * value)
	{
		___ActiveConnections_18 = value;
		Il2CppCodeGenWriteBarrier(&___ActiveConnections_18, value);
	}

	inline static int32_t get_offset_of_FreeConnections_19() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___FreeConnections_19)); }
	inline List_1_t2151311861 * get_FreeConnections_19() const { return ___FreeConnections_19; }
	inline List_1_t2151311861 ** get_address_of_FreeConnections_19() { return &___FreeConnections_19; }
	inline void set_FreeConnections_19(List_1_t2151311861 * value)
	{
		___FreeConnections_19 = value;
		Il2CppCodeGenWriteBarrier(&___FreeConnections_19, value);
	}

	inline static int32_t get_offset_of_RecycledConnections_20() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___RecycledConnections_20)); }
	inline List_1_t2151311861 * get_RecycledConnections_20() const { return ___RecycledConnections_20; }
	inline List_1_t2151311861 ** get_address_of_RecycledConnections_20() { return &___RecycledConnections_20; }
	inline void set_RecycledConnections_20(List_1_t2151311861 * value)
	{
		___RecycledConnections_20 = value;
		Il2CppCodeGenWriteBarrier(&___RecycledConnections_20, value);
	}

	inline static int32_t get_offset_of_RequestQueue_21() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___RequestQueue_21)); }
	inline List_1_t3802574315 * get_RequestQueue_21() const { return ___RequestQueue_21; }
	inline List_1_t3802574315 ** get_address_of_RequestQueue_21() { return &___RequestQueue_21; }
	inline void set_RequestQueue_21(List_1_t3802574315 * value)
	{
		___RequestQueue_21 = value;
		Il2CppCodeGenWriteBarrier(&___RequestQueue_21, value);
	}

	inline static int32_t get_offset_of_IsCallingCallbacks_22() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___IsCallingCallbacks_22)); }
	inline bool get_IsCallingCallbacks_22() const { return ___IsCallingCallbacks_22; }
	inline bool* get_address_of_IsCallingCallbacks_22() { return &___IsCallingCallbacks_22; }
	inline void set_IsCallingCallbacks_22(bool value)
	{
		___IsCallingCallbacks_22 = value;
	}

	inline static int32_t get_offset_of_Locker_23() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___Locker_23)); }
	inline Il2CppObject * get_Locker_23() const { return ___Locker_23; }
	inline Il2CppObject ** get_address_of_Locker_23() { return &___Locker_23; }
	inline void set_Locker_23(Il2CppObject * value)
	{
		___Locker_23 = value;
		Il2CppCodeGenWriteBarrier(&___Locker_23, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_24() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CU3Ef__mgU24cache0_24)); }
	inline HTTPConnectionRecycledDelegate_t3354195806 * get_U3CU3Ef__mgU24cache0_24() const { return ___U3CU3Ef__mgU24cache0_24; }
	inline HTTPConnectionRecycledDelegate_t3354195806 ** get_address_of_U3CU3Ef__mgU24cache0_24() { return &___U3CU3Ef__mgU24cache0_24; }
	inline void set_U3CU3Ef__mgU24cache0_24(HTTPConnectionRecycledDelegate_t3354195806 * value)
	{
		___U3CU3Ef__mgU24cache0_24 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache0_24, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_25() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CU3Ef__amU24cache0_25)); }
	inline Predicate_1_t2876423298 * get_U3CU3Ef__amU24cache0_25() const { return ___U3CU3Ef__amU24cache0_25; }
	inline Predicate_1_t2876423298 ** get_address_of_U3CU3Ef__amU24cache0_25() { return &___U3CU3Ef__amU24cache0_25; }
	inline void set_U3CU3Ef__amU24cache0_25(Predicate_1_t2876423298 * value)
	{
		___U3CU3Ef__amU24cache0_25 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_25, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_26() { return static_cast<int32_t>(offsetof(HTTPManager_t2983460817_StaticFields, ___U3CU3Ef__amU24cache1_26)); }
	inline Comparison_1_t1400224738 * get_U3CU3Ef__amU24cache1_26() const { return ___U3CU3Ef__amU24cache1_26; }
	inline Comparison_1_t1400224738 ** get_address_of_U3CU3Ef__amU24cache1_26() { return &___U3CU3Ef__amU24cache1_26; }
	inline void set_U3CU3Ef__amU24cache1_26(Comparison_1_t1400224738 * value)
	{
		___U3CU3Ef__amU24cache1_26 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
