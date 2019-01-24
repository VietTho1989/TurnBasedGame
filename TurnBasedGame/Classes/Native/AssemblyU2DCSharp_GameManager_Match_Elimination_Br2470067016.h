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
// NetData`1<GameManager.Match.Elimination.Bracket>
struct NetData_1_t674355891;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketIdentity
struct  BracketIdentity_t2470067016  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.Elimination.BracketIdentity::isActive
	bool ___isActive_17;
	// System.Int32 GameManager.Match.Elimination.BracketIdentity::index
	int32_t ___index_18;
	// UnityEngine.Networking.SyncListInt GameManager.Match.Elimination.BracketIdentity::byeTeamIndexs
	SyncListInt_t3316705628 * ___byeTeamIndexs_19;
	// NetData`1<GameManager.Match.Elimination.Bracket> GameManager.Match.Elimination.BracketIdentity::netData
	NetData_1_t674355891 * ___netData_20;

public:
	inline static int32_t get_offset_of_isActive_17() { return static_cast<int32_t>(offsetof(BracketIdentity_t2470067016, ___isActive_17)); }
	inline bool get_isActive_17() const { return ___isActive_17; }
	inline bool* get_address_of_isActive_17() { return &___isActive_17; }
	inline void set_isActive_17(bool value)
	{
		___isActive_17 = value;
	}

	inline static int32_t get_offset_of_index_18() { return static_cast<int32_t>(offsetof(BracketIdentity_t2470067016, ___index_18)); }
	inline int32_t get_index_18() const { return ___index_18; }
	inline int32_t* get_address_of_index_18() { return &___index_18; }
	inline void set_index_18(int32_t value)
	{
		___index_18 = value;
	}

	inline static int32_t get_offset_of_byeTeamIndexs_19() { return static_cast<int32_t>(offsetof(BracketIdentity_t2470067016, ___byeTeamIndexs_19)); }
	inline SyncListInt_t3316705628 * get_byeTeamIndexs_19() const { return ___byeTeamIndexs_19; }
	inline SyncListInt_t3316705628 ** get_address_of_byeTeamIndexs_19() { return &___byeTeamIndexs_19; }
	inline void set_byeTeamIndexs_19(SyncListInt_t3316705628 * value)
	{
		___byeTeamIndexs_19 = value;
		Il2CppCodeGenWriteBarrier(&___byeTeamIndexs_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(BracketIdentity_t2470067016, ___netData_20)); }
	inline NetData_1_t674355891 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t674355891 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t674355891 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct BracketIdentity_t2470067016_StaticFields
{
public:
	// System.Int32 GameManager.Match.Elimination.BracketIdentity::kListbyeTeamIndexs
	int32_t ___kListbyeTeamIndexs_21;

public:
	inline static int32_t get_offset_of_kListbyeTeamIndexs_21() { return static_cast<int32_t>(offsetof(BracketIdentity_t2470067016_StaticFields, ___kListbyeTeamIndexs_21)); }
	inline int32_t get_kListbyeTeamIndexs_21() const { return ___kListbyeTeamIndexs_21; }
	inline int32_t* get_address_of_kListbyeTeamIndexs_21() { return &___kListbyeTeamIndexs_21; }
	inline void set_kListbyeTeamIndexs_21(int32_t value)
	{
		___kListbyeTeamIndexs_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
