#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.Elimination.EliminationRound>
struct NetData_1_t3393885780;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationRoundIdentity
struct  EliminationRoundIdentity_t3169761953  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.Elimination.EliminationRoundIdentity::isActive
	bool ___isActive_17;
	// System.Int32 GameManager.Match.Elimination.EliminationRoundIdentity::index
	int32_t ___index_18;
	// NetData`1<GameManager.Match.Elimination.EliminationRound> GameManager.Match.Elimination.EliminationRoundIdentity::netData
	NetData_1_t3393885780 * ___netData_19;

public:
	inline static int32_t get_offset_of_isActive_17() { return static_cast<int32_t>(offsetof(EliminationRoundIdentity_t3169761953, ___isActive_17)); }
	inline bool get_isActive_17() const { return ___isActive_17; }
	inline bool* get_address_of_isActive_17() { return &___isActive_17; }
	inline void set_isActive_17(bool value)
	{
		___isActive_17 = value;
	}

	inline static int32_t get_offset_of_index_18() { return static_cast<int32_t>(offsetof(EliminationRoundIdentity_t3169761953, ___index_18)); }
	inline int32_t get_index_18() const { return ___index_18; }
	inline int32_t* get_address_of_index_18() { return &___index_18; }
	inline void set_index_18(int32_t value)
	{
		___index_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(EliminationRoundIdentity_t3169761953, ___netData_19)); }
	inline NetData_1_t3393885780 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3393885780 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3393885780 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
