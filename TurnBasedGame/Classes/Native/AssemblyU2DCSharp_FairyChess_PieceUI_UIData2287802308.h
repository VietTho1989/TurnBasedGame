#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<FairyChess.Common/VariantType>
struct VP_1_t3949171818;
// VP`1<FairyChess.Common/Piece>
struct VP_1_t880072437;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.PieceUI/UIData
struct  UIData_t2287802308  : public Data_t3569509720
{
public:
	// VP`1<FairyChess.Common/VariantType> FairyChess.PieceUI/UIData::variantType
	VP_1_t3949171818 * ___variantType_5;
	// VP`1<FairyChess.Common/Piece> FairyChess.PieceUI/UIData::piece
	VP_1_t880072437 * ___piece_6;
	// VP`1<System.Int32> FairyChess.PieceUI/UIData::position
	VP_1_t2450154454 * ___position_7;

public:
	inline static int32_t get_offset_of_variantType_5() { return static_cast<int32_t>(offsetof(UIData_t2287802308, ___variantType_5)); }
	inline VP_1_t3949171818 * get_variantType_5() const { return ___variantType_5; }
	inline VP_1_t3949171818 ** get_address_of_variantType_5() { return &___variantType_5; }
	inline void set_variantType_5(VP_1_t3949171818 * value)
	{
		___variantType_5 = value;
		Il2CppCodeGenWriteBarrier(&___variantType_5, value);
	}

	inline static int32_t get_offset_of_piece_6() { return static_cast<int32_t>(offsetof(UIData_t2287802308, ___piece_6)); }
	inline VP_1_t880072437 * get_piece_6() const { return ___piece_6; }
	inline VP_1_t880072437 ** get_address_of_piece_6() { return &___piece_6; }
	inline void set_piece_6(VP_1_t880072437 * value)
	{
		___piece_6 = value;
		Il2CppCodeGenWriteBarrier(&___piece_6, value);
	}

	inline static int32_t get_offset_of_position_7() { return static_cast<int32_t>(offsetof(UIData_t2287802308, ___position_7)); }
	inline VP_1_t2450154454 * get_position_7() const { return ___position_7; }
	inline VP_1_t2450154454 ** get_address_of_position_7() { return &___position_7; }
	inline void set_position_7(VP_1_t2450154454 * value)
	{
		___position_7 = value;
		Il2CppCodeGenWriteBarrier(&___position_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
