﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Networking_Types_NetworkID348058649.h"
#include "UnityEngine_UnityEngine_Networking_Types_NodeID3569487935.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Int64>
struct Dictionary_2_t2823857299;
// System.Collections.Generic.List`1<UnityEngine.Networking.Match.MatchInfoSnapshot/MatchInfoDirectConnectSnapshot>
struct List_1_t1370459572;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.MatchInfoSnapshot
struct  MatchInfoSnapshot_t3179110907  : public Il2CppObject
{
public:
	// UnityEngine.Networking.Types.NetworkID UnityEngine.Networking.Match.MatchInfoSnapshot::<networkId>k__BackingField
	uint64_t ___U3CnetworkIdU3Ek__BackingField_0;
	// UnityEngine.Networking.Types.NodeID UnityEngine.Networking.Match.MatchInfoSnapshot::<hostNodeId>k__BackingField
	uint16_t ___U3ChostNodeIdU3Ek__BackingField_1;
	// System.String UnityEngine.Networking.Match.MatchInfoSnapshot::<name>k__BackingField
	String_t* ___U3CnameU3Ek__BackingField_2;
	// System.Int32 UnityEngine.Networking.Match.MatchInfoSnapshot::<averageEloScore>k__BackingField
	int32_t ___U3CaverageEloScoreU3Ek__BackingField_3;
	// System.Int32 UnityEngine.Networking.Match.MatchInfoSnapshot::<maxSize>k__BackingField
	int32_t ___U3CmaxSizeU3Ek__BackingField_4;
	// System.Int32 UnityEngine.Networking.Match.MatchInfoSnapshot::<currentSize>k__BackingField
	int32_t ___U3CcurrentSizeU3Ek__BackingField_5;
	// System.Boolean UnityEngine.Networking.Match.MatchInfoSnapshot::<isPrivate>k__BackingField
	bool ___U3CisPrivateU3Ek__BackingField_6;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int64> UnityEngine.Networking.Match.MatchInfoSnapshot::<matchAttributes>k__BackingField
	Dictionary_2_t2823857299 * ___U3CmatchAttributesU3Ek__BackingField_7;
	// System.Collections.Generic.List`1<UnityEngine.Networking.Match.MatchInfoSnapshot/MatchInfoDirectConnectSnapshot> UnityEngine.Networking.Match.MatchInfoSnapshot::<directConnectInfos>k__BackingField
	List_1_t1370459572 * ___U3CdirectConnectInfosU3Ek__BackingField_8;

public:
	inline static int32_t get_offset_of_U3CnetworkIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CnetworkIdU3Ek__BackingField_0)); }
	inline uint64_t get_U3CnetworkIdU3Ek__BackingField_0() const { return ___U3CnetworkIdU3Ek__BackingField_0; }
	inline uint64_t* get_address_of_U3CnetworkIdU3Ek__BackingField_0() { return &___U3CnetworkIdU3Ek__BackingField_0; }
	inline void set_U3CnetworkIdU3Ek__BackingField_0(uint64_t value)
	{
		___U3CnetworkIdU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3ChostNodeIdU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3ChostNodeIdU3Ek__BackingField_1)); }
	inline uint16_t get_U3ChostNodeIdU3Ek__BackingField_1() const { return ___U3ChostNodeIdU3Ek__BackingField_1; }
	inline uint16_t* get_address_of_U3ChostNodeIdU3Ek__BackingField_1() { return &___U3ChostNodeIdU3Ek__BackingField_1; }
	inline void set_U3ChostNodeIdU3Ek__BackingField_1(uint16_t value)
	{
		___U3ChostNodeIdU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CnameU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CnameU3Ek__BackingField_2)); }
	inline String_t* get_U3CnameU3Ek__BackingField_2() const { return ___U3CnameU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CnameU3Ek__BackingField_2() { return &___U3CnameU3Ek__BackingField_2; }
	inline void set_U3CnameU3Ek__BackingField_2(String_t* value)
	{
		___U3CnameU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CnameU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CaverageEloScoreU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CaverageEloScoreU3Ek__BackingField_3)); }
	inline int32_t get_U3CaverageEloScoreU3Ek__BackingField_3() const { return ___U3CaverageEloScoreU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CaverageEloScoreU3Ek__BackingField_3() { return &___U3CaverageEloScoreU3Ek__BackingField_3; }
	inline void set_U3CaverageEloScoreU3Ek__BackingField_3(int32_t value)
	{
		___U3CaverageEloScoreU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CmaxSizeU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CmaxSizeU3Ek__BackingField_4)); }
	inline int32_t get_U3CmaxSizeU3Ek__BackingField_4() const { return ___U3CmaxSizeU3Ek__BackingField_4; }
	inline int32_t* get_address_of_U3CmaxSizeU3Ek__BackingField_4() { return &___U3CmaxSizeU3Ek__BackingField_4; }
	inline void set_U3CmaxSizeU3Ek__BackingField_4(int32_t value)
	{
		___U3CmaxSizeU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CcurrentSizeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CcurrentSizeU3Ek__BackingField_5)); }
	inline int32_t get_U3CcurrentSizeU3Ek__BackingField_5() const { return ___U3CcurrentSizeU3Ek__BackingField_5; }
	inline int32_t* get_address_of_U3CcurrentSizeU3Ek__BackingField_5() { return &___U3CcurrentSizeU3Ek__BackingField_5; }
	inline void set_U3CcurrentSizeU3Ek__BackingField_5(int32_t value)
	{
		___U3CcurrentSizeU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CisPrivateU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CisPrivateU3Ek__BackingField_6)); }
	inline bool get_U3CisPrivateU3Ek__BackingField_6() const { return ___U3CisPrivateU3Ek__BackingField_6; }
	inline bool* get_address_of_U3CisPrivateU3Ek__BackingField_6() { return &___U3CisPrivateU3Ek__BackingField_6; }
	inline void set_U3CisPrivateU3Ek__BackingField_6(bool value)
	{
		___U3CisPrivateU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of_U3CmatchAttributesU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CmatchAttributesU3Ek__BackingField_7)); }
	inline Dictionary_2_t2823857299 * get_U3CmatchAttributesU3Ek__BackingField_7() const { return ___U3CmatchAttributesU3Ek__BackingField_7; }
	inline Dictionary_2_t2823857299 ** get_address_of_U3CmatchAttributesU3Ek__BackingField_7() { return &___U3CmatchAttributesU3Ek__BackingField_7; }
	inline void set_U3CmatchAttributesU3Ek__BackingField_7(Dictionary_2_t2823857299 * value)
	{
		___U3CmatchAttributesU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CmatchAttributesU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CdirectConnectInfosU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(MatchInfoSnapshot_t3179110907, ___U3CdirectConnectInfosU3Ek__BackingField_8)); }
	inline List_1_t1370459572 * get_U3CdirectConnectInfosU3Ek__BackingField_8() const { return ___U3CdirectConnectInfosU3Ek__BackingField_8; }
	inline List_1_t1370459572 ** get_address_of_U3CdirectConnectInfosU3Ek__BackingField_8() { return &___U3CdirectConnectInfosU3Ek__BackingField_8; }
	inline void set_U3CdirectConnectInfosU3Ek__BackingField_8(List_1_t1370459572 * value)
	{
		___U3CdirectConnectInfosU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CdirectConnectInfosU3Ek__BackingField_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif