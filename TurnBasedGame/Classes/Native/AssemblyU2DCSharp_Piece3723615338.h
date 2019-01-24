#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"
#include "AssemblyU2DCSharp_Piece_Position3293915964.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Piece
struct  Piece_t3723615338  : public Data_t3569509720
{
public:

public:
};

struct Piece_t3723615338_StaticFields
{
public:
	// Piece/Position Piece::UnknownPosition
	Position_t3293915964  ___UnknownPosition_5;
	// Piece/Position Piece::EatenPosition
	Position_t3293915964  ___EatenPosition_6;

public:
	inline static int32_t get_offset_of_UnknownPosition_5() { return static_cast<int32_t>(offsetof(Piece_t3723615338_StaticFields, ___UnknownPosition_5)); }
	inline Position_t3293915964  get_UnknownPosition_5() const { return ___UnknownPosition_5; }
	inline Position_t3293915964 * get_address_of_UnknownPosition_5() { return &___UnknownPosition_5; }
	inline void set_UnknownPosition_5(Position_t3293915964  value)
	{
		___UnknownPosition_5 = value;
	}

	inline static int32_t get_offset_of_EatenPosition_6() { return static_cast<int32_t>(offsetof(Piece_t3723615338_StaticFields, ___EatenPosition_6)); }
	inline Position_t3293915964  get_EatenPosition_6() const { return ___EatenPosition_6; }
	inline Position_t3293915964 * get_address_of_EatenPosition_6() { return &___EatenPosition_6; }
	inline void set_EatenPosition_6(Position_t3293915964  value)
	{
		___EatenPosition_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
