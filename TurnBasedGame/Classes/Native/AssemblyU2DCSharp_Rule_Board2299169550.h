#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[0...,0...]
struct ByteU5BU2CU5D_t3397334014;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rule.Board
struct  Board_t2299169550  : public Il2CppObject
{
public:
	// System.Byte[0...,0...] Rule.Board::board
	ByteU5BU2CU5D_t3397334014* ___board_0;
	// System.Byte[0...,0...] Rule.Board::side
	ByteU5BU2CU5D_t3397334014* ___side_1;

public:
	inline static int32_t get_offset_of_board_0() { return static_cast<int32_t>(offsetof(Board_t2299169550, ___board_0)); }
	inline ByteU5BU2CU5D_t3397334014* get_board_0() const { return ___board_0; }
	inline ByteU5BU2CU5D_t3397334014** get_address_of_board_0() { return &___board_0; }
	inline void set_board_0(ByteU5BU2CU5D_t3397334014* value)
	{
		___board_0 = value;
		Il2CppCodeGenWriteBarrier(&___board_0, value);
	}

	inline static int32_t get_offset_of_side_1() { return static_cast<int32_t>(offsetof(Board_t2299169550, ___side_1)); }
	inline ByteU5BU2CU5D_t3397334014* get_side_1() const { return ___side_1; }
	inline ByteU5BU2CU5D_t3397334014** get_address_of_side_1() { return &___side_1; }
	inline void set_side_1(ByteU5BU2CU5D_t3397334014* value)
	{
		___side_1 = value;
		Il2CppCodeGenWriteBarrier(&___side_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
