#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// LP`1<System.Int32>
struct LP_1_t809621404;
// LP`1<System.Byte>
struct LP_1_t2420848392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.MoveQueue
struct  MoveQueue_t272323230  : public Data_t3569509720
{
public:
	// VP`1<System.UInt32> Weiqi.MoveQueue::moves
	VP_1_t2527959027 * ___moves_7;
	// LP`1<System.Int32> Weiqi.MoveQueue::move
	LP_1_t809621404 * ___move_8;
	// LP`1<System.Byte> Weiqi.MoveQueue::tag
	LP_1_t2420848392 * ___tag_9;

public:
	inline static int32_t get_offset_of_moves_7() { return static_cast<int32_t>(offsetof(MoveQueue_t272323230, ___moves_7)); }
	inline VP_1_t2527959027 * get_moves_7() const { return ___moves_7; }
	inline VP_1_t2527959027 ** get_address_of_moves_7() { return &___moves_7; }
	inline void set_moves_7(VP_1_t2527959027 * value)
	{
		___moves_7 = value;
		Il2CppCodeGenWriteBarrier(&___moves_7, value);
	}

	inline static int32_t get_offset_of_move_8() { return static_cast<int32_t>(offsetof(MoveQueue_t272323230, ___move_8)); }
	inline LP_1_t809621404 * get_move_8() const { return ___move_8; }
	inline LP_1_t809621404 ** get_address_of_move_8() { return &___move_8; }
	inline void set_move_8(LP_1_t809621404 * value)
	{
		___move_8 = value;
		Il2CppCodeGenWriteBarrier(&___move_8, value);
	}

	inline static int32_t get_offset_of_tag_9() { return static_cast<int32_t>(offsetof(MoveQueue_t272323230, ___tag_9)); }
	inline LP_1_t2420848392 * get_tag_9() const { return ___tag_9; }
	inline LP_1_t2420848392 ** get_address_of_tag_9() { return &___tag_9; }
	inline void set_tag_9(LP_1_t2420848392 * value)
	{
		___tag_9 = value;
		Il2CppCodeGenWriteBarrier(&___tag_9, value);
	}
};

struct MoveQueue_t272323230_StaticFields
{
public:
	// System.Boolean Weiqi.MoveQueue::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(MoveQueue_t272323230_StaticFields, ___log_5)); }
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
