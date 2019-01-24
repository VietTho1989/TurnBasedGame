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
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.PieceUI/UIData
struct  UIData_t121907730  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> InternationalDraught.PieceUI/UIData::square
	VP_1_t2450154454 * ___square_5;
	// VP`1<System.Int32> InternationalDraught.PieceUI/UIData::pieceSide
	VP_1_t2450154454 * ___pieceSide_6;
	// VP`1<System.Boolean> InternationalDraught.PieceUI/UIData::isLastCapture
	VP_1_t4203851724 * ___isLastCapture_7;
	// System.Int32 InternationalDraught.PieceUI/UIData::animationSquare
	int32_t ___animationSquare_8;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t121907730, ___square_5)); }
	inline VP_1_t2450154454 * get_square_5() const { return ___square_5; }
	inline VP_1_t2450154454 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t2450154454 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_pieceSide_6() { return static_cast<int32_t>(offsetof(UIData_t121907730, ___pieceSide_6)); }
	inline VP_1_t2450154454 * get_pieceSide_6() const { return ___pieceSide_6; }
	inline VP_1_t2450154454 ** get_address_of_pieceSide_6() { return &___pieceSide_6; }
	inline void set_pieceSide_6(VP_1_t2450154454 * value)
	{
		___pieceSide_6 = value;
		Il2CppCodeGenWriteBarrier(&___pieceSide_6, value);
	}

	inline static int32_t get_offset_of_isLastCapture_7() { return static_cast<int32_t>(offsetof(UIData_t121907730, ___isLastCapture_7)); }
	inline VP_1_t4203851724 * get_isLastCapture_7() const { return ___isLastCapture_7; }
	inline VP_1_t4203851724 ** get_address_of_isLastCapture_7() { return &___isLastCapture_7; }
	inline void set_isLastCapture_7(VP_1_t4203851724 * value)
	{
		___isLastCapture_7 = value;
		Il2CppCodeGenWriteBarrier(&___isLastCapture_7, value);
	}

	inline static int32_t get_offset_of_animationSquare_8() { return static_cast<int32_t>(offsetof(UIData_t121907730, ___animationSquare_8)); }
	inline int32_t get_animationSquare_8() const { return ___animationSquare_8; }
	inline int32_t* get_address_of_animationSquare_8() { return &___animationSquare_8; }
	inline void set_animationSquare_8(int32_t value)
	{
		___animationSquare_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
