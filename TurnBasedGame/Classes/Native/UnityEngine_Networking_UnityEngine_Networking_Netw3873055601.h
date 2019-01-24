#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Networking.NetworkIdentity
struct NetworkIdentity_t1766639790;
// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.Networking.NetworkBehaviour/Invoker>
struct Dictionary_2_t2867028446;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkBehaviour
struct  NetworkBehaviour_t3873055601  : public MonoBehaviour_t1158329972
{
public:
	// System.UInt32 UnityEngine.Networking.NetworkBehaviour::m_SyncVarDirtyBits
	uint32_t ___m_SyncVarDirtyBits_2;
	// System.Single UnityEngine.Networking.NetworkBehaviour::m_LastSendTime
	float ___m_LastSendTime_3;
	// System.Boolean UnityEngine.Networking.NetworkBehaviour::m_SyncVarGuard
	bool ___m_SyncVarGuard_4;
	// UnityEngine.Networking.NetworkIdentity UnityEngine.Networking.NetworkBehaviour::m_MyView
	NetworkIdentity_t1766639790 * ___m_MyView_6;

public:
	inline static int32_t get_offset_of_m_SyncVarDirtyBits_2() { return static_cast<int32_t>(offsetof(NetworkBehaviour_t3873055601, ___m_SyncVarDirtyBits_2)); }
	inline uint32_t get_m_SyncVarDirtyBits_2() const { return ___m_SyncVarDirtyBits_2; }
	inline uint32_t* get_address_of_m_SyncVarDirtyBits_2() { return &___m_SyncVarDirtyBits_2; }
	inline void set_m_SyncVarDirtyBits_2(uint32_t value)
	{
		___m_SyncVarDirtyBits_2 = value;
	}

	inline static int32_t get_offset_of_m_LastSendTime_3() { return static_cast<int32_t>(offsetof(NetworkBehaviour_t3873055601, ___m_LastSendTime_3)); }
	inline float get_m_LastSendTime_3() const { return ___m_LastSendTime_3; }
	inline float* get_address_of_m_LastSendTime_3() { return &___m_LastSendTime_3; }
	inline void set_m_LastSendTime_3(float value)
	{
		___m_LastSendTime_3 = value;
	}

	inline static int32_t get_offset_of_m_SyncVarGuard_4() { return static_cast<int32_t>(offsetof(NetworkBehaviour_t3873055601, ___m_SyncVarGuard_4)); }
	inline bool get_m_SyncVarGuard_4() const { return ___m_SyncVarGuard_4; }
	inline bool* get_address_of_m_SyncVarGuard_4() { return &___m_SyncVarGuard_4; }
	inline void set_m_SyncVarGuard_4(bool value)
	{
		___m_SyncVarGuard_4 = value;
	}

	inline static int32_t get_offset_of_m_MyView_6() { return static_cast<int32_t>(offsetof(NetworkBehaviour_t3873055601, ___m_MyView_6)); }
	inline NetworkIdentity_t1766639790 * get_m_MyView_6() const { return ___m_MyView_6; }
	inline NetworkIdentity_t1766639790 ** get_address_of_m_MyView_6() { return &___m_MyView_6; }
	inline void set_m_MyView_6(NetworkIdentity_t1766639790 * value)
	{
		___m_MyView_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_MyView_6, value);
	}
};

struct NetworkBehaviour_t3873055601_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.Networking.NetworkBehaviour/Invoker> UnityEngine.Networking.NetworkBehaviour::s_CmdHandlerDelegates
	Dictionary_2_t2867028446 * ___s_CmdHandlerDelegates_7;

public:
	inline static int32_t get_offset_of_s_CmdHandlerDelegates_7() { return static_cast<int32_t>(offsetof(NetworkBehaviour_t3873055601_StaticFields, ___s_CmdHandlerDelegates_7)); }
	inline Dictionary_2_t2867028446 * get_s_CmdHandlerDelegates_7() const { return ___s_CmdHandlerDelegates_7; }
	inline Dictionary_2_t2867028446 ** get_address_of_s_CmdHandlerDelegates_7() { return &___s_CmdHandlerDelegates_7; }
	inline void set_s_CmdHandlerDelegates_7(Dictionary_2_t2867028446 * value)
	{
		___s_CmdHandlerDelegates_7 = value;
		Il2CppCodeGenWriteBarrier(&___s_CmdHandlerDelegates_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
