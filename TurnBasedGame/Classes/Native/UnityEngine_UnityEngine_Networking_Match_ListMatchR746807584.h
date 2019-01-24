#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Networking_Match_Request1834273339.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Int64>
struct Dictionary_2_t2823857299;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.ListMatchRequest
struct  ListMatchRequest_t746807584  : public Request_t1834273339
{
public:
	// System.Int32 UnityEngine.Networking.Match.ListMatchRequest::<pageSize>k__BackingField
	int32_t ___U3CpageSizeU3Ek__BackingField_5;
	// System.Int32 UnityEngine.Networking.Match.ListMatchRequest::<pageNum>k__BackingField
	int32_t ___U3CpageNumU3Ek__BackingField_6;
	// System.String UnityEngine.Networking.Match.ListMatchRequest::<nameFilter>k__BackingField
	String_t* ___U3CnameFilterU3Ek__BackingField_7;
	// System.Boolean UnityEngine.Networking.Match.ListMatchRequest::<filterOutPrivateMatches>k__BackingField
	bool ___U3CfilterOutPrivateMatchesU3Ek__BackingField_8;
	// System.Int32 UnityEngine.Networking.Match.ListMatchRequest::<eloScore>k__BackingField
	int32_t ___U3CeloScoreU3Ek__BackingField_9;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int64> UnityEngine.Networking.Match.ListMatchRequest::<matchAttributeFilterLessThan>k__BackingField
	Dictionary_2_t2823857299 * ___U3CmatchAttributeFilterLessThanU3Ek__BackingField_10;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int64> UnityEngine.Networking.Match.ListMatchRequest::<matchAttributeFilterEqualTo>k__BackingField
	Dictionary_2_t2823857299 * ___U3CmatchAttributeFilterEqualToU3Ek__BackingField_11;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int64> UnityEngine.Networking.Match.ListMatchRequest::<matchAttributeFilterGreaterThan>k__BackingField
	Dictionary_2_t2823857299 * ___U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12;

public:
	inline static int32_t get_offset_of_U3CpageSizeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CpageSizeU3Ek__BackingField_5)); }
	inline int32_t get_U3CpageSizeU3Ek__BackingField_5() const { return ___U3CpageSizeU3Ek__BackingField_5; }
	inline int32_t* get_address_of_U3CpageSizeU3Ek__BackingField_5() { return &___U3CpageSizeU3Ek__BackingField_5; }
	inline void set_U3CpageSizeU3Ek__BackingField_5(int32_t value)
	{
		___U3CpageSizeU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CpageNumU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CpageNumU3Ek__BackingField_6)); }
	inline int32_t get_U3CpageNumU3Ek__BackingField_6() const { return ___U3CpageNumU3Ek__BackingField_6; }
	inline int32_t* get_address_of_U3CpageNumU3Ek__BackingField_6() { return &___U3CpageNumU3Ek__BackingField_6; }
	inline void set_U3CpageNumU3Ek__BackingField_6(int32_t value)
	{
		___U3CpageNumU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of_U3CnameFilterU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CnameFilterU3Ek__BackingField_7)); }
	inline String_t* get_U3CnameFilterU3Ek__BackingField_7() const { return ___U3CnameFilterU3Ek__BackingField_7; }
	inline String_t** get_address_of_U3CnameFilterU3Ek__BackingField_7() { return &___U3CnameFilterU3Ek__BackingField_7; }
	inline void set_U3CnameFilterU3Ek__BackingField_7(String_t* value)
	{
		___U3CnameFilterU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CnameFilterU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CfilterOutPrivateMatchesU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CfilterOutPrivateMatchesU3Ek__BackingField_8)); }
	inline bool get_U3CfilterOutPrivateMatchesU3Ek__BackingField_8() const { return ___U3CfilterOutPrivateMatchesU3Ek__BackingField_8; }
	inline bool* get_address_of_U3CfilterOutPrivateMatchesU3Ek__BackingField_8() { return &___U3CfilterOutPrivateMatchesU3Ek__BackingField_8; }
	inline void set_U3CfilterOutPrivateMatchesU3Ek__BackingField_8(bool value)
	{
		___U3CfilterOutPrivateMatchesU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CeloScoreU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CeloScoreU3Ek__BackingField_9)); }
	inline int32_t get_U3CeloScoreU3Ek__BackingField_9() const { return ___U3CeloScoreU3Ek__BackingField_9; }
	inline int32_t* get_address_of_U3CeloScoreU3Ek__BackingField_9() { return &___U3CeloScoreU3Ek__BackingField_9; }
	inline void set_U3CeloScoreU3Ek__BackingField_9(int32_t value)
	{
		___U3CeloScoreU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of_U3CmatchAttributeFilterLessThanU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CmatchAttributeFilterLessThanU3Ek__BackingField_10)); }
	inline Dictionary_2_t2823857299 * get_U3CmatchAttributeFilterLessThanU3Ek__BackingField_10() const { return ___U3CmatchAttributeFilterLessThanU3Ek__BackingField_10; }
	inline Dictionary_2_t2823857299 ** get_address_of_U3CmatchAttributeFilterLessThanU3Ek__BackingField_10() { return &___U3CmatchAttributeFilterLessThanU3Ek__BackingField_10; }
	inline void set_U3CmatchAttributeFilterLessThanU3Ek__BackingField_10(Dictionary_2_t2823857299 * value)
	{
		___U3CmatchAttributeFilterLessThanU3Ek__BackingField_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CmatchAttributeFilterLessThanU3Ek__BackingField_10, value);
	}

	inline static int32_t get_offset_of_U3CmatchAttributeFilterEqualToU3Ek__BackingField_11() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CmatchAttributeFilterEqualToU3Ek__BackingField_11)); }
	inline Dictionary_2_t2823857299 * get_U3CmatchAttributeFilterEqualToU3Ek__BackingField_11() const { return ___U3CmatchAttributeFilterEqualToU3Ek__BackingField_11; }
	inline Dictionary_2_t2823857299 ** get_address_of_U3CmatchAttributeFilterEqualToU3Ek__BackingField_11() { return &___U3CmatchAttributeFilterEqualToU3Ek__BackingField_11; }
	inline void set_U3CmatchAttributeFilterEqualToU3Ek__BackingField_11(Dictionary_2_t2823857299 * value)
	{
		___U3CmatchAttributeFilterEqualToU3Ek__BackingField_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CmatchAttributeFilterEqualToU3Ek__BackingField_11, value);
	}

	inline static int32_t get_offset_of_U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12() { return static_cast<int32_t>(offsetof(ListMatchRequest_t746807584, ___U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12)); }
	inline Dictionary_2_t2823857299 * get_U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12() const { return ___U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12; }
	inline Dictionary_2_t2823857299 ** get_address_of_U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12() { return &___U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12; }
	inline void set_U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12(Dictionary_2_t2823857299 * value)
	{
		___U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12 = value;
		Il2CppCodeGenWriteBarrier(&___U3CmatchAttributeFilterGreaterThanU3Ek__BackingField_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
