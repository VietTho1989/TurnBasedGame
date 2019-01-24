#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection>
struct List_1_t3771356334;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ConnectionArray
struct  ConnectionArray_t2445648839  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.ConnectionArray::m_LocalConnections
	List_1_t3771356334 * ___m_LocalConnections_0;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.ConnectionArray::m_Connections
	List_1_t3771356334 * ___m_Connections_1;

public:
	inline static int32_t get_offset_of_m_LocalConnections_0() { return static_cast<int32_t>(offsetof(ConnectionArray_t2445648839, ___m_LocalConnections_0)); }
	inline List_1_t3771356334 * get_m_LocalConnections_0() const { return ___m_LocalConnections_0; }
	inline List_1_t3771356334 ** get_address_of_m_LocalConnections_0() { return &___m_LocalConnections_0; }
	inline void set_m_LocalConnections_0(List_1_t3771356334 * value)
	{
		___m_LocalConnections_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_LocalConnections_0, value);
	}

	inline static int32_t get_offset_of_m_Connections_1() { return static_cast<int32_t>(offsetof(ConnectionArray_t2445648839, ___m_Connections_1)); }
	inline List_1_t3771356334 * get_m_Connections_1() const { return ___m_Connections_1; }
	inline List_1_t3771356334 ** get_address_of_m_Connections_1() { return &___m_Connections_1; }
	inline void set_m_Connections_1(List_1_t3771356334 * value)
	{
		___m_Connections_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_Connections_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
