#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiMove
struct  WeiqiMove_t49913084  : public GameMove_t1861898997
{
public:
	// VP`1<System.Int32> Weiqi.WeiqiMove::coord
	VP_1_t2450154454 * ___coord_5;
	// VP`1<System.Int32> Weiqi.WeiqiMove::color
	VP_1_t2450154454 * ___color_6;
	// VP`1<System.Int32> Weiqi.WeiqiMove::boardSize
	VP_1_t2450154454 * ___boardSize_7;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(WeiqiMove_t49913084, ___coord_5)); }
	inline VP_1_t2450154454 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t2450154454 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t2450154454 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_color_6() { return static_cast<int32_t>(offsetof(WeiqiMove_t49913084, ___color_6)); }
	inline VP_1_t2450154454 * get_color_6() const { return ___color_6; }
	inline VP_1_t2450154454 ** get_address_of_color_6() { return &___color_6; }
	inline void set_color_6(VP_1_t2450154454 * value)
	{
		___color_6 = value;
		Il2CppCodeGenWriteBarrier(&___color_6, value);
	}

	inline static int32_t get_offset_of_boardSize_7() { return static_cast<int32_t>(offsetof(WeiqiMove_t49913084, ___boardSize_7)); }
	inline VP_1_t2450154454 * get_boardSize_7() const { return ___boardSize_7; }
	inline VP_1_t2450154454 ** get_address_of_boardSize_7() { return &___boardSize_7; }
	inline void set_boardSize_7(VP_1_t2450154454 * value)
	{
		___boardSize_7 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
