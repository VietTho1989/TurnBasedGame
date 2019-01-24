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

// Shogi.EvalList
struct  EvalList_t2435730832  : public Data_t3569509720
{
public:
	// LP`1<System.Int32> Shogi.EvalList::list0
	LP_1_t809621404 * ___list0_7;
	// LP`1<System.Int32> Shogi.EvalList::list1
	LP_1_t809621404 * ___list1_8;
	// LP`1<System.Int32> Shogi.EvalList::listToSquareHand
	LP_1_t809621404 * ___listToSquareHand_9;
	// LP`1<System.Int32> Shogi.EvalList::squareHandToList
	LP_1_t809621404 * ___squareHandToList_10;

public:
	inline static int32_t get_offset_of_list0_7() { return static_cast<int32_t>(offsetof(EvalList_t2435730832, ___list0_7)); }
	inline LP_1_t809621404 * get_list0_7() const { return ___list0_7; }
	inline LP_1_t809621404 ** get_address_of_list0_7() { return &___list0_7; }
	inline void set_list0_7(LP_1_t809621404 * value)
	{
		___list0_7 = value;
		Il2CppCodeGenWriteBarrier(&___list0_7, value);
	}

	inline static int32_t get_offset_of_list1_8() { return static_cast<int32_t>(offsetof(EvalList_t2435730832, ___list1_8)); }
	inline LP_1_t809621404 * get_list1_8() const { return ___list1_8; }
	inline LP_1_t809621404 ** get_address_of_list1_8() { return &___list1_8; }
	inline void set_list1_8(LP_1_t809621404 * value)
	{
		___list1_8 = value;
		Il2CppCodeGenWriteBarrier(&___list1_8, value);
	}

	inline static int32_t get_offset_of_listToSquareHand_9() { return static_cast<int32_t>(offsetof(EvalList_t2435730832, ___listToSquareHand_9)); }
	inline LP_1_t809621404 * get_listToSquareHand_9() const { return ___listToSquareHand_9; }
	inline LP_1_t809621404 ** get_address_of_listToSquareHand_9() { return &___listToSquareHand_9; }
	inline void set_listToSquareHand_9(LP_1_t809621404 * value)
	{
		___listToSquareHand_9 = value;
		Il2CppCodeGenWriteBarrier(&___listToSquareHand_9, value);
	}

	inline static int32_t get_offset_of_squareHandToList_10() { return static_cast<int32_t>(offsetof(EvalList_t2435730832, ___squareHandToList_10)); }
	inline LP_1_t809621404 * get_squareHandToList_10() const { return ___squareHandToList_10; }
	inline LP_1_t809621404 ** get_address_of_squareHandToList_10() { return &___squareHandToList_10; }
	inline void set_squareHandToList_10(LP_1_t809621404 * value)
	{
		___squareHandToList_10 = value;
		Il2CppCodeGenWriteBarrier(&___squareHandToList_10, value);
	}
};

struct EvalList_t2435730832_StaticFields
{
public:
	// System.Boolean Shogi.EvalList::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(EvalList_t2435730832_StaticFields, ___log_5)); }
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
