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
#include "Foundation_Server_Unity3d_U3CModuleU3E3783534214.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac2379170077.h"
#include "mscorlib_System_String2029220233.h"
#include "mscorlib_System_Void1841601450.h"
#include "mscorlib_System_Object2689449295.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac3543373684.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac3646237994.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac2069602367.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac1548912630.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac2301947249.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Ac2489824135.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Acc903274447.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_AP2310486523.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Gam916059438.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Re3913696061.h"
#include "mscorlib_System_Collections_Generic_Dictionary_2_g3557165234.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Re3933149076.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_St1550279825.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_St2476242911.h"
#include "mscorlib_System_Boolean3825574718.h"
#include "mscorlib_System_Single2076509932.h"
#include "mscorlib_System_Int322071877448.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_St3218109694.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_Sto639770576.h"
#include "mscorlib_System_DateTime693205669.h"
#include "Foundation_Server_Unity3d_System_ComponentModel_Da2240259672.h"
#include "mscorlib_System_Attribute542643598.h"
#include "Foundation_Server_Unity3d_System_ComponentModel_Da2456169416.h"
#include "Foundation_Server_Unity3d_System_ComponentModel_Da2131782145.h"

// Foundation.Server.Api.AccountDetails
struct AccountDetails_t2379170077;
// System.String
struct String_t;
// System.Object
struct Il2CppObject;
// Foundation.Server.Api.AccountEmailDelete
struct AccountEmailDelete_t3543373684;
// Foundation.Server.Api.AccountEmailReset
struct AccountEmailReset_t3646237994;
// Foundation.Server.Api.AccountEmailSignIn
struct AccountEmailSignIn_t2069602367;
// Foundation.Server.Api.AccountEmailUpdate
struct AccountEmailUpdate_t1548912630;
// Foundation.Server.Api.AccountFacebookConnect
struct AccountFacebookConnect_t2301947249;
// Foundation.Server.Api.AccountFacebookDisconnect
struct AccountFacebookDisconnect_t2489824135;
// Foundation.Server.Api.AccountGuestSignIn
struct AccountGuestSignIn_t903274447;
// Foundation.Server.Api.RealtimeSignIn
struct RealtimeSignIn_t3913696061;
// System.Collections.Generic.Dictionary`2<System.String,System.String[]>
struct Dictionary_2_t3557165234;
// Foundation.Server.Api.RealtimeToken
struct RealtimeToken_t3933149076;
// Foundation.Server.Api.StorageDelta
struct StorageDelta_t2476242911;
// Foundation.Server.Api.StorageProperty
struct StorageProperty_t3218109694;
// Foundation.Server.Api.StorageRequest
struct StorageRequest_t639770576;
// System.ComponentModel.DataAnnotations.EmailAddressAttribute
struct EmailAddressAttribute_t2240259672;
// System.Attribute
struct Attribute_t542643598;
// System.ComponentModel.DataAnnotations.MinLength
struct MinLength_t2456169416;
// System.ComponentModel.DataAnnotations.RequiredAttribute
struct RequiredAttribute_t2131782145;
extern Il2CppClass* APIConstants_t2310486523_il2cpp_TypeInfo_var;
extern Il2CppCodeGenString* _stringLiteral3719270727;
extern Il2CppCodeGenString* _stringLiteral4246317902;
extern Il2CppCodeGenString* _stringLiteral4280417383;
extern Il2CppCodeGenString* _stringLiteral1782274182;
extern const uint32_t APIConstants__cctor_m3839933007_MetadataUsageId;




// System.Void System.Object::.ctor()
extern "C"  void Object__ctor_m2551263788 (Il2CppObject * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String Foundation.Server.Api.StorageDelta::get_ObjectId()
extern "C"  String_t* StorageDelta_get_ObjectId_m946576256 (StorageDelta_t2476242911 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String Foundation.Server.Api.StorageProperty::get_ObjectId()
extern "C"  String_t* StorageProperty_get_ObjectId_m1075814207 (StorageProperty_t3218109694 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String Foundation.Server.Api.StorageRequest::get_ObjectId()
extern "C"  String_t* StorageRequest_get_ObjectId_m4229571329 (StorageRequest_t639770576 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Attribute::.ctor()
extern "C"  void Attribute__ctor_m1730479323 (Attribute_t542643598 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.ComponentModel.DataAnnotations.MinLength::set_Length(System.Int32)
extern "C"  void MinLength_set_Length_m1192683426 (MinLength_t2456169416 * __this, int32_t ___value0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.String Foundation.Server.Api.AccountDetails::get_Id()
extern "C"  String_t* AccountDetails_get_Id_m283993423 (AccountDetails_t2379170077 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = __this->get_U3CIdU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Foundation.Server.Api.AccountDetails::set_Id(System.String)
extern "C"  void AccountDetails_set_Id_m883086134 (AccountDetails_t2379170077 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CIdU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.String Foundation.Server.Api.AccountDetails::get_Email()
extern "C"  String_t* AccountDetails_get_Email_m755019754 (AccountDetails_t2379170077 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = __this->get_U3CEmailU3Ek__BackingField_1();
		return L_0;
	}
}
// System.Void Foundation.Server.Api.AccountDetails::.ctor()
extern "C"  void AccountDetails__ctor_m2124075570 (AccountDetails_t2379170077 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailDelete::set_Password(System.String)
extern "C"  void AccountEmailDelete_set_Password_m1419074589 (AccountEmailDelete_t3543373684 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CPasswordU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailDelete::.ctor()
extern "C"  void AccountEmailDelete__ctor_m3157556777 (AccountEmailDelete_t3543373684 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailReset::set_Email(System.String)
extern "C"  void AccountEmailReset_set_Email_m2815636082 (AccountEmailReset_t3646237994 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CEmailU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailReset::.ctor()
extern "C"  void AccountEmailReset__ctor_m788835661 (AccountEmailReset_t3646237994 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailSignIn::set_UserId(System.String)
extern "C"  void AccountEmailSignIn_set_UserId_m3650751223 (AccountEmailSignIn_t2069602367 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CUserIdU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailSignIn::set_Email(System.String)
extern "C"  void AccountEmailSignIn_set_Email_m2155617783 (AccountEmailSignIn_t2069602367 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CEmailU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailSignIn::set_Password(System.String)
extern "C"  void AccountEmailSignIn_set_Password_m1456360626 (AccountEmailSignIn_t2069602367 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CPasswordU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailSignIn::.ctor()
extern "C"  void AccountEmailSignIn__ctor_m3550086694 (AccountEmailSignIn_t2069602367 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailUpdate::set_NewEmail(System.String)
extern "C"  void AccountEmailUpdate_set_NewEmail_m2958118562 (AccountEmailUpdate_t1548912630 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CNewEmailU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailUpdate::set_NewPassword(System.String)
extern "C"  void AccountEmailUpdate_set_NewPassword_m1324805721 (AccountEmailUpdate_t1548912630 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CNewPasswordU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountEmailUpdate::.ctor()
extern "C"  void AccountEmailUpdate__ctor_m4009993165 (AccountEmailUpdate_t1548912630 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountFacebookConnect::set_AccessToken(System.String)
extern "C"  void AccountFacebookConnect_set_AccessToken_m150042012 (AccountFacebookConnect_t2301947249 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CAccessTokenU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountFacebookConnect::.ctor()
extern "C"  void AccountFacebookConnect__ctor_m3822309878 (AccountFacebookConnect_t2301947249 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountFacebookDisconnect::.ctor()
extern "C"  void AccountFacebookDisconnect__ctor_m1269223888 (AccountFacebookDisconnect_t2489824135 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountGuestSignIn::set_UserId(System.String)
extern "C"  void AccountGuestSignIn_set_UserId_m2386405843 (AccountGuestSignIn_t903274447 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CUserIdU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.AccountGuestSignIn::.ctor()
extern "C"  void AccountGuestSignIn__ctor_m95139014 (AccountGuestSignIn_t903274447 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Foundation.Server.Api.APIConstants::.cctor()
extern "C"  void APIConstants__cctor_m3839933007 (Il2CppObject * __this /* static, unused */, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (APIConstants__cctor_m3839933007_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		((APIConstants_t2310486523_StaticFields*)APIConstants_t2310486523_il2cpp_TypeInfo_var->static_fields)->set_APPLICATIONID_0(_stringLiteral3719270727);
		((APIConstants_t2310486523_StaticFields*)APIConstants_t2310486523_il2cpp_TypeInfo_var->static_fields)->set_SESSION_1(_stringLiteral4246317902);
		((APIConstants_t2310486523_StaticFields*)APIConstants_t2310486523_il2cpp_TypeInfo_var->static_fields)->set_AUTHORIZATION_2(_stringLiteral4280417383);
		((APIConstants_t2310486523_StaticFields*)APIConstants_t2310486523_il2cpp_TypeInfo_var->static_fields)->set_FACEBOOK_3(_stringLiteral1782274182);
		return;
	}
}
// System.Void Foundation.Server.Api.RealtimeSignIn::set_Channels(System.Collections.Generic.Dictionary`2<System.String,System.String[]>)
extern "C"  void RealtimeSignIn_set_Channels_m2298597236 (RealtimeSignIn_t3913696061 * __this, Dictionary_2_t3557165234 * ___value0, const MethodInfo* method)
{
	{
		Dictionary_2_t3557165234 * L_0 = ___value0;
		__this->set_U3CChannelsU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.RealtimeSignIn::.ctor()
extern "C"  void RealtimeSignIn__ctor_m2429081714 (RealtimeSignIn_t3913696061 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.String Foundation.Server.Api.RealtimeToken::get_AuthenticationToken()
extern "C"  String_t* RealtimeToken_get_AuthenticationToken_m4128617818 (RealtimeToken_t3933149076 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = __this->get_U3CAuthenticationTokenU3Ek__BackingField_0();
		return L_0;
	}
}
// System.String Foundation.Server.Api.StorageDelta::get_ObjectId()
extern "C"  String_t* StorageDelta_get_ObjectId_m946576256 (StorageDelta_t2476242911 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = __this->get_U3CObjectIdU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Foundation.Server.Api.StorageDelta::set_ObjectId(System.String)
extern "C"  void StorageDelta_set_ObjectId_m3364499111 (StorageDelta_t2476242911 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CObjectIdU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageDelta::set_PropertyName(System.String)
extern "C"  void StorageDelta_set_PropertyName_m2819577063 (StorageDelta_t2476242911 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CPropertyNameU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageDelta::set_IsFloat(System.Boolean)
extern "C"  void StorageDelta_set_IsFloat_m3812267980 (StorageDelta_t2476242911 * __this, bool ___value0, const MethodInfo* method)
{
	{
		bool L_0 = ___value0;
		__this->set_U3CIsFloatU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageDelta::set_Delta(System.Single)
extern "C"  void StorageDelta_set_Delta_m720008854 (StorageDelta_t2476242911 * __this, float ___value0, const MethodInfo* method)
{
	{
		float L_0 = ___value0;
		__this->set_U3CDeltaU3Ek__BackingField_3(L_0);
		return;
	}
}
// System.Int32 Foundation.Server.Api.StorageDelta::GetHashCode()
extern "C"  int32_t StorageDelta_GetHashCode_m2311114531 (StorageDelta_t2476242911 * __this, const MethodInfo* method)
{
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		String_t* L_0 = StorageDelta_get_ObjectId_m946576256(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		G_B3_0 = 0;
		goto IL_0017;
	}

IL_000c:
	{
		String_t* L_1 = StorageDelta_get_ObjectId_m946576256(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		int32_t L_2 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_1);
		G_B3_0 = L_2;
	}

IL_0017:
	{
		V_0 = G_B3_0;
		goto IL_001a;
	}

IL_001a:
	{
		int32_t L_3 = V_0;
		return L_3;
	}
}
// System.Void Foundation.Server.Api.StorageDelta::.ctor()
extern "C"  void StorageDelta__ctor_m4002042228 (StorageDelta_t2476242911 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.String Foundation.Server.Api.StorageProperty::get_ObjectId()
extern "C"  String_t* StorageProperty_get_ObjectId_m1075814207 (StorageProperty_t3218109694 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = __this->get_U3CObjectIdU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Foundation.Server.Api.StorageProperty::set_ObjectId(System.String)
extern "C"  void StorageProperty_set_ObjectId_m61457730 (StorageProperty_t3218109694 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CObjectIdU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageProperty::set_PropertyName(System.String)
extern "C"  void StorageProperty_set_PropertyName_m4180855470 (StorageProperty_t3218109694 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CPropertyNameU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageProperty::set_PropertyValue(System.String)
extern "C"  void StorageProperty_set_PropertyValue_m2589800400 (StorageProperty_t3218109694 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CPropertyValueU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Int32 Foundation.Server.Api.StorageProperty::GetHashCode()
extern "C"  int32_t StorageProperty_GetHashCode_m1138112112 (StorageProperty_t3218109694 * __this, const MethodInfo* method)
{
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		String_t* L_0 = StorageProperty_get_ObjectId_m1075814207(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		G_B3_0 = 0;
		goto IL_0017;
	}

IL_000c:
	{
		String_t* L_1 = StorageProperty_get_ObjectId_m1075814207(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		int32_t L_2 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_1);
		G_B3_0 = L_2;
	}

IL_0017:
	{
		V_0 = G_B3_0;
		goto IL_001a;
	}

IL_001a:
	{
		int32_t L_3 = V_0;
		return L_3;
	}
}
// System.Void Foundation.Server.Api.StorageProperty::.ctor()
extern "C"  void StorageProperty__ctor_m3850051423 (StorageProperty_t3218109694 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.String Foundation.Server.Api.StorageRequest::get_ObjectId()
extern "C"  String_t* StorageRequest_get_ObjectId_m4229571329 (StorageRequest_t639770576 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = __this->get_U3CObjectIdU3Ek__BackingField_0();
		return L_0;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_ObjectId(System.String)
extern "C"  void StorageRequest_set_ObjectId_m1647176380 (StorageRequest_t639770576 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CObjectIdU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_ObjectType(System.String)
extern "C"  void StorageRequest_set_ObjectType_m1563983903 (StorageRequest_t639770576 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CObjectTypeU3Ek__BackingField_1(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_ObjectScore(System.Single)
extern "C"  void StorageRequest_set_ObjectScore_m493791634 (StorageRequest_t639770576 * __this, float ___value0, const MethodInfo* method)
{
	{
		float L_0 = ___value0;
		__this->set_U3CObjectScoreU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_ObjectData(System.String)
extern "C"  void StorageRequest_set_ObjectData_m1938851487 (StorageRequest_t639770576 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CObjectDataU3Ek__BackingField_3(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_ModifiedOn(System.DateTime)
extern "C"  void StorageRequest_set_ModifiedOn_m3527728616 (StorageRequest_t639770576 * __this, DateTime_t693205669  ___value0, const MethodInfo* method)
{
	{
		DateTime_t693205669  L_0 = ___value0;
		__this->set_U3CModifiedOnU3Ek__BackingField_4(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_AclType(Foundation.Server.Api.StorageACLType)
extern "C"  void StorageRequest_set_AclType_m986267385 (StorageRequest_t639770576 * __this, int32_t ___value0, const MethodInfo* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_U3CAclTypeU3Ek__BackingField_5(L_0);
		return;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::set_AclParam(System.String)
extern "C"  void StorageRequest_set_AclParam_m2919922967 (StorageRequest_t639770576 * __this, String_t* ___value0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set_U3CAclParamU3Ek__BackingField_6(L_0);
		return;
	}
}
// System.Int32 Foundation.Server.Api.StorageRequest::GetHashCode()
extern "C"  int32_t StorageRequest_GetHashCode_m1305022706 (StorageRequest_t639770576 * __this, const MethodInfo* method)
{
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		String_t* L_0 = StorageRequest_get_ObjectId_m4229571329(__this, /*hidden argument*/NULL);
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		G_B3_0 = 0;
		goto IL_0017;
	}

IL_000c:
	{
		String_t* L_1 = StorageRequest_get_ObjectId_m4229571329(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		int32_t L_2 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_1);
		G_B3_0 = L_2;
	}

IL_0017:
	{
		V_0 = G_B3_0;
		goto IL_001a;
	}

IL_001a:
	{
		int32_t L_3 = V_0;
		return L_3;
	}
}
// System.Void Foundation.Server.Api.StorageRequest::.ctor()
extern "C"  void StorageRequest__ctor_m1887157301 (StorageRequest_t639770576 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.ComponentModel.DataAnnotations.EmailAddressAttribute::.ctor()
extern "C"  void EmailAddressAttribute__ctor_m2744309132 (EmailAddressAttribute_t2240259672 * __this, const MethodInfo* method)
{
	{
		Attribute__ctor_m1730479323(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.ComponentModel.DataAnnotations.MinLength::set_Length(System.Int32)
extern "C"  void MinLength_set_Length_m1192683426 (MinLength_t2456169416 * __this, int32_t ___value0, const MethodInfo* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_U3CLengthU3Ek__BackingField_0(L_0);
		return;
	}
}
// System.Void System.ComponentModel.DataAnnotations.MinLength::.ctor(System.Int32)
extern "C"  void MinLength__ctor_m932972001 (MinLength_t2456169416 * __this, int32_t ___length0, const MethodInfo* method)
{
	{
		Attribute__ctor_m1730479323(__this, /*hidden argument*/NULL);
		int32_t L_0 = ___length0;
		MinLength_set_Length_m1192683426(__this, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.ComponentModel.DataAnnotations.RequiredAttribute::.ctor()
extern "C"  void RequiredAttribute__ctor_m2946652543 (RequiredAttribute_t2131782145 * __this, const MethodInfo* method)
{
	{
		Attribute__ctor_m1730479323(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
