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
// VP`1<Weiqi.Common/stone>
struct VP_1_t2022265424;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.NoneRule.WeiqiCustomSet
struct  WeiqiCustomSet_t1775426844  : public GameMove_t1861898997
{
public:
	// VP`1<System.Int32> Weiqi.NoneRule.WeiqiCustomSet::coord
	VP_1_t2450154454 * ___coord_5;
	// VP`1<Weiqi.Common/stone> Weiqi.NoneRule.WeiqiCustomSet::piece
	VP_1_t2022265424 * ___piece_6;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(WeiqiCustomSet_t1775426844, ___coord_5)); }
	inline VP_1_t2450154454 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t2450154454 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t2450154454 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_piece_6() { return static_cast<int32_t>(offsetof(WeiqiCustomSet_t1775426844, ___piece_6)); }
	inline VP_1_t2022265424 * get_piece_6() const { return ___piece_6; }
	inline VP_1_t2022265424 ** get_address_of_piece_6() { return &___piece_6; }
	inline void set_piece_6(VP_1_t2022265424 * value)
	{
		___piece_6 = value;
		Il2CppCodeGenWriteBarrier(&___piece_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
