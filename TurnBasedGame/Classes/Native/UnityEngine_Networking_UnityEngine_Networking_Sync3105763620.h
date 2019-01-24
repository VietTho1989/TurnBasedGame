#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<System.UInt32>
struct List_1_t1518803153;
// UnityEngine.Networking.NetworkBehaviour
struct NetworkBehaviour_t3873055601;
// UnityEngine.Networking.SyncList`1/SyncListChanged<System.UInt32>
struct SyncListChanged_t515952471;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncList`1<System.UInt32>
struct  SyncList_1_t3105763620  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<T> UnityEngine.Networking.SyncList`1::m_Objects
	List_1_t1518803153 * ___m_Objects_0;
	// UnityEngine.Networking.NetworkBehaviour UnityEngine.Networking.SyncList`1::m_Behaviour
	NetworkBehaviour_t3873055601 * ___m_Behaviour_1;
	// System.Int32 UnityEngine.Networking.SyncList`1::m_CmdHash
	int32_t ___m_CmdHash_2;
	// UnityEngine.Networking.SyncList`1/SyncListChanged<T> UnityEngine.Networking.SyncList`1::m_Callback
	SyncListChanged_t515952471 * ___m_Callback_3;

public:
	inline static int32_t get_offset_of_m_Objects_0() { return static_cast<int32_t>(offsetof(SyncList_1_t3105763620, ___m_Objects_0)); }
	inline List_1_t1518803153 * get_m_Objects_0() const { return ___m_Objects_0; }
	inline List_1_t1518803153 ** get_address_of_m_Objects_0() { return &___m_Objects_0; }
	inline void set_m_Objects_0(List_1_t1518803153 * value)
	{
		___m_Objects_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Objects_0, value);
	}

	inline static int32_t get_offset_of_m_Behaviour_1() { return static_cast<int32_t>(offsetof(SyncList_1_t3105763620, ___m_Behaviour_1)); }
	inline NetworkBehaviour_t3873055601 * get_m_Behaviour_1() const { return ___m_Behaviour_1; }
	inline NetworkBehaviour_t3873055601 ** get_address_of_m_Behaviour_1() { return &___m_Behaviour_1; }
	inline void set_m_Behaviour_1(NetworkBehaviour_t3873055601 * value)
	{
		___m_Behaviour_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_Behaviour_1, value);
	}

	inline static int32_t get_offset_of_m_CmdHash_2() { return static_cast<int32_t>(offsetof(SyncList_1_t3105763620, ___m_CmdHash_2)); }
	inline int32_t get_m_CmdHash_2() const { return ___m_CmdHash_2; }
	inline int32_t* get_address_of_m_CmdHash_2() { return &___m_CmdHash_2; }
	inline void set_m_CmdHash_2(int32_t value)
	{
		___m_CmdHash_2 = value;
	}

	inline static int32_t get_offset_of_m_Callback_3() { return static_cast<int32_t>(offsetof(SyncList_1_t3105763620, ___m_Callback_3)); }
	inline SyncListChanged_t515952471 * get_m_Callback_3() const { return ___m_Callback_3; }
	inline SyncListChanged_t515952471 ** get_address_of_m_Callback_3() { return &___m_Callback_3; }
	inline void set_m_Callback_3(SyncListChanged_t515952471 * value)
	{
		___m_Callback_3 = value;
		Il2CppCodeGenWriteBarrier(&___m_Callback_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
