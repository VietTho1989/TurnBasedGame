#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_MineSweeper_MineSweeperAI_FirstM1511575556.h"

// NetData`1<MineSweeper.MineSweeperAI>
struct NetData_1_t2595135587;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.MineSweeperAIIdentity
struct  MineSweeperAIIdentity_t3642508940  : public DataIdentity_t543951486
{
public:
	// MineSweeper.MineSweeperAI/FirstMoveType MineSweeper.MineSweeperAIIdentity::firstMoveType
	int32_t ___firstMoveType_17;
	// NetData`1<MineSweeper.MineSweeperAI> MineSweeper.MineSweeperAIIdentity::netData
	NetData_1_t2595135587 * ___netData_18;

public:
	inline static int32_t get_offset_of_firstMoveType_17() { return static_cast<int32_t>(offsetof(MineSweeperAIIdentity_t3642508940, ___firstMoveType_17)); }
	inline int32_t get_firstMoveType_17() const { return ___firstMoveType_17; }
	inline int32_t* get_address_of_firstMoveType_17() { return &___firstMoveType_17; }
	inline void set_firstMoveType_17(int32_t value)
	{
		___firstMoveType_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(MineSweeperAIIdentity_t3642508940, ___netData_18)); }
	inline NetData_1_t2595135587 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t2595135587 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t2595135587 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
