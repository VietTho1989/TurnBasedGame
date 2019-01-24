#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Shogi.Common/HandPiece>
struct VP_1_t2971963327;
// VP`1<Shogi.Common/Color>
struct VP_1_t703898847;
// VP`1<System.UInt32>
struct VP_1_t2527959027;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.HandPieceUI/UIData
struct  UIData_t1587393260  : public Data_t3569509720
{
public:
	// VP`1<Shogi.Common/HandPiece> Shogi.HandPieceUI/UIData::handPiece
	VP_1_t2971963327 * ___handPiece_5;
	// VP`1<Shogi.Common/Color> Shogi.HandPieceUI/UIData::color
	VP_1_t703898847 * ___color_6;
	// VP`1<System.UInt32> Shogi.HandPieceUI/UIData::count
	VP_1_t2527959027 * ___count_7;

public:
	inline static int32_t get_offset_of_handPiece_5() { return static_cast<int32_t>(offsetof(UIData_t1587393260, ___handPiece_5)); }
	inline VP_1_t2971963327 * get_handPiece_5() const { return ___handPiece_5; }
	inline VP_1_t2971963327 ** get_address_of_handPiece_5() { return &___handPiece_5; }
	inline void set_handPiece_5(VP_1_t2971963327 * value)
	{
		___handPiece_5 = value;
		Il2CppCodeGenWriteBarrier(&___handPiece_5, value);
	}

	inline static int32_t get_offset_of_color_6() { return static_cast<int32_t>(offsetof(UIData_t1587393260, ___color_6)); }
	inline VP_1_t703898847 * get_color_6() const { return ___color_6; }
	inline VP_1_t703898847 ** get_address_of_color_6() { return &___color_6; }
	inline void set_color_6(VP_1_t703898847 * value)
	{
		___color_6 = value;
		Il2CppCodeGenWriteBarrier(&___color_6, value);
	}

	inline static int32_t get_offset_of_count_7() { return static_cast<int32_t>(offsetof(UIData_t1587393260, ___count_7)); }
	inline VP_1_t2527959027 * get_count_7() const { return ___count_7; }
	inline VP_1_t2527959027 ** get_address_of_count_7() { return &___count_7; }
	inline void set_count_7(VP_1_t2527959027 * value)
	{
		___count_7 = value;
		Il2CppCodeGenWriteBarrier(&___count_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
