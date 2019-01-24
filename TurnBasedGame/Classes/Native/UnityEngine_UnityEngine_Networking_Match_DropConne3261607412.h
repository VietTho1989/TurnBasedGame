#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Networking_Match_Request1834273339.h"
#include "UnityEngine_UnityEngine_Networking_Types_NetworkID348058649.h"
#include "UnityEngine_UnityEngine_Networking_Types_NodeID3569487935.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.DropConnectionRequest
struct  DropConnectionRequest_t3261607412  : public Request_t1834273339
{
public:
	// UnityEngine.Networking.Types.NetworkID UnityEngine.Networking.Match.DropConnectionRequest::<networkId>k__BackingField
	uint64_t ___U3CnetworkIdU3Ek__BackingField_5;
	// UnityEngine.Networking.Types.NodeID UnityEngine.Networking.Match.DropConnectionRequest::<nodeId>k__BackingField
	uint16_t ___U3CnodeIdU3Ek__BackingField_6;

public:
	inline static int32_t get_offset_of_U3CnetworkIdU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(DropConnectionRequest_t3261607412, ___U3CnetworkIdU3Ek__BackingField_5)); }
	inline uint64_t get_U3CnetworkIdU3Ek__BackingField_5() const { return ___U3CnetworkIdU3Ek__BackingField_5; }
	inline uint64_t* get_address_of_U3CnetworkIdU3Ek__BackingField_5() { return &___U3CnetworkIdU3Ek__BackingField_5; }
	inline void set_U3CnetworkIdU3Ek__BackingField_5(uint64_t value)
	{
		___U3CnetworkIdU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CnodeIdU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(DropConnectionRequest_t3261607412, ___U3CnodeIdU3Ek__BackingField_6)); }
	inline uint16_t get_U3CnodeIdU3Ek__BackingField_6() const { return ___U3CnodeIdU3Ek__BackingField_6; }
	inline uint16_t* get_address_of_U3CnodeIdU3Ek__BackingField_6() { return &___U3CnodeIdU3Ek__BackingField_6; }
	inline void set_U3CnodeIdU3Ek__BackingField_6(uint16_t value)
	{
		___U3CnodeIdU3Ek__BackingField_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
