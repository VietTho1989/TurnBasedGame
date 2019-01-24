#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Networking_Match_ResponseB1952642056.h"
#include "UnityEngine_UnityEngine_Networking_Types_NodeID3569487935.h"
#include "UnityEngine_UnityEngine_Networking_Types_HostPrior2800759508.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.MatchDirectConnectInfo
struct  MatchDirectConnectInfo_t3750452272  : public ResponseBase_t1952642056
{
public:
	// UnityEngine.Networking.Types.NodeID UnityEngine.Networking.Match.MatchDirectConnectInfo::<nodeId>k__BackingField
	uint16_t ___U3CnodeIdU3Ek__BackingField_0;
	// System.String UnityEngine.Networking.Match.MatchDirectConnectInfo::<publicAddress>k__BackingField
	String_t* ___U3CpublicAddressU3Ek__BackingField_1;
	// System.String UnityEngine.Networking.Match.MatchDirectConnectInfo::<privateAddress>k__BackingField
	String_t* ___U3CprivateAddressU3Ek__BackingField_2;
	// UnityEngine.Networking.Types.HostPriority UnityEngine.Networking.Match.MatchDirectConnectInfo::<hostPriority>k__BackingField
	int32_t ___U3ChostPriorityU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CnodeIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MatchDirectConnectInfo_t3750452272, ___U3CnodeIdU3Ek__BackingField_0)); }
	inline uint16_t get_U3CnodeIdU3Ek__BackingField_0() const { return ___U3CnodeIdU3Ek__BackingField_0; }
	inline uint16_t* get_address_of_U3CnodeIdU3Ek__BackingField_0() { return &___U3CnodeIdU3Ek__BackingField_0; }
	inline void set_U3CnodeIdU3Ek__BackingField_0(uint16_t value)
	{
		___U3CnodeIdU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CpublicAddressU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MatchDirectConnectInfo_t3750452272, ___U3CpublicAddressU3Ek__BackingField_1)); }
	inline String_t* get_U3CpublicAddressU3Ek__BackingField_1() const { return ___U3CpublicAddressU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CpublicAddressU3Ek__BackingField_1() { return &___U3CpublicAddressU3Ek__BackingField_1; }
	inline void set_U3CpublicAddressU3Ek__BackingField_1(String_t* value)
	{
		___U3CpublicAddressU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CpublicAddressU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CprivateAddressU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MatchDirectConnectInfo_t3750452272, ___U3CprivateAddressU3Ek__BackingField_2)); }
	inline String_t* get_U3CprivateAddressU3Ek__BackingField_2() const { return ___U3CprivateAddressU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CprivateAddressU3Ek__BackingField_2() { return &___U3CprivateAddressU3Ek__BackingField_2; }
	inline void set_U3CprivateAddressU3Ek__BackingField_2(String_t* value)
	{
		___U3CprivateAddressU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CprivateAddressU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3ChostPriorityU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(MatchDirectConnectInfo_t3750452272, ___U3ChostPriorityU3Ek__BackingField_3)); }
	inline int32_t get_U3ChostPriorityU3Ek__BackingField_3() const { return ___U3ChostPriorityU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3ChostPriorityU3Ek__BackingField_3() { return &___U3ChostPriorityU3Ek__BackingField_3; }
	inline void set_U3ChostPriorityU3Ek__BackingField_3(int32_t value)
	{
		___U3ChostPriorityU3Ek__BackingField_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
