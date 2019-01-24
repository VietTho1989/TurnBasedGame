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
// NetData`1<GameManager.Match.Elimination.BracketContest>
struct NetData_1_t1100727255;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketContestIdentity
struct  BracketContestIdentity_t2387324896  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.Elimination.BracketContestIdentity::isActive
	bool ___isActive_17;
	// System.Int32 GameManager.Match.Elimination.BracketContestIdentity::index
	int32_t ___index_18;
	// UnityEngine.Networking.SyncListInt GameManager.Match.Elimination.BracketContestIdentity::teamIndexs
	SyncListInt_t3316705628 * ___teamIndexs_19;
	// NetData`1<GameManager.Match.Elimination.BracketContest> GameManager.Match.Elimination.BracketContestIdentity::netData
	NetData_1_t1100727255 * ___netData_20;

public:
	inline static int32_t get_offset_of_isActive_17() { return static_cast<int32_t>(offsetof(BracketContestIdentity_t2387324896, ___isActive_17)); }
	inline bool get_isActive_17() const { return ___isActive_17; }
	inline bool* get_address_of_isActive_17() { return &___isActive_17; }
	inline void set_isActive_17(bool value)
	{
		___isActive_17 = value;
	}

	inline static int32_t get_offset_of_index_18() { return static_cast<int32_t>(offsetof(BracketContestIdentity_t2387324896, ___index_18)); }
	inline int32_t get_index_18() const { return ___index_18; }
	inline int32_t* get_address_of_index_18() { return &___index_18; }
	inline void set_index_18(int32_t value)
	{
		___index_18 = value;
	}

	inline static int32_t get_offset_of_teamIndexs_19() { return static_cast<int32_t>(offsetof(BracketContestIdentity_t2387324896, ___teamIndexs_19)); }
	inline SyncListInt_t3316705628 * get_teamIndexs_19() const { return ___teamIndexs_19; }
	inline SyncListInt_t3316705628 ** get_address_of_teamIndexs_19() { return &___teamIndexs_19; }
	inline void set_teamIndexs_19(SyncListInt_t3316705628 * value)
	{
		___teamIndexs_19 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndexs_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(BracketContestIdentity_t2387324896, ___netData_20)); }
	inline NetData_1_t1100727255 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t1100727255 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t1100727255 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct BracketContestIdentity_t2387324896_StaticFields
{
public:
	// System.Int32 GameManager.Match.Elimination.BracketContestIdentity::kListteamIndexs
	int32_t ___kListteamIndexs_21;

public:
	inline static int32_t get_offset_of_kListteamIndexs_21() { return static_cast<int32_t>(offsetof(BracketContestIdentity_t2387324896_StaticFields, ___kListteamIndexs_21)); }
	inline int32_t get_kListteamIndexs_21() const { return ___kListteamIndexs_21; }
	inline int32_t* get_address_of_kListteamIndexs_21() { return &___kListteamIndexs_21; }
	inline void set_kListteamIndexs_21(int32_t value)
	{
		___kListteamIndexs_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
