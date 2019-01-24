#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Networking.ConnectionConfig
struct ConnectionConfig_t1350910390;
// System.Collections.Generic.List`1<UnityEngine.Networking.ConnectionConfig>
struct List_1_t720031522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.HostTopology
struct  HostTopology_t3602650143  : public Il2CppObject
{
public:
	// UnityEngine.Networking.ConnectionConfig UnityEngine.Networking.HostTopology::m_DefConfig
	ConnectionConfig_t1350910390 * ___m_DefConfig_0;
	// System.Int32 UnityEngine.Networking.HostTopology::m_MaxDefConnections
	int32_t ___m_MaxDefConnections_1;
	// System.Collections.Generic.List`1<UnityEngine.Networking.ConnectionConfig> UnityEngine.Networking.HostTopology::m_SpecialConnections
	List_1_t720031522 * ___m_SpecialConnections_2;
	// System.UInt16 UnityEngine.Networking.HostTopology::m_ReceivedMessagePoolSize
	uint16_t ___m_ReceivedMessagePoolSize_3;
	// System.UInt16 UnityEngine.Networking.HostTopology::m_SentMessagePoolSize
	uint16_t ___m_SentMessagePoolSize_4;
	// System.Single UnityEngine.Networking.HostTopology::m_MessagePoolSizeGrowthFactor
	float ___m_MessagePoolSizeGrowthFactor_5;

public:
	inline static int32_t get_offset_of_m_DefConfig_0() { return static_cast<int32_t>(offsetof(HostTopology_t3602650143, ___m_DefConfig_0)); }
	inline ConnectionConfig_t1350910390 * get_m_DefConfig_0() const { return ___m_DefConfig_0; }
	inline ConnectionConfig_t1350910390 ** get_address_of_m_DefConfig_0() { return &___m_DefConfig_0; }
	inline void set_m_DefConfig_0(ConnectionConfig_t1350910390 * value)
	{
		___m_DefConfig_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_DefConfig_0, value);
	}

	inline static int32_t get_offset_of_m_MaxDefConnections_1() { return static_cast<int32_t>(offsetof(HostTopology_t3602650143, ___m_MaxDefConnections_1)); }
	inline int32_t get_m_MaxDefConnections_1() const { return ___m_MaxDefConnections_1; }
	inline int32_t* get_address_of_m_MaxDefConnections_1() { return &___m_MaxDefConnections_1; }
	inline void set_m_MaxDefConnections_1(int32_t value)
	{
		___m_MaxDefConnections_1 = value;
	}

	inline static int32_t get_offset_of_m_SpecialConnections_2() { return static_cast<int32_t>(offsetof(HostTopology_t3602650143, ___m_SpecialConnections_2)); }
	inline List_1_t720031522 * get_m_SpecialConnections_2() const { return ___m_SpecialConnections_2; }
	inline List_1_t720031522 ** get_address_of_m_SpecialConnections_2() { return &___m_SpecialConnections_2; }
	inline void set_m_SpecialConnections_2(List_1_t720031522 * value)
	{
		___m_SpecialConnections_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_SpecialConnections_2, value);
	}

	inline static int32_t get_offset_of_m_ReceivedMessagePoolSize_3() { return static_cast<int32_t>(offsetof(HostTopology_t3602650143, ___m_ReceivedMessagePoolSize_3)); }
	inline uint16_t get_m_ReceivedMessagePoolSize_3() const { return ___m_ReceivedMessagePoolSize_3; }
	inline uint16_t* get_address_of_m_ReceivedMessagePoolSize_3() { return &___m_ReceivedMessagePoolSize_3; }
	inline void set_m_ReceivedMessagePoolSize_3(uint16_t value)
	{
		___m_ReceivedMessagePoolSize_3 = value;
	}

	inline static int32_t get_offset_of_m_SentMessagePoolSize_4() { return static_cast<int32_t>(offsetof(HostTopology_t3602650143, ___m_SentMessagePoolSize_4)); }
	inline uint16_t get_m_SentMessagePoolSize_4() const { return ___m_SentMessagePoolSize_4; }
	inline uint16_t* get_address_of_m_SentMessagePoolSize_4() { return &___m_SentMessagePoolSize_4; }
	inline void set_m_SentMessagePoolSize_4(uint16_t value)
	{
		___m_SentMessagePoolSize_4 = value;
	}

	inline static int32_t get_offset_of_m_MessagePoolSizeGrowthFactor_5() { return static_cast<int32_t>(offsetof(HostTopology_t3602650143, ___m_MessagePoolSizeGrowthFactor_5)); }
	inline float get_m_MessagePoolSizeGrowthFactor_5() const { return ___m_MessagePoolSizeGrowthFactor_5; }
	inline float* get_address_of_m_MessagePoolSizeGrowthFactor_5() { return &___m_MessagePoolSizeGrowthFactor_5; }
	inline void set_m_MessagePoolSizeGrowthFactor_5(float value)
	{
		___m_MessagePoolSizeGrowthFactor_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
