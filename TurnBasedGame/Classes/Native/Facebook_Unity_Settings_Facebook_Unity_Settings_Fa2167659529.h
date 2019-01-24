#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"

// System.String
struct String_t;
// System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings/OnChangeCallback>
struct List_1_t2008310816;
// Facebook.Unity.Settings.FacebookSettings
struct FacebookSettings_t2167659529;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;
// System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings/UrlSchemes>
struct List_1_t1435751405;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Settings.FacebookSettings
struct  FacebookSettings_t2167659529  : public ScriptableObject_t1975622470
{
public:
	// System.Int32 Facebook.Unity.Settings.FacebookSettings::selectedAppIndex
	int32_t ___selectedAppIndex_7;
	// System.Collections.Generic.List`1<System.String> Facebook.Unity.Settings.FacebookSettings::clientTokens
	List_1_t1398341365 * ___clientTokens_8;
	// System.Collections.Generic.List`1<System.String> Facebook.Unity.Settings.FacebookSettings::appIds
	List_1_t1398341365 * ___appIds_9;
	// System.Collections.Generic.List`1<System.String> Facebook.Unity.Settings.FacebookSettings::appLabels
	List_1_t1398341365 * ___appLabels_10;
	// System.Boolean Facebook.Unity.Settings.FacebookSettings::cookie
	bool ___cookie_11;
	// System.Boolean Facebook.Unity.Settings.FacebookSettings::logging
	bool ___logging_12;
	// System.Boolean Facebook.Unity.Settings.FacebookSettings::status
	bool ___status_13;
	// System.Boolean Facebook.Unity.Settings.FacebookSettings::xfbml
	bool ___xfbml_14;
	// System.Boolean Facebook.Unity.Settings.FacebookSettings::frictionlessRequests
	bool ___frictionlessRequests_15;
	// System.String Facebook.Unity.Settings.FacebookSettings::iosURLSuffix
	String_t* ___iosURLSuffix_16;
	// System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings/UrlSchemes> Facebook.Unity.Settings.FacebookSettings::appLinkSchemes
	List_1_t1435751405 * ___appLinkSchemes_17;
	// System.String Facebook.Unity.Settings.FacebookSettings::uploadAccessToken
	String_t* ___uploadAccessToken_18;

public:
	inline static int32_t get_offset_of_selectedAppIndex_7() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___selectedAppIndex_7)); }
	inline int32_t get_selectedAppIndex_7() const { return ___selectedAppIndex_7; }
	inline int32_t* get_address_of_selectedAppIndex_7() { return &___selectedAppIndex_7; }
	inline void set_selectedAppIndex_7(int32_t value)
	{
		___selectedAppIndex_7 = value;
	}

	inline static int32_t get_offset_of_clientTokens_8() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___clientTokens_8)); }
	inline List_1_t1398341365 * get_clientTokens_8() const { return ___clientTokens_8; }
	inline List_1_t1398341365 ** get_address_of_clientTokens_8() { return &___clientTokens_8; }
	inline void set_clientTokens_8(List_1_t1398341365 * value)
	{
		___clientTokens_8 = value;
		Il2CppCodeGenWriteBarrier(&___clientTokens_8, value);
	}

	inline static int32_t get_offset_of_appIds_9() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___appIds_9)); }
	inline List_1_t1398341365 * get_appIds_9() const { return ___appIds_9; }
	inline List_1_t1398341365 ** get_address_of_appIds_9() { return &___appIds_9; }
	inline void set_appIds_9(List_1_t1398341365 * value)
	{
		___appIds_9 = value;
		Il2CppCodeGenWriteBarrier(&___appIds_9, value);
	}

	inline static int32_t get_offset_of_appLabels_10() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___appLabels_10)); }
	inline List_1_t1398341365 * get_appLabels_10() const { return ___appLabels_10; }
	inline List_1_t1398341365 ** get_address_of_appLabels_10() { return &___appLabels_10; }
	inline void set_appLabels_10(List_1_t1398341365 * value)
	{
		___appLabels_10 = value;
		Il2CppCodeGenWriteBarrier(&___appLabels_10, value);
	}

	inline static int32_t get_offset_of_cookie_11() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___cookie_11)); }
	inline bool get_cookie_11() const { return ___cookie_11; }
	inline bool* get_address_of_cookie_11() { return &___cookie_11; }
	inline void set_cookie_11(bool value)
	{
		___cookie_11 = value;
	}

	inline static int32_t get_offset_of_logging_12() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___logging_12)); }
	inline bool get_logging_12() const { return ___logging_12; }
	inline bool* get_address_of_logging_12() { return &___logging_12; }
	inline void set_logging_12(bool value)
	{
		___logging_12 = value;
	}

	inline static int32_t get_offset_of_status_13() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___status_13)); }
	inline bool get_status_13() const { return ___status_13; }
	inline bool* get_address_of_status_13() { return &___status_13; }
	inline void set_status_13(bool value)
	{
		___status_13 = value;
	}

	inline static int32_t get_offset_of_xfbml_14() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___xfbml_14)); }
	inline bool get_xfbml_14() const { return ___xfbml_14; }
	inline bool* get_address_of_xfbml_14() { return &___xfbml_14; }
	inline void set_xfbml_14(bool value)
	{
		___xfbml_14 = value;
	}

	inline static int32_t get_offset_of_frictionlessRequests_15() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___frictionlessRequests_15)); }
	inline bool get_frictionlessRequests_15() const { return ___frictionlessRequests_15; }
	inline bool* get_address_of_frictionlessRequests_15() { return &___frictionlessRequests_15; }
	inline void set_frictionlessRequests_15(bool value)
	{
		___frictionlessRequests_15 = value;
	}

	inline static int32_t get_offset_of_iosURLSuffix_16() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___iosURLSuffix_16)); }
	inline String_t* get_iosURLSuffix_16() const { return ___iosURLSuffix_16; }
	inline String_t** get_address_of_iosURLSuffix_16() { return &___iosURLSuffix_16; }
	inline void set_iosURLSuffix_16(String_t* value)
	{
		___iosURLSuffix_16 = value;
		Il2CppCodeGenWriteBarrier(&___iosURLSuffix_16, value);
	}

	inline static int32_t get_offset_of_appLinkSchemes_17() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___appLinkSchemes_17)); }
	inline List_1_t1435751405 * get_appLinkSchemes_17() const { return ___appLinkSchemes_17; }
	inline List_1_t1435751405 ** get_address_of_appLinkSchemes_17() { return &___appLinkSchemes_17; }
	inline void set_appLinkSchemes_17(List_1_t1435751405 * value)
	{
		___appLinkSchemes_17 = value;
		Il2CppCodeGenWriteBarrier(&___appLinkSchemes_17, value);
	}

	inline static int32_t get_offset_of_uploadAccessToken_18() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529, ___uploadAccessToken_18)); }
	inline String_t* get_uploadAccessToken_18() const { return ___uploadAccessToken_18; }
	inline String_t** get_address_of_uploadAccessToken_18() { return &___uploadAccessToken_18; }
	inline void set_uploadAccessToken_18(String_t* value)
	{
		___uploadAccessToken_18 = value;
		Il2CppCodeGenWriteBarrier(&___uploadAccessToken_18, value);
	}
};

struct FacebookSettings_t2167659529_StaticFields
{
public:
	// System.Collections.Generic.List`1<Facebook.Unity.Settings.FacebookSettings/OnChangeCallback> Facebook.Unity.Settings.FacebookSettings::onChangeCallbacks
	List_1_t2008310816 * ___onChangeCallbacks_5;
	// Facebook.Unity.Settings.FacebookSettings Facebook.Unity.Settings.FacebookSettings::instance
	FacebookSettings_t2167659529 * ___instance_6;

public:
	inline static int32_t get_offset_of_onChangeCallbacks_5() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529_StaticFields, ___onChangeCallbacks_5)); }
	inline List_1_t2008310816 * get_onChangeCallbacks_5() const { return ___onChangeCallbacks_5; }
	inline List_1_t2008310816 ** get_address_of_onChangeCallbacks_5() { return &___onChangeCallbacks_5; }
	inline void set_onChangeCallbacks_5(List_1_t2008310816 * value)
	{
		___onChangeCallbacks_5 = value;
		Il2CppCodeGenWriteBarrier(&___onChangeCallbacks_5, value);
	}

	inline static int32_t get_offset_of_instance_6() { return static_cast<int32_t>(offsetof(FacebookSettings_t2167659529_StaticFields, ___instance_6)); }
	inline FacebookSettings_t2167659529 * get_instance_6() const { return ___instance_6; }
	inline FacebookSettings_t2167659529 ** get_address_of_instance_6() { return &___instance_6; }
	inline void set_instance_6(FacebookSettings_t2167659529 * value)
	{
		___instance_6 = value;
		Il2CppCodeGenWriteBarrier(&___instance_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
