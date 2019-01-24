#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Int32>
struct LP_1_t809621404;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.BoardOwnerMap
struct  BoardOwnerMap_t4254344455  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Weiqi.BoardOwnerMap::playouts
	VP_1_t2450154454 * ___playouts_6;
	// LP`1<System.Int32> Weiqi.BoardOwnerMap::map
	LP_1_t809621404 * ___map_7;

public:
	inline static int32_t get_offset_of_playouts_6() { return static_cast<int32_t>(offsetof(BoardOwnerMap_t4254344455, ___playouts_6)); }
	inline VP_1_t2450154454 * get_playouts_6() const { return ___playouts_6; }
	inline VP_1_t2450154454 ** get_address_of_playouts_6() { return &___playouts_6; }
	inline void set_playouts_6(VP_1_t2450154454 * value)
	{
		___playouts_6 = value;
		Il2CppCodeGenWriteBarrier(&___playouts_6, value);
	}

	inline static int32_t get_offset_of_map_7() { return static_cast<int32_t>(offsetof(BoardOwnerMap_t4254344455, ___map_7)); }
	inline LP_1_t809621404 * get_map_7() const { return ___map_7; }
	inline LP_1_t809621404 ** get_address_of_map_7() { return &___map_7; }
	inline void set_map_7(LP_1_t809621404 * value)
	{
		___map_7 = value;
		Il2CppCodeGenWriteBarrier(&___map_7, value);
	}
};

struct BoardOwnerMap_t4254344455_StaticFields
{
public:
	// System.Boolean Weiqi.BoardOwnerMap::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(BoardOwnerMap_t4254344455_StaticFields, ___log_5)); }
	inline bool get_log_5() const { return ___log_5; }
	inline bool* get_address_of_log_5() { return &___log_5; }
	inline void set_log_5(bool value)
	{
		___log_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
