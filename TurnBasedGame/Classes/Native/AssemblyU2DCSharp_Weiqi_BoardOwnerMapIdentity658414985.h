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
// NetData`1<Weiqi.BoardOwnerMap>
struct NetData_1_t205725684;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.BoardOwnerMapIdentity
struct  BoardOwnerMapIdentity_t658414985  : public DataIdentity_t543951486
{
public:
	// System.Int32 Weiqi.BoardOwnerMapIdentity::playouts
	int32_t ___playouts_17;
	// UnityEngine.Networking.SyncListInt Weiqi.BoardOwnerMapIdentity::map
	SyncListInt_t3316705628 * ___map_18;
	// NetData`1<Weiqi.BoardOwnerMap> Weiqi.BoardOwnerMapIdentity::netData
	NetData_1_t205725684 * ___netData_19;

public:
	inline static int32_t get_offset_of_playouts_17() { return static_cast<int32_t>(offsetof(BoardOwnerMapIdentity_t658414985, ___playouts_17)); }
	inline int32_t get_playouts_17() const { return ___playouts_17; }
	inline int32_t* get_address_of_playouts_17() { return &___playouts_17; }
	inline void set_playouts_17(int32_t value)
	{
		___playouts_17 = value;
	}

	inline static int32_t get_offset_of_map_18() { return static_cast<int32_t>(offsetof(BoardOwnerMapIdentity_t658414985, ___map_18)); }
	inline SyncListInt_t3316705628 * get_map_18() const { return ___map_18; }
	inline SyncListInt_t3316705628 ** get_address_of_map_18() { return &___map_18; }
	inline void set_map_18(SyncListInt_t3316705628 * value)
	{
		___map_18 = value;
		Il2CppCodeGenWriteBarrier(&___map_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(BoardOwnerMapIdentity_t658414985, ___netData_19)); }
	inline NetData_1_t205725684 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t205725684 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t205725684 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct BoardOwnerMapIdentity_t658414985_StaticFields
{
public:
	// System.Int32 Weiqi.BoardOwnerMapIdentity::kListmap
	int32_t ___kListmap_20;

public:
	inline static int32_t get_offset_of_kListmap_20() { return static_cast<int32_t>(offsetof(BoardOwnerMapIdentity_t658414985_StaticFields, ___kListmap_20)); }
	inline int32_t get_kListmap_20() const { return ___kListmap_20; }
	inline int32_t* get_address_of_kListmap_20() { return &___kListmap_20; }
	inline void set_kListmap_20(int32_t value)
	{
		___kListmap_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
