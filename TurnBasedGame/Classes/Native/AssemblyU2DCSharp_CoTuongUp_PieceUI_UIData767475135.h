#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Byte>
struct VP_1_t4061381442;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.PieceUI/UIData
struct  UIData_t767475135  : public Data_t3569509720
{
public:
	// VP`1<System.Byte> CoTuongUp.PieceUI/UIData::coord
	VP_1_t4061381442 * ___coord_5;
	// VP`1<System.Byte> CoTuongUp.PieceUI/UIData::piece
	VP_1_t4061381442 * ___piece_6;
	// System.Byte CoTuongUp.PieceUI/UIData::animationCoord
	uint8_t ___animationCoord_7;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(UIData_t767475135, ___coord_5)); }
	inline VP_1_t4061381442 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t4061381442 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t4061381442 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_piece_6() { return static_cast<int32_t>(offsetof(UIData_t767475135, ___piece_6)); }
	inline VP_1_t4061381442 * get_piece_6() const { return ___piece_6; }
	inline VP_1_t4061381442 ** get_address_of_piece_6() { return &___piece_6; }
	inline void set_piece_6(VP_1_t4061381442 * value)
	{
		___piece_6 = value;
		Il2CppCodeGenWriteBarrier(&___piece_6, value);
	}

	inline static int32_t get_offset_of_animationCoord_7() { return static_cast<int32_t>(offsetof(UIData_t767475135, ___animationCoord_7)); }
	inline uint8_t get_animationCoord_7() const { return ___animationCoord_7; }
	inline uint8_t* get_address_of_animationCoord_7() { return &___animationCoord_7; }
	inline void set_animationCoord_7(uint8_t value)
	{
		___animationCoord_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
