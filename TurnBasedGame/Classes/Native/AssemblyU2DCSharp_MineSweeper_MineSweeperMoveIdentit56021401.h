#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<MineSweeper.MineSweeperMove>
struct NetData_1_t4068557476;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.MineSweeperMoveIdentity
struct  MineSweeperMoveIdentity_t56021401  : public DataIdentity_t543951486
{
public:
	// System.Int32 MineSweeper.MineSweeperMoveIdentity::move
	int32_t ___move_17;
	// System.Int32 MineSweeper.MineSweeperMoveIdentity::X
	int32_t ___X_18;
	// System.Int32 MineSweeper.MineSweeperMoveIdentity::Y
	int32_t ___Y_19;
	// NetData`1<MineSweeper.MineSweeperMove> MineSweeper.MineSweeperMoveIdentity::netData
	NetData_1_t4068557476 * ___netData_20;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(MineSweeperMoveIdentity_t56021401, ___move_17)); }
	inline int32_t get_move_17() const { return ___move_17; }
	inline int32_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(int32_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_X_18() { return static_cast<int32_t>(offsetof(MineSweeperMoveIdentity_t56021401, ___X_18)); }
	inline int32_t get_X_18() const { return ___X_18; }
	inline int32_t* get_address_of_X_18() { return &___X_18; }
	inline void set_X_18(int32_t value)
	{
		___X_18 = value;
	}

	inline static int32_t get_offset_of_Y_19() { return static_cast<int32_t>(offsetof(MineSweeperMoveIdentity_t56021401, ___Y_19)); }
	inline int32_t get_Y_19() const { return ___Y_19; }
	inline int32_t* get_address_of_Y_19() { return &___Y_19; }
	inline void set_Y_19(int32_t value)
	{
		___Y_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(MineSweeperMoveIdentity_t56021401, ___netData_20)); }
	inline NetData_1_t4068557476 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t4068557476 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t4068557476 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
