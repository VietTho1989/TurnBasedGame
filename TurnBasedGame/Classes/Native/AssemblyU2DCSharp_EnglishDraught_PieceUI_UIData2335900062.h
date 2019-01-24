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
// VP`1<System.Byte>
struct VP_1_t4061381442;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.PieceUI/UIData
struct  UIData_t2335900062  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> EnglishDraught.PieceUI/UIData::square
	VP_1_t2450154454 * ___square_5;
	// VP`1<System.Byte> EnglishDraught.PieceUI/UIData::piece
	VP_1_t4061381442 * ___piece_6;
	// System.Int32 EnglishDraught.PieceUI/UIData::animationSquare
	int32_t ___animationSquare_7;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t2335900062, ___square_5)); }
	inline VP_1_t2450154454 * get_square_5() const { return ___square_5; }
	inline VP_1_t2450154454 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t2450154454 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_piece_6() { return static_cast<int32_t>(offsetof(UIData_t2335900062, ___piece_6)); }
	inline VP_1_t4061381442 * get_piece_6() const { return ___piece_6; }
	inline VP_1_t4061381442 ** get_address_of_piece_6() { return &___piece_6; }
	inline void set_piece_6(VP_1_t4061381442 * value)
	{
		___piece_6 = value;
		Il2CppCodeGenWriteBarrier(&___piece_6, value);
	}

	inline static int32_t get_offset_of_animationSquare_7() { return static_cast<int32_t>(offsetof(UIData_t2335900062, ___animationSquare_7)); }
	inline int32_t get_animationSquare_7() const { return ___animationSquare_7; }
	inline int32_t* get_address_of_animationSquare_7() { return &___animationSquare_7; }
	inline void set_animationSquare_7(int32_t value)
	{
		___animationSquare_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
