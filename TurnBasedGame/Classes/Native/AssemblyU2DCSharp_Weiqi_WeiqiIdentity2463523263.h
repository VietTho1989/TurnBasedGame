#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<Weiqi.Weiqi>
struct NetData_1_t1090304262;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiIdentity
struct  WeiqiIdentity_t2463523263  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Weiqi.WeiqiIdentity::scoreOwnerMap
	SyncListInt_t3316705628 * ___scoreOwnerMap_17;
	// System.Int32 Weiqi.WeiqiIdentity::scoreOwnerMapSize
	int32_t ___scoreOwnerMapSize_18;
	// System.Int32 Weiqi.WeiqiIdentity::scoreBlack
	int32_t ___scoreBlack_19;
	// System.Int32 Weiqi.WeiqiIdentity::scoreWhite
	int32_t ___scoreWhite_20;
	// System.Int32 Weiqi.WeiqiIdentity::dame
	int32_t ___dame_21;
	// System.Single Weiqi.WeiqiIdentity::score
	float ___score_22;
	// NetData`1<Weiqi.Weiqi> Weiqi.WeiqiIdentity::netData
	NetData_1_t1090304262 * ___netData_23;

public:
	inline static int32_t get_offset_of_scoreOwnerMap_17() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___scoreOwnerMap_17)); }
	inline SyncListInt_t3316705628 * get_scoreOwnerMap_17() const { return ___scoreOwnerMap_17; }
	inline SyncListInt_t3316705628 ** get_address_of_scoreOwnerMap_17() { return &___scoreOwnerMap_17; }
	inline void set_scoreOwnerMap_17(SyncListInt_t3316705628 * value)
	{
		___scoreOwnerMap_17 = value;
		Il2CppCodeGenWriteBarrier(&___scoreOwnerMap_17, value);
	}

	inline static int32_t get_offset_of_scoreOwnerMapSize_18() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___scoreOwnerMapSize_18)); }
	inline int32_t get_scoreOwnerMapSize_18() const { return ___scoreOwnerMapSize_18; }
	inline int32_t* get_address_of_scoreOwnerMapSize_18() { return &___scoreOwnerMapSize_18; }
	inline void set_scoreOwnerMapSize_18(int32_t value)
	{
		___scoreOwnerMapSize_18 = value;
	}

	inline static int32_t get_offset_of_scoreBlack_19() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___scoreBlack_19)); }
	inline int32_t get_scoreBlack_19() const { return ___scoreBlack_19; }
	inline int32_t* get_address_of_scoreBlack_19() { return &___scoreBlack_19; }
	inline void set_scoreBlack_19(int32_t value)
	{
		___scoreBlack_19 = value;
	}

	inline static int32_t get_offset_of_scoreWhite_20() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___scoreWhite_20)); }
	inline int32_t get_scoreWhite_20() const { return ___scoreWhite_20; }
	inline int32_t* get_address_of_scoreWhite_20() { return &___scoreWhite_20; }
	inline void set_scoreWhite_20(int32_t value)
	{
		___scoreWhite_20 = value;
	}

	inline static int32_t get_offset_of_dame_21() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___dame_21)); }
	inline int32_t get_dame_21() const { return ___dame_21; }
	inline int32_t* get_address_of_dame_21() { return &___dame_21; }
	inline void set_dame_21(int32_t value)
	{
		___dame_21 = value;
	}

	inline static int32_t get_offset_of_score_22() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___score_22)); }
	inline float get_score_22() const { return ___score_22; }
	inline float* get_address_of_score_22() { return &___score_22; }
	inline void set_score_22(float value)
	{
		___score_22 = value;
	}

	inline static int32_t get_offset_of_netData_23() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263, ___netData_23)); }
	inline NetData_1_t1090304262 * get_netData_23() const { return ___netData_23; }
	inline NetData_1_t1090304262 ** get_address_of_netData_23() { return &___netData_23; }
	inline void set_netData_23(NetData_1_t1090304262 * value)
	{
		___netData_23 = value;
		Il2CppCodeGenWriteBarrier(&___netData_23, value);
	}
};

struct WeiqiIdentity_t2463523263_StaticFields
{
public:
	// System.Int32 Weiqi.WeiqiIdentity::kListscoreOwnerMap
	int32_t ___kListscoreOwnerMap_24;

public:
	inline static int32_t get_offset_of_kListscoreOwnerMap_24() { return static_cast<int32_t>(offsetof(WeiqiIdentity_t2463523263_StaticFields, ___kListscoreOwnerMap_24)); }
	inline int32_t get_kListscoreOwnerMap_24() const { return ___kListscoreOwnerMap_24; }
	inline int32_t* get_address_of_kListscoreOwnerMap_24() { return &___kListscoreOwnerMap_24; }
	inline void set_kListscoreOwnerMap_24(int32_t value)
	{
		___kListscoreOwnerMap_24 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
