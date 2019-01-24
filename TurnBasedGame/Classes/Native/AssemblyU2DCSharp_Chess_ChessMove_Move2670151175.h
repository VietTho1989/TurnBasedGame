#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_Chess_Common_Square3637781469.h"
#include "AssemblyU2DCSharp_Chess_Common_PieceType635940010.h"
#include "AssemblyU2DCSharp_Chess_Common_MoveType908581857.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.ChessMove/Move
struct  Move_t2670151175 
{
public:
	// Chess.Common/Square Chess.ChessMove/Move::ori
	int32_t ___ori_0;
	// Chess.Common/Square Chess.ChessMove/Move::dest
	int32_t ___dest_1;
	// Chess.Common/PieceType Chess.ChessMove/Move::promotion
	int32_t ___promotion_2;
	// Chess.Common/MoveType Chess.ChessMove/Move::type
	int32_t ___type_3;

public:
	inline static int32_t get_offset_of_ori_0() { return static_cast<int32_t>(offsetof(Move_t2670151175, ___ori_0)); }
	inline int32_t get_ori_0() const { return ___ori_0; }
	inline int32_t* get_address_of_ori_0() { return &___ori_0; }
	inline void set_ori_0(int32_t value)
	{
		___ori_0 = value;
	}

	inline static int32_t get_offset_of_dest_1() { return static_cast<int32_t>(offsetof(Move_t2670151175, ___dest_1)); }
	inline int32_t get_dest_1() const { return ___dest_1; }
	inline int32_t* get_address_of_dest_1() { return &___dest_1; }
	inline void set_dest_1(int32_t value)
	{
		___dest_1 = value;
	}

	inline static int32_t get_offset_of_promotion_2() { return static_cast<int32_t>(offsetof(Move_t2670151175, ___promotion_2)); }
	inline int32_t get_promotion_2() const { return ___promotion_2; }
	inline int32_t* get_address_of_promotion_2() { return &___promotion_2; }
	inline void set_promotion_2(int32_t value)
	{
		___promotion_2 = value;
	}

	inline static int32_t get_offset_of_type_3() { return static_cast<int32_t>(offsetof(Move_t2670151175, ___type_3)); }
	inline int32_t get_type_3() const { return ___type_3; }
	inline int32_t* get_address_of_type_3() { return &___type_3; }
	inline void set_type_3(int32_t value)
	{
		___type_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
