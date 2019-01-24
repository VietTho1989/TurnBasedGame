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
// NetData`1<GameManager.Match.Elimination.BracketStateEnd>
struct NetData_1_t412512991;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketStateEndIdentity
struct  BracketStateEndIdentity_t2493228484  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt GameManager.Match.Elimination.BracketStateEndIdentity::winTeamIndexs
	SyncListInt_t3316705628 * ___winTeamIndexs_17;
	// UnityEngine.Networking.SyncListInt GameManager.Match.Elimination.BracketStateEndIdentity::loseTeamIndexs
	SyncListInt_t3316705628 * ___loseTeamIndexs_18;
	// NetData`1<GameManager.Match.Elimination.BracketStateEnd> GameManager.Match.Elimination.BracketStateEndIdentity::netData
	NetData_1_t412512991 * ___netData_19;

public:
	inline static int32_t get_offset_of_winTeamIndexs_17() { return static_cast<int32_t>(offsetof(BracketStateEndIdentity_t2493228484, ___winTeamIndexs_17)); }
	inline SyncListInt_t3316705628 * get_winTeamIndexs_17() const { return ___winTeamIndexs_17; }
	inline SyncListInt_t3316705628 ** get_address_of_winTeamIndexs_17() { return &___winTeamIndexs_17; }
	inline void set_winTeamIndexs_17(SyncListInt_t3316705628 * value)
	{
		___winTeamIndexs_17 = value;
		Il2CppCodeGenWriteBarrier(&___winTeamIndexs_17, value);
	}

	inline static int32_t get_offset_of_loseTeamIndexs_18() { return static_cast<int32_t>(offsetof(BracketStateEndIdentity_t2493228484, ___loseTeamIndexs_18)); }
	inline SyncListInt_t3316705628 * get_loseTeamIndexs_18() const { return ___loseTeamIndexs_18; }
	inline SyncListInt_t3316705628 ** get_address_of_loseTeamIndexs_18() { return &___loseTeamIndexs_18; }
	inline void set_loseTeamIndexs_18(SyncListInt_t3316705628 * value)
	{
		___loseTeamIndexs_18 = value;
		Il2CppCodeGenWriteBarrier(&___loseTeamIndexs_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(BracketStateEndIdentity_t2493228484, ___netData_19)); }
	inline NetData_1_t412512991 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t412512991 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t412512991 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct BracketStateEndIdentity_t2493228484_StaticFields
{
public:
	// System.Int32 GameManager.Match.Elimination.BracketStateEndIdentity::kListwinTeamIndexs
	int32_t ___kListwinTeamIndexs_20;
	// System.Int32 GameManager.Match.Elimination.BracketStateEndIdentity::kListloseTeamIndexs
	int32_t ___kListloseTeamIndexs_21;

public:
	inline static int32_t get_offset_of_kListwinTeamIndexs_20() { return static_cast<int32_t>(offsetof(BracketStateEndIdentity_t2493228484_StaticFields, ___kListwinTeamIndexs_20)); }
	inline int32_t get_kListwinTeamIndexs_20() const { return ___kListwinTeamIndexs_20; }
	inline int32_t* get_address_of_kListwinTeamIndexs_20() { return &___kListwinTeamIndexs_20; }
	inline void set_kListwinTeamIndexs_20(int32_t value)
	{
		___kListwinTeamIndexs_20 = value;
	}

	inline static int32_t get_offset_of_kListloseTeamIndexs_21() { return static_cast<int32_t>(offsetof(BracketStateEndIdentity_t2493228484_StaticFields, ___kListloseTeamIndexs_21)); }
	inline int32_t get_kListloseTeamIndexs_21() const { return ___kListloseTeamIndexs_21; }
	inline int32_t* get_address_of_kListloseTeamIndexs_21() { return &___kListloseTeamIndexs_21; }
	inline void set_kListloseTeamIndexs_21(int32_t value)
	{
		___kListloseTeamIndexs_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
