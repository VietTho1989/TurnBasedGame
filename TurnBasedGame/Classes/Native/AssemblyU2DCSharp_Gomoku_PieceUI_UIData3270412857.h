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
// VP`1<Gomoku.Common/Type>
struct VP_1_t996544516;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.PieceUI/UIData
struct  UIData_t3270412857  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Gomoku.PieceUI/UIData::coord
	VP_1_t2450154454 * ___coord_5;
	// VP`1<Gomoku.Common/Type> Gomoku.PieceUI/UIData::type
	VP_1_t996544516 * ___type_6;
	// VP`1<System.Int32> Gomoku.PieceUI/UIData::lastMoveIndex
	VP_1_t2450154454 * ___lastMoveIndex_7;
	// VP`1<System.Boolean> Gomoku.PieceUI/UIData::isWinCoord
	VP_1_t4203851724 * ___isWinCoord_8;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(UIData_t3270412857, ___coord_5)); }
	inline VP_1_t2450154454 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t2450154454 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t2450154454 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_type_6() { return static_cast<int32_t>(offsetof(UIData_t3270412857, ___type_6)); }
	inline VP_1_t996544516 * get_type_6() const { return ___type_6; }
	inline VP_1_t996544516 ** get_address_of_type_6() { return &___type_6; }
	inline void set_type_6(VP_1_t996544516 * value)
	{
		___type_6 = value;
		Il2CppCodeGenWriteBarrier(&___type_6, value);
	}

	inline static int32_t get_offset_of_lastMoveIndex_7() { return static_cast<int32_t>(offsetof(UIData_t3270412857, ___lastMoveIndex_7)); }
	inline VP_1_t2450154454 * get_lastMoveIndex_7() const { return ___lastMoveIndex_7; }
	inline VP_1_t2450154454 ** get_address_of_lastMoveIndex_7() { return &___lastMoveIndex_7; }
	inline void set_lastMoveIndex_7(VP_1_t2450154454 * value)
	{
		___lastMoveIndex_7 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveIndex_7, value);
	}

	inline static int32_t get_offset_of_isWinCoord_8() { return static_cast<int32_t>(offsetof(UIData_t3270412857, ___isWinCoord_8)); }
	inline VP_1_t4203851724 * get_isWinCoord_8() const { return ___isWinCoord_8; }
	inline VP_1_t4203851724 ** get_address_of_isWinCoord_8() { return &___isWinCoord_8; }
	inline void set_isWinCoord_8(VP_1_t4203851724 * value)
	{
		___isWinCoord_8 = value;
		Il2CppCodeGenWriteBarrier(&___isWinCoord_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
