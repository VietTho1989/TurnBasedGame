#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.WWW
struct WWW_t2919945039;
// UnityEngine.Networking.Match.JoinMatchResponse
struct JoinMatchResponse_t1256242636;
// UnityEngine.Networking.Match.NetworkMatch/InternalResponseDelegate`2<UnityEngine.Networking.Match.JoinMatchResponse,UnityEngine.Networking.Match.NetworkMatch/DataResponseDelegate`1<UnityEngine.Networking.Match.MatchInfo>>
struct InternalResponseDelegate_2_t4009221651;
// UnityEngine.Networking.Match.NetworkMatch/DataResponseDelegate`1<UnityEngine.Networking.Match.MatchInfo>
struct DataResponseDelegate_1_t3220115103;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2<UnityEngine.Networking.Match.JoinMatchResponse,UnityEngine.Networking.Match.NetworkMatch/DataResponseDelegate`1<UnityEngine.Networking.Match.MatchInfo>>
struct  U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254  : public Il2CppObject
{
public:
	// UnityEngine.WWW UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::client
	WWW_t2919945039 * ___client_0;
	// JSONRESPONSE UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::<jsonInterface>__0
	JoinMatchResponse_t1256242636 * ___U3CjsonInterfaceU3E__0_1;
	// UnityEngine.Networking.Match.NetworkMatch/InternalResponseDelegate`2<JSONRESPONSE,USERRESPONSEDELEGATETYPE> UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::internalCallback
	InternalResponseDelegate_2_t4009221651 * ___internalCallback_2;
	// USERRESPONSEDELEGATETYPE UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::userCallback
	DataResponseDelegate_1_t3220115103 * ___userCallback_3;
	// System.Object UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::$current
	Il2CppObject * ___U24current_4;
	// System.Boolean UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::$disposing
	bool ___U24disposing_5;
	// System.Int32 UnityEngine.Networking.Match.NetworkMatch/<ProcessMatchResponse>c__Iterator0`2::$PC
	int32_t ___U24PC_6;

public:
	inline static int32_t get_offset_of_client_0() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___client_0)); }
	inline WWW_t2919945039 * get_client_0() const { return ___client_0; }
	inline WWW_t2919945039 ** get_address_of_client_0() { return &___client_0; }
	inline void set_client_0(WWW_t2919945039 * value)
	{
		___client_0 = value;
		Il2CppCodeGenWriteBarrier(&___client_0, value);
	}

	inline static int32_t get_offset_of_U3CjsonInterfaceU3E__0_1() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___U3CjsonInterfaceU3E__0_1)); }
	inline JoinMatchResponse_t1256242636 * get_U3CjsonInterfaceU3E__0_1() const { return ___U3CjsonInterfaceU3E__0_1; }
	inline JoinMatchResponse_t1256242636 ** get_address_of_U3CjsonInterfaceU3E__0_1() { return &___U3CjsonInterfaceU3E__0_1; }
	inline void set_U3CjsonInterfaceU3E__0_1(JoinMatchResponse_t1256242636 * value)
	{
		___U3CjsonInterfaceU3E__0_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CjsonInterfaceU3E__0_1, value);
	}

	inline static int32_t get_offset_of_internalCallback_2() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___internalCallback_2)); }
	inline InternalResponseDelegate_2_t4009221651 * get_internalCallback_2() const { return ___internalCallback_2; }
	inline InternalResponseDelegate_2_t4009221651 ** get_address_of_internalCallback_2() { return &___internalCallback_2; }
	inline void set_internalCallback_2(InternalResponseDelegate_2_t4009221651 * value)
	{
		___internalCallback_2 = value;
		Il2CppCodeGenWriteBarrier(&___internalCallback_2, value);
	}

	inline static int32_t get_offset_of_userCallback_3() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___userCallback_3)); }
	inline DataResponseDelegate_1_t3220115103 * get_userCallback_3() const { return ___userCallback_3; }
	inline DataResponseDelegate_1_t3220115103 ** get_address_of_userCallback_3() { return &___userCallback_3; }
	inline void set_userCallback_3(DataResponseDelegate_1_t3220115103 * value)
	{
		___userCallback_3 = value;
		Il2CppCodeGenWriteBarrier(&___userCallback_3, value);
	}

	inline static int32_t get_offset_of_U24current_4() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___U24current_4)); }
	inline Il2CppObject * get_U24current_4() const { return ___U24current_4; }
	inline Il2CppObject ** get_address_of_U24current_4() { return &___U24current_4; }
	inline void set_U24current_4(Il2CppObject * value)
	{
		___U24current_4 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_4, value);
	}

	inline static int32_t get_offset_of_U24disposing_5() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___U24disposing_5)); }
	inline bool get_U24disposing_5() const { return ___U24disposing_5; }
	inline bool* get_address_of_U24disposing_5() { return &___U24disposing_5; }
	inline void set_U24disposing_5(bool value)
	{
		___U24disposing_5 = value;
	}

	inline static int32_t get_offset_of_U24PC_6() { return static_cast<int32_t>(offsetof(U3CProcessMatchResponseU3Ec__Iterator0_2_t1041813254, ___U24PC_6)); }
	inline int32_t get_U24PC_6() const { return ___U24PC_6; }
	inline int32_t* get_address_of_U24PC_6() { return &___U24PC_6; }
	inline void set_U24PC_6(int32_t value)
	{
		___U24PC_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
