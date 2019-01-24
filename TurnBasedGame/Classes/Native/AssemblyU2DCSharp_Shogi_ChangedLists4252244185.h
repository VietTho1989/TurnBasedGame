#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<Shogi.ChangedListPair>
struct LP_1_t374304494;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.UInt64>
struct VP_1_t3287473920;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ChangedLists
struct  ChangedLists_t4252244185  : public Data_t3569509720
{
public:
	// LP`1<Shogi.ChangedListPair> Shogi.ChangedLists::clistpair
	LP_1_t374304494 * ___clistpair_6;
	// LP`1<System.Int32> Shogi.ChangedLists::listindex
	LP_1_t809621404 * ___listindex_7;
	// VP`1<System.UInt64> Shogi.ChangedLists::size
	VP_1_t3287473920 * ___size_8;

public:
	inline static int32_t get_offset_of_clistpair_6() { return static_cast<int32_t>(offsetof(ChangedLists_t4252244185, ___clistpair_6)); }
	inline LP_1_t374304494 * get_clistpair_6() const { return ___clistpair_6; }
	inline LP_1_t374304494 ** get_address_of_clistpair_6() { return &___clistpair_6; }
	inline void set_clistpair_6(LP_1_t374304494 * value)
	{
		___clistpair_6 = value;
		Il2CppCodeGenWriteBarrier(&___clistpair_6, value);
	}

	inline static int32_t get_offset_of_listindex_7() { return static_cast<int32_t>(offsetof(ChangedLists_t4252244185, ___listindex_7)); }
	inline LP_1_t809621404 * get_listindex_7() const { return ___listindex_7; }
	inline LP_1_t809621404 ** get_address_of_listindex_7() { return &___listindex_7; }
	inline void set_listindex_7(LP_1_t809621404 * value)
	{
		___listindex_7 = value;
		Il2CppCodeGenWriteBarrier(&___listindex_7, value);
	}

	inline static int32_t get_offset_of_size_8() { return static_cast<int32_t>(offsetof(ChangedLists_t4252244185, ___size_8)); }
	inline VP_1_t3287473920 * get_size_8() const { return ___size_8; }
	inline VP_1_t3287473920 ** get_address_of_size_8() { return &___size_8; }
	inline void set_size_8(VP_1_t3287473920 * value)
	{
		___size_8 = value;
		Il2CppCodeGenWriteBarrier(&___size_8, value);
	}
};

struct ChangedLists_t4252244185_StaticFields
{
public:
	// System.Boolean Shogi.ChangedLists::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(ChangedLists_t4252244185_StaticFields, ___log_5)); }
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
