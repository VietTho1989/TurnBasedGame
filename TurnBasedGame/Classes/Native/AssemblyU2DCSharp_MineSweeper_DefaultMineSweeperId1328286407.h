#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<MineSweeper.DefaultMineSweeper>
struct NetData_1_t512747450;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.DefaultMineSweeperIdentity
struct  DefaultMineSweeperIdentity_t1328286407  : public DataIdentity_t543951486
{
public:
	// System.Int32 MineSweeper.DefaultMineSweeperIdentity::N
	int32_t ___N_17;
	// System.Int32 MineSweeper.DefaultMineSweeperIdentity::M
	int32_t ___M_18;
	// System.Single MineSweeper.DefaultMineSweeperIdentity::minK
	float ___minK_19;
	// System.Single MineSweeper.DefaultMineSweeperIdentity::maxK
	float ___maxK_20;
	// System.Boolean MineSweeper.DefaultMineSweeperIdentity::allowWatchBomb
	bool ___allowWatchBomb_21;
	// NetData`1<MineSweeper.DefaultMineSweeper> MineSweeper.DefaultMineSweeperIdentity::netData
	NetData_1_t512747450 * ___netData_22;

public:
	inline static int32_t get_offset_of_N_17() { return static_cast<int32_t>(offsetof(DefaultMineSweeperIdentity_t1328286407, ___N_17)); }
	inline int32_t get_N_17() const { return ___N_17; }
	inline int32_t* get_address_of_N_17() { return &___N_17; }
	inline void set_N_17(int32_t value)
	{
		___N_17 = value;
	}

	inline static int32_t get_offset_of_M_18() { return static_cast<int32_t>(offsetof(DefaultMineSweeperIdentity_t1328286407, ___M_18)); }
	inline int32_t get_M_18() const { return ___M_18; }
	inline int32_t* get_address_of_M_18() { return &___M_18; }
	inline void set_M_18(int32_t value)
	{
		___M_18 = value;
	}

	inline static int32_t get_offset_of_minK_19() { return static_cast<int32_t>(offsetof(DefaultMineSweeperIdentity_t1328286407, ___minK_19)); }
	inline float get_minK_19() const { return ___minK_19; }
	inline float* get_address_of_minK_19() { return &___minK_19; }
	inline void set_minK_19(float value)
	{
		___minK_19 = value;
	}

	inline static int32_t get_offset_of_maxK_20() { return static_cast<int32_t>(offsetof(DefaultMineSweeperIdentity_t1328286407, ___maxK_20)); }
	inline float get_maxK_20() const { return ___maxK_20; }
	inline float* get_address_of_maxK_20() { return &___maxK_20; }
	inline void set_maxK_20(float value)
	{
		___maxK_20 = value;
	}

	inline static int32_t get_offset_of_allowWatchBomb_21() { return static_cast<int32_t>(offsetof(DefaultMineSweeperIdentity_t1328286407, ___allowWatchBomb_21)); }
	inline bool get_allowWatchBomb_21() const { return ___allowWatchBomb_21; }
	inline bool* get_address_of_allowWatchBomb_21() { return &___allowWatchBomb_21; }
	inline void set_allowWatchBomb_21(bool value)
	{
		___allowWatchBomb_21 = value;
	}

	inline static int32_t get_offset_of_netData_22() { return static_cast<int32_t>(offsetof(DefaultMineSweeperIdentity_t1328286407, ___netData_22)); }
	inline NetData_1_t512747450 * get_netData_22() const { return ___netData_22; }
	inline NetData_1_t512747450 ** get_address_of_netData_22() { return &___netData_22; }
	inline void set_netData_22(NetData_1_t512747450 * value)
	{
		___netData_22 = value;
		Il2CppCodeGenWriteBarrier(&___netData_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
