#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListByte
struct SyncListByte_t230810734;
// NetData`1<Weiqi.NeighborColors>
struct NetData_1_t1505200495;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.NeighborColorsIdentity
struct  NeighborColorsIdentity_t2867972820  : public DataIdentity_t543951486
{
public:
	// DataIdentity/SyncListByte Weiqi.NeighborColorsIdentity::colors
	SyncListByte_t230810734 * ___colors_17;
	// NetData`1<Weiqi.NeighborColors> Weiqi.NeighborColorsIdentity::netData
	NetData_1_t1505200495 * ___netData_18;

public:
	inline static int32_t get_offset_of_colors_17() { return static_cast<int32_t>(offsetof(NeighborColorsIdentity_t2867972820, ___colors_17)); }
	inline SyncListByte_t230810734 * get_colors_17() const { return ___colors_17; }
	inline SyncListByte_t230810734 ** get_address_of_colors_17() { return &___colors_17; }
	inline void set_colors_17(SyncListByte_t230810734 * value)
	{
		___colors_17 = value;
		Il2CppCodeGenWriteBarrier(&___colors_17, value);
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(NeighborColorsIdentity_t2867972820, ___netData_18)); }
	inline NetData_1_t1505200495 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1505200495 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1505200495 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

struct NeighborColorsIdentity_t2867972820_StaticFields
{
public:
	// System.Int32 Weiqi.NeighborColorsIdentity::kListcolors
	int32_t ___kListcolors_19;

public:
	inline static int32_t get_offset_of_kListcolors_19() { return static_cast<int32_t>(offsetof(NeighborColorsIdentity_t2867972820_StaticFields, ___kListcolors_19)); }
	inline int32_t get_kListcolors_19() const { return ___kListcolors_19; }
	inline int32_t* get_address_of_kListcolors_19() { return &___kListcolors_19; }
	inline void set_kListcolors_19(int32_t value)
	{
		___kListcolors_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
