#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Networking_Match_Response999782913.h"
#include "UnityEngine_UnityEngine_Networking_Types_NetworkID348058649.h"
#include "UnityEngine_UnityEngine_Networking_Types_NodeID3569487935.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.DropConnectionResponse
struct  DropConnectionResponse_t3742478148  : public Response_t999782913
{
public:
	// UnityEngine.Networking.Types.NetworkID UnityEngine.Networking.Match.DropConnectionResponse::<networkId>k__BackingField
	uint64_t ___U3CnetworkIdU3Ek__BackingField_2;
	// UnityEngine.Networking.Types.NodeID UnityEngine.Networking.Match.DropConnectionResponse::<nodeId>k__BackingField
	uint16_t ___U3CnodeIdU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CnetworkIdU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(DropConnectionResponse_t3742478148, ___U3CnetworkIdU3Ek__BackingField_2)); }
	inline uint64_t get_U3CnetworkIdU3Ek__BackingField_2() const { return ___U3CnetworkIdU3Ek__BackingField_2; }
	inline uint64_t* get_address_of_U3CnetworkIdU3Ek__BackingField_2() { return &___U3CnetworkIdU3Ek__BackingField_2; }
	inline void set_U3CnetworkIdU3Ek__BackingField_2(uint64_t value)
	{
		___U3CnetworkIdU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CnodeIdU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(DropConnectionResponse_t3742478148, ___U3CnodeIdU3Ek__BackingField_3)); }
	inline uint16_t get_U3CnodeIdU3Ek__BackingField_3() const { return ___U3CnodeIdU3Ek__BackingField_3; }
	inline uint16_t* get_address_of_U3CnodeIdU3Ek__BackingField_3() { return &___U3CnodeIdU3Ek__BackingField_3; }
	inline void set_U3CnodeIdU3Ek__BackingField_3(uint16_t value)
	{
		___U3CnodeIdU3Ek__BackingField_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
