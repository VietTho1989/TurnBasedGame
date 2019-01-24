#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<System.Int32>
struct LP_1_t809621404;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ChangedListPair
struct  ChangedListPair_t1636560538  : public Data_t3569509720
{
public:
	// LP`1<System.Int32> Shogi.ChangedListPair::newList
	LP_1_t809621404 * ___newList_6;
	// LP`1<System.Int32> Shogi.ChangedListPair::oldlist
	LP_1_t809621404 * ___oldlist_7;

public:
	inline static int32_t get_offset_of_newList_6() { return static_cast<int32_t>(offsetof(ChangedListPair_t1636560538, ___newList_6)); }
	inline LP_1_t809621404 * get_newList_6() const { return ___newList_6; }
	inline LP_1_t809621404 ** get_address_of_newList_6() { return &___newList_6; }
	inline void set_newList_6(LP_1_t809621404 * value)
	{
		___newList_6 = value;
		Il2CppCodeGenWriteBarrier(&___newList_6, value);
	}

	inline static int32_t get_offset_of_oldlist_7() { return static_cast<int32_t>(offsetof(ChangedListPair_t1636560538, ___oldlist_7)); }
	inline LP_1_t809621404 * get_oldlist_7() const { return ___oldlist_7; }
	inline LP_1_t809621404 ** get_address_of_oldlist_7() { return &___oldlist_7; }
	inline void set_oldlist_7(LP_1_t809621404 * value)
	{
		___oldlist_7 = value;
		Il2CppCodeGenWriteBarrier(&___oldlist_7, value);
	}
};

struct ChangedListPair_t1636560538_StaticFields
{
public:
	// System.Boolean Shogi.ChangedListPair::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(ChangedListPair_t1636560538_StaticFields, ___log_5)); }
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
