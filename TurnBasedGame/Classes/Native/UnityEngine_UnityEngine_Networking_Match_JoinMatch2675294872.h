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

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.JoinMatchRequest
struct  JoinMatchRequest_t2675294872  : public Request_t1834273339
{
public:
	// UnityEngine.Networking.Types.NetworkID UnityEngine.Networking.Match.JoinMatchRequest::<networkId>k__BackingField
	uint64_t ___U3CnetworkIdU3Ek__BackingField_5;
	// System.String UnityEngine.Networking.Match.JoinMatchRequest::<publicAddress>k__BackingField
	String_t* ___U3CpublicAddressU3Ek__BackingField_6;
	// System.String UnityEngine.Networking.Match.JoinMatchRequest::<privateAddress>k__BackingField
	String_t* ___U3CprivateAddressU3Ek__BackingField_7;
	// System.Int32 UnityEngine.Networking.Match.JoinMatchRequest::<eloScore>k__BackingField
	int32_t ___U3CeloScoreU3Ek__BackingField_8;
	// System.String UnityEngine.Networking.Match.JoinMatchRequest::<password>k__BackingField
	String_t* ___U3CpasswordU3Ek__BackingField_9;

public:
	inline static int32_t get_offset_of_U3CnetworkIdU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(JoinMatchRequest_t2675294872, ___U3CnetworkIdU3Ek__BackingField_5)); }
	inline uint64_t get_U3CnetworkIdU3Ek__BackingField_5() const { return ___U3CnetworkIdU3Ek__BackingField_5; }
	inline uint64_t* get_address_of_U3CnetworkIdU3Ek__BackingField_5() { return &___U3CnetworkIdU3Ek__BackingField_5; }
	inline void set_U3CnetworkIdU3Ek__BackingField_5(uint64_t value)
	{
		___U3CnetworkIdU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CpublicAddressU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(JoinMatchRequest_t2675294872, ___U3CpublicAddressU3Ek__BackingField_6)); }
	inline String_t* get_U3CpublicAddressU3Ek__BackingField_6() const { return ___U3CpublicAddressU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CpublicAddressU3Ek__BackingField_6() { return &___U3CpublicAddressU3Ek__BackingField_6; }
	inline void set_U3CpublicAddressU3Ek__BackingField_6(String_t* value)
	{
		___U3CpublicAddressU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CpublicAddressU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CprivateAddressU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(JoinMatchRequest_t2675294872, ___U3CprivateAddressU3Ek__BackingField_7)); }
	inline String_t* get_U3CprivateAddressU3Ek__BackingField_7() const { return ___U3CprivateAddressU3Ek__BackingField_7; }
	inline String_t** get_address_of_U3CprivateAddressU3Ek__BackingField_7() { return &___U3CprivateAddressU3Ek__BackingField_7; }
	inline void set_U3CprivateAddressU3Ek__BackingField_7(String_t* value)
	{
		___U3CprivateAddressU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CprivateAddressU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CeloScoreU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(JoinMatchRequest_t2675294872, ___U3CeloScoreU3Ek__BackingField_8)); }
	inline int32_t get_U3CeloScoreU3Ek__BackingField_8() const { return ___U3CeloScoreU3Ek__BackingField_8; }
	inline int32_t* get_address_of_U3CeloScoreU3Ek__BackingField_8() { return &___U3CeloScoreU3Ek__BackingField_8; }
	inline void set_U3CeloScoreU3Ek__BackingField_8(int32_t value)
	{
		___U3CeloScoreU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CpasswordU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(JoinMatchRequest_t2675294872, ___U3CpasswordU3Ek__BackingField_9)); }
	inline String_t* get_U3CpasswordU3Ek__BackingField_9() const { return ___U3CpasswordU3Ek__BackingField_9; }
	inline String_t** get_address_of_U3CpasswordU3Ek__BackingField_9() { return &___U3CpasswordU3Ek__BackingField_9; }
	inline void set_U3CpasswordU3Ek__BackingField_9(String_t* value)
	{
		___U3CpasswordU3Ek__BackingField_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CpasswordU3Ek__BackingField_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
