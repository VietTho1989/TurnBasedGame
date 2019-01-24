#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_Array3829468939.h"
#include "Facebook_Unity_IOS_U3CModuleU3E3783534214.h"
#include "Facebook_Unity_IOS_Facebook_Unity_IOS_IOSWrapper294756590.h"
#include "mscorlib_System_String2029220233.h"
#include "mscorlib_System_Void1841601450.h"
#include "mscorlib_System_Boolean3825574718.h"
#include "mscorlib_System_Int322071877448.h"
#include "mscorlib_System_Double4078015681.h"
#include "mscorlib_System_Object2689449295.h"

// Facebook.Unity.IOS.IOSWrapper
struct IOSWrapper_t294756590;
// System.String
struct String_t;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.Object
struct Il2CppObject;

// System.String[]
struct StringU5BU5D_t1642385972  : public Il2CppArray
{
public:
	ALIGN_FIELD (8) String_t* m_Items[1];

public:
	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};



// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBInit(System.String,System.Boolean,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBInit_m902272037 (Il2CppObject * __this /* static, unused */, String_t* ___appId0, bool ___frictionlessRequests1, String_t* ___urlSuffix2, String_t* ___unityUserAgentSuffix3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBLogInWithReadPermissions(System.Int32,System.String)
extern "C"  void IOSWrapper_IOSFBLogInWithReadPermissions_m1929637458 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___scope1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBLogInWithPublishPermissions(System.Int32,System.String)
extern "C"  void IOSWrapper_IOSFBLogInWithPublishPermissions_m1193287201 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___scope1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBLogOut()
extern "C"  void IOSWrapper_IOSFBLogOut_m1975029250 (Il2CppObject * __this /* static, unused */, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBSetShareDialogMode(System.Int32)
extern "C"  void IOSWrapper_IOSFBSetShareDialogMode_m3394844047 (Il2CppObject * __this /* static, unused */, int32_t ___mode0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBShareLink(System.Int32,System.String,System.String,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBShareLink_m3128905012 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___contentURL1, String_t* ___contentTitle2, String_t* ___contentDescription3, String_t* ___photoURL4, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBFeedShare(System.Int32,System.String,System.String,System.String,System.String,System.String,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBFeedShare_m2674999132 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___toId1, String_t* ___link2, String_t* ___linkName3, String_t* ___linkCaption4, String_t* ___linkDescription5, String_t* ___picture6, String_t* ___mediaSource7, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppRequest(System.Int32,System.String,System.String,System.String,System.String[],System.Int32,System.String,System.String[],System.Int32,System.Boolean,System.Int32,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBAppRequest_m3493977217 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___message1, String_t* ___actionType2, String_t* ___objectId3, StringU5BU5D_t1642385972* ___to4, int32_t ___toLength5, String_t* ___filters6, StringU5BU5D_t1642385972* ___excludeIds7, int32_t ___excludeIdsLength8, bool ___hasMaxRecipients9, int32_t ___maxRecipients10, String_t* ___data11, String_t* ___title12, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppInvite(System.Int32,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBAppInvite_m1414880447 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___appLinkUrl1, String_t* ___previewImageUrl2, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBSettingsActivateApp(System.String)
extern "C"  void IOSWrapper_IOSFBSettingsActivateApp_m797401977 (Il2CppObject * __this /* static, unused */, String_t* ___appId0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppEventsLogEvent(System.String,System.Double,System.Int32,System.String[],System.String[])
extern "C"  void IOSWrapper_IOSFBAppEventsLogEvent_m1319076241 (Il2CppObject * __this /* static, unused */, String_t* ___logEvent0, double ___valueToSum1, int32_t ___numParams2, StringU5BU5D_t1642385972* ___paramKeys3, StringU5BU5D_t1642385972* ___paramVals4, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppEventsLogPurchase(System.Double,System.String,System.Int32,System.String[],System.String[])
extern "C"  void IOSWrapper_IOSFBAppEventsLogPurchase_m1964399802 (Il2CppObject * __this /* static, unused */, double ___logPurchase0, String_t* ___currency1, int32_t ___numParams2, StringU5BU5D_t1642385972* ___paramKeys3, StringU5BU5D_t1642385972* ___paramVals4, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppEventsSetLimitEventUsage(System.Boolean)
extern "C"  void IOSWrapper_IOSFBAppEventsSetLimitEventUsage_m1765600937 (Il2CppObject * __this /* static, unused */, bool ___limitEventUsage0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBGetAppLink(System.Int32)
extern "C"  void IOSWrapper_IOSFBGetAppLink_m459813758 (Il2CppObject * __this /* static, unused */, int32_t ___requestID0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String Facebook.Unity.IOS.IOSWrapper::IOSFBSdkVersion()
extern "C"  String_t* IOSWrapper_IOSFBSdkVersion_m1954204313 (Il2CppObject * __this /* static, unused */, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBFetchDeferredAppLink(System.Int32)
extern "C"  void IOSWrapper_IOSFBFetchDeferredAppLink_m4025468277 (Il2CppObject * __this /* static, unused */, int32_t ___requestID0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBRefreshCurrentAccessToken(System.Int32)
extern "C"  void IOSWrapper_IOSFBRefreshCurrentAccessToken_m1240471684 (Il2CppObject * __this /* static, unused */, int32_t ___requestID0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Object::.ctor()
extern "C"  void Object__ctor_m2551263788 (Il2CppObject * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Facebook.Unity.IOS.IOSWrapper::Init(System.String,System.Boolean,System.String,System.String)
extern "C"  void IOSWrapper_Init_m4044042630 (IOSWrapper_t294756590 * __this, String_t* ___appId0, bool ___frictionlessRequests1, String_t* ___urlSuffix2, String_t* ___unityUserAgentSuffix3, const MethodInfo* method)
{
	{
		String_t* L_0 = ___appId0;
		bool L_1 = ___frictionlessRequests1;
		String_t* L_2 = ___urlSuffix2;
		String_t* L_3 = ___unityUserAgentSuffix3;
		IOSWrapper_IOSFBInit_m902272037(NULL /*static, unused*/, L_0, L_1, L_2, L_3, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::LogInWithReadPermissions(System.Int32,System.String)
extern "C"  void IOSWrapper_LogInWithReadPermissions_m2416395187 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, String_t* ___scope1, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		String_t* L_1 = ___scope1;
		IOSWrapper_IOSFBLogInWithReadPermissions_m1929637458(NULL /*static, unused*/, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::LogInWithPublishPermissions(System.Int32,System.String)
extern "C"  void IOSWrapper_LogInWithPublishPermissions_m1237464384 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, String_t* ___scope1, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		String_t* L_1 = ___scope1;
		IOSWrapper_IOSFBLogInWithPublishPermissions_m1193287201(NULL /*static, unused*/, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::LogOut()
extern "C"  void IOSWrapper_LogOut_m1708493573 (IOSWrapper_t294756590 * __this, const MethodInfo* method)
{
	{
		IOSWrapper_IOSFBLogOut_m1975029250(NULL /*static, unused*/, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::SetShareDialogMode(System.Int32)
extern "C"  void IOSWrapper_SetShareDialogMode_m4089495540 (IOSWrapper_t294756590 * __this, int32_t ___mode0, const MethodInfo* method)
{
	{
		int32_t L_0 = ___mode0;
		IOSWrapper_IOSFBSetShareDialogMode_m3394844047(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::ShareLink(System.Int32,System.String,System.String,System.String,System.String)
extern "C"  void IOSWrapper_ShareLink_m3201753603 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, String_t* ___contentURL1, String_t* ___contentTitle2, String_t* ___contentDescription3, String_t* ___photoURL4, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		String_t* L_1 = ___contentURL1;
		String_t* L_2 = ___contentTitle2;
		String_t* L_3 = ___contentDescription3;
		String_t* L_4 = ___photoURL4;
		IOSWrapper_IOSFBShareLink_m3128905012(NULL /*static, unused*/, L_0, L_1, L_2, L_3, L_4, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::FeedShare(System.Int32,System.String,System.String,System.String,System.String,System.String,System.String,System.String)
extern "C"  void IOSWrapper_FeedShare_m2448783915 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, String_t* ___toId1, String_t* ___link2, String_t* ___linkName3, String_t* ___linkCaption4, String_t* ___linkDescription5, String_t* ___picture6, String_t* ___mediaSource7, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		String_t* L_1 = ___toId1;
		String_t* L_2 = ___link2;
		String_t* L_3 = ___linkName3;
		String_t* L_4 = ___linkCaption4;
		String_t* L_5 = ___linkDescription5;
		String_t* L_6 = ___picture6;
		String_t* L_7 = ___mediaSource7;
		IOSWrapper_IOSFBFeedShare_m2674999132(NULL /*static, unused*/, L_0, L_1, L_2, L_3, L_4, L_5, L_6, L_7, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::AppRequest(System.Int32,System.String,System.String,System.String,System.String[],System.Int32,System.String,System.String[],System.Int32,System.Boolean,System.Int32,System.String,System.String)
extern "C"  void IOSWrapper_AppRequest_m410058696 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, String_t* ___message1, String_t* ___actionType2, String_t* ___objectId3, StringU5BU5D_t1642385972* ___to4, int32_t ___toLength5, String_t* ___filters6, StringU5BU5D_t1642385972* ___excludeIds7, int32_t ___excludeIdsLength8, bool ___hasMaxRecipients9, int32_t ___maxRecipients10, String_t* ___data11, String_t* ___title12, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		String_t* L_1 = ___message1;
		String_t* L_2 = ___actionType2;
		String_t* L_3 = ___objectId3;
		StringU5BU5D_t1642385972* L_4 = ___to4;
		int32_t L_5 = ___toLength5;
		String_t* L_6 = ___filters6;
		StringU5BU5D_t1642385972* L_7 = ___excludeIds7;
		int32_t L_8 = ___excludeIdsLength8;
		bool L_9 = ___hasMaxRecipients9;
		int32_t L_10 = ___maxRecipients10;
		String_t* L_11 = ___data11;
		String_t* L_12 = ___title12;
		IOSWrapper_IOSFBAppRequest_m3493977217(NULL /*static, unused*/, L_0, L_1, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::AppInvite(System.Int32,System.String,System.String)
extern "C"  void IOSWrapper_AppInvite_m3762505178 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, String_t* ___appLinkUrl1, String_t* ___previewImageUrl2, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		String_t* L_1 = ___appLinkUrl1;
		String_t* L_2 = ___previewImageUrl2;
		IOSWrapper_IOSFBAppInvite_m1414880447(NULL /*static, unused*/, L_0, L_1, L_2, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::FBSettingsActivateApp(System.String)
extern "C"  void IOSWrapper_FBSettingsActivateApp_m3904596848 (IOSWrapper_t294756590 * __this, String_t* ___appId0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___appId0;
		IOSWrapper_IOSFBSettingsActivateApp_m797401977(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::LogAppEvent(System.String,System.Double,System.Int32,System.String[],System.String[])
extern "C"  void IOSWrapper_LogAppEvent_m2988588831 (IOSWrapper_t294756590 * __this, String_t* ___logEvent0, double ___valueToSum1, int32_t ___numParams2, StringU5BU5D_t1642385972* ___paramKeys3, StringU5BU5D_t1642385972* ___paramVals4, const MethodInfo* method)
{
	{
		String_t* L_0 = ___logEvent0;
		double L_1 = ___valueToSum1;
		int32_t L_2 = ___numParams2;
		StringU5BU5D_t1642385972* L_3 = ___paramKeys3;
		StringU5BU5D_t1642385972* L_4 = ___paramVals4;
		IOSWrapper_IOSFBAppEventsLogEvent_m1319076241(NULL /*static, unused*/, L_0, L_1, L_2, L_3, L_4, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::LogPurchaseAppEvent(System.Double,System.String,System.Int32,System.String[],System.String[])
extern "C"  void IOSWrapper_LogPurchaseAppEvent_m855950180 (IOSWrapper_t294756590 * __this, double ___logPurchase0, String_t* ___currency1, int32_t ___numParams2, StringU5BU5D_t1642385972* ___paramKeys3, StringU5BU5D_t1642385972* ___paramVals4, const MethodInfo* method)
{
	{
		double L_0 = ___logPurchase0;
		String_t* L_1 = ___currency1;
		int32_t L_2 = ___numParams2;
		StringU5BU5D_t1642385972* L_3 = ___paramKeys3;
		StringU5BU5D_t1642385972* L_4 = ___paramVals4;
		IOSWrapper_IOSFBAppEventsLogPurchase_m1964399802(NULL /*static, unused*/, L_0, L_1, L_2, L_3, L_4, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::FBAppEventsSetLimitEventUsage(System.Boolean)
extern "C"  void IOSWrapper_FBAppEventsSetLimitEventUsage_m3970473682 (IOSWrapper_t294756590 * __this, bool ___limitEventUsage0, const MethodInfo* method)
{
	{
		bool L_0 = ___limitEventUsage0;
		IOSWrapper_IOSFBAppEventsSetLimitEventUsage_m1765600937(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::GetAppLink(System.Int32)
extern "C"  void IOSWrapper_GetAppLink_m2773878673 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		IOSWrapper_IOSFBGetAppLink_m459813758(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.String Facebook.Unity.IOS.IOSWrapper::FBSdkVersion()
extern "C"  String_t* IOSWrapper_FBSdkVersion_m1433820366 (IOSWrapper_t294756590 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = IOSWrapper_IOSFBSdkVersion_m1954204313(NULL /*static, unused*/, /*hidden argument*/NULL);
		return L_0;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::FetchDeferredAppLink(System.Int32)
extern "C"  void IOSWrapper_FetchDeferredAppLink_m3892819798 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		IOSWrapper_IOSFBFetchDeferredAppLink_m4025468277(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Facebook.Unity.IOS.IOSWrapper::RefreshCurrentAccessToken(System.Int32)
extern "C"  void IOSWrapper_RefreshCurrentAccessToken_m2438835001 (IOSWrapper_t294756590 * __this, int32_t ___requestId0, const MethodInfo* method)
{
	{
		int32_t L_0 = ___requestId0;
		IOSWrapper_IOSFBRefreshCurrentAccessToken_m1240471684(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		return;
	}
}
extern "C" void DEFAULT_CALL IOSFBInit(char*, int32_t, char*, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBInit(System.String,System.Boolean,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBInit_m902272037 (Il2CppObject * __this /* static, unused */, String_t* ___appId0, bool ___frictionlessRequests1, String_t* ___urlSuffix2, String_t* ___unityUserAgentSuffix3, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, int32_t, char*, char*);

	// Marshaling of parameter '___appId0' to native representation
	char* ____appId0_marshaled = NULL;
	____appId0_marshaled = il2cpp_codegen_marshal_string(___appId0);

	// Marshaling of parameter '___urlSuffix2' to native representation
	char* ____urlSuffix2_marshaled = NULL;
	____urlSuffix2_marshaled = il2cpp_codegen_marshal_string(___urlSuffix2);

	// Marshaling of parameter '___unityUserAgentSuffix3' to native representation
	char* ____unityUserAgentSuffix3_marshaled = NULL;
	____unityUserAgentSuffix3_marshaled = il2cpp_codegen_marshal_string(___unityUserAgentSuffix3);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBInit)(____appId0_marshaled, static_cast<int32_t>(___frictionlessRequests1), ____urlSuffix2_marshaled, ____unityUserAgentSuffix3_marshaled);

	// Marshaling cleanup of parameter '___appId0' native representation
	il2cpp_codegen_marshal_free(____appId0_marshaled);
	____appId0_marshaled = NULL;

	// Marshaling cleanup of parameter '___urlSuffix2' native representation
	il2cpp_codegen_marshal_free(____urlSuffix2_marshaled);
	____urlSuffix2_marshaled = NULL;

	// Marshaling cleanup of parameter '___unityUserAgentSuffix3' native representation
	il2cpp_codegen_marshal_free(____unityUserAgentSuffix3_marshaled);
	____unityUserAgentSuffix3_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBLogInWithReadPermissions(int32_t, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBLogInWithReadPermissions(System.Int32,System.String)
extern "C"  void IOSWrapper_IOSFBLogInWithReadPermissions_m1929637458 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___scope1, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, char*);

	// Marshaling of parameter '___scope1' to native representation
	char* ____scope1_marshaled = NULL;
	____scope1_marshaled = il2cpp_codegen_marshal_string(___scope1);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBLogInWithReadPermissions)(___requestId0, ____scope1_marshaled);

	// Marshaling cleanup of parameter '___scope1' native representation
	il2cpp_codegen_marshal_free(____scope1_marshaled);
	____scope1_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBLogInWithPublishPermissions(int32_t, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBLogInWithPublishPermissions(System.Int32,System.String)
extern "C"  void IOSWrapper_IOSFBLogInWithPublishPermissions_m1193287201 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___scope1, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, char*);

	// Marshaling of parameter '___scope1' to native representation
	char* ____scope1_marshaled = NULL;
	____scope1_marshaled = il2cpp_codegen_marshal_string(___scope1);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBLogInWithPublishPermissions)(___requestId0, ____scope1_marshaled);

	// Marshaling cleanup of parameter '___scope1' native representation
	il2cpp_codegen_marshal_free(____scope1_marshaled);
	____scope1_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBLogOut();
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBLogOut()
extern "C"  void IOSWrapper_IOSFBLogOut_m1975029250 (Il2CppObject * __this /* static, unused */, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBLogOut)();

}
extern "C" void DEFAULT_CALL IOSFBSetShareDialogMode(int32_t);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBSetShareDialogMode(System.Int32)
extern "C"  void IOSWrapper_IOSFBSetShareDialogMode_m3394844047 (Il2CppObject * __this /* static, unused */, int32_t ___mode0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBSetShareDialogMode)(___mode0);

}
extern "C" void DEFAULT_CALL IOSFBShareLink(int32_t, char*, char*, char*, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBShareLink(System.Int32,System.String,System.String,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBShareLink_m3128905012 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___contentURL1, String_t* ___contentTitle2, String_t* ___contentDescription3, String_t* ___photoURL4, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, char*, char*, char*, char*);

	// Marshaling of parameter '___contentURL1' to native representation
	char* ____contentURL1_marshaled = NULL;
	____contentURL1_marshaled = il2cpp_codegen_marshal_string(___contentURL1);

	// Marshaling of parameter '___contentTitle2' to native representation
	char* ____contentTitle2_marshaled = NULL;
	____contentTitle2_marshaled = il2cpp_codegen_marshal_string(___contentTitle2);

	// Marshaling of parameter '___contentDescription3' to native representation
	char* ____contentDescription3_marshaled = NULL;
	____contentDescription3_marshaled = il2cpp_codegen_marshal_string(___contentDescription3);

	// Marshaling of parameter '___photoURL4' to native representation
	char* ____photoURL4_marshaled = NULL;
	____photoURL4_marshaled = il2cpp_codegen_marshal_string(___photoURL4);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBShareLink)(___requestId0, ____contentURL1_marshaled, ____contentTitle2_marshaled, ____contentDescription3_marshaled, ____photoURL4_marshaled);

	// Marshaling cleanup of parameter '___contentURL1' native representation
	il2cpp_codegen_marshal_free(____contentURL1_marshaled);
	____contentURL1_marshaled = NULL;

	// Marshaling cleanup of parameter '___contentTitle2' native representation
	il2cpp_codegen_marshal_free(____contentTitle2_marshaled);
	____contentTitle2_marshaled = NULL;

	// Marshaling cleanup of parameter '___contentDescription3' native representation
	il2cpp_codegen_marshal_free(____contentDescription3_marshaled);
	____contentDescription3_marshaled = NULL;

	// Marshaling cleanup of parameter '___photoURL4' native representation
	il2cpp_codegen_marshal_free(____photoURL4_marshaled);
	____photoURL4_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBFeedShare(int32_t, char*, char*, char*, char*, char*, char*, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBFeedShare(System.Int32,System.String,System.String,System.String,System.String,System.String,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBFeedShare_m2674999132 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___toId1, String_t* ___link2, String_t* ___linkName3, String_t* ___linkCaption4, String_t* ___linkDescription5, String_t* ___picture6, String_t* ___mediaSource7, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, char*, char*, char*, char*, char*, char*, char*);

	// Marshaling of parameter '___toId1' to native representation
	char* ____toId1_marshaled = NULL;
	____toId1_marshaled = il2cpp_codegen_marshal_string(___toId1);

	// Marshaling of parameter '___link2' to native representation
	char* ____link2_marshaled = NULL;
	____link2_marshaled = il2cpp_codegen_marshal_string(___link2);

	// Marshaling of parameter '___linkName3' to native representation
	char* ____linkName3_marshaled = NULL;
	____linkName3_marshaled = il2cpp_codegen_marshal_string(___linkName3);

	// Marshaling of parameter '___linkCaption4' to native representation
	char* ____linkCaption4_marshaled = NULL;
	____linkCaption4_marshaled = il2cpp_codegen_marshal_string(___linkCaption4);

	// Marshaling of parameter '___linkDescription5' to native representation
	char* ____linkDescription5_marshaled = NULL;
	____linkDescription5_marshaled = il2cpp_codegen_marshal_string(___linkDescription5);

	// Marshaling of parameter '___picture6' to native representation
	char* ____picture6_marshaled = NULL;
	____picture6_marshaled = il2cpp_codegen_marshal_string(___picture6);

	// Marshaling of parameter '___mediaSource7' to native representation
	char* ____mediaSource7_marshaled = NULL;
	____mediaSource7_marshaled = il2cpp_codegen_marshal_string(___mediaSource7);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBFeedShare)(___requestId0, ____toId1_marshaled, ____link2_marshaled, ____linkName3_marshaled, ____linkCaption4_marshaled, ____linkDescription5_marshaled, ____picture6_marshaled, ____mediaSource7_marshaled);

	// Marshaling cleanup of parameter '___toId1' native representation
	il2cpp_codegen_marshal_free(____toId1_marshaled);
	____toId1_marshaled = NULL;

	// Marshaling cleanup of parameter '___link2' native representation
	il2cpp_codegen_marshal_free(____link2_marshaled);
	____link2_marshaled = NULL;

	// Marshaling cleanup of parameter '___linkName3' native representation
	il2cpp_codegen_marshal_free(____linkName3_marshaled);
	____linkName3_marshaled = NULL;

	// Marshaling cleanup of parameter '___linkCaption4' native representation
	il2cpp_codegen_marshal_free(____linkCaption4_marshaled);
	____linkCaption4_marshaled = NULL;

	// Marshaling cleanup of parameter '___linkDescription5' native representation
	il2cpp_codegen_marshal_free(____linkDescription5_marshaled);
	____linkDescription5_marshaled = NULL;

	// Marshaling cleanup of parameter '___picture6' native representation
	il2cpp_codegen_marshal_free(____picture6_marshaled);
	____picture6_marshaled = NULL;

	// Marshaling cleanup of parameter '___mediaSource7' native representation
	il2cpp_codegen_marshal_free(____mediaSource7_marshaled);
	____mediaSource7_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBAppRequest(int32_t, char*, char*, char*, char**, int32_t, char*, char**, int32_t, int32_t, int32_t, char*, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppRequest(System.Int32,System.String,System.String,System.String,System.String[],System.Int32,System.String,System.String[],System.Int32,System.Boolean,System.Int32,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBAppRequest_m3493977217 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___message1, String_t* ___actionType2, String_t* ___objectId3, StringU5BU5D_t1642385972* ___to4, int32_t ___toLength5, String_t* ___filters6, StringU5BU5D_t1642385972* ___excludeIds7, int32_t ___excludeIdsLength8, bool ___hasMaxRecipients9, int32_t ___maxRecipients10, String_t* ___data11, String_t* ___title12, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, char*, char*, char*, char**, int32_t, char*, char**, int32_t, int32_t, int32_t, char*, char*);

	// Marshaling of parameter '___message1' to native representation
	char* ____message1_marshaled = NULL;
	____message1_marshaled = il2cpp_codegen_marshal_string(___message1);

	// Marshaling of parameter '___actionType2' to native representation
	char* ____actionType2_marshaled = NULL;
	____actionType2_marshaled = il2cpp_codegen_marshal_string(___actionType2);

	// Marshaling of parameter '___objectId3' to native representation
	char* ____objectId3_marshaled = NULL;
	____objectId3_marshaled = il2cpp_codegen_marshal_string(___objectId3);

	// Marshaling of parameter '___to4' to native representation
	char** ____to4_marshaled = NULL;
	if (___to4 != NULL)
	{
		int32_t ____to4_Length = (___to4)->max_length;
		____to4_marshaled = il2cpp_codegen_marshal_allocate_array<char*>(____to4_Length + 1);
		(____to4_marshaled)[____to4_Length] = NULL;
		for (int32_t i = 0; i < ____to4_Length; i++)
		{
			(____to4_marshaled)[i] = il2cpp_codegen_marshal_string((___to4)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		____to4_marshaled = NULL;
	}

	// Marshaling of parameter '___filters6' to native representation
	char* ____filters6_marshaled = NULL;
	____filters6_marshaled = il2cpp_codegen_marshal_string(___filters6);

	// Marshaling of parameter '___excludeIds7' to native representation
	char** ____excludeIds7_marshaled = NULL;
	if (___excludeIds7 != NULL)
	{
		int32_t ____excludeIds7_Length = (___excludeIds7)->max_length;
		____excludeIds7_marshaled = il2cpp_codegen_marshal_allocate_array<char*>(____excludeIds7_Length + 1);
		(____excludeIds7_marshaled)[____excludeIds7_Length] = NULL;
		for (int32_t i = 0; i < ____excludeIds7_Length; i++)
		{
			(____excludeIds7_marshaled)[i] = il2cpp_codegen_marshal_string((___excludeIds7)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		____excludeIds7_marshaled = NULL;
	}

	// Marshaling of parameter '___data11' to native representation
	char* ____data11_marshaled = NULL;
	____data11_marshaled = il2cpp_codegen_marshal_string(___data11);

	// Marshaling of parameter '___title12' to native representation
	char* ____title12_marshaled = NULL;
	____title12_marshaled = il2cpp_codegen_marshal_string(___title12);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBAppRequest)(___requestId0, ____message1_marshaled, ____actionType2_marshaled, ____objectId3_marshaled, ____to4_marshaled, ___toLength5, ____filters6_marshaled, ____excludeIds7_marshaled, ___excludeIdsLength8, static_cast<int32_t>(___hasMaxRecipients9), ___maxRecipients10, ____data11_marshaled, ____title12_marshaled);

	// Marshaling cleanup of parameter '___message1' native representation
	il2cpp_codegen_marshal_free(____message1_marshaled);
	____message1_marshaled = NULL;

	// Marshaling cleanup of parameter '___actionType2' native representation
	il2cpp_codegen_marshal_free(____actionType2_marshaled);
	____actionType2_marshaled = NULL;

	// Marshaling cleanup of parameter '___objectId3' native representation
	il2cpp_codegen_marshal_free(____objectId3_marshaled);
	____objectId3_marshaled = NULL;

	// Marshaling cleanup of parameter '___to4' native representation
	if (____to4_marshaled != NULL)
	{
		const int32_t ____to4_marshaled_CleanupLoopCount = (___to4 != NULL) ? (___to4)->max_length : 0;
		for (int32_t i = 0; i < ____to4_marshaled_CleanupLoopCount; i++)
		{
			il2cpp_codegen_marshal_free((____to4_marshaled)[i]);
			(____to4_marshaled)[i] = NULL;
		}
		il2cpp_codegen_marshal_free(____to4_marshaled);
		____to4_marshaled = NULL;
	}

	// Marshaling cleanup of parameter '___filters6' native representation
	il2cpp_codegen_marshal_free(____filters6_marshaled);
	____filters6_marshaled = NULL;

	// Marshaling cleanup of parameter '___excludeIds7' native representation
	if (____excludeIds7_marshaled != NULL)
	{
		const int32_t ____excludeIds7_marshaled_CleanupLoopCount = (___excludeIds7 != NULL) ? (___excludeIds7)->max_length : 0;
		for (int32_t i = 0; i < ____excludeIds7_marshaled_CleanupLoopCount; i++)
		{
			il2cpp_codegen_marshal_free((____excludeIds7_marshaled)[i]);
			(____excludeIds7_marshaled)[i] = NULL;
		}
		il2cpp_codegen_marshal_free(____excludeIds7_marshaled);
		____excludeIds7_marshaled = NULL;
	}

	// Marshaling cleanup of parameter '___data11' native representation
	il2cpp_codegen_marshal_free(____data11_marshaled);
	____data11_marshaled = NULL;

	// Marshaling cleanup of parameter '___title12' native representation
	il2cpp_codegen_marshal_free(____title12_marshaled);
	____title12_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBAppInvite(int32_t, char*, char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppInvite(System.Int32,System.String,System.String)
extern "C"  void IOSWrapper_IOSFBAppInvite_m1414880447 (Il2CppObject * __this /* static, unused */, int32_t ___requestId0, String_t* ___appLinkUrl1, String_t* ___previewImageUrl2, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, char*, char*);

	// Marshaling of parameter '___appLinkUrl1' to native representation
	char* ____appLinkUrl1_marshaled = NULL;
	____appLinkUrl1_marshaled = il2cpp_codegen_marshal_string(___appLinkUrl1);

	// Marshaling of parameter '___previewImageUrl2' to native representation
	char* ____previewImageUrl2_marshaled = NULL;
	____previewImageUrl2_marshaled = il2cpp_codegen_marshal_string(___previewImageUrl2);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBAppInvite)(___requestId0, ____appLinkUrl1_marshaled, ____previewImageUrl2_marshaled);

	// Marshaling cleanup of parameter '___appLinkUrl1' native representation
	il2cpp_codegen_marshal_free(____appLinkUrl1_marshaled);
	____appLinkUrl1_marshaled = NULL;

	// Marshaling cleanup of parameter '___previewImageUrl2' native representation
	il2cpp_codegen_marshal_free(____previewImageUrl2_marshaled);
	____previewImageUrl2_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBSettingsActivateApp(char*);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBSettingsActivateApp(System.String)
extern "C"  void IOSWrapper_IOSFBSettingsActivateApp_m797401977 (Il2CppObject * __this /* static, unused */, String_t* ___appId0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*);

	// Marshaling of parameter '___appId0' to native representation
	char* ____appId0_marshaled = NULL;
	____appId0_marshaled = il2cpp_codegen_marshal_string(___appId0);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBSettingsActivateApp)(____appId0_marshaled);

	// Marshaling cleanup of parameter '___appId0' native representation
	il2cpp_codegen_marshal_free(____appId0_marshaled);
	____appId0_marshaled = NULL;

}
extern "C" void DEFAULT_CALL IOSFBAppEventsLogEvent(char*, double, int32_t, char**, char**);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppEventsLogEvent(System.String,System.Double,System.Int32,System.String[],System.String[])
extern "C"  void IOSWrapper_IOSFBAppEventsLogEvent_m1319076241 (Il2CppObject * __this /* static, unused */, String_t* ___logEvent0, double ___valueToSum1, int32_t ___numParams2, StringU5BU5D_t1642385972* ___paramKeys3, StringU5BU5D_t1642385972* ___paramVals4, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, double, int32_t, char**, char**);

	// Marshaling of parameter '___logEvent0' to native representation
	char* ____logEvent0_marshaled = NULL;
	____logEvent0_marshaled = il2cpp_codegen_marshal_string(___logEvent0);

	// Marshaling of parameter '___paramKeys3' to native representation
	char** ____paramKeys3_marshaled = NULL;
	if (___paramKeys3 != NULL)
	{
		int32_t ____paramKeys3_Length = (___paramKeys3)->max_length;
		____paramKeys3_marshaled = il2cpp_codegen_marshal_allocate_array<char*>(____paramKeys3_Length + 1);
		(____paramKeys3_marshaled)[____paramKeys3_Length] = NULL;
		for (int32_t i = 0; i < ____paramKeys3_Length; i++)
		{
			(____paramKeys3_marshaled)[i] = il2cpp_codegen_marshal_string((___paramKeys3)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		____paramKeys3_marshaled = NULL;
	}

	// Marshaling of parameter '___paramVals4' to native representation
	char** ____paramVals4_marshaled = NULL;
	if (___paramVals4 != NULL)
	{
		int32_t ____paramVals4_Length = (___paramVals4)->max_length;
		____paramVals4_marshaled = il2cpp_codegen_marshal_allocate_array<char*>(____paramVals4_Length + 1);
		(____paramVals4_marshaled)[____paramVals4_Length] = NULL;
		for (int32_t i = 0; i < ____paramVals4_Length; i++)
		{
			(____paramVals4_marshaled)[i] = il2cpp_codegen_marshal_string((___paramVals4)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		____paramVals4_marshaled = NULL;
	}

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBAppEventsLogEvent)(____logEvent0_marshaled, ___valueToSum1, ___numParams2, ____paramKeys3_marshaled, ____paramVals4_marshaled);

	// Marshaling cleanup of parameter '___logEvent0' native representation
	il2cpp_codegen_marshal_free(____logEvent0_marshaled);
	____logEvent0_marshaled = NULL;

	// Marshaling cleanup of parameter '___paramKeys3' native representation
	if (____paramKeys3_marshaled != NULL)
	{
		const int32_t ____paramKeys3_marshaled_CleanupLoopCount = (___paramKeys3 != NULL) ? (___paramKeys3)->max_length : 0;
		for (int32_t i = 0; i < ____paramKeys3_marshaled_CleanupLoopCount; i++)
		{
			il2cpp_codegen_marshal_free((____paramKeys3_marshaled)[i]);
			(____paramKeys3_marshaled)[i] = NULL;
		}
		il2cpp_codegen_marshal_free(____paramKeys3_marshaled);
		____paramKeys3_marshaled = NULL;
	}

	// Marshaling cleanup of parameter '___paramVals4' native representation
	if (____paramVals4_marshaled != NULL)
	{
		const int32_t ____paramVals4_marshaled_CleanupLoopCount = (___paramVals4 != NULL) ? (___paramVals4)->max_length : 0;
		for (int32_t i = 0; i < ____paramVals4_marshaled_CleanupLoopCount; i++)
		{
			il2cpp_codegen_marshal_free((____paramVals4_marshaled)[i]);
			(____paramVals4_marshaled)[i] = NULL;
		}
		il2cpp_codegen_marshal_free(____paramVals4_marshaled);
		____paramVals4_marshaled = NULL;
	}

}
extern "C" void DEFAULT_CALL IOSFBAppEventsLogPurchase(double, char*, int32_t, char**, char**);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppEventsLogPurchase(System.Double,System.String,System.Int32,System.String[],System.String[])
extern "C"  void IOSWrapper_IOSFBAppEventsLogPurchase_m1964399802 (Il2CppObject * __this /* static, unused */, double ___logPurchase0, String_t* ___currency1, int32_t ___numParams2, StringU5BU5D_t1642385972* ___paramKeys3, StringU5BU5D_t1642385972* ___paramVals4, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (double, char*, int32_t, char**, char**);

	// Marshaling of parameter '___currency1' to native representation
	char* ____currency1_marshaled = NULL;
	____currency1_marshaled = il2cpp_codegen_marshal_string(___currency1);

	// Marshaling of parameter '___paramKeys3' to native representation
	char** ____paramKeys3_marshaled = NULL;
	if (___paramKeys3 != NULL)
	{
		int32_t ____paramKeys3_Length = (___paramKeys3)->max_length;
		____paramKeys3_marshaled = il2cpp_codegen_marshal_allocate_array<char*>(____paramKeys3_Length + 1);
		(____paramKeys3_marshaled)[____paramKeys3_Length] = NULL;
		for (int32_t i = 0; i < ____paramKeys3_Length; i++)
		{
			(____paramKeys3_marshaled)[i] = il2cpp_codegen_marshal_string((___paramKeys3)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		____paramKeys3_marshaled = NULL;
	}

	// Marshaling of parameter '___paramVals4' to native representation
	char** ____paramVals4_marshaled = NULL;
	if (___paramVals4 != NULL)
	{
		int32_t ____paramVals4_Length = (___paramVals4)->max_length;
		____paramVals4_marshaled = il2cpp_codegen_marshal_allocate_array<char*>(____paramVals4_Length + 1);
		(____paramVals4_marshaled)[____paramVals4_Length] = NULL;
		for (int32_t i = 0; i < ____paramVals4_Length; i++)
		{
			(____paramVals4_marshaled)[i] = il2cpp_codegen_marshal_string((___paramVals4)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		____paramVals4_marshaled = NULL;
	}

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBAppEventsLogPurchase)(___logPurchase0, ____currency1_marshaled, ___numParams2, ____paramKeys3_marshaled, ____paramVals4_marshaled);

	// Marshaling cleanup of parameter '___currency1' native representation
	il2cpp_codegen_marshal_free(____currency1_marshaled);
	____currency1_marshaled = NULL;

	// Marshaling cleanup of parameter '___paramKeys3' native representation
	if (____paramKeys3_marshaled != NULL)
	{
		const int32_t ____paramKeys3_marshaled_CleanupLoopCount = (___paramKeys3 != NULL) ? (___paramKeys3)->max_length : 0;
		for (int32_t i = 0; i < ____paramKeys3_marshaled_CleanupLoopCount; i++)
		{
			il2cpp_codegen_marshal_free((____paramKeys3_marshaled)[i]);
			(____paramKeys3_marshaled)[i] = NULL;
		}
		il2cpp_codegen_marshal_free(____paramKeys3_marshaled);
		____paramKeys3_marshaled = NULL;
	}

	// Marshaling cleanup of parameter '___paramVals4' native representation
	if (____paramVals4_marshaled != NULL)
	{
		const int32_t ____paramVals4_marshaled_CleanupLoopCount = (___paramVals4 != NULL) ? (___paramVals4)->max_length : 0;
		for (int32_t i = 0; i < ____paramVals4_marshaled_CleanupLoopCount; i++)
		{
			il2cpp_codegen_marshal_free((____paramVals4_marshaled)[i]);
			(____paramVals4_marshaled)[i] = NULL;
		}
		il2cpp_codegen_marshal_free(____paramVals4_marshaled);
		____paramVals4_marshaled = NULL;
	}

}
extern "C" void DEFAULT_CALL IOSFBAppEventsSetLimitEventUsage(int32_t);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBAppEventsSetLimitEventUsage(System.Boolean)
extern "C"  void IOSWrapper_IOSFBAppEventsSetLimitEventUsage_m1765600937 (Il2CppObject * __this /* static, unused */, bool ___limitEventUsage0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBAppEventsSetLimitEventUsage)(static_cast<int32_t>(___limitEventUsage0));

}
extern "C" void DEFAULT_CALL IOSFBGetAppLink(int32_t);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBGetAppLink(System.Int32)
extern "C"  void IOSWrapper_IOSFBGetAppLink_m459813758 (Il2CppObject * __this /* static, unused */, int32_t ___requestID0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBGetAppLink)(___requestID0);

}
extern "C" char* DEFAULT_CALL IOSFBSdkVersion();
// System.String Facebook.Unity.IOS.IOSWrapper::IOSFBSdkVersion()
extern "C"  String_t* IOSWrapper_IOSFBSdkVersion_m1954204313 (Il2CppObject * __this /* static, unused */, const MethodInfo* method)
{
	typedef char* (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	char* returnValue = reinterpret_cast<PInvokeFunc>(IOSFBSdkVersion)();

	// Marshaling of return value back from native representation
	String_t* _returnValue_unmarshaled = NULL;
	_returnValue_unmarshaled = il2cpp_codegen_marshal_string_result(returnValue);

	// Marshaling cleanup of return value native representation
	il2cpp_codegen_marshal_free(returnValue);
	returnValue = NULL;

	return _returnValue_unmarshaled;
}
extern "C" void DEFAULT_CALL IOSFBFetchDeferredAppLink(int32_t);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBFetchDeferredAppLink(System.Int32)
extern "C"  void IOSWrapper_IOSFBFetchDeferredAppLink_m4025468277 (Il2CppObject * __this /* static, unused */, int32_t ___requestID0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBFetchDeferredAppLink)(___requestID0);

}
extern "C" void DEFAULT_CALL IOSFBRefreshCurrentAccessToken(int32_t);
// System.Void Facebook.Unity.IOS.IOSWrapper::IOSFBRefreshCurrentAccessToken(System.Int32)
extern "C"  void IOSWrapper_IOSFBRefreshCurrentAccessToken_m1240471684 (Il2CppObject * __this /* static, unused */, int32_t ___requestID0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(IOSFBRefreshCurrentAccessToken)(___requestID0);

}
// System.Void Facebook.Unity.IOS.IOSWrapper::.ctor()
extern "C"  void IOSWrapper__ctor_m3492638423 (IOSWrapper_t294756590 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
