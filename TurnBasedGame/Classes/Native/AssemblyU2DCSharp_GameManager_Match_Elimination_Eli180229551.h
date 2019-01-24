#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// NetData`1<GameManager.Match.Elimination.EliminationFactory>
struct NetData_1_t14968842;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationFactoryIdentity
struct  EliminationFactoryIdentity_t180229551  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListUInt GameManager.Match.Elimination.EliminationFactoryIdentity::initTeamCounts
	SyncListUInt_t2190275715 * ___initTeamCounts_17;
	// NetData`1<GameManager.Match.Elimination.EliminationFactory> GameManager.Match.Elimination.EliminationFactoryIdentity::netData
	NetData_1_t14968842 * ___netData_18;

public:
	inline static int32_t get_offset_of_initTeamCounts_17() { return static_cast<int32_t>(offsetof(EliminationFactoryIdentity_t180229551, ___initTeamCounts_17)); }
	inline SyncListUInt_t2190275715 * get_initTeamCounts_17() const { return ___initTeamCounts_17; }
	inline SyncListUInt_t2190275715 ** get_address_of_initTeamCounts_17() { return &___initTeamCounts_17; }
	inline void set_initTeamCounts_17(SyncListUInt_t2190275715 * value)
	{
		___initTeamCounts_17 = value;
		Il2CppCodeGenWriteBarrier(&___initTeamCounts_17, value);
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(EliminationFactoryIdentity_t180229551, ___netData_18)); }
	inline NetData_1_t14968842 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t14968842 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t14968842 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

struct EliminationFactoryIdentity_t180229551_StaticFields
{
public:
	// System.Int32 GameManager.Match.Elimination.EliminationFactoryIdentity::kListinitTeamCounts
	int32_t ___kListinitTeamCounts_19;

public:
	inline static int32_t get_offset_of_kListinitTeamCounts_19() { return static_cast<int32_t>(offsetof(EliminationFactoryIdentity_t180229551_StaticFields, ___kListinitTeamCounts_19)); }
	inline int32_t get_kListinitTeamCounts_19() const { return ___kListinitTeamCounts_19; }
	inline int32_t* get_address_of_kListinitTeamCounts_19() { return &___kListinitTeamCounts_19; }
	inline void set_kListinitTeamCounts_19(int32_t value)
	{
		___kListinitTeamCounts_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
