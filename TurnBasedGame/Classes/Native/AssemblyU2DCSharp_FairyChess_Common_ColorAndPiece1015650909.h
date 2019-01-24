#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Color1267941922.h"
#include "AssemblyU2DCSharp_FairyChess_Common_PieceType2850651519.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.Common/ColorAndPiece
struct  ColorAndPiece_t1015650909  : public Il2CppObject
{
public:
	// FairyChess.Common/Color FairyChess.Common/ColorAndPiece::color
	int32_t ___color_0;
	// FairyChess.Common/PieceType FairyChess.Common/ColorAndPiece::pieceType
	int32_t ___pieceType_1;

public:
	inline static int32_t get_offset_of_color_0() { return static_cast<int32_t>(offsetof(ColorAndPiece_t1015650909, ___color_0)); }
	inline int32_t get_color_0() const { return ___color_0; }
	inline int32_t* get_address_of_color_0() { return &___color_0; }
	inline void set_color_0(int32_t value)
	{
		___color_0 = value;
	}

	inline static int32_t get_offset_of_pieceType_1() { return static_cast<int32_t>(offsetof(ColorAndPiece_t1015650909, ___pieceType_1)); }
	inline int32_t get_pieceType_1() const { return ___pieceType_1; }
	inline int32_t* get_address_of_pieceType_1() { return &___pieceType_1; }
	inline void set_pieceType_1(int32_t value)
	{
		___pieceType_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
